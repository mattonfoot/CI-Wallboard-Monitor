using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Config.Models
{
	[XmlRoot("pipeline")]
	public class BuildPipelineConfig
	{
		[XmlAttribute("name")]
		public string Name { get; set; }
	}
}