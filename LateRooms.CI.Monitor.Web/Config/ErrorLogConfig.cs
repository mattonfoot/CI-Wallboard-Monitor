using System.Collections.Generic;
using System.Xml.Serialization;
using LateRooms.CI.Monitor.Web.Controllers;

namespace LateRooms.CI.Monitor.Web.Config
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