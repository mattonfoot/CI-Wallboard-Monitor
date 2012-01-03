using System.Collections.Generic;
using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Config
{
	[XmlRoot("liveservers")]
	public class LiveServersConfig
	{
		public LiveServersConfig()
		{
			Servers = new List<LiveServerConfig>();
		}

		[XmlAttribute("serviceuri")]
		public string ServiceUri { get; set; }

		[XmlAttribute("filter")]
		public string CssNodeFilter { get; set; }

		[XmlElement("server")]
		public List<LiveServerConfig> Servers { get; set; }
	}
}