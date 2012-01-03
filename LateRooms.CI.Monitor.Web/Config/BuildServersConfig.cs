using System.Collections.Generic;
using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Config
{
	[XmlRoot("buildservers")]
	public class BuildServersConfig
	{
		public BuildServersConfig()
		{
			Servers = new List<BuildServerConfig>();
		}

		[XmlElement("server")]
		public List<BuildServerConfig> Servers { get; set; }
	}
}