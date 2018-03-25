// © Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleInjector;

namespace AnyContainer.SimpleInjector
{
    public class SimpleInjectorAnyContainer : AnyContainer
    {
	    private readonly Container container;

	    public SimpleInjectorAnyContainer()
	    {
		    this.container = new Container();
		    this.AddCoreScopes();
	    }

		public SimpleInjectorAnyContainer(Container container)
	    {
		    this.container = container;
		    this.AddCoreScopes();
	    }

	    private void AddCoreScopes()
	    {
		    this.AddScope(Lifetime.Singleton, new SimpleInjectorSingletonScopeRegistrar(this.container));
		    this.AddScope(Lifetime.Transient, new SimpleInjectorTransientScopeRegistrar(this.container));
	    }

	    public override T Resolve<T>()
	    {
		    return this.container.GetInstance<T>();
	    }

	    public override IList<T> ResolveAll<T>()
	    {
		    return this.container.GetAllInstances<T>().ToList();
	    }
    }
}
