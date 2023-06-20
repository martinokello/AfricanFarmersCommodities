import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter, AfterContentInit, AfterViewChecked } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IVehicleCategory, IAddress, ILocation, AfricanFarmerCommoditiesService, IVehicleCapacity } from '../../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
declare var jQuery: any;
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
export class vehicleCategoryComponent implements OnInit, AfterContentInit, AfterViewChecked {
  hasPopulatedPage: boolean = false;
  setTo: NodeJS.Timeout;
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
    jQuery('form#locationView').css('display', 'block').slideDown();
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
    jQuery('form#locationView').css('display', 'block').slideDown();
  }
  public selectVehicleCategory(): void {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.GetVehicleCategoryById(this.vehicleCategory.vehicleCategoryId);
    actualResult.map((p: any) => {
      this.vehicleCategory = p;
    }).subscribe();
    jQuery('form#locationView').css('display', 'block').slideDown();
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
    jQuery('form#locationView').css('display', 'block').slideDown();
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


  } ngAfterViewChecked() {
    let curthis = this;

    this.setTo = setTimeout(this.runAutoCompleteOnSelects, 1000, curthis);

  }
  runAutoCompleteOnSelects(curthis: any) {
    let hasFoundSelectsOnPage = false;

    if (!curthis.hasPopulatedPage) {

      let selects = jQuery('div#client-wrapper-vehcat select');

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
