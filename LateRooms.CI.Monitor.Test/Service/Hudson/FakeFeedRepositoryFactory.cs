using LateRooms.CI.Monitor.Web.Repositories;
using LateRooms.CI.Monitor.Web.Service.Hudson.Requests;
using LateRooms.CI.Monitor.Web.Service.Hudson.Responses;

namespace LateRooms.CI.Monitor.Test.Service.Hudson
{
	public static class FakeFeedRepositoryFactory
	{
		public static IFeedRepository<HudsonProjectListRequest, HudsonProjectListResponse> ProjectListRepository(HudsonProjectListResponse response)
		{
			return new FakeProjectListRepository(response);
		}

		public static IFeedRepository<HudsonProjectRequest, HudsonFreeStyleProjectResponse> ProjectRepository(HudsonFreeStyleProjectResponse response)
		{
			return new FakeProjectRepository(response);
		}

		public static IFeedRepository<HudsonQueueRequest, HudsonQueueResponse> QueueRepository(HudsonQueueResponse response)
		{
			return new FakeQueueRepository(response);
		}

		public static IFeedRepository<HudsonBuildRequest, HudsonFreeStyleBuildResponse> BuildRepository(HudsonFreeStyleBuildResponse response)
		{
			return new FakeBuildRepository(response);
		}
	}

	public class FakeQueueRepository : IFeedRepository<HudsonQueueRequest, HudsonQueueResponse>
	{
		private readonly HudsonQueueResponse _response;

		public FakeQueueRepository()
		{
		}

		public FakeQueueRepository(HudsonQueueResponse response)
		{
			_response = response;
		}

		public string ServerUri { get; set; }

		public HudsonQueueResponse Get(HudsonQueueRequest request)
		{
			return _response ?? new HudsonQueueResponse();
		}
	}

	public class FakeBuildRepository : IFeedRepository<HudsonBuildRequest, HudsonFreeStyleBuildResponse>
	{
		private readonly HudsonFreeStyleBuildResponse _response;

		public FakeBuildRepository()
		{
		}

		public FakeBuildRepository(HudsonFreeStyleBuildResponse response)
		{
			_response = response;
		}

		public string ServerUri { get; set; }

		public HudsonFreeStyleBuildResponse Get(HudsonBuildRequest request)
		{
			_response.URL = request.Uri;
			_response.FullDisplayName = request.Name;
			_response.Id = request.BuildNumber.ToString();

			return _response ?? new HudsonFreeStyleBuildResponse();
		}
	}

	public class FakeProjectRepository : IFeedRepository<HudsonProjectRequest, HudsonFreeStyleProjectResponse>
	{
		private readonly HudsonFreeStyleProjectResponse _response;

		public FakeProjectRepository()
		{
		}

		public FakeProjectRepository(HudsonFreeStyleProjectResponse response)
		{
			_response = response;
		}

		public string ServerUri { get; set; }

		public HudsonFreeStyleProjectResponse Get(HudsonProjectRequest request)
		{
			_response.Description = request.Name;
			_response.Url = request.Uri;
			_response.Name = request.Name;

			return _response ?? new HudsonFreeStyleProjectResponse();
		}
	}

	public class FakeProjectListRepository : IFeedRepository<HudsonProjectListRequest, HudsonProjectListResponse>
	{
		private readonly HudsonProjectListResponse _response;

		public FakeProjectListRepository()
		{
		}

		public FakeProjectListRepository(HudsonProjectListResponse response)
		{
			_response = response;
		}

		public string ServerUri { get; set; }

		public HudsonProjectListResponse Get(HudsonProjectListRequest request)
		{
			return _response ?? new HudsonProjectListResponse();
		}
	}
}