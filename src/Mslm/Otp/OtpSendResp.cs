using Newtonsoft.Json;

namespace Mslm.OtpNS
{
    /// <summary>
    /// Represents the response received after sending a One-Time Password (OTP).
    /// </summary>
    public class OtpSendResp
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("msg")]
        public string? Msg { get; set; }
    }
}
