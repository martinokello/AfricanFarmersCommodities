import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter, AfterViewChecked } from '@angular/core';
import { IAddress, ILocation, AfricanFarmerCommoditiesService } from '../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
declare var jQuery: any;
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Component({
    selector: 'addLocation',
    templateUrl: './addLocation.component.html',
    styleUrls: ['./addLocation.component.css'],
    providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class AddLocationComponent implements OnInit,AfterViewChecked {
  setTo: NodeJS.Timeout;
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  hasPopulatedPage: boolean = false;
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
    }
    public location: ILocation | any;

    public addLocation(): void {
      let actualResult: Observable<any> = this.africanFarmerCommoditiesService.PostOrCreateLocation(this.location);
        actualResult.map((p: any) => {

            alert('Location Added: ' + p.result);
        }).subscribe();
        jQuery('div#locationView').css('display', 'block').slideDown();
    }
    public updateLocation() {
      let actualResult: Observable<any> = this.africanFarmerCommoditiesService.UpdateLocation(this.location);
        actualResult.map((p: any) => {

            alert('Location Added: ' + p.result);
        }).subscribe();
        jQuery('div#locationView').css('display', 'block').slideDown();
    }
    public ngOnInit(): void {
        this.location = {}
        this.location.address = {};
  }
  ngAfterViewChecked() {
    let curthis = this;

    this.setTo = setTimeout(this.runAutoCompleteOnSelects, 1000, curthis);

  }
  runAutoCompleteOnSelects(curthis: any) {
    let hasFoundSelectsOnPage = false;

    if (!curthis.hasPopulatedPage) {

      let selects = jQuery('div#client-wrapper-addLocation select');

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

        debugger;
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
