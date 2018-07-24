// © Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyContainer.UnitTests
{
    using AnyContainer.UnitTests.RegisteredClasses;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public static class CommonContainerTestRunner
    {
        public static void RunTests(Func<BaseAnyContainer> factory)
        {
            TestSingletonGeneric(factory);
            TestSingletonNonGeneric(factory);
            TestTransientGeneric(factory);
            TestTransientNonGeneric(factory);
            TestFunc(factory);
            TestTryResolveFail(factory);
            TestTryResolveSucceed(factory);
        }

        private static void TestSingletonGeneric(Func<BaseAnyContainer> factory)
        {
            BaseAnyContainer container = factory();
            container.RegisterSingleton<ILogger, Logger>();

            var instanceA = container.Resolve<ILogger>();
            var instanceB = container.Resolve<ILogger>();

            Assert.AreEqual(instanceA, instanceB);
        }

        private static void TestSingletonNonGeneric(Func<BaseAnyContainer> factory)
        {
            BaseAnyContainer container = factory();
            container.RegisterSingleton(typeof(ILogger), typeof(Logger));

            var instanceA = container.Resolve<ILogger>();
            var instanceB = container.Resolve<ILogger>();

            Assert.AreEqual(instanceA, instanceB);
        }

        private static void TestTransientGeneric(Func<BaseAnyContainer> factory)
        {
            BaseAnyContainer container = factory();
            container.RegisterTransient<ILogger, Logger>();

            var instanceA = container.Resolve<ILogger>();
            var instanceB = container.Resolve<ILogger>();

            Assert.AreNotEqual(instanceA, instanceB);
        }

        private static void TestTransientNonGeneric(Func<BaseAnyContainer> factory)
        {
            BaseAnyContainer container = factory();
            container.RegisterTransient(typeof(ILogger), typeof(Logger));

            var instanceA = container.Resolve<ILogger>();
            var instanceB = container.Resolve<ILogger>();

            Assert.AreNotEqual(instanceA, instanceB);
        }

        private static void TestFunc(Func<BaseAnyContainer> factory)
        {
            bool functionCalled = false;

            BaseAnyContainer container = factory();
            container.RegisterTransient<ILogger>(() =>
            {
                functionCalled = true;
                return new Logger();
            });

            Assert.IsFalse(functionCalled);

            var logger = container.Resolve<ILogger>();

            Assert.IsTrue(functionCalled);
            Assert.IsNotNull(logger);
        }

        private static void TestTryResolveFail(Func<BaseAnyContainer> factory)
        {
            BaseAnyContainer container = factory();
            Resolver.SetResolver(container);

            ILogger logger = Resolver.TryResolve<ILogger>();

            Assert.IsNull(logger);
        }

        private static void TestTryResolveSucceed(Func<BaseAnyContainer> factory)
        {
            BaseAnyContainer container = factory();
            container.RegisterSingleton<ILogger, Logger>();

            Resolver.SetResolver(container);

            ILogger logger = Resolver.TryResolve<ILogger>();

            Assert.IsNotNull(logger);
        }
    }
}
