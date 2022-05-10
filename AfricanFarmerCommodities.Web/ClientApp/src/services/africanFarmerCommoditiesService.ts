import { HttpClient, HttpHeaders } from '@angular/common/http';
import 'rxjs/add/operator/map';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Binary } from '@angular/compiler';
import 'rxjs/Rx';
import { APP_BASE_HREF } from '@angular/common';

@Injectable()
export class AfricanFarmerCommoditiesService {

  private baseServerUrl: string = /*"https://localhost:44387";*/  "https://africanfarmerscommodities.martinlayooinc.com";
  public static isLoginPage: boolean = false;
  public actionResult: any;
  public httpClient: HttpClient;
  public getAllRoles: string = this.baseServerUrl + "/Account/GetAllRoles";
  public getTwitterFeedsUrl: string = this.baseServerUrl + "/SocialMedia/TwitterProfileFeeds";
  public getCityLocationWeatherFocus: string = this.baseServerUrl + "/api/LocationWeather/GetLocationWeather";
  public postRemoveVehicleFromMonitorUrl: string = this.baseServerUrl + "/VehicleSchedules/RemoveVehicleFromMonitor";

  public createTransLogUrl: string = this.baseServerUrl + "/Home/CreateOrUpdateTransportScheduleLog";
  public deleteTransLogUrl: string = this.baseServerUrl + "/Home/DeleteTransportScheduleLog"
  public getDriverMobileLocationAppUrl: string = this.baseServerUrl + "/Transport/GetLocationEmitterApp";

  public getVehicleRealTimeLocations: string = this.baseServerUrl + "/VehicleSchedules/GetVehicleLocations";
  public getAllUserRoles: string = this.baseServerUrl + "/Account/GetAllUserRoles";
  public getUserInvoicedItems: string = this.baseServerUrl + "/Home/GetUserInvoicedItems";
  public createRoleUrl: string = this.baseServerUrl + "/Account/CreateRole";
  public deleteRoleUrl: string = this.baseServerUrl + "/Account/DeleteRole";
  public postRmoveUserFromRole: string = this.baseServerUrl + "/Account/RemoveUserFromRole";
  public postAddUserToRole: string = this.baseServerUrl + "/Account/AddUserToRole";
  public createTransportPricingUrl: string = this.baseServerUrl + "/Transport/PostOrCreateTransportPricing";
  public updateTransportPricingUrl: string = this.baseServerUrl + "/Transport/UpdateTransportPricing"
  public getTransportPricingById: string = this.baseServerUrl + "/Transport/GetTransportPricingById";
  public postCurrentPaymentUrl: string = this.baseServerUrl + "/Home/MakePayment";
  public schedulesPricingsUrl: string = this.baseServerUrl + "/Home/GetSchedulesPricing";
  public dealsPricingsUrl: string = this.baseServerUrl + "/Home/GetDealsPricing";
  public transportPricingsUrl: string = this.baseServerUrl + "/Home/GetTransportPricing";
  public postOrCreateSchedulesPricingUrl: string = this.baseServerUrl + "/Administration/PostSchedulesPricing";
  public updateSchedulesPricingUrl: string = this.baseServerUrl + "/Administration/UpdateSchedulesPricing";
  public postLoginUrl: string = this.baseServerUrl + "/Account/Login";
  public getVerifyLoggedInUser: string = this.baseServerUrl + "/Account/VerifyLoggedInUser";
  public getLogoutUrl: string = this.baseServerUrl + "/Account/Logout";
  public postRegisterUrl: string = this.baseServerUrl + "/Account/Register";
  public postForgotPasswordUrl: string = this.baseServerUrl + "/Account/ForgotPassword";
  public static clientEmailAddress = "";
  public postSendEmail: string = this.baseServerUrl + "/Home/SendEmail";
  public postVerifyQrcodeScan: string = this.baseServerUrl + "/Home/GetClientEmailAndMobilePhoneNumber";
  public getDriverTransportSchedulesUrl: string = "/Transport/GetDriverTransportSchedules"; 
  public getDriverScheduleNotesUrl: string = "/Transport/GetDriverScheduleNotes";

  public getallFoodHubStorageAvailabilityStorage: string = this.baseServerUrl + "/AdhocReporting/GetAllFoodHubCommoditiesStockStorageUsage";
  public getFoodHubStorageAvailabiliyStorageByFoodHubId: string = this.baseServerUrl + "/AdhocReporting/GetFoodHubCommoditiesStockStorageUsage";
  public getTop5DryCommoditiesInDemandRatingAccordingToStorageFacilities: string = this.baseServerUrl + "/AdhocReporting/GetTop5DryCommoditiesInDemandRatingAccordingToStorageFacilities";
  public getTop5RefreigeratedCommoditiesInDemandRatingAccordingToStorageFacilities: string = this.baseServerUrl + "/AdhocReporting/GetTop5RefreigeratedCommoditiesInDemandRatingAccordingToStorageFacilities";
  public getTop5FarmerCommoditiesUnitPricings: string = this.baseServerUrl + "/AdhocReporting/GetTop5FarmerCommoditiesDateAnalysisInUnitPricing";
  public getallScheduledVehiclesGroupedByStorageCapacity: string = this.baseServerUrl + "/AdhocReporting/GetAllScheduledVehiclesByStorageCapacityLowestPrice";
  public getallUnScheduledVehiclesGroupedByStorageCapacity: string = this.baseServerUrl + "/AdhocReporting/GetAllUnScheduledVehiclesByStorageCapacityLowestPrice";

  public postOrCreateFarmerUrl: string = this.baseServerUrl + "/Farmer/PostOrCreateFarmer";
  public updateFarmerUrl: string = this.baseServerUrl + "/Farmer/UpdateFarmer";
  public getAllFarmersUrl: string = this.baseServerUrl + "/Farmer/GetAllFarmers";
  public getFarmerByIdUrl: string = this.baseServerUrl + "/Farmer/GetFarmerById";
  public deleteFarmerUrl: string = this.baseServerUrl + "/Farmer/DeleteFarmer";

