﻿namespace LateRooms.CI.Monitor.Web.Wrappers
{
	public interface IScopedCacheWrapper
	{
		T Get<T>(string cacheKey) where T : new();
		bool Insert(string cacheKey, object value, int minutes);
	}
}