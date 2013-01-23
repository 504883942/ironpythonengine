using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ironpythonengine.test
{
    using NUnit.Framework;
    using ironpythonengine;

    [TestFixture]
    class EngineTestFramework
    {

        protected IronPythonEngine ipe;


        [Test]
        public void test_constructor()
        {
            Assert.IsNotNull(ipe.get_engine());
            Assert.IsNotNull(ipe.get_scope());
        }

        [Test]
        public void test_run_expression()
        {
            int x = ipe.get_engine().Execute<int>("3+4");
            Assert.AreEqual(x, 7);
        }

        [Test]
        public void test_multi_session_expression()
        {
            ipe.get_engine().Execute("x=4");
            int x = ipe.get_engine().Execute<int>("x-1");
            Assert.AreEqual(x, 3);
        }


        [Test]
        public void test_simiple_variable_injection()
        {
            ipe.get_scope().SetVariable("name", "Dave");
            string str = ipe.get_engine().Execute<string>(" \"Hello, {}!\".format(name); ");
            Assert.AreEqual(str, "Hello, Dave!");
        
        }

    }


     //[TestFixtureSetUp]
     //   public void setup()
     //   {
     //       this.ipe = 
     //   }

}
