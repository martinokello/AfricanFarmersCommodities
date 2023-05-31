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
using System.Xml.Linq;
using System.Runtime.CompilerServices;
using BLG.Business.Interfaces;
using System.Net.Http;
using SimbaToursEastAfrica.Caching.Interfaces;
using System.Web.Http.Results;
using System.Reflection.PortableExecutable;

namespace AfricanFarmerCommodities.Web.Controllers
{
    [EnableCors(PolicyName = "CorsPolicy")]
    public class SocialMediaController : Controller
    {
        private IConfigurationSection _applicationConstants;
        private IConfigurationSection _businessSmtpDetails;
        private IConfigurationSection _twitterProfileFiguration;
        private IConfiguration _appSettings;
        private IMailService _emailService;
        private AfricanFarmerCommoditiesUnitOfWork _unitOfWork;
        private Mapper _Mapper;
        private HttpClient _httpClient;
        private ICaching _caching;

        public SocialMediaController(IMailService emailService, AfricanFarmerCommoditiesUnitOfWork unitOfWork, Mapper mapper, AppSettingsConfigurations appSettings, ICaching caching)
        {
            _applicationConstants = appSettings.AppSettings.GetSection("ApplicationConstants");
            _twitterProfileFiguration = appSettings.AppSettings.GetSection("TwitterProfileFiguration");
            _businessSmtpDetails = appSettings.AppSettings.GetSection("BusinessSmtpDetails");
            _emailService = emailService;
            _unitOfWork = unitOfWork;
            _Mapper = mapper;
            _appSettings = appSettings.AppSettings;
            _httpClient = new HttpClient();
            _caching = caching;
        }
        // GET: Twitter Feeds   
        [HttpGet]
        public async Task<IActionResult> TwitterProfileFeeds()
        {
            try
            {
                var caching = new SimbaToursEastAfrica.Caching.Concretes.SimbaToursEastAfricaCahing();

                var twitterEngine = new TwitterProfileFeed<WidgetGroupItemList>();
                twitterEngine.TwitterProfileFiguration = _twitterProfileFiguration;
                var tweets = new WidgetGroupItemList();
                Int32.TryParse(_twitterProfileFiguration["cacheTimeSecs"], out int cacheTimeSecs);
                tweets = await caching.GetOrSaveToCache<WidgetGroupItemList>(_twitterProfileFiguration["cachKey"], cacheTimeSecs, twitterEngine.GetFeeds);

                if (tweets != null && tweets.Any())
                {
                    Ok(tweets);
                }
                else if (tweets == null || !tweets.Any())
                    tweets = new WidgetGroupItemList();
                return Ok(tweets);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message + System.Environment.NewLine + ex.StackTrace);
            }

        }
        [HttpGet]
        public async Task<RssFeedViewModel[]> GetCivilEngineeringFeeds()
        {

            Func<Task<RssFeedViewModel[]>> GetFromEngFeedsFromCache = async () =>
            {
                var result = await _httpClient.GetStringAsync(_appSettings.GetSection("RealWireCivilEngineeringRssFeeds").Value);
                var xmlDocument = XDocument.Parse(result);
                var rssFeeds = new List<RssFeedViewModel>();
                var img = xmlDocument.Descendants("image").FirstOrDefault();

                var imageUrl = (img != null ? img.Descendants("url").First().Value : "");
                var results = from it in xmlDocument.Descendants("item")
                              select new RssFeedViewModel
                              {
                                  ImageUrl = imageUrl,
                                  Title = it.Descendants("title").FirstOrDefault() != null ?
                                  it.Descendants("title").FirstOrDefault().Value : "",
                                  Description = it.Descendants("description").FirstOrDefault() != null ?
                                  it.Descendants("description").FirstOrDefault().Value : "",
                                  PublishDate = it.Descendants("pubDate").FirstOrDefault() != null ?
                                  it.Descendants("pubDate").FirstOrDefault().Value : "",
                                  Url = it.Descendants("link").FirstOrDefault() != null ?
                                  it.Descendants("link").FirstOrDefault().Value : "",
                              };

                return results.ToArray();
            };



            var results = await _caching.GetOrSaveToCache<RssFeedViewModel[]>("RealWireCivilEngineeringRssFeeds", 15 * 60 * 50, GetFromEngFeedsFromCache);

            return await Task.FromResult(results.Take(3).ToArray());

        }
    }
}
