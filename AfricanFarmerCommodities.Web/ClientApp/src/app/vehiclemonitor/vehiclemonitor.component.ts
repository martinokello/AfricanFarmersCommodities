import { Component, OnInit, ViewChild, ElementRef, Injectable, AfterViewInit, Inject } from '@angular/core';
import { AfricanFarmerCommoditiesService, IVehicleLocationMonitor } from '../../services/africanFarmerCommoditiesService';
import 'rxjs/Rx';
import * as $ from "jquery";
import { saveAs } from 'file-saver';
import { Observable } from 'rxjs/Observable';
import * as google from '../../assets/google/googleMaps.js';
declare const google: any;

@Component({
  selector: 'vehicle-monitor',
  templateUrl: './vehiclemonitor.component.html',
  styleUrls: ['./vehiclemonitor.component.css'],
  providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class VehicleMonitorComponent implements OnInit, AfterViewInit {
  public vehicles: IVehicleLocationMonitor[] = [];
  public currentVehicle: IVehicleLocationMonitor;
  private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService | any;
  public markers: any = [];
  public myMap: google.maps.Map;

  public constructor(africanFarmerCommoditiesService: AfricanFarmerCommoditiesService) {

    this.africanFarmerCommoditiesService = africanFarmerCommoditiesService;

    let defaultVehMonitor: IVehicleLocationMonitor = {
      lattitude: 0,
      longitude: 0,
      driverName: 'NO Driver',
      driverPhoneNumber: "N/A",
      vehicleRegistration: "NO Reg"
    };
    this.currentVehicle = defaultVehMonitor;

  }

  public ngAfterViewInit(): void {

    this.getVehiclesHttp();
  }

  public getAndroidMobileLocationApp() {

    let actualResult: Observable<Blob> = this.africanFarmerCommoditiesService.GetDriverMobileLocationApp('android');
    actualResult.map((blob: Blob) => {
      saveAs(blob, 'XamarinForms.locationservice.apk');
    }).subscribe()
  }
  public getIosMobileLocationApp() {

    let actualResult: Observable<Blob> = this.africanFarmerCommoditiesService.GetDriverMobileLocationApp('ios');
    actualResult.map((blob: Blob) => {
      saveAs(blob, 'XamarinForms.locationservice.ipa');
    }).subscribe()
  }
    public getVehiclesHttp(): void {
    //$('div#vehicleView').css('display', 'block').slideDown();
    let actualResult: Observable<IVehicleLocationMonitor[]> = this.africanFarmerCommoditiesService.GetVehicleRealTimeLocations();
    actualResult.map((p: IVehicleLocationMonitor[]) => {
      if (p && p.length > 0) {
        this.vehicles = p;
        let selector: HTMLSelectElement = document.querySelector('select#vhmonitor');

        if (this.vehicles.length > 0 && selector.children.length > 0) {
          selector.querySelector('option').remove();
        }

        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.selected = true;
        optionElem.value = (0).toString();
        optionElem.text = "Select Vehicle";
        selector.append(optionElem);

        this.vehicles.forEach((vhm: IVehicleLocationMonitor, index: number) => {
          let optionElem1: HTMLOptionElement = document.createElement('option');
          optionElem1.value = vhm.vehicleRegistration;
          optionElem1.text = vhm.vehicleRegistration;
          selector.append(optionElem1);
        });

        this.currentVehicle = this.vehicles[0];
      }
      else {
        this.vehicles = [];
        let defaultVehMonitor: IVehicleLocationMonitor = {
          lattitude: 0,
          longitude: 0,
          driverName: 'NO Driver',
          driverPhoneNumber: "N/A",
          vehicleRegistration: "NO Reg"
        };
        this.currentVehicle = defaultVehMonitor;
      }
      this.vehiclePlotOnMap();

    }).subscribe();
  }

  public ngOnInit(): void {
    this.myMap = new google.maps.Map(document.getElementById('monitormap'), {
      center: new google.maps.LatLng(10.3, 12.5),
      zoom: 8,
      mapTypeId: google.maps.MapTypeId.ROADMAP
    });
  }

  public vehiclePlotOnMap() {

    if (this.markers != null && this.markers.length > 0) {
      this.clearMarkers();
    }
    for (let n = 0; n < this.vehicles.length; n++) {
      let vehMonitor: IVehicleLocationMonitor = this.vehicles[n];
      this.initMap(vehMonitor);
    }
  }
  public initMap(vehMonitor: IVehicleLocationMonitor): void {

    let marker = new google.maps.Marker({
      position: new google.maps.LatLng(parseFloat(`${vehMonitor.lattitude}`), parseFloat(`${vehMonitor.longitude}`)),
      title: vehMonitor.driverName + ", " + vehMonitor.vehicleRegistration,
      map: this.myMap
    });

    // Attaching a click event to the current marker
    google.maps.event.addListener(marker, 'click', (function (marker, map, vehMonitor) {
        let infowindow = new google.maps.InfoWindow({
          content: "<p>Marker Location:" + marker.getPosition().lat().toString()+","+marker.getPosition().lng().toString()  + "</p><p>" + vehMonitor.vehicleRegistration + "</p><p>" + vehMonitor.driverPhoneNumber + "</p><p>" + vehMonitor.driverName + "</p>"
        });
      infowindow.open(map, marker);
    })(marker, this.myMap, vehMonitor));

    //marker.setMap(this.myMap);
    this.markers.push(marker);
  }
  clearMarkers() {
    this.markers = [];
  }

  showVehicle(): void {

    let currentVehReg: string = this.currentVehicle.vehicleRegistration;
    let selectedVe = this.vehicles.find(v => v.vehicleRegistration == currentVehReg);

    this.markers.forEach((mrk: google.maps.Marker, index: number) => {
      mrk.setMap(null);
    });
    this.markers = [];
    this.initMap(selectedVe);
  }
  showAllVehicles() {
    this.markers = [];
    this.vehiclePlotOnMap();
  }
  removeVehicle() {
    let currentVehReg: string = this.currentVehicle.vehicleRegistration;
    let index: number = -1;
    let selectedVeh = this.vehicles.find((v, n) => {
      index = n;
      return v.vehicleRegistration == currentVehReg
    });
    this.markers = [];
    this.vehicles.splice(index);
    let result: Observable<any> = this.africanFarmerCommoditiesService.RemoveVehicleFromMonitor(selectedVeh);
    result.map((res: any) => {
      alert(res.message);
      this.showAllVehicles();
    }).subscribe();

  }

}
