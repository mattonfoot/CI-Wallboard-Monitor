using System.Collections.Generic;
using System.Linq;

namespace LateRooms.CI.Monitor.Web.ViewModels
{
	public class BuildServerViewModel
	{
		public BuildServerViewModel(string name, int columns)
		{
			Name = name;
			Columns = columns;

			Pipelines = Enumerable.Empty<IEnumerable<PipelineViewModel>>();
		}

		public string Name { get; private set; }

		public int Columns { get; private set; }

		public IEnumerable<IEnumerable<PipelineViewModel>> Pipelines { get; set; }
	}
}