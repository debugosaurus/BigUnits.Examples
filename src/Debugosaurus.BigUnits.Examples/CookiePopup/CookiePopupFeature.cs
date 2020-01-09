using  Debugosaurus.BigUnits.Examples.CookiePopup.Implementation;
using  Debugosaurus.BigUnits.Examples.CookiePopup.Interfaces;
using  Debugosaurus.BigUnits.Examples.Users;

namespace Debugosaurus.BigUnits.Examples.CookiePopup
{
    public class CookiePopupFeature : ICookiePopupFeature
    {
        private IUser _currentUser;
        private ICookieMessageProvider _cookieMessageProvider;
        private ICookieMessageFormatter _cookieMessageFormatter;

        public CookiePopupFeature(
            IUser currentUser,
            ICookieMessageProvider cookieMessageProvider,
            ICookieMessageFormatter cookieMessageFormatter)
        {
            _currentUser = currentUser;
            _cookieMessageProvider = cookieMessageProvider;
            _cookieMessageFormatter = cookieMessageFormatter;
        }

        public CookiePopup GetCookiePopup()
        {
            if(_currentUser.HasAcceptedCookies)
            {
                return CookiePopup.Empty;
            }

            var messageTemplate = _cookieMessageProvider.GetMessageTemplate();
            var message = _cookieMessageFormatter.FormatMessage(
                _currentUser,
                messageTemplate);

            return new CookiePopup(
                true,
                message
            );
        }


    }
}