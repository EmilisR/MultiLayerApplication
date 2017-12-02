using ProductItemBLService;
using System;
using BasketBLService;

using Unity;
using Unity.AspNet.Mvc;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using User.Service;
using Basket.Service;
using Product.Service;
using LoginBLService;

namespace GuiLayer
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              //var a = ConfigurationManager.GetSection("unity");
              //var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            container.RegisterType<ILoginService, LoginService>();
            container.RegisterType<IProductItemService, ProductItemInStockService>();
            //container.RegisterType<IProductItemService, ProductItemArrivingService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IBasketService, BasketService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<Helper>();
            container.RegisterType<IBasketBLService, RegisteredUserBasketService>();
            //container.RegisterType<IBasketBLService, GuestBasketService>();
            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}