import { AfterContentInit, AfterViewChecked, ChangeDetectorRef, Component, Injectable, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';
declare var jQuery: any;
import { AfricanFarmerCommoditiesService, ICommodity } from '../../services/africanFarmerCommoditiesService';
import { AfterViewInit } from '@angular/core';
import { Renderer } from '@angular/core';
@Component({
  selector: 'payments',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.css'],
  providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class BasketComponent implements OnInit, AfterViewInit, AfterViewChecked {
  setTo: NodeJS.Timeout;
  contentOrders: ICommodity[];
  actualOrderGoingForward: ICommodity[] = [];
  runningTotalPrice: number = 0;
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService | any;
  @ViewChild("commoditiesOrder", { static: false }) commoditiesOrder: HTMLElement | any;
  public currentPayment: number | any;
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private cdr: ChangeDetectorRef, private router: Router, private renderer: Renderer) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
    this.runningTotalPrice = 0;
  }
  ngAfterViewInit(): void {

    if (this.actualOrderGoingForward && this.actualOrderGoingForward.length > 0) {
      this.actualOrderGoingForward.forEach((cmd: ICommodity) => {
        let form: HTMLFormElement = document.querySelector('form[id="form' + cmd.commodityId.toString() + '"]');
        jQuery(form).find("input[name='numberOfUnits']").attr('value', cmd.numberOfUnits);
      });
    }

    if (sessionStorage.getItem("runningTotalPrice") != null)
      this.runningTotalPrice = parseFloat(sessionStorage.getItem("runningTotalPrice"));
    else this.runningTotalPrice = 0;
  }

  public makePayment(): void {
    this.actualOrderGoingForward = JSON.parse(sessionStorage.getItem("ActualContents"));

    if (sessionStorage.getItem("runningTotalPrice") != null)
      this.runningTotalPrice = parseFloat(sessionStorage.getItem("runningTotalPrice"));
    else this.runningTotalPrice = 0;
    if (this.runningTotalPrice == 0) {
      alert("Your payment Price is 0. Cannot take payment");
      return;
    }
    this.currentPayment = this.runningTotalPrice;
    let result: Observable<any> = this.africanFarmerCommoditiesService.MakePayment(this.currentPayment, this.actualOrderGoingForward, AfricanFarmerCommoditiesService.clientEmailAddress);

    result.map((q: any) => {
      window.open(q.payPalRedirectUrl);
      console.log('Response received');
      console.log(q.paypalUrl);
      sessionStorage.removeItem("Orders");
      sessionStorage.removeItem("ActualContents");
      sessionStorage.removeItem("runningTotalPrice");
      this.contentOrders = [];
      this.actualOrderGoingForward = [];
      this.runningTotalPrice = 0;
      this.cdr.detectChanges();
      alert("Payment made. Currently being processed by paypal service!");
    }).subscribe();
  }
  public clearBasket(): void {

    this.runningTotalPrice = 0;
    this.contentOrders = [];
    this.actualOrderGoingForward = [];
    sessionStorage.removeItem("Orders");
    sessionStorage.removeItem("ActualContents");
    sessionStorage.removeItem("runningTotalPrice");
    //remove the forms:
    this.cdr.detectChanges();
    jQuery('div#commoditiesOrder form').remove();

  }
  public ngOnInit(): void {
    this.contentOrders = JSON.parse(sessionStorage.getItem("Orders"));
    this.cdr.detectChanges();
  }

  addCommodity(commodityId: number): void {

    if (sessionStorage.getItem("runningTotalPrice") != null)
      this.runningTotalPrice = parseFloat(sessionStorage.getItem("runningTotalPrice"));
    else this.runningTotalPrice = 0;

    if (sessionStorage.getItem("ActualContents"))
      this.actualOrderGoingForward = JSON.parse(sessionStorage.getItem("ActualContents"));
    else {
      this.actualOrderGoingForward = [];
    }

    let currentCommodity: ICommodity = this.contentOrders.find((q: ICommodity) => { return q.commodityId == commodityId });

    let form: HTMLFormElement = document.querySelector('form[id="form' + commodityId + '"]');
    let numbUnitsEle: HTMLInputElement = form.querySelector("input#numberOfUnits");
    let numberOfUnits: number = parseFloat(numbUnitsEle.value);
    currentCommodity.numberOfUnits = numberOfUnits.toString();

    if (numberOfUnits > currentCommodity.unitsAvailable) {
      alert(currentCommodity.commodityName + ", order cannot be fulfilled");
      return;
    }

    currentCommodity.unitsAvailable -= numberOfUnits;
    this.actualOrderGoingForward.push(currentCommodity);
    this.runningTotalPrice += (currentCommodity.commodityUnitPrice * numberOfUnits);

    sessionStorage.setItem("runningTotalPrice", this.runningTotalPrice.toString());
    sessionStorage.setItem("ActualContents", JSON.stringify(this.actualOrderGoingForward));

    sessionStorage.setItem("Orders", JSON.stringify(this.actualOrderGoingForward));

  }

  removeCommodity(commodityId: number): void {
    this.actualOrderGoingForward = JSON.parse(sessionStorage.getItem("ActualContents"));
    if (sessionStorage.getItem("runningTotalPrice") != null)
      this.runningTotalPrice = parseFloat(sessionStorage.getItem("runningTotalPrice"));
    else this.runningTotalPrice = 0;

    let currentCommodity: ICommodity = this.contentOrders.find((q: ICommodity) => { return q.commodityId == commodityId });
    let actIndexToRem = this.actualOrderGoingForward.findIndex(q => q.commodityId == commodityId);
    let actRem: ICommodity[] = this.actualOrderGoingForward.splice(actIndexToRem, 1);

    let form: HTMLFormElement = document.querySelector('form[id="form' + commodityId.toString() + '"]');
    //let numberOfUnits: number = parseFloat(jQuery(form).find("input[name='numberOfUnits']").val());

    let indexToRemove: number = this.contentOrders.findIndex(q => q.commodityId == commodityId);
    this.contentOrders.splice(indexToRemove, 1);
    let numbOfUnits = parseInt(actRem[0].numberOfUnits);
    if (this.runningTotalPrice > 0) {
      this.runningTotalPrice -= (actRem[0].commodityUnitPrice * numbOfUnits);
      currentCommodity.unitsAvailable += numbOfUnits;
    }
    else {
      this.runningTotalPrice = 0;
      sessionStorage.setItem("runningTotalPrice", "0");
      jQuery(form).remove();
    }
    sessionStorage.setItem("runningTotalPrice", this.runningTotalPrice.toString());

    sessionStorage.setItem("ActualContents", JSON.stringify(this.actualOrderGoingForward));
    sessionStorage.setItem("Orders", JSON.stringify(this.contentOrders));
  } ngAfterViewChecked() {
    let curthis = this;

    this.setTo = setTimeout(this.runAutoCompleteOnSelects, 1000, curthis);

  }
  runAutoCompleteOnSelects(curthis: any) {
    let hasFoundSelectsOnPage = false;

    if (!curthis.hasPopulatedPage) {

      let selects = jQuery('div#client-wrapper-basket select');

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

      jQuery('div#editableClientDetails').hide(2000);
      clearTimeout(curthis.setTo);
    }
  }
}

