using System;

namespace LateRooms.CI.Monitor.Web.Helpers
{

	public class JavaTimeStamp
	{
		private readonly double _timestamp;

		public decimal Ticks { get { return ToDateTime().Ticks;  } }

		public JavaTimeStamp(double timestamp)
		{
			_timestamp = timestamp;
		}

		public DateTime ToDateTime()
		{
			var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
			return dtDateTime.AddSeconds(Math.Round(_timestamp / 1000)).ToLocalTime();
		}

	}

}