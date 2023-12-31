using Mslm.Lib;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace Mslm.EmailVerify
{
    public class SingleVerify
    {
        private Util _util;

        public SingleVerify()
        {
            _util = new Util();
        }

        public SingleVerify(string apiKey)
        {
            _util = new Util(apiKey);
        }

        public void SetHttpClient(HttpClient httpClient)
        {
            _util.SetHttpClient(httpClient);
        }

        public void SetBaseUrl(string baseUrlStr)
        {
            _util.SetBaseUrl(baseUrlStr);
        }

        public void SetUserAgent(string userAgent)
        {
            _util.SetUserAgent(userAgent);
        }

        public void SetApiKey(string apiKey)
        {
            _util.SetApiKey(apiKey);
        }

        public async Task<SingleVerifyResp> Verify(string email)
        {
            var opts = new ReqOpts
            {
                ApiKey = _util.ApiKey,
                BaseUrl = _util.BaseUrl,
                Http = _util.Http,
                UserAgent = _util.UserAgent
            };

            var queryParams = new Dictionary<string, string>
            {
                ["email"] = email
            };

            Uri url = _util.PrepareUrl("/api/sv/v1", queryParams, opts);
            // Console.WriteLine($"URL: {url}");
            // Console.WriteLine($"opts: {opts.BaseUrl}");
            return await _util.ReqAndResp(url, opts);
        }

        public async Task<SingleVerifyResp> Verify(string email, SingleVerifyReqOpts opts)
        {
            SingleVerifyReqOpts opt = opts ?? new SingleVerifyReqOpts();

            // Encode email if not disabled in options.
            if (opt.DisableUrlEncode.HasValue && !opt.DisableUrlEncode.Value)
            {
                email = HttpUtility.UrlEncode(email);
            }

            var queryParams = new Dictionary<string, string>
            {
                ["email"] = email
            };

            Uri url = _util.PrepareUrl("/api/sv/v1", queryParams, opt.ReqOpts);
            return await _util.ReqAndResp(url, opt.ReqOpts);
        }
    }
}
