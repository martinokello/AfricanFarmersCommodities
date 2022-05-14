import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter, AfterContentInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IAllscheduledVehiclesByStorageCapacity, IVehicle,IAddress, ILocation, AfricanFarmerCommoditiesService, IVehicleCategory, ICompany, IVehicleNumbersScheduled } from '../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
import * as $ from 'jquery';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';
import Chart from 'chart.js/auto';

@Component({
  selector: 'Top5VehicleNumbersScheduledByCategory',
  templateUrl: './Top5VehicleNumbersScheduledByCategory.component.html',
  styleUrls: ['./Top5VehicleNumbersScheduledByCategory.component.css'],
    providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class Top5VehicleNumbersScheduledByCategoryComponent implements OnInit, AfterContentInit {
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
  }
  canvas: any;
  ctx: any;
  unScheduledVehiclesChart: any;

  ngAfterContentInit(): void {
    let actualResult = this.africanFarmerCommoditiesService.GetTop5VehiclesCategoriesUsedByNumber();
    actualResult.map((p: IVehicleNumbersScheduled[]) => {
      if (p && p.length > 0) {
        this.canvas = document.querySelector('canvas#top5CommoditiesSoldByQuantityCanvas');
        this.ctx = this.canvas.getContext('2d');

        let dataGroups: IVehicleNumbersScheduled[] = p;

        this.drawCharts(dataGroups);
      }
      else {
        p = [];
      }
    }).subscribe();

    $('div#resultsViewTop5FarmerPricingStats').css('display', 'block').slideDown();
  }
  ngOnInit() {
  }
  drawCharts(dataGroups: IVehicleNumbersScheduled[]): void {
    let labels: string[] = [];
    let data: number[] = [];

    dataGroups.map((q: IVehicleNumbersScheduled) => {
      labels.push(q.vehicleCategoryName);
      data.push(q.numbersOfSchedules);
    });

    if (this.unScheduledVehiclesChart) this.unScheduledVehiclesChart.destroy();
    this.unScheduledVehiclesChart = new Chart(this.ctx, {
      type: 'bar',
      data: {
        labels: labels,
        datasets: [{
          label: "Top 5 Farmer Vehicle Category Usage",
          data: data,
          backgroundColor: [
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(58, 169, 235, 1)',
            'rgba(124, 162, 235, 1)',
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


