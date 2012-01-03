using System.Collections.Generic;
using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Service.Hudson.Responses
{
	[XmlRoot(ElementName = "hudson")]
	public class HudsonProjectListResponse
	{
		public HudsonProjectListResponse()
		{
			Jobs = new List<HudsonJobResponse>();
		}

		[XmlElement(ElementName = "assignedLabel", DataType = "string")]
		public string AssignedLabel { get; set; }

		[XmlElement(ElementName = "mode", DataType = "string")]
		public string Mode { get; set; }

		[XmlElement(ElementName = "nodeDescription", DataType = "string")]
		public string NodeDescription { get; set; }

		[XmlElement(ElementName = "nodeName", DataType = "string")]
		public string NodeName { get; set; }

		[XmlElement(ElementName = "numExecutors", DataType = "int")]
		public int NumExecutors { get; set; }

		[XmlElement(ElementName = "job")]
		public List<HudsonJobResponse> Jobs { get; set; }

		[XmlElement(ElementName = "overallLoad", DataType = "string")]
		public string OverallLoad { get; set; }

		[XmlElement(ElementName = "quietingDown", DataType = "boolean")]
		public bool QuietingDown { get; set; }

		[XmlElement(ElementName = "slaveAgentPort", DataType = "int")]
		public int SlaveAgentPort { get; set; }

		[XmlElement(ElementName = "useCrumbs", DataType = "boolean")]
		public bool UseCrumbs { get; set; }

		[XmlElement(ElementName = "useSecurity", DataType = "boolean")]
		public bool UseSecurity { get; set; }
	}
}
