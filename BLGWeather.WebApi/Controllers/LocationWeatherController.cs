using BLG.Business;
using BLG.Business.Concretes;
using BLGWeather.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BLGWeather.WebApi.Controllers
{
    namespace BLGWeather.WebApi.Controllers
    {
        public class LocationWeatherController : ApiController
        {
            [EnableCors(origins: "*", headers: "*", methods: "*")]
            [System.Web.Http.Route("~/api/LocationWeather/GetLocationWeather/{location}/{countryCode}")]
            public async Task<IHttpActionResult> GetLocationWeather(string location, string countryCode)
            {
                var httpClient = new BGLHttpClient();
                httpClient.HttpRequestClient = new HttpClient();
                BLGLocationWeatherRequests request = new BLGLocationWeatherRequests(httpClient, ConfigurationManager.AppSettings["OpenWeatherMapAPIKey"]);
                try
                {
                    var result = await request.GetLocationWeather(ConfigurationManager.AppSettings["WeatherApiBaseUrl"], new Location { CityName = location, CountryCode = countryCode });

                    if (result == null)
                    {
                        return NotFound();
                    }
                    return Ok(result);
                }
                catch(Exception e)
                {
                    return BadRequest("Bad Result Set!");
                }
            }
        }
    }
}
