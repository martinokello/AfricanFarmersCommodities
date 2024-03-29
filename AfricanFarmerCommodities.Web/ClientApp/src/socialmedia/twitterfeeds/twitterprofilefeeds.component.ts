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
    let twitterFeeds: Observable<any[]> = this.africanFarmerCommoditiesService.GetCivilEngineeringFeeds();
    debugger;
    twitterFeeds.toPromise().then((feed: any[]) => {
      document.querySelector('h3#tweetheader').innerHTML = "Civil Engineering Rss Feeds";

      if (feed.length > 2) {

        document.querySelector('h4#feed1').innerHTML = feed[0].title;
        document.querySelector('h4#feed2').innerHTML = feed[1].title;
        document.querySelector('h4#feed3').innerHTML = feed[2].title;
        document.querySelector('p#tweet1').innerHTML = feed[0].description + `<p><a href='${feed[0].url}'>${feed[0].url}</a></p>`;
        document.querySelector('p#tweet2').innerHTML = feed[1].description + `<p><a href='${feed[1].url}'>${feed[1].url}</a></p>`;
        document.querySelector('p#tweet3').innerHTML = feed[2].description + `<p><a href='${feed[2].url}'>${feed[2].url}</a></p>`;
      }
      else if (feed.length > 1) {
        document.querySelector('h4#feed1').innerHTML = feed[0].title;
        document.querySelector('h4#feed2').innerHTML = feed[1].title;
        document.querySelector('p#tweet1').innerHTML = feed[0].description + `<p><a href='${feed[0].url}'>${feed[0].url}</a></p>`;
        document.querySelector('p#tweet2').innerHTML = feed[1].description + `<p><a href='${feed[1].url}'>${feed[1].url}</a></p>`;
        document.querySelector('p#tweet3').innerHTML = "No rss feeds available";
      }
      else if (feed.length > 0) {
        document.querySelector('h4#feed1').innerHTML = feed[0].title;
        document.querySelector('p#tweet1').innerHTML = feed[0].description + `<p><a href='${feed[0].url}'>${feed[0].url}</a></p>`;
      }
      else {
        document.querySelector('p#tweet1').innerHTML = "<div style='text-align:center !important;'><img src='/images/ug-flag.gif' style='width:40% !important;height:auto !important;' alt='feeds unavailable'/></div>";
        document.querySelector('p#tweet2').innerHTML = "<div style='text-align:center !important;'><img src='/images/HappyGrad.jpg' style='border-radius:10% !important;width:40% !important;height:auto !important;' alt='feeds unavailable'/></div>";
        document.querySelector('p#tweet3').innerHTML = "<div style='text-align:center !important;'><img src='/images/uk-flag.gif' style='width:40% !important;height:auto !important;' alt='feeds unavailable'/></div>";
      }
    }).catch((reason: any) => {
      document.querySelector('p#tweet1').innerHTML = "<div style='text-align:center !important;'><img src='/images/ug-flag.gif' style='width:40% !important;height:auto !important;' alt='feeds unavailable'/></div>";
      document.querySelector('p#tweet2').innerHTML = "<div style='text-align:center !important;'><img src='/images/HappyGrad.jpg' style='border-radius:10% !important;width:40% !important;height:auto !important;' alt='feeds unavailable'/></div>";
      document.querySelector('p#tweet3').innerHTML = "<div style='text-align:center !important;'><img src='/images/uk-flag.gif' style='width:40% !important;height:auto !important;' alt='feeds unavailable'/></div>";
    });
  }
}
