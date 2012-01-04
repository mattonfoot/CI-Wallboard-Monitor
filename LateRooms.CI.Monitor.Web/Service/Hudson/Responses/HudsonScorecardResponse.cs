using System.Collections.Generic;
using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Service.Hudson.Responses
{
	[XmlRoot(ElementName = "scorecard")]
	public class HudsonScorecardResponse
	{
		[XmlElement(ElementName = "score")]
		public List<HudsonScoreResponse> Score { get; set; }

		[XmlElement(ElementName = "totalPoints", DataType = "string")]
		public string TotalPoints { get; set; }
	}

	public class HudsonEmptyScorecardResponse : HudsonScorecardResponse
	{
		public HudsonEmptyScorecardResponse()
		{
			Score = new List<HudsonScoreResponse>();
			TotalPoints = "0";
		}
	}
}