using Mslm.EmailVerifyNS;
using Mslm.MslmNS;
using Mslm.OtpNS;
using System;
using System.Threading.Tasks;

namespace Mslm
{

    public class Program
    {
        static async Task Main(string[] args)
        {
            var emailVerifyClient = new Mslm.EmailVerifyNS.EmailVerify("aabb947fe09c4ba1bc0deac144db0239");
            var mslmClient = new Mslm.MslmNS.Init("aabb947fe09c4ba1bc0deac144db0239");

            string emailToVerify = "hak173129@gmail.com";

            try
            {
                var result = await emailVerifyClient.SingleVerify(emailToVerify);
                Console.WriteLine($"Result: {result}");
                Console.WriteLine($"Email: {result.Email}");
                Console.WriteLine($"Status: {result.Status}");
                Console.WriteLine($"Username: {result.Username}");

                var result2 = await mslmClient.EmailVerifyClient.SingleVerify(emailToVerify);
                Console.WriteLine($"\nResult mslm client Email: {result2.Email}");

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during email verification:");
                Console.WriteLine(ex.Message);
            }

            // Example OTP send request data
            var otpSendReq = new OtpSendReq
            {
                Phone = "03219427983",
                TmplSms = "Your OTP is Harissss",
                TokenLen = 6,
                ExpireSeconds = 300
            };

            var otpSendClient = new Mslm.OtpNS.Otp("2263d8b149e240569d321516848f526c");

            try
            {
            var sendResponse = await otpSendClient.Send(otpSendReq);
            Console.WriteLine($"OTP Send Response: {sendResponse.Msg}");
            }
            catch (Exception ex)
            {
            Console.WriteLine("An error occurred during OTP operation:");
            Console.WriteLine(ex.Message);
            }

            // Example OTP tokeb verify request data
            var otpVerifyReq = new OtpTokenVerifyReq
            {
                Phone = "03219427983",
                Token = "772839",
                Consume = true
            };

            var otpVerifyClient = new Mslm.OtpNS.Otp("2263d8b149e240569d321516848f526c");

            try
            {
            var sendResponse = await otpVerifyClient.Verify(otpVerifyReq);
            Console.WriteLine($"OTP Send Response: {sendResponse.Msg}");
            Console.WriteLine($"OTP Send Response: {sendResponse.Code}");
            }
            catch (Exception ex)
            {
            Console.WriteLine("An error occurred during OTP operation:");
            Console.WriteLine(ex.Message);
            }
        }
    }
}