  public postOrCreateFoodHubUrl: string = this.baseServerUrl + "/FoodHub/PostOrCreateFoodHub";
  public updatefoodHubUrl: string = this.baseServerUrl + "/FoodHub/UpdateFoodHub";
  public getAllFoodHubsUrl: string = this.baseServerUrl + "/FoodHub/GetAllFoodHubs";
  public getFoodHubByIdUrl: string = this.baseServerUrl + "/FoodHub/GetFoodHubById";
  public deleteFoodHubUrl: string = this.baseServerUrl + "/FoodHub/DeleteFoodHub";

  public postOrCreateFoodHubStorageUrl: string = this.baseServerUrl + "/FoodHub/PostCreateFoodHubStorage";
  public updateFoodHubStorageUrl: string = this.baseServerUrl + "/FoodHub/UpdateFoodHubStorage";
  public getAllFoodHubStoragesUrl: string = this.baseServerUrl + "/FoodHub/GetAllFoodHubStorages";
  public getFoodHubStorageByIdUrl: string = this.baseServerUrl + "/FoodHub/GetFoodHubStorageById";
  public deleteFoodHubStorageUrl: string = this.baseServerUrl + "/FoodHub/DeleteFoodHubStorage";

  public postOrCreateCommodityUrl: string = this.baseServerUrl + "/Farmer/PostOrCreateFarmerCommodity";
  public updateCommodityUrl: string = this.baseServerUrl + "/Farmer/UpdateFarmerCommodity";
  public getAllCommoditiesUrl: string = this.baseServerUrl + "/Farmer/GetAllFarmerCommodities";
  public getCommodityByIdUrl: string = this.baseServerUrl + "/Farmer/GetFarmerCommodityById";
  public deleteCommodityUrl: string = this.baseServerUrl + "/Farmer/DeleteFarmerCommodity";

  public postOrCreateCommodityUnitUrl: string = this.baseServerUrl + "/Farmer/PostOrCreateCommodityUnit";
  public updateCommodityUnitUrl: string = this.baseServerUrl + "/Farmer/UpdateCommodityUnit";
  public getAllCommodityUnitsUrl: string = this.baseServerUrl + "/Farmer/GetAllCommodityUnits";
  public getCommodityUnitByIdUrl: string = this.baseServerUrl + "/Farmer/GetCommodityUnitById";
  public deleteCommodityUnitUrl: string = this.baseServerUrl + "/Farmer/DeleteCommodityUnit";

  public postOrCreateCommodityCategoryUrl: string = this.baseServerUrl + "/Farmer/PostOrCreateCommodityCategory";
  public updateCommodityCategoryUrl: string = this.baseServerUrl + "/Farmer/UpdateCommodityCategory";
  public getAllCommodityCategoriesUrl: string = this.baseServerUrl + "/Farmer/GetAllCommodityCategories";
  public getCommodityCategoryByIdUrl: string = this.baseServerUrl + "/Farmer/GetCommodityCategoryById";
  public deleteCommodityCategoryUrl: string = this.baseServerUrl + "/Farmer/DeleteCommodityCategory";

  public postOrCreateCompanyUrl: string = this.baseServerUrl + "/Company/PostOrCreateCompany";
  public updateCompanyUrl: string = this.baseServerUrl + "/Company/UpdateCompany";
  public getAllCompaniesUrl: string = this.baseServerUrl + "/Company/GetAllCompanies";
  public getCompanyByIdUrl: string = this.baseServerUrl + "/Company/GetCompanyById";
  public deleteCompanyUrl: string = this.baseServerUrl + "/Company/DeleteCompany";

  public postOrCreateTransportPricingUrl: string = this.baseServerUrl + "/Transport/PostOrCreateTransportPricing";
  public updateTransportPricing: string = this.baseServerUrl + + "/Transport/UpdateTransportPricing";
  public getAllTransportPricingsUrl: string = this.baseServerUrl + "/Transport/GetAllTransportPricings";
  public getTransportPricingByIdUrl: string = this.baseServerUrl + "/Transport/GetTransportPricingById";
  public deleteTransportPricingUrl: string = this.baseServerUrl + "/Transport/DeleteTransportPricing";

  public postOrCreateTransportScheduleUrl: string = this.baseServerUrl + "/Transport/PostOrCreateTransportSchedule";
  public updateTransportScheduleUrl: string = this.baseServerUrl + "/Transport/UpdateTransportSchedule";
  public getAllTransportSchedulesUrl: string = this.baseServerUrl + "/Transport/GetAllTransportSchedules";
  public getTransportScheduleByIdUrl: string = this.baseServerUrl + "/Transport/GetTransportScheduleById";
  public deleteTransportScheduleUrl: string = this.baseServerUrl + "/Transport/DeleteTransportSchedule";
  public getIntermediateSchedulesByTransportScheduleId: string = this.baseServerUrl + "/Transport/GetIntermediateSchedulesByTransportScheduleId";

  public postOrCreateIntermediateScheduleUrl: string = this.baseServerUrl + "/Transport/PostOrCreateIntermediateSchedule";
  public updateIntermediateScheduleUrl: string = this.baseServerUrl + "/Transport/UpdateIntermediateSchedule";
  public getAllIntermediateSchedulesUrl: string = this.baseServerUrl + "/Transport/GetAllIntermediateSchedules";
  public getIntermediateScheduleByIdUrl: string = this.baseServerUrl + "/Transport/GetIntermediateScheduleById";
  public deleteIntermediateScheduleUrl: string = this.baseServerUrl + "/Transport/DeleteIntermediateSchedule";


  public postOrCreateVehicleCapacityUrl: string = this.baseServerUrl + "/Transport/PostOrCreateVehicleCapacity";
  public updateVehicleCapacityUrl: string = this.baseServerUrl + "/Transport/UpdateVehicleCapacity";
  public getAllVehicleCapacitiesUrl: string = this.baseServerUrl + "/Transport/GetAllVehicleCapacities";
  public getVehicleCapacityByIdUrl: string = this.baseServerUrl + "/Transport/GetVehicleCapacityById";
  public deleteVehicleCapacityUrl: string = this.baseServerUrl + "/Transport/DeleteVehicleCapacity";

  public postOrCreateVehicleUrl: string = this.baseServerUrl + "/Transport/PostOrCreateVehicle";
  public updateVehicleUrl: string = this.baseServerUrl + "/Transport/UpdateVehicle";
  public getAllVehiclesUrl: string = this.baseServerUrl + "/Transport/GetAllVehicles";
  public getVehicleByIdUrl: string = this.baseServerUrl + "/Transport/GetVehicleById";
  public deleteVehicleUrl: string = this.baseServerUrl + "/Transport/DeleteVehicle";

