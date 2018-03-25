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
    internal class UnitySingletonScopeRegistrar : ScopeRegistrar
    {
	    private readonly IUnityContainer container;

	    public UnitySingletonScopeRegistrar(IUnityContainer container)
	    {
		    this.container = container;
	    }

	    public override void Register<T, TImpl>()
	    {
		    this.container.RegisterType<T, TImpl>(new ContainerControlledLifetimeManager());
	    }

	    public override void Register<T>(Func<T> factory)
	    {
		    this.container.RegisterType<T>(new ContainerControlledLifetimeManager(), new InjectionFactory(c => factory()));
	    }

	    public override void Register<T>()
	    {
		    this.container.RegisterType<T>(new ContainerControlledLifetimeManager());
		}
    }
}
