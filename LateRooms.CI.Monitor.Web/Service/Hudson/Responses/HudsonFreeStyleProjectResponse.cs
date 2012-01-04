using System.Collections.Generic;
using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Service.Hudson.Responses
{
	[XmlRoot(ElementName = "freeStyleProject")]
	public class HudsonFreeStyleProjectResponse
	{
		public HudsonFreeStyleProjectResponse()
		{
			Actions = new List<HudsonActionResponse>();
			Builds = new List<HudsonBuildResponse>();
			HealthReports = new List<HudsonHealthReportResponse>();

			LastBuild = new List<HudsonLastBuildResponse>();
			LastCompletedBuild = new List<HudsonLastCompletedBuildResponse>();
			LastFailedBuild = new List<HudsonLastFailedBuildResponse>();
			LastStableBuild = new List<HudsonLastStableBuildResponse>();
			LastSuccessfulBuild = new List<HudsonLastSuccessfulBuildResponse>();
			LastUnsuccessfulBuild = new List<HudsonLastUnsuccessfulBuildResponse>();

			DownstreamProjects = new List<HudsonDownstreamProjectResponse>();
			UpstreamProjects = new List<HudsonUpstreamProjectResponse>();

		}

		[XmlElement(ElementName = "action")]
		public List<HudsonActionResponse> Actions { get; set; }

		[XmlElement(ElementName = "description", DataType = "string")]
		public string Description { get; set; }

		[XmlElement(ElementName = "displayName", DataType = "string")]
		public string DisplayName { get; set; }

		[XmlElement(ElementName = "name", DataType = "string")]
		public string Name { get; set; }

		[XmlElement(ElementName = "url", DataType = "string")]
		public string Url { get; set; }

		[XmlElement(ElementName = "buildable", DataType = "boolean")]
		public bool Buildable { get; set; }

		[XmlElement(ElementName = "build")]
		public List<HudsonBuildResponse> Builds { get; set; }

		[XmlElement(ElementName = "color", DataType = "string")]
		public string Color { get; set; }

		[XmlElement(ElementName = "firstBuild")]
		public HudsonBuildResponse FirstBuild { get; set; }

		[XmlElement(ElementName = "healthReport")]
		public List<HudsonHealthReportResponse> HealthReports { get; set; }

		[XmlElement(ElementName = "inQueue", DataType = "boolean")]
		public bool InQueue { get; set; }

		[XmlElement(ElementName = "keepDependencies", DataType = "boolean")]
		public bool KeepDependencies { get; set; }

		[XmlElement(ElementName = "lastBuild")]
		public List<HudsonLastBuildResponse> LastBuild { get; set; }

		[XmlElement(ElementName = "lastCompletedBuild")]
		public List<HudsonLastCompletedBuildResponse> LastCompletedBuild { get; set; }

		[XmlElement(ElementName = "lastFailedBuild")]
		public List<HudsonLastFailedBuildResponse> LastFailedBuild { get; set; }

		[XmlElement(ElementName = "lastStableBuild")]
		public List<HudsonLastStableBuildResponse> LastStableBuild { get; set; }

		[XmlElement(ElementName = "lastSuccessfulBuild")]
		public List<HudsonLastSuccessfulBuildResponse> LastSuccessfulBuild { get; set; }

		[XmlElement(ElementName = "lastUnsuccessfulBuild")]
		public List<HudsonLastUnsuccessfulBuildResponse> LastUnsuccessfulBuild { get; set; }

		[XmlElement(ElementName = "nextBuildNumber", DataType = "long")]
		public long NextBuildNumber { get; set; }

		[XmlElement(ElementName = "concurrentBuild", DataType = "boolean")]
		public bool ConcurrentBuild { get; set; }

		[XmlElement(ElementName = "downstreamProject")]
		public List<HudsonDownstreamProjectResponse> DownstreamProjects { get; set; }

		[XmlElement(ElementName = "upstreamProject")]
		public List<HudsonUpstreamProjectResponse> UpstreamProjects { get; set; }
	}
}