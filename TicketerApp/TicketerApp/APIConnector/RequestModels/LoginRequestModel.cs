using Newtonsoft.Json;

namespace TicketerApp.APIConnector.RequestModels
{
    public class LoginRequestModel
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("captcha_key")]
        public string CaptchaKey { get; set; }
        [JsonProperty("mfa_code")]
        public string MfaCode { get; set; }
    }
}
