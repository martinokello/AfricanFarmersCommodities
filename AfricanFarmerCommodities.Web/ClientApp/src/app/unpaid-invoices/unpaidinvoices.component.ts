import { Component, OnInit, ViewChild, ElementRef, Input, Injectable, EventEmitter, Output } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { AfricanFarmerCommoditiesService, IInvoice } from '../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
import * as $ from 'jquery';
import 'rxjs/add/operator/map';
@Component({
  selector: 'unpaid-invoices',
  templateUrl: './unpaidinvoices.component.html',
  styleUrls: ['./unpaidinvoices.component.css'],
  providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class UnpaidInvoicesComponent implements OnInit {
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService | any;
  @ViewChild("paymentsForm", { static: false }) paymentsForm: HTMLElement | any;
    public currentPayment: number | any;
  public amountLeftToPay: number | any;
  public unpaidInvoices: IInvoice[];
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
    }
  public makePayment($event): void {
    let $form = $('form[name="' + $event.target.name + '"]');
    let invoice: IInvoice = {
      invoiceId: parseInt($form["invoiceId"]),
      userId: parseInt($form["userId"]),
      grossCost: parseFloat($form["amountLeftToPay"]),
      netCost: parseFloat($form["amountLeftToPay"]),
      invoiceName: `LatePayments${parseInt($form["invoiceId"])}`,
      dateCreated: new Date(),
      dateUpdated: new Date(),
      percentTaxAppliable: 0
    };

    let result: Observable<any> = this.africanFarmerCommoditiesService.MakeLatePayment(invoice, AfricanFarmerCommoditiesService.clientEmailAddress);

        result.map((q: any) => {
            window.open(q.payPalRedirectUrl);
            console.log('Response received');
            console.log(q);
            alert("Payment made. Currently being processed by paypal service");
        }).subscribe();
        $event.preventDefault();
    }
  
    public ngOnInit(): void {
        this.currentPayment = 0.00;

      let result: Observable<IInvoice[]> = this.africanFarmerCommoditiesService.GetUnpaidInvoices(AfricanFarmerCommoditiesService.clientEmailAddress);

      result.map((resp: IInvoice[]) => {
        this.unpaidInvoices = resp;
        this.unpaidInvoices.forEach((invoice: IInvoice) => {
            this.amountLeftToPay += invoice.grossCost;
          });
        }).subscribe();
    }
}
