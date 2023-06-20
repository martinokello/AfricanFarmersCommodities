import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter, AfterContentInit, AfterViewChecked } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IDriver, IAddress, ILocation, AfricanFarmerCommoditiesService, IVehicle, ITransportSchedule } from '../../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
declare var jQuery: any;
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';

@Component({
  selector: 'driver',
  templateUrl: './driver.component.html',
  styleUrls: ['./driver.component.css'],
    providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class DriverComponent implements OnInit, AfterContentInit, AfterViewChecked {
  hasPopulatedPage: boolean = false;
  setTo: NodeJS.Timeout;
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
    }
  public driver: IDriver | any;

  public addDriver(): void {

    this.driver.driverId = 0;
    this.driver.transportScheduleId = this.driver.transportSchedule.transportScheduleId;
    this.driver.transportSchedule = null;
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.PostOrCreateDriver(this.driver);
    actualResult.map((p: any) => {
      alert('Driver Added: ' + p.result); if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    jQuery('form#locationView').css('display', 'block').slideDown();
  }
  public updateDriver() {
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
    jQuery('form#locationView').css('display', 'block').slideDown();
  }
  public selectDriver(): void {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.GetDriverById(this.driver.driverId);
    actualResult.map((p: any) => {
      this.driver.firstName = p.firstName;
      this.driver.lastName = p.lastName;
      this.driver.transportSchedule.transportScheduleId = p.transportScheduleId;
    }).subscribe();
    jQuery('form#locationView').css('display', 'block').slideDown();
  }
  public deleteDriver() {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.DeleteDriver(this.driver);
    actualResult.map((p: any) => {
      alert('Driver Deleted: ' + p.result);
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
    this.driver = 
    {
      driverId : 0,
      firstName:"",
      lastName:"",
      transportScheduleId: 0,
      transportSchedule: {},
      dateCreated:"",
      dateUpdated: ""
    };
  }
  ngAfterContentInit(): void {
    const driversObs: Observable<IDriver[]> = this.africanFarmerCommoditiesService.GetAllDrivers();
    //const vehObs: Observable<IVehicle[]> = this.africanFarmerCommoditiesService.GetAllVehicles();
    const schedsObs: Observable<ITransportSchedule[]> = this.africanFarmerCommoditiesService.GetAllTransportSchedules();

    let optionElem: HTMLOptionElement = document.createElement('option');
    optionElem.selected = true;
    optionElem.value = (0).toString();
    optionElem.text = "Select Driver";
    document.querySelector('select#driverId').append(optionElem);


   /* optionElem = document.createElement('option');
    optionElem.value = (0).toString();
    optionElem.text = "Select Vehicle";
    document.querySelector('select#drivehicleId').append(optionElem);*/

    optionElem = document.createElement('option');
    optionElem.value = (0).toString();
    optionElem.text = "Select Schedule";
    document.querySelector('select#dritransportScheduleId').append(optionElem);


    driversObs.map((cmds: IDriver[]) => {
      cmds.forEach((cmd: IDriver, index: number, cmds) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = cmd.driverId.toString();
        optionElem.text = cmd.firstName + " " + cmd.lastName;
        document.querySelector('select#driverId').append(optionElem);
      });
    }).subscribe();

    /*vehObs.map((cmdCats: IVehicle[]) => {
      cmdCats.forEach((comCat: IVehicle, index: number, cmdCats) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = comCat.vehicleId.toString();
        optionElem.text = comCat.vehicleRegistration;
        document.querySelector('select#drivehicleId').append(optionElem);
      });
    }).subscribe();*/

    schedsObs.map((cmdUnits: ITransportSchedule[]) => {
      cmdUnits.forEach((cmdUnit: ITransportSchedule, index: number, cmdUnits) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = cmdUnit.transportScheduleId.toString();
        optionElem.text = cmdUnit.transportScheduleName;
        document.querySelector('select#dritransportScheduleId').append(optionElem);
      });
    }).subscribe();
  }

  ngAfterViewChecked() {
    let curthis = this;

    this.setTo = setTimeout(this.runAutoCompleteOnSelects, 1000, curthis);

  }
  runAutoCompleteOnSelects(curthis: any) {
    let hasFoundSelectsOnPage = false;

    if (!curthis.hasPopulatedPage) {

      let selects = jQuery('div#client-wrapper-driver select');

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
