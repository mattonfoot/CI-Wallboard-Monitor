using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Service.Hudson.Responses
{
	[XmlRoot(ElementName = "task")]
	public class HudsonTaskResponse
	{
		[XmlElement(ElementName = "name", DataType = "string")]
		public string Name { get; set; }

		[XmlElement(ElementName = "url", DataType = "string")]
		public string Url { get; set; }

		[XmlElement(ElementName = "color", DataType = "string")]
		public string Color { get; set; }
	}
}