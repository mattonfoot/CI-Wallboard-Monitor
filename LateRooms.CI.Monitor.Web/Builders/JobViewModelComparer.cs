using System.Collections.Generic;
using LateRooms.CI.Monitor.Web.ViewModels;

namespace LateRooms.CI.Monitor.Web.Builders
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