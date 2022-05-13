import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter, AfterContentInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IAllscheduledVehiclesByStorageCapacity, IVehicle,IAddress, ILocation, AfricanFarmerCommoditiesService, IVehicleCategory, ICompany } from '../../services/africanFarmerCommoditiesService';
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
  canvas: any;
  ctx: any;
  indexIntoData: number;
  unScheduledVehiclesChart: any;

  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
    }
  public scheduledVehicle: IAllscheduledVehiclesByStorageCapacity;

  public allscheduledVehicle: IAllscheduledVehiclesByStorageCapacity[];

  public getallScheduledVehiclesGroupedByStorageCapacity(): Observable<IAllscheduledVehiclesByStorageCapacity[]> {

    let actualResult: Observable<IAllscheduledVehiclesByStorageCapacity[]> = this.africanFarmerCommoditiesService.GetallScheduledVehiclesGroupedByStorageCapacity();
    return actualResult;
  }

  public GetVehicleCostDataByCategory(): void {
    let select: HTMLSelectElement = document.querySelector('select#sshvehicleId');
    let vehicleId: number = parseInt(select.value);

    this.scheduledVehicle = this.allscheduledVehicle.find(q => q.vehicleId == vehicleId);

    let dataLabels: string[] = ["cost"];
    this.drawSelectedChartData(dataLabels);
  }
  ngAfterContentInit(): void {
    let actualResult = this.getallScheduledVehiclesGroupedByStorageCapacity();
    actualResult.map((p: IAllscheduledVehiclesByStorageCapacity[]) => {
      if (p && p.length > 0) {
        this.allscheduledVehicle = p;
        this.scheduledVehicle = p[0];
        this.canvas = document.querySelector('canvas#vehicleScheduledCanvas');
        this.ctx = this.canvas.getContext('2d');

        let dataGroups: any = [];

        this.allscheduledVehicle.forEach(
          (availableScheduledVehicle: IAllscheduledVehiclesByStorageCapacity, index: number, elements) => {
            let scheduledVehs = elements.filter((q: IAllscheduledVehiclesByStorageCapacity) => {
              q.vehicleCategoryName == this.scheduledVehicle.vehicleCategoryName
                && q.companyName == this.scheduledVehicle.companyName;
            });
            let cost: number = 0;
            scheduledVehs.map((fh) => {
              cost += fh.cost;
            });
            let scheduledVehiclesByCompanyAndCategory: any[] = [cost];
            dataGroups.push(scheduledVehiclesByCompanyAndCategory);
          });

        let dataLabels: string[] = ["cost"];
        this.drawCharts(dataGroups, dataLabels);
      }
      else {
        this.allscheduledVehicle = [];
      }
    }).subscribe();
    $('div#scheduledVehicleWithCapacity').css('display', 'block').slideDown();
  }


  drawSelectedChartData(dataLabels: string[]): void {
    if (this.unScheduledVehiclesChart) this.unScheduledVehiclesChart.destroy();
    this.unScheduledVehiclesChart = new Chart(this.ctx, {
      type: 'bar',
      data: {
        labels: dataLabels,
        datasets: [{
          label: this.scheduledVehicle.companyName+", "+ this.scheduledVehicle.vehicleCategoryName,
          data: [this.scheduledVehicle.cost],
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
  drawCharts(dataGroups: any, dataLabels: string[]): void {

    if (this.unScheduledVehiclesChart) this.unScheduledVehiclesChart.destroy();
    this.unScheduledVehiclesChart = new Chart(this.ctx, {
      type: 'bar',
      data: {
        labels: dataLabels,
        datasets: [{
          label: this.scheduledVehicle.companyName + ", " + this.scheduledVehicle.vehicleCategoryName,
          data: [this.scheduledVehicle.cost],
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
