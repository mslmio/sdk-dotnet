using Mslm.LibNS;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mslm.OtpNS
{
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

        public void SetHttpClient(HttpClient httpClient)
        {
            _lib.SetHttpClient(httpClient);
        }

        public void SetBaseUrl(string baseUrlStr)
        {
            _lib.SetBaseUrl(baseUrlStr);
        }

        public void SetUserAgent(string userAgent)
        {
            _lib.SetUserAgent(userAgent);
        }

        public void SetApiKey(string apiKey)
        {
            _lib.SetApiKey(apiKey);
        }

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

            // Prepare query parameters including the API key
            var queryParams = new Dictionary<string, string>
            {
                ["apikey"] = opts.ApiKey
            };

            var url = _lib.PrepareUrl("/api/otp/v1/send", queryParams, opts);
            var data = JsonConvert.SerializeObject(otpSendReq);

            return await _lib.ReqAndResp<OtpSendResp>("POST", url, opts, data);
        }

        public async Task<OtpSendResp> Send(OtpSendReq otpSendReq, OtpSendReqOpts opts)
        {

            if (string.IsNullOrEmpty(otpSendReq.Phone))
            {
                throw new ArgumentException("Phone number is required for OTP request.");
            }

            OtpSendReqOpts opt = opts ?? new OtpSendReqOpts();

            // Prepare query parameters including the API key
            var queryParams = new Dictionary<string, string>
            {
                ["apikey"] = opt.ReqOpts.ApiKey
            };

            var url = _lib.PrepareUrl("/api/otp/v1/send", queryParams, opt.ReqOpts);
            var data = JsonConvert.SerializeObject(otpSendReq);

            return await _lib.ReqAndResp<OtpSendResp>("POST", url, opt.ReqOpts, data);
        }


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

            // Prepare query parameters including the API key
            var queryParams = new Dictionary<string, string>
            {
                ["apikey"] = opts.ApiKey
            };

            var url = _lib.PrepareUrl("/api/otp/v1/token_verify", queryParams, opts);
            var data = JsonConvert.SerializeObject(otpTokenVerifyReq);

            return await _lib.ReqAndResp<OtpTokenVerifyResp>("POST", url, opts, data);
        }

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

            // Prepare query parameters including the API key
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
