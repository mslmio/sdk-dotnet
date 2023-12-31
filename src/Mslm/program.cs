using Mslm.EmailVerify;
using System;
using System.Threading.Tasks;

namespace Mslm
{
    public class EmailVerificationTest
    {
        public async Task TestEmailVerificationAsync()
        {
            // Initialize the EmailVerify class.
            // Look at go sdk README. This is equivalent to mslm.init since we are simply initializing the client. 
            // Do something like mslm.init once you have the mslm wrapper setup. and then do something like
            // c.EmailVerify.SingleVerify(email) in place of emailVerifier.Verify!! 
            var emailVerifier = new Mslm.EmailVerify.SingleVerify("aabb947fe09c4ba1bc0deac144db0239");

            // Optionally, set additional properties if needed.
            emailVerifier.SetBaseUrl("http://localhost:1793");

            // The email you want to verify.
            string emailToVerify = "hak173129@gmail.com";

            // try
            // {
                // Call the SingleVerify method and await its result.
                var result = await emailVerifier.Verify(emailToVerify);
                // Console.WriteLine($"Result: {result.email}");
                // Output the result to the console.
                Console.WriteLine($"Email: {result.Email}");
                Console.WriteLine($"Status: {result.Status}");
                Console.WriteLine($"Username: {result.Username}");
                // ... Output other properties as needed.
            // }
            // catch (Exception ex)
            // {
            //     // If an error occurs, write the exception to the console.
            //     Console.WriteLine("An error occurred during email verification:");
            //     Console.WriteLine(ex.Message);
            // }
        }
    }

    public class Program
    {
        static async Task Main(string[] args)
        {
            // Instantiate your test class
            var emailTest = new EmailVerificationTest();

            // Run the test
            await emailTest.TestEmailVerificationAsync();
        }
    }
}
