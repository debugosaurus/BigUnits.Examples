using Debugosaurus.BigUnits.Examples.Users;

namespace Debugosaurus.BigUnits.Examples.CookiePopup.Implementation
{
    public interface ICookieMessageFormatter
    {
         string FormatMessage(
            IUser user,
            string template);
    }
}