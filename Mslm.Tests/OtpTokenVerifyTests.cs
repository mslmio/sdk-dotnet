using System.Threading.Tasks;
using Xunit;
using Mslm.OtpNS;

public class OtpTokenVerifyTests
{
    [Fact]
    public async Task TestTokenVerify()
    {
        // Arrange
        // to run this test, add your MSLM Api Key to environment variable
        // named "MSLM_API_KEY", or initialize your key string directly.
        string token = Environment.GetEnvironmentVariable("MSLM_API_KEY") ?? "default-api-key";

        var otpClient = new Otp(token);
        var otpTokenVerifyReq = new OtpTokenVerifyReq
        {
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