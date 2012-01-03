using System;
using System.Xml;
using LateRooms.CI.Monitor.Web.Builders;
using LateRooms.CI.Monitor.Web.Helpers;
using LateRooms.CI.Monitor.Web.Wrappers;

namespace LateRooms.CI.Monitor.Web.Repositories
{
	public class XmlFeedRepository<TRequest, TResponse> : IFeedRepository<TRequest, TResponse>
			where TRequest : new() 
			where TResponse : new()
	{
		private IScopedCacheWrapper ScopedCacheWrapper { get; set; }

		public string ServerUri { get; set; }

		public XmlFeedRepository(IScopedCacheWrapper scopedCacheWrapper)
		{
			ScopedCacheWrapper = scopedCacheWrapper;
		}

		public TResponse Get(TRequest request)
		{
			var remoteUri = RequestUrlBuilder.From(ServerUri, request).Build();

			var xmlDoc = new XmlDocument();
			var cacheKey = string.Format("FeedXml:{0}", remoteUri);

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
				catch (Exception e)
				{
					throw new ServiceNotAvailableException(string.Format("Server [{0}] Not Available", ServerUri), e);
				}
			}

			return XmlDeserializer.From<TResponse>(xmlDoc);
		}
	}
}
