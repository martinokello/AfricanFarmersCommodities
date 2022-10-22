import { BrowserModule } from '@angular/platform-browser';
import { NgModule, NgZone } from '@angular/core'; 
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ActiveCrudOperationsComponent } from './activecrudoperations/activecrudoperations.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AddLocationComponent } from './addLocation/addLocation.component';
import { AddVehicleComponent } from './addVehicle/addVehicle.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ForgotPasswordComponent } from './forgotPassword/forgotPassword.component';
import { PayByInstallmentsComponent } from './installments/installments.component';
import { UserRolesComponent } from './userroles/userroles.component';
import { ContactUsComponent } from './contactus/contactus.component';
import { AboutUsComponent } from './about/aboutus.component';
import { SectionsContactComponent } from './sectionscontact/sectionscontact.component';
import { PayPalSuccessComponent } from './paypalSuccess/paypal-success.component';
import { PayPalFailureComponent } from './paypalFailure/paypal-failure.component';
import { NewRolesComponent } from './newroles/newroles.component';
import { APP_BASE_HREF } from '@angular/common';
import { AfricanFarmerCommoditiesService } from '../services/africanFarmerCommoditiesService';
import { AppInterceptor } from '../interceptors/app.interceptor';
import { AuthGuard } from '../guards/AuthGuard';
import { AdminAuthGuard } from '../guards/AdminAuthGuard';
import { QrCodeComponent } from './qrCodeReader/qrCodeReader.component';
import { AddressComponent } from './crud-operations/address/address.component';
import { CommodityComponent } from './crud-operations/commodity/commodity.component';
import { CommodityCategoryComponent } from './crud-operations/commodity-category/commodityCategory.component';
import { CompanyComponent } from './crud-operations/company/company.component';
import { DriverComponent } from './crud-operations/driver/driver.component';
import { FarmerComponent } from './crud-operations/farmer/farmer.component';
import { FoodHubComponent } from './crud-operations/foodhub/foodhub.component';
import { FoodHubStorageComponent } from './crud-operations/foodhubStorage/foodhubStorage.component';
import { LocationComponent } from './crud-operations/location/location.component';
import { TransportPricingComponent } from './crud-operations/transport-pricing/transportPricing.component';
import { VehicleComponent } from './crud-operations/vehicle/vehicle.component';
import { vehicleCategoryComponent } from './crud-operations/vehicle-category/vehicleCategory.component';
import { TransportScheduleComponent } from './crud-operations/transport-schedule/transportSchedule.component';
import { CommodityUnitComponent } from './crud-operations/commodity-unit/commodityUnit.component';
import { VehicleCapacityComponent } from './crud-operations/vehicle-capacity/vehicleCapacity.component';
import { SuccessComponent } from './success/success.component';
import { FailureComponent } from './failure/failure.component';
import { VehicleMonitorComponent } from './vehiclemonitor/vehiclemonitor.component';
import { BasketComponent } from './basket/basket.component';
import { DriverCalendarComponent } from './driver-calendar-notes/driverCalendar.component';

import { AdministratorRoleComponent } from './roles/administrator/administrator.component';
import { DriverRoleComponent } from './roles/driver/driver.component';
import { FarmerRoleComponent } from './roles/farmer/farmer.component';
import { GovernmentRoleComponent } from './roles/government/government.component';
import { GuestRoleComponent } from './roles/guest/guest.component';
import { RetailerRoleComponent } from './roles/retailer/retailer.component';
import { StandardUserRoleComponent } from './roles/standarduser/standarduser.component';
import { WholeSalerRoleComponent } from './roles/wholesaler/wholesaler.component';
import { AuthDriverGuard } from '../guards/AuthDriverGuard';
import { AuthFarmerGuard } from '../guards/AuthFarmerGuard';
import { AuthGovernmentGuard } from '../guards/AuthGovernmentGuard';
import { AuthGuestGuard } from '../guards/AuthGuestGuard';
import { AuthRetailerGuard } from '../guards/AuthRetailerGuard';
import { AuthStandardUserGuard } from '../guards/AuthStandardUserGuard';
import { AuthWholeSalerGuard } from '../guards/AuthWholeSalerGuard';

