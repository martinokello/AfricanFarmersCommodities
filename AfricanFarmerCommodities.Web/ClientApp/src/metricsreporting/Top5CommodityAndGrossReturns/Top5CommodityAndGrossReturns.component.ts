import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter, AfterContentInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IVehicle,IAddress, ILocation, AfricanFarmerCommoditiesService, IVehicleCategory, ICompany, IAllFarmersCommoditiesInUnitPricing, ITop5FarmersCommoditiesByUnitPrice, ICommodityAndGrossReturns } from '../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
import * as $ from 'jquery';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';
import Chart from 'chart.js/auto';

@Component({
  selector: 'Top5CommodityAndGrossReturns',
  templateUrl: './Top5CommodityAndGrossReturns.component.html',
  styleUrls: ['./Top5CommodityAndGrossReturns.component.css'],
  providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class Top5CommodityAndGrossReturnsComponent implements OnInit, AfterContentInit {
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
  }
  canvas: any;
  ctx: any;
  unScheduledVehiclesChart: any;

  ngAfterContentInit(): void {
    let actualResult = this.africanFarmerCommoditiesService.GetTop5CommoditiesSoldByICommodityAndGrossReturns();
    actualResult.map((p: ICommodityAndGrossReturns[]) => {
      if (p && p.length > 0) {
        this.canvas = document.querySelector('canvas#top5CommoditiesSoldByGrossReturns');
        this.ctx = this.canvas.getContext('2d');

        let dataGroups: ICommodityAndGrossReturns[] = p;

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
  drawCharts(dataGroups: ICommodityAndGrossReturns[]): void {
    let labels: string[] = [];
    let data: number[] = [];

    dataGroups.map((q: ICommodityAndGrossReturns) => {
      labels.push(q.commodityName);
      data.push(q.GrossReturns);
    });

    if(this.unScheduledVehiclesChart) this.unScheduledVehiclesChart.destroy();
    this.unScheduledVehiclesChart = new Chart(this.ctx, {
      type: 'bar',
      data: {
        labels: labels,
        datasets: [{
          label: "Top 5 Commodities Sold By Gross Returns",
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
