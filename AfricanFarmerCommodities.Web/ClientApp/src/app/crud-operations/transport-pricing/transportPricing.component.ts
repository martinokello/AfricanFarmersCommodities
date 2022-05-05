import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter, AfterContentInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ITransportPricing,IAddress, ILocation, AfricanFarmerCommoditiesService, ITransportSchedule } from '../../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
import * as $ from 'jquery';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';

@Component({
    selector: 'transport-pricing',
    templateUrl: './transportPricing.component.html',
  styleUrls: ['./transportPricing.component.css'],
    providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class TransportPricingComponent implements OnInit, AfterContentInit {
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
    }
  public transportPricing: ITransportPricing | any;

  public addTransportPricing(): void {
    this.transportPricing.transportPricingId = 0;
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.PostOrCreateTransportPricing(this.transportPricing);
    actualResult.map((p: any) => {
      alert('TransportPricing Added: ' + p.result);
      if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public updateTransportPricing() {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.UpdateTransportPricing(this.transportPricing);
    actualResult.map((p: any) => {
      alert('TransportPricing Updated: ' + p.result);
      if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public selectTransportPricing(): void {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.GetTransportPricingById(this.transportPricing.transportPricingId);
    actualResult.map((p: any) => {
      this.transportPricing = p;
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public deleteTransportPricing() {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.DeleteTransportPricing(this.transportPricing);
    actualResult.map((p: any) => {
      alert('TransportPricing Deleted: ' + p.result);
      if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public ngOnInit(): void {
    this.transportPricing = {};
  }
  ngAfterContentInit(): void {
    const addsObs: Observable<ITransportPricing[]> = this.africanFarmerCommoditiesService.GetAllTransportPricings();

    let optionElem: HTMLOptionElement = document.createElement('option');
    optionElem.selected = true;
    optionElem.value = (0).toString();
    optionElem.text = "Select Transport Pricing";
    document.querySelector('select#transportPricingId').append(optionElem);

    addsObs.map((cmds: ITransportPricing[]) => {
      cmds.forEach((cmd: ITransportPricing, index: number, cmds) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = cmd.transportPricingId.toString();
        optionElem.text = cmd.transportPricingName;
        document.querySelector('select#transportPricingId').append(optionElem);
      });
    }).subscribe();

  }
}
