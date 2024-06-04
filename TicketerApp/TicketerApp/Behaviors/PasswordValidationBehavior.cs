using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Behaviors.Internals;

namespace TicketerApp.Behaviors
{
    public class PasswordValidationBehavior : ValidationBehavior
    {
        const string _regexPasswordPattern = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[_])[A-Za-z\d_]{8,}$";

        protected override ValueTask<bool> ValidateAsync(object value, CancellationToken token)
        {
            if (value is string password)
            {
                ValueTask<bool> result = new ValueTask<bool>(Regex.IsMatch(password, _regexPasswordPattern));
                return result;
            }
            return new ValueTask<bool>(false);
        }
    }
}
