import { Component,AfterContentInit, ViewChild, ElementRef, Input, Output, EventEmitter, OnInit, AfterViewInit } from '@angular/core';
import { Element } from '@angular/compiler';
import { Observable } from 'rxjs/Observable';
import { AfricanFarmerCommoditiesService, IUserStatus, IUserDetail } from '../../services/africanFarmerCommoditiesService';
import 'rxjs/add/operator/map';
import * as $ from 'jquery';
import { Router, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements AfterContentInit,AfterViewInit {

  @Input("actUserStatus") actUserStatus: IUserStatus = {
    isUserLoggedIn: false,
    isUserAdministrator: false
  };
  public userRoles: string[];

  public africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
    this.router.events.filter(event => event instanceof NavigationEnd).subscribe((val: any) => { this.myInit(); });
  }

  ngAfterContentInit(): void {
    this.myInit();
  }

  ngAfterViewInit(): void {
    this.myInit();
  }
  myInit(): void {
    this.verifyLoggedInUser();
  }
  verifyLoggedInUser(): void {
    this.actUserStatus.isUserLoggedIn = AfricanFarmerCommoditiesService.actUserStatus.isUserLoggedIn;
    this.actUserStatus.isUserAdministrator = AfricanFarmerCommoditiesService.actUserStatus.isUserAdministrator;
    if (!this.actUserStatus.isUserLoggedIn) {

      let verifyResult: Observable<any> = this.africanFarmerCommoditiesService.VerifyLoggedInUser();
      verifyResult.map((p: any) => {
        if (p.isLoggedIn) {
          $('span#loginName').css('display', 'block');
          $('span#loginName').text("logged in as: " + p.name);
          AfricanFarmerCommoditiesService.SetUserEmail(p.name);
          AfricanFarmerCommoditiesService.actUserStatus.isUserLoggedIn = this.actUserStatus.isUserLoggedIn = true;
          if (p.isAdministrator) {
            AfricanFarmerCommoditiesService.actUserStatus.isUserAdministrator = this.actUserStatus.isUserAdministrator = true;
          }
          localStorage.removeItem("actUserStatus");
          localStorage.setItem("actUserStatus", JSON.stringify(this.actUserStatus));

          this.ensureUserRolesGot();
        }
        else {
          AfricanFarmerCommoditiesService.actUserStatus.isUserLoggedIn = this.actUserStatus.isUserLoggedIn = false;
          AfricanFarmerCommoditiesService.actUserStatus.isUserAdministrator = this.actUserStatus.isUserAdministrator = false;

          localStorage.removeItem("userRoles");
          localStorage.removeItem("actUserStatus");
          localStorage.removeItem('authToken');
          $('span#loginName').css('display', 'none');
        }
      }).subscribe();
    }

    this.ensureUserRolesGot();
  }
  makePayments(): void {
  }
  setIsLogInPage(): void {
    AfricanFarmerCommoditiesService.isLoginPage = true;
    this.logOut();
  }
  logOut(): void {
    localStorage.removeItem('authToken');
    localStorage.removeItem("userDetails");
    localStorage.removeItem("userRoles");
    localStorage.removeItem("Orders");
    this.userRoles = null;

    this.actUserStatus.isUserLoggedIn = AfricanFarmerCommoditiesService.actUserStatus.isUserLoggedIn = false;
    this.actUserStatus.isUserAdministrator = AfricanFarmerCommoditiesService.actUserStatus.isUserAdministrator = false;
    AfricanFarmerCommoditiesService.SetUserEmail('');
    let logOutResult: Observable<any> = this.africanFarmerCommoditiesService.LogOut();
    logOutResult.map((p: any) => {

      $('span#loginName').css('display', 'none');
      localStorage.removeItem("userRoles");
      localStorage.removeItem("actUserStatus");
      this.actUserStatus.isUserLoggedIn = false;
      this.actUserStatus.isUserAdministrator = false;

    }).subscribe();

  }

  public ensureUserRolesGot(): void {
    if (this.actUserStatus.isUserLoggedIn) {
      let userRolesStr = localStorage.getItem("userRoles");
      if (userRolesStr != null && userRolesStr.length > 0) {
        this.userRoles = AfricanFarmerCommoditiesService.userRoles = JSON.parse(userRolesStr);
        localStorage.setItem("userRoles", JSON.stringify(AfricanFarmerCommoditiesService.userRoles));
        return;
      }
      if (this.userRoles == null || this.userRoles.length < 1) {
        this.africanFarmerCommoditiesService.GetAllUserRoles(AfricanFarmerCommoditiesService.clientEmailAddress).
          map((userroles: string[]) => {
            localStorage.setItem("userRoles", JSON.stringify(userroles));
            this.userRoles = AfricanFarmerCommoditiesService.userRoles =  userroles;
          }).subscribe();
      }
    }

  }
}
