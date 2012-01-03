using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Service.Hudson.Responses
{
	[XmlRoot(ElementName = "item")]
	public class HudsonQueueItemResponse
	{
		[XmlElement(ElementName = "action")]
		public HudsonActionResponse Action { get; set; }

		[XmlElement(ElementName = "id", DataType = "int")]
		public int Id { get; set; }

		[XmlElement(ElementName = "blocked", DataType = "boolean")]
		public bool Blocked { get; set; }

		[XmlElement(ElementName = "buildable", DataType = "boolean")]
		public bool Buildable { get; set; }

		[XmlElement(ElementName = "stuck", DataType = "boolean")]
		public bool Stuck { get; set; }

		[XmlElement(ElementName = "task")]
		public HudsonTaskResponse Task { get; set; }

		[XmlElement(ElementName = "why", DataType = "string")]
		public string Why { get; set; }

		[XmlElement(ElementName = "buildableStartMilliseconds", DataType = "long")]
		public long BuildableStart { get; set; }
		
	}
}