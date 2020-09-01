using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmAspire
{
    /// <summary>
    /// An interface for facilitating inversion of control (IoC).
    /// </summary>
    public interface IDependencyResolver
    {
        /// <summary>
        /// Gets the current IoC container.
        /// </summary>
        /// <returns></returns>
        object GetContainer();

        /// <summary>
        /// Resolves the type to an instance.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        object Get(Type type);

        /// <summary>
        /// Registers an implementation of a type.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="implementationType"></param>
        void Register(Type type, Type implementationType);

        /// <summary>
        /// Registers an implementation of a type.
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <typeparam name="TImplementationType"></typeparam>
        void Register<TType, TImplementationType>()
            where TImplementationType : TType;

        /// <summary>
        /// Registers an instance of a type.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="instance"></param>
        void Register(Type type, object instance);
    }
}
