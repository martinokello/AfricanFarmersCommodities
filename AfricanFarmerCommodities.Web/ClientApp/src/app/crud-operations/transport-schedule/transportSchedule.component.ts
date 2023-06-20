import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter, AfterContentInit, AfterViewChecked } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ITransportSchedule,IAddress, ILocation, AfricanFarmerCommoditiesService, ITransportPricing, IVehicle, IIntermediateSchedule, IInvoice, ITransportLog, IDriverNote, IDriver } from '../../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
declare var jQuery: any;
import { datetimepicker } from 'jquery-datetimepicker';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';
import { AfterViewInit } from '@angular/core';

@Component({
  selector: 'transport-schedule',
  templateUrl: './transportSchedule.component.html',
  styleUrls: ['./transportSchedule.component.css'],
  providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class TransportScheduleComponent implements OnInit, AfterContentInit, AfterViewInit, AfterViewChecked {
  hasPopulatedPage: boolean = false;
  setTo: NodeJS.Timeout;
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;

  public intemediateShedules: IIntermediateSchedule[];
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
  }
  public transportSchedule: ITransportSchedule | any;

  public addTransportSchedule(): void {
    this.transportSchedule.dateStartFromOrigin = jQuery('input#dateStartFromOrigin').val();
    this.transportSchedule.dateEndAtDestination = jQuery('input#dateEndAtDestination').val();
    this.transportSchedule.transportScheduleId = 0;
    this.transportSchedule.transportPricingId = this.transportSchedule.transportPricing.transportPricingId;
    this.transportSchedule.originLocationId = this.transportSchedule.originName.locationId;
    this.transportSchedule.destinationLocationId = this.transportSchedule.destinationName.locationId;
    this.transportSchedule.vehicleId = this.transportSchedule.vehicle.vehicleId;

    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.PostOrCreateTransportSchedule(this.transportSchedule);
    actualResult.map((p: any) => {
      alert('TransportSchedule Added: ' + p.result);
      if (p.result) {

        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
  }
  public updateTransportSchedule() {
    this.transportSchedule.dateStartFromOrigin = jQuery('input#dateStartFromOrigin').val();
    this.transportSchedule.dateEndAtDestination = jQuery('input#dateEndAtDestination').val();
    this.transportSchedule.transportPricingId = this.transportSchedule.transportPricing.transportPricingId;
    this.transportSchedule.originLocationId = this.transportSchedule.originName.locationId;
    this.transportSchedule.destinationLocationId = this.transportSchedule.destinationName.locationId;
    this.transportSchedule.vehicleId = this.transportSchedule.vehicle.vehicleId;
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.UpdateTransportSchedule(this.transportSchedule);
    actualResult.map((p: any) => {
      alert('TransportSchedule Updated: ' + p.result);
      if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
  }
  public selectTransportSchedule(): void {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.GetTransportScheduleId(this.transportSchedule.transportScheduleId);
    actualResult.map((p: any) => {
      this.transportSchedule = p;
      this.transportSchedule.transportPricing = {};
      this.transportSchedule.originName = {};
      this.transportSchedule.destinationName = {};
      this.transportSchedule.vehicle = {};
      this.transportSchedule.transportPricing.transportPricingId = this.transportSchedule.transportPricingId
      this.transportSchedule.originName.locationId = this.transportSchedule.originLocationId;
      this.transportSchedule.destinationName.locationId = this.transportSchedule.destinationLocationId;
      this.transportSchedule.vehicle.vehicleId = this.transportSchedule.vehicleId;
    }).subscribe();
    jQuery('form#locationView').css('display', 'block').slideDown();
  }
  public deleteTransportSchedule() {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.DeleteTransportSchedule(this.transportSchedule);
    actualResult.map((p: any) => {
      alert('TransportSchedule deleted: ' + p.result);
      if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    jQuery('form#locationView').css('display', 'block').slideDown();
  }
  public ngOnInit(): void {

    this.transportSchedule = {
      transportScheduleId: 0,
      transportScheduleName: "",
      transportPricingId: 0,
      transportPricing: {
      },
      description: "",
      vehicleId: 0,
      vehicle: { vehicleId: 0 },
      originName: {},
      destinationName: {},
      dateStartFromOrigin: "",
      dateEndAtDestination: ""
    };
  }
  ngAfterContentInit(): void {

    const addschedObs: Observable<ITransportSchedule[]> = this.africanFarmerCommoditiesService.GetAllTransportSchedules();
    const addsObs: Observable<ITransportPricing[]> = this.africanFarmerCommoditiesService.GetAllTransportPricings();
    const locatObs: Observable<ILocation[]> = this.africanFarmerCommoditiesService.GetAllLocations();
    const vehsObs: Observable<IVehicle[]> = this.africanFarmerCommoditiesService.GetAllVehicles();

    let optionElem: HTMLOptionElement = document.createElement('option');
    optionElem.selected = true;
    optionElem.value = (0).toString();
    optionElem.text = "Select Transport Schedule";
    document.querySelector('select#tstransportScheduleId').append(optionElem);

    optionElem = document.createElement('option');
    optionElem.value = (0).toString();
    optionElem.text = "Select Transport Pricing";
    document.querySelector('select#tstransportPricingId').append(optionElem);

    optionElem = document.createElement('option');
    optionElem.value = (0).toString();
    optionElem.text = "Select Origin Loc.";
    document.querySelector('select#tsoriginId').append(optionElem);

    optionElem = document.createElement('option');
    optionElem.value = (0).toString();
    optionElem.text = "Select Destination Loc";
    document.querySelector('select#tsdestinationId').append(optionElem);


    optionElem = document.createElement('option');
    optionElem.value = (0).toString();
    optionElem.text = "Select Vehicle";
    document.querySelector('select#tsvehicleId').append(optionElem);


    addschedObs.map((cmds: ITransportSchedule[]) => {
      cmds.forEach((cmd: ITransportSchedule, index: number, cmds) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = cmd.transportScheduleId.toString();
        optionElem.text = cmd.transportScheduleName;
        document.querySelector('select#tstransportScheduleId').append(optionElem);
      });
    }).subscribe();
    addsObs.map((cmds: ITransportPricing[]) => {
      cmds.forEach((cmd: ITransportPricing, index: number, cmds) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = cmd.transportPricingId.toString();
        optionElem.text = cmd.transportPricingName;
        document.querySelector('select#tstransportPricingId').append(optionElem);
      });
    }).subscribe();

    locatObs.map((cmdCats: ILocation[]) => {
      cmdCats.forEach((comCat: ILocation, index: number, cmdCats) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = comCat.locationId.toString();
        optionElem.text = comCat.locationName;
        document.querySelector('select#tsoriginId').append(optionElem);
      });
    }).subscribe();

    locatObs.map((cmdCats: ILocation[]) => {
      cmdCats.forEach((comCat: ILocation, index: number, cmdCats) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = comCat.locationId.toString();
        optionElem.text = comCat.locationName;
        document.querySelector('select#tsdestinationId').append(optionElem);
      });
    }).subscribe();

    vehsObs.map((cmds: IVehicle[]) => {
      cmds.forEach((cmd: IVehicle, index: number, cmds) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = cmd.vehicleId.toString();
        optionElem.text = cmd.vehicleRegistration;
        document.querySelector('select#tsvehicleId').append(optionElem);
      });
    }).subscribe();

  }
  showIntermediateVehicleSchedules(): void {
    //Get schedules for vehicleId:
    let vshedsObs: Observable<IIntermediateSchedule[]> = this.africanFarmerCommoditiesService.GetIntermediateScheduleByTransportScheduleId(this.transportSchedule.transportScheduleId);

    vshedsObs.map((intSchs: IIntermediateSchedule[]) => {
      let vSheds: IIntermediateSchedule[] = intSchs;
      //Now Generate Table with vSheds Content.
      if (vSheds != null && vSheds.length > 0) {

        this.intemediateShedules = vSheds;
        let div: HTMLElement = document.querySelector("div#intermediate-transport-schedules");
        div.scrollIntoView();
      }
      else {
        this.intemediateShedules = [];
        alert('Vehicles not scheduled');
      }
    }).subscribe();
  }
addIntermediateVehicleSchedules(): void {
    //Add Intemediate Drops:
    this.router.navigateByUrl("/addintermediateschedule")
  }
  ngAfterViewInit() {

  } ngAfterViewChecked() {
    let curthis = this;

    this.setTo = setTimeout(this.runAutoCompleteOnSelects, 1000, curthis);

  }
  runAutoCompleteOnSelects(curthis: any) {
    let hasFoundSelectsOnPage = false;

    if (!curthis.hasPopulatedPage) {

      let selects = jQuery('div#client-wrapper-trnsshed select');

      if (selects && selects.length > 0) {
        hasFoundSelectsOnPage = true;
      }

      if (hasFoundSelectsOnPage) {

        jQuery(selects.each((ind, elem) => {
          jQuery(elem).parent('ul').css('background', 'white');
          jQuery(elem).parent('ul').css('z-index', '100');
          let id = 'autoComplete' + jQuery(elem).attr('id');
          jQuery(elem).parent('div').prepend("<input type='text' placeholder='Search dropdown' id=" + `${id}` + " /><br/>");

        }));
        hasFoundSelectsOnPage = false;

      }
      //Check For Dom Change and Add auto complete to select elements
      debugger;
      jQuery('select').each((ind, sel) => {
        let options = jQuery(sel).children('option');

        let vals = [];
        jQuery(options).each((id, el) => {
          let optionText = jQuery(el).html();
          vals.push(optionText);
        });
        //options is source of auto complete:
        let jQueryinpId = jQuery('input#autoComplete' + jQuery(sel).attr('id'));
        jQueryinpId.autocomplete({ source: vals });
        jQuery(document).on('click', '.ui-menu .ui-menu-item-wrapper', function (event) {
          jQuery('select#' + jQuery(sel).attr('id')).find("option").filter(function () {
            return jQuery(event.target).text() == jQuery(this).html();
          }).attr("selected", true);
        });
      });

      curthis.hasPopulatedPage = true;
      clearTimeout(curthis.setTo);
    }
  }
}
