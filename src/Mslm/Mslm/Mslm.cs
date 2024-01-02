using System;
using System.Net.Http;
using Mslm.EmailVerifyNS;
using Mslm.OtpNS;
using Mslm.LibNS;

namespace Mslm.MslmNS
{
    public class Init
    {
        // Common util class.
        public Lib LibClient { get; private set; }

        // The Email Verify API client.
        public EmailVerify EmailVerifyClient { get; private set; }
        public Otp OtpClient { get; private set; }

        public Init()
        {
            EmailVerifyClient = new EmailVerify();
            OtpClient = new Otp();
            LibClient = new Lib();
        }

        public Init(string apiKey)
        {
            EmailVerifyClient = new EmailVerify(apiKey);
            OtpClient = new Otp(apiKey);
            LibClient = new Lib(apiKey);
        }

        public void SetHttpClient(HttpClient httpClient)
        {
            EmailVerifyClient.SetHttpClient(httpClient);
            OtpClient.SetHttpClient(httpClient);
            LibClient.SetHttpClient(httpClient);
        }

        public void SetBaseUrl(string baseUrlStr)
        {
            EmailVerifyClient.SetBaseUrl(baseUrlStr);
            OtpClient.SetBaseUrl(baseUrlStr);
            LibClient.SetBaseUrl(baseUrlStr);
        }

        public void SetUserAgent(string userAgent)
        {
            EmailVerifyClient.SetUserAgent(userAgent);
            OtpClient.SetUserAgent(userAgent);
            LibClient.SetUserAgent(userAgent);
        }

        public void SetApiKey(string apiKey)
        {
            EmailVerifyClient.SetApiKey(apiKey);
            OtpClient.SetApiKey(apiKey);
            LibClient.SetApiKey(apiKey);
        }
    }
}
