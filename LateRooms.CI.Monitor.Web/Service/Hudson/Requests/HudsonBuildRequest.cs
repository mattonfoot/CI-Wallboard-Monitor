namespace LateRooms.CI.Monitor.Web.Service.Hudson.Requests
{
	public class HudsonBuildRequest
	{
		private const string UriTemplate = "/job/{0}/{1}/api/xml";

		public HudsonBuildRequest()
		{
			Depth = 0;
		}

		public string Name { get; set; }
		public long BuildNumber { get; set; }

		public string Uri { 
			get { 
				return string.Format(UriTemplate, Name, BuildNumber);
			}
		}

		public int Depth { get; set; }
	}
}