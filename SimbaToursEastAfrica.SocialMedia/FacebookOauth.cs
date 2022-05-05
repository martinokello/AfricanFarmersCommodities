using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using MartinLayooInc.SocialMedia;
using Microsoft.Extensions.Primitives;

namespace MartinLayooInc.SocialMedia
{
    public enum Method { GET, POST };
    public class FacebookOauth<T> where T:class
    {
        public const string AUTHORIZE = "https://graph.facebook.com/v2.1/oauth/authorize";
        public const string ACCESS_TOKEN = "https://graph.facebook.com/v2.1/oauth/access_token";
        public const string CALLBACK_URL = "http://martinlayooinc.net/Home/AboutUs";
        private string _consumerKey = "992667847534750";
        private string _consumerSecret = "6b9afdd94048c2d849616cb64e607f19";
        private string _token = "";

        #region Properties

        public string ConsumerKey
        {
            get
            {
                if (_consumerKey.Length == 0)
                {
                    _consumerKey = "1111111111111"; //Your application ID
                }
                return _consumerKey;
            }
            set { _consumerKey = value; }
        }

        public string ConsumerSecret
        {
            get
            {
                if (_consumerSecret.Length == 0)
                {
                    _consumerSecret = "11111111111111111111111111111111"; //Your application secret
                }
                return _consumerSecret;
            }
            set { _consumerSecret = value; }
        }

        public string Token { get { return _token; } set { _token = value; } }

        #endregion

        /// <summary>
        /// Get the link to Facebook's authorization page for this application.
        /// </summary>
        /// <returns>The url with a valid request token, or a null string.</returns>
        public string AuthorizationLinkGet()
        {
            return string.Format("{0}?client_id={1}&redirect_uri={2}", AUTHORIZE, this.ConsumerKey, CALLBACK_URL);
        }

        public T GetFBJsonString(string code)
        {
            T json = default(T);
            string url = "";
            
            if (code.Length > 0)
            {
                //We now have the credentials, so we can start making API calls
                this.AccessTokenGet(code);
                url = "https://graph.facebook.com/v2.1/1426912112/posts?limit=100&access_token=" + this.Token;
                json = this.WebRequest(Method.GET, url, string.Empty);
                
            }
            return json;
        }

        /// <summary>
        /// Exchange the Facebook "code" for an access token.
        /// </summary>
        /// <param name="authToken">The oauth_token or "code" is supplied by Facebook's authorization page following the callback.</param>
        public void AccessTokenGet(string authToken)
        {
            string accessTokenUrl = string.Format("{0}?client_id={1}&redirect_uri={2}&client_secret={3}&code={4}",
            ACCESS_TOKEN, this.ConsumerKey, CALLBACK_URL, this.ConsumerSecret, authToken);

            T response = WebRequest(Method.GET, accessTokenUrl, String.Empty);

            if( (response as string).Length > 0)
            {
                var uri = (response as HttpWebResponse).ResponseUri;
                //Store the returned access_token
                var qs = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(uri.Query);
                var values  = new StringValues();
                if (qs.TryGetValue("access_token",out values))
                {
                    Token = values.FirstOrDefault();
                }
            }
        }

        /// <summary>
        /// Web Request Wrapper
        /// </summary>
        /// <param name="method">Http Method</param>
        /// <param name="url">Full url to the web resource</param>
        /// <param name="postData">Data to post in querystring format</param>
        /// <returns>The web server response.</returns>
        public T WebRequest(Method method, string url, string postData)
        {

            HttpWebRequest webRequest = null;
            StreamWriter requestWriter = null;
            T responseData = null;

            webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = method.ToString();
            webRequest.ServicePoint.Expect100Continue = false;
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:12.0) Gecko/20100101 Firefox/12.0";
            webRequest.Timeout = 20000;

            if (method == Method.POST)
            {
                webRequest.ContentType = "application/x-www-form-urlencoded";

                //POST the data.
                requestWriter = new StreamWriter(webRequest.GetRequestStream());

                try
                {
                    requestWriter.Write(postData);
                }
                catch(Exception e)
                {
                    throw;
                }

                finally
                {
                    requestWriter.Close();
                    requestWriter = null;
                }
            }

            responseData = WebResponseGet(webRequest);
            webRequest = null;
            return responseData;
        }

        /// <summary>
        /// Process the web response.
        /// </summary>
        /// <param name="webRequest">The request object.</param>
        /// <returns>The response data.</returns>
        public T WebResponseGet(HttpWebRequest webRequest)
        {
            StreamReader responseReader = null;
            T responseData = default(T);

            try
            {
                responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                responseData = responseReader.ReadToEnd() as T;
            }
            catch(Exception ex)
            {

            }
            finally
            {
                webRequest.GetResponse().GetResponseStream().Close();
                responseReader.Close();
                responseReader = null;
            }

            return responseData;
        }
    }

}