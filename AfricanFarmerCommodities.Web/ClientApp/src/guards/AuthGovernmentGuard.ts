import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AfricanFarmerCommoditiesService, IUserStatus } from '../services/africanFarmerCommoditiesService';


@Injectable()
export class AuthGovernmentGuard implements CanActivate {
  // Inject Router so we can hand off the user to the Login Page 
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService;
    userRoles: string[];
  // Inject Router so we can hand off the user to the Login Page 
  constructor(private router: Router, africanFarmerCommoditiesService: AfricanFarmerCommoditiesService) {
    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;
  }
  canActivate(): boolean {
    if (AfricanFarmerCommoditiesService.userRoles != null && AfricanFarmerCommoditiesService.userRoles.length > 0) {
      this.userRoles = AfricanFarmerCommoditiesService.userRoles;

      return this.userRoles.indexOf("Government") > -1;
    }
    return false;
  }
}
