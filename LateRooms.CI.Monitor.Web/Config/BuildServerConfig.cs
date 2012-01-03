using System.Collections.Generic;
using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Config
{
	[XmlRoot("server")]
	public class BuildServerConfig
	{
		public BuildServerConfig()
		{
			Pipelines = new List<BuildPipelineConfig>();
		}

		[XmlAttribute("name")]
		public string Name { get; set; }

		[XmlAttribute("type")]
		public string Type { get; set; }

		[XmlAttribute("serviceuri")]
		public string ServiceUri { get; set; }

		[XmlElement("pipeline")]
		public List<BuildPipelineConfig> Pipelines { get; set; }
	}
}