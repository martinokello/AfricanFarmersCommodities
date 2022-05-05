import { Component, OnInit, ViewChild, ElementRef, Injectable } from '@angular/core';
import { AfricanFarmerCommoditiesService, IEmailMessage } from '../../services/africanFarmerCommoditiesService';
import * as $ from "jquery";

@Component({
    selector: 'sections-contact',
    templateUrl: './sectionscontact.component.html',
    styleUrls: ['./sectionscontact.component.css'],
  providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class SectionsContactComponent implements OnInit {
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService | any;
    email: IEmailMessage | any;

  @ViewChild('emailFormView', { static: false }) emailFormView: HTMLElement | any; 
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService) {

    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
    }
    sendEmail(): void {

        let formView = this.emailFormView;
        let form = formView.nativeElement.querySelector("form");
        if (form.checkValidity())
        form.submit();
    }
    getFiles(event) {
        this.email.attachment = event.target.files;
    } 
    ngOnInit() {
        this.email = {
            emailBody: "",
            attachment: null,
            emailSubject: "",
            emailTo: "",
            emailFrom: ""
        }
        
        $(document).ready(function () {
           
            $('input[type="text"]').focus(function () {
                $(this).val("");
            });
        });
    }
}
