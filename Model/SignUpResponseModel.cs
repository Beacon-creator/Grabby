

using System.Text.Json.Serialization;

namespace Grabby_Two.Model
{
    public class SignUpResponseModel
        {
        public string? Message { get; set; }

        [JsonPropertyName("verificationCode")]
        public string? VerificationCode { get; set; }
        public User? NewUser { get; set; }
        }

    }
