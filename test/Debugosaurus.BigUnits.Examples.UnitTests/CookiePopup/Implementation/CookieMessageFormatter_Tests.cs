using Debugosaurus.BigUnits.Examples.Users;
using Debugosaurus.BigUnits.Examples.CookiePopup.Implementation;
using Moq;
using Xunit;
using Shouldly;

namespace Debugosaurus.BigUnits.Examples.UnitTests.CookiePopup.Implementation
{
    public class CookieMessageFormatter_Tests : UnitTest<CookieMessageFormatter>
    {
        [Fact]
        public void When_a_template_containing_a_user_token_is_formatted_then_the_user_token_is_replaced_with_the_users_name()
        {
            var user = Mock.Of<IUser>();
            Mock.Get(user)
                .Setup(x => x.DisplayName)
                .Returns("you");

            var result = TestInstance.FormatMessage(
                user,
                $"Hi {CookieMessageTokens.USER_DISPLAY_NAME}!");

            result.ShouldBe("Hi you!");
        }
    }
}