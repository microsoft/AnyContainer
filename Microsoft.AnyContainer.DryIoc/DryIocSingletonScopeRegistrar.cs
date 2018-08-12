using System;
using System.Collections.Generic;
using System.Text;
using DryIoc;

namespace Microsoft.AnyContainer.DryIoc
{
	/// <summary>
	/// Register items in the singleton scope for DryIoc.
	/// </summary>
	public class DryIocSingletonScopeRegistrar : ScopeRegistrar
    {
	    private readonly Container container;

		/// <summary>
		/// Creates a new instance of the <see cref="DryIocSingletonScopeRegistrar"/> class.
		/// </summary>
		/// <param name="container">The DryIoc container to use to register.</param>
		public DryIocSingletonScopeRegistrar(Container container)
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
			this.container.Register<TRegisteredAs, TResolvedTo>(Reuse.Singleton);
	    }

	    /// <summary>
	    /// Registers a type with a given implementation type.
	    /// </summary>
	    /// <param name="registeredAs">The type to register.</param>
	    /// <param name="resolvedTo">The type to implement the registration.</param>
		public override void Register(Type registeredAs, Type resolvedTo)
	    {
			this.container.Register(registeredAs, resolvedTo, Reuse.Singleton);
	    }

	    /// <summary>
	    /// Registers a type with a given factory.
	    /// </summary>
	    /// <typeparam name="T">The type to register.</typeparam>
	    /// <param name="factory">The factory to create the type.</param>
		public override void Register<T>(Func<T> factory)
	    {
			this.container.RegisterDelegate(c => factory(), Reuse.Singleton);
		}

	    /// <summary>
	    /// Registers a type.
	    /// </summary>
	    /// <typeparam name="T">The type to register.</typeparam>
	    public override void Register<T>()
	    {
		    this.container.Register<T>(Reuse.Singleton);
	    }
	}
}
