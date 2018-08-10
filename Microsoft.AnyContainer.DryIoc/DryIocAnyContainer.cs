// Copyright © Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DryIoc;

namespace Microsoft.AnyContainer.DryIoc
{
    public class DryIocAnyContainer : AnyContainerBase
    {
	    private readonly Container container;

	    public DryIocAnyContainer()
	    {
		    this.container = new Container();
		    this.AddCoreScopes();
		}

		public DryIocAnyContainer(Container container)
	    {
		    this.container = container;
		    this.AddCoreScopes();
	    }

		/// <summary>
		/// Adds the singleton and transient scope registrars.
		/// </summary>
		private void AddCoreScopes()
	    {
		    this.AddScope(Lifetime.Singleton, new DryIocSingletonScopeRegistrar(this.container));
		    this.AddScope(Lifetime.Transient, new DryIocTransientScopeRegistrar(this.container));
	    }

		public override T Resolve<T>()
	    {
		    return this.container.Resolve<T>();
	    }

	    public override object Resolve(Type componentType)
	    {
		    return this.container.Resolve(componentType);
	    }

	    public override IList<T> ResolveAll<T>()
	    {
		    return this.container.ResolveMany<T>().ToList();
	    }

	    public override IList<object> ResolveAll(Type componentType)
	    {
		    return this.container.ResolveMany(componentType).ToList();
	    }
    }
}
