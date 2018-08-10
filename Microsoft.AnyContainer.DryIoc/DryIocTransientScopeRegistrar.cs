using System;
using System.Collections.Generic;
using System.Text;
using DryIoc;

namespace Microsoft.AnyContainer.DryIoc
{
    public class DryIocTransientScopeRegistrar : ScopeRegistrar
    {
	    private readonly Container container;

		/// <summary>
		/// Creates a new instance of the <see cref="DryIocTransientScopeRegistrar"/> class.
		/// </summary>
		/// <param name="container">The DryIoc container to use to register.</param>
		public DryIocTransientScopeRegistrar(Container container)
	    {
		    this.container = container;
	    }

		public override void Register<TRegisteredAs, TResolvedTo>()
	    {
			this.container.Register<TRegisteredAs, TResolvedTo>(Reuse.Transient);
	    }

	    public override void Register(Type registeredAs, Type resolvedTo)
	    {
			this.container.Register(registeredAs, resolvedTo, Reuse.Transient);
	    }

	    public override void Register<T>(Func<T> factory)
	    {
			this.container.RegisterDelegate(c => factory(), Reuse.Transient);
	    }
    }
}
