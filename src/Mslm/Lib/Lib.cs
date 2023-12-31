using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Web;
using Mslm.EmailVerify;

namespace Mslm.Lib
{
    public class Util
    {
        public string ApiKey { get; set; }
        public HttpClient Http { get; set; }
        public Uri BaseUrl { get; set; }
        public string UserAgent { get; set; }

        public Util()
        {
            ApiKey = "";
            Http = new HttpClient();
            BaseUrl = new Uri("https://mslm.io");
            UserAgent = GetUserAgent("mslm");
        }

        public Util(string apiKey)
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

        public Uri PrepareUrl(string urlPath, Dictionary<string, string> queryParams, ReqOpts opts)
        {
            // Assuming BaseUrl is the root URL like "http://localhost:1793"
            var baseUri = new Uri(opts.BaseUrl, urlPath);
            var query = HttpUtility.ParseQueryString(string.Empty);

            foreach (var param in queryParams)
            {
                query[param.Key] = param.Value;
            }

            // This will take care of URL encoding of the query parameters
            string? queryString = query.ToString();

            var uriBuilder = new UriBuilder(baseUri)
            {
                Query = queryString
            };

            return uriBuilder.Uri;
        }

        public async Task<SingleVerifyResp> ReqAndResp(Uri url, ReqOpts opts)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, url);

            // Set a valid User-Agent header
            request.Headers.UserAgent.ParseAdd("mslm-sdk/1.0.0");

            HttpResponseMessage response = await Http.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string jsonData = await response.Content.ReadAsStringAsync();
            // Console.WriteLine($"Raw JSON data: {jsonData}");

            // var jsonObject = JsonConvert.DeserializeObject<JObject>(jsonData);
            // Console.WriteLine($"JSON Object: {jsonObject.ToString()}");

            var result = JsonConvert.DeserializeObject<SingleVerifyResp>(jsonData);

            // Option 1: Throw an exception if result is null
            if (result == null)
            {
                throw new InvalidOperationException("Deserialization of response returned null.");
            }

            return result;
        }
    }
}
