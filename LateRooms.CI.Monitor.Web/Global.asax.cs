using System.Web.Mvc;
using System.Web.Routing;

namespace LateRooms.CI.Monitor.Web
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			BootStrap.RegisterAll(RouteTable.Routes, ViewEngines.Engines);
		}
	}
}