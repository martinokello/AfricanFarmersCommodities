import { Component, Injectable, } from '@angular/core';
import { AfricanFarmerCommoditiesService, IEmailMessage } from '../../services/africanFarmerCommoditiesService';
import { Router } from '@angular/router';
declare const google: any;

@Component({
  selector: 'failure',
  templateUrl: './failure.component.html',
  styleUrls: ['./failure.component.css'],
  providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class FailureComponent {
  public constructor() { }
}
