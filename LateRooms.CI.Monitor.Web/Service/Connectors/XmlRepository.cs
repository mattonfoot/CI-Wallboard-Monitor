using System;
using System.Xml;
using LateRooms.CI.Monitor.Web.Caching;
using LateRooms.CI.Monitor.Web.Helpers;

namespace LateRooms.CI.Monitor.Web.Service.Connectors
{
	public class XmlRepository<TRequest, TResponse> : IRepository<TRequest, TResponse>
			where TRequest : new() 
			where TResponse : new()
	{
		private IScopedCacheWrapper ScopedCacheWrapper { get; set; }

		public string ServerUri { get; set; }

		public XmlRepository(IScopedCacheWrapper scopedCacheWrapper)
		{
			ScopedCacheWrapper = scopedCacheWrapper;
		}

		public TResponse Get(TRequest request)
		{
			var remoteUri = RequestUrlBuilder.From(ServerUri, request).Build();

			var xmlDoc = new XmlDocument();
			var cacheKey = string.Format("RepositoryXml:{0}", remoteUri);

			var fromCache = ScopedCacheWrapper.Get<XmlDocument>(cacheKey);

			if (fromCache.InnerXml != "")
			{
				xmlDoc = fromCache;
			}
			else
			{
				try
				{
					xmlDoc.Load(remoteUri);
					ScopedCacheWrapper.Insert(cacheKey, xmlDoc, 60);
				}
				catch (Exception)
				{
					return new TResponse();
				}
			}

			return XmlDeserializer.From<TResponse>(xmlDoc, xmlDoc.InnerText);
		}
	}
}
