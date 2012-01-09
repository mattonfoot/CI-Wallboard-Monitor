using System.Collections.Generic;
using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Config.Models
{
	[XmlRoot("errorlog")]
	public class ErrorLogConfig
	{
		public ErrorLogConfig()
		{
			Sites = new List<ErrorLogSiteConfig>();
		}

		[XmlAttribute("serviceuri")]
		public string ServiceUri { get; set; }

		[XmlElement("site")]
		public List<ErrorLogSiteConfig> Sites { get; set; }
	}
}