import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter, AfterContentInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ICommodityCategory, AfricanFarmerCommoditiesService } from '../../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
import * as $ from 'jquery';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';

@Component({
    selector: 'commodity-category',
    templateUrl: './commodityCategory.component.html',
  styleUrls: ['./commodityCategory.component.css'],
    providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class CommodityCategoryComponent implements OnInit, AfterContentInit {
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
    }
  public commodityCategory: ICommodityCategory | any;

  public addCommodityCategory(): void {

    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.PostOrCreateCommodityCategory(this.commodityCategory);
    actualResult.map((p: any) => {
      alert('CommodityCategory Added: ' + p.result); if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
        }).subscribe();
        $('form#locationView').css('display', 'block').slideDown();
    }
  public updateCommodityCategory() {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.UpdateCommodityCategory(this.commodityCategory);
    actualResult.map((p: any) => {
      alert('CommodityCategory Updated: ' + p.result); if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
        }).subscribe();
        $('form#locationView').css('display', 'block').slideDown();
  }
  public selectCommodityCategory(): void {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.GetCommodityCategoryById(this.commodityCategory.commodityCategoryId);
    actualResult.map((p: any) => {
      this.commodityCategory = p; 
        }).subscribe();
        $('form#locationView').css('display', 'block').slideDown();
    }
  public deleteCommodityCategory() {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.DeleteCommodityCategory(this.commodityCategory);
    actualResult.map((p: any) => {
      alert('CommodityCategory Deleted: ' + p.result); if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
        }).subscribe();
        $('form#locationView').css('display', 'block').slideDown();
    }
    public ngOnInit(): void {
      this.commodityCategory = {}
  }
  ngAfterContentInit(): void {
    const comCatObs: Observable<ICommodityCategory[]> = this.africanFarmerCommoditiesService.GetAllCommodityCategories();
    let optionElem = document.createElement('option');
    optionElem.selected = true;
    optionElem.value = (0).toString();
    optionElem.text = "Select Commodity Category";
    document.querySelector('select#commodityCategoryId').append(optionElem);

    comCatObs.map((cmdCats: ICommodityCategory[]) => {
      cmdCats.forEach((comCat: ICommodityCategory, index: number, cmdCats) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = comCat.commodityCategoryId.toString();
        optionElem.text = comCat.commodityCategoryName;
        document.querySelector('select#commodityCategoryId').append(optionElem);
      });
    }).subscribe();

  }
}
