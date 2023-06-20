import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter, AfterContentInit, AfterViewChecked } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IFoodHub, IAddress, ILocation, AfricanFarmerCommoditiesService } from '../../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
declare var jQuery: any;
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';

@Component({
  selector: 'foodhub',
  templateUrl: './foodHub.component.html',
  styleUrls: ['./foodHub.component.css'],
    providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class FoodHubComponent implements OnInit, AfterContentInit, AfterViewChecked {
  hasPopulatedPage: boolean = false;
  setTo: NodeJS.Timeout;
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
    }
  public foodHub: IFoodHub | any;

  public addFoodHub(): void {
    this.foodHub.foodHubId = 0;
    this.foodHub.locationId = this.foodHub.location.locationId;
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.PostOrCreateFoodHub(this.foodHub);
    actualResult.map((p: any) => {
      alert('FoodHub Added: ' + p.result); if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    jQuery('form#locationView').css('display', 'block').slideDown();
  }
  public updateFoodHub() {
    this.foodHub.locationId = this.foodHub.location.locationId;
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.UpdateFoodHub(this.foodHub);
    actualResult.map((p: any) => {
      alert('FoodHub Updated: ' + p.result); if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    jQuery('form#locationView').css('display', 'block').slideDown();
  }
  public selectFoodHub(): void {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.GetFoodHubById(this.foodHub.foodHubId);
    actualResult.map((p: any) => {
      this.foodHub = p;
      this.foodHub.foodHubName = p.foodHubName;
      this.foodHub.location.locationId = p.locationId;
      this.foodHub.description = p.description;
    }).subscribe();
    jQuery('form#locationView').css('display', 'block').slideDown();
  }
  public deleteFoodHub() {
    this.foodHub.locationId = this.foodHub.location.locationId;
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.DeleteFoodHub(this.foodHub);
    actualResult.map((p: any) => {
      alert('FoodHub Deleted: ' + p.result); if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    jQuery('form#locationView').css('display', 'block').slideDown();
  }
  public ngOnInit(): void {
    this.foodHub = {
      foodHubId: 0,
      description:"",
      foodHubName: "",
      locationId: 0,
      location: {
        locationId: 0,
        locationName: "",
        address: {},
        addressId: -1}
      }
  }
  ngAfterContentInit(): void {
    const foodHubsObs: Observable<IFoodHub[]> = this.africanFarmerCommoditiesService.GetAllFoodHubs();
    const locatObs: Observable<ILocation[]> = this.africanFarmerCommoditiesService.GetAllLocations();

    let optionElem: HTMLOptionElement = document.createElement('option');
    optionElem.selected = true;
    optionElem.value = (0).toString();
    optionElem.text = "Select Food Hub";
    document.querySelector('select#foodHubId').append(optionElem);


    let optionElem1: HTMLOptionElement = document.createElement('option');
    optionElem1.value = (0).toString();
    optionElem1.text = "Select Location";
    document.querySelector('select#fhlocationId').append(optionElem1);


    foodHubsObs.map((cmds: IFoodHub[]) => {
      cmds.forEach((cmd: IFoodHub, index: number, cmds) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = cmd.foodHubId.toString();
        optionElem.text = cmd.foodHubName;
        document.querySelector('select#foodHubId').append(optionElem);
      });
    }).subscribe();

    locatObs.map((cmdCats: ILocation[]) => {
      cmdCats.forEach((comCat: ILocation, index: number, cmdCats) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = comCat.locationId.toString();
        optionElem.text = comCat.locationName;
        document.querySelector('select#fhlocationId').append(optionElem);
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

      let selects = jQuery('div#client-wrapper-foodhub select');

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
