using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Service.Hudson.Responses
{
	[XmlRoot(ElementName = "healthReport")]
	public class HudsonHealthReportResponse
	{
		[XmlElement(ElementName = "description", DataType = "string")]
		public string Description { get; set; }

		[XmlElement(ElementName = "iconUrl", DataType = "string")]
		public string IconUrl { get; set; }

		[XmlElement(ElementName = "score", DataType = "int")]
		public int Score { get; set; }
	}

}