import { Component, OnInit, Injectable, AfterContentInit, AfterViewChecked } from '@angular/core';
import { IAddress,AfricanFarmerCommoditiesService } from '../../../services/africanFarmerCommoditiesService';
declare var jQuery: any;
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
export class AddressComponent implements OnInit, AfterContentInit, AfterViewChecked {
  hasPopulatedPage: boolean = false;
  setTo: NodeJS.Timeout;
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
        jQuery('form#locationView').css('display', 'block').slideDown();
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
        jQuery('form#locationView').css('display', 'block').slideDown();
  }
  public selectAddress(): void {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.GetAddressById(this.address.addressId);
    actualResult.map((p: any) => {
      this.address = p;
    }).subscribe();
    jQuery('form#locationView').css('display', 'block').slideDown();
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
    jQuery('form#locationView').css('display', 'block').slideDown();
  }
    public ngOnInit(): void {
        this.address = {}
  }
  ngAfterViewChecked() {
    let curthis = this;

    this.setTo = setTimeout(this.runAutoCompleteOnSelects, 1000, curthis);

  }
  runAutoCompleteOnSelects(curthis: any) {
    let hasFoundSelectsOnPage = false;

    if (!curthis.hasPopulatedPage) {

      let selects = jQuery('div#client-wrapper-address select');

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
