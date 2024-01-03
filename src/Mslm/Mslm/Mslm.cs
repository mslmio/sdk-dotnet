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
        public EmailVerify EmailVerifyClient { get; private set; }

        // The Otp API client
        public Otp OtpClient { get; private set; }

        public MslmClient()
        {
            EmailVerifyClient = new EmailVerify();
            OtpClient = new Otp();
            LibClient = new Lib();
        }

        public MslmClient(string apiKey)
        {
            EmailVerifyClient = new EmailVerify(apiKey);
            OtpClient = new Otp(apiKey);
            LibClient = new Lib(apiKey);
        }

        /// <summary>
        /// Sets the HttpClient used for making requests.
        /// </summary>
        /// <param name="httpClient">The HttpClient instance to use.</param>
        public void SetHttpClient(HttpClient httpClient)
        {
            EmailVerifyClient.SetHttpClient(httpClient);
            OtpClient.SetHttpClient(httpClient);
            LibClient.SetHttpClient(httpClient);
        }

        /// <summary>
        /// Sets the base URL for API requests.
        /// </summary>
        /// <param name="baseUrlStr">The base URL string.</param>
        public void SetBaseUrl(string baseUrlStr)
        {
            EmailVerifyClient.SetBaseUrl(baseUrlStr);
            OtpClient.SetBaseUrl(baseUrlStr);
            LibClient.SetBaseUrl(baseUrlStr);
        }

        /// <summary>
        /// Sets the User-Agent header for HTTP requests.
        /// </summary>
        /// <param name="userAgent">The User-Agent string.</param>
        public void SetUserAgent(string userAgent)
        {
            EmailVerifyClient.SetUserAgent(userAgent);
            OtpClient.SetUserAgent(userAgent);
            LibClient.SetUserAgent(userAgent);
        }

        /// <summary>
        /// Sets the API key for the service.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        public void SetApiKey(string apiKey)
        {
            EmailVerifyClient.SetApiKey(apiKey);
            OtpClient.SetApiKey(apiKey);
            LibClient.SetApiKey(apiKey);
        }
    }
}
