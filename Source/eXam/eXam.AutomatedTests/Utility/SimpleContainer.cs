using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace eXam.AutomatedTests
{
	/// <summary>
	/// This is a very simple example of a DI/IoC container. Taken from the XAM300 - Advanced Cross Platform Class
	/// </summary>
	public sealed class SimpleContainer
	{
		readonly Dictionary<Type, Func<object>> registeredCreators = new Dictionary<Type, Func<object>>();

		/// <summary>
		/// Register a type with the container. This is only necessary if the 
		/// type has a non-default constructor or needs to be customized in some fashion.
		/// </summary>
		/// <typeparam name="TAbstraction">Abstraction type<typeparam>
		/// <typeparam name="TImpl">Type to create</typeparam>
		public void Register<TAbstraction, TImpl>() 
			where TImpl : new()
		{
			registeredCreators.Add(typeof(TAbstraction), () => new TImpl());
		}

		/// <summary>
		/// Register a type with the container. This is only necessary if the 
		/// type has a non-default constructor or needs to be customized in some fashion.
		/// </summary>
		/// <param name="creator">Function to create the given type.</param>
		/// <typeparam name="T">Type to create</typeparam>
		public void Register<T>(Func<object> creator)
		{
			registeredCreators.Add(typeof(T),creator);
		}

		/// <summary>
		/// Creates a factory for a type so it may be created through
		/// the container without taking a dependency on the container directly.
		/// </summary>
		/// <returns>Creator function</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public Func<T> FactoryFor<T>() 
		{
			return Create<T>;
		}

		/// <summary>
		/// Creates the given type, either through a registered function
		/// or through the default constructor.
		/// </summary>
		/// <typeparam name="T">Type to create</typeparam>
		public T Create<T>()
		{
			return (T) Create(typeof(T));
		}

		/// <summary>
		/// Creates the given type, either through a registered function
		/// or through the default constructor.
		/// </summary>
		/// <param name="type">Type to create</param>
		public object Create(Type type)
		{
			TypeInfo typeInfo = type.GetTypeInfo();

			Func<object> creator;
			if (registeredCreators.TryGetValue(type, out creator))
				return registeredCreators[type]();

			var ctors = typeInfo.DeclaredConstructors.Where(c => c.IsPublic).ToArray();
			var ctor = ctors.FirstOrDefault(c => c.GetParameters().Length == 0);
			if (ctor != null)
				return Activator.CreateInstance(type);

			// Pick the first constructor found and create any parameters.
			ctor = ctors[0];
			List<object> parameters = new List<object>();
			foreach (var p in ctor.GetParameters())
				parameters.Add(Create(p.ParameterType));

			return Activator.CreateInstance(type, parameters.ToArray());
		}
	}
}
