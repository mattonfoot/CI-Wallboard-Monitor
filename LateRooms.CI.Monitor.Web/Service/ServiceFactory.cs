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
				BuildXmlRepository<HudsonProjectListRequest, HudsonProjectListResponse>(_serverUri, "request"),
				BuildXmlRepository<HudsonProjectRequest, HudsonFreeStyleProjectResponse>(_serverUri, "request"),
				BuildXmlRepository<HudsonQueueRequest, HudsonQueueResponse>(_serverUri, "request"),
				BuildXmlRepository<HudsonBuildRequest, HudsonFreeStyleBuildResponse>(_serverUri, "request")
			);
		}

		private static IRepository<TRequest, TResponse> BuildXmlRepository<TRequest, TResponse>(string serverUri, string cachescope)
			where TRequest : new()
			where TResponse : new()
		{
			var scope = ObjectFactory.GetNamedInstance<IScopedCacheWrapper>(cachescope);

			return new XmlRepository<TRequest, TResponse>(scope) { ServerUri = serverUri };
		}
	}
}