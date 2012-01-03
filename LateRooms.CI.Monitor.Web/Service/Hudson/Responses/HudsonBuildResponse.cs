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
	public class HudsonLastBuildResponse
	{
		[XmlElement(ElementName = "number", DataType = "long")]
		public long Number { get; set; }

		[XmlElement(ElementName = "url", DataType = "string")]
		public string Url { get; set; }
	}

	[XmlRoot(ElementName = "lastCompletedBuild")]
	public class HudsonLastCompletedBuildResponse
	{
		[XmlElement(ElementName = "number", DataType = "long")]
		public long Number { get; set; }

		[XmlElement(ElementName = "url", DataType = "string")]
		public string Url { get; set; }
	}

	[XmlRoot(ElementName = "lastFailedBuild")]
	public class HudsonLastFailedBuildResponse
	{
		[XmlElement(ElementName = "number", DataType = "long")]
		public long Number { get; set; }

		[XmlElement(ElementName = "url", DataType = "string")]
		public string Url { get; set; }
	}

	[XmlRoot(ElementName = "lastStableBuild")]
	public class HudsonLastStableBuildResponse
	{
		[XmlElement(ElementName = "number", DataType = "long")]
		public long Number { get; set; }

		[XmlElement(ElementName = "url", DataType = "string")]
		public string Url { get; set; }
	}

	[XmlRoot(ElementName = "lastSuccessfulBuild")]
	public class HudsonLastSuccessfulBuildResponse
	{
		[XmlElement(ElementName = "number", DataType = "long")]
		public long Number { get; set; }

		[XmlElement(ElementName = "url", DataType = "string")]
		public string Url { get; set; }
	}

	[XmlRoot(ElementName = "lastUnsuccessfulBuild")]
	public class HudsonLastUnsuccessfulBuildResponse
	{
		[XmlElement(ElementName = "number", DataType = "long")]
		public long Number { get; set; }

		[XmlElement(ElementName = "url", DataType = "string")]
		public string Url { get; set; }
	}
}