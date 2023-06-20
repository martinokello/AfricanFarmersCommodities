import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter, AfterContentInit, AfterViewChecked } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IFarmer,IAddress, ILocation, AfricanFarmerCommoditiesService, ICompany } from '../../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
declare var jQuery: any;
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
export class FarmerComponent implements OnInit, AfterContentInit, AfterViewChecked {
  hasPopulatedPage: boolean = false;
  setTo: NodeJS.Timeout;
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
    jQuery('form#locationView').css('display', 'block').slideDown();
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
    jQuery('form#locationView').css('display', 'block').slideDown();
  }
  public selectFarmer(): void {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.GetFarmerById(this.farmer.farmerId);
    actualResult.map((p: any) => {
      this.farmer = p;
      this.farmer.company = { companyId: p.companyId };
      this.farmer.address = { addressId : p.addressId };
    }).subscribe();
    jQuery('form#locationView').css('display', 'block').slideDown();
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
    jQuery('form#locationView').css('display', 'block').slideDown();
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

  ngAfterViewChecked() {
    let curthis = this;

    this.setTo = setTimeout(this.runAutoCompleteOnSelects, 1000, curthis);

  }
  runAutoCompleteOnSelects(curthis: any) {
    let hasFoundSelectsOnPage = false;

    if (!curthis.hasPopulatedPage) {

      let selects = jQuery('div#client-wrapper-farmer select');

      if (selects && selects.length > 0) {
        hasFoundSelectsOnPage = true;
      }

      if (hasFoundSelectsOnPage) {

        jQuery(selects.each((ind, elem) => {
          jQuery(elem).parent('ul').css('background', 'white');
          jQuery(elem).parent('ul').css('z-index', '100');
          let id = 'autoComplete' + jQuery(elem).attr('id');
          jQuery(elem).parent('div').prepend("<input type='text' placeholder='Search dropdown' id=" + `${id}` + " /><br/>");

        }));
        hasFoundSelectsOnPage = false;

      }
      //Check For Dom Change and Add auto complete to select elements
      debugger;
      jQuery('select').each((ind, sel) => {
        let options = jQuery(sel).children('option');

        let vals = [];
        jQuery(options).each((id, el) => {
          let optionText = jQuery(el).html();
          vals.push(optionText);
        });
        //options is source of auto complete:
        let jQueryinpId = jQuery('input#autoComplete' + jQuery(sel).attr('id'));
        jQueryinpId.autocomplete({ source: vals });
        jQuery(document).on('click', '.ui-menu .ui-menu-item-wrapper', function (event) {
          jQuery('select#' + jQuery(sel).attr('id')).find("option").filter(function () {
            return jQuery(event.target).text() == jQuery(this).html();
          }).attr("selected", true);
        });
      });

      curthis.hasPopulatedPage = true;
      clearTimeout(curthis.setTo);
    }
  }
}
