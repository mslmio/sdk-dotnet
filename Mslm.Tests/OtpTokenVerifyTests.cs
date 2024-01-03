using System.Threading.Tasks;
using Xunit;
using Mslm.OtpNS;

public class OtpTokenVerifyTests
{
    [Fact]
    public async Task TestTokenVerify()
    {
        // Arrange
        var otpClient = new Otp("3f5deea912f8434684af92fbf92a0cd1");
        var otpTokenVerifyReq = new OtpTokenVerifyReq {
                Phone = "03219427983",
                Token = "406378",
                Consume = true
            };

        // Act
        var result = await otpClient.Verify(otpTokenVerifyReq);

        // Assert
        Assert.NotNull(result);
    }
}