import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter, AfterContentInit, AfterViewChecked } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ITransportPricing,IAddress, ILocation, AfricanFarmerCommoditiesService, ITransportSchedule } from '../../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
declare var jQuery: any;
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';

@Component({
    selector: 'transport-pricing',
    templateUrl: './transportPricing.component.html',
  styleUrls: ['./transportPricing.component.css'],
    providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class TransportPricingComponent implements OnInit, AfterContentInit, AfterViewChecked {
  hasPopulatedPage: boolean = false;
  setTo: NodeJS.Timeout;
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
    }
  public transportPricing: ITransportPricing | any;

  public addTransportPricing(): void {
    this.transportPricing.transportPricingId = 0;
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.PostOrCreateTransportPricing(this.transportPricing);
    actualResult.map((p: any) => {
      alert('TransportPricing Added: ' + p.result);
      if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    jQuery('form#locationView').css('display', 'block').slideDown();
  }
  public updateTransportPricing() {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.UpdateTransportPricing(this.transportPricing);
    actualResult.map((p: any) => {
      alert('TransportPricing Updated: ' + p.result);
      if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    jQuery('form#locationView').css('display', 'block').slideDown();
  }
  public selectTransportPricing(): void {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.GetTransportPricingById(this.transportPricing.transportPricingId);
    actualResult.map((p: any) => {
      this.transportPricing = p;
    }).subscribe();
    jQuery('form#locationView').css('display', 'block').slideDown();
  }
  public deleteTransportPricing() {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.DeleteTransportPricing(this.transportPricing);
    actualResult.map((p: any) => {
      alert('TransportPricing Deleted: ' + p.result);
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
    this.transportPricing = {};
  }
  ngAfterContentInit(): void {
    const addsObs: Observable<ITransportPricing[]> = this.africanFarmerCommoditiesService.GetAllTransportPricings();

    let optionElem: HTMLOptionElement = document.createElement('option');
    optionElem.selected = true;
    optionElem.value = (0).toString();
    optionElem.text = "Select Transport Pricing";
    document.querySelector('select#transportPricingId').append(optionElem);

    addsObs.map((cmds: ITransportPricing[]) => {
      cmds.forEach((cmd: ITransportPricing, index: number, cmds) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = cmd.transportPricingId.toString();
        optionElem.text = cmd.transportPricingName;
        document.querySelector('select#transportPricingId').append(optionElem);
      });
    }).subscribe();

  } ngAfterViewChecked() {
    let curthis = this;

    this.setTo = setTimeout(this.runAutoCompleteOnSelects, 1000, curthis);

  }
  runAutoCompleteOnSelects(curthis: any) {
    let hasFoundSelectsOnPage = false;

    if (!curthis.hasPopulatedPage) {

      let selects = jQuery('div#client-wrapper-trnsprice select');

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
