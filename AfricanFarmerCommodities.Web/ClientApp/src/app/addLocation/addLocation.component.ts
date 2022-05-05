import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter } from '@angular/core';
import { IAddress, ILocation, AfricanFarmerCommoditiesService } from '../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
import * as $ from 'jquery';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Component({
    selector: 'addLocation',
    templateUrl: './addLocation.component.html',
    styleUrls: ['./addLocation.component.css'],
    providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class AddLocationComponent implements OnInit {
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
    }
    public location: ILocation | any;

    public addLocation(): void {
      let actualResult: Observable<any> = this.africanFarmerCommoditiesService.PostOrCreateLocation(this.location);
        actualResult.map((p: any) => {

            alert('Location Added: ' + p.result);
        }).subscribe();
        $('div#locationView').css('display', 'block').slideDown();
    }
    public updateLocation() {
      let actualResult: Observable<any> = this.africanFarmerCommoditiesService.UpdateLocation(this.location);
        actualResult.map((p: any) => {

            alert('Location Added: ' + p.result);
        }).subscribe();
        $('div#locationView').css('display', 'block').slideDown();
    }
    public ngOnInit(): void {
        this.location = {}
        this.location.address = {};
    }
}
