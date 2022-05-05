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
  selector: 'foodHubCommoditiesStockStorageUsage',
  templateUrl: './foodHubCommoditiesStockStorageUsage.component.html',
  styleUrls: ['./foodHubCommoditiesStockStorageUsage.component.css'],
    providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class FoodHubCommoditiesStockStorageUsageComponent implements OnInit, AfterContentInit {
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  public foodHubStoreData: IFoodHubCommodityStorageUsage;
  canvas: any;
  ctx: any;
  indexIntoData: number;
  unScheduledVehiclesChart: Chart;

  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
  }
  public allFoodHubStorageAvailabilityStorage: IFoodHubCommodityStorageUsage[];

  public GetStorageDataValue(): void {
    let select: HTMLSelectElement = document.querySelector('select#stpfoodHubId');
    let foodHubIdSelected: number = parseInt(select.value);
    this.foodHubStoreData = this.allFoodHubStorageAvailabilityStorage.find(q => q.foodHubId == foodHubIdSelected);

    let dataGroups: any = [];
    dataGroups = [this.foodHubStoreData.dryStorageCapacity,
      this.foodHubStoreData.usedDryStorageCapacity,
      this.foodHubStoreData.refreigeratedStorageCapacity,
      this.foodHubStoreData.usedRefreigeratedStorageCapacity];
    let dataLabels: string[] = ["Total DryStorageCapacity", "Total Used DryStorageCapacity", "Total Refregirated StorageCapacity", "Total Used RefregiratedCapacity"];
    this.drawCharts(dataGroups, dataLabels);
  }
  ngAfterContentInit(): void {

    let actualResult = this.africanFarmerCommoditiesService.GetallFoodHubStorageAvailabilityStorage();
    actualResult.map((p: IFoodHubCommodityStorageUsage[]) => {
      this.allFoodHubStorageAvailabilityStorage = p;
      this.foodHubStoreData = p[0];
      let optionElem: HTMLOptionElement = document.createElement('option');
      optionElem.selected = true;
      optionElem.value = (0).toString();
      optionElem.text = "Select Food Hub";
      document.querySelector('select#stpfoodHubId').append(optionElem);

      this.drawChartsForFoodHubId(this.foodHubStoreData.foodHubId);
    }).subscribe()
  }

  drawChartsForFoodHubId(foodHubId: number) {
    let actualResult = this.africanFarmerCommoditiesService.GetFoodHubStorageAvailabilityStorageByFoodHubId(foodHubId);
    actualResult.map((p: IFoodHubCommodityStorageUsage[]) => {
      if (p && p.length > 0) {
        this.foodHubStoreData = p[0];
        this.allFoodHubStorageAvailabilityStorage = p;
        this.canvas = document.querySelector('canvas#commoditiesFoodHubUsageStorageCanvas');
        this.ctx = this.canvas.getContext('2d');

        let dataGroups: any = [];

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

        let unitGroupStorageUsage: any = {
          foodHubName: this.foodHubStoreData.foodHubName,
          totalDryStorageCapacity: totalDryStorageCapacity,
          totalUsedDryStorageCapacity: totalUsedDryStorageCapacity,
          totalRefregiratedStorageCapacity: totalRefregiratedStorageCapacity,
          totalUsedRefregiratedCapacity: totalUsedRefregiratedCapacity
        }
        dataGroups = [unitGroupStorageUsage.totalDryStorageCapacity,
        unitGroupStorageUsage.totalUsedDryStorageCapacity,
        unitGroupStorageUsage.totalRefregiratedStorageCapacity,
        unitGroupStorageUsage.totalUsedRefregiratedCapacity];

        let dataLabels: string[] = ["Total DryStorageCapacity", "Total Used DryStorageCapacity", "Total Refregirated StorageCapacity", "Total Used RefregiratedCapacity"];        this.drawCharts(dataGroups, dataLabels);
        this.drawCharts(dataGroups, dataLabels);
      }
      else {
        p = [];
      }
    }).subscribe();
    $('div#resultsViewFoodHubByIdStats').css('display', 'block').slideDown();
  }

  drawCharts(dataGroups: any, dataLabels: string[]): void {

      this.unScheduledVehiclesChart = new Chart(this.ctx, {
      type: 'bar',
      data: {
        labels: dataLabels,
        datasets: [{
          label: 'Storage Capacity Usage',
          data: dataGroups,
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

  ngOnInit() {
  }
}
