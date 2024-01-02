using Mslm.LibNS;
using Newtonsoft.Json;

namespace Mslm.OtpNS
{
    public class OtpTokenVerifyReq
    {
        [JsonProperty("phone")]
        public string? Phone { get; set; }
        [JsonProperty("token")]
        public string? Token { get; set; }
        [JsonProperty("consume")]
        public bool? Consume { get; set; }
    }

    public class OtpTokenVerifyReqOpts
    {
        public ReqOpts ReqOpts { get; set; }

        public OtpTokenVerifyReqOpts()
        {
            ReqOpts = new ReqOpts();
        }
    }
}