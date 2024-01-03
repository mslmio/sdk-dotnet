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
            // Arrange
            // to run this test, add your MSLM Api Key to environment variable
            // named "MSLM_API_KEY", or initialize your key string directly.
            string token = Environment.GetEnvironmentVariable("MSLM_API_KEY") ?? "default-api-key";

            var emailVerifyClient = new EmailVerify(token);
            string emailToVerify = "abc@gmail.com";

            // Act
            var result = await emailVerifyClient.SingleVerify(emailToVerify);

            // Assert
            Assert.NotNull(result);
        }
    }
}
