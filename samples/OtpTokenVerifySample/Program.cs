﻿using System.Threading.Tasks;
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

            var otpVerifyClient = new Otp("3f5deea912f8434684af92fbf92a0cd1");

            try
            {
                var response = await otpVerifyClient.Verify(otpVerifyReq);
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
