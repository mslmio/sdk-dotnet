using System;
using System.Text;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Web;
using Mslm.EmailVerifyNS;

namespace Mslm.LibNS
{
    public class Lib
    {
        public string ApiKey { get; set; }
        public HttpClient Http { get; set; }
        public Uri BaseUrl { get; set; }
        public string UserAgent { get; set; }

        public Lib()
        {
            ApiKey = "";
            Http = new HttpClient();
            BaseUrl = new Uri("https://mslm.io");
            UserAgent = GetUserAgent("mslm");
        }

        public Lib(string apiKey)
        {
            ApiKey = apiKey;
            Http = new HttpClient();
            BaseUrl = new Uri("https://mslm.io");
            UserAgent = GetUserAgent("mslm");
        }

        public void SetHttpClient(HttpClient httpClient)
        {
            Http = httpClient;
        }

        public void SetBaseUrl(string baseUrlStr)
        {
            BaseUrl = new Uri(baseUrlStr);
        }

        public void SetUserAgent(string userAgent)
        {
            UserAgent = userAgent;
        }

        public void SetApiKey(string apiKey)
        {
            ApiKey = apiKey;
        }

        public static string GetUserAgent(string pkg)
        {
            return $"{pkg}/csharp/1.0.0";
        }

        private string GetMsgForCode(long code)
        {
            return code switch
            {
                401 => "API key not authorized.",
                400 => "Bad request.",
                500 => "Internal Server Error.",
                429 => "Too many requests.",
                200 => "Ok.",
                _ => ""
            };
        }

        public Uri PrepareUrl(string urlPath, Dictionary<string, string> queryParams, ReqOpts opts)
        {
            var baseUri = new Uri(opts.BaseUrl, urlPath);
            var query = HttpUtility.ParseQueryString(string.Empty);

            foreach (var param in queryParams)
            {
                query[param.Key] = param.Value;
            }

            // This will take care of URL encoding of the query parameters.
            string? queryString = query.ToString();

            var uriBuilder = new UriBuilder(baseUri)
            {
                Query = queryString
            };

            return uriBuilder.Uri;
        }

        public async Task<T> ReqAndResp<T>(string method, Uri url, ReqOpts opts, string? data = null) where T : new()
        {
            using var request = new HttpRequestMessage(new HttpMethod(method), url);

            // Add data to the request body for POST and PUT methods.
            if (!string.IsNullOrEmpty(data))
            {
                request.Content = new StringContent(data, Encoding.UTF8, "application/json");

            }

            // Set a valid User-Agent header.
            request.Headers.UserAgent.ParseAdd("mslm-sdk/1.0.0");

            HttpResponseMessage response = await Http.SendAsync(request);

            string jsonData = await response.Content.ReadAsStringAsync();
            T result = JsonConvert.DeserializeObject<T>(jsonData)
                       ?? throw new InvalidOperationException("Deserialization of response returned null.");

            // Handle setting the message based on the code.
            if (result is SingleVerifyResp singleVerifyResp)
            {
                singleVerifyResp.Msg = GetMsgForCode(singleVerifyResp.Code);
            }

            return result;
        }
    }
}
