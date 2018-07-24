// © Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace AnyContainer.Unity
{
	/// <summary>
	/// Registers items in the Transient scope for Unity.
	/// </summary>
    internal class UnityTransientScopeRegistrar : ScopeRegistrar
    {
	    private readonly IUnityContainer container;

		/// <summary>
		/// Creates a new instance of the <see cref="UnityTransientScopeRegistrar"/> class.
		/// </summary>
		/// <param name="container">The unity container to do the registering.</param>
	    public UnityTransientScopeRegistrar(IUnityContainer container)
	    {
		    this.container = container;
	    }

	    /// <summary>
	    /// Registers a type with a given implementation type.
	    /// </summary>
	    /// <typeparam name="TRegisteredAs">The type to register.</typeparam>
	    /// <typeparam name="TResolvedTo">The type to implement the registration.</typeparam>
		public override void Register<TRegisteredAs, TResolvedTo>()
	    {
		    this.container.RegisterType<TRegisteredAs, TResolvedTo>();
	    }

        /// <summary>
        /// Registers a type with a given implementation type.
        /// </summary>
        /// <param name="registeredAs">The type to register.</param>
        /// <param name="resolvedTo">The type to implement the registration.</param>
        public override void Register(Type registeredAs, Type resolvedTo)
        {
            this.container.RegisterType(registeredAs, resolvedTo);
        }

        /// <summary>
	    /// Registers a type with a given factory.
	    /// </summary>
	    /// <typeparam name="T">The type to register.</typeparam>
	    /// <param name="factory">The factory to create the type.</param>
		public override void Register<T>(Func<T> factory)
	    {
		    this.container.RegisterType<T>(new InjectionFactory(c => factory()));
	    }

	    /// <summary>
	    /// Registers a type.
	    /// </summary>
	    /// <typeparam name="T">The type to register.</typeparam>
		public override void Register<T>()
	    {
		    this.container.RegisterType<T>();
	    }
	}
}
