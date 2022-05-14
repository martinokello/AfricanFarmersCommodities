import { Component, Injectable, OnInit, AfterViewInit,AfterContentInit } from '@angular/core';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import * as $ from 'jquery';
import { Observable } from 'rxjs/Observable';
@Component({
  selector: 'reporting',
  templateUrl: './reporting.component.html',
  styleUrls: ['./reporting.component.css']
})
@Injectable()
export class ReportingComponent {

  constructor(public router: Router) {

  }

  ShowTop5CommodityAndQuantity($event): void {
    $('div.reports').css('display', 'none');
    $('div#Top5CommodityAndQuantity').css('display', 'block');
    $event.preventDefault();
  }
  ShowTop5CommodityAndGrossReturns($event): void {
    $('div.reports').css('display', 'none');
    $('div#Top5CommodityAndGrossReturns').css('display', 'block');
    $event.preventDefault();
  }
  ShowTop5FarmerCommodityAndGrossReturns($event): void {
    $('div.reports').css('display', 'none');
    $('div#Top5FarmerCommodityAndGrossReturns').css('display', 'block');
    $event.preventDefault();
  }
  ShowTop5FarmerVehicleCategoryUsageByCostReturns($event): void {
    $('div.reports').css('display', 'none');
    $('div#Top5FarmerVehicleCategoryUsageByCostReturns').css('display', 'block');
    $event.preventDefault();
  }
  ShowTop5VehicleCostReturnsScheduledByCategory($event): void {
    $('div.reports').css('display', 'none');
    $('div#Top5VehicleCostReturnsScheduledByCategory').css('display', 'block');
    $event.preventDefault();
  }
  ShowTop5VehicleNumbersScheduledByCategory($event): void {
    $('div.reports').css('display', 'none');
    $('div#Top5VehicleNumbersScheduledByCategory').css('display', 'block');
    $event.preventDefault();
  }
  ShowTop5FarmerVehicleCategoryUsageByNumber($event): void {
    $('div.reports').css('display', 'none');
    $('div#Top5FarmerVehicleCategoryUsageByNumber').css('display', 'block');
    $event.preventDefault();
  }
}
