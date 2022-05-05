using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AfricanFarmersCommodities.ServicesEndPoint.GeneralSevices;
using AfricanFarmerCommodities.UnitOfWork.Concretes;
using AfricanFarmerCommodities.Web.ViewModels;
using AfricanFarmersCommodities.Domain;
using AfricanFarmersCommodities.Services.EmailServices.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AfricanFarmerCommodities.Domain;
using Twitter;
using MartinLayooInc.SocialMedia;
using SimbaToursEastAfrica.Caching;
using AfricanFarmersCommodities.AppConfigurations;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Cors;

namespace AfricanFarmerCommodities.Web.Controllers
{
    [EnableCors(PolicyName = "CorsPolicy")]
    public class SocialMediaController : Controller
    {
        private IConfigurationSection _applicationConstants;
        private IConfigurationSection _businessSmtpDetails;
        private IConfigurationSection _twitterProfileFiguration;
        private IMailService _emailService;
        private AfricanFarmerCommoditiesUnitOfWork _unitOfWork;
        private Mapper _Mapper;

        public SocialMediaController(IMailService emailService, AfricanFarmerCommoditiesUnitOfWork unitOfWork, Mapper mapper, AppSettingsConfigurations appSettings)
        {
            _applicationConstants = appSettings.AppSettings.GetSection("ApplicationConstants");
            _twitterProfileFiguration = appSettings.AppSettings.GetSection("TwitterProfileFiguration");
            _businessSmtpDetails = appSettings.AppSettings.GetSection("BusinessSmtpDetails");
            _emailService = emailService;
            _unitOfWork = unitOfWork;
            _Mapper = mapper;
        }
        // GET: Twitter Feeds   
        [HttpGet]
        public async Task<IActionResult> TwitterProfileFeeds()
        {
            var caching = new SimbaToursEastAfrica.Caching.Concretes.SimbaToursEastAfricaCahing();

            var twitterEngine = new TwitterProfileFeed<WidgetGroupItemList>();
            twitterEngine.TwitterProfileFiguration = _twitterProfileFiguration;
            var tweets = new WidgetGroupItemList();
            Int32.TryParse(_twitterProfileFiguration["cacheTimeSecs"], out int cacheTimeSecs);
            tweets = await caching.GetOrSaveToCache<WidgetGroupItemList>( _twitterProfileFiguration["cachKey"], cacheTimeSecs, twitterEngine.GetFeeds);

            if (tweets != null && tweets.Any())
            {
                Ok(tweets);
            }
            else if (tweets == null || !tweets.Any())
                tweets = new WidgetGroupItemList();
            return Ok(tweets);

        }
    }
}
