using System.Collections.Generic;
using System.Linq;

namespace LateRooms.CI.Monitor.Web.ViewModels
{
	public class DashboardViewModel
	{
		public DashboardViewModel()
		{
			Monitors = Enumerable.Empty<string>();
			BuildServers = Enumerable.Empty<BuildServerViewModel>();
		}

		public string DashboardName { get; set; }

		public string Error { get; set; }

		public IEnumerable<string> Monitors { get; set; }

		public IEnumerable<BuildServerViewModel> BuildServers { get; set; }
	}
}