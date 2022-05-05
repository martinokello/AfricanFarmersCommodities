import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter, AfterContentInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IVehicleCategory, IAddress, ILocation, AfricanFarmerCommoditiesService, IVehicleCapacity } from '../../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
import * as $ from 'jquery';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';

@Component({
  selector: 'vehicle-category',
  templateUrl: './vehicleCategory.component.html',
  styleUrls: ['./vehicleCategory.component.css'],
    providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class vehicleCategoryComponent implements OnInit, AfterContentInit {
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
  }

  public vehicleCategory: IVehicleCategory | any;

  public addVehicleCategory(): void {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.PostOrCreateVehicleCategory(this.vehicleCategory);
    actualResult.map((p: any) => {
      alert('VehicleCategory Added: ' + p.result);
      if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public updateVehicleCategory() {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.UpdateVehicleCategory(this.vehicleCategory);
    actualResult.map((p: any) => {
      alert('VehicleCategory Updated: ' + p.result);
      if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public selectVehicleCategory(): void {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.GetVehicleCategoryById(this.vehicleCategory.vehicleCategoryId);
    actualResult.map((p: any) => {
      this.vehicleCategory = p;
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public deleteVehicleCategory() {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.DeleteVehicleCategory(this.vehicleCategory);
    actualResult.map((p: any) => {
      alert('VehicleCategory Deleted: ' + p.result);
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

    this.vehicleCategory = {
      vehicleCategoryId: 0,
      vehicleCategoryName: "",
      description:""
    };
  }
  ngAfterContentInit(): void {
    //physically populate categoryName:
    const vehCatObs: Observable<IVehicleCategory[]> = this.africanFarmerCommoditiesService.GetAllVehicleCategories();

    let optionElemCat: HTMLOptionElement = document.createElement('option');
    optionElemCat.selected = true;
    optionElemCat.value = (0).toString();
    optionElemCat.text = "Select Vehicle Category";
    document.querySelector('select#vecVehicleCategoryId').append(optionElemCat);

    vehCatObs.map((cmdCats: IVehicleCategory[]) => {
      cmdCats.forEach((comCat: IVehicleCategory, index: number, cmdCats) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = comCat.vehicleCategoryId.toString();
        optionElem.text = comCat.vehicleCategoryName;
        document.querySelector('select#vecVehicleCategoryId').append(optionElem);
      });
    }).subscribe();


    }
}
