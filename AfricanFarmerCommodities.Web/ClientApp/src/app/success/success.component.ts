import { Component, Injectable, } from '@angular/core';
import { AfricanFarmerCommoditiesService } from '../../services/africanFarmerCommoditiesService';
declare const google: any;

@Component({
  selector: 'success',
  templateUrl: './success.component.html',
  styleUrls: ['./success.component.css'],
  providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class SuccessComponent {
  public constructor() { }
}
