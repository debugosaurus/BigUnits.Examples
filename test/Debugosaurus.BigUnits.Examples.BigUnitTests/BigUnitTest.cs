using Debugosaurus.BigUnits;
using Debugosaurus.BigUnits.Framework;
using Debugosaurus.BigUnits.Moq;

namespace Debugosaurus.BigUnits.Examples.BigUnitTests
{
    public class BigUnitTest<T> : BaseBigUnitTest
    {
        public BigUnitTest() : base(
            TestScopes.Namespace<T>(),
            new MoqDependencyProvider())
        {}

        public T TestInstance => GetTestInstance<T>();
    }
}
