using Mslm.LibNS;
using Newtonsoft.Json;

namespace Mslm.OtpNS
{
    /// <summary>
    /// Provides functionality for One-Time Password (OTP) operations using the Mslm API.
    /// </summary>
    public class Otp
    {
        private readonly Lib _lib;

        public Otp()
        {
            _lib = new Lib();
        }

        public Otp(string apiKey)
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
        /// Sends an OTP to a specified phone number.
        /// </summary>
        /// <param name="otpSendReq">The request containing the OTP sending details.</param>
        /// <returns>A task that represents the asynchronous operation and returns the OTP send response.</returns>
        /// <exception cref="ArgumentException">Thrown when the phone number is missing in the request.</exception>
        public async Task<OtpSendResp> Send(OtpSendReq otpSendReq)
        {

            if (string.IsNullOrEmpty(otpSendReq.Phone))
            {
                throw new ArgumentException("Phone number is required for OTP request.");
            }

            var opts = new ReqOpts
            {
                ApiKey = _lib.ApiKey,
                BaseUrl = _lib.BaseUrl,
                Http = _lib.Http,
                UserAgent = _lib.UserAgent,
            };

            // Prepare query parameters including the API key.
            var queryParams = new Dictionary<string, string>
            {
                ["apikey"] = opts.ApiKey
            };

            var url = _lib.PrepareUrl("/api/otp/v1/send", queryParams, opts);
            var data = JsonConvert.SerializeObject(otpSendReq);

            return await _lib.ReqAndResp<OtpSendResp>("POST", url, opts, data);
        }

        /// <summary>
        /// Sends an OTP to a specified phone number using specified request options.
        /// </summary>
        /// <param name="otpSendReq">The request containing the OTP sending details.</param>
        /// <param name="opts">The request options for sending the OTP.</param>
        /// <returns>A task that represents the asynchronous operation and returns the OTP send response.</returns>
        /// <exception cref="ArgumentException">Thrown when the phone number is missing in the request.</exception>
        public async Task<OtpSendResp> Send(OtpSendReq otpSendReq, OtpSendReqOpts opts)
        {

            if (string.IsNullOrEmpty(otpSendReq.Phone))
            {
                throw new ArgumentException("Phone number is required for OTP request.");
            }

            OtpSendReqOpts opt = opts ?? new OtpSendReqOpts();

            // Prepare query parameters including the API key.
            var queryParams = new Dictionary<string, string>
            {
                ["apikey"] = opt.ReqOpts.ApiKey
            };

            var url = _lib.PrepareUrl("/api/otp/v1/send", queryParams, opt.ReqOpts);
            var data = JsonConvert.SerializeObject(otpSendReq);

            return await _lib.ReqAndResp<OtpSendResp>("POST", url, opt.ReqOpts, data);
        }

        /// <summary>
        /// Verifies an OTP token for a specified phone number.
        /// </summary>
        /// <param name="otpTokenVerifyReq">The request containing the OTP token verification details.</param>
        /// <returns>A task that represents the asynchronous operation and returns the OTP token verification response.</returns>
        /// <exception cref="ArgumentException">Thrown when the phone number or token is missing in the request.</exception>
        public async Task<OtpTokenVerifyResp> Verify(OtpTokenVerifyReq otpTokenVerifyReq)
        {
            if (string.IsNullOrEmpty(otpTokenVerifyReq.Phone))
            {
                throw new ArgumentException("Phone number is required for OTP request.");
            }
            else if (string.IsNullOrEmpty(otpTokenVerifyReq.Token))
            {
                throw new ArgumentException("Token is required for OTP request.");
            }

            var opts = new ReqOpts
            {
                ApiKey = _lib.ApiKey,
                BaseUrl = _lib.BaseUrl,
                Http = _lib.Http,
                UserAgent = _lib.UserAgent,
            };

            // Prepare query parameters including the API key.
            var queryParams = new Dictionary<string, string>
            {
                ["apikey"] = opts.ApiKey
            };

            var url = _lib.PrepareUrl("/api/otp/v1/token_verify", queryParams, opts);
            var data = JsonConvert.SerializeObject(otpTokenVerifyReq);

            return await _lib.ReqAndResp<OtpTokenVerifyResp>("POST", url, opts, data);
        }

        /// <summary>
        /// Verifies an OTP token for a specified phone number using specified request options.
        /// </summary>
        /// <param name="otpTokenVerifyReq">The request containing the OTP token verification details.</param>
        /// <param name="opts">The request options for verifying the OTP token.</param>
        /// <returns>A task that represents the asynchronous operation and returns the OTP token verification response.</returns>
        /// <exception cref="ArgumentException">Thrown when the phone number or token is missing in the request.</exception>
        public async Task<OtpTokenVerifyResp> Verify(OtpTokenVerifyReq otpTokenVerifyReq, OtpTokenVerifyReqOpts opts)
        {
            if (string.IsNullOrEmpty(otpTokenVerifyReq.Phone))
            {
                throw new ArgumentException("Phone number is required for OTP request.");
            }
            else if (string.IsNullOrEmpty(otpTokenVerifyReq.Token))
            {
                throw new ArgumentException("Token is required for OTP request.");
            }

            OtpTokenVerifyReqOpts opt = opts ?? new OtpTokenVerifyReqOpts();

            // Prepare query parameters including the API key.
            var queryParams = new Dictionary<string, string>
            {
                ["apikey"] = opt.ReqOpts.ApiKey
            };

            var url = _lib.PrepareUrl("/api/otp/v1/token_verify", queryParams, opt.ReqOpts);
            var data = JsonConvert.SerializeObject(otpTokenVerifyReq);

            return await _lib.ReqAndResp<OtpTokenVerifyResp>("POST", url, opt.ReqOpts, data);
        }
    }
}
