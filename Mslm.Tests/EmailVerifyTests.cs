using System.Threading.Tasks;
using Xunit;
using Mslm.EmailVerifyNS;

namespace Mslm.Tests
{
    public class EmailVerifyTests
    {
        [Fact]
        public async Task TestSingleVerify()
        {
            // To run this test, add your Mslm API Key to environment variable
            // named "MSLM_API_KEY", or initialize your key string directly.
            string token = Environment.GetEnvironmentVariable("MSLM_API_KEY") ?? "default-api-key";

            // Set up client.
            var emailVerifyClient = new EmailVerify(token);
            string emailToVerify = "abc@gmail.com";

            // Get result.
            var result = await emailVerifyClient.SingleVerify(emailToVerify);

            // Assert.
            Assert.NotNull(result);
        }
    }
}
