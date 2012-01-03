using System.Web.Mvc;
using System.Web.Routing;
using LateRooms.CI.Monitor.Web.Mvc;
using LateRooms.CI.Monitor.Web.Config;

namespace LateRooms.CI.Monitor.Web
{
	public static class BootStrap
	{
		public static void RegisterAll(RouteCollection routes, ViewEngineCollection engines)
		{
			StructureMapConfiguration.Register();

			ControllerBuilder.Current.SetControllerFactory(new ControllerFactory());

			RegisterViewEngine(engines);
			RegisterRoutes(routes);

			AreaRegistration.RegisterAllAreas();
		}

		public static void DeRegisterAll()
		{
			StructureMapConfiguration.DeRegister();
		}

		private static void RegisterViewEngine(ViewEngineCollection engines)
		{
			SparkEngineInstaller.Install(engines);
		}

		private static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.IgnoreRoute("{resource}.css/{*pathInfo}");
			routes.IgnoreRoute("{resource}.js/{*pathInfo}");
			routes.IgnoreRoute("{resource}.htm/{*pathInfo}");
			routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

			routes.MapRoute(
					"Default",
					"{controller}/{action}/{id}",
					new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
			);
		}

	}
}