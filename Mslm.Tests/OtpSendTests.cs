using System.Threading.Tasks;
using Xunit;
using Mslm.OtpNS;

public class OtpSendTests
    {
        [Fact]
        public async Task TestSend()
        {
            // Arrange
            var otpClient = new Otp("3f5deea912f8434684af92fbf92a0cd1");
            var otpSendReq = new OtpSendReq {
                Phone = "03219427983",
                TmplSms = "This is your Otp",
                TokenLen = 6,
                ExpireSeconds = 300
            };

            // Act
            var result = await otpClient.Send(otpSendReq);

            // Assert
            Assert.NotNull(result);
        }
    }