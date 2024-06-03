using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Behaviors.Internals;

namespace TicketerApp.Behaviors
{
    public class NameValidationBehavior : ValidationBehavior
    {
        const string regexPattern = @"^[\p{L}\p{M}'\.\-]+$";
        protected override ValueTask<bool> ValidateAsync(object value, CancellationToken token)
        {
            if(value is string partName)
            {
                ValueTask<bool> result = new ValueTask<bool>(Regex.IsMatch(partName, regexPattern));
                return result;
            }
            return new ValueTask<bool>(false);
        }
    }
}
