using System.Web.Mvc;
using System.Web.Routing;

namespace LateRooms.CI.Monitor.Web
{
	public class MvcApplication : System.Web.HttpApplication
	{
// ReSharper disable InconsistentNaming
		protected void Application_Start()
// ReSharper restore InconsistentNaming
		{
			BootStrap.RegisterAll(RouteTable.Routes, ViewEngines.Engines);
		}
	}
}