using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Service.Hudson.Responses
{

	[XmlRoot(ElementName = "build")]
	public class HudsonBuildResponse
	{
		[XmlElement(ElementName = "number", DataType = "long")]
		public long Number { get; set; }

		[XmlElement(ElementName = "url", DataType = "string")]
		public string Url { get; set; }
	}

	[XmlRoot(ElementName = "lastbuild")]
	public class HudsonLastBuildResponse : HudsonBuildResponse
	{
	}

	[XmlRoot(ElementName = "lastCompletedBuild")]
	public class HudsonLastCompletedBuildResponse : HudsonBuildResponse
	{
	}

	[XmlRoot(ElementName = "lastFailedBuild")]
	public class HudsonLastFailedBuildResponse : HudsonBuildResponse
	{
	}

	[XmlRoot(ElementName = "lastStableBuild")]
	public class HudsonLastStableBuildResponse : HudsonBuildResponse
	{
	}

	[XmlRoot(ElementName = "lastSuccessfulBuild")]
	public class HudsonLastSuccessfulBuildResponse : HudsonBuildResponse
	{
	}

	[XmlRoot(ElementName = "lastUnsuccessfulBuild")]
	public class HudsonLastUnsuccessfulBuildResponse : HudsonBuildResponse
	{
	}
}