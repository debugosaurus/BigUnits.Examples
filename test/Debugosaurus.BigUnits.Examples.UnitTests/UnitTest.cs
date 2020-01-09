using Debugosaurus.BigUnits;
using Debugosaurus.BigUnits.Moq;

namespace Debugosaurus.BigUnits.Examples.UnitTests
{
    public class UnitTest<T> : BaseUnitTest<T> where T : class
    {
        public UnitTest() : base(new MoqDependencyProvider())
        {}
    }
}