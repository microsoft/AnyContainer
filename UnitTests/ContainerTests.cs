using System;
using Microsoft.AnyContainer.Unity;
using Microsoft.AnyContainer.SimpleInjector;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.AnyContainer.UnitTests
{
    [TestClass]
    public class ContainerTests
    {
        [TestMethod]
        public void TestUnity()
        {
            CommonContainerTestRunner.RunTests(() => new UnityAnyContainer());
        }

        [TestMethod]
        public void TestSimpleInjector()
        {
            CommonContainerTestRunner.RunTests(() => new SimpleInjectorAnyContainer());
        }
    }
}
