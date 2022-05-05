import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter, AfterContentInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IFarmer,IAddress, ILocation, AfricanFarmerCommoditiesService, ICompany } from '../../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
import * as $ from 'jquery';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';

@Component({
    selector: 'farmer',
  templateUrl: './farmer.component.html',
  styleUrls: ['./farmer.component.css'],
    providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class FarmerComponent implements OnInit, AfterContentInit {
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
    }
  public farmer: IFarmer | any;

  public addFarmer(): void {
    this.farmer.addressId = this.farmer.address.addressId;
    this.farmer.companyId = this.farmer.company.companyId;
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.PostOrCreateFarmer(this.farmer);
    actualResult.map((p: any) => {
      alert('Farmer Added: ' + p.result); if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public updateFarmer() {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.UpdateFarmer(this.farmer);
    actualResult.map((p: any) => {
      alert('Farmer Updated: ' + p.result); if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public selectFarmer(): void {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.GetFarmerById(this.farmer.farmerId);
    actualResult.map((p: any) => {
      this.farmer = p;
      this.farmer.company = { companyId: p.companyId };
      this.farmer.address = { addressId : p.addressId };
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public deleteFarmer() {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.DeleteFarmer(this.farmer);
    actualResult.map((p: any) => {
      alert('Farmer Deleted: ' + p.result); if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public ngOnInit(): void {
    this.farmer = {
      farmerId: 0,
      company: { companyId: 0 },
      address: {addressId:0},
      farmerName: ""
    }
  }
  ngAfterContentInit(): void {

    let optionElem: HTMLOptionElement = document.createElement('option');
    optionElem.selected = true;
    optionElem.value = (0).toString();
    optionElem.text = "Select Farmer";
    document.querySelector('select#farmerId').append(optionElem);


    optionElem = document.createElement('option');
    optionElem.value = (0).toString();
    optionElem.text = "Select Address";
    document.querySelector('select#frmaddressId').append(optionElem);

    optionElem = document.createElement('option');
    optionElem.value = (0).toString();
    optionElem.text = "Select Company";
    document.querySelector('select#frmcompanyId').append(optionElem);

    const farmersObs: Observable<IFarmer[]> = this.africanFarmerCommoditiesService.GetAllFamers();
    const addressObs: Observable<IAddress[]> = this.africanFarmerCommoditiesService.GetAllAddresses();
    const compObs: Observable<ICompany[]> = this.africanFarmerCommoditiesService.GetAllCompanies();
	
    farmersObs.map((cmds: IFarmer[]) => {
      cmds.forEach((cmd: IFarmer, index: number, cmds) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = cmd.farmerId.toString();
        optionElem.text = cmd.farmerName;
        document.querySelector('select#farmerId').append(optionElem);
      });
    }).subscribe();

    addressObs.map((cmdCats: IAddress[]) => {
      cmdCats.forEach((comCat: IAddress, index: number, cmdCats) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = comCat.addressId.toString();
        optionElem.text = comCat.addressLine1 + ", " + comCat.town + ", " + comCat.postCode;
        document.querySelector('select#frmaddressId').append(optionElem);
      });
    }).subscribe();

    compObs.map((cmdUnits: ICompany[]) => {
      cmdUnits.forEach((cmdUnit: ICompany, index: number, cmdUnits) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = cmdUnit.companyId.toString();
        optionElem.text = cmdUnit.companyName;
        document.querySelector('select#frmcompanyId').append(optionElem);
      });
    }).subscribe();
  }
}
