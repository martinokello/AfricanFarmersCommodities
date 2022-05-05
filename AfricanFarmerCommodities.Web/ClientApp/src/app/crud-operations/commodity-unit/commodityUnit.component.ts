import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter, AfterContentInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ICommodityCategory, AfricanFarmerCommoditiesService, ICommodityUnit } from '../../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
import * as $ from 'jquery';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';

@Component({
    selector: 'commodity-unit',
    templateUrl: './commodityUnit.component.html',
  styleUrls: ['./commodityUnit.component.css'],
    providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class CommodityUnitComponent implements OnInit, AfterContentInit {
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
    }
  public commodityUnit: ICommodityUnit | any;

  public addCommodityUnit(): void {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.PostOrCreateCommodityUnit(this.commodityUnit);
    actualResult.map((p: any) => {
          alert('CommodityUnit Added: ' + p.result);
      if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
        }).subscribe();
        $('form#locationView').css('display', 'block').slideDown();
    }
  public updateCommodityUnit() {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.UpdateCommodityUnit(this.commodityUnit);
    actualResult.map((p: any) => {;
          alert('CommodityCategory Updated: ' + p.result);
      if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
        }).subscribe();
        $('form#locationView').css('display', 'block').slideDown();
  }
  public selectCommodityUnit(): void {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.GetCommodityUnitById(this.commodityUnit.commodityUnitId);
    actualResult.map((p: any) => {
      this.commodityUnit = p;
        }).subscribe();
        $('form#locationView').css('display', 'block').slideDown();
    }
  public deleteCommodityUnit() {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.DeleteCommodityUnit(this.commodityUnit);
    actualResult.map((p: any) => {
          alert('CommodityCategory Deleted: ' + p.result);
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
      this.commodityUnit = {}
  }
  ngAfterContentInit(): void {
    const comCatObs: Observable<ICommodityUnit[]> = this.africanFarmerCommoditiesService.GetAllCommodityUnits();
    let optionElem = document.createElement('option');
    optionElem.selected = true;
    optionElem.value = (0).toString();
    optionElem.text = "Select Commodity Unit";
    document.querySelector('select#commodityUnitId').append(optionElem);

    comCatObs.map((cmdCats: ICommodityUnit[]) => {
      cmdCats.forEach((comCat: ICommodityUnit, index: number, cmdCats) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = comCat.commodityUnitId.toString();
        optionElem.text = comCat.commodityUnitName;
        document.querySelector('select#commodityUnitId').append(optionElem);
      });
    }).subscribe();

  }
}
