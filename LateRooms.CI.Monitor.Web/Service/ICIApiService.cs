using LateRooms.CI.Monitor.Web.Service.Models;

namespace LateRooms.CI.Monitor.Web.Service
{
	public interface ICIApiService
	{
		ProjectList GetProjectList();
		ProjectBuildQueue GetQueue();
		Project GetProject(string projectName);
		BuildJob GetBuild(string projectName, long buildNumber);
	}
}