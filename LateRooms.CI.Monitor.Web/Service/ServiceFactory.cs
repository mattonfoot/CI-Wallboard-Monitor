using LateRooms.CI.Monitor.Web.Caching;
using LateRooms.CI.Monitor.Web.Service.Connectors;
using LateRooms.CI.Monitor.Web.Service.Hudson;
using LateRooms.CI.Monitor.Web.Service.Hudson.Requests;
using LateRooms.CI.Monitor.Web.Service.Hudson.Responses;
using StructureMap;

namespace LateRooms.CI.Monitor.Web.Service
{
	public class CIApiServiceFactory
	{
		private readonly string _serverUri;

		public CIApiServiceFactory(string serveruri)
		{
			_serverUri = serveruri;
		}

		public HudsonCIApiService BuildHudsonCIApiService()
		{
			return new HudsonCIApiService(
				BuildHudsonFeedRepository<HudsonProjectListRequest, HudsonProjectListResponse>(_serverUri),
				BuildHudsonFeedRepository<HudsonProjectRequest, HudsonFreeStyleProjectResponse>(_serverUri),
				BuildHudsonFeedRepository<HudsonQueueRequest, HudsonQueueResponse>(_serverUri),
				BuildHudsonFeedRepository<HudsonBuildRequest, HudsonFreeStyleBuildResponse>(_serverUri)
			);
		}

		private static IRepository<TRequest, TResponse> BuildHudsonFeedRepository<TRequest, TResponse>(string serverUri)
			where TRequest : new()
			where TResponse : new()
		{
			var scope = ObjectFactory.GetInstance<IScopedCacheWrapper>();

			return new XmlRepository<TRequest, TResponse>(scope) { ServerUri = serverUri };
		}
	}
}