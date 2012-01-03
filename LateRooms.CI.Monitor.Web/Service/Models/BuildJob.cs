
using System;
using System.Collections.Generic;

namespace LateRooms.CI.Monitor.Web.Service.Models
{
	public class BuildJob
	{
		public BuildJob(string projectName, string result, int number, string url, bool status, int duration, long timestamp, bool isbuilding, SVNChangeSet changeset, Dictionary<string,string> parameters)
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

		public Dictionary<string, string> Parameters { get; set; }

		public string ProjectName { get; private set; }

		public string Result { get; private set; }

		public int Number { get; private set; }
		
		public string URL { get; private set; }
		
		public bool Status { get; private set; }
		
		public int Duration { get; private set; }
		
		public long Timestamp { get; private set; }

		public bool IsBuilding { get; set; }

		public SVNChangeSet SvnChangeSet { get; set; }
	}
}