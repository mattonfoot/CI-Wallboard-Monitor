using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Service.Hudson.Responses
{
	[XmlRoot(ElementName = "score")]
	public class HudsonScoreResponse
	{
		[XmlElement(ElementName = "description", DataType = "string")]
		public string Description { get; set; }

		[XmlElement(ElementName = "ruleName", DataType = "string")]
		public string RuleName { get; set; }

		[XmlElement(ElementName = "rulesetName", DataType = "string")]
		public string RulesetName { get; set; }

		[XmlElement(ElementName = "value", DataType = "decimal")]
		public decimal Value { get; set; }
	}
}