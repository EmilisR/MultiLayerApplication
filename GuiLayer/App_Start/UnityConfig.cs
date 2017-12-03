using BasketBLService;
using LoginBLService;
using Microsoft.Practices.Unity.Configuration;
using ProductItemBLService;
using System;
using System.Configuration;
using Unity;

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
              var container = new UnityContainer();
              UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
              section.Configure(container);
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
            container.RegisterType<Helper>();
            container.RegisterType<IBasketBLService, RegisteredUserBasketService>();
            //container.RegisterType<IBasketBLService, GuestBasketService>();
            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}