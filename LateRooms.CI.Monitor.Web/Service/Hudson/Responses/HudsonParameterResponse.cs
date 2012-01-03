using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Service.Hudson.Responses
{
	public class HudsonParameterResponse
	{
		[XmlElement(ElementName = "name", DataType = "string")]
		public string Name { get; set; }

		[XmlElement(ElementName = "value", DataType = "string")]
		public string Value { get; set; }

	}
}