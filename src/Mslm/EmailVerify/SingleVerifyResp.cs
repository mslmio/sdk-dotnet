using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace Mslm.EmailVerify
{
    public class SingleVerifyResp
    {
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

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("SingleVerifyResp {");
            stringBuilder.AppendLine($"  Email: {Email},");
            stringBuilder.AppendLine($"  Username: {Username},");
            stringBuilder.AppendLine($"  Domain: {Domain},");
            stringBuilder.AppendLine($"  Malformed: {Malformed},");
            stringBuilder.AppendLine($"  Suggestion: {Suggestion},");
            stringBuilder.AppendLine($"  Status: {Status},");
            stringBuilder.AppendLine($"  HasMailbox: {HasMailbox},");
            stringBuilder.AppendLine($"  AcceptAll: {AcceptAll},");
            stringBuilder.AppendLine($"  Disposable: {Disposable},");
            stringBuilder.AppendLine($"  Free: {Free},");
            stringBuilder.AppendLine($"  Role: {Role},");
            stringBuilder.Append("  Mx: [");
            if (Mx != null)
            {
                foreach (var mx in Mx)
                {
                    stringBuilder.Append(mx.ToString() + ", ");
                }
            }
            stringBuilder.AppendLine("]");
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }
    }

    public class SingleVerifyRespMx
    {
        [JsonProperty("host")]
        public string? Host { get; set; }

        [JsonProperty("pref")]
        public int Pref { get; set; }

        public override string ToString()
        {
            return $"SingleVerifyRespMx {{ Host: {Host}, Pref: {Pref} }}";
        }
    }
}
