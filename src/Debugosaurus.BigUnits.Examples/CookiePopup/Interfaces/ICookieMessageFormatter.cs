using  Debugosaurus.BigUnits.Examples.Users;

namespace Debugosaurus.BigUnits.Examples.CookiePopup.Interfaces
{
    public interface ICookieMessageFormatter
    {
         string FormatMessage(
            IUser user,
            string template);
    }
}