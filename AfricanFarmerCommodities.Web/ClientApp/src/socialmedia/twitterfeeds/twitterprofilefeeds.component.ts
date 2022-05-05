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

    twitterFeeds.map((feed: any[]) => {
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
        document.querySelector('p#tweet1').innerHTML = "No tweets available";
        document.querySelector('p#tweet2').innerHTML = "No tweets available";
        document.querySelector('p#tweet3').innerHTML = "No tweets available";
      }
    }).subscribe();
  }
}
