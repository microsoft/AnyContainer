// Copyright © Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AnyContainer.SimpleInjector;
using Microsoft.AnyContainer.UnitTests.RegisteredClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;

namespace Microsoft.AnyContainer.UnitTests
{
    [TestClass]
    public class SimpleInjectorContainerTests
    {
        [TestMethod]
        public void ResolveAll()
        {
            Container simpleContainer = new Container();
            SimpleInjectorAnyContainer anyContainer = new SimpleInjectorAnyContainer(simpleContainer);

            simpleContainer.Collection.Register<ILogger>(typeof(Logger), typeof(AlternateLogger));

            IList<ILogger> loggers = anyContainer.ResolveAll<ILogger>();
            Assert.AreEqual(2, loggers.Count);
            Assert.AreNotEqual(loggers[0], loggers[1]);
        }
    }
}
