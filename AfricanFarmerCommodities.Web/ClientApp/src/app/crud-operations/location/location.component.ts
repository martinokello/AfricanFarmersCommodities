import { Component, OnInit, Injectable, Inject, AfterContentInit, AfterViewChecked } from '@angular/core';
import { IAddress, ILocation, AfricanFarmerCommoditiesService } from '../../../services/africanFarmerCommoditiesService';
declare var jQuery: any;
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';

@Component({
    selector: 'location',
    templateUrl: './location.component.html',
    styleUrls: ['./location.component.css'],
    providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class LocationComponent implements OnInit, AfterContentInit, AfterViewChecked {
  hasPopulatedPage: boolean = false;
  setTo: NodeJS.Timeout;
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
    }
    public location: ILocation | any;

  public addLocation(): void {
    this.location.address = null;
      let actualResult: Observable<any> = this.africanFarmerCommoditiesService.PostOrCreateLocation(this.location);
      actualResult.map((p: any) => {
        alert('Location Added: ' + p.result); if (p.result) {
          this.router.navigateByUrl('success');
        }
        else {
          this.router.navigateByUrl('failure');
        }
        }).subscribe();
        jQuery('form#locationView').css('display', 'block').slideDown();
    }
    public updateLocation() {
      let actualResult: Observable<any> = this.africanFarmerCommoditiesService.UpdateLocation(this.location);
      actualResult.map((p: any) => {
        alert('Location Updated: ' + p.result); if (p.result) {
          this.router.navigateByUrl('success');
        }
        else {
          this.router.navigateByUrl('failure');
        }
        }).subscribe();
        jQuery('form#locationView').css('display', 'block').slideDown();
  }
  public selectLocation(): void {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.GetLocationById(this.location.locationId);
    actualResult.map((p: any) => {
      this.location = p; 
    }).subscribe();
    jQuery('form#locationView').css('display', 'block').slideDown();
  }
  public deleteLocation() {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.DeleteLocation(this.location);
    actualResult.map((p: any) => {
      alert('Location Deleted: ' + p.result); if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    jQuery('form#locationView').css('display', 'block').slideDown();
  }
    public ngOnInit(): void {
        this.location = {}
        this.location.address = {};
  }
  ngAfterContentInit(): void {
    const addsObs: Observable<IAddress[]> = this.africanFarmerCommoditiesService.GetAllAddresses();
    const locatObs: Observable<ILocation[]> = this.africanFarmerCommoditiesService.GetAllLocations();

    let optionElem: HTMLOptionElement = document.createElement('option');
    optionElem.selected = true;
    optionElem.value = (0).toString();
    optionElem.text = "Select Location";
    document.querySelector('select#locationId').append(optionElem);

    optionElem = document.createElement('option');
    optionElem.value = (0).toString();
    optionElem.text = "Select Address";
    document.querySelector('select#locaddressId').append(optionElem);

    addsObs.map((cmds: IAddress[]) => {
      cmds.forEach((cmd: IAddress, index: number, cmds) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = cmd.addressId.toString();
        optionElem.text = cmd.addressLine1 + ", " + cmd.town + ", " + cmd.postCode;
        document.querySelector('select#locaddressId').append(optionElem);
      });
    }).subscribe();

    locatObs.map((cmdCats: ILocation[]) => {
      cmdCats.forEach((comCat: ILocation, index: number, cmdCats) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = comCat.locationId.toString();
        optionElem.text = comCat.locationName;
        document.querySelector('select#locationId').append(optionElem);
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

      let selects = jQuery('div#client-wrapper-locations select');

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
