namespace Debugosaurus.BigUnits.Examples.CookiePopup
{
    public class CookiePopup
    {
        public static CookiePopup Empty = new CookiePopup(false, string.Empty);

        public CookiePopup(
            bool showPopup,
            string message)
        {
            ShowPopup = showPopup;
            Message = message;
        }

        public bool ShowPopup { get; private set; }
        public string Message { get; private set; }
    }
}