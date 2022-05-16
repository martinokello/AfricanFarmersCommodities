import { Component, Injectable, OnInit, AfterViewInit,AfterContentInit } from '@angular/core';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import * as $ from 'jquery';
import { Observable } from 'rxjs/Observable';
import { AfricanFarmerCommoditiesService } from '../../services/africanFarmerCommoditiesService';
import { HttpResponse } from '@angular/common/http';
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
    resultsObs.map((blob: Blob) => {
      var url = window.URL.createObjectURL(blob);
      let a = document.createElement('a');
      a.href = url;
      a.download = "Top5CommodityAndQuantityOverall.xlsx";
      a.click();
    }).subscribe();

    $event.preventDefault();
  }
  GetReportTop5CommodityAndGrossReturns($event): void {
    let resultsObs = this.africanFarmerCommoditiesService.GetReportTop5CommodityAndGrossReturnssOverall();
    resultsObs.map((blob: Blob) => {
      var url = window.URL.createObjectURL(blob);
      let a = document.createElement('a');
      a.href = url;
      a.download = "Top5CommodityAndGrossReturnssOverall.xlsx";
      a.click();
    }).subscribe();
    $event.preventDefault();
  }
  GetReportTop5FarmerCommoditiesByGrossReturns($event): void {
    var resultsObs: any = this.africanFarmerCommoditiesService.GetReportTop5FarmerCommoditiesByGrossReturns();
    resultsObs.map((blob: Blob) => {
      var url = window.URL.createObjectURL(blob);
      let a = document.createElement('a');
      a.href = url;
      a.download = "Top5FarmerCommoditiesByGrossReturns.xlsx";
      a.click();
    }).subscribe();
    $event.preventDefault();
  }
  GetReportTop5FarmerVehicleCategoryUsageByCostReturns($event): void {
    var resultsObs: any = this.africanFarmerCommoditiesService.GetReportTop5FarmerVehicleCategoryUsageByCostReturns();
    resultsObs.map((blob: Blob) => {
      var url = window.URL.createObjectURL(blob);
      let a = document.createElement('a');
      a.href = url;
      a.download = "Top5FarmerVehicleCategoryUsageByCostReturns.xlsx";
      a.click();
    }).subscribe();
    $event.preventDefault();
  }
  GetReportTop5VehicleCostReturnsScheduledByCategory($event): void {
    var resultsObs: any = this.africanFarmerCommoditiesService.GetReportTop5VehicleCostReturnsScheduledByCategory();
    resultsObs.map((blob: Blob) => {
      var url = window.URL.createObjectURL(blob);
      let a = document.createElement('a');
      a.href = url;
      a.download = "Top5VehicleCostReturnsScheduledByCategory.xlsx";
      a.click();
    }).subscribe();
    $event.preventDefault();
  }
  GetReportTop5VehicleNumbersScheduledByCategory($event): void {
    var resultsObs: any = this.africanFarmerCommoditiesService.GetReportTop5VehicleNumbersScheduledByCategory();
    resultsObs.map((blob: Blob) => {
      var url = window.URL.createObjectURL(blob);
      let a = document.createElement('a');
      a.href = url;
      a.download = "Top5VehicleNumbersScheduledByCategory.xlsx";
      a.click();
    }).subscribe();
    $event.preventDefault();
  }
  GetReportTop5FarmerVehicleCategoryUsageByNumber($event): void {
    let resultsObs:Observable<Blob> = this.africanFarmerCommoditiesService.GetReportTop5FarmerVehicleCategoryUsageByNumber();
    resultsObs.map((blob: Blob) => {
      var url = window.URL.createObjectURL(blob);
      let a = document.createElement('a');
      a.href = url;
      a.download = "Top5FarmerVehicleCategoryUsageByNumber.xlsx";
      a.click();
    }).subscribe();
    $event.preventDefault();
  }
}
