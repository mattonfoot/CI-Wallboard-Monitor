using System.Collections.Generic;
using LateRooms.CI.Monitor.Web.Service.Models;

namespace LateRooms.CI.Monitor.Web.Service.Hudson.Mappers
{
	public static class ProjectListMapper
	{
		public static ProjectList FromHudsonAPI(string nodeDescription, IEnumerable<Project> jobs)
		{
			return new ProjectList(nodeDescription, jobs);
		}
	}
}