using System.Collections.Generic;
using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Service.Hudson.Responses
{
	[XmlRoot(ElementName = "freeStyleBuild")]
	public class HudsonFreeStyleBuildResponse
	{
		public HudsonFreeStyleBuildResponse()
		{
			Actions = new List<HudsonActionResponse>();
			ChangeSet = new HudsonChangeSetResponse();
		}

		[XmlElement(ElementName = "action")]
		public List<HudsonActionResponse> Actions { get; set; }

		[XmlElement(ElementName = "building", DataType = "boolean")]
		public bool IsBuilding { get; set; }

		[XmlElement(ElementName = "duration", DataType = "int")]
		public int Duration { get; set; }

		[XmlElement(ElementName = "fullDisplayName", DataType = "string")]
		public string FullDisplayName { get; set; }

		[XmlElement(ElementName = "id", DataType = "string")]
		public string Id { get; set; }

		[XmlElement(ElementName = "keepLog", DataType = "boolean")]
		public bool KeepLog { get; set; }

		[XmlElement(ElementName = "number", DataType = "int")]
		public int Number { get; set; }

		[XmlElement(ElementName = "result", DataType = "string")]
		public string Result { get; set; }

		[XmlElement(ElementName = "timestamp", DataType = "long")]
		public long Timestamp { get; set; }

		[XmlElement(ElementName = "url", DataType = "string")]
		public string URL { get; set; }

		[XmlElement(ElementName = "builtOn", DataType = "string")]
		public string BuiltOn { get; set; }

		[XmlElement(ElementName = "changeSet")]
		public HudsonChangeSetResponse ChangeSet { get; set; }
	}
}