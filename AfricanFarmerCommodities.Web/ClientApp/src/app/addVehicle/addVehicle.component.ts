import { Component, OnInit, ViewChild, ElementRef, Injectable, AfterViewInit, AfterViewChecked, Inject } from '@angular/core';
import { IVehicle, AfricanFarmerCommoditiesService } from '../../services/africanFarmerCommoditiesService';
declare var jQuery: any;
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Component({
    selector: 'addVehicle',
    templateUrl: './addVehicle.component.html',
    styleUrls: ['./addVehicle.component.css'],
  providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class AddVehicleComponent implements OnInit, AfterViewInit, AfterViewChecked {
  hasPopulatedPage: boolean = false;
  public vehicle: IVehicle | any;
  setTo: NodeJS.Timeout;
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService | any;
  @ViewChild('vehicleItem', { static: false }) vehicleItem: HTMLElement | any; 

  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
    }
    public addVehicle(): void{
        //jQuery('div#vehicleView').css('display', 'block').slideDown();
      let actualResult: Observable<any> = this.africanFarmerCommoditiesService.PostOrCreateVehicle(this.vehicle);
        actualResult.map((p: any) => {

            alert('Vehicle Added: ' + p.result);
        }).subscribe();
    }
    public updateVehicle() {
      let actualResult: Observable<any> = this.africanFarmerCommoditiesService.UpdateVehicle(this.vehicle);
        actualResult.map((p: any) => {

            alert('Vehicle Added: ' + p.result);
        }).subscribe();

    }
    public ngOnInit(): void {
        this.vehicle = {};
        console.log("inside OnInit");
        let div = this.vehicleItem
        console.log(div);
        
        let select = div.nativeElement.querySelector("select");
        console.log(select);
      let items = this.africanFarmerCommoditiesService.GetVehicleTypeNames();

        jQuery(select).remove('option');
        jQuery(select).append('<option value="-1" selected="true">Select An Item Type</option>');
      for (let i = 0; i < items.length; i++) {
        jQuery(select).append('<option value="' + items[i].valueOf().toString() + '">' +"VehicleType[]"  + '</option>');
        }
    }
    ngAfterViewInit() {

    }
  ngAfterViewChecked() {
    let curthis = this;

    this.setTo = setTimeout(this.runAutoCompleteOnSelects, 1000, curthis);

  }
  runAutoCompleteOnSelects(curthis: any) {
    let hasFoundSelectsOnPage = false;

    if (!curthis.hasPopulatedPage) {

      let selects = jQuery('div#client-wrapper-addVehicle select');

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
