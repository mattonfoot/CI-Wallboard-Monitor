using System.Collections.Generic;
using LateRooms.CI.Monitor.Web.Service.Models;

namespace LateRooms.CI.Monitor.Web.Mappers
{
	public static class ProjectBuildQueueMapper
	{
		public static ProjectBuildQueue FromHudsonAPI(IList<Project> queue)
		{
			return new ProjectBuildQueue(queue);
		}
	}
}