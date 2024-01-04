using Newtonsoft.Json;

namespace Mslm.EmailVerifyNS
{
    /// <summary>
    /// Represents the response received from a single email verification request.
    /// </summary>
    public class SingleVerifyResp
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("msg")]
        public string? Msg { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("username")]
        public string? Username { get; set; }

        [JsonProperty("domain")]
        public string? Domain { get; set; }

        [JsonProperty("malformed")]
        public bool Malformed { get; set; }

        [JsonProperty("suggestion")]
        public string? Suggestion { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("has_mailbox")]
        public bool HasMailbox { get; set; }

        [JsonProperty("accept_all")]
        public bool AcceptAll { get; set; }

        [JsonProperty("disposable")]
        public bool Disposable { get; set; }

        [JsonProperty("free")]
        public bool Free { get; set; }

        [JsonProperty("role")]
        public bool Role { get; set; }

        [JsonProperty("mx")]
        public List<SingleVerifyRespMx>? Mx { get; set; }
    }

    /// <summary>
    /// Represents a mail exchange (MX) record for a domain in the email verification response.
    /// </summary>
    public class SingleVerifyRespMx
    {
        [JsonProperty("host")]
        public string? Host { get; set; }

        [JsonProperty("pref")]
        public int Pref { get; set; }
    }
}
