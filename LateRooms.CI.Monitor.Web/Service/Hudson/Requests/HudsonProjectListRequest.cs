namespace LateRooms.CI.Monitor.Web.Service.Hudson.Requests
{
	public class HudsonProjectListRequest
	{
		public HudsonProjectListRequest()
		{
			Uri = "/api/xml";
			Depth = 0;
		}

		public string Uri { get; private set; }

		public int Depth { get; set; }
	}
}