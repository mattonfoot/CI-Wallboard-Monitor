using System.Collections.Generic;
using LateRooms.CI.Monitor.Web.Service.Hudson;
using LateRooms.CI.Monitor.Web.Service.Hudson.Responses;
using NUnit.Framework;

namespace LateRooms.CI.Monitor.Test.Service.Hudson
{
	[TestFixture]
	public class HudsonCIApiServiceProjectTests
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
				Number = 241,
				Url = TestApiUri + "/job/" + SampleBuildProjectName + "/" + SampleBuildNumber + "/"
			};

			var fakedLastCompletedBuildResponse = new HudsonLastCompletedBuildResponse
			{
				Number = 241,
				Url = TestApiUri + "/job/" + SampleBuildProjectName + "/" + SampleBuildNumber + "/"
			};

			var fakedLastFailedBuildResponse = new HudsonLastFailedBuildResponse
			{
				Number = 241,
				Url = TestApiUri + "/job/" + SampleBuildProjectName + "/" + SampleBuildNumber + "/"
			};

			var fakedLastSuccessfulBuildResponse = new HudsonLastSuccessfulBuildResponse
			{
				Number = 241,
				Url = TestApiUri + "/job/" + SampleBuildProjectName + "/" + SampleBuildNumber + "/"
			};

			var fakedLastUnsuccessfulBuildResponse = new HudsonLastUnsuccessfulBuildResponse
			{
				Number = 241,
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
														LastBuild = fakedLastBuildResponse,
														LastCompletedBuild = fakedLastCompletedBuildResponse,
														LastFailedBuild = fakedLastFailedBuildResponse,
														LastSuccessfulBuild = fakedLastSuccessfulBuildResponse,
														LastUnsuccessfulBuild = fakedLastUnsuccessfulBuildResponse
			                   	};

			_queueResponse = new HudsonQueueResponse();
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
		public void Get_Queue_Should_Return_A_Build_Based_On_The_Retrieved_Request()
		{
			var build = _serviceUnderTest.GetBuild(SampleBuildProjectName, SampleBuildNumber);

			Assert.That(build.ProjectName, Is.EqualTo(SampleBuildProjectName));
			Assert.That(build.Number, Is.EqualTo(SampleBuildNumber));
			Assert.That(build.Duration, Is.EqualTo(SampleBuildDuration));
		}
	}
}
