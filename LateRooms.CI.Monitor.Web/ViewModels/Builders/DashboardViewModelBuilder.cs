using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using LateRooms.CI.Monitor.Web.Config;
using LateRooms.CI.Monitor.Web.Config.Models;
using LateRooms.CI.Monitor.Web.Service.Models;

namespace LateRooms.CI.Monitor.Web.ViewModels.Builders
{
	public class DashboardViewModelBuilder
	{
		private readonly Dictionary<string, ProjectList> _projectServers = new Dictionary<string, ProjectList>();
		private IEnumerable<string> _monitors;
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

		public DashboardViewModelBuilder WithMonitor(IEnumerable<string> monitorHtml)
		{
			_monitors = monitorHtml;
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

			var buildServerViewModels = configuredServers
				.Select(server =>
				        	{
				        		var models = new List<PipelineViewModel>();

				        		if (server.Pipelines.Count > 0)
				        		{
				        			models.AddRange(SpecificPipelineViewModels(server.Name, server.Pipelines));
				        		}

				        		if (server.Filters.Count > 0)
				        		{
											models.AddRange(FilteredPipelineViewModels(server.Name, server.Filters));
				        		}

				        		if (models.Count() == 0)
				        		{
				        			var allProjects = _projectServers[server.Name].Projects.Select(pipe => GetPipeline(pipe));

											models.AddRange(allProjects);
				        		}

				        		var numCols = server.Columns > 0 ? server.Columns : 1;         
				        		var current = 0;
										var columnsize = (models.Count() / numCols) + (models.Count() % numCols > 0 ? 1 : 0);
										var columns = new List<IEnumerable<PipelineViewModel>>();
										for (var i = 0; i < server.Columns; i++ )
										{
											columns.Add( models.Skip(current).Take(columnsize) );
											current += columnsize;
										}

										return new BuildServerViewModel(server.Name, numCols) { Pipelines = columns };
				        	});

			return new DashboardViewModel
			       	{
								BuildServers = buildServerViewModels,
								DashboardName = _config.Description,
								Monitors = _monitors
			       	};
		}

		private IEnumerable<PipelineViewModel> FilteredPipelineViewModels(string serverName, IEnumerable<BuildFilterConfig> filterConfigs)
		{
			// specific pipelines
			var configuredFilterPatterns = filterConfigs
						.Select(filter => filter.Pattern);

			if (configuredFilterPatterns.Count() > 0)
			{
				var fullPattern = String.Join("|", configuredFilterPatterns.Select(pattern => pattern).ToArray());

				return _projectServers[serverName].Projects
						.Where(project => Regex.IsMatch(project.Name, fullPattern))
						.Select(pipe => GetPipeline(pipe));
			}

			return Enumerable.Empty<PipelineViewModel>();
		}

		private IEnumerable<PipelineViewModel> SpecificPipelineViewModels(string serverName, IEnumerable<BuildPipelineConfig> pipelineConfigs)
		{
			// specific pipelines
			var configuredPipelineNames = pipelineConfigs
						.Select(pipeline => pipeline.Name);

			if (configuredPipelineNames.Count() > 0) {
				var configuredProjects = configuredPipelineNames
							.Select(pipeName => GetFirstProjectForPipeline(serverName, pipeName))
							.Where(pipe => pipe != null);

				return configuredProjects.Select(pipe => GetPipeline(pipe));
			}

			return Enumerable.Empty<PipelineViewModel>();
		}

		private Project GetFirstProjectForPipeline(string serverName, string pipeName)
		{
			return _projectServers[serverName].Projects
													.Where(project => Regex.IsMatch(project.Name, pipeName))
													.FirstOrDefault();
		}

		private static PipelineViewModel GetPipeline(Project projectpipe)
		{
			var stages = new List<StageViewModel>();

			var firstStage = new StageViewModel { Jobs = new List<JobViewModel> { JobViewModelBuilder.From(projectpipe).Build() } };
			stages.Add(firstStage);

			var stage = GetNextStage(firstStage.Jobs);
			while (stage != null)
			{
				stages.Add(stage);
				stage = GetNextStage(stage.Jobs);
			}

			return new PipelineViewModel { Stages = stages };
		}

		private static StageViewModel GetNextStage(IEnumerable<JobViewModel> jobs)
		{
			var downstreamJobs = jobs.SelectMany(x => x.DownstreamJobs).Distinct(new JobViewModelComparer());

			return downstreamJobs.Count() == 0 ? null : new StageViewModel { Jobs = downstreamJobs, NumberOfJobs = downstreamJobs.Count()};
		}
	}
}