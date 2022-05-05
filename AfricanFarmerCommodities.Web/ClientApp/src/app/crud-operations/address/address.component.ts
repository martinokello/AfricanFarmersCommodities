import { Component, OnInit, Injectable,AfterContentInit } from '@angular/core';
import { IAddress,AfricanFarmerCommoditiesService } from '../../../services/africanFarmerCommoditiesService';
import * as $ from 'jquery';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';

@Component({
    selector: 'address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.css'],
    providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class AddressComponent implements OnInit, AfterContentInit {
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router:Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
    }
  ngAfterContentInit(): void {
    let optionElem = document.createElement('option');
    optionElem.selected = true;
    optionElem.value = (0).toString();
    optionElem.text = "Select Address";
    document.querySelector('select#addressId').append(optionElem);


    let addressesObs: Observable<IAddress[]> = this.africanFarmerCommoditiesService.GetAllAddresses();
    addressesObs.map((adds: IAddress[]) => {
      adds.forEach((add: IAddress, index: number, adds)=>{
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = add.addressId.toString();
        optionElem.text = add.addressLine1 + ", " + add.town+", "+add.postCode;
        document.querySelector('select#addressId').append(optionElem);
      });
    }).subscribe();

    }
    public address: IAddress | any;

    public addAddress(): void {
      let actualResult: Observable<any> = this.africanFarmerCommoditiesService.PostOrCreateAddress(this.address);
      actualResult.map((p: any) => {
        alert('Address Added: ' + p.result);
        if (p.result) {
          this.router.navigateByUrl('success');
        }
        else {
          this.router.navigateByUrl('failure');
        }
        }).subscribe();
        $('form#locationView').css('display', 'block').slideDown();
    }
    public updateAddress() {
      let actualResult: Observable<any> = this.africanFarmerCommoditiesService.UpdateAddress(this.address);
      actualResult.map((p: any) => {
        alert('Address Updated: ' + p.result);
        if (p.result) {
          this.router.navigateByUrl('success');
        }
        else {
          this.router.navigateByUrl('failure');
        }
        }).subscribe();
        $('form#locationView').css('display', 'block').slideDown();
  }
  public selectAddress(): void {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.GetAddressById(this.address.addressId);
    actualResult.map((p: any) => {
      this.address = p;
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public deleteAddress() {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.DeleteAddress(this.address);
    actualResult.map((p: any) => {
      alert('Address Deleted: ' + p.result);
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
        this.address = {}
    }
}
