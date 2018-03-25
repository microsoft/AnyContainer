// © Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using SimpleInjector;

namespace AnyContainer.SimpleInjector
{
    internal class SimpleInjectorTransientScopeRegistrar : ScopeRegistrar
    {
	    private readonly Container container;

	    public SimpleInjectorTransientScopeRegistrar(Container container)
	    {
		    this.container = container;
	    }

	    public override void Register<T, TImpl>()
	    {
		    this.container.Register<T, TImpl>(Lifestyle.Transient);
	    }

	    public override void Register<T>(Func<T> factory)
	    {
		    this.container.Register<T>(factory, Lifestyle.Transient);
	    }

	    public override void Register<T>()
	    {
		    this.container.Register<T>(Lifestyle.Transient);
	    }
    }
}
