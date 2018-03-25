// © Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity;

namespace AnyContainer.Unity
{
    public class UnityAnyContainer : AnyContainer
    {
	    private readonly IUnityContainer container;

	    public UnityAnyContainer()
	    {
		    this.container = new UnityContainer();
			this.AddCoreScopes();
	    }

	    public UnityAnyContainer(IUnityContainer container)
	    {
		    this.container = container;
			this.AddCoreScopes();
	    }

		private void AddCoreScopes()
	    {
		    this.AddScope(Lifetime.Singleton, new UnitySingletonScopeRegistrar(this.container));
		    this.AddScope(Lifetime.Transient, new UnityTransientScopeRegistrar(this.container));
	    }

		public override T Resolve<T>()
		{
			return this.container.Resolve<T>();
	    }

	    public override IList<T> ResolveAll<T>()
	    {
		    return this.container.ResolveAll<T>().ToList();
	    }
    }
}
