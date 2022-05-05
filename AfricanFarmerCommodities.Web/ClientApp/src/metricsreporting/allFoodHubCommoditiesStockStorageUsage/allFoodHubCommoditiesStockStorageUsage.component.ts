import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter, AfterContentInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IVehicle,IAddress, ILocation, AfricanFarmerCommoditiesService, IVehicleCategory, ICompany, IFoodHubCommodityStorageUsage } from '../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
import * as $ from 'jquery';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';
import Chart from 'chart.js/auto';

@Component({
  selector: 'allFoodHubCommoditiesStockStorageUsage',
  templateUrl: './allFoodHubCommoditiesStockStorageUsage.component.html',
  styleUrls: ['./allFoodHubCommoditiesStockStorageUsage.component.css'],
    providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class AllFoodHubCommoditiesStockStorageUsageComponent implements OnInit, AfterContentInit {
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  canvas: any;
  ctx: any;
  unScheduledVehiclesChart: Chart;
  indexIntoData: number;
  dataGroups: number[] = [];
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
    }
  public allFoodHubStorageAvailabilityStorage: IFoodHubCommodityStorageUsage[];

  public getallFoodHubStorageAvailabiliyStorage(): Observable<IFoodHubCommodityStorageUsage[]> {

    let actualResult: Observable<IFoodHubCommodityStorageUsage[]> = this.africanFarmerCommoditiesService.GetallFoodHubStorageAvailabilityStorage();
    return actualResult;
  }
  ngAfterContentInit(): void {
    let actualResult = this.africanFarmerCommoditiesService.GetallFoodHubStorageAvailabilityStorage();
    actualResult.map((p: IFoodHubCommodityStorageUsage[]) => {
      if (p && p.length > 0) {
        this.allFoodHubStorageAvailabilityStorage = p;
        this.canvas = document.querySelector('canvas#allAvailableFoodHubStorageCanvas');
        this.ctx = this.canvas.getContext('2d');
        this.dataGroups = [];

        let totalDryStorageCapacity: number = 0;
        let totalUsedDryStorageCapacity: number = 0;
        let totalRefregiratedStorageCapacity: number = 0;
        let totalUsedRefregiratedCapacity: number = 0;

        this.allFoodHubStorageAvailabilityStorage.forEach(
          (availableFoodHubStr: IFoodHubCommodityStorageUsage, index: number, elements) => {
            totalDryStorageCapacity += availableFoodHubStr.dryStorageCapacity;
            totalUsedDryStorageCapacity += availableFoodHubStr.usedDryStorageCapacity;
            totalRefregiratedStorageCapacity += availableFoodHubStr.refreigeratedStorageCapacity;
            totalUsedRefregiratedCapacity += availableFoodHubStr.usedRefreigeratedStorageCapacity
          });
        let unitGroupStorageUsage: number[] = [ totalDryStorageCapacity, totalUsedDryStorageCapacity, totalRefregiratedStorageCapacity, totalUsedRefregiratedCapacity]
        this.dataGroups = unitGroupStorageUsage;

        this.showFoodHubData();
      }
      else {
        p = [];
      }
    }).subscribe();
    $('div#resultsAllViewFodHubStats').css('display', 'block').slideDown();
  }
  drawCharts(dataLabels: string[]): void {

    //if (this.unScheduledVehiclesChart) this.unScheduledVehiclesChart.destroy()
    this.unScheduledVehiclesChart = new Chart(this.ctx, {
      type: 'bar',
      data: {
        labels: dataLabels,
        datasets: [{
          label: 'Storage Capacity Usage',
          data: this.dataGroups,
          backgroundColor: [
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)'
          ],
          borderWidth: 1
        }]
      },
      options: {
        responsive: false
      }
    });
  }
  showFoodHubData() {
    let dataLabels: string[] = [ "Total DryStorageCapacity", "Total Used DryStorageCapacity", "Total Refregirated StorageCapacity", "Total Used RefregiratedCapacity"];
    this.drawCharts(dataLabels);
  }
  ngOnInit() {
  }
}
