import { Component, OnInit, ViewChild, ElementRef, Injectable, AfterViewInit, AfterViewChecked, Inject } from '@angular/core';
import { IVehicle, AfricanFarmerCommoditiesService, IUserDetail } from '../../services/africanFarmerCommoditiesService';
import * as $ from "jquery";
import 'rxjs/add/operator/map';
@Component({
    selector: 'forgotPassword',
    templateUrl: './forgotPassword.component.html',
    styleUrls: ['./forgotPassword.component.css'],
  providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class ForgotPasswordComponent implements OnInit{
    public userDetail: IUserDetail | any;
    private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService | any;
    ngOnInit(): void {
        let userDetail: IUserDetail = {
            password: "",
            role: "",
            emailAddress: "",
            username: "",
            mobileNumber:"",
            repassword: "",
            firstName: "",
            lastName: "",
            keepLoggedIn: false,
            authToken: ""
        };

        this.userDetail = userDetail;
    }
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
    }
  public forgotPassword(): void {
    this.userDetail.username = this.userDetail.emailAddress;
      this.africanFarmerCommoditiesService.forgotPasswordByPost(this.userDetail);
    }
}
