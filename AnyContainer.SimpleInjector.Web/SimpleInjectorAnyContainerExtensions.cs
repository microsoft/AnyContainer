// © Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using SimpleInjector;

namespace AnyContainer.SimpleInjector.Web
{
    /// <summary>
    /// Extension methods for SimpleInjectorAnyContainer.
    /// </summary>
    public static class SimpleInjectorAnyContainerExtensions
    {
        /// <summary>
        /// Adds the web request scope to the container.
        /// </summary>
        /// <param name="anyContainer">The container to add to.</param>
        /// <param name="nativeContainer">The native container to use.</param>
        public static void AddWebRequestScope(this SimpleInjectorAnyContainer anyContainer, Container nativeContainer)
        {
            anyContainer.AddScope(Lifetime.WebRequest, new SimpleInjectorWebRequestScopeRegistrar(nativeContainer));
        }
    }
}
