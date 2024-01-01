using Mslm.EmailVerifyNS;
using Mslm.InitNS;
using System;
using System.Threading.Tasks;

namespace Mslm
{

    public class Program
    {
        static async Task Main(string[] args)
        {
            var emailVerifier = new Mslm.EmailVerifyNS.EmailVerify("aabb947fe09c4ba1bc0deac144db0239");
            var mslm = new Mslm.InitNS.Init("aabb947fe09c4ba1bc0deac144db0239");

            emailVerifier.SetBaseUrl("http://localhost:1793");

            string emailToVerify = "hak173129@gmail.com";

            try
            {
                var result = await emailVerifier.SingleVerify(emailToVerify);
                Console.WriteLine($"Result: {result}");
                Console.WriteLine($"Email: {result.Email}");
                Console.WriteLine($"Status: {result.Status}");
                Console.WriteLine($"Username: {result.Username}");

                var result2 = await mslm.EmailVerifier.SingleVerify(emailToVerify);
                Console.WriteLine($"\nResult2: {result2}");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during email verification:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
