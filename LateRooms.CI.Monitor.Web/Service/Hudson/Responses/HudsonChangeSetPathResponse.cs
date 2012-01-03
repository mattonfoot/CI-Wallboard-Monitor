using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Service.Hudson.Responses
{
	[XmlRoot(ElementName = "path")]
	public class HudsonChangeSetPathResponse
	{
		[XmlElement(ElementName = "editType", DataType = "string")]
		public string EditType { get; set; }

		[XmlElement(ElementName = "file", DataType = "string")]
		public string File { get; set; }
	}
}