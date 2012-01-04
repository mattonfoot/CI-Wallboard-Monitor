using System.Collections.Generic;
using System.Linq;

namespace LateRooms.CI.Monitor.Web.ViewModels
{
	public class StageViewModel
	{
		public StageViewModel()
		{
			Jobs = Enumerable.Empty<JobViewModel>();
			NumberOfJobs = 1;
		}

		public int NumberOfJobs { get; set; }

		public IEnumerable<JobViewModel> Jobs { get; set; }
	}
}