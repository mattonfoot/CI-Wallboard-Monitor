using System;
using System.Collections.Generic;
using System.Linq;
using LateRooms.CI.Monitor.Web.Mappers;
using LateRooms.CI.Monitor.Web.Repositories;
using LateRooms.CI.Monitor.Web.Service.Hudson.Requests;
using LateRooms.CI.Monitor.Web.Service.Hudson.Responses;
using LateRooms.CI.Monitor.Web.Service.Models;

namespace LateRooms.CI.Monitor.Web.Service.Hudson
{
	public class HudsonCIApiService : ICIApiService
	{
		private IFeedRepository<HudsonProjectListRequest, HudsonProjectListResponse> ProjectListRepository { get; set; }
		private IFeedRepository<HudsonProjectRequest, HudsonFreeStyleProjectResponse> ProjectRepository { get; set; }
		private IFeedRepository<HudsonQueueRequest, HudsonQueueResponse> QueueRepository { get; set; }
		private IFeedRepository<HudsonBuildRequest, HudsonFreeStyleBuildResponse> BuildRepository { get; set; }

		public HudsonCIApiService(
			IFeedRepository<HudsonProjectListRequest, HudsonProjectListResponse> projectListRepository,
			IFeedRepository<HudsonProjectRequest, HudsonFreeStyleProjectResponse> projectRepository,
			IFeedRepository<HudsonQueueRequest, HudsonQueueResponse> queueRepository,
			IFeedRepository<HudsonBuildRequest, HudsonFreeStyleBuildResponse> buildRepository)
		{
			QueueRepository = queueRepository;
			ProjectListRepository = projectListRepository;
			ProjectRepository = projectRepository;
			BuildRepository = buildRepository;
		}

		public ProjectList GetProjectList()
		{
			try
			{
				var request = new HudsonProjectListRequest();
				var response = ProjectListRepository.Get(request);

				var jobList = response.Jobs
															.Select(job => GetProject(job.Name))
															.Where(job => job.UpstreamProjects.Count() == 0);
	     
				return ProjectListMapper.FromHudsonAPI(response.NodeDescription, jobList);
			}
			catch (Exception e)
			{
				return new ProjectList(e.Message);
			}
		}

		private ProjectBuildQueue _cachedQueue;
		public ProjectBuildQueue GetQueue()
		{
			if (_cachedQueue != null) return _cachedQueue;

			var request = new HudsonQueueRequest();

			var response = QueueRepository.Get(request);
			var projectBuildQueue = response.Items
																			.Where(build => build.Task != null)
																			.Select(build => GetProject(build.Task.Name))
																			.ToList();

			_cachedQueue = ProjectBuildQueueMapper.FromHudsonAPI(projectBuildQueue);

			return _cachedQueue;
		}

		private readonly List<Project> _cachedProjects = new List<Project>();
		public Project GetProject(string projectName)
		{
			var cachedProject = _cachedProjects.Where(x => x.Name == projectName).FirstOrDefault();
			if (cachedProject != null) return cachedProject;

			var request = new HudsonProjectRequest { Name = projectName };

			var response = ProjectRepository.Get(request);

			var lastbuild = GetBuild(response.Name, response.LastCompletedBuild.Number);
			var successfulbuild = GetBuild(response.Name, response.LastSuccessfulBuild.Number);
			var completedbuild = GetBuild(response.Name, response.LastCompletedBuild.Number);
			var currentbuild = GetBuild(response.Name, response.LastBuild.Number);

			var upstreamProjects = response.UpstreamProjects
																			.Select(x => GetProject(x.Name));

			var downstreamProjects = response.DownstreamProjects
																				.Select(x => GetProject(x.Name));

			var queue = GetQueue();

			var project = ProjectMapper.FromHudsonAPI(response, lastbuild, successfulbuild, completedbuild, currentbuild,
			                                          upstreamProjects, downstreamProjects, queue);
			_cachedProjects.Add(project);

			return project;
		}

		private readonly List<BuildJob> _cachedBuild = new List<BuildJob>();
		public BuildJob GetBuild(string projectName, long buildNumber)
		{
			var cachedBuild = _cachedBuild.Where(x => x.ProjectName == projectName && x.Number == buildNumber).FirstOrDefault();
			if (cachedBuild != null) return cachedBuild;

			var request = new HudsonBuildRequest { Name = projectName, BuildNumber = buildNumber };

			var response = BuildRepository.Get(request);

			var build = BuildJobMapper.FromHudsonAPI(projectName, response);

			_cachedBuild.Add(build);

			return build;
		}
	}
}
