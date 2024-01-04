using Mslm.EmailVerifyNS;
using Mslm.OtpNS;
using Mslm.LibNS;

namespace Mslm.MslmNS
{
    /// <summary>
    /// Represents the main client for the Mslm SDK, providing access to Email Verification and OTP services.
    /// </summary>
    public class MslmClient
    {
        // Common util class.
        public Lib LibClient { get; private set; }

        // The Email Verify API client.
        public EmailVerify EmailVerify { get; private set; }

        // The Otp API client
        public Otp Otp { get; private set; }

        public MslmClient()
        {
            EmailVerify = new EmailVerify();
            Otp = new Otp();
            LibClient = new Lib();
        }

        public MslmClient(string apiKey)
        {
            EmailVerify = new EmailVerify(apiKey);
            Otp = new Otp(apiKey);
            LibClient = new Lib(apiKey);
        }

        /// <summary>
        /// Sets the HttpClient used for making requests.
        /// </summary>
        /// <param name="httpClient">The HttpClient instance to use.</param>
        public void SetHttpClient(HttpClient httpClient)
        {
            EmailVerify.SetHttpClient(httpClient);
            Otp.SetHttpClient(httpClient);
            LibClient.SetHttpClient(httpClient);
        }

        /// <summary>
        /// Sets the base URL for API requests.
        /// </summary>
        /// <param name="baseUrlStr">The base URL string.</param>
        public void SetBaseUrl(string baseUrlStr)
        {
            EmailVerify.SetBaseUrl(baseUrlStr);
            Otp.SetBaseUrl(baseUrlStr);
            LibClient.SetBaseUrl(baseUrlStr);
        }

        /// <summary>
        /// Sets the User-Agent header for HTTP requests.
        /// </summary>
        /// <param name="userAgent">The User-Agent string.</param>
        public void SetUserAgent(string userAgent)
        {
            EmailVerify.SetUserAgent(userAgent);
            Otp.SetUserAgent(userAgent);
            LibClient.SetUserAgent(userAgent);
        }

        /// <summary>
        /// Sets the API key for the service.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        public void SetApiKey(string apiKey)
        {
            EmailVerify.SetApiKey(apiKey);
            Otp.SetApiKey(apiKey);
            LibClient.SetApiKey(apiKey);
        }
    }
}
