using LateRooms.CI.Monitor.Web.Enums;
using LateRooms.CI.Monitor.Web.Service;
using LateRooms.CI.Monitor.Web.Service.Models;

namespace LateRooms.CI.Monitor.Web.Controllers
{
	public class ProjectListRetriever
	{
		private readonly ICIApiService _ciApiService;

		public ProjectListRetriever(CIServerType ciServerType, string serveruri)
		{
			var factory = new CIApiServiceFactory(serveruri);

			switch(ciServerType)
			{
				case CIServerType.Hudson:
					_ciApiService = factory.BuildHudsonCIApiService();
					break;

				default:
					_ciApiService = factory.BuildHudsonCIApiService();
					break;
			}
		}

		public ProjectList GetProjectList()
		{
			return _ciApiService.GetProjectList();
		}
	}
}