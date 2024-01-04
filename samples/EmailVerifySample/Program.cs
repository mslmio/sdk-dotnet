using System;
using System.Threading.Tasks;
using Mslm;
using Mslm.EmailVerifyNS;

namespace EmailVerifySample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // To use this sample, add your Mslm API Key to environment variable
            // named "MSLM_API_KEY", or initialize your key string directly.
            string token = Environment.GetEnvironmentVariable("MSLM_API_KEY") ?? "default-api-key";

            var emailVerifyClient = new EmailVerify(token);
            
            // Email to verify.
            string emailToVerify = "abc@gmail.com";

            try
            {
                var response = await emailVerifyClient.SingleVerify(emailToVerify);
                Console.WriteLine($"Code: {response.Code}");
                Console.WriteLine($"Msg: {response.Msg}");
                Console.WriteLine($"Email: {response.Email}");
                Console.WriteLine($"Status: {response.Status}");
                Console.WriteLine($"Username: {response.Username}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during email verification:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
