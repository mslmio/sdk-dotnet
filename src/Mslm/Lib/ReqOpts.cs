namespace Mslm.LibNS
{
    /// <summary>
    /// Represents the options for making HTTP requests, encapsulating various configurations like
    /// API keys, base URLs, user agents, and HTTP clients.
    /// </summary>
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
            UserAgent = Lib.GetUserAgent("mslm");
            ApiKey = "";
        }

        public ReqOpts(HttpClient http, Uri baseUrl, string userAgent, string apiKey)
        {
            Http = http;
            BaseUrl = baseUrl;
            UserAgent = userAgent;
            ApiKey = apiKey;
        }
    }
}
