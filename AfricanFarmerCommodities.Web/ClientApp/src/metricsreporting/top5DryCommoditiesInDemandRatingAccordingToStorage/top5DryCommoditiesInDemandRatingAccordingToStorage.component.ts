import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter, AfterContentInit, AfterViewChecked } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IVehicle,IAddress, ILocation, AfricanFarmerCommoditiesService, IVehicleCategory, ICompany, ITop5DryStorageCommoditiesInDemandRating } from '../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
declare var jQuery: any;
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';
import Chart from 'chart.js/auto';

@Component({
  selector: 'top5DryCommoditiesInDemandRatingAccordingToStorage',
  templateUrl: './top5DryCommoditiesInDemandRatingAccordingToStorage.component.html',
  styleUrls: ['./top5DryCommoditiesInDemandRatingAccordingToStorage.component.css'],
    providers: [AfricanFarmerCommoditiesService]
}) 
@Injectable()
export class Top5DryCommoditiesInDemandRatingAccordingToStorageComponent implements OnInit, AfterContentInit, AfterViewChecked {
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  setTo: NodeJS.Timeout;
  canvas: any;
  ctx: any;
  indexIntoData: number;
  unScheduledVehiclesChart: Chart;

  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
    }
  public top5DryStorageCommodities: ITop5DryStorageCommoditiesInDemandRating[];
  public currentTop5StorageCommodidites: ITop5DryStorageCommoditiesInDemandRating;

  public getTop5DryCommoditiesInDemandRatingAccordingToStorageFacilities(): Observable<ITop5DryStorageCommoditiesInDemandRating[]> {
    let actualResult: Observable<ITop5DryStorageCommoditiesInDemandRating[]>  = this.africanFarmerCommoditiesService.GetTop5DryCommoditiesInDemandRatingAccordingToStorageFacilities();
    return actualResult;
  }

  public GetTop5CommoditieByStorage(): void {

    let select: HTMLSelectElement = document.querySelector('select#top5commodityId');
    let commodityId: number = parseInt(select.value);
     this.currentTop5StorageCommodidites = this.top5DryStorageCommodities.find((curTopChoice: ITop5DryStorageCommoditiesInDemandRating) => {
       return curTopChoice.commodityId == commodityId;
     });
    let dataLabels: string[] = ["Total DryStorage Capacity", "Total Used DryStorage Capacity"];
    this.drawSelectedChartData(dataLabels);
  }
  public ngOnInit(): void {
    this.top5DryStorageCommodities = []
  }
  ngAfterContentInit(): void {
    let actualResult = this.getTop5DryCommoditiesInDemandRatingAccordingToStorageFacilities();
    actualResult.map((p: ITop5DryStorageCommoditiesInDemandRating[]) => {
      if (p && p.length > 0) {
        this.top5DryStorageCommodities = p;
        this.currentTop5StorageCommodidites = p[0];
        this.canvas = document.querySelector('canvas#top5AvailableDryFoodStorageCanvas');
        this.ctx = this.canvas.getContext('2d');

        let dataGroups: any = [];

        this.top5DryStorageCommodities.forEach(
          (availableScheduledVehicle: ITop5DryStorageCommoditiesInDemandRating, index: number, elements) => {
            let top5StoredCommodities = elements.filter((q: ITop5DryStorageCommoditiesInDemandRating) => {
              q.commodityName == this.currentTop5StorageCommodidites.commodityName
                && q.commodityCategoryName == this.currentTop5StorageCommodidites.commodityCategoryName;
              this.indexIntoData = index;
            });
            let totalDryStorageCapacity: number = 0;
            let totalUsedDryStorageCapacity: number = 0;
            top5StoredCommodities.map((fh) => {
              totalDryStorageCapacity += fh.totalDryStorageCapacity;
              totalUsedDryStorageCapacity += fh.totalUsedDryStorageCapacity;
            });
            let dryCommodityCategory: any[] = [
              totalDryStorageCapacity,
              totalUsedDryStorageCapacity];
              dataGroups.push(dryCommodityCategory);
          });

        let dataLabels: string[] = ["Total DryStorage Capacity", "Total Used DryStorage Capacity"];
        this.drawCharts(dataGroups, dataLabels);
      }
      else {
        p = [];
      }
    }).subscribe();
    $('div#resultsAllViewFoodHubStats').css('display', 'block').slideDown();
  }
  drawCharts(dataGroups: any, dataLabels: string[]): void {

    if (this.unScheduledVehiclesChart) this.unScheduledVehiclesChart.destroy();
     this.unScheduledVehiclesChart = new Chart(this.ctx, {
      type: 'bar',
      data: {
        labels: dataLabels,
        datasets: [{
          label:
            this.currentTop5StorageCommodidites.commodityName+", "+this.currentTop5StorageCommodidites.commodityCategoryName,
          data: [this.currentTop5StorageCommodidites.totalDryStorageCapacity, this.currentTop5StorageCommodidites.totalUsedDryStorageCapacity],
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
          label:
            this.currentTop5StorageCommodidites.commodityName + ", " + this.currentTop5StorageCommodidites.commodityCategoryName,
          data: [this.currentTop5StorageCommodidites.totalDryStorageCapacity,this.currentTop5StorageCommodidites.totalUsedDryStorageCapacity],
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
