import { Component, Injectable, OnInit, AfterViewInit,AfterContentInit } from '@angular/core';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import * as $ from 'jquery';
import { Observable } from 'rxjs/Observable';
import { AfricanFarmerCommoditiesService } from '../../services/africanFarmerCommoditiesService';
@Component({
  selector: 'reporting',
  templateUrl: './reporting.component.html',
  styleUrls: ['./reporting.component.css']
})
@Injectable()
export class ReportingComponent {

  constructor(private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {

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

  //////////////////
  GetReportTop5CommodityAndQuantity($event): void {
    var resultsObs: any = this.africanFarmerCommoditiesService.GetReportTop5CommodityAndQuantityOverall();
    resultsObs.map((q => {
      alert(q.message);
    })).subscribe();
    $event.preventDefault();
  }
  GetReportTop5CommodityAndGrossReturns($event): void {
    this.africanFarmerCommoditiesService.GetReportTop5CommodityAndGrossReturnssOverall();
    var resultsObs: any = resultsObs.map((q => {
      alert(q.message);
    })).subscribe();
    $event.preventDefault();
  }
  GetReportTop5FarmerCommoditiesByGrossReturns($event): void {
    var resultsObs: any = this.africanFarmerCommoditiesService.GetReportTop5FarmerCommoditiesByGrossReturns();
    resultsObs.map((q => {
      alert(q.message);
    })).subscribe();
    $event.preventDefault();
  }
  GetReportTop5FarmerVehicleCategoryUsageByCostReturns($event): void {
    var resultsObs: any = this.africanFarmerCommoditiesService.GetReportTop5FarmerVehicleCategoryUsageByCostReturns();
    resultsObs.map((q => {
      alert(q.message);
    })).subscribe();
    $event.preventDefault();
  }
  GetReportTop5VehicleCostReturnsScheduledByCategory($event): void {
    var resultsObs: any = this.africanFarmerCommoditiesService.GetReportTop5VehicleCostReturnsScheduledByCategory();
    resultsObs.map((q => {
      alert(q.message);
    })).subscribe();
    $event.preventDefault();
  }
  GetReportTop5VehicleNumbersScheduledByCategory($event): void {
    var resultsObs: any = this.africanFarmerCommoditiesService.GetReportTop5VehicleNumbersScheduledByCategory();
    resultsObs.map((q => {
      alert(q.message);
    })).subscribe();
    $event.preventDefault();
  }
  GetReportTop5FarmerVehicleCategoryUsageByNumber($event): void {
    this.africanFarmerCommoditiesService.GetReportTop5FarmerVehicleCategoryUsageByNumber();
    var resultsObs: any = resultsObs.map((q => {
      alert(q.message);
    })).subscribe();
    $event.preventDefault();
  }
}
