import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter, AfterContentInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IVehicle,IAddress, ILocation, AfricanFarmerCommoditiesService, IVehicleCategory, ICompany, IVehicleCapacity } from '../../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
import * as $ from 'jquery';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';

@Component({
    selector: 'vehicle',
  templateUrl: './vehicle.component.html',
  styleUrls: ['./vehicle.component.css'],
    providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class VehicleComponent implements OnInit, AfterContentInit {
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
    }
  public vehicle: IVehicle | any;

  public addVehicle(): void {
    this.vehicle.vehicleId = 0;
    this.vehicle.vehicleCategoryId = this.vehicle.vehicleCategory.vehicleCategoryId;
    this.vehicle.vehicleCapacityId = this.vehicle.vehicleCapacity.vehicleCapacityId;
    this.vehicle.companyId = this.vehicle.company.companyId;
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.PostOrCreateVehicle(this.vehicle);
    actualResult.map((p: any) => {
      alert('Vehicle Added: ' + p.result);
      if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public updateVehicle() {
    this.vehicle.vehicleCategoryId = this.vehicle.vehicleCategory.vehicleCategoryId;
    this.vehicle.companyId = this.vehicle.company.companyId;
    this.vehicle.vehicleCapacityId = this.vehicle.vehicleCapacity.vehicleCapacityId;
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.UpdateVehicle(this.vehicle);
    actualResult.map((p: any) => {
      alert('Vehicle Updated: ' + p.result);
      if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public selectVehicle(): void {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.GetVehiclById(this.vehicle.vehicleId);
    actualResult.map((p: any) => {
      this.vehicle = p;
      this.vehicle.vehicleCategory = { vehicleCategoryId: this.vehicle.vehicleCategoryId };
      this.vehicle.vehicleCapacity = { vehicleCapacityId: this.vehicle.vehicleCapacityId };
      this.vehicle.company = { companyId: this.vehicle.companyId };
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public deleteVehicle() {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.DeleteVehicle(this.vehicle);
    actualResult.map((p: any) => {
      alert('Vehicle Deleted: ' + p.result);
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
    this.vehicle = {
      vehicleId: 0,
      vehicleRegistration:"",
      vehicleCategory: {},
      vehicleCapacity: {},
      company: {},
      vehicleCategoryId: 0,
      vehicleCapacityId:0,
      maxNumberOfPassengers: 0,
      actualNumberOfPassengersAllocated: 0};
  }
  ngAfterContentInit(): void {
    const vehsObs: Observable<IVehicle[]> = this.africanFarmerCommoditiesService.GetAllVehicles();
    const vehCatObs: Observable<IVehicleCategory[]> = this.africanFarmerCommoditiesService.GetAllVehicleCategories();
    const vehCompObs: Observable<ICompany[]> = this.africanFarmerCommoditiesService.GetAllCompanies();
    const vehcaps: Observable<IVehicleCapacity[]> = this.africanFarmerCommoditiesService.GetAllVehicleCapacities();

    let optionElem: HTMLOptionElement = document.createElement('option');
    optionElem.selected = true;
    optionElem.value = (0).toString();
    optionElem.text = "Select Vehicle";
    document.querySelector('select#vehVehicleId').append(optionElem);

    let optionElem2: HTMLOptionElement = document.createElement('option');
    optionElem2.selected = true;
    optionElem2.value = (0).toString();
    optionElem2.text = "Select Vehicle Category.";
    document.querySelector('select#vehVehicleCategoryId').append(optionElem2);

    let optionElem3: HTMLOptionElement = document.createElement('option');
    optionElem3.selected = true;
    optionElem3.value = (0).toString();
    optionElem3.text = "Select Vehicle Company.";
    document.querySelector('select#vehVehicleCompanyId').append(optionElem3);

    let optionElem1: HTMLOptionElement = document.createElement('option');
    optionElem1.value = (0).toString();
    optionElem1.text = "Select Vehicle Capacity";
    document.querySelector('select#vcatvehicleCapacityId').append(optionElem1);

    vehsObs.map((cmds: IVehicle[]) => {
      cmds.forEach((cmd: IVehicle, index: number, cmds) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = cmd.vehicleId.toString();
        optionElem.text = cmd.vehicleRegistration;
        document.querySelector('select#vehVehicleId').append(optionElem);
      });
    }).subscribe();

    vehCatObs.map((cmdCats: IVehicleCategory[]) => {
      cmdCats.forEach((comCat: IVehicleCategory, index: number, cmdCats) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = comCat.vehicleCategoryId.toString();
        optionElem.text = comCat.vehicleCategoryName;
        document.querySelector('select#vehVehicleCategoryId').append(optionElem);
      });
    }).subscribe();

    vehCompObs.map((cmdComps: ICompany[]) => {
      cmdComps.forEach((comComp: ICompany, index: number, cmdComps) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = comComp.companyId.toString();
        optionElem.text = comComp.companyName;
        document.querySelector('select#vehVehicleCompanyId').append(optionElem);
      });
    }).subscribe();


    vehcaps.map((cmds: IVehicleCapacity[]) => {
      cmds.forEach((cmd: IVehicleCapacity, index: number, cmds) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = cmd.vehicleCapacityId.toString();
        optionElem.text = cmd.vechicleCapacityUnitsName;
        document.querySelector('select#vcatvehicleCapacityId').append(optionElem);
      });
    }).subscribe();
  }
}
