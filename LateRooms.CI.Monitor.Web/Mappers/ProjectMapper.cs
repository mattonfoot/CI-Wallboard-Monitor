using System;
using System.Collections.Generic;
using System.Linq;
using LateRooms.CI.Monitor.Web.Helpers;
using LateRooms.CI.Monitor.Web.Service.Hudson.Responses;
using LateRooms.CI.Monitor.Web.Service.Models;

namespace LateRooms.CI.Monitor.Web.Service.Hudson
{
	public static class ProjectMapper
	{
		public static Project FromHudsonAPI(HudsonFreeStyleProjectResponse response, BuildJob lastbuild, BuildJob successfulbuild, BuildJob completedbuild, BuildJob currentbuild, IEnumerable<Project> upstreamProjects, IEnumerable<Project> downstreamProjects, ProjectBuildQueue queue)
		{
			var projectname = response.Name;

			var progress = 0;
			if (currentbuild.IsBuilding)
				progress = GetPercentageProgress(currentbuild.Timestamp, successfulbuild.Duration);

			var position = queue.Items.ToList().FindIndex(x => x.Name == projectname) + 1;

			return new Project(projectname, lastbuild, successfulbuild, completedbuild, currentbuild, progress, position, upstreamProjects, downstreamProjects);
		}

		private static int GetPercentageProgress(long startTimestamp, int buildDuration)
		{
			var now = DateTime.Now.Ticks;
			var start = new JavaTimeStamp(startTimestamp).Ticks;
			var estimatedEnd = new JavaTimeStamp(startTimestamp + buildDuration).Ticks;
			var duration = estimatedEnd - start;
			var completed = now - start;

			return Convert.ToInt32(Math.Round(Math.Ceiling((completed / duration) * 100)));
		}
	}
}