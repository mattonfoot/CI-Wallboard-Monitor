using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Config.Models
{
	[XmlRoot("server")]
	public class LiveServerConfig
	{
		[XmlAttribute("name")]
		public string Name { get; set; }
	}
}