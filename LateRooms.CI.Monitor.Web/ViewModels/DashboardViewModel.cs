using System.Collections.Generic;

namespace LateRooms.CI.Monitor.Web.ViewModels
{
	public class DashboardViewModel
	{
		public DashboardViewModel()
		{
			BuildServers = new List<BuildServerViewModel>();

			Jobs = new List<JobViewModel>();
		}

		public string Monitor { get; set; }

		public string DashboardName { get; set; }

		public string Error { get; set; }

		public List<BuildServerViewModel> BuildServers { get; set; }
    
		public List<JobViewModel> Jobs { get; set; }
	}
}