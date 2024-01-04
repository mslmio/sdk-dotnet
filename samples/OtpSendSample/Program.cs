using System.Threading.Tasks;
using Mslm;
using Mslm.OtpNS;

namespace OtpSendSample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Example OTP send request data.
            var otpSendReq = new OtpSendReq
            {
                Phone = "03219427983",
                TmplSms = "This is your Otp",
                TokenLen = 6,
                ExpireSeconds = 300
            };

            // To use this sample, add your Mslm API Key to environment variable
            // named "MSLM_API_KEY", or initialize your key string directly.
            string token = Environment.GetEnvironmentVariable("MSLM_API_KEY") ?? "default-api-key";

            var otpSendClient = new Otp(token);

            try
            {
                var response = await otpSendClient.Send(otpSendReq);
                Console.WriteLine($"Code: {response.Code}");
                Console.WriteLine($"Msg: {response.Msg}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during OTP operation:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}

