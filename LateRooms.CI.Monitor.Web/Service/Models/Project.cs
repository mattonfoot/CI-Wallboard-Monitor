using System.Collections.Generic;

namespace LateRooms.CI.Monitor.Web.Service.Models
{
	public class Project
	{

		public Project(string name, BuildJob lastbuild, BuildJob successfulbuild, BuildJob completedbuild, BuildJob currentbuild, int currentBuildProgress, int currentQueuePosition, IEnumerable<Project> upstreamProjects, IEnumerable<Project> downstreamProjects)
		{
			Name = name;

			LastBuild = lastbuild;
			LastSuccessfulBuild = successfulbuild;
			LastCompletedBuild = completedbuild;
			CurrentBuild = currentbuild;
			CurrentBuildProgress = currentBuildProgress;
			CurrentQueuePosition = currentQueuePosition;

			UpstreamProjects = upstreamProjects;
			DownstreamProjects = downstreamProjects;
		}

		public string Name { get; private set; }

		public BuildJob LastBuild { get; private set; }
		
		public BuildJob LastSuccessfulBuild { get; private set; }

		public BuildJob LastCompletedBuild { get; private set; }

		public BuildJob CurrentBuild { get; private set; }

		public int CurrentBuildProgress { get; private set; }

		public int CurrentQueuePosition { get; private set; }

		public IEnumerable<Project> UpstreamProjects { get; private set; }

		public IEnumerable<Project> DownstreamProjects { get; private set; }
	}
}