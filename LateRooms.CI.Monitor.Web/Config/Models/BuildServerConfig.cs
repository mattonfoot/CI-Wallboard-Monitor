using System.Collections.Generic;
using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Config.Models
{
	[XmlRoot("server")]
	public class BuildServerConfig
	{
		public BuildServerConfig()
		{
			Pipelines = new List<BuildPipelineConfig>();
			Views = new List<BuildViewConfig>();
			Filters = new List<BuildFilterConfig>();
		}

		[XmlAttribute("name")]
		public string Name { get; set; }

		[XmlAttribute("type")]
		public string Type { get; set; }

		[XmlAttribute("serviceuri")]
		public string ServiceUri { get; set; }

		[XmlAttribute("columns", DataType = "int")]
		public int Columns { get; set; }

		[XmlElement("pipeline")]
		public List<BuildPipelineConfig> Pipelines { get; set; }

		[XmlElement("view")]
		public List<BuildViewConfig> Views { get; set; }

		[XmlElement("filter")]
		public List<BuildFilterConfig> Filters { get; set; }
	}
}