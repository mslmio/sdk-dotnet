using Newtonsoft.Json;

namespace Mslm.OtpNS
{
    public class OtpSendResp
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("msg")]
        public string? Msg { get; set; }
    }
}
