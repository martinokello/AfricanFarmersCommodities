import { Component, OnInit, Injectable, Inject, AfterContentInit } from '@angular/core';
import { IVehicleCapacity, AfricanFarmerCommoditiesService } from '../../../services/africanFarmerCommoditiesService';
import * as $ from 'jquery';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';

@Component({
    selector: 'vehicle-capacity',
    templateUrl: './vehicleCapacity.component.html',
    styleUrls: ['./vehicleCapacity.component.css'],
    providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class VehicleCapacityComponent implements OnInit, AfterContentInit {
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;

  public vehicleCapacity: IVehicleCapacity;
  
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
  }

  public addVehicleCapacity(): void {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.PostOrCreateVehicleCapacity(this.vehicleCapacity);
    actualResult.map((p: any) => {
      alert('Vehicle Added: ' + p.result);
      if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public updateVehicleCapacity() {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.UpdateVehicleCapacity(this.vehicleCapacity);
    actualResult.map((p: any) => {
      alert('Vehicle Updated: ' + p.result);
      if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public selectVehicleCapacity(): void {
    let actualResult: Observable<IVehicleCapacity> = this.africanFarmerCommoditiesService.GetVehicleCapacityById(this.vehicleCapacity.vehicleCapacityId);
    actualResult.map((p: IVehicleCapacity) => {
      this.vehicleCapacity = p;
    }).subscribe();
  }
  public deleteVehicleCapacity():void {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.DeleteVehicleCapacity(this.vehicleCapacity);
    actualResult.map((p: any) => {
      alert('Vehicle Deleted: ' + p.result);
      if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
  }
  public ngOnInit(): void {
    this.vehicleCapacity = {
      vehicleCapacityId: 0,
      vechicleCapacityUnitsName: '',
      vechicleCapacity: 0,
      description: ''
    };
  }
  ngAfterContentInit(): void {
    const vehsObs: Observable<IVehicleCapacity[]> = this.africanFarmerCommoditiesService.GetAllVehicleCapacities();


    let optionElem: HTMLOptionElement = document.createElement('option');
    optionElem.value = (0).toString();
    optionElem.text = "Select Vehicle Capacity";
    document.querySelector('select#vehicleCapacityId').append(optionElem);

    vehsObs.map((cmds: IVehicleCapacity[]) => {
      cmds.forEach((cmd: IVehicleCapacity, index: number, cmds) => {
      let optionElem2: HTMLOptionElement = document.createElement('option');
        optionElem2.value = cmd.vehicleCapacityId.toString();
        optionElem2.text = cmd.vechicleCapacityUnitsName;
        document.querySelector('select#vehicleCapacityId').append(optionElem2);
      });
    }).subscribe();
  }
}
