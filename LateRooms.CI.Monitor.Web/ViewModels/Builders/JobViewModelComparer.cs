using System.Collections.Generic;

namespace LateRooms.CI.Monitor.Web.ViewModels.Builders
{
	internal class JobViewModelComparer : IEqualityComparer<JobViewModel>
	{
		public bool Equals(JobViewModel x, JobViewModel y)
		{
			return x.Name == y.Name;
		}

		public int GetHashCode(JobViewModel obj)
		{
			return obj.Name.GetHashCode();
		}
	}
}