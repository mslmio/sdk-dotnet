using Mslm.LibNS;
using Newtonsoft.Json;

namespace Mslm.OtpNS
{
    /// <summary>
    /// Represents the request for sending a One-Time Password (OTP).
    /// </summary>
    public class OtpSendReq
    {
        [JsonProperty("phone")]
        public string? Phone { get; set; }

        [JsonProperty("tmpl_sms")]
        public string? TmplSms { get; set; }

        [JsonProperty("token_len")]
        public int TokenLen { get; set; }

        [JsonProperty("expire_seconds")]
        public int ExpireSeconds { get; set; }
    }

    /// <summary>
    /// Represents request options specifically for the OTP send operation.
    /// </summary>
    public class OtpSendReqOpts
    {
        public ReqOpts ReqOpts { get; set; }

        public OtpSendReqOpts()
        {
            ReqOpts = new ReqOpts();
        }
    }
}
