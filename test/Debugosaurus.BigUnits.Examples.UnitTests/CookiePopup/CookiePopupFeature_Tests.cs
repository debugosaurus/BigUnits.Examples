using Debugosaurus.BigUnits.Examples.CookiePopup;
using Debugosaurus.BigUnits.Examples.CookiePopup.Interfaces;
using Debugosaurus.BigUnits.Examples.Users;
using Moq;
using Shouldly;
using Xunit;

namespace Debugosaurus.BigUnits.Examples.UnitTests.CookiePopup
{
    public class CookiePopupFeature_Tests : UnitTest<CookiePopupFeature>
    {
        private const string AnyMessageTemplate = "AnyMessageTemplate";
        private const string AnyFormattedMessage = "AnyFormattedMessage";

        [Fact]
        public void When_user_has_accepted_cookies_then_empty_popup_is_returned()
        {
            Mock.Get(GetDependency<IUser>())
                .Setup(x => x.HasAcceptedCookies)
                .Returns(true);

            var result = TestInstance.GetCookiePopup();

            result.ShouldSatisfyAllConditions(() =>
            {
                result.ShowPopup.ShouldBe(false);
                result.Message.ShouldBe(string.Empty);
            });
        }

        [Fact]
        public void When_user_has_not_accepted_cookies_then_empty_popup_is_returned()
        {
            var user = GetDependency<IUser>();
            Mock.Get(user)
                .Setup(x => x.HasAcceptedCookies)
                .Returns(false);

            Mock.Get(GetDependency<ICookieMessageProvider>())
                .Setup(x => x.GetMessageTemplate())
                .Returns(AnyMessageTemplate);

            Mock.Get(GetDependency<ICookieMessageFormatter>())
                .Setup(x => x.FormatMessage(user, AnyMessageTemplate))
                .Returns(AnyFormattedMessage);                

            var result = TestInstance.GetCookiePopup();

            result.ShouldSatisfyAllConditions(() =>
            {
                result.ShowPopup.ShouldBe(true);
                result.Message.ShouldBe(AnyFormattedMessage);
            });
        }        
    }
}