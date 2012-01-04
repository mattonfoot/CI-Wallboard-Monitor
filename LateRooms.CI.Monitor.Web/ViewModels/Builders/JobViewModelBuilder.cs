using System;
using System.Linq;
using LateRooms.CI.Monitor.Web.Service.Models;

namespace LateRooms.CI.Monitor.Web.ViewModels.Builders
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
			long lastBuildRevision = -1;
			var lastBuildUser = "Unknown";

			if (_project.CurrentBuild.SvnChangeSet.Count() > 0) {
				var changeset = _project.CurrentBuild.SvnChangeSet.FirstOrDefault();
				lastBuildRevision = changeset.Revision;
				lastBuildUser = changeset.User;
			}



			return new JobViewModel
			       	{
			       		Name = _project.Name,
			       		Status = _project.LastBuild.Status,
			       		Result = _project.LastBuild.Result,
			       		QueuePosition = _project.CurrentQueuePosition,
			       		LastBuildNumber = _project.LastBuild.Number,
								LastBuildRevision = lastBuildRevision,
			       		LastBuildDuration = _project.LastBuild.Duration,
			       		LastBuildTime = new DateTime(_project.LastBuild.Timestamp),
								LastBuildUser = lastBuildUser,
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