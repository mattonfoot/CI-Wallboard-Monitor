using System;
using System.Collections.Generic;
using System.Linq;
using LateRooms.CI.Monitor.Web.Config;
using LateRooms.CI.Monitor.Web.Service.Models;
using LateRooms.CI.Monitor.Web.ViewModels;

namespace LateRooms.CI.Monitor.Web.Builders
{
	public class DashboardViewModelBuilder
	{
		private readonly Dictionary<string, ProjectList> _projectServers = new Dictionary<string, ProjectList>();
		private string _monitorHtml;
		private MonitorConfig _config;

		public static DashboardViewModelBuilder Get()
		{
			return new DashboardViewModelBuilder();
		}

		public DashboardViewModelBuilder WithConfig(MonitorConfig config)
		{
			_config = config;
			return this;
		}

		public DashboardViewModelBuilder WithMonitor(string monitorHtml)
		{
			_monitorHtml = monitorHtml;
			return this;
		}

		public DashboardViewModelBuilder AddServerProjects(string servername, ProjectList projectList)
		{
			_projectServers.Add(servername, projectList);
			return this;
		}

		public DashboardViewModel Build()
		{
			var configuredServers = _config.BuildServers.Servers.Where(server => _projectServers.ContainsKey(server.Name));

			var pipelineViewModels = configuredServers.Select(server => SelectPipelineViewModels(server.Name, server.Pipelines));

			var buildServerViewModels = pipelineViewModels.Select(pipelineview => new BuildServerViewModel { Pipelines = pipelineview.ToList() });

			return new DashboardViewModel
			       	{
								BuildServers = buildServerViewModels.ToList(),
								DashboardName = _config.Description,
								Monitor = _monitorHtml
			       	};
		}

		private IEnumerable<PipelineViewModel> SelectPipelineViewModels(string serverName, IEnumerable<BuildPipelineConfig> pipelineConfigs)
		{
			var configuredPipelineNames = pipelineConfigs
						.Select(pipeline => pipeline.Name);

			var configuredProjects = configuredPipelineNames
						.Select(pipeName => GetFirstProjectForPipeline(serverName, pipeName))
						.Where(pipe => pipe != null);
				
			return configuredProjects.Select(pipe => GetPipeline(pipe));
		}

		private Project GetFirstProjectForPipeline(string serverName, string pipeName)
		{
			return _projectServers[serverName].Projects
			                   	.Where(project => project.Name == pipeName)
													.FirstOrDefault();
		}

		private static PipelineViewModel GetPipeline(Project projectpipe)
		{
			var pipeline = new PipelineViewModel();

			var firstStage = new StageViewModel { Jobs = new List<JobViewModel> { JobViewModelBuilder.From(projectpipe).Build() } };
			pipeline.Stages.Add(firstStage);

			var stage = GetNextStage(firstStage.Jobs);
			while (stage != null)
			{
				pipeline.Stages.Add(stage);
				stage = GetNextStage(stage.Jobs);
			}

			return pipeline;
		}

		private static StageViewModel GetNextStage(IEnumerable<JobViewModel> jobs)
		{
			var downstreamJobs = jobs.SelectMany(x => x.DownstreamJobs).Distinct(new JobViewModelComparer());

			return downstreamJobs.Count() == 0 ? null : new StageViewModel { Jobs = downstreamJobs.ToList() };
		}
	}
}