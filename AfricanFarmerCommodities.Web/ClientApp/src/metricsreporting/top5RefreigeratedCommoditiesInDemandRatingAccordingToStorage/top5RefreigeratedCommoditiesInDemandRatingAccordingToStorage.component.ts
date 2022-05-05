import { AfterContentInit, Component, Injectable, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import Chart from 'chart.js/auto';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';
import * as $ from 'jquery';

import { AfricanFarmerCommoditiesService, ITop5ReferigeratedStorageCommoditiesInDemandRating } from '../../services/africanFarmerCommoditiesService';

@Component({
  selector: 'top5RefreigeratedCommoditiesInDemandRatingAccordingToStorage',
  templateUrl: './top5RefreigeratedCommoditiesInDemandRatingAccordingToStorage.component.html',
  styleUrls: ['./top5RefreigeratedCommoditiesInDemandRatingAccordingToStorage.component.css'],
    providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class Top5RefreigeratedCommoditiesInDemandRatingAccordingToStorageComponent implements OnInit, AfterContentInit {
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
    }
  public top5RefregiratedStorageCommodities: ITop5ReferigeratedStorageCommoditiesInDemandRating[];
  public currentTop5RefgStorageCommodidites: ITop5ReferigeratedStorageCommoditiesInDemandRating;
  canvas: any;
  ctx: any;
  indexIntoData: number = 0;
  unScheduledVehiclesChart: Chart;

  public getTop5ReferigatedCommoditiesInDemandRatingAccordingToStorageFacilities(): Observable<ITop5ReferigeratedStorageCommoditiesInDemandRating[]> {
    let actualResult: Observable<ITop5ReferigeratedStorageCommoditiesInDemandRating[]> = this.africanFarmerCommoditiesService.GetTop5RefreigeratedCommoditiesInDemandRatingAccordingToStorageFacilities();
    return actualResult;
  }

  public GetTop5CommoditieByStorage(): void {
      let currentCommoditySelect: HTMLSelectElement = document.querySelector("select#commodityId");
      let curCommodityId: number = parseInt(currentCommoditySelect.value);
      this.currentTop5RefgStorageCommodidites = this.top5RefregiratedStorageCommodities.find((curTopChoice: ITop5ReferigeratedStorageCommoditiesInDemandRating) => {
        return curTopChoice.commodityId == curCommodityId;
      });
    let dataLabels: string[] = ["Total Refreigerated StorageCapacity", "Total Used Refreigerated StorageCapacity"];
    this.drawSelectedChartData(dataLabels);
  }
  public ngOnInit(): void {
    this.top5RefregiratedStorageCommodities = []
  }
  ngAfterContentInit(): void {
    let actualResult = this.getTop5ReferigatedCommoditiesInDemandRatingAccordingToStorageFacilities();
    actualResult.map((p: ITop5ReferigeratedStorageCommoditiesInDemandRating[]) => {
      if (p && p.length > 0) {
        this.top5RefregiratedStorageCommodities = p;
        this.currentTop5RefgStorageCommodidites = p[0]
        this.canvas = document.querySelector('canvas#availableRefregFoodHubStorageCanvas');
        this.ctx = this.canvas.getContext('2d');

        let dataGroups: any = [];

        this.top5RefregiratedStorageCommodities.forEach(
          (availableScheduledVehicle: ITop5ReferigeratedStorageCommoditiesInDemandRating, index: number, elements) => {
            let top5StoredReferigeratedCommodities = elements.filter((q: ITop5ReferigeratedStorageCommoditiesInDemandRating) => {
              q.commodityName == this.currentTop5RefgStorageCommodidites.commodityName
                && q.commodityCategoryName == this.currentTop5RefgStorageCommodidites.commodityCategoryName;
            });
            let totalRefreigeratedStorageCapacity: number = 0;
            let totalUsedRefreigeratedStorageCapacity: number = 0;
            top5StoredReferigeratedCommodities.map((fh) => {
              totalRefreigeratedStorageCapacity += fh.totalRefreigeratedStorageCapacity;
              totalUsedRefreigeratedStorageCapacity += fh.totalUsedRefreigeratedStorageCapacity;
            });
            let refregieratedCommodityCategory: any = [totalRefreigeratedStorageCapacity, totalUsedRefreigeratedStorageCapacity];
            
            dataGroups.push(refregieratedCommodityCategory);
          });

        let dataLabels: string[] = [ "Total Referigerated StorageCapacity","Total Used  Refegirated StorageCapacity"];
        this.drawCharts(dataGroups, dataLabels);
      }
      else {
        p = [];
      }
    }).subscribe();
    $('div#resultsViewTop5ReferigeratedStorageUsage').css('display', 'block').slideDown();
  }
  drawCharts(dataGroups: any, dataLabels: string[]): void {
    if (this.unScheduledVehiclesChart) this.unScheduledVehiclesChart.destroy();
    this.unScheduledVehiclesChart = new Chart(this.ctx, {
      type: 'bar',
      data: {
        labels: dataLabels,
        datasets: [{
          label: this.currentTop5RefgStorageCommodidites.commodityName+", "+this.currentTop5RefgStorageCommodidites.commodityCategoryName,
          data: [this.currentTop5RefgStorageCommodidites.totalRefreigeratedStorageCapacity, this.currentTop5RefgStorageCommodidites.totalUsedRefreigeratedStorageCapacity],
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

  drawSelectedChartData(dataLabels: string[]): void {
    if (this.unScheduledVehiclesChart) this.unScheduledVehiclesChart.destroy();
    this.unScheduledVehiclesChart = new Chart(this.ctx, {
      type: 'bar',
      data: {
        labels: dataLabels,
        datasets: [{
          label: 'Referigerated Storage Capacity',
          data: [this.currentTop5RefgStorageCommodidites.totalRefreigeratedStorageCapacity, this.currentTop5RefgStorageCommodidites.totalUsedRefreigeratedStorageCapacity],

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
}
