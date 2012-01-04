using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using LateRooms.CI.Monitor.Web.Caching;
using LateRooms.CI.Monitor.Web.Mvc;
using LateRooms.CI.Monitor.Web.Config;
using LateRooms.CI.Monitor.Web.Helpers;
using LateRooms.CI.Monitor.Web.Service;
using LateRooms.CI.Monitor.Web.ViewModels.Builders;

namespace LateRooms.CI.Monitor.Web.Controllers
{
	[NoCache]
	public class DashboardController : Controller
	{
		
		public ActionResult Index()
		{
			// model
			var model = DashboardViewModelBuilder.Get();

			// config
			var configpath = Server.MapPath("~/Monitors.config");

			var cache = new RequestScopedCacheWrapper();
			var xmlFileLoader = new XmlFileLoader(cache);
			var config = new ConfigLoader(xmlFileLoader).From(configpath);

			model.WithConfig(config);

			// liveserver monitors
			if (config.LiveServers != null && !string.IsNullOrEmpty(config.LiveServers.ServiceUri))
			{
				var web = new HtmlWeb();
				var htmlDocument = web.Load(config.LiveServers.ServiceUri);
				var document = htmlDocument.DocumentNode;

				var monitorHtml = string.Join("", document.QuerySelectorAll(config.LiveServers.CssNodeFilter)
					.Where(x => IsMonitoredServer(config.LiveServers.Servers, x.InnerText))
					.Select(x => x.OuterHtml).ToArray());

				model.WithMonitor(monitorHtml);
			}

			// buildservers
			if (config.BuildServers != null)
			{
				foreach (var buildServerConfig in config.BuildServers.Servers)
				{
					var buildservertype = (CIServerType) Enum.Parse(typeof (CIServerType), buildServerConfig.Type);
					var projectListRetriever = new ProjectListRetriever(buildservertype, buildServerConfig.ServiceUri);

					model.AddServerProjects(buildServerConfig.Name, projectListRetriever.GetProjectList());
				}
			}

			return View(model.Build());
		}

		private static bool IsMonitoredServer(IEnumerable<LiveServerConfig> servers, string monitor)
		{
			return servers.Select(x => x.Name).Any(monitor.Contains);
		}
	}
}
