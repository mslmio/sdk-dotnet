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

            var otpSendClient = new Mslm.OtpNS.Otp("aa");

            try
            {
                var response = await otpSendClient.Send(otpSendReq);
                Console.WriteLine($"OTP Send Response Msg: {response.Msg}");
                Console.WriteLine($"OTP Send Response Code: {response.Code}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during OTP operation:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}

