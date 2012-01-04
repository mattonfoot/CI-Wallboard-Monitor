using LateRooms.CI.Monitor.Web.Service.Hudson;
using LateRooms.CI.Monitor.Web.Service.Hudson.Responses;
using NUnit.Framework;
using System.Collections.Generic;

namespace LateRooms.CI.Monitor.Test.Service.Hudson
{
	[TestFixture]
	public class HudsonCIApiServiceQueueTests
	{
		private HudsonCIApiService _serviceUnderTest;

		private const string TestApiUri = "http://hudson.test.service:8080";
		private const string SampleBuildProjectName = "Sample Build Project";
		private const int SampleBuildNumber = 241;
		private const int SampleBuildDuration = 6274;

		private HudsonProjectListResponse _projectListResponse;
		private HudsonFreeStyleProjectResponse _projectResponse;
		private HudsonQueueResponse _queueResponse;
		private HudsonFreeStyleBuildResponse _buildResponse;

		[SetUp]
		public void SetUp()
		{
			var fakedBuildResponse = new HudsonBuildResponse
			{
				Number = 241,
				Url = TestApiUri + "/job/" + SampleBuildProjectName + "/" + SampleBuildNumber + "/"
			};

			var fakedLastBuildResponse = new HudsonLastBuildResponse
			{
				Number = 242,
				Url = TestApiUri + "/job/" + SampleBuildProjectName + "/" + SampleBuildNumber + "/"
			};

			var fakedLastCompletedBuildResponse = new HudsonLastCompletedBuildResponse
			{
				Number = 243,
				Url = TestApiUri + "/job/" + SampleBuildProjectName + "/" + SampleBuildNumber + "/"
			};

			var fakedLastFailedBuildResponse = new HudsonLastFailedBuildResponse
			{
				Number = 244,
				Url = TestApiUri + "/job/" + SampleBuildProjectName + "/" + SampleBuildNumber + "/"
			};

			var fakedLastSuccessfulBuildResponse = new HudsonLastSuccessfulBuildResponse
			{
				Number = 245,
				Url = TestApiUri + "/job/" + SampleBuildProjectName + "/" + SampleBuildNumber + "/"
			};

			var fakedLastUnsuccessfulBuildResponse = new HudsonLastUnsuccessfulBuildResponse
			{
				Number = 246,
				Url = TestApiUri + "/job/" + SampleBuildProjectName + "/" + SampleBuildNumber + "/"
			};

			_projectListResponse = new HudsonProjectListResponse();
			_projectResponse = new HudsonFreeStyleProjectResponse
			{
				DisplayName = SampleBuildProjectName,
				Name = SampleBuildProjectName,
				Url = TestApiUri + "/job/" + SampleBuildProjectName + "/",
				Buildable = true,
				Builds = new List<HudsonBuildResponse> { fakedBuildResponse },
				FirstBuild = fakedBuildResponse,
				LastBuild = new List<HudsonLastBuildResponse> { fakedLastBuildResponse },
				LastCompletedBuild = new List<HudsonLastCompletedBuildResponse> { fakedLastCompletedBuildResponse },
				LastFailedBuild = new List<HudsonLastFailedBuildResponse> { fakedLastFailedBuildResponse },
				LastSuccessfulBuild = new List<HudsonLastSuccessfulBuildResponse> { fakedLastSuccessfulBuildResponse },
				LastUnsuccessfulBuild = new List<HudsonLastUnsuccessfulBuildResponse> { fakedLastUnsuccessfulBuildResponse }
			};
			_queueResponse = new HudsonQueueResponse
			{
				Items = new List<HudsonQueueItemResponse>
				        	{
				        		new HudsonQueueItemResponse { Id = 0, Task = new HudsonTaskResponse { Name = SampleBuildProjectName, Color = "green", Url = TestApiUri + "/job/" + SampleBuildProjectName + "/" }},
				        		new HudsonQueueItemResponse { Id = 1, Task = new HudsonTaskResponse { Name = SampleBuildProjectName, Color = "green", Url = TestApiUri + "/job/" + SampleBuildProjectName + "/" }},
				        		new HudsonQueueItemResponse { Id = 2, Task = new HudsonTaskResponse { Name = SampleBuildProjectName, Color = "green", Url = TestApiUri + "/job/" + SampleBuildProjectName + "/" }}
				        	}
			};
			_buildResponse = new HudsonFreeStyleBuildResponse
			{
				BuiltOn = "06/12/2001",
				Duration = SampleBuildDuration,
				FullDisplayName = SampleBuildProjectName + " #" + SampleBuildNumber,
				Id = "2011-12-06_11-47-18",
				IsBuilding = false,
				KeepLog = false,
				Number = SampleBuildNumber,
				Result = "SUCCESS",
				Timestamp = 1323172038606,
				URL = TestApiUri + "/job/" + SampleBuildProjectName + "/" + SampleBuildNumber + "/"
			};

			_serviceUnderTest = new HudsonCIApiService(
				FakeFeedRepositoryFactory.ProjectListRepository(_projectListResponse),
				FakeFeedRepositoryFactory.ProjectRepository(_projectResponse),
				FakeFeedRepositoryFactory.QueueRepository(_queueResponse),
				FakeFeedRepositoryFactory.BuildRepository(_buildResponse)
			);
		}

		[Test]
		public void Get_Queue_Should_Return_A_Project_Build_Queue_Based_On_The_RetrievedResponse()
		{
			/*
			var itemCount = _serviceUnderTest.GetQueue().Items.Count;

			Assert.That(itemCount, Is.EqualTo(3));
			/*
			Assert.That(items[0].Name, Is.EqualTo("Item 1"));
			Assert.That(items[1].Name, Is.EqualTo("Item 2"));
			Assert.That(items[2].Name, Is.EqualTo("Item 3"));
			*/
		}
	}
}
