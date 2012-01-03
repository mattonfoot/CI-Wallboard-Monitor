using System.Collections.Generic;

namespace LateRooms.CI.Monitor.Web.ViewModels
{
	public class StageViewModel
	{
		public StageViewModel()
		{
			Jobs = new List<JobViewModel>();
		}

		public List<JobViewModel> Jobs { get; set; }
	}
}