using Newtonsoft.Json;

namespace Mslm.OtpNS
{
    /// <summary>
    /// Represents the response received after verifying a One-Time Password (OTP) token.
    /// </summary>
    public class OtpTokenVerifyResp
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("msg")]
        public string? Msg { get; set; }
    }
}