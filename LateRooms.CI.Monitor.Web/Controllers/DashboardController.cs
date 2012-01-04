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
			var modelBuilder = DashboardViewModelBuilder.Get();

			// config
			var config = GetConfig("~/Monitors.config");
			modelBuilder.WithConfig(config);

			// liveserver monitors
			if (config.LiveServers != null) {
				var monitorHtml = GetMonitorHtml(config.LiveServers);
				modelBuilder.WithMonitor(monitorHtml);
			}

			// buildservers
			if (config.BuildServers != null)
			{
				config.BuildServers.Servers
					.ForEach(buildServerConfig => addProjectsToModel(buildServerConfig, modelBuilder));
			}

			return View(modelBuilder.Build());
		}

		private void addProjectsToModel(BuildServerConfig config, DashboardViewModelBuilder builder)
		{
			var buildservertype = (CIServerType)Enum.Parse(typeof(CIServerType), config.Type);
			var projectListRetriever = new ProjectListRetriever(buildservertype, config.ServiceUri);

			builder.AddServerProjects(config.Name, projectListRetriever.GetProjectList());
		}

		private string GetMonitorHtml(LiveServersConfig config)
		{
			if (string.IsNullOrEmpty(config.ServiceUri))
				return string.Empty;

			var web = new HtmlWeb();
			var htmlDocument = web.Load(config.ServiceUri);
			var document = htmlDocument.DocumentNode;

			return string.Join("", document.QuerySelectorAll(config.CssNodeFilter)
			                              	.Where(x => IsMonitoredServer(config.Servers, x.InnerText))
			                              	.Select(x => x.OuterHtml).ToArray());
		}

		private MonitorConfig GetConfig(string configpath)
		{
			var requestscopecache = new RequestScopedCacheWrapper();
			var xmlFileLoader = new XmlFileLoader(requestscopecache);

			return new ConfigLoader(xmlFileLoader).From(Server.MapPath(configpath));
		}

		private static bool IsMonitoredServer(IEnumerable<LiveServerConfig> servers, string monitor)
		{
			return servers.Select(x => x.Name).Any(monitor.Contains);
		}
	}
}
