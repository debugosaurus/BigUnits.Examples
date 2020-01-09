using  Debugosaurus.BigUnits.Examples.CookiePopup.Interfaces;
using  Debugosaurus.BigUnits.Examples.Users;

namespace Debugosaurus.BigUnits.Examples.CookiePopup.Implementation
{
    public class CookieMessageFormatter : ICookieMessageFormatter
    {
        public string FormatMessage(
            IUser user,
            string template)
        {
            return template.Replace(
                CookieMessageTokens.USER_DISPLAY_NAME,
                user.DisplayName);
        }
    }
}