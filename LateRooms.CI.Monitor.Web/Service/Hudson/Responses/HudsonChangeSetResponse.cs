using System.Collections.Generic;
using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Service.Hudson.Responses
{
	[XmlRoot(ElementName = "changeSet")]
	public class HudsonChangeSetResponse
	{
		public HudsonChangeSetResponse()
		{
			Revisions = new List<HudsonRevisionsResponse>();
			Items = new List<HudsonChangeSetItemResponse>();
		}

		[XmlElement(ElementName = "revision")]
		public List<HudsonRevisionsResponse> Revisions { get; set; }

		[XmlElement(ElementName = "item")]
		public List<HudsonChangeSetItemResponse> Items { get; set; }

		[XmlElement(ElementName = "kind", DataType = "string")]
		public string Kind { get; set; }
	}
}