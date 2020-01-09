using System.Text;
using Debugosaurus.BigUnits.Examples.CookiePopup.Implementation;
using Debugosaurus.BigUnits.Examples.FileSystem;
using Moq;
using Xunit;
using Shouldly;

namespace Debugosaurus.BigUnits.Examples.UnitTests.CookiePopup.Implementation
{
    public class CookieMessageProvider_Tests : UnitTest<CookieMessageProvider>
    {
        [Fact]
        public void When_file_has_bom_then_the_bom_is_removed()
        {
            var bom = Encoding.UTF8.GetString(Encoding.Unicode.GetPreamble());

            Mock.Get(GetDependency<IFileSystem>())
                .Setup(x => x.ReadAllText())
                .Returns(bom + "text");

            var result = TestInstance.GetMessageTemplate();

            result.ShouldBe("text");
        }

        [Fact]
        public void When_file_has_no_bom_then_the_text_is_returned_unaltered()
        {
            Mock.Get(GetDependency<IFileSystem>())
                .Setup(x => x.ReadAllText())
                .Returns("text");

            var result = TestInstance.GetMessageTemplate();

            result.ShouldBe("text");
        }        
    }
}