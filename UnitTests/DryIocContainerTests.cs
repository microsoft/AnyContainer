// Copyright © Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using DryIoc;
using Microsoft.AnyContainer.DryIoc;
using Microsoft.AnyContainer.UnitTests.RegisteredClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.AnyContainer.UnitTests
{
	[TestClass]
	public class DryIocContainerTests
	{
		[TestMethod]
		public void ResolveAll()
		{
			Container dryContainer = new Container();
			DryIocAnyContainer anyContainer = new DryIocAnyContainer(dryContainer);

			dryContainer.Register<ILogger, Logger>(serviceKey: "a");
			dryContainer.Register<ILogger, AlternateLogger>(serviceKey: "b");

			IList<ILogger> loggers = anyContainer.ResolveAll<ILogger>();
			Assert.AreEqual(2, loggers.Count);
			Assert.AreNotEqual(loggers[0], loggers[1]);
		}
	}
}
