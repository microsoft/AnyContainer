// © Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using SimpleInjector;

namespace AnyContainer.SimpleInjector
{
	/// <summary>
	/// Register items in the singleton scope for Simple Injector.
	/// </summary>
    internal class SimpleInjectorSingletonScopeRegistrar : ScopeRegistrar
    {
	    private readonly Container container;

		/// <summary>
		/// Creates a new instance of the <see cref="SimpleInjectorSingletonScopeRegistrar"/> class.
		/// </summary>
		/// <param name="container">The Simple Injector container to use to register.</param>
		public SimpleInjectorSingletonScopeRegistrar(Container container)
	    {
		    this.container = container;
	    }

	    /// <summary>
	    /// Registers a type with a given implementation type.
	    /// </summary>
	    /// <typeparam name="T">The type to register.</typeparam>
	    /// <typeparam name="TImpl">The type to implement the registration.</typeparam>
		public override void Register<T, TImpl>()
	    {
			this.container.Register<T, TImpl>(Lifestyle.Singleton);
	    }

	    /// <summary>
	    /// Registers a type with a given factory.
	    /// </summary>
	    /// <typeparam name="T">The type to register.</typeparam>
	    /// <param name="factory">The factory to create the type.</param>
		public override void Register<T>(Func<T> factory)
	    {
			this.container.Register<T>(factory, Lifestyle.Singleton);
	    }

	    /// <summary>
	    /// Registers a type.
	    /// </summary>
	    /// <typeparam name="T">The type to register.</typeparam>
		public override void Register<T>()
	    {
			this.container.Register<T>(Lifestyle.Singleton);
	    }
    }
}
