// Copyright © Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.AnyContainer
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Resolves instances of types.
    /// </summary>
    public interface IResolver
    {
        /// <summary>
        /// Resolves an instance of the given type.
        /// </summary>
        /// <typeparam name="T">The type to resolve.</typeparam>
        /// <returns>An instance of the given type.</returns>
        T Resolve<T>()
            where T : class;

        /// <summary>
        /// Resolves an instance of the given type.
        /// </summary>
        /// <param name="componentType">The type to resolve.</param>
        /// <returns>An instance of the given type.</returns>
        object Resolve(Type componentType);

        /// <summary>
        /// Resolves all instances of the given type.
        /// </summary>
        /// <typeparam name="T">The type to resolve.</typeparam>
        /// <returns>All instances of the given type.</returns>
        IList<T> ResolveAll<T>()
            where T : class;

        /// <summary>
        /// Resolves all instances of the given type.
        /// </summary>
        /// <param name="componentType">The type to resolve.</param>
        /// <returns>All instances of the given type.</returns>
        IList<object> ResolveAll(Type componentType);
    }
}
