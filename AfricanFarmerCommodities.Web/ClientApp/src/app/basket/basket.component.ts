import { AfterContentInit, ChangeDetectorRef, Component, Injectable, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';
import * as $ from 'jquery';
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
export class BasketComponent implements OnInit, AfterViewInit {
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
        $(form).find("input[name='numberOfUnits']").attr('value', cmd.numberOfUnits);
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
    $('div#commoditiesOrder form').remove();

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
    //let numberOfUnits: number = parseFloat($(form).find("input[name='numberOfUnits']").val());

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
      $(form).remove();
    }
    sessionStorage.setItem("runningTotalPrice", this.runningTotalPrice.toString());

    sessionStorage.setItem("ActualContents", JSON.stringify(this.actualOrderGoingForward));
    sessionStorage.setItem("Orders", JSON.stringify(this.contentOrders));
  }
}

