// © Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnyContainer.UnitTests.RegisteredClasses;
using AnyContainer.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace AnyContainer.UnitTests
{
    [TestClass]
    public class UnityContainerTests
    {
        [TestMethod]
        public void ResolveAll()
        {
            IUnityContainer unityContainer = new UnityContainer();
            var anyContainer = new UnityAnyContainer(unityContainer);

            unityContainer.RegisterType<ILogger, Logger>("a");
            unityContainer.RegisterType<ILogger, AlternateLogger>("b");

            IList<ILogger> loggers = anyContainer.ResolveAll<ILogger>();
            Assert.AreEqual(2, loggers.Count);
            Assert.AreNotEqual(loggers[0], loggers[1]);
        }
    }
}
