import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter, AfterContentInit, AfterViewChecked } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IVehicle,IAddress, ILocation, AfricanFarmerCommoditiesService, IVehicleCategory, ICompany, IAllFarmersCommoditiesInUnitPricing, ITop5FarmersCommoditiesByUnitPrice } from '../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
declare var jQuery: any;
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';
import Chart from 'chart.js/auto';

@Component({
  selector: 'top5FarmerCommoditiesAnalysisInUnitPricing',
  templateUrl: './Top5FarmerCommoditiesAnalysisInUnitPricing.component.html',
  styleUrls: ['./Top5FarmerCommoditiesAnalysisInUnitPricing.component.css'],
  providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class Top5FarmerCommoditiesAnalysisInUnitPricingComponent implements OnInit, AfterContentInit, AfterViewChecked {
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  setTo: NodeJS.Timeout;
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
  }
  public currentFarmerPricingStats: ITop5FarmersCommoditiesByUnitPrice;
  public top5FarmerPricingStats: ITop5FarmersCommoditiesByUnitPrice[];
  canvas: any;
  ctx: any;
  indexIntoData: number;
  unScheduledVehiclesChart: any;
/*
  public getallFarmerCommoditiesPricings(): Observable<ITop5FarmersCommoditiesByUnitPrice[]> {

    let actualResult: Observable<ITop5FarmersCommoditiesByUnitPrice[]> = this.africanFarmerCommoditiesService.GetTop5FarmerCommoditiesUnitPricings();
    return actualResult;
  }*/

  public GetStorageDataValue(): void {
    let select: HTMLSelectElement = document.querySelector('select#farmerId');
    let farmerId: number = parseInt(select.value);
    let storage: ITop5FarmersCommoditiesByUnitPrice = this.top5FarmerPricingStats.find(
      (value: ITop5FarmersCommoditiesByUnitPrice, index: number) => { this.indexIntoData = index; return value.farmerId == farmerId;}
    );
    this.currentFarmerPricingStats = storage;
    let dataLabels: string[] = ["Farmer Commodity UnitPrice Total"];
    this.drawSelectedChartData(dataLabels);
  }
  ngAfterContentInit(): void {
    let actualResult = this.africanFarmerCommoditiesService.GetTop5FarmerCommoditiesUnitPricings();
    actualResult.map((p: ITop5FarmersCommoditiesByUnitPrice[]) => {
      if (p && p.length > 0) {
        this.currentFarmerPricingStats = p[0];
        this.top5FarmerPricingStats = p;
        this.canvas = document.querySelector('canvas#top5FarmersCommoditiesByUnitPriceCanvas');
        this.ctx = this.canvas.getContext('2d');

        let dataGroups: any = [];

        this.top5FarmerPricingStats.forEach(
          (availableScheduledVehicle: ITop5FarmersCommoditiesByUnitPrice, index: number, elements) => {
            let top5UnitPriceFarmerCommodities = elements.filter((q: ITop5FarmersCommoditiesByUnitPrice) => {
              q.commodityName == this.currentFarmerPricingStats.commodityName
                && q.commodityCategoryName == this.currentFarmerPricingStats.commodityCategoryName
              q.farmerId == this.currentFarmerPricingStats.farmerId;
            });
            let farmerCommodityUnitPriceTotal: number = 0;
            top5UnitPriceFarmerCommodities.map((fh) => {
              farmerCommodityUnitPriceTotal += fh.farmerCommodityUnitPrice;
            });
            let farmerCommodityUnitPrice: any = [farmerCommodityUnitPriceTotal];
              
            dataGroups.push(farmerCommodityUnitPrice);
          });
        let dataLabels: string[] = ["Farmer Commodity UnitPrice Total"];
        this.drawCharts(dataGroups, dataLabels);
      }
      else {
        p = [];
      }
    }).subscribe();
    $('div#resultsViewTop5FarmerPricingStats').css('display', 'block').slideDown();
  }
  ngOnInit() {
  }
  drawCharts(dataGroups: any, dataLabels: string[]): void {

    if (this.unScheduledVehiclesChart) this.unScheduledVehiclesChart.destroy();
     this.unScheduledVehiclesChart = new Chart(this.ctx, {
      type: 'bar',
      data: {
        labels: dataLabels,
        datasets: [{
          label: this.currentFarmerPricingStats.farmerName + ", " + this.currentFarmerPricingStats.commodityName + ", " + this.currentFarmerPricingStats.commodityCategoryName,
          data: [this.currentFarmerPricingStats.farmerCommodityUnitPrice],
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
          label: this.currentFarmerPricingStats.farmerName + ", " + this.currentFarmerPricingStats.commodityName + ", " + this.currentFarmerPricingStats.commodityCategoryName,
          data: [this.currentFarmerPricingStats.farmerCommodityUnitPrice],
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
  } ngAfterViewChecked() {
    let curthis = this;

    this.setTo = setTimeout(this.runAutoCompleteOnSelects, 1000, curthis);

  }
  runAutoCompleteOnSelects(curthis: any) {
    let hasFoundSelectsOnPage = false;

    if (!curthis.hasPopulatedPage) {

      let selects = jQuery('div#client-wrapper-addVehicle select');

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

      clearTimeout(curthis.setTo);
    }
  }
}
