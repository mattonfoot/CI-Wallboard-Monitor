using System.Collections.Generic;
using System.Linq;

namespace LateRooms.CI.Monitor.Web.Service.Models
{
	public class BuildJob
	{
		public BuildJob(string projectName, string result, int number, string url, bool status, int duration, long timestamp, bool isbuilding, IEnumerable<SVNChangeSet> changeset, IDictionary<string,string> parameters)
		{
			ProjectName = projectName;
			Result = result;
			Number = number;
			URL = url;
			Status = status;
			Duration = duration;
			Timestamp = timestamp;
			IsBuilding = isbuilding;
			SvnChangeSet = changeset;
			Parameters = parameters;
		}

		public IDictionary<string, string> Parameters { get; set; }

		public string ProjectName { get; private set; }

		public string Result { get; private set; }

		public int Number { get; private set; }
		
		public string URL { get; private set; }
		
		public bool Status { get; private set; }
		
		public int Duration { get; private set; }
		
		public long Timestamp { get; private set; }

		public bool IsBuilding { get; set; }

		public IEnumerable<SVNChangeSet> SvnChangeSet { get; set; }
	}

	class NullBuildJob : BuildJob
	{
		public NullBuildJob()
			: base(string.Empty, string.Empty, 0, string.Empty, true, 0, 0, false, Enumerable.Empty<SVNChangeSet>(), new Dictionary<string, string>())
		{
		}
	}
}