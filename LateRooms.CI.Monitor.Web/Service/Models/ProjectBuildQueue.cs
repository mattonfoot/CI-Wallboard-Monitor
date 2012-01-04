using System.Collections.Generic;

namespace LateRooms.CI.Monitor.Web.Service.Models
{
	public class ProjectBuildQueue
	{
		public ProjectBuildQueue(IEnumerable<Project> queue)
		{
			Items = queue;
		}

		public IEnumerable<Project> Items { get; private set; }
	}
}