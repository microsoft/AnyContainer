// © Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace AnyContainer
{
	/// <summary>
	/// An implementation-agnostic IoC container.
	/// </summary>
	public abstract class AnyContainer
    {
		private readonly Dictionary<Lifetime, ScopeRegistrar> scopeDictionary = new Dictionary<Lifetime, ScopeRegistrar>();

	    public void AddScope(Lifetime lifetime, ScopeRegistrar scopeRegistrar)
	    {
		    if (this.scopeDictionary.ContainsKey(lifetime))
		    {
			    throw new ArgumentException($"Lifetime scope {lifetime} already added", nameof(lifetime));
		    }

			this.scopeDictionary.Add(lifetime, scopeRegistrar);
		}

	    /// <summary>
	    /// Registers a type with a given implementation type.
	    /// </summary>
	    /// <typeparam name="T">The type to register.</typeparam>
	    /// <typeparam name="TImpl">The type to implement the registration.</typeparam>
	    /// <param name="lifetime">The lifetime for the created object(s).</param>
	    public void Register<T, TImpl>(Lifetime lifetime)
		    where T : class
		    where TImpl : class, T
	    {
			this.GetRegistrarOrThrow(lifetime).Register<T, TImpl>();
	    }

		/// <summary>
		/// Registers a type with a given factory.
		/// </summary>
		/// <typeparam name="T">The type to register.</typeparam>
		/// <param name="factory">The factory to create the type.</param>
		/// <param name="lifetime">The lifetime for the created object(s).</param>
		public void Register<T>(Func<T> factory, Lifetime lifetime)
		    where T : class
	    {
			this.GetRegistrarOrThrow(lifetime).Register<T>(factory);
		}

		/// <summary>
		/// Registers a type.
		/// </summary>
		/// <typeparam name="T">The type to register.</typeparam>
		/// <param name="lifetime">The lifetime for the created object(s).</param>
		public void Register<T>(Lifetime lifetime)
		    where T : class
		{
			this.GetRegistrarOrThrow(lifetime).Register<T>();
		}

	    /// <summary>
	    /// Registers a type with a given implementation type as a transient.
	    /// </summary>
	    /// <typeparam name="T">The type to register.</typeparam>
	    /// <typeparam name="TImpl">The type to implement the registration.</typeparam>
	    public void RegisterTransient<T, TImpl>()
		    where T : class
		    where TImpl : class, T
	    {
		    this.Register<T, TImpl>(Lifetime.Transient);
	    }

	    /// <summary>
	    /// Registers a type as a transient.
	    /// </summary>
	    /// <typeparam name="T">The type to register.</typeparam>
	    public void RegisterTransient<T>()
		    where T : class
	    {
		    this.Register<T>(Lifetime.Transient);
	    }

	    /// <summary>
	    /// Registers a type with a given factory as a transient.
	    /// </summary>
	    /// <typeparam name="T">The type to register.</typeparam>
	    /// <param name="factory">The factory to create the type.</param>
	    public void RegisterTransient<T>(Func<T> factory)
		    where T : class
	    {
		    this.Register<T>(factory, Lifetime.Transient);
	    }

		/// <summary>
		/// Registers a type with a given implementation type as a singleton.
		/// </summary>
		/// <typeparam name="T">The type to register.</typeparam>
		/// <typeparam name="TImpl">The type to implement the registration.</typeparam>
		public void RegisterSingleton<T, TImpl>()
		    where T : class
		    where TImpl : class, T
	    {
		    this.Register<T, TImpl>(Lifetime.Singleton);
	    }

	    /// <summary>
	    /// Registers a type as a singleton.
	    /// </summary>
	    /// <typeparam name="T">The type to register.</typeparam>
	    public void RegisterSingleton<T>()
		    where T : class
	    {
		    this.Register<T>(Lifetime.Singleton);
	    }

	    /// <summary>
	    /// Registers a type with a given factory as a singleton.
	    /// </summary>
	    /// <typeparam name="T">The type to register.</typeparam>
	    /// <param name="factory">The factory to create the type.</param>
	    public void RegisterSingleton<T>(Func<T> factory)
		    where T : class
	    {
		    this.Register<T>(factory, Lifetime.Singleton);
	    }

	    /// <summary>
	    /// Resolves an instance of the given type.
	    /// </summary>
	    /// <typeparam name="T">The type to resolve.</typeparam>
	    /// <returns>An instance of the given type.</returns>
	    public abstract T Resolve<T>()
		    where T : class;

	    /// <summary>
	    /// Resolves all instances of the given type.
	    /// </summary>
	    /// <typeparam name="T">The type to resolve.</typeparam>
	    /// <returns>All instances of the given type.</returns>
	    public abstract IList<T> ResolveAll<T>()
		    where T : class;

		private ScopeRegistrar GetRegistrarOrThrow(Lifetime lifetime)
	    {
			ScopeRegistrar registrar;
		    if (!this.scopeDictionary.TryGetValue(lifetime, out registrar))
		    {
			    throw new ArgumentException($"Lifetime scope {lifetime} has not been added.", nameof(lifetime));
		    }

		    return registrar;
	    }
	}
}
