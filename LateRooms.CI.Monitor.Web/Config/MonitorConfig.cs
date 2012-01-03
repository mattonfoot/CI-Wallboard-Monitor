using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Config
{
	[XmlRoot("settings")]
	public class MonitorConfig
	{
		public MonitorConfig()
		{
			Description = "Unconfigured Monitor";
			ErrorLog = new ErrorLogConfig();
			LiveServers = new LiveServersConfig();
			BuildServers = new BuildServersConfig();
		}

		[XmlElement("description")]
		public string Description { get; set; }

		[XmlElement("errorlog")]
		public ErrorLogConfig ErrorLog { get; set; }

		[XmlElement("liveservers")]
		public LiveServersConfig LiveServers { get; set; }

		[XmlElement("buildservers")]
		public BuildServersConfig BuildServers { get; set; }
	}
}