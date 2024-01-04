using Mslm.LibNS;

namespace Mslm.EmailVerifyNS
{
    /// <summary>
    /// Provides functionality for verifying email addresses using the Mslm API.
    /// </summary>
    public class EmailVerify
    {
        private readonly Lib _lib;

        public EmailVerify()
        {
            _lib = new Lib();
        }

        public EmailVerify(string apiKey)
        {
            _lib = new Lib(apiKey);
        }

        /// <summary>
        /// Sets the HttpClient used for making requests.
        /// </summary>
        /// <param name="httpClient">The HttpClient instance to use.</param>
        public void SetHttpClient(HttpClient httpClient)
        {
            _lib.SetHttpClient(httpClient);
        }

        /// <summary>
        /// Sets the base URL for API requests.
        /// </summary>
        /// <param name="baseUrlStr">The base URL string.</param>
        public void SetBaseUrl(string baseUrlStr)
        {
            _lib.SetBaseUrl(baseUrlStr);
        }

        /// <summary>
        /// Sets the User-Agent header for HTTP requests.
        /// </summary>
        /// <param name="userAgent">The User-Agent string.</param>
        public void SetUserAgent(string userAgent)
        {
            _lib.SetUserAgent(userAgent);
        }

        /// <summary>
        /// Sets the API key for the service.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        public void SetApiKey(string apiKey)
        {
            _lib.SetApiKey(apiKey);
        }

        /// <summary>
        /// Verifies an email address using the default request options.
        /// </summary>
        /// <param name="email">The email address to verify.</param>
        /// <returns>A task that represents the asynchronous operation and returns the verification response.</returns>
        public async Task<SingleVerifyResp> SingleVerify(string email)
        {
            var opts = new ReqOpts
            {
                ApiKey = _lib.ApiKey,
                BaseUrl = _lib.BaseUrl,
                Http = _lib.Http,
                UserAgent = _lib.UserAgent,
            };

            var queryParams = new Dictionary<string, string>
            {
                ["email"] = email
            };

            Uri url = _lib.PrepareUrl("/api/sv/v1", queryParams, opts);
            var response = await _lib.ReqAndResp<SingleVerifyResp>("GET", url, opts);
            return response;
        }

        /// <summary>
        /// Verifies an email address using specified request options.
        /// </summary>
        /// <param name="email">The email address to verify.</param>
        /// <param name="opts">The request options for verification.</param>
        /// <returns>A task that represents the asynchronous operation and returns the verification response.</returns>
        public async Task<SingleVerifyResp> SingleVerify(string email, SingleVerifyReqOpts opts)
        {
            SingleVerifyReqOpts opt = opts ?? new SingleVerifyReqOpts();

            var queryParams = new Dictionary<string, string>
            {
                ["email"] = email
            };

            Uri url = _lib.PrepareUrl("/api/sv/v1", queryParams, opt.ReqOpts);
            var response = await _lib.ReqAndResp<SingleVerifyResp>("GET", url, opt.ReqOpts);
            return response;
        }
    }
}