  public postOrCreateVehicleCategoryUrl: string = this.baseServerUrl + "/Transport/PostOrCreateVehicleCategory";
  public updateVehicleCategoryUrl: string = this.baseServerUrl + "/Transport/UpdateVehicleCategory";
  public getAllVehicleCategoriesUrl: string = this.baseServerUrl + "/Transport/GetAllVehicleCategories";
  public getVehicleCategoryByIdUrl: string = this.baseServerUrl + "/Transport/GetVehicleCategoryById";
  public deleteVehicleCategoryUrl: string = this.baseServerUrl + "/Transport/DeleteVehicleCategory";

  public postOrCreateAddressUrl: string = this.baseServerUrl + "/LocationAndAddress/PostOrCreateAddress";
  public updateAddressUrl: string = this.baseServerUrl + "/LocationAndAddress/UpdateAddress";
  public getAllAddressesUrl: string = this.baseServerUrl + "/LocationAndAddress/GetAllAddresses";
  public getAddressByIdUrl: string = this.baseServerUrl + "/LocationAndAddress/GetAddressById";
  public deleteAddressUrl: string = this.baseServerUrl + "/LocationAndAddress/DeleteAddress";

  public postOrCreateLocationUrl: string = this.baseServerUrl + "/LocationAndAddress/PostOrCreateLocation";
  public updateLocationUrl: string = this.baseServerUrl + "/LocationAndAddress/UpdateLocation";
  public getAllLocationsUrl: string = this.baseServerUrl + "/LocationAndAddress/GetAllLocations";
  public getLocationByIdUrl: string = this.baseServerUrl + "/LocationAndAddress/GetLocationById";
  public deleteLocationUrl: string = this.baseServerUrl + "/LocationAndAddress/DeleteLocation";


  public postOrCreateDriverUrl: string = this.baseServerUrl + "/Company/PostOrCreateDriver";
  public updateDriverUrl: string = this.baseServerUrl + "/Company/UpdateDriver";
  public getAllDriversUrl: string = this.baseServerUrl + "/Company/GetAllDrivers";
  public getDriverByIdUrl: string = this.baseServerUrl + "/Company/GetDriverById";
  public deleteDriverUrl: string = this.baseServerUrl + "/Company/DeleteDriver";
  public postOrCreateDriverNoteUrl: string = this.baseServerUrl + "/Company/CreateDriverNote";
  public getDriverByTransportScheduleIdUrl: string = this.baseServerUrl + "/Company/GetDriverByTransportScheduleId";

  public static actUserStatus: IUserStatus = {
    isUserLoggedIn: false,
    isUserAdministrator: false
  };
  public static userDetails: IUserDetail = {
    emailAddress: "",
    username: "",
    mobileNumber: "",
    password: "",
    keepLoggedIn: false,
    repassword: "",
    role: "",
    firstName: "",
    lastName: "",
    authToken: ""
  }
  public static userRoles = []
  public constructor(httpClient: HttpClient) {
    this.httpClient = httpClient;
  }

