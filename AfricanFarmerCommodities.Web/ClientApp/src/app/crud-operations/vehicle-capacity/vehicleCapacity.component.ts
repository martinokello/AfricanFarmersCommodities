import { Component, OnInit, Injectable, Inject, AfterContentInit, AfterViewChecked } from '@angular/core';
import { IVehicleCapacity, AfricanFarmerCommoditiesService } from '../../../services/africanFarmerCommoditiesService';
declare var jQuery: any;
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';

@Component({
  selector: 'vehicle-capacity',
  templateUrl: './vehicleCapacity.component.html',
  styleUrls: ['./vehicleCapacity.component.css'],
  providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class VehicleCapacityComponent implements OnInit, AfterContentInit, AfterViewChecked {
  hasPopulatedPage: boolean = false;
  setTo: NodeJS.Timeout;
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;

  public vehicleCapacity: IVehicleCapacity;
  
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
  }

  public addVehicleCapacity(): void {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.PostOrCreateVehicleCapacity(this.vehicleCapacity);
    actualResult.map((p: any) => {
      alert('Vehicle Added: ' + p.result);
      if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    jQuery('form#locationView').css('display', 'block').slideDown();
  }
  public updateVehicleCapacity() {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.UpdateVehicleCapacity(this.vehicleCapacity);
    actualResult.map((p: any) => {
      alert('Vehicle Updated: ' + p.result);
      if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    jQuery('form#locationView').css('display', 'block').slideDown();
  }
  public selectVehicleCapacity(): void {
    let actualResult: Observable<IVehicleCapacity> = this.africanFarmerCommoditiesService.GetVehicleCapacityById(this.vehicleCapacity.vehicleCapacityId);
    actualResult.map((p: IVehicleCapacity) => {
      this.vehicleCapacity = p;
    }).subscribe();
  }
  public deleteVehicleCapacity():void {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.DeleteVehicleCapacity(this.vehicleCapacity);
    actualResult.map((p: any) => {
      alert('Vehicle Deleted: ' + p.result);
      if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
  }
  public ngOnInit(): void {
    this.vehicleCapacity = {
      vehicleCapacityId: 0,
      vechicleCapacityUnitsName: '',
      vechicleCapacity: 0,
      description: ''
    };
  }
  ngAfterContentInit(): void {
    const vehsObs: Observable<IVehicleCapacity[]> = this.africanFarmerCommoditiesService.GetAllVehicleCapacities();


    let optionElem: HTMLOptionElement = document.createElement('option');
    optionElem.value = (0).toString();
    optionElem.text = "Select Vehicle Capacity";
    document.querySelector('select#vehicleCapacityId').append(optionElem);

    vehsObs.map((cmds: IVehicleCapacity[]) => {
      cmds.forEach((cmd: IVehicleCapacity, index: number, cmds) => {
      let optionElem2: HTMLOptionElement = document.createElement('option');
        optionElem2.value = cmd.vehicleCapacityId.toString();
        optionElem2.text = cmd.vechicleCapacityUnitsName;
        document.querySelector('select#vehicleCapacityId').append(optionElem2);
      });
    }).subscribe();
  } ngAfterViewChecked() {
    let curthis = this;

    this.setTo = setTimeout(this.runAutoCompleteOnSelects, 1000, curthis);

  }
  runAutoCompleteOnSelects(curthis: any) {
    let hasFoundSelectsOnPage = false;

    if (!curthis.hasPopulatedPage) {

      let selects = jQuery('div#client-wrapper-vehcap select');

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
