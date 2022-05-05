import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter, AfterContentInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ITransportSchedule,IAddress, ILocation, AfricanFarmerCommoditiesService, ITransportPricing, IVehicle, IIntermediateSchedule } from '../../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
import * as $ from 'jquery';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';

@Component({
  selector: 'intermediate-schedules',
  templateUrl: './intermediateschedules.component.html',
  styleUrls: ['./intermediateschedules.component.css'],
    providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class IntermediateScheduleComponent implements OnInit, AfterContentInit {
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router){
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
  }
  public intermediateSchedule: IIntermediateSchedule | any;

  public addIntermediateSchedule(): void {
    this.intermediateSchedule.dateStartFromOrigin = $('input#intdateStartFromOrigin').val();
    this.intermediateSchedule.dateEndAtDestination = $('input#intdateEndAtDestination').val();
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.PostOrCreateIntermediateSchedule(this.intermediateSchedule);
    actualResult.map((p: any) => {
      alert('IntermediateSchedule Added: ' + p.result);
      if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public updateIntermediateSchedule() {
    this.intermediateSchedule.dateStartFromOrigin = $('input#intdateStartFromOrigin').val();
    this.intermediateSchedule.dateEndAtDestination = $('input#intdateEndAtDestination').val();
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.UpdateIntermediateSchedule(this.intermediateSchedule);
    actualResult.map((p: any) => {
      alert('TransportSchedule Updated: ' + p.result);
      if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public selectIntermediateSchedule(): void {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.GetIntermediateScheduleById(this.intermediateSchedule.intermediateScheduleId);
    actualResult.map((p: any) => {
      this.intermediateSchedule = p;
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public deleteIntermediateSchedule() {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.DeleteIntermediateSchedule(this.intermediateSchedule);
    actualResult.map((p: any) => {
      alert('IntermediateSchedule deleted: ' + p.result);
      if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public ngOnInit(): void {
    this.intermediateSchedule = {
      intermediateScheduleId: 0,
      transportScheduleId: 0,
      transportScheduleName: "",
      vehicleId: 0,
      vehicle: {},
      originName: {},
      destinationName: {},
      dateStartFromOrigin: "",
      dateEndAtDestination: ""
    };
  }
  ngAfterContentInit(): void {
    let masterPickedTransportId: number = parseInt(sessionStorage.getItem("masterPickedTransportId"));
    if (masterPickedTransportId > 0) {
      this.intermediateSchedule.transportScheduleId = masterPickedTransportId;
      sessionStorage.removeItem("masterPickedTransportId")
    }
    const addschedObs: Observable<IIntermediateSchedule[]> = this.africanFarmerCommoditiesService.GetAllIntermediateSchedules();
    const addsObs: Observable<ITransportPricing[]> = this.africanFarmerCommoditiesService.GetAllTransportPricings();
    const locatObs: Observable<ILocation[]> = this.africanFarmerCommoditiesService.GetAllLocations();
    const vehsObs: Observable<IVehicle[]> = this.africanFarmerCommoditiesService.GetAllVehicles();

    let optionElem: HTMLOptionElement = document.createElement('option');
    optionElem.selected = true;
    optionElem.value = (0).toString();
    optionElem.text = "Select Intermediate Schedule";
    document.querySelector('select#intermediateScheduleId').append(optionElem);

    optionElem = document.createElement('option');
    optionElem.value = (0).toString();
    optionElem.text = "Select Origin Loc.";
    document.querySelector('select#intoriginId').append(optionElem);

    optionElem = document.createElement('option');
    optionElem.value = (0).toString();
    optionElem.text = "Select Destination Loc";
    document.querySelector('select#intdestinationId').append(optionElem);


    optionElem = document.createElement('option');
    optionElem.value = (0).toString();
    optionElem.text = "Select Vehicle";
    document.querySelector('select#intvehicleId').append(optionElem);

    addschedObs.map((cmds: IIntermediateSchedule[]) => {
      cmds.forEach((cmd: IIntermediateSchedule, index: number, cmds) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = cmd.intermediateScheduleId.toString();
        optionElem.text = cmd.intermediateTransportScheduleName;
        document.querySelector('select#intermediateScheduleId').append(optionElem);
      });
    }).subscribe();

    locatObs.map((cmdCats: ILocation[]) => {
      cmdCats.forEach((comCat: ILocation, index: number, cmdCats) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = comCat.locationId.toString();
        optionElem.text = comCat.locationName;
        document.querySelector('select#intoriginId').append(optionElem);
      });
    }).subscribe();

    locatObs.map((cmdCats: ILocation[]) => {
      cmdCats.forEach((comCat: ILocation, index: number, cmdCats) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = comCat.locationId.toString();
        optionElem.text = comCat.locationName;
        document.querySelector('select#intdestinationId').append(optionElem);
      });
    }).subscribe();

    vehsObs.map((cmds: IVehicle[]) => {
      cmds.forEach((cmd: IVehicle, index: number, cmds) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = cmd.vehicleId.toString();
        optionElem.text = cmd.vehicleRegistration;
        document.querySelector('select#intvehicleId').append(optionElem);
      });
    }).subscribe();
  }
}
