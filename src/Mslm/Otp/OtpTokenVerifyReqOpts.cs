using Mslm.LibNS;
using Newtonsoft.Json;

namespace Mslm.OtpNS
{
    /// <summary>
    /// Represents the request for verifying a One-Time Password (OTP) token.
    /// </summary>
    public class OtpTokenVerifyReq
    {
        [JsonProperty("phone")]
        public string? Phone { get; set; }
        [JsonProperty("token")]
        public string? Token { get; set; }
        [JsonProperty("consume")]
        public bool? Consume { get; set; }
    }

    /// <summary>
    /// Represents request options specifically for the OTP token verification operation.
    /// </summary>
    public class OtpTokenVerifyReqOpts
    {
        public ReqOpts ReqOpts { get; set; }

        public OtpTokenVerifyReqOpts()
        {
            ReqOpts = new ReqOpts();
        }
    }
}