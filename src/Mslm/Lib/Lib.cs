using System.Text;
using Newtonsoft.Json;
using System.Web;
using Mslm.EmailVerifyNS;

namespace Mslm.LibNS
{
    /// <summary>
    /// Provides a base library class for handling common operations such as HTTP requests.
    /// </summary>
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

        /// <summary>
        /// Sets the HttpClient used for making requests.
        /// </summary>
        /// <param name="httpClient">The HttpClient instance to use.</param>
        public void SetHttpClient(HttpClient httpClient)
        {
            Http = httpClient;
        }

        /// <summary>
        /// Sets the base URL for API requests.
        /// </summary>
        /// <param name="baseUrlStr">The base URL string.</param>
        public void SetBaseUrl(string baseUrlStr)
        {
            BaseUrl = new Uri(baseUrlStr);
        }

        /// <summary>
        /// Sets the User-Agent header for HTTP requests.
        /// </summary>
        /// <param name="userAgent">The User-Agent string.</param>
        public void SetUserAgent(string userAgent)
        {
            UserAgent = userAgent;
        }

        /// <summary>
        /// Sets the API key for the service.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        public void SetApiKey(string apiKey)
        {
            ApiKey = apiKey;
        }

        /// <summary>
        /// Constructs the User-Agent string for the service.
        /// </summary>
        /// <param name="pkg">The package name or identifier.</param>
        /// <returns>A string representing the User-Agent.</returns>
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

        /// <summary>
        /// Prepares the URL for making a request by appending query parameters.
        /// </summary>
        /// <param name="urlPath">The path segment of the URL.</param>
        /// <param name="queryParams">The query parameters to append.</param>
        /// <param name="opts">The request options containing the base URL.</param>
        /// <returns>A <see cref="Uri"/> object representing the full URL.</returns>
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

        // <summary>
        /// Makes an HTTP request and returns the deserialized response.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the response to.</typeparam>
        /// <param name="method">The HTTP method to use for the request.</param>
        /// <param name="url">The URL to send the request to.</param>
        /// <param name="opts">The request options.</param>
        /// <param name="data">The data to send in the body of the request.</param>
        /// <returns>A task that represents the asynchronous operation and contains the deserialized response.</returns>
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
