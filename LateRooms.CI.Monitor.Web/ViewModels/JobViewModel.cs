using System;
using System.Collections.Generic;

namespace LateRooms.CI.Monitor.Web.ViewModels
{
	public class JobViewModel
	{
		public JobViewModel()
		{
			UpstreamJobs = new List<JobViewModel>();
			DownstreamJobs = new List<JobViewModel>();
			LastBuildParameters = new Dictionary<string, string>();
		}

		public string Name { get; set; }

		public bool Status { get; set; }

		public string Result { get; set; }

		public int LastBuildNumber { get; set; }

		public string LastBuildUser { get; set; }

		public long LastBuildRevision { get; set; }

		public DateTime LastBuildTime { get; set; }

		public long LastBuildDuration { get; set; }

		public Dictionary<string, string> LastBuildParameters { get; set; }

		public int QueuePosition { get; set; }

		public int Progress { get; set; }

		public long StartTime { get; set; }

		public string Url { get; set; }

		public int UpstreamJobCount { get; set; }

		public int DownstreamJobCount { get; set; }

		public List<JobViewModel> UpstreamJobs { get; set; }

		public List<JobViewModel> DownstreamJobs { get; set; }
	}
}