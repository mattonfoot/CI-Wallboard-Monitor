using System;
using System.Linq;
using LateRooms.CI.Monitor.Web.Service.Models;
using LateRooms.CI.Monitor.Web.ViewModels;

namespace LateRooms.CI.Monitor.Web.Builders
{
	public class JobViewModelBuilder
	{
		private readonly Project _project;

		private JobViewModelBuilder(Project project)
		{
			_project = project;
		}

		public static JobViewModelBuilder From(Project project)
		{
			return new JobViewModelBuilder(project);
		}

		public JobViewModel Build()
		{
			return new JobViewModel
			       	{
			       		Name = _project.Name,
			       		Status = _project.LastBuild.Status,
			       		Result = _project.LastBuild.Result,
			       		QueuePosition = _project.CurrentQueuePosition,
			       		LastBuildNumber = _project.LastBuild.Number,
			       		LastBuildRevision = _project.CurrentBuild.SvnChangeSet.Revision,
			       		LastBuildDuration = _project.LastBuild.Duration,
			       		LastBuildTime = new DateTime(_project.LastBuild.Timestamp),
								LastBuildUser = _project.CurrentBuild.SvnChangeSet.User,
								LastBuildParameters = _project.LastBuild.Parameters,
			       		StartTime = _project.CurrentBuild.Timestamp,
			       		Progress = _project.CurrentBuildProgress,
			       		Url = _project.CurrentBuild.URL,
			       		//UpstreamJobs = _project.UpstreamProjects.Select(x => new JobViewModelBuilder(x).Build()).ToList(),
								DownstreamJobs = _project.DownstreamProjects.Select(x => new JobViewModelBuilder(x).Build()).ToList()
							};
		}
	}
}