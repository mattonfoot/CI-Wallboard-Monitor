using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Config
{
	[XmlRoot("site")]
	public class ErrorLogSiteConfig
	{
		[XmlAttribute("name")]
		public string Name { get; set; }

		[XmlAttribute("id")]
		public int Id { get; set; }
	}
}