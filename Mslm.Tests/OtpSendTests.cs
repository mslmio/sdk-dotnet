using System.Threading.Tasks;
using Xunit;
using Mslm.OtpNS;

public class OtpSendTests
    {
        [Fact]
        public async Task TestSend()
        {
            // To run this test, add your Mslm API Key to environment variable
            // named "MSLM_API_KEY", or initialize your key string directly.
            string token = Environment.GetEnvironmentVariable("MSLM_API_KEY") ?? "default-api-key";

            // Set up client.
            var otpClient = new Otp(token);
            var otpSendReq = new OtpSendReq {
                Phone = "03219427983",
                TmplSms = "This is your Otp",
                TokenLen = 6,
                ExpireSeconds = 300
            };

            var result = await otpClient.Send(otpSendReq);

            // Assert.
            Assert.NotNull(result);
        }
    }