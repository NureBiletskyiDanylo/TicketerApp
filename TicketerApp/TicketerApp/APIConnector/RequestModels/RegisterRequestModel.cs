using Newtonsoft.Json;

namespace TicketerApp.APIConnector.RequestModels
{
    public class RegisterRequestModel
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("captcha_key")]
        public string CaptchaKey {  get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
    }
}
