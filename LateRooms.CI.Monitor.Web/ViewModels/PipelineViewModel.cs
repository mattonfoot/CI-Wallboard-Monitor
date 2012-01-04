using System.Collections.Generic;
using System.Linq;

namespace LateRooms.CI.Monitor.Web.ViewModels
{
	public class PipelineViewModel
	{
		public PipelineViewModel()
		{
			Stages = Enumerable.Empty<StageViewModel>();
		}

		public IEnumerable<StageViewModel> Stages { get; set; }
	}
}