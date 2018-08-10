using System;
using System.Collections.Generic;
using System.Text;
using DryIoc;

namespace Microsoft.AnyContainer.DryIoc
{
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

		public override void Register<TRegisteredAs, TResolvedTo>()
	    {
			this.container.Register<TRegisteredAs, TResolvedTo>(Reuse.Singleton);
	    }

	    public override void Register(Type registeredAs, Type resolvedTo)
	    {
			this.container.Register(registeredAs, resolvedTo, Reuse.Singleton);
	    }

	    public override void Register<T>(Func<T> factory)
	    {
			this.container.RegisterDelegate(c => factory(), Reuse.Singleton);
		}
    }
}
