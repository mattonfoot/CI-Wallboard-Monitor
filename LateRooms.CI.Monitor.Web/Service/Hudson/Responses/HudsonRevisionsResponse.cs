using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Service.Hudson.Responses
{
	[XmlRoot(ElementName = "revision")]
	public class HudsonRevisionsResponse
	{
		[XmlElement(ElementName = "module", DataType = "string")]
		public string Module { get; set; }

		[XmlElement(ElementName = "revision", DataType = "int")]
		public int Revision { get; set; }
	}
}