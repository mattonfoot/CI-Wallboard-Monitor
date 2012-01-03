using System.Collections.Generic;

namespace LateRooms.CI.Monitor.Web.ViewModels
{
	public class PipelineViewModel
	{
		public PipelineViewModel()
		{
			Stages = new List<StageViewModel>();
		}


		public List<StageViewModel> Stages { get; set; }
	}
}