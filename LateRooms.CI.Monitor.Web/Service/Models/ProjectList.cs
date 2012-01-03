using System.Collections.Generic;
using System.Linq;

namespace LateRooms.CI.Monitor.Web.Service.Models
{
	public class ProjectList
	{
		public ProjectList(string description, IEnumerable<Project> jobs)
		{
			Projects = jobs;
			Description = description;
		}

		public ProjectList(string description)
		{
			Projects = Enumerable.Empty<Project>();
			Description = description;
		}

		public string Description { get; private set; }

		public IEnumerable<Project> Projects { get; private set; }
	}
}