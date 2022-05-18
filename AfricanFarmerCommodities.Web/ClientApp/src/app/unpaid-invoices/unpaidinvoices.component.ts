import { Component, OnInit, ViewChild, ElementRef, Input, Injectable, EventEmitter, Output } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { AfricanFarmerCommoditiesService, IInvoice, IUserDetail } from '../../services/africanFarmerCommoditiesService';
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
  public amountLeftToPay: number;
  public unpaidInvoices: IInvoice[];
  public userDetails: IUserDetail;

  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
  }
  public makePayment(event): void {

    let form = $(event.target).parents('form')

    console.log(form.attr('id'));
    let invoiceId: any = $(form).find('input[name="invoiceId"]').val();
    let userId: any = $(form).find('input[name="userId"]').val();
    let grossCost: any = $(form).find('input[name="grossCost"]').val();

    let invoice: IInvoice = {
      invoiceId: parseInt(invoiceId),
      userId: userId,
      grossCost: parseFloat(grossCost),
      netCost: parseFloat(grossCost),
      invoiceName: `LatePayments ${invoiceId}`,
      dateCreated: new Date(),
      dateUpdated: new Date(),
      percentTaxAppliable: 0
    };

    let result: Observable<any> = this.africanFarmerCommoditiesService.MakeLatePayment(invoice, this.userDetails.emailAddress);

    result.map((q: any) => {
      if (q.payPalRedirectUrl) {
        window.open(q.payPalRedirectUrl);
      }
      console.log('Response received');
      alert("Payment made. Currently being processed by paypal service");
    }).subscribe();
    event.preventDefault();
  }

  public ngOnInit(): void {
    this.currentPayment = 0.00;
    this.userDetails = JSON.parse(localStorage.getItem("userDetails"));
    let result: Observable<IInvoice[]> = this.africanFarmerCommoditiesService.GetUnpaidInvoices(this.userDetails.emailAddress);
    this.amountLeftToPay = 0.0;

    result.map((resp: IInvoice[]) => {
      this.unpaidInvoices = resp;
      this.unpaidInvoices.forEach((invoice: IInvoice) => {
        this.amountLeftToPay += invoice.grossCost;
      });
    }).subscribe();
  }
}
