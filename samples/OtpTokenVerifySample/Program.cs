using System.Threading.Tasks;
using Mslm;
using Mslm.OtpNS;

namespace OtpTokenVerifySample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Example OTP tokeb verify request data.
            var otpVerifyReq = new OtpTokenVerifyReq
            {
                Phone = "03219427983",
                Token = "406378",
                Consume = true
            };

            // To use this sample, add your Mslm API Key to environment variable
            // named "MSLM_API_KEY", or initialize your key string directly.
            string token = Environment.GetEnvironmentVariable("MSLM_API_KEY") ?? "default-api-key";

            var otpVerifyClient = new Otp(token);

            try
            {
                var response = await otpVerifyClient.Verify(otpVerifyReq);
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
