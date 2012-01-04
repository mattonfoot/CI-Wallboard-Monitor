using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Config
{
	[XmlRoot("view")]
	public class BuildViewConfig
	{
		[XmlAttribute("name")]
		public string Name { get; set; }
	}
}