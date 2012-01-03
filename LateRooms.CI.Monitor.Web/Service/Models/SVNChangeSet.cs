namespace LateRooms.CI.Monitor.Web.Service.Models
{
	public class SVNChangeSet
	{
		public SVNChangeSet(string user, long revision)
		{
			User = user;
			Revision = revision;
		}

		public string User { get; set; }
		public long Revision { get; set; }
	}
}