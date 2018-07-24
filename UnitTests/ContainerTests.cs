using AnyContainer.Unity;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnyContainer.UnitTests
{
    using AnyContainer.SimpleInjector;

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
