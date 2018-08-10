// Copyright © Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.AnyContainer
{
	/// <summary>
	/// Registers types for a specific scope (Singleton, transient, etc).
	/// </summary>
    public abstract class ScopeRegistrar
    {
	    /// <summary>
	    /// Registers a type with a given implementation type.
	    /// </summary>
	    /// <typeparam name="TRegisteredAs">The type to register.</typeparam>
	    /// <typeparam name="TResolvedTo">The type to implement the registration.</typeparam>
		public abstract void Register<TRegisteredAs, TResolvedTo>()
		    where TRegisteredAs : class
		    where TResolvedTo : class, TRegisteredAs;

        /// <summary>
        /// Registers a type with a given implementation type.
        /// </summary>
        /// <param name="registeredAs">The type to register.</param>
        /// <param name="resolvedTo">The type to implement the registration.</param>
        public abstract void Register(Type registeredAs, Type resolvedTo);

        /// <summary>
        /// Registers a type with a given factory.
        /// </summary>
        /// <typeparam name="T">The type to register.</typeparam>
        /// <param name="factory">The factory to create the type.</param>
        public abstract void Register<T>(Func<T> factory)
		    where T : class;

	    /// <summary>
	    /// Registers a type.
	    /// </summary>
	    /// <typeparam name="T">The type to register.</typeparam>
		public virtual void Register<T>()
		    where T : class
		{
		    this.Register<T, T>();
	    }

        /// <summary>
        /// Registers a type.
        /// </summary>
        /// <param name="componentType">The type to register.</param>
        public virtual void Register(Type componentType)
        {
            this.Register(componentType, componentType);
        }
    }
}