import { UnScheduledVehiclesByStorageCapacityComponent } from '../metricsreporting/unscheduledVehiclesByStorageCapacity/unscheduledVehiclesByStorageCapacity.component';
import { ScheduledVehiclesByStorageCapacityComponent }  from '../metricsreporting/scheduledVehiclesByStorageCapacity/scheduledVehiclesByStorageCapacity.component';
import { FoodHubCommoditiesStockStorageUsageComponent } from '../metricsreporting/foodHubCommoditiesStockStorageUsage/foodHubCommoditiesStockStorageUsage.component';
import { AllFoodHubCommoditiesStockStorageUsageComponent } from '../metricsreporting/allFoodHubCommoditiesStockStorageUsage/allFoodHubCommoditiesStockStorageUsage.component';
import { Top5DryCommoditiesInDemandRatingAccordingToStorageComponent } from '../metricsreporting/top5DryCommoditiesInDemandRatingAccordingToStorage/top5DryCommoditiesInDemandRatingAccordingToStorage.component';
import { Top5RefreigeratedCommoditiesInDemandRatingAccordingToStorageComponent } from '../metricsreporting/top5RefreigeratedCommoditiesInDemandRatingAccordingToStorage/top5RefreigeratedCommoditiesInDemandRatingAccordingToStorage.component';
import { Top5FarmerCommoditiesAnalysisInUnitPricingComponent } from '../metricsreporting/top5FarmerCommoditiesAnalysisInUnitPricing/top5FarmerCommoditiesAnalysisInUnitPricing.component';
import { IntermediateScheduleComponent } from './crud-operations/intermediate-schedules/intermediateschedules.component';
import { TwitterProfileFeedsComponent } from '../socialmedia/twitterfeeds/twitterprofilefeeds.component';
import { Top5CommodityAndQuantityComponent } from '../metricsreporting/Top5CommodityAndQuantity/Top5CommodityAndQuantity.component';
import { Top5CommodityAndGrossReturnsComponent } from '../metricsreporting/Top5CommodityAndGrossReturns/Top5CommodityAndGrossReturns.component';
import { Top5FarmerCommodityAndGrossReturnsComponent } from '../metricsreporting/Top5FarmerCommodityAndGrossReturns/Top5FarmerCommodityAndGrossReturns.component';
import { Top5FarmerCommodityAndQuantityComponent } from '../metricsreporting/Top5FarmerCommodityAndQuantity/Top5FarmerCommodityAndQuantity.component';
import { Top5FarmerVehicleCategoryUsageByNumberComponent } from '../metricsreporting/Top5FarmerVehicleCategoryUsageByNumber/Top5FarmerVehicleCategoryUsageByNumber.component';
import { Top5VehicleCostReturnsScheduledByCategoryComponent } from '../metricsreporting/Top5VehicleCostReturnsScheduledByCategory/Top5VehicleCostReturnsScheduledByCategory.component';
import { Top5VehicleNumbersScheduledByCategoryComponent } from '../metricsreporting/Top5VehicleNumbersScheduledByCategory/Top5VehicleNumbersScheduledByCategory.component';
import { ReportingComponent } from './reporting/reporting.component';
import { Top5FarmerVehicleCategoryUsageByCostReturnsComponent } from '../metricsreporting/Top5FarmerVehicleCategoryUsageByCostReturns/Top5FarmerVehicleCategoryUsageByCostReturns.component';
import { UnpaidInvoicesComponent } from './unpaid-invoices/unpaidinvoices.component';
import { RecaptchaComponent } from 'ng-recaptcha';
import { myRecaptchaComponent } from './recaptcha/recaptcha.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ActiveCrudOperationsComponent,
    FetchDataComponent,
    LocationComponent,
    VehicleComponent,
    AddVehicleComponent,
    AddLocationComponent,
    LoginComponent,
    ForgotPasswordComponent,
    RegisterComponent,
    ForgotPasswordComponent,
    PayByInstallmentsComponent,
    TransportPricingComponent,
    UserRolesComponent,
    ContactUsComponent,
    AboutUsComponent,
    SectionsContactComponent,
    PayPalSuccessComponent,
    PayPalFailureComponent,
    NewRolesComponent,
    QrCodeComponent,
    AddressComponent,
    LocationComponent,
    CompanyComponent,
    FarmerComponent,
    FoodHubComponent,
    FoodHubStorageComponent,
    CommodityComponent,
    CommodityCategoryComponent,
    VehicleComponent,
    vehicleCategoryComponent,
    DriverComponent,
    TransportScheduleComponent,
    CommodityUnitComponent,
    VehicleCapacityComponent,
    SuccessComponent,
    FailureComponent,
    AdministratorRoleComponent,
    DriverRoleComponent,
    FarmerRoleComponent,
    GovernmentRoleComponent,
    GuestRoleComponent,
    RetailerRoleComponent,
    StandardUserRoleComponent,
    WholeSalerRoleComponent,
    IntermediateScheduleComponent,
    VehicleMonitorComponent,
    TwitterProfileFeedsComponent,
    BasketComponent,
    DriverCalendarComponent,
    ReportingComponent,
    UnpaidInvoicesComponent,

    UnScheduledVehiclesByStorageCapacityComponent,
    ScheduledVehiclesByStorageCapacityComponent,
    FoodHubCommoditiesStockStorageUsageComponent,
    AllFoodHubCommoditiesStockStorageUsageComponent,
    Top5DryCommoditiesInDemandRatingAccordingToStorageComponent,
    Top5RefreigeratedCommoditiesInDemandRatingAccordingToStorageComponent,
    Top5FarmerCommoditiesAnalysisInUnitPricingComponent,

    Top5CommodityAndQuantityComponent,
    Top5CommodityAndGrossReturnsComponent,
    Top5FarmerCommodityAndGrossReturnsComponent,
    Top5FarmerCommodityAndQuantityComponent,
    Top5FarmerVehicleCategoryUsageByNumberComponent,
    Top5VehicleCostReturnsScheduledByCategoryComponent,
    Top5VehicleNumbersScheduledByCategoryComponent,
    Top5FarmerVehicleCategoryUsageByCostReturnsComponent,
    myRecaptchaComponent
    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'basket', component: BasketComponent },
      { path: 'crud', component: ActiveCrudOperationsComponent, canActivate:[AuthGuard] },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthGuard]},
      { path: 'schedules-admin', component: TransportScheduleComponent, canActivate: [AuthGuard] },
      { path: 'schedules-pricing', component: TransportPricingComponent, canActivate: [AdminAuthGuard] },
      { path: 'add-location', component: LocationComponent, canActivate: [AdminAuthGuard] },
      { path: 'add-vehicle', component: VehicleComponent, canActivate: [AdminAuthGuard] },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'scanqrcode', component: QrCodeComponent, canActivate:[AuthGuard] },
      { path: 'forgot-password', component: ForgotPasswordComponent },
      { path: 'make-Payments', component: PayByInstallmentsComponent, canActivate: [AuthGuard] },
      { path: 'transport-pricing', component: TransportPricingComponent, canActivate: [AdminAuthGuard]},
      { path: 'logout', component: HomeComponent },
      { path: 'manage-roles', component: UserRolesComponent, canActivate: [AdminAuthGuard]},
      { path: 'contactus', component: ContactUsComponent },
      { path: 'aboutus', component: AboutUsComponent },
      { path: 'paypal-success', component: PayPalSuccessComponent },
      { path: 'paypal-failure', component: PayPalFailureComponent },
      { path: 'success', component: SuccessComponent },
      { path: 'failure', component: FailureComponent },
      { path: 'Administrator', component: AdministratorRoleComponent, canActivate: [AdminAuthGuard] },
      { path: 'Driver', component: DriverRoleComponent, canActivate: [AuthDriverGuard] },
      { path: 'Farmer', component: FarmerRoleComponent, canActivate: [AuthFarmerGuard] },
      { path: 'Government', component: GovernmentRoleComponent, canActivate: [AuthGovernmentGuard] },
      { path: 'Guest', component: GuestRoleComponent, canActivate: [AuthGuestGuard] },
      { path: 'Retailer', component: RetailerRoleComponent, canActivate: [AuthRetailerGuard] },
      { path: 'StandardUser', component: StandardUserRoleComponent, canActivate: [AuthStandardUserGuard] },
      { path: 'Wholesaler', component: WholeSalerRoleComponent, canActivate: [AuthWholeSalerGuard] },
      { path: 'monitorvehicles', component: VehicleMonitorComponent, canActivate: [AuthGuard] },
      { path: 'addintermediateschedule', component: IntermediateScheduleComponent, canActivate: [AuthGuard] },
      { path: 'allFoodHubCommoditiesStockStorageUsage', component: AllFoodHubCommoditiesStockStorageUsageComponent, canActivate: [AuthGuard] },
      { path: 'foodHubByIdCommoditiesStockStorageUsage', component: FoodHubCommoditiesStockStorageUsageComponent, canActivate: [AuthGuard] },
      { path: 'top5DryInDemandByStorageUsage', component: Top5DryCommoditiesInDemandRatingAccordingToStorageComponent, canActivate: [AuthGuard] },
      { path: 'top5RefreigeratedInDemandByStorageUsage', component: Top5RefreigeratedCommoditiesInDemandRatingAccordingToStorageComponent, canActivate: [AuthGuard] },
      { path: 'top5FarmerCommoditiesunitpricing', component: Top5FarmerCommoditiesAnalysisInUnitPricingComponent, canActivate: [AuthGuard] },
      { path: 'top5FarmerCommodScheduledvehiclesByStorageCapacity', component: ScheduledVehiclesByStorageCapacityComponent, canActivate: [AuthGuard] },
      { path: 'unscheduledvehiclesByStorageCapacity', component: UnScheduledVehiclesByStorageCapacityComponent, canActivate: [AuthGuard] },
      { path: 'reporting', component: ReportingComponent, canActivate: [AuthGuard] },
      { path: 'unpaid-invoices', component: UnpaidInvoicesComponent, canActivate: [AuthGuard] },
      { path: 'drivercalendarschedule', component: DriverCalendarComponent, canActivate: [AuthGuard] }
   ])
  ],
  providers: [{ provide: AdminAuthGuard, useClass: AdminAuthGuard }, 
    { provide: AuthDriverGuard, useClass: AuthDriverGuard },
    { provide: AuthFarmerGuard, useClass: AuthFarmerGuard },
    { provide: AuthGovernmentGuard, useClass: AuthGovernmentGuard },
    { provide: AuthGuestGuard, useClass: AuthGuestGuard },
    { provide: AuthRetailerGuard, useClass: AuthRetailerGuard },
    { provide: AuthStandardUserGuard, useClass: AuthStandardUserGuard },
    { provide: AuthWholeSalerGuard, useClass: AuthWholeSalerGuard },
    { provide: AuthGuard, useClass: AuthGuard },
    { provide: HttpClient, useClass: HttpClient },
    { provide: AfricanFarmerCommoditiesService, useClass: AfricanFarmerCommoditiesService },
    { provide: HTTP_INTERCEPTORS,useClass: AppInterceptor, multi: true},
    { provide: APP_BASE_HREF, useValue: '/africanfarmerscommodities/' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
