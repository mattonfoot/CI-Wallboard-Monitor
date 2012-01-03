using System.Collections.Generic;

namespace LateRooms.CI.Monitor.Web.ViewModels
{
	public class BuildServerViewModel
	{
		public BuildServerViewModel()
		{
			Pipelines = new List<PipelineViewModel>();
		}

		public List<PipelineViewModel> Pipelines { get; set; }
	}
}