using System.Collections.Generic;
using System.Linq;
using LateRooms.CI.Monitor.Web.Service.Hudson.Responses;
using LateRooms.CI.Monitor.Web.Service.Models;

namespace LateRooms.CI.Monitor.Web.Service.Hudson.Mappers
{
	public static class BuildJobMapper
	{
		public static BuildJob FromHudsonAPI(string projectName, HudsonFreeStyleBuildResponse buildjob)
		{
			var changeset = GetChangeSet(buildjob);
			var parameters = GetParamters(buildjob);
			var buildresult = buildjob.Result == null || buildjob.Result.Equals("SUCCESS");

			return new BuildJob(projectName,buildjob.Result, buildjob.Number, buildjob.URL, buildresult, buildjob.Duration,
													buildjob.Timestamp, buildjob.IsBuilding, changeset, parameters);
		}

		private static Dictionary<string, string> GetParamters(HudsonFreeStyleBuildResponse build)
		{
			return build.Actions
				.Where(x => x.Parameters.Count > 0)
				.SelectMany(x => x.Parameters).ToDictionary(k => k.Name, v => v.Value);

		}

		private static IEnumerable<SVNChangeSet> GetChangeSet(HudsonFreeStyleBuildResponse build)
		{
			if (build.ChangeSets.Count > 0)
			{
				var changesetitems = build.ChangeSets.Select(item => item);

				return changesetitems.SelectMany(x => x.Items)
					.Select(changeset => new SVNChangeSet(changeset.User, changeset.Revision));
			}

			return new List<SVNChangeSet>();
		}
	}
}