// Copyright © Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleInjector;

namespace Microsoft.AnyContainer.SimpleInjector
{
	/// <summary>
	/// Simple Injector implementation of the abstract container.
	/// </summary>
	public class SimpleInjectorAnyContainer : AnyContainerBase
    {
	    private readonly Container container;

		/// <summary>
		/// Creates a new instance of the <see cref="SimpleInjectorAnyContainer"/> class.
		/// </summary>
		public SimpleInjectorAnyContainer()
	    {
		    this.container = new Container();
		    this.AddCoreScopes();
	    }

		/// <summary>
		/// Creates a new instance of the <see cref="SimpleInjectorAnyContainer"/> class.
		/// </summary>
		/// <param name="container">The Unity container to power the class.</param>
		public SimpleInjectorAnyContainer(Container container)
	    {
		    this.container = container;
		    this.AddCoreScopes();
	    }

	    /// <summary>
	    /// Adds the singleton and transient scope registrars.
	    /// </summary>
		private void AddCoreScopes()
	    {
		    this.AddScope(Lifetime.Singleton, new SimpleInjectorSingletonScopeRegistrar(this.container));
		    this.AddScope(Lifetime.Transient, new SimpleInjectorTransientScopeRegistrar(this.container));
	    }

	    /// <summary>
	    /// Resolves an instance of the given type.
	    /// </summary>
	    /// <typeparam name="T">The type to resolve.</typeparam>
	    /// <returns>An instance of the given type.</returns>
		public override T Resolve<T>()
	    {
		    return this.container.GetInstance<T>();
	    }

        /// <summary>
        /// Resolves an instance of the given type.
        /// </summary>
        /// <param name="componentType">The type to resolve.</param>
        /// <returns>An instance of the given type.</returns>
        public override object Resolve(Type componentType)
        {
            return this.container.GetInstance(componentType);
        }

        /// <summary>
	    /// Resolves all instances of the given type.
	    /// </summary>
	    /// <typeparam name="T">The type to resolve.</typeparam>
	    /// <returns>All instances of the given type.</returns>
		public override IList<T> ResolveAll<T>()
	    {
		    return this.container.GetAllInstances<T>().ToList();
	    }

        /// <summary>
        /// Resolves all instances of the given type.
        /// </summary>
        /// <param name="componentType">The type to resolve.</param>
        /// <returns>All instances of the given type.</returns>
        public override IList<object> ResolveAll(Type componentType)
        {
            return this.container.GetAllInstances(componentType).ToList();
        }
    }
}
