import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter, AfterContentInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IAllscheduledVehiclesByStorageCapacity, IVehicle, IAddress, ILocation, AfricanFarmerCommoditiesService, IVehicleCategory, ICompany, IUnscheduledVehiclesByStorageCapacity } from '../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
import * as $ from 'jquery';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';
import Chart from 'chart.js/auto';

@Component({
  selector: 'unScheduledVehiclesByStorageCapacity',
  templateUrl: './unscheduledVehiclesByStorageCapacity.component.html',
  styleUrls: ['./unscheduledVehiclesByStorageCapacity.component.css'],
  providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class UnScheduledVehiclesByStorageCapacityComponent implements OnInit, AfterContentInit {
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  canvas: any;
  ctx: any;
  indexIntoData: number = 0;
  unScheduledVehiclesChart: any;

  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
  }
  public unScheduledVehicle: IUnscheduledVehiclesByStorageCapacity;

  public allUnScheduledVehicle: IUnscheduledVehiclesByStorageCapacity[];

  public getallUnScheduledVehiclesGroupedByStorageCapacity(): Observable<IUnscheduledVehiclesByStorageCapacity[]> {

    let actualResult: Observable<IUnscheduledVehiclesByStorageCapacity[]> = this.africanFarmerCommoditiesService.GetallUnScheduledVehiclesGroupedByStorageCapacity();
    return actualResult;
  }
  public GetVehicleCostDataByCategory(): void {

    let select: HTMLSelectElement = document.querySelector('select#unShvehicleId');
    let vehicleId: number = parseInt(select.value);

    this.unScheduledVehicle = this.allUnScheduledVehicle.find(
      (unschVehi: IUnscheduledVehiclesByStorageCapacity, index: number) => {
        this.indexIntoData = index;
        return unschVehi.vehicleId == vehicleId;
      }
    ); 
    let dataLabels: string[] = [ "cost"];
    this.drawSelectedChartData(dataLabels);
  }
  ngAfterContentInit(): void {
    let actualResult = this.getallUnScheduledVehiclesGroupedByStorageCapacity();
    actualResult.map((p: IUnscheduledVehiclesByStorageCapacity[]) => {
      if (p && p.length > 0) {
        this.allUnScheduledVehicle = p;
        this.unScheduledVehicle = p[0];
        this.canvas = document.querySelector('canvas#unScheduledVehicleCanvas');
        this.ctx = this.canvas.getContext('2d');

        let dataGroups: any = [];

        let cost: number = 0;
        this.allUnScheduledVehicle.forEach(
          (availableUnScheduledVehicle: IUnscheduledVehiclesByStorageCapacity, index: number, elements) => {
            let unScheduledVehs = elements.filter((q: IUnscheduledVehiclesByStorageCapacity) => {
              q.vehicleCategoryName == this.unScheduledVehicle.vehicleCategoryName
                && q.companyName == this.unScheduledVehicle.companyName;
            });
            cost += availableUnScheduledVehicle.cost;
          });

        dataGroups.push(cost);
        let dataLabels: string[] = ["cost"];
        this.drawCharts(dataGroups, dataLabels);
      }
      else {
        this.allUnScheduledVehicle = [];
      }
    }).subscribe();
    $('div#unScheduledVehicleWithCapacity').css('display', 'block').slideDown();
  }

  drawCharts(dataGroups:any, dataLabels:string[]): void {

    if (this.unScheduledVehiclesChart) this.unScheduledVehiclesChart.destroy();
    this.unScheduledVehiclesChart = new Chart(this.ctx, {
      type: 'bar',
      data: {
        labels: dataLabels,
        datasets: [{
          label: this.unScheduledVehicle.companyName + ", " + this.unScheduledVehicle.vehicleCategoryName,
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

  drawSelectedChartData(dataLabels: string[]): void {

    if (this.unScheduledVehiclesChart) this.unScheduledVehiclesChart.destroy();
      this.unScheduledVehiclesChart = new Chart(this.ctx, {
      type: 'bar',
      data: {
        labels: dataLabels,
        datasets: [{
          label: this.unScheduledVehicle.companyName + ", " + this.unScheduledVehicle.vehicleCategoryName,
          data: [this.unScheduledVehicle.cost],
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
