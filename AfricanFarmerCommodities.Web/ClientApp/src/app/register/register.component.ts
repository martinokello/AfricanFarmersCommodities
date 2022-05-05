import { Component, OnInit, ViewChild, ElementRef, Injectable, AfterViewInit, AfterViewChecked, Inject } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import * as $ from "jquery";
import 'rxjs/add/operator/map';
import { AfricanFarmerCommoditiesService, ILogInStatus, IUserDetail, IVehicle } from '../../services/africanFarmerCommoditiesService';
import { Router } from '@angular/router';
@Component({
    selector: 'register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css'],
  providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class RegisterComponent implements OnInit{
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
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router:Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
    }
  public registerUser(): void {

    this.userDetail.username = this.userDetail.emailAddress;
      let registeResults: Observable<ILogInStatus> = this.africanFarmerCommoditiesService.registerByPost(this.userDetail);

      registeResults.map((q: ILogInStatus) => {
            if (q.isRegistered) {
              alert('Registration Successfull: ' + q.isRegistered);
              this.router.navigateByUrl("/login");
            }
            else {
                alert('Failed to Register user. Please contact the Site Administrator')
            }
        }).subscribe();

    }
}
