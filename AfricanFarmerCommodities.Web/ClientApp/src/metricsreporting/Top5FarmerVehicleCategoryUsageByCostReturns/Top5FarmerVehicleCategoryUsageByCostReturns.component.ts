import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter, AfterContentInit, AfterViewChecked } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IAllscheduledVehiclesByStorageCapacity, IVehicle,IAddress, ILocation, AfricanFarmerCommoditiesService, IVehicleCategory, ICompany, IFarmerVehicleCategoryUsageByCostReturns } from '../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
declare var jQuery: any;
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';
import Chart from 'chart.js/auto';

@Component({
  selector: 'Top5FarmerVehicleCategoryUsageByCostReturns',
  templateUrl: './Top5FarmerVehicleCategoryUsageByCostReturns.component.html',
  styleUrls: ['./Top5FarmerVehicleCategoryUsageByCostReturns.component.css'],
    providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class Top5FarmerVehicleCategoryUsageByCostReturnsComponent implements OnInit, AfterContentInit, AfterViewChecked {
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  setTo: NodeJS.Timeout;
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
  }
  canvas: any;
  ctx: any;
  unScheduledVehiclesChart: any;

  ngAfterContentInit(): void {
    let actualResult = this.africanFarmerCommoditiesService.GetTop5FarmerVehicleCategoryUsageByCostReturnsOverYear();
    actualResult.map((p: IFarmerVehicleCategoryUsageByCostReturns[]) => {
      if (p && p.length > 0) {
        this.canvas = document.querySelector('canvas#top5FarmerVehicleCategoryUsageByCostReturnsCanvas');
        this.ctx = this.canvas.getContext('2d');

        let dataGroups: IFarmerVehicleCategoryUsageByCostReturns[] = p;

        this.drawCharts(dataGroups);
      }
      else {
        p = [];
      }
    }).subscribe();
  }
  ngOnInit() {
  }
  drawCharts(dataGroups: IFarmerVehicleCategoryUsageByCostReturns[]): void {
    let labels: string[] = [];
    let data: number[] = [];

    dataGroups.forEach((q: IFarmerVehicleCategoryUsageByCostReturns) => {
      labels.push(q.farmerName + ", " + q.vehicleCategoryName);
      data.push(q.grossReturns);
    });

    if (this.unScheduledVehiclesChart) this.unScheduledVehiclesChart.destroy();
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
