using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TicketerApp.APIConnector.RequestModels
{
    public class SuccessfulLoginRegistrationResponseModel
    {
        public string token {  get; set; }
        public double expires_at { get; set; }

        
    }
}
