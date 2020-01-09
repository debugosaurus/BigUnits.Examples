using Debugosaurus.BigUnits.Examples.FileSystem;
using Debugosaurus.BigUnits.Examples.CookiePopup;
using Debugosaurus.BigUnits.Examples.CookiePopup.Implementation;
using Debugosaurus.BigUnits.Examples.Users;
using Moq;
using Shouldly;
using Xunit;

namespace Debugosaurus.BigUnits.Examples.BigUnitTests.CookiePopup
{
    public class CookiePopupFeature_Tests : BigUnitTest<CookiePopupFeature>
    {
        [Fact]
        public void When_user_has_accepted_cookies_then_no_popup_is_to_be_displayed()
        {
            GivenTheUserHasAcceptedCookies();

            var result = TestInstance.GetCookiePopup();

            result.ShouldSatisfyAllConditions(() =>
            {
                result.ShowPopup.ShouldBe(false);
                result.Message.ShouldBe(string.Empty);
            });
        }

        [Fact]
        public void When_user_has_not_accepted_cookies_then_a_formatted_popup_is_to_be_displayed()
        {
            GivenTheUserIsNamed("you");
            GivenTheUserHasAcceptedCookies(hasAccepted : false);
            GivenTheCookiePopupMessageTemplateIs($"Hi {CookieMessageTokens.USER_DISPLAY_NAME}!");

            var result = TestInstance.GetCookiePopup();

            result.ShouldSatisfyAllConditions(() =>
            {
                result.ShowPopup.ShouldBe(true);
                result.Message.ShouldBe("Hi you!");
            });
        }        

        protected void GivenTheUserIsNamed(string displayName)
        {
            Mock.Get(GetDependency<IUser>())
                .Setup(x => x.DisplayName)
                .Returns(displayName);               
        }

        protected void GivenTheUserHasAcceptedCookies(bool hasAccepted = true)
        {
            Mock.Get(GetDependency<IUser>())
                .Setup(x => x.HasAcceptedCookies)
                .Returns(hasAccepted);            
        }

        protected void GivenTheCookiePopupMessageTemplateIs(string messageTemplate)
        {
            Mock.Get(GetDependency<IFileSystem>())
                .Setup(x => x.ReadAllText())
                .Returns(messageTemplate);              
        }
    }
}