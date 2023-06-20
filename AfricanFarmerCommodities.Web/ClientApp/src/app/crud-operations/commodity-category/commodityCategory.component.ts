import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter, AfterContentInit, AfterViewChecked } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ICommodityCategory, AfricanFarmerCommoditiesService } from '../../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
declare var jQuery: any;
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
export class CommodityCategoryComponent implements OnInit, AfterContentInit, AfterViewChecked {
  hasPopulatedPage: boolean = false;
  setTo: NodeJS.Timeout;
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
        jQuery('form#locationView').css('display', 'block').slideDown();
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
        jQuery('form#locationView').css('display', 'block').slideDown();
  }
  public selectCommodityCategory(): void {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.GetCommodityCategoryById(this.commodityCategory.commodityCategoryId);
    actualResult.map((p: any) => {
      this.commodityCategory = p; 
        }).subscribe();
        jQuery('form#locationView').css('display', 'block').slideDown();
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
        jQuery('form#locationView').css('display', 'block').slideDown();
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
  ngAfterViewChecked() {
    let curthis = this;

    this.setTo = setTimeout(this.runAutoCompleteOnSelects, 1000, curthis);

  }
  runAutoCompleteOnSelects(curthis: any) {
    let hasFoundSelectsOnPage = false;

    if (!curthis.hasPopulatedPage) {

      let selects = jQuery('div#client-wrapper-commodity-cat select');

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
