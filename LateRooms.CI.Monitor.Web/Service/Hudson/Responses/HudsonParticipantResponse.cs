using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Service.Hudson.Responses
{
	[XmlRoot(ElementName = "participant")]
	public class HudsonParticipantResponse
	{
		[XmlElement(ElementName = "absoluteUrl", DataType = "string")]
		public string AbsoluteUrl { get; set; }

		[XmlElement(ElementName = "fullName", DataType = "string")]
		public string FullName { get; set; }
	}

	public class HudsonEmptyParticipantResponse : HudsonParticipantResponse
	{
		public HudsonEmptyParticipantResponse()
		{
			AbsoluteUrl = string.Empty;
			FullName = string.Empty;
		}
	}

	[XmlRoot(ElementName = "culprit")]
	public class HudsonCulpritResponse : HudsonParticipantResponse { }

	public class HudsonEmptyCulpritResponse : HudsonEmptyParticipantResponse { }
}