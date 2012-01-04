using System.Collections.Generic;

namespace LateRooms.CI.Monitor.Web.ViewModels
{
	public class BuildServerViewModel
	{
		public BuildServerViewModel(string name, int columns)
		{
			Name = name;
			Columns = columns;

			Pipelines = new List<List<PipelineViewModel>>();
		}

		public string Name { get; private set; }

		public int Columns { get; private set; }

		public List<List<PipelineViewModel>> Pipelines { get; set; }
	}
}