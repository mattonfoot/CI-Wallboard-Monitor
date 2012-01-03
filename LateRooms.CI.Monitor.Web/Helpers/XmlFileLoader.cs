﻿using System;
using System.Xml;
using LateRooms.CI.Monitor.Web.Repositories;
using LateRooms.CI.Monitor.Web.Wrappers;

namespace LateRooms.CI.Monitor.Web.Helpers
{
	public class XmlFileLoader
	{
		private IScopedCacheWrapper ScopedCacheWrapper { get; set; }

		public XmlFileLoader(IScopedCacheWrapper scopedCacheWrapper)
		{
			ScopedCacheWrapper = scopedCacheWrapper;
		}

		public TResponse Get<TResponse>(string filepath)
			where TResponse : new()
		{
			var xmlDoc = new XmlDocument();
			var cacheKey = string.Format("FileXml:{0}", filepath);

			var fromCache = ScopedCacheWrapper.Get<XmlDocument>(cacheKey);

			if (fromCache.InnerXml != "")
			{
				xmlDoc = fromCache;
			}
			else
			{
				try
				{
					xmlDoc.Load(filepath);
					ScopedCacheWrapper.Insert(cacheKey, xmlDoc, 60);
				}
				catch (Exception e)
				{
					throw new ServiceNotAvailableException(string.Format("File not available [{0}]", filepath), e);
				}
			}

			return XmlDeserializer.From<TResponse>(xmlDoc);
		}
	}
}