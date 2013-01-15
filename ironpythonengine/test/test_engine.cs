using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ironpythonengine.test
{
    using NUnit.Framework;

    [TestFixture]
    class TestEngine
    {
        [Test]
        public void test_fail()
        {
            throw new DivideByZeroException();
        }

    }
}
