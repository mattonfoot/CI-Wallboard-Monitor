using System.Collections.Generic;
using System.Web;

namespace LateRooms.CI.Monitor.Web.Wrappers
{
	public class RequestScopedCacheWrapper : IScopedCacheWrapper
	{
		public T Get<T>(string cacheKey) where T : new()
		{
			var fromCache = HttpContext.Current.Items[cacheKey];

			if (fromCache != null)
			{
				return (T)fromCache;
			}

			return new T();
		}

		public bool Insert(string cacheKey, object value, int minutes)
		{
			if (value == null) return false;

			if (value is List<object> && ((List<object>)value).Count == 0) return false;

			HttpContext.Current.Items.Add(cacheKey, value);

			return true;
		}
	}
}
