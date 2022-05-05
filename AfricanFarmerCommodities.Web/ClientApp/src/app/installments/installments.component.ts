import { Component, OnInit, ViewChild, ElementRef, Input, Injectable, EventEmitter, Output } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { AfricanFarmerCommoditiesService } from '../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
import * as $ from 'jquery';
import 'rxjs/add/operator/map';
@Component({
    selector: 'installment-payments',
    templateUrl: './installments.component.html',
    styleUrls: ['./installments.component.css'],
  providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class PayByInstallmentsComponent implements OnInit {
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService | any;
  @ViewChild("paymentsForm", { static: false }) paymentsForm: HTMLElement | any;
    public currentPayment: number | any;
    public amountLeftToPay: number | any;
    public tourClient: any;
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
    }
    public makePayment(): void {
      let result: Observable<any> = this.africanFarmerCommoditiesService.MakePayment(this.currentPayment, AfricanFarmerCommoditiesService.clientEmailAddress);

        result.map((q: any) => {
            window.open(q.payPalRedirectUrl);
            console.log('Response received');
            console.log(q);
            alert("Payment made. Currently being processed by paypal service");
        }).subscribe();
    }
  
    public ngOnInit(): void {
        this.tourClient = {};
        this.currentPayment = 0.00;

      let result: Observable<any> = this.africanFarmerCommoditiesService.GetTourClientByEmail(AfricanFarmerCommoditiesService.clientEmailAddress);

        result.map((resp: any) => {
            this.tourClient = resp;
            var balance = this.tourClient.grossTotalCosts - this.tourClient.paidInstallments;
            this.amountLeftToPay = balance.toFixed(2);
        }).subscribe();
    }
}
