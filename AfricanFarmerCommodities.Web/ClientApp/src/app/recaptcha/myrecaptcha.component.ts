import { Component, OnInit, Inject, AfterContentInit, AfterViewChecked } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AfricanFarmerCommoditiesService } from '../../services/africanFarmerCommoditiesService';
import { Observable } from 'rxjs';
import * as $ from 'jquery';
import { Router } from '@angular/router';
import { AfterViewInit } from '@angular/core';
import * as Recaptcha  from 'ng-recaptcha';


@Component({
    selector: 'myrecaptcha',
    templateUrl: './myrecaptcha.component.html',
  providers: [HttpClient, AfricanFarmerCommoditiesService]
})
export class myRecaptchaComponent implements OnInit, AfterViewInit {

    //private siteKey = "6Lf2450iAAAAAEviEkx3ED-JWZgMU7hfSyZ_RZFu";
    //private recaptchaSecretKey ='6Lf2450iAAAAAHfNolJ4SwXMy4i91dStnQNRyEKr';
    private googleUrl = "https://www.google.com/recaptcha/api/siteverify";
    private isRecaptchaVerified: boolean;
    private showContent: boolean;
    private siteKey = "6LefGaEiAAAAAH4l4gFiF-yPQRWT95VOsh9h4eT4"; 
    private recaptchaSecretKey = "6LefGaEiAAAAADFfUHW1989eOhM3MAeRRP0SY4BB";

    constructor(private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router, private httpClient: HttpClient) {
        
    }
    ngAfterViewInit(): void {
        this.isRecaptchaVerified = false;
        if (this.isUrlValidForRecaptcha()) {

            $('input[type="submit"]#submit').css('display', 'none');
            $('input[type="submit"].oneRowRegButton').css('display', 'none');

        }
    }

    private CallRecaptureVerify(dataStr:string): void {

      let promObs: Promise<any> = this.africanFarmerCommoditiesService.PostToRecaptchaVerify(this.googleUrl, dataStr);
        promObs.then((q: any) => {
            debugger;
            this.isRecaptchaVerified = true;
            $('input[type="submit"]#submit').css('display', 'block');
        }).catch((reason: any) => {
            $('input[type="submit"]#submit').css('display', 'block');
        });

    }
    private validateResponse(responseResult: any): void {
        //debugger;
        document.querySelector('input[type="submit"]#submit').setAttribute('style','display:block !important;')
        /*
        var dataResp = {
            response: responseResult,
            secret: this.recaptchaSecretKey,
        };
        var dataStr = JSON.stringify(dataResp);

        console.log(dataStr);
        this.CallRecaptureVerify(dataStr);
        */
    }
    private isUrlValidForRecaptcha(): boolean {

        return window.location.href.toLowerCase().indexOf('/login') > -1 ||
            window.location.href.toLowerCase().indexOf('/register') > -1 ||
            window.location.href.toLowerCase().indexOf('/contactus') > -1;
    }
	private verifyTextbox(e): boolean {
    $('input[type="submit"]#submit').css('display', 'block');
    return true;
    }
    decoderUrl(url: string): string {
        return decodeURIComponent(url);
    }

    ngOnInit(): void {
        debugger;
        grecaptcha.render(document.querySelector('div#layooRecaptcha') as HTMLElement, {
            sitekey: this.siteKey,
            callback: this.validateResponse,
            theme: 'light'
        });
    }
}

