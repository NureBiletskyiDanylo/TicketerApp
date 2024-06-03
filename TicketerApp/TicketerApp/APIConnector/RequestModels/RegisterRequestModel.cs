using System;
using System.Collections.Generic;
using System.Text;

namespace TicketerApp.APIConnector.RequestModels
{
    public class RegisterRequestModel
    {
        public string email { get; set; }
        public string password { get; set; }
        public string captcha_key {  get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    }
}
