using System;

namespace LateRooms.CI.Monitor.Web.Repositories
{
	public class ServiceNotAvailableException : Exception
	{
		public ServiceNotAvailableException(string message, Exception innerException)
			: base(message, innerException)
		{
			
		}
	}
}