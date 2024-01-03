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
            var emailVerifyClient = new EmailVerify("3f5deea912f8434684af92fbf92a0cd1");
            string emailToVerify = "hak17319@gmail.com";

            // Act
            var result = await emailVerifyClient.SingleVerify(emailToVerify);

            // Assert
            Assert.NotNull(result);
        }
    }
}
