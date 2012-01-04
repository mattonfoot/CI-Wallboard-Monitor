using LateRooms.CI.Monitor.Web.Caching;
using LateRooms.CI.Monitor.Web.Service.Connectors;
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

				x.For(typeof(IRepository<,>)).Use(typeof(XmlRepository<,>));
			});
		}

		public static void DeRegister()
		{
			ObjectFactory.ReleaseAndDisposeAllHttpScopedObjects();
		}
	}
}