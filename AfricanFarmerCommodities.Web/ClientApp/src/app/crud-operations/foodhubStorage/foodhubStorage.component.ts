import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter, AfterContentInit, AfterViewChecked } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IFoodHubStorage, IAddress, ILocation, AfricanFarmerCommoditiesService, IFoodHub, ICommodityUnit } from '../../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
declare var jQuery: any;
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
export class FoodHubStorageComponent implements OnInit, AfterContentInit, AfterViewChecked {
  hasPopulatedPage: boolean = false;
  setTo: NodeJS.Timeout;
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
    }
  public foodHubStorage: IFoodHubStorage | any;

  public addFoodHubStorage(): void {
    let fhId: HTMLSelectElement = document.querySelector('select#fhsfoodHubId');//jQuery('select[name="foodHubId"]').val();
    let cuId: HTMLSelectElement = document.querySelector('select#fhscommodityUnitId'); //jQuery('select[name="commodityUnitId"]').val();

    let foodHubId: number = parseInt(fhId.value);
    let commodityUnitId: number = parseInt(cuId.value);

    let foodHubStorageToAdd: IFoodHubStorage = {
      foodHubStorageId: this.foodHubStorage.foodHubStorageId,
      foodHubId: foodHubId,
      commodityUnitId: commodityUnitId,
      foodHubStorageName: this.foodHubStorage.foodHubStorageName,
      dryStorageCapacity: this.foodHubStorage.dryStorageCapacity,
      usedDryStorageCapacity: this.foodHubStorage.usedDryStorageCapacity,
      refreigeratedStorageCapacity: this.foodHubStorage.refreigeratedStorageCapacity,
      usedRefreigeratedStorageCapacity: this.foodHubStorage.usedRefreigeratedStorageCapacity
    };

    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.PostOrCreateFoodHubStorage(foodHubStorageToAdd);
    actualResult.map((p: any) => {
      alert('FoodHub Storgae Added: ' + p.result); if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
  }
  public updateFoodHubStorage() {

    let fhId: HTMLSelectElement = document.querySelector('select#fhsfoodHubId');//jQuery('select[name="foodHubId"]').val();
    let cuId: HTMLSelectElement = document.querySelector('select#fhscommodityUnitId'); //jQuery('select[name="commodityUnitId"]').val();

    let foodHubId: number = parseInt(fhId.value);
    let commodityUnitId: number = parseInt(cuId.value);

    let foodHubStorageToUpdate: IFoodHubStorage = {
      foodHubStorageId: this.foodHubStorage.foodHubStorageId,
      foodHubId: foodHubId,
      commodityUnitId: commodityUnitId,
      foodHubStorageName: this.foodHubStorage.foodHubStorageName,
      dryStorageCapacity: this.foodHubStorage.dryStorageCapacity,
      usedDryStorageCapacity: this.foodHubStorage.usedDryStorageCapacity,
      refreigeratedStorageCapacity: this.foodHubStorage.refreigeratedStorageCapacity,
      usedRefreigeratedStorageCapacity: this.foodHubStorage.usedRefreigeratedStorageCapacity
    };

    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.UpdateFoodHubStorage(foodHubStorageToUpdate);
    actualResult.map((p: any) => {
      alert('FoodHub Updated: ' + p.result); if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
  }
  public selectFoodHubStorage(): void {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.GetFoodHubStorageById(this.foodHubStorage.foodHubStorageId);
    actualResult.map((p: any) => {
      this.foodHubStorage = p;
    }).subscribe();
  }
  public deleteFoodHubStorage() {

    let fhId: HTMLSelectElement = document.querySelector('select#fhsfoodHubId');//jQuery('select[name="foodHubId"]').val();
    let cuId: HTMLSelectElement = document.querySelector('select#fhscommodityUnitId'); //jQuery('select[name="commodityUnitId"]').val();

    let foodHubId: number = parseInt(fhId.value);
    let commodityUnitId: number = parseInt(cuId.value);

    let foodHubStorageToDelete: IFoodHubStorage = {
      foodHubStorageId: this.foodHubStorage.foodHubStorageId,
      foodHubId: foodHubId,
      commodityUnitId: commodityUnitId,
      foodHubStorageName: this.foodHubStorage.foodHubStorageName,
      dryStorageCapacity: this.foodHubStorage.dryStorageCapacity,
      usedDryStorageCapacity: this.foodHubStorage.usedDryStorageCapacity,
      refreigeratedStorageCapacity: this.foodHubStorage.refreigeratedStorageCapacity,
      usedRefreigeratedStorageCapacity: this.foodHubStorage.usedRefreigeratedStorageCapacity
    };
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.DeleteFoodHubStorage(foodHubStorageToDelete);
    actualResult.map((p: any) => {
      alert('FoodHub Deleted: ' + p.result); if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
  }
  public ngOnInit(): void {
    this.foodHubStorage = {};
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
  ngAfterViewChecked() {
    let curthis = this;

    this.setTo = setTimeout(this.runAutoCompleteOnSelects, 1000, curthis);

  }
  runAutoCompleteOnSelects(curthis: any) {
    let hasFoundSelectsOnPage = false;

    if (!curthis.hasPopulatedPage) {

      let selects = jQuery('div#client-wrapper-foodhubsto select');

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
