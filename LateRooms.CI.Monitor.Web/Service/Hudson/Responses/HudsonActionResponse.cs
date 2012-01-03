using System.Collections.Generic;
using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Service.Hudson.Responses
{
	[XmlRoot(ElementName = "action")]
	public class HudsonActionResponse
	{
		public HudsonActionResponse()
		{
			Causes = new List<HudsonCauseResponse>();
			Parameters = new List<HudsonParameterResponse>();
			Participant = new HudsonEmptyParticipantResponse();
			Scorecard = new HudsonEmptyScorecardResponse();
		}

		[XmlElement(ElementName = "cause")]
		public List<HudsonCauseResponse> Causes { get; set; }

		[XmlElement(ElementName = "parameter")]
		public List<HudsonParameterResponse> Parameters { get; set; }

		[XmlElement(ElementName = "failCount", DataType = "int")]
		public int FailCount { get; set; }

		[XmlElement(ElementName = "skipCount", DataType = "int")]
		public int SkipCount { get; set; }

		[XmlElement(ElementName = "totalCount", DataType = "int")]
		public int TotalCount { get; set; }

		[XmlElement(ElementName = "urlName", DataType = "string")]
		public string URLName { get; set; }

		[XmlElement(ElementName = "participant")]
		public HudsonParticipantResponse Participant { get; set; }

		[XmlElement(ElementName = "scorecard")]
		public HudsonScorecardResponse Scorecard { get; set; }
	}
}