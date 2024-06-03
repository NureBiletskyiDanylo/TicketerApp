using System;
using System.Collections.Generic;
using System.Text;

namespace TicketerApp.APIConnector.RequestModels
{
    public class LoginRequestModel
    {
        public string email { get; set; }
        public string password { get; set; }
        public string captcha_key { get; set; }
        public string mfa_code { get; set; }
    }
}