  public static SetUserEmail(userEmailAddress: string) {
    AfricanFarmerCommoditiesService.clientEmailAddress = userEmailAddress;
  }
  public GetVehicleCategories(): Observable<string[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getAllVehicleCategoriesUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any): string[] => {
      let vehicleCategories: string[] = res;
      return vehicleCategories;
    });
  }

  public GetDriverScheduleNotes(): Observable<IDriverNote[]> {

    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getDriverScheduleNotesUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any): IDriverNote[] => {
      let driverNotes: IDriverNote[] = res;
      return driverNotes;
    });
  }


  public GetDriverTransportSchedules(): Observable<ITransportSchedule[]> {

    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getDriverTransportSchedulesUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any): ITransportSchedule[] => {
      let transportSchedules: ITransportSchedule[] = res;
      return transportSchedules;
    });
  }
  public GetAllRoles(): Observable<any> {

    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getAllRoles;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any): object[] => {
      let roles: object[] = res;
      return roles;
    });
  }
  GetTwitterFeeds(): Observable<any[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getTwitterFeedsUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any): any[] => {
      let twitterFeeds: any[] = res;
      return twitterFeeds;
    });
  }
  public RemoveVehicleFromMonitor(selectedVe: IVehicleLocationMonitor): Observable<any> {
    let body = JSON.stringify(selectedVe);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.postRemoveVehicleFromMonitorUrl,
      headers: headers,
      body: body
    };

    return this.httpClient.post(requestOptions.url, body, { 'headers': requestOptions.headers }).
      map((res: any) => {
        return res;
      });
  } 
  public GetDriverMobileLocationApp(appType: string): Observable<Blob> {

    let requestUrl = this.getDriverMobileLocationAppUrl+"/"+ appType;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      responseType: 'blob'
    };

    return this.httpClient.get(requestOptions.url, requestOptions).map((res:any) => {
      let result: Blob = res;
      return result;
    });
  }
  public GetVehicleRealTimeLocations(): Observable<IVehicleLocationMonitor[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getVehicleRealTimeLocations;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      let results: IVehicleLocationMonitor[] = res;
      return results;
    });
  }
  GetallFoodHubStorageAvailabilityStorage(): Observable<IFoodHubCommodityStorageUsage[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getallFoodHubStorageAvailabilityStorage;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((results: any) => {
      return results;
    });
  }

  GetFoodHubStorageAvailabilityStorageByFoodHubId(foodHubId: number): Observable<IFoodHubCommodityStorageUsage[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getFoodHubStorageAvailabiliyStorageByFoodHubId + "?foodHubId=" + foodHubId;;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((results: any) => {
      return results;
    });
  }

  GetTop5DryCommoditiesInDemandRatingAccordingToStorageFacilities(): Observable<ITop5DryStorageCommoditiesInDemandRating[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getTop5DryCommoditiesInDemandRatingAccordingToStorageFacilities;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((results: any) => {
      return results;
    });
  }

  GetTop5RefreigeratedCommoditiesInDemandRatingAccordingToStorageFacilities(): Observable<ITop5ReferigeratedStorageCommoditiesInDemandRating[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getTop5RefreigeratedCommoditiesInDemandRatingAccordingToStorageFacilities;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((results: any) => {
      return results;
    });
  }

  GetTop5FarmerCommoditiesUnitPricings(): Observable<ITop5FarmersCommoditiesByUnitPrice[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getTop5FarmerCommoditiesUnitPricings;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((results: any) => {
      return results;
    });
  }
  GetallScheduledVehiclesGroupedByStorageCapacity(): Observable<IAllscheduledVehiclesByStorageCapacity[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getallScheduledVehiclesGroupedByStorageCapacity;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((results: any) => {
      return results;
    });
  }

  GetallUnScheduledVehiclesGroupedByStorageCapacity(): Observable<IUnscheduledVehiclesByStorageCapacity[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getallUnScheduledVehiclesGroupedByStorageCapacity;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((results: any) => {
      return results;
    });
  }
  GetSearchLocationWeather(city: string, country: string): Observable<ILocationWeather> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getCityLocationWeatherFocus + "/" + city + "/" + country;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((weatherFocus: any) => {
      return weatherFocus;
    });
  }

  public GetUserInvoicedItems(username: string): Observable<IInvoice[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getUserInvoicedItems + "?username=" + username;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any): IInvoice[] => {
      let invoices: IInvoice[] = res;
      return invoices;
    });
  }

  public GetAllUserRoles(username: string): Observable<string[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getAllUserRoles + "?username=" + username;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any): string[] => {
      let roles: string[] = res;
      return roles;
    });
  }
  public DeleteTransportScheduleLog(transLog: ITransportLog): Observable<any> {
    let body = JSON.stringify(transLog);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.deleteTransLogUrl,
      method: 'POST',
      headers: headers,
      body: body
    };

    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }
  public CreateTransportScheduleLog(transLog: ITransportLog): Observable<any> {
    let body = JSON.stringify(transLog);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.createTransLogUrl,
      method: 'POST',
      headers: headers,
      body: body
    };

    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public CreateUserRole(role: string): Observable<any> {
    let body = JSON.stringify({ role: role });

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.createRoleUrl,
      method: 'POST',
      headers: headers,
      body: body
    };

    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }
  public VerifyQrcodeScan(userDetail: IUserDetail): Observable<any> {
    let body = JSON.stringify(userDetail);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.postVerifyQrcodeScan,
      method: 'POST',
      headers: headers,
      body: body
    };

    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }
  public DeleteUserRole(role: string): Observable<any> {
    let body = JSON.stringify({ role: role });

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.deleteRoleUrl,
      method: 'POST',
      headers: headers,
      body: body
    };

    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }
  public AddUserToRole(email: string, role: string): Observable<any> {
    let body = JSON.stringify({ email: email, role: role });

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.postAddUserToRole,
      method: 'POST',
      headers: headers,
      body: body
    };
    return this.httpClient.post(requestOptions.url, body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }
  public SendEmail(body: FormData): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'multipart/form-data' });
    let requestOptions: any = {
      url: this.postSendEmail,
      headers: headers
    };

    return this.httpClient.post(requestOptions.url, body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public RemoveUserFromRole(email: string, role: string): Observable<any> {
    let body = JSON.stringify({ email: email, role: role });

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.postRmoveUserFromRole,
      headers: headers,
      body: body
    };

    return this.httpClient.post(requestOptions.url, body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public VerifyLoggedInUser(): any {
    let headers = new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' });
    let requestUrl = this.getVerifyLoggedInUser;
    let requestOptions: any = {
      url: requestUrl,
      headers: headers
    };

    return this.httpClient.get(requestOptions.url, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });

  }
  public LoginByPost(userDetail: IUserDetail): Observable<any> {
    let body = JSON.stringify(userDetail);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.postLoginUrl,
      headers: headers,
      body: body
    };

    return this.httpClient.post(requestOptions.url, body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }
  public MakePayment(currentPaymentAmount: number, contents: ICommodity[], username: string): Observable<any> {
    let encapsulatedData: any = {
      amountPayable: currentPaymentAmount,
      username: username,
      contents: contents
    }
    let body = JSON.stringify(encapsulatedData);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.postCurrentPaymentUrl,
      headers: headers,
      body: body
    };

    return this.httpClient.post(requestOptions.url, body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public LogOut(): Observable<any> {

    return this.httpClient.get(this.getLogoutUrl).map((res: any) => {
      return res;
    });
  }
  public GetRequest(url): Observable<any> {

    return this.httpClient.get(url).map((res: any) => {
      return res;
    });
  }

  public GetSchedulesPricingById(schedulesPricingId: number): Observable<any> {

    let headers = new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' });
    let requestUrl = this.schedulesPricingsUrl + "?schedulesPricingId=" + schedulesPricingId;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers
    };

    return this.httpClient.get(requestOptions.url, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }
  public registerByPost(userDetail: IUserDetail): Observable<any> {
    let body = JSON.stringify(userDetail);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.postRegisterUrl,
      headers: headers,
      body: body
    };

    return this.httpClient.post(requestOptions.url, body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }
  public forgotPasswordByPost(userDetail: IUserDetail): Observable<any> {
    let body = JSON.stringify(userDetail);
    var actionResult: any;

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.postForgotPasswordUrl,
      headers: headers,
      body: body
    };
    return this.httpClient.post(requestOptions.url, body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }
  public GetAllAddresses(): Observable<IAddress[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getAllAddressesUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetAddressById(addressId: number): Observable<IAddress> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getAddressByIdUrl + "/" + addressId;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public DeleteAddress(address: IAddress): any {
    let body: string = JSON.stringify(address);
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.deleteAddressUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'POST',
      headers: headers,
      responseType: 'application/json',
      body: body
    };

    return this.httpClient.post(requestOptions.url, requestOptions.body, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetAllLocations(): Observable<ILocation[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getAllLocationsUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetLocationById(locationId: number): Observable<ILocation> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getLocationByIdUrl + "/" + locationId;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public DeleteLocation(location: ILocation): any {
    let body: string = JSON.stringify(location);
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.deleteLocationUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'POST',
      headers: headers,
      responseType: 'application/json',
      body: body
    };

    return this.httpClient.post(requestOptions.url, requestOptions.body.requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  GetDriverByTransportScheduleId(transportScheduleId: number): Observable<IDriver> {

    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getDriverByTransportScheduleIdUrl + "/" + transportScheduleId;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetAllDrivers(): Observable<IDriver[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getAllDriversUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetDriverById(driverId: number): Observable<IDriver> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getDriverByIdUrl + "/" + driverId;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public DeleteDriver(driver: IDriver): any {
    let body: string = JSON.stringify(driver);
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.deleteDriverUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'POST',
      headers: headers,
      responseType: 'application/json',
      body: body
    };

    return this.httpClient.post(requestOptions.url, requestOptions.body, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetUserDetails(): any {
    return localStorage.getItem("userDetails");
  }
  public PostOrCreateIntermediateSchedule(intermediateSchedule: IIntermediateSchedule): Observable<any> {
    let body = JSON.stringify(intermediateSchedule);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.postOrCreateIntermediateScheduleUrl,
      headers: headers,
      body: body
    }; headers.append('Content-Type', 'application/json');

    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }
  public UpdateIntermediateSchedule(intermediateSchedule: IIntermediateSchedule): Observable<any> {
    let body = JSON.stringify(intermediateSchedule);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.updateIntermediateScheduleUrl,
      headers: headers,
      body: body
    };
    headers.append('Content-Type', 'application/json');
    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public GetAllIntermediateSchedules(): Observable<IIntermediateSchedule[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getAllIntermediateSchedulesUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public DeleteIntermediateSchedule(intermediateSchedule: ITransportSchedule) {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.deleteIntermediateScheduleUrl;
    let body: string = JSON.stringify(intermediateSchedule);
    let requestOptions: any = {
      url: requestUrl,
      method: 'POST',
      headers: headers,
      responseType: 'application/json',
      body: body
    };

    return this.httpClient.post(requestOptions.url, requestOptions.body, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetIntermediateScheduleById(intermediateScheduleId: number): Observable<ITransportSchedule> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getIntermediateScheduleByIdUrl + "/" + intermediateScheduleId;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetAllFamers(): Observable<IFarmer[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getAllFarmersUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }

  public GetFarmerById(farmerId: number): Observable<IFarmer> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getFarmerByIdUrl + "/" + farmerId;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public DeleteFarmer(farmer: IFarmer): any {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let body: string = JSON.stringify(farmer);
    let requestUrl = this.deleteFarmerUrl
    let requestOptions: any = {
      url: requestUrl,
      method: 'POST',
      headers: headers,
      responseType: 'application/json',
      body: body
    };

    return this.httpClient.post(requestOptions.url, requestOptions.body, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetAllFoodHubs(): Observable<IFoodHub[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getAllFoodHubsUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetFoodHubById(foodHubId: number): Observable<IFoodHub> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getFoodHubByIdUrl + "/" + foodHubId;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public DeleteFoodHub(foodHub: IFoodHub) {
    let body: string = JSON.stringify(foodHub);
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.deleteFoodHubUrl;;
    let requestOptions: any = {
      url: requestUrl,
      method: 'POST',
      headers: headers,
      responseType: 'application/json',
      body: body
    };

    return this.httpClient.post(requestOptions.url, requestOptions.body, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetAllFoodHubStorages(): Observable<IFoodHubStorage[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getAllFoodHubStoragesUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetFoodHubStorageById(foodHubStorageId: number): Observable<IFoodHubStorage> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getFoodHubStorageByIdUrl + "/" + foodHubStorageId;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public DeleteFoodHubStorage(foodHubStorage: IFoodHubStorage) {
    let body: string = JSON.stringify(foodHubStorage);
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.deleteFoodHubStorageUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'POST',
      headers: headers,
      responseType: 'application/json',
      body: body
    };

    return this.httpClient.post(requestOptions.url, requestOptions.body, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetAllCommodities(): Observable<ICommodity[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getAllCommoditiesUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetCommodityById(commodityId: number): Observable<ICommodity> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getCommodityByIdUrl + "/" + commodityId;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public DeleteCommodity(commodity: ICommodity) {
    let body: string = JSON.stringify(commodity);
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.deleteCommodityUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'POST',
      headers: headers,
      responseType: 'application/json',
      body: body
    };

    return this.httpClient.post(requestOptions.url, requestOptions.body, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetAllCommodityUnits(): Observable<ICommodityUnit[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getAllCommodityUnitsUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetCommodityUnitById(commodityUnitId: number): Observable<ICommodityUnit> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getCommodityUnitByIdUrl + "/" + commodityUnitId;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public DeleteCommodityUnit(commodityUnit: ICommodityUnit) {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let body: string = JSON.stringify(commodityUnit);
    let requestUrl = this.deleteCommodityUnitUrl
    let requestOptions: any = {
      url: requestUrl,
      method: 'POST',
      headers: headers,
      responseType: 'application/json',
      body: body
    };

    return this.httpClient.post(requestOptions.url, requestOptions.body, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetAllCommodityCategories(): Observable<ICommodityCategory[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getAllCommodityCategoriesUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetCommodityCategoryById(commodityCategoryId: number): Observable<ICommodityCategory> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getCommodityCategoryByIdUrl + "/" + commodityCategoryId;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public DeleteCommodityCategory(commodityCategory: ICommodityCategory) {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let body: string = JSON.stringify(commodityCategory);
    let requestUrl = this.deleteCommodityCategoryUrl
    let requestOptions: any = {
      url: requestUrl,
      method: 'POST',
      headers: headers,
      responseType: 'application/json',
      body: body
    };

    return this.httpClient.post(requestOptions.url, requestOptions.body, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetAllCompanies(): Observable<ICompany[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getAllCompaniesUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetCompanyById(companyId: number): Observable<ICompany> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getCompanyByIdUrl + "/" + companyId;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public DeleteCompany(company: ICompany) {
    let body: string = JSON.stringify(company);
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.deleteCompanyUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'POST',
      headers: headers,
      responseType: 'application/json',
      body: body
    };

    return this.httpClient.post(requestOptions.url, requestOptions.body, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetAllTransportPricings(): Observable<ITransportPricing[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getAllTransportPricingsUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetTransportPricingById(transportPricingId: number): Observable<ICompany> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getTransportPricingByIdUrl + "/" + transportPricingId;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public DeleteTransportPricing(transportPricing: ITransportPricing) {
    let body: string = JSON.stringify(transportPricing);
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.deleteTransportPricingUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'POST',
      headers: headers,
      responseType: 'application/json',
      body: body
    };

    return this.httpClient.post(requestOptions.url, requestOptions.body, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetAllTransportSchedules(): Observable<ITransportSchedule[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getAllTransportSchedulesUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetAllIntemediateSchedules(): Observable<ITransportSchedule[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getAllTransportSchedulesUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetIntermediateScheduleByTransportScheduleId(transportScheduleId: number): Observable<IIntermediateSchedule[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getIntermediateSchedulesByTransportScheduleId + "/" + transportScheduleId;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }

  public GetTransportScheduleId(transportScheduleId: number): Observable<ITransportSchedule> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getTransportScheduleByIdUrl + "/" + transportScheduleId;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public DeleteTransportSchedule(transportSchedule: ITransportSchedule) {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.deleteTransportScheduleUrl;
    let body: string = JSON.stringify(transportSchedule);
    let requestOptions: any = {
      url: requestUrl,
      method: 'POST',
      headers: headers,
      responseType: 'application/json',
      body: body
    };

    return this.httpClient.post(requestOptions.url, requestOptions.body, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetAllVehicles(): Observable<IVehicle[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getAllVehiclesUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetVehiclById(vehicleId: number): Observable<IVehicle> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getVehicleByIdUrl + "/" + vehicleId;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public DeleteVehicle(vehicle: IVehicle) {
    let body: string = JSON.stringify(vehicle);
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.deleteVehicleUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'POST',
      headers: headers,
      responseType: 'application/json',
      body: body
    };

    return this.httpClient.post(requestOptions.url, requestOptions.body, requestOptions.headers).map((res: any) => {
      return res;
    })
  }

  public GetAllVehicleCapacities(): Observable<IVehicleCapacity[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getAllVehicleCapacitiesUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetVehicleCapacityById(vehicleCapacityId: number): Observable<IVehicleCapacity> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getVehicleCapacityByIdUrl + "/" + vehicleCapacityId;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public DeleteVehicleCapacity(vehicleCapacity: IVehicleCapacity) {
    let body: string = JSON.stringify(vehicleCapacity);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.deleteVehicleCapacityUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'POST',
      headers: headers,
      responseType: 'application/json',
      body: body
    };

    return this.httpClient.post(requestOptions.url, requestOptions.body, requestOptions.headers).map((res: any) => {
      return res;
    });
  }

  public GetAllVehicleCategories(): Observable<IVehicleCategory[]> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getAllVehicleCategoriesUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public GetVehicleCategoryById(vehicleCategoryId: number): Observable<IVehicleCategory> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.getVehicleCategoryByIdUrl + "/" + vehicleCategoryId;
    let requestOptions: any = {
      url: requestUrl,
      method: 'GET',
      headers: headers,
      responseType: 'application/json'
    };

    return this.httpClient.get(requestOptions.url, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public DeleteVehicleCategory(vehicleCategory: IVehicleCategory) {
    let body: string = JSON.stringify(vehicleCategory);
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    let requestUrl = this.deleteVehicleCategoryUrl;
    let requestOptions: any = {
      url: requestUrl,
      method: 'POST',
      headers: headers,
      responseType: 'application/json',
      body: body
    };

    return this.httpClient.post(requestOptions.url, requestOptions.body, requestOptions.headers).map((res: any) => {
      return res;
    });
  }
  public PostOrCreateLocation(location: ILocation): Observable<any> {
    let body = JSON.stringify(location);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.postOrCreateLocationUrl,
      headers: headers,
      body: body
    };
    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public UpdateLocation(location: ILocation): Observable<any> {
    let body = JSON.stringify(location);
    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.updateLocationUrl,
      headers: headers,
      body: body
    };
    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public addDriverNote(driverNote: IDriverNote): Observable<any> {
    let body = JSON.stringify(driverNote);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.postOrCreateDriverNoteUrl,
      headers: headers,
      body: body
    };
    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: IDriverNote) => {
      return res;
    });
  }
  public PostOrCreateDriver(driver: IDriver): Observable<any> {
    let body = JSON.stringify(driver);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.postOrCreateDriverUrl,
      headers: headers,
      body: body
    };
    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public UpdateDriver(driver: IDriver): Observable<any> {
    let body = JSON.stringify(driver);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.updateDriverUrl,
      headers: headers,
      body: body
    };
    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }
  public PostOrCreateVehicle(vehicle: IVehicle): Observable<any> {
    let body = JSON.stringify(vehicle);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.postOrCreateVehicleUrl,
      headers: headers,
      body: body
    }; headers.append('Content-Type', 'application/json');

    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public UpdateVehicle(vehicle: IVehicle): Observable<any> {
    let body = JSON.stringify(vehicle);
    var actionResult: any;

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.updateVehicleUrl,
      headers: headers,
      body: body
    };
    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public PostOrCreateAddress(address: IAddress): Observable<any> {
    let body = JSON.stringify(address);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.postOrCreateAddressUrl,
      headers: headers,
      body: body
    };

    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public UpdateAddress(address: IAddress): Observable<any> {
    let body = JSON.stringify(address);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.updateAddressUrl,
      headers: headers,
      body: body
    };
    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public PostOrCreateFarmer(farmer: IFarmer): Observable<any> {
    let body = JSON.stringify(farmer);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.postOrCreateFarmerUrl,
      headers: headers,
      body: body
    };

    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public UpdateFarmer(farmer: IFarmer): Observable<any> {
    let body = JSON.stringify(farmer);
    var actionResult: any;

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.updateFarmerUrl,
      headers: headers,
      body: body
    };
    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public PostOrCreateFoodHub(foodHub: IFoodHub): Observable<any> {
    let body = JSON.stringify(foodHub);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.postOrCreateFoodHubUrl,
      headers: headers,
      body: body
    };
    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }
  public UpdateFoodHub(foodHub: IFoodHub): Observable<any> {
    let body = JSON.stringify(foodHub);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.updatefoodHubUrl,
      headers: headers,
      body: body
    };
    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public PostOrCreateFoodHubStorage(foodHubStorage: IFoodHubStorage): Observable<any> {
    let body = JSON.stringify(foodHubStorage);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.postOrCreateFoodHubStorageUrl,
      headers: headers,
      body: body
    };
    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public UpdateFoodHubStorage(foodHubStorage: IFoodHubStorage): Observable<any> {
    let body = JSON.stringify(foodHubStorage);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.updateFoodHubStorageUrl,
      headers: headers,
      body: body
    };
    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public PostOrCreateCommodity(commodity: ICommodity): Observable<any> {
    let body = JSON.stringify(commodity);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.postOrCreateCommodityUrl,
      headers: headers,
      body: body
    }; headers.append('Content-Type', 'application/json');

    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public UpdateCommodity(commodity: ICommodity): Observable<any> {
    let body = JSON.stringify(commodity);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.updateCommodityUrl,
      headers: headers,
      body: body
    };
    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public PostOrCreateCommodityUnit(commodityUnit: ICommodityUnit): Observable<any> {
    let body = JSON.stringify(commodityUnit);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.postOrCreateCommodityUnitUrl,
      headers: headers,
      body: body
    };

    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public UpdateCommodityUnit(commodityUnit: ICommodityUnit): Observable<any> {
    let body = JSON.stringify(commodityUnit);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.updateCommodityUnitUrl,
      headers: headers,
      body: body
    };
    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public PostOrCreateCommodityCategory(commodityCategory: ICommodityCategory): Observable<any> {
    let body = JSON.stringify(commodityCategory);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.postOrCreateCommodityCategoryUrl,
      headers: headers,
      body: body
    };

    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public UpdateCommodityCategory(commodityCategory: ICommodityCategory): Observable<any> {
    let body = JSON.stringify(commodityCategory);
    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.updateCommodityCategoryUrl,
      headers: headers,
      body: body
    };
    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public PostOrCreateCompany(company: ICompany): Observable<any> {
    let body = JSON.stringify(company);
    var actionResult: any;

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.postOrCreateCompanyUrl,
      headers: headers,
      body: body
    }; headers.append('Content-Type', 'application/json');

    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public UpdateCompany(company: ICompany): Observable<any> {
    let body = JSON.stringify(company);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.updateCompanyUrl,
      headers: headers,
      body: body
    };
    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public PostOrCreateTransportPricing(transportPricing: ITransportPricing): Observable<any> {
    let body = JSON.stringify(transportPricing);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.postOrCreateTransportPricingUrl,
      headers: headers,
      body: body
    };
    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public UpdateTransportPricing(transportPricing: ITransportPricing): Observable<any> {
    let body = JSON.stringify(transportPricing);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.updateTransportPricingUrl,
      headers: headers,
      body: body
    };
    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public PostOrCreateTransportSchedule(transportSchedule: ITransportSchedule): Observable<any> {
    let body = JSON.stringify(transportSchedule);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.postOrCreateTransportScheduleUrl,
      headers: headers,
      body: body
    };

    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public UpdateTransportSchedule(transportSchedule: ITransportSchedule): Observable<any> {
    let body = JSON.stringify(transportSchedule);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.updateTransportScheduleUrl,
      headers: headers,
      body: body
    };
    headers.append('Content-Type', 'application/json');
    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public PostOrCreateVehicleCapacity(vehicleCapacity: IVehicleCapacity): Observable<any> {
    let body = JSON.stringify(vehicleCapacity);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.postOrCreateVehicleCapacityUrl,
      headers: headers,
      body: body
    };
    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public UpdateVehicleCapacity(vehicleCapacity: IVehicleCapacity): Observable<any> {
    let body = JSON.stringify(vehicleCapacity);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.updateVehicleCapacityUrl,
      headers: headers,
      body: body
    };
    headers.append('Content-Type', 'application/json');
    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public PostOrCreateVehicleCategory(vehicleCategory: IVehicleCategory): Observable<any> {
    let body = JSON.stringify(vehicleCategory);

    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.postOrCreateVehicleCategoryUrl,
      headers: headers,
      body: body
    }; headers.append('Content-Type', 'application/json');

    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }

  public UpdateVehicleCategory(vehicleCategory: IVehicleCategory): Observable<any> {
    let body = JSON.stringify(vehicleCategory);
    const headers = new HttpHeaders({ 'content-type': 'application/json' });

    let requestOptions: any = {
      url: this.updateVehicleCategoryUrl,
      headers: headers,
      body: body
    };
    headers.append('Content-Type', 'application/json');
    return this.httpClient.post(requestOptions.url, requestOptions.body, { 'headers': requestOptions.headers }).map((res: any) => {
      return res;
    });
  }
}
export interface IExtraCharges {
  tourClientId: number;
  tourClientExtraChargesId: number;
  extraCharges: number;
  description: string
}
export interface IInvoice {
  invoiceId: number;
  invoiceName: string;
  netCost: number;
  percentTaxAppliable: number;
  grossTotalCost: number;
  dateUpdated: Date;
  dateCreated: Date;
}
export interface IVehicle {
  vehicleId: number;
  inGoodCondition: boolean;
  companyId: number;
  company: ICompany;
  vehicleRegistration: string;
  vehicleCategory: IVehicleCategory;
  vehicleCapacity: IVehicleCapacity;
  vehicleCapacityId: number;
  vehicleCategoryId: number;
}
export interface IVehicleCategory {
  vehicleCategoryId: number;
  vehicleCategoryName: string;
  description: string;
}
export interface IVehicleCapacity {
  vehicleCapacityId: number;
  vechicleCapacityUnitsName: string;
  vechicleCapacity: number;
  description: string;
}
export interface ILocation {
  locationId: number;
  locationName: string;
  address: IAddress;
  addressId: number;
}
export interface IAddress {
  addressId: number;
  addressLine1: string;
  addressLine2: string;
  town: string;
  postCode: string;
  country: string;
}
export interface IUserDetail {
  emailAddress: string | any;
  username: string;
  mobileNumber: string | any;
  password: string | any;
  keepLoggedIn: boolean;
  repassword: string;
  role: string;
  firstName: string;
  lastName: string;
  authToken: string;
}
export interface IEmailMessage {
  emailFrom: string;
  emailTo: string;
  attachment: Binary;
  emailSubject: string;
  emailBody: string;
}
export interface IUserStatus {

  isUserLoggedIn: boolean;
  isUserAdministrator: boolean;
}
export interface ILogInStatus {
  isLoggedIn: boolean;
  isAdministrator: boolean;
  isRegistered: boolean;
  message: string;
  errorMessage: string;
  authToken: string;
}
export interface IUserRole {
  name: string;
}
export interface ICompany {
  companyId: number;
  companyName: string
  companyPhoneNUmber: string;
  locationId: number;
  location: ILocation;
}
export interface IDriver {
  driverId: number;
  firstName: string;
  lastName: string;
  transportScheduleId: number;
  transportSchedule: ITransportSchedule;
  vehicleId: number;
  vehicle: IVehicle;
}
export interface ICommodity {
  commodityId: number;
  commodityName: string;
  commodityDescription: string;
  commodityUnitPrice: number;
  numberOfUnits: string;
  commodityUnit: ICommodityUnit;
  commodityUnitId: number;
  commodityCategoryId: number;
  commodityCategory: ICommodityCategory;
  companyId: string;
  farmerId: string;
  farmer: IFarmer;
  username: string;
  unitsAvailable: number;
}
export interface ICommodityCategory {
  commodityCategoryId: number;
  commodityCategoryName: string;
  description: string;
}
export interface IFarmer {
  farmerId: number;
  farmerName: string;
  companyId: number;
  company: ICompany;
  address: IAddress;
  addressId: number;
}
export interface IFoodHub {
  foodHubId: number;
  foodHubName: string;
  locationId: number;
  location: ILocation;
  description: string;
}
export interface ICommodityUnit {
  commodityUnitId: number;
  commodityUnitName: string;
  description: string;
}
export interface IFoodHubStorage {
  foodHubStorageId: number;
  foodHubStorageName: string;
  dryStorageCapacity: number;
  usedDryStorageCapacity: number;
  refreigeratedStorageCapacity: number;
  usedRefreigeratedStorageCapacity: number;
  commodityUnitId: number;
  commodityUnit: ICommodityUnit;
  foodHub: IFoodHub;
  foodHubId: number;
}
export interface IInvoice {
  invoiceId: number;
  InvoiceName: string;
  hasFullyPaid: boolean;
}
export interface ILocation {
  locationId: number;
  country: string;
  locationName: string;
  addressId: number;
  address: IAddress;
}
export interface ITransportPricing {
  transportPricingId: number;
  transportPricingName: string;
  description: string;
  carPricing: number;
  miniBusPricing: number;
  taxiPricing: number;
  pickupTruckPricing: number;
  truckPricing: number;
  busPricing: number;
  trainPricing: number;
  tramPricing: number;
}
export interface IIntermediateSchedule {
  intermediateScheduleId: number;
  transportScheduleId: number;
  intermediateTransportScheduleName: string;
  originLocationId: number;
  destinationLocationId: number;
  vehicleId: number;
  vehicle: IVehicle;
  originName: ILocation;
  hasReachedFinalDestination: boolean;
  destinationName: ILocation;
  dateStartFromOrigin: string;
  dateEndAtDestination: string;
}
export interface ITransportLog {
  transportLogId: number;
  invoiceId: number;
  transportLogName: string;
  transportScheduleId: number;
}
export interface ITransportSchedule {
  transportScheduleId: number;
  transportScheduleName: string;
  transportPricingId: number;
  transportPricing: ITransportPricing;
  description: string;
  originLocationId: number;
  destinationLocationId: number;
  vehicleId: number;
  vehicle: IVehicle;
  originName: ILocation;
  destinationName: ILocation;
  dateStartFromOrigin: string;
  dateEndAtDestination: string;
  hasIntermediateDrops: boolean;
}
export interface IWeatherLocation {
  cityName: string;
  country: string;
}
export interface ITemperature {
  currentTemperature: number;
  maximumTemperature: number;
  minmumTemperature: number;
}
export interface ILocationWeather {
  location: IWeatherLocation;
  temperature: ITemperature;
  pressure: number;
  humidity: number;
  sunrise: string;
  sunset: string;
}

export interface IUnscheduledVehiclesByStorageCapacity {
  vehicleId: number;
  vehicleRegistration: string;
  companyName: string;
  vehicleCategoryName: string;
  description: string;
  cost: number;
}

export interface IAllscheduledVehiclesByStorageCapacity {
  vehicleId: number;
  vehicleRegistration: string;
  companyName: string;
  vehicleCategoryName: string;
  description: string;
  cost: number;
}


export interface IFoodHubCommodityStorageUsage {
  foodHubId: number;
  foodHubName: string;
  foodHubStorageId: number;
  refreigeratedStorageCapacity: number;
  dryStorageCapacity: number;
  usedDryStorageCapacity: number;
  usedRefreigeratedStorageCapacity: number;
}
export interface ITop5DryStorageCommoditiesInDemandRating {
  commodityId: number;
  commodityName: string;
  commodityCategoryName: string;
  totalUsedDryStorageCapacity: number;
  totalDryStorageCapacity: number;
}

export interface ITop5ReferigeratedStorageCommoditiesInDemandRating {
  commodityId: number;
  commodityName: string;
  commodityCategoryName: string;
  totalUsedRefreigeratedStorageCapacity: number;
  totalRefreigeratedStorageCapacity: number;
}

export interface IAllFarmersCommoditiesInUnitPricing {
  farmerId: number;
  farmerName: string;
  commodityId: number;
  commodityName: string;
  commodityCategoryName: string;
  commodityUnitName: string;
  commodityUnitPricing: number;
}

export interface IFoodHubDateAnalysisCommoditiesStockStorageUsage {

  foodHubId: number;
  foodHubName: string;
  foodHubStorageId: number;
  refreigeratedStorageCapacity: number;
  dryStorageCapacity: number;
  usedDryStorageCapacity: number;
  usedRefreigeratedStorageCapacity: number;
}

export interface ITop5FarmersCommoditiesByUnitPrice {
  farmerId: number;
  farmerName: string;
  commodityId: number;
  commodityName: string;
  commodityCategoryName: string;
  commodityUnitName: string;
  farmerCommodityUnitPrice: number;
}
export interface IVehicleLocationMonitor {
  driverName: string;
  driverPhoneNumber: string;
  vehicleRegistration: string;
  lattitude: number;
  longitude: number;
}
export interface IDriverNote {
  driverId: number;
  driverName: string;
  transportScheduleId: number;
  driverNote: string;
  isOriginNote: boolean;
}


