using Newtonsoft.Json;

namespace Mslm.OtpNS
{
    public class OtpTokenVerifyResp
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("msg")]
        public string? Msg { get; set; }
    }
}