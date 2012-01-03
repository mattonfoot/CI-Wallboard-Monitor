using System.Collections.Generic;
using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Service.Hudson.Responses
{
	[XmlRoot(ElementName = "queue")]
	public class HudsonQueueResponse
	{
		public HudsonQueueResponse()
		{
			Items = new List<HudsonQueueItemResponse>();
		}

		[XmlElement(ElementName = "item")]
		public List<HudsonQueueItemResponse> Items { get; set; }
	}
}