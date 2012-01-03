using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Service.Hudson.Responses
{
	[XmlRoot(ElementName = "job")]
	public class HudsonJobResponse
	{
		[XmlElement(ElementName = "name", DataType = "string")]
		public string Name { get; set; }

		[XmlElement(ElementName = "url", DataType = "string")]
		public string Url { get; set; }

		[XmlElement(ElementName = "color", DataType = "string")]
		public string Color { get; set; }
	}

	[XmlRoot(ElementName = "downstreamProject")]
	public class HudsonDownstreamProjectResponse
	{
		[XmlElement(ElementName = "name", DataType = "string")]
		public string Name { get; set; }

		[XmlElement(ElementName = "url", DataType = "string")]
		public string Url { get; set; }

		[XmlElement(ElementName = "color", DataType = "string")]
		public string Color { get; set; }
	}

	[XmlRoot(ElementName = "upstreamProject")]
	public class HudsonUpstreamProjectResponse
	{
		[XmlElement(ElementName = "name", DataType = "string")]
		public string Name { get; set; }

		[XmlElement(ElementName = "url", DataType = "string")]
		public string Url { get; set; }

		[XmlElement(ElementName = "color", DataType = "string")]
		public string Color { get; set; }
	}
}