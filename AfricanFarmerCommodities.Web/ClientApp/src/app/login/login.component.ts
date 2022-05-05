import { Component, OnInit, ViewChild, ElementRef, Injectable, AfterViewInit, AfterViewChecked, Inject, Output, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { AfricanFarmerCommoditiesService, ILogInStatus, IUserDetail, IUserStatus } from '../../services/africanFarmerCommoditiesService';
import 'rxjs/add/operator/map';
import * as $ from 'jquery';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class LoginComponent implements OnInit {
  userRoles: string[] = [];
  public userDetail: IUserDetail | any;
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService | any;
  private router: Router;
  actUserStatus: IUserStatus = {
    isUserAdministrator: false,
    isUserLoggedIn: false
  }
  ngOnInit(): void {

    let userDetail: IUserDetail = {
      password: "",
      role: "",
      emailAddress: "",
      username: "",
      mobileNumber: "",
      repassword: "",
      firstName: "",
      lastName: "",
      keepLoggedIn: false,
      authToken: ""
    };
    this.userDetail = userDetail;
  }
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
    this.router = router;
  }

  public loginUser(): void {

    localStorage.setItem("userRoles", '');
    sessionStorage.removeItem("Orders");

    this.userDetail.authToken = localStorage.getItem('authToken');
    this.userDetail.username = this.userDetail.emailAddress;
    let loginResults: Observable<any> = this.africanFarmerCommoditiesService.LoginByPost(this.userDetail);
    loginResults.map((q: any) => {
      console.log(q.toString());
      if (q.isLoggedIn === true) {
        localStorage.setItem("userDetails", this.userDetail);
        AfricanFarmerCommoditiesService.userDetails = this.userDetail;

        if (q.authToken) {
          localStorage.setItem('authToken', q.authToken);
        }
        this.actUserStatus.isUserLoggedIn = AfricanFarmerCommoditiesService.actUserStatus.isUserLoggedIn = true;
        if (q.isAdministrator) {
          this.actUserStatus.isUserAdministrator = AfricanFarmerCommoditiesService.actUserStatus.isUserAdministrator = true;
        }

        localStorage.setItem("actUserStatus", JSON.stringify(this.actUserStatus));
        $('span#loginName').css('display', 'block');
        $('span#loginName').text("logged in as: " + this.userDetail.emailAddress);
        AfricanFarmerCommoditiesService.isLoginPage = false;
        AfricanFarmerCommoditiesService.SetUserEmail(this.userDetail.emailAddress);
        this.ensureUserRolesGot();
        this.router.navigateByUrl("/scanqrcode");
      }
      else {
        $('span#loginName').css('display', 'none');
        $('span#loginName').text("");
        alert('Login Failed. Unknown User');
        this.actUserStatus.isUserLoggedIn = AfricanFarmerCommoditiesService.actUserStatus.isUserLoggedIn = false;
        this.actUserStatus.isUserAdministrator = AfricanFarmerCommoditiesService.actUserStatus.isUserAdministrator = false;

        AfricanFarmerCommoditiesService.SetUserEmail('');
        localStorage.removeItem("actUserStatus");
        localStorage.removeItem('authToken');
        localStorage.removeItem("userRoles");
      }
    }).subscribe();
  }

  public ensureUserRolesGot(): void {
    let userRolesStr = localStorage.getItem("userRoles");
    if (userRolesStr != null && userRolesStr.length > 0) {
      this.userRoles = JSON.parse(userRolesStr);
      AfricanFarmerCommoditiesService.userRoles = this.userRoles;
      localStorage.setItem("userRoles", JSON.stringify(this.userRoles));
    }
    if (this.userRoles == null || this.userRoles.length < 1) {
      this.africanFarmerCommoditiesService.GetAllUserRoles(AfricanFarmerCommoditiesService.clientEmailAddress).
        map((userroles: string[]) => {
          localStorage.setItem("userRoles", JSON.stringify(userroles));
          AfricanFarmerCommoditiesService.userRoles = userroles;
        }).subscribe();
    }
  }
}
