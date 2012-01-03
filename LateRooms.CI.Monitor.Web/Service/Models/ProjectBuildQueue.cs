using System.Collections.Generic;

namespace LateRooms.CI.Monitor.Web.Service.Models
{
	public class ProjectBuildQueue
	{
		public ProjectBuildQueue(IList<Project> queue)
		{
			Items = queue;
		}

		public IList<Project> Items { get; private set; }
	}
}