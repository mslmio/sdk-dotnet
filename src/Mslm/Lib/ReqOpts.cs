using System;
using System.Net.Http;

namespace Mslm.Lib
{
    public class ReqOpts
    {
        public string ApiKey { get; set; }
        public HttpClient Http { get; set; }
        public Uri BaseUrl { get; set; }
        public string UserAgent { get; set; }

        public ReqOpts()
        {
            Http = new HttpClient();
            BaseUrl = new Uri("https://mslm.io");
            UserAgent = Util.GetUserAgent("mslm");
            ApiKey = "";
        }

        public ReqOpts(HttpClient http, Uri baseUrl, string userAgent, string apiKey)
        {
            Http = http;
            BaseUrl = baseUrl;
            UserAgent = userAgent;
            ApiKey = apiKey;
        }

        // Builder class not required in C# due to object initializer syntax
    }
}
