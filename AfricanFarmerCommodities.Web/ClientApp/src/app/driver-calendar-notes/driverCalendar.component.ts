import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter, AfterContentInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IDriver, IAddress, ILocation, AfricanFarmerCommoditiesService, IVehicle, ITransportSchedule, IDriverNote, ITransportLog, IInvoice } from '../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
import * as $ from 'jquery';
import * as moment from 'moment';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';
import { CalendarOptions, Calendar, formatDate } from '@fullcalendar/core';
import momentPlugin from '@fullcalendar/moment';
import dayGridPlugin from '@fullcalendar/daygrid';
import timeGridPlugin from '@fullcalendar/timegrid';
import interactionPlugin from '@fullcalendar/interaction';


@Component({
  selector: 'driver-calendar',
  templateUrl: './driverCalendar.component.html',
  styleUrls: ['./driverCalendar.component.css'],
  providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class DriverCalendarComponent implements OnInit, AfterContentInit {

  drivers: IDriver[];
  driverNotes: IDriverNote[];
  transportSchedules: ITransportSchedule[];
  private events = [];
  public calendar: Calendar;
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  public driverOriginNoteContent: string;
  public driverDestinationNoteContent: string;
  public invoiceId: number;

  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
  }
  public driver: IDriver | any
  public transportSchedule: ITransportSchedule | any;

  addInvoicedOrderToTransportSchedule(): void {
    let invoiceIdSelect: HTMLSelectElement = document.querySelector('select#tsPaidInvoicedOrdersId');
    let invoiceName: string = invoiceIdSelect.selectedOptions[0].text;
    let invoiceId: number = parseInt(invoiceIdSelect.value);
    let transLog: ITransportLog = {
      transportLogId: 0,
      invoiceId: invoiceId,
      transportLogName: invoiceName,
      transportScheduleId: this.transportSchedule.transportScheduleId
    }

    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.CreateTransportScheduleLog(transLog);
    actualResult.map((p: any) => {
      if (p.result) {
        alert('TransportSchedule Added: ' + p.message);
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
  }
  removeInvoicedOrderFromTransportSchedule(): void {
    let invoiceIdSelect: HTMLSelectElement = document.querySelector('select#tsPaidInvoicedOrdersId');
    let invoiceName: string = invoiceIdSelect.selectedOptions[0].text;
    let invoiceId:number = parseInt(invoiceIdSelect.value);
    let transLog: ITransportLog = {
      transportLogId: 0,
      invoiceId: invoiceId,
      transportLogName: invoiceName,
      transportScheduleId: this.transportSchedule.transportScheduleId
    }

    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.DeleteTransportScheduleLog(transLog);
    actualResult.map((p: any) => {
      if (p.result) {
        alert('Invoice Removed: ' + p.message);
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
  }
  public onchangeTransportSchedule() {

    let tranSchIdSelect: HTMLSelectElement = document.querySelector('select#dritransportScheduleId');
    //let invoiceName: string = tranSchIdSelect.selectedOptions[0].text;
    let transportScheduleId: number = parseInt(tranSchIdSelect.value);

    let transShed: Observable<ITransportSchedule> = this.africanFarmerCommoditiesService.GetTransportScheduleId(transportScheduleId);
    transShed.map((p: ITransportSchedule) => {
      this.driver.transportSchedule = p;
      let transScheLog: Observable<ITransportLog> = this.africanFarmerCommoditiesService.GetCurrentTransScheduleInvoiceLog(p.transportScheduleId);
      transScheLog.map((q: ITransportLog) => {
        let selectInvoice: HTMLSelectElement = document.querySelector('select#tsPaidInvoicedOrdersId');
        selectInvoice.value = q.invoiceId.toString();
        this.invoiceId = q.invoiceId;
      }).subscribe();
      this.setDriverCalendarNotes();
    }).subscribe();
  }
  public addDriver(): void {

    this.driver.driverId = 0;
    this.driver.vehicleId = this.driver.vehicle.vehicleId;
    this.driver.transportScheduleId = this.driver.transportSchedule.transportScheduleId;
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.PostOrCreateDriver(this.driver);
    actualResult.map((p: any) => {
      if (p.result) {
        alert('Driver Added: ' + p.result);
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
  }

  public updateDriver() {
    this.driver.vehicleId = this.driver.vehicle.vehicleId;
    this.driver.transportScheduleId = this.driver.transportSchedule.transportScheduleId;
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.UpdateDriver(this.driver);
    actualResult.map((p: any) => {
      if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
  }

  public selectDriver(): void {

    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.GetDriverById(this.driver.driverId);
    actualResult.map((p: any) => {
      this.driver.firstName = p.firstName;
      this.driver.lastName = p.lastName;
      this.driver.transportId = p.transportId;
      this.driver.vehicle.vehicleId = p.vehicleId;

      this.transportSchedule = this.transportSchedules.find((q: ITransportSchedule) => {
        return q.transportScheduleId == this.driver.transportSchedule.transportScheduleId;
      });

      this.driver.transportSchedule = this.transportSchedule;
      this.driver.transportScheduleId = this.driver.transportSchedule.transportScheduleId;

      let transScheLog: Observable<ITransportLog> = this.africanFarmerCommoditiesService.GetCurrentTransScheduleInvoiceLog(this.transportSchedule.transportScheduleId);
      transScheLog.map((q: ITransportLog) => {
        let selectInvoice: HTMLSelectElement = document.querySelector('select#tsPaidInvoicedOrdersId');
        selectInvoice.value = q.invoiceId.toString();
        this.invoiceId = q.invoiceId;
      }).subscribe();
      this.setDriverCalendarNotes();

    }).subscribe();
  }
  public setDriverCalendarNotes() {
    if (this.driverNotes.length > 0) {

      let currentOriginDriverNote: IDriverNote = this.driverNotes.find((q: IDriverNote) => {
        return q.transportScheduleId == this.driver.transportSchedule.transportScheduleId &&
          q.isOriginNote
      });
      if (currentOriginDriverNote) {
        this.driverOriginNoteContent = currentOriginDriverNote.driverNote;
      }

      let currentDestinationDriverNote: IDriverNote = this.driverNotes.find((q: IDriverNote) => {
        return q.transportScheduleId == this.driver.transportSchedule.transportScheduleId &&
          !q.isOriginNote
      });

      if (currentDestinationDriverNote) {
        this.driverDestinationNoteContent = currentDestinationDriverNote.driverNote;
      }
    }
  }
  public deleteDriver() {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.DeleteDriver(this.driver);
    actualResult.map((p: any) => {
      alert('Driver Deleted: ' + p.result); if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
  }
  public goToDateAtOrigin(): void {

    if (this.driver.transportSchedule.dateStartFromOrigin) {
      this.calendar.gotoDate(this.driver.transportSchedule.dateStartFromOrigin);
      document.getElementById('mainbodycontent').scrollIntoView({
        behavior: "smooth"
      });
    }
    else {
      this.calendar.gotoDate(new Date());
      document.getElementById('mainbodycontent').scrollIntoView({
        behavior: "smooth"
      });
    }
  }
  public goToDateAtDestination(): void {
    if (this.driver.transportSchedule.dateEndAtDestination) {
      this.calendar.gotoDate(this.driver.transportSchedule.dateEndAtDestination);
      document.getElementById('mainbodycontent').scrollIntoView({
        behavior: "smooth"
      });
    }
    else {
      this.calendar.gotoDate(new Date()); document.getElementById('mainbodycontent').scrollIntoView({
        behavior: "smooth"
      });
    }
  }
  public ngOnInit(): void {
    this.events = [];
    this.driver = {
      driverId: 0,
      firstName: "",
      lastName: "",
      transportScheduleId: 0,
      transportSchedule: {},
      vehicleId: 0,
      vehicle: {},
      dateCreated: "",
      dateUpdated: ""
    };

    let driverNotesObs: Observable<IDriverNote[]> = this.africanFarmerCommoditiesService.GetDriverScheduleNotes();
    let schedsObs: Observable<ITransportSchedule[]> = this.africanFarmerCommoditiesService.GetAllTransportSchedules();
    let driversObs: Observable<IDriver[]> = this.africanFarmerCommoditiesService.GetAllDrivers();
    var calendarDiv: HTMLElement = document.querySelector('div#driverCalendar');

    let calOptions: CalendarOptions = {

      plugins: [timeGridPlugin, dayGridPlugin, momentPlugin, interactionPlugin],
      initialView: 'dayGridMonth',
      themeSystem: 'jquery-ui',
      initialDate: new Date().toISOString(),
      headerToolbar: {
        left: 'prev,next,today',
        center: 'title',
        right: 'dayGridMonth,timeGridWeek,timeGridDay'
      },
      handleWindowResize: true,
      contentHeight: 650,
      navLinks: true, // can click day/week names to navigate views
      editable: true,
      events: this.events
    };

    //this.calendar.destroy();
    this.calendar = new Calendar(calendarDiv, calOptions);
    let cal = this.calendar;

      $('a#previousMonth').click(function () {
        var currentDate = new Date();
        currentDate.setMonth(currentDate.getMonth() - 1);
        cal.gotoDate(currentDate);
        //fullCallendar.pignoseCalendar({ date: currentDate});
        return false;
      });
      $('a#nextMonth').click(function () {
        var currentDate = new Date();
        currentDate.setMonth(currentDate.getMonth() + 1);
        cal.gotoDate(currentDate);
        //fullCallendar.pignoseCalendar({ date: currentDate });
        return false;
      });
      $('a#currentMonth').click(function () {
        var currentDate = new Date();
        cal.gotoDate(currentDate);
        //fullCallendar.pignoseCalendar({ date: currentDate});
        return false;
      });
      $('a#previousMonth').click(function () {
        var currentDate = new Date();
        currentDate.setMonth(currentDate.getMonth() - 1);
        cal.gotoDate(currentDate);
        //fullCallendar.pignoseCalendar({ date: currentDate});
        return false;
      });
      $('a#nextMonth').click(function () {
        var currentDate = new Date();
        currentDate.setMonth(currentDate.getMonth() + 1);
        cal.gotoDate(currentDate);
        //fullCallendar.pignoseCalendar({ date: currentDate });
        return false;
      });
      $('a#currentMonth').click(function () {
        var currentDate = new Date();
        cal.gotoDate(currentDate);
        //fullCallendar.pignoseCalendar({ date: currentDate});
        return false;
      });

      driverNotesObs.map((resDrNotes: IDriverNote[]) => {
        if (resDrNotes.length > 0) {

          this.driverNotes = resDrNotes;
          schedsObs.map((tranSches: ITransportSchedule[]) => {
            this.transportSchedules = tranSches;

            driversObs.map((d: IDriver[]) => {
              this.drivers = d;

              if (this.transportSchedules && this.transportSchedules.length > 0) {

                for (var n = 0; n < this.transportSchedules.length; n++) {

                  let calendarScheduleItem: ITransportSchedule = this.transportSchedules[n];

                  if (this.driverNotes && this.driverNotes.length > 0) {
                    let originContent: string = "";
                    let destContent: string = "";

                    let driverOriNote: IDriverNote = this.driverNotes.find((q: IDriverNote) => {
                      return q.transportScheduleId === calendarScheduleItem.transportScheduleId &&
                        q.isOriginNote;
                    });
                    let driverDestNote: IDriverNote = this.driverNotes.find((q: IDriverNote) => {
                      return q.transportScheduleId === calendarScheduleItem.transportScheduleId &&
                        !q.isOriginNote;
                    });
                    this.driver.transportSchedule = calendarScheduleItem;

                    if (driverOriNote) {

                      originContent = calendarScheduleItem.originName.locationName + ", " + driverOriNote.driverName + ', driver Id: ' + driverOriNote.driverId + '\r' + driverOriNote.isOriginNote.toString() + "\r" + driverOriNote.driverNote + "\r";
                    }
                    if (driverDestNote) {
                      destContent = calendarScheduleItem.destinationName.locationName + ", " + driverDestNote.driverName + ', driver Id: ' + driverDestNote.driverId + '\r' + driverDestNote.isOriginNote.toString() + "\r" + driverDestNote.driverNote + "\r";
                    }
                    let transportSched: string = calendarScheduleItem.transportScheduleName + '\r TransportScheduleId: ' + calendarScheduleItem.transportScheduleId + '\rOrigin Name\r' + calendarScheduleItem.originName.locationName + ', to \rDestination Name\r ' + calendarScheduleItem.destinationName.locationName;
                    var startDate = new Date(calendarScheduleItem.dateStartFromOrigin).toISOString();
                    var endDate = new Date(calendarScheduleItem.dateEndAtDestination).toISOString();
                    this.events.push({
                      start: startDate,
                      title: transportSched + '\rDriver Notes for Origin: ' + '\r\r' + originContent
                    });
                    this.events.push({
                      start: endDate,
                      title: transportSched + '\rNotes for Destination: ' + '\r\r' + destContent
                    });

                    //this.calendar.destroy();
                    this.calendar = new Calendar(calendarDiv, calOptions);
                    this.calendar.addEventSource(this.events);
                    this.calendar.render();
                  }
                }
              }
              document.querySelector('style').textContent += "@media screen and (max-width:767px) { .fc-toolbar.fc-header-toolbar {flex-direction:column;} .fc-toolbar-chunk { display: table-row; text-align:center; padding:5px 0; } }";

            }).subscribe();
          }).subscribe();
        }
        else {
          //this.calendar.destroy();
          this.calendar = new Calendar(calendarDiv, calOptions);
          this.calendar.render();
        }
      }).subscribe();
  }

  ngAfterContentInit(): void {
    const driversObs: Observable<IDriver[]> = this.africanFarmerCommoditiesService.GetAllDrivers();
    const vehObs: Observable<IVehicle[]> = this.africanFarmerCommoditiesService.GetAllVehicles();
    const schedsObs: Observable<ITransportSchedule[]> = this.africanFarmerCommoditiesService.GetAllTransportSchedules();
    const tsOrders: Observable<any[]> = this.africanFarmerCommoditiesService.GetUserInvoicedItems(AfricanFarmerCommoditiesService.clientEmailAddress);


    let optionElem: HTMLOptionElement = document.createElement('option');
    optionElem.selected = true;
    optionElem.value = (0).toString();
    optionElem.text = "Select Driver";
    document.querySelector('select#driverId').append(optionElem);


    optionElem = document.createElement('option');
    optionElem.value = (0).toString();
    optionElem.text = "Select Vehicle";
    document.querySelector('select#drivehicleId').append(optionElem);

    optionElem = document.createElement('option');
    optionElem.value = (0).toString();
    optionElem.text = "Select Schedule";
    document.querySelector('select#dritransportScheduleId').append(optionElem);

    optionElem = document.createElement('option');
    optionElem.selected = true;
    optionElem.value = (0).toString();
    optionElem.text = "Select Invoiced Order";
    document.querySelector('select#tsPaidInvoicedOrdersId').append(optionElem);

    driversObs.map((cmds: IDriver[]) => {
      cmds.forEach((cmd: IDriver, index: number, cmds) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = cmd.driverId.toString();
        optionElem.text = cmd.firstName + " " + cmd.lastName;
        document.querySelector('select#driverId').append(optionElem);
      });
    }).subscribe();

    vehObs.map((cmdCats: IVehicle[]) => {
      cmdCats.forEach((comCat: IVehicle, index: number, cmdCats) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = comCat.vehicleId.toString();
        optionElem.text = comCat.vehicleRegistration;
        document.querySelector('select#drivehicleId').append(optionElem);
      });
    }).subscribe();

    schedsObs.map((cmdUnits: ITransportSchedule[]) => {
      cmdUnits.forEach((cmdUnit: ITransportSchedule, index: number, cmdUnits) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = cmdUnit.transportScheduleId.toString();
        optionElem.text = cmdUnit.transportScheduleName;
        document.querySelector('select#dritransportScheduleId').append(optionElem);
      });

      tsOrders.map((cmds: IInvoice[]) => {
        cmds.forEach((cmd: IInvoice, index: number, cmds) => {
          let optionElem: HTMLOptionElement = document.createElement('option');
          optionElem.value = cmd.invoiceId.toString();
          optionElem.text = cmd.invoiceName + new Date(cmd.dateUpdated).toUTCString();
          document.querySelector('select#tsPaidInvoicedOrdersId').append(optionElem);
        });
      }).subscribe();
    }).subscribe();
  }

  addOriginNote() {
    let driverObs: Observable<IDriver> = this.africanFarmerCommoditiesService.GetDriverByTransportScheduleId(this.driver.transportSchedule.transportScheduleId);

    driverObs.map((q: any) => {
      let driver: IDriver = q;
      if (driver) {
        let originNoteObj: IDriverNote = {
          driverId: driver.driverId,
          driverName: driver.firstName + " " + driver.lastName,
          transportScheduleId: this.driver.transportSchedule.transportScheduleId,
          driverNote: this.driverOriginNoteContent,
          isOriginNote: true
        };

        let actualResult: Observable<any> = this.africanFarmerCommoditiesService.addDriverNote(originNoteObj);
        actualResult.map((p: any) => {
          alert(p.message);
         //this.ngOnInit();
        }).subscribe();
      }
      else {
        alert("Driver not found!");
      }
    }).subscribe();
  }

  addDestinationNote() {
    let driverObs: Observable<IDriver> = this.africanFarmerCommoditiesService.GetDriverByTransportScheduleId(this.driver.transportSchedule.transportScheduleId);

    driverObs.map((q: any) => {
      let driver: IDriver = q;
      if (driver) {
        let destinationNoteObj: IDriverNote = {
          driverId: driver.driverId,
          driverName: driver.firstName + " " + driver.lastName,
          transportScheduleId: this.driver.transportSchedule.transportScheduleId,
          driverNote: this.driverDestinationNoteContent,
          isOriginNote: false
        };

        let actualResult: Observable<any> = this.africanFarmerCommoditiesService.addDriverNote(destinationNoteObj);
        actualResult.map((p: any) => {
          alert(p.message);
          //this.ngOnInit();
        }).subscribe();
      }
      else {
        alert("Driver not found!");
      }
    }).subscribe();
  }

}
