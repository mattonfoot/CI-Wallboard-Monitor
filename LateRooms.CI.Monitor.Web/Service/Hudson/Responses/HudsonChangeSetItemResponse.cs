using System.Collections.Generic;
using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Service.Hudson.Responses
{
	[XmlRoot(ElementName = "item")]
	public class HudsonChangeSetItemResponse
	{
		public HudsonChangeSetItemResponse()
		{
			Paths = new List<HudsonChangeSetPathResponse>();
		}

		[XmlElement(ElementName = "date", DataType = "string")]
		public string Date { get; set; }

		[XmlElement(ElementName = "msg", DataType = "string")]
		public string Message { get; set; }

		[XmlElement(ElementName = "revision", DataType = "long")]
		public long Revision { get; set; }

		[XmlElement(ElementName = "user", DataType = "string")]
		public string User { get; set; }

		[XmlElement(ElementName = "path")]
		public List<HudsonChangeSetPathResponse> Paths { get; set; }
	}
}