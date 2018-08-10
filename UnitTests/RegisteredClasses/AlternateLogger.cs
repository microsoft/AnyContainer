// Copyright © Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AnyContainer.UnitTests.RegisteredClasses
{
    public class AlternateLogger : ILogger
    {
        public void Log(string message)
        {
        }
    }
}
