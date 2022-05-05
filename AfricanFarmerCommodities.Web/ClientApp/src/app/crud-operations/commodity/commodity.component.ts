import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter, AfterContentInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ICommodity, IAddress, ILocation, AfricanFarmerCommoditiesService, ICommodityCategory, ICommodityUnit, ICompany, IVehicle, IUserDetail, IFarmer } from '../../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
import * as $ from 'jquery';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';

@Component({
  selector: 'commodity',
  templateUrl: './commodity.component.html',
  styleUrls: ['./commodity.component.css'],
  providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class CommodityComponent implements OnInit, AfterContentInit {
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
  }
  public commodity: ICommodity | any;

  ngAfterContentInit(): void {
    const commoditiessObs: Observable<ICommodity[]> = this.africanFarmerCommoditiesService.GetAllCommodities();
    const comCatObs: Observable<ICommodityCategory[]> = this.africanFarmerCommoditiesService.GetAllCommodityCategories();
    const comUnitsObs: Observable<ICommodityUnit[]> = this.africanFarmerCommoditiesService.GetAllCommodityUnits();
    const comsObs: Observable<ICompany[]> = this.africanFarmerCommoditiesService.GetAllCompanies();
    const comsVhe: Observable<IVehicle[]> = this.africanFarmerCommoditiesService.GetAllVehicles();
    const farmersObs: Observable<IFarmer[]> = this.africanFarmerCommoditiesService.GetAllFamers();

    let optionElem: HTMLOptionElement = document.createElement('option');
    optionElem.selected = true;
    optionElem.value = (0).toString();
    optionElem.text = "Select Commodity";
    document.querySelector('select#commodityId').append(optionElem);


    optionElem = document.createElement('option');
    optionElem.selected = true;
    optionElem.value = (0).toString();
    optionElem.text = "Select Farmer";
    document.querySelector('select#comfarmerId').append(optionElem);

    optionElem = document.createElement('option');
    optionElem.value = (0).toString();
    optionElem.text = "Select Company";
    document.querySelector('select#comcompanyId').append(optionElem);

    optionElem = document.createElement('option');
    optionElem.value = (0).toString();
    optionElem.text = "Select Commodity Category";
    document.querySelector('select#comcommodityCategoryId').append(optionElem);

    optionElem = document.createElement('option');
    optionElem.value = (0).toString();
    optionElem.text = "Select Commodity Units";
    document.querySelector('select#comcommodityUnitId').append(optionElem);

    this.commodity.username= AfricanFarmerCommoditiesService.userDetails.emailAddress;

    commoditiessObs.map((cmds: ICommodity[]) => {
      cmds.forEach((cmd: ICommodity, index: number, cmds) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = cmd.commodityId.toString();
        optionElem.text = cmd.commodityName;
        document.querySelector('select#commodityId').append(optionElem);
      });
    }).subscribe();

    farmersObs.map((cmds: IFarmer[]) => {
      cmds.forEach((cmd: IFarmer, index: number, cmds) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = cmd.farmerId.toString();
        optionElem.text = cmd.farmerName;
        document.querySelector('select#comfarmerId').append(optionElem);
      });
    }).subscribe();

    comsObs.map((cmdUnits: ICompany[]) => {
      cmdUnits.forEach((cmdUnit: ICompany, index: number, cmdUnits) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = cmdUnit.companyId.toString();
        optionElem.text = cmdUnit.companyName;
        document.querySelector('select#comcompanyId').append(optionElem);
      });
    }).subscribe();
    comCatObs.map((cmdCats: ICommodityCategory[]) => {
      cmdCats.forEach((comCat: ICommodityCategory, index: number, cmdCats) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = comCat.commodityCategoryId.toString();
        optionElem.text = comCat.commodityCategoryName;
        document.querySelector('select#comcommodityCategoryId').append(optionElem);
      });
    }).subscribe();

    comUnitsObs.map((cmdUnits: ICommodityUnit[]) => {
      cmdUnits.forEach((cmdUnit: ICommodityUnit, index: number, cmdUnits) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = cmdUnit.commodityUnitId.toString();
        optionElem.text = cmdUnit.commodityUnitName;
        document.querySelector('select#comcommodityUnitId').append(optionElem);
      });
    }).subscribe();
  }
  public addCommodity(): void {
    this.commodity.commodityUnit = null;
    this.commodity.commodityCategory = null;

    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.PostOrCreateCommodity(this.commodity);
    actualResult.map((p: any) => {
      alert('ICommodity Added: ' + p.result);
      if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public updateCommodity() {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.UpdateCommodity(this.commodity);
    actualResult.map((p: any) => {
      alert('ICommodity Updated: ' + p.result);
      if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public selectCommodity(): void {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.GetCommodityById(this.commodity.commodityId);
    actualResult.map((p: ICommodity) => {
      p.unitsAvailable = parseFloat(p.numberOfUnits);
      this.commodity = p;
      alert("Succesfully Selected");
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public deleteCommodity() {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.DeleteCommodity(this.commodity);
    actualResult.map((p: any) => {
      alert('ICommodity Deleted: ' + p.result);
      if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }

  public OrderCommodity(): void {
    let orders: ICommodity[] = JSON.parse(sessionStorage.getItem("Orders"));

    if (orders == null) {
      orders = [];
      sessionStorage.setItem("runningTotalPrice", "0");
    }

    this.commodity.unitsAvailable = this.commodity.numberOfUnits;
    orders.push(this.commodity);
    sessionStorage.setItem("Orders", JSON.stringify(orders));

    this.router.navigateByUrl("/basket");
  }
  public ngOnInit(): void {
    this.commodity = {}
  }
}
