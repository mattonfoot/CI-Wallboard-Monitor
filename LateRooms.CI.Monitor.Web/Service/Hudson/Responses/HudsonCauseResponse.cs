using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Service.Hudson.Responses
{
	[XmlRoot(ElementName = "cause")]
	public class HudsonCauseResponse
	{
		[XmlElement(ElementName = "shortDescription")]
		public string ShortDescription { get; set; }
	}
}