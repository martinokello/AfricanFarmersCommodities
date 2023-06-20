import { Component, OnInit, ViewChild, ElementRef, Input, Output, Injectable, Inject, EventEmitter, AfterContentInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ICompany, IAddress, ILocation, AfricanFarmerCommoditiesService } from '../../../services/africanFarmerCommoditiesService';
import { Element } from '@angular/compiler';
declare var jQuery: any;
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';
import { AfterViewChecked } from '@angular/core';

@Component({
  selector: 'company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css'],
    providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class CompanyComponent implements OnInit, AfterContentInit, AfterViewChecked {
  hasPopulatedPage: boolean = false;
  setTo: NodeJS.Timeout;
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  public company: ICompany | any;
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router:Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
    }

  public addCompany(): void {
    this.company.location = null;
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.PostOrCreateCompany(this.company);
    actualResult.map((p: any) => {
      alert('Company Added: ' + p.result); if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    jQuery('form#locationView').css('display', 'block').slideDown();
  }
  public updateCompany() {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.UpdateCompany(this.company);
    actualResult.map((p: any) => {
      alert('Company Updated: ' + p.result); if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    jQuery('form#locationView').css('display', 'block').slideDown();
  }
  public selectCompany(): void {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.GetCompanyById(this.company.companyId);
    actualResult.map((p: any) => {
      this.company = p; 
    }).subscribe();
    jQuery('form#locationView').css('display', 'block').slideDown();
  }
  public deleteCompany() {
    let actualResult: Observable<any> = this.africanFarmerCommoditiesService.DeleteCompany(this.company);
    actualResult.map((p: any) => {
      alert('Company Deleted: ' + p.result);
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
    this.company = {}
  }
  ngAfterContentInit(): void {

    let optionElem: HTMLOptionElement = document.createElement('option');
    optionElem.selected = true;
    optionElem.value = (0).toString();
    optionElem.text = "Select Company";
    document.querySelector('select#companyId').append(optionElem);


    optionElem = document.createElement('option');
    optionElem.value = (0).toString();
    optionElem.text = "Select Location";
    document.querySelector('select#complocationId').append(optionElem);


    const companiesObs: Observable<ICompany[]> = this.africanFarmerCommoditiesService.GetAllCompanies();
    const locatObs: Observable<ILocation[]> = this.africanFarmerCommoditiesService.GetAllLocations();

    companiesObs.map((cmds: ICompany[]) => {
      cmds.forEach((cmd: ICompany, index: number, cmds) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = cmd.companyId.toString();
        optionElem.text = cmd.companyName;
        document.querySelector('select#companyId').append(optionElem);
      });
    }).subscribe();

    locatObs.map((cmdCats: ILocation[]) => {
      cmdCats.forEach((comCat: ILocation, index: number, cmdCats) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = comCat.locationId.toString();
        optionElem.text = comCat.locationName;
        document.querySelector('select#complocationId').append(optionElem);
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

      let selects = jQuery('div#client-wrapper-company select');

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
