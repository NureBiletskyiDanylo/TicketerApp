using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Behaviors.Internals;
using Xamarin.Forms;

namespace TicketerApp.Behaviors
{
    public class PasswordValidationBehavior : ValidationBehavior
    {
        const string passwordRegex = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[_])[A-Za-z\d_]{8,}$";

        protected override ValueTask<bool> ValidateAsync(object value, CancellationToken token)
        {
            if (value is string password)
            {
                ValueTask<bool> result = new ValueTask<bool>(Regex.IsMatch(password, passwordRegex));
                return result;
            }
            return new ValueTask<bool>(false);
        }
    }
}
