using LateRooms.CI.Monitor.Web.Repositories;
using LateRooms.CI.Monitor.Web.Wrappers;
using StructureMap;

namespace LateRooms.CI.Monitor.Web.Config
{
	public static class StructureMapConfiguration
	{
		public static void Register()
		{
			ObjectFactory.Initialize(x =>
			{
				x.Scan(s =>
				{
					s.TheCallingAssembly();
					s.WithDefaultConventions();
				});

				x.For<IScopedCacheWrapper>().Use<RequestScopedCacheWrapper>();

				x.For(typeof(IFeedRepository<,>)).Use(typeof(XmlFeedRepository<,>));
			});
		}

		public static void DeRegister()
		{
			ObjectFactory.ReleaseAndDisposeAllHttpScopedObjects();
		}
	}
}