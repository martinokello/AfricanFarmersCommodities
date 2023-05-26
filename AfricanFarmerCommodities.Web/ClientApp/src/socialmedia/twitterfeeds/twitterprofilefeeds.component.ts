import { Component, Injectable, } from '@angular/core';
import { AfricanFarmerCommoditiesService, IEmailMessage } from '../../services/africanFarmerCommoditiesService';
import { Router } from '@angular/router';
import { OnInit } from '@angular/core';
import { Observable } from 'rxjs';
declare const google: any;

@Component({
  selector: 'twitter-profile-feeds',
  templateUrl: './twitterprofilefeeds.component.html',
  styleUrls: ['./twitterprofilefeeds.component.css'],
  providers: [AfricanFarmerCommoditiesService]
})
@Injectable()
export class TwitterProfileFeedsComponent implements OnInit{

  public constructor(private africanFarmerCommoditiesService: AfricanFarmerCommoditiesService, private router: Router) {
  }
  ngOnInit(): void {
    let twitterFeeds: Observable<any[]> = this.africanFarmerCommoditiesService.GetTwitterFeeds();

    twitterFeeds.toPromise().then((feed: any[]) => {
      document.querySelector('h3#tweetheader').innerHTML = feed[0].groupHeaderText;

      if (feed.length > 2) {
        document.querySelector('p#tweet1').innerHTML = feed[0].groupDescription;
        document.querySelector('p#tweet2').innerHTML = feed[1].groupDescription;
        document.querySelector('p#tweet3').innerHTML = feed[2].groupDescription;
      }
      else if (feed.length > 1) {
        document.querySelector('p#tweet1').innerHTML = feed[0].groupDescription;
        document.querySelector('p#tweet2').innerHTML = feed[1].groupDescription;
        document.querySelector('p#tweet3').innerHTML = "No tweets available";
      }
      else if (feed.length > 0) {
        document.querySelector('p#tweet1').innerHTML = feed[0].groupDescription;
      }
      else {
        document.querySelector('p#tweet1').innerHTML = "<div style='text-align:center !important;'><img src='/images/ug-flag.gif' style='width:60% !important;height:auto !important;' alt='feeds unavailable'/></div>";
        document.querySelector('p#tweet2').innerHTML = "<div style='text-align:center !important;'><img src='/images/HappyGrad.jpg' style='border-radius:8px !important;width:60% !important;height:auto !important;' alt='feeds unavailable'/></div>";
        document.querySelector('p#tweet3').innerHTML = "<div style='text-align:center !important;'><img src='/images/uk-flag.gif' style='width:60% !important;height:auto !important;' alt='feeds unavailable'/></div>";
     }
    }).catch((reason: any) => {
      document.querySelector('p#tweet1').innerHTML = "<div style='text-align:center !important;'><img src='/images/ug-flag.gif' style='width:60% !important;height:auto !important;' alt='feeds unavailable'/></div>";
      document.querySelector('p#tweet2').innerHTML = "<div style='text-align:center !important;'><img src='/images/HappyGrad.jpg' style='border-radius:8px !important;width:60% !important;height:auto !important;' alt='feeds unavailable'/></div>";
      document.querySelector('p#tweet3').innerHTML = "<div style='text-align:center !important;'><img src='/images/uk-flag.gif' style='width:60% !important;height:auto !important;' alt='feeds unavailable'/></div>";
    });
  }
}
