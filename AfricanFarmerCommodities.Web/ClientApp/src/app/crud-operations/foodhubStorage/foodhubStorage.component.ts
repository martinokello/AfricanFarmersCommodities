import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter, AfterContentInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IFoodHubStorage, IAddress, ILocation, AfricanFarmerCommoditiesService, IFoodHub, ICommodityUnit } from '../../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
import * as $ from 'jquery';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';

@Component({
  selector: 'foodhub-storage',
  templateUrl: './foodhubStorage.component.html',
  styleUrls: ['./foodhubStorage.component.css'],
    providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class FoodHubStorageComponent implements OnInit, AfterContentInit {
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
    }
  public foodHubStorage: IFoodHubStorage | any;

  public addFoodHubStorage(): void {
    this.foodHubStorage.foodHubStorageId = 0;
    this.foodHubStorage.foodHubId = this.foodHubStorage.foodHub.foodHubId;
    this.foodHubStorage.commodityUnitId = this.foodHubStorage.commodityUnit.commodityUnitId;

    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.PostOrCreateFoodHubStorage(this.foodHubStorage);
    actualResult.map((p: any) => {
      alert('FoodHub Storgae Added: ' + p.result); if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public updateFoodHubStorage() {
    this.foodHubStorage.foodHubId = this.foodHubStorage.foodHub.foodHubId;
    this.foodHubStorage.commodityUnitId = this.foodHubStorage.commodityUnit.commodityUnitId;

    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.UpdateFoodHubStorage(this.foodHubStorage);
    actualResult.map((p: any) => {
      alert('FoodHub Updated: ' + p.result); if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public selectFoodHubStorage(): void {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.GetFoodHubStorageById(this.foodHubStorage.foodHubStorageId);
    actualResult.map((p: any) => {
      this.foodHubStorage = p;
      this.foodHubStorage.foodHub.foodHubId = this.foodHubStorage.foodHubId;
      this.foodHubStorage.commodityUnit.commodityUnitId = this.foodHubStorage.commodityId ;
      this.foodHubStorage.foodHub = { foodHubId: this.foodHubStorage.foodHub.foodHubId };
      this.foodHubStorage.commodityUnit.commodityUnitId = this.foodHubStorage.commodityUnitId;
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public deleteFoodHubStorage() {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.DeleteFoodHubStorage(this.foodHubStorage);
    actualResult.map((p: any) => {
      alert('FoodHub Deleted: ' + p.result); if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public ngOnInit(): void {
    this.foodHubStorage = {};
    this.foodHubStorage.foodHub = {};
    this.foodHubStorage.commodityUnit = {};
  }
  ngAfterContentInit(): void {
    const foodHubStorsObs: Observable<IFoodHubStorage[]> = this.africanFarmerCommoditiesService.GetAllFoodHubStorages();
    const foodHubsObs: Observable<IFoodHub[]> = this.africanFarmerCommoditiesService.GetAllFoodHubs();
    const locatObs: Observable<ICommodityUnit[]> = this.africanFarmerCommoditiesService.GetAllCommodityUnits();

    let optionElem1: HTMLOptionElement = document.createElement('option');
    optionElem1.selected = true;
    optionElem1.value = (0).toString();
    optionElem1.text = "Select Food Hub Storage";
    document.querySelector('select#foodHubStorageId').append(optionElem1);

    let optionElem2: HTMLOptionElement = document.createElement('option');
    optionElem2.value = (0).toString();
    optionElem2.text = "Select Food Hub";
    document.querySelector('select#fhsfoodHubId').append(optionElem2);

    let optionElem3: HTMLOptionElement = document.createElement('option');
    optionElem3.value = (0).toString();
    optionElem3.text = "Select Commodity Unit";
    document.querySelector('select#fhscommodityUnitId').append(optionElem3);


    foodHubStorsObs.map((cmds: IFoodHubStorage[]) => {
      cmds.forEach((cmd: IFoodHubStorage, index: number, cmds) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = cmd.foodHubStorageId.toString();
        optionElem.text = cmd.foodHubStorageName;
        document.querySelector('select#foodHubStorageId').append(optionElem);
      });
    }).subscribe();

    foodHubsObs.map((cmds: IFoodHub[]) => {
      cmds.forEach((cmd: IFoodHub, index: number, cmds) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = cmd.foodHubId.toString();
        optionElem.text = cmd.foodHubName;
        document.querySelector('select#fhsfoodHubId').append(optionElem);
      });
    }).subscribe();

    locatObs.map((cmdCats: ICommodityUnit[]) => {
      cmdCats.forEach((comCat: ICommodityUnit, index: number, cmdCats) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = comCat.commodityUnitId.toString();
        optionElem.text = comCat.commodityUnitName;
        document.querySelector('select#fhscommodityUnitId').append(optionElem);
      });
    }).subscribe();
  }
}
