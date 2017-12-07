using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using Unity;
using User.Service;
using Basket.Service;
using Product.Service;
using System;

namespace BasketBLService
{
    /// <summary>
    /// Simple wrapper for unity resolution.
    /// </summary>
    public class DependencyFactory
    {
        private static IUnityContainer _container;

        public static IUserService ResolveUserService()
        {
            return _container.Resolve<IUserService>();
        }

        public static IProductService ResolveProductService()
        {
            return _container.Resolve<IProductService>();
        }

        /// <summary>
        /// Public reference to the unity container which will 
        /// allow the ability to register instrances or take 
        /// other actions on the container.
        /// </summary>
        public static IUnityContainer Container
        {
            get
            {
                return _container;
            }
            private set
            {
                _container = value;
            }
        }

        /// <summary>
        /// Static constructor for DependencyFactory which will 
        /// initialize the unity container.
        /// </summary>
        static DependencyFactory()
        {
            var container = new UnityContainer();

            /*var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            if (section != null)
            {
                section.Configure(container);
            }*/
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IBasketService, BasketService>();

            _container = container;
        }

        /// <summary>
        /// Resolves the type parameter T to an instance of the appropriate type.
        /// </summary>
        /// <typeparam name="T">Type of object to return</typeparam>
        public static T Resolve<T>()
        {
            T ret = default(T);

            if (Container.IsRegistered(typeof(T)))
            {
                ret = Container.Resolve<T>();
            }

            return ret;
        }

        public static IBasketService ResolveBasketService()
        {
            return Container.Resolve<IBasketService>();
        }
    }
}
