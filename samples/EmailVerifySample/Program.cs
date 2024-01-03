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
            var emailVerifyClient = new EmailVerify("3f5deea912f8434684af92fbf92a0cd1");

            string emailToVerify = "hak173129@gmail.com";

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
