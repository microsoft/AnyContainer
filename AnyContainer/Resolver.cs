// © Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AnyContainer
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Resolves instances of types.
    /// </summary>
    public static class Resolver
    {
        /// <summary>The current resolver implementation.</summary>
        private static IResolver currentResolver;

        /// <summary>
        /// Sets the current resolver.
        /// </summary>
        /// <param name="resolver">The new resolver to use.</param>
        public static void SetResolver(IResolver resolver)
        {
            currentResolver = resolver;
        }

        /// <summary>
        /// Resolves an instance of the given type.
        /// </summary>
        /// <typeparam name="T">The type to resolve.</typeparam>
        /// <returns>An instance of the given type.</returns>
        public static T Resolve<T>()
            where T : class
        {
            return currentResolver.Resolve<T>();
        }

        /// <summary>
        /// Tries to resolve an instance of the given type.
        /// </summary>
        /// <typeparam name="T">The type to resolve.</typeparam>
        /// <returns>An instance of the given type, or null if an instance could not be resolved.</returns>
        public static T TryResolve<T>()
            where T : class
        {
            if (currentResolver == null)
            {
                return null;
            }

            try
            {
                return currentResolver.Resolve<T>();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Resolves all instances of the given type.
        /// </summary>
        /// <typeparam name="T">The type to resolve.</typeparam>
        /// <returns>All instances of the given type.</returns>
        public static IList<T> ResolveAll<T>()
            where T : class
        {
            return currentResolver.ResolveAll<T>();
        }
    }
}
