using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Config.Models
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