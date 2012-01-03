namespace LateRooms.CI.Monitor.Web.Service.Hudson.Requests
{
	public class HudsonProjectRequest
	{
		private const string UriTemplate = "/job/{0}/api/xml";

		public HudsonProjectRequest()
		{
			Depth = 0;
		}

		public string Name { get; set; }

		public string Uri { 
			get { 
				return string.Format(UriTemplate, Name);
			}
		}

		public int Depth { get; set; }
	}
}