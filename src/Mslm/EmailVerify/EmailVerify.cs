using Mslm.LibNS;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace Mslm.EmailVerifyNS
{
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
