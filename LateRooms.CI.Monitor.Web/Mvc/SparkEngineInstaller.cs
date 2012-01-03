using System;
using System.Reflection;
using System.Web.Mvc;
using Spark;
using Spark.Web.Mvc;

namespace LateRooms.CI.Monitor.Web.Mvc
{
	public static class SparkEngineInstaller
	{
		public static void Install(ViewEngineCollection engines)
		{
			if (engines == null)
				throw new ApplicationException("ViewEngines.Engines Found");

			var sparkSettings = GetSparkSettings(Assembly.GetCallingAssembly());
			var sparkViewFactory = new SparkViewFactory(sparkSettings);

			engines.Clear();
			engines.Add(sparkViewFactory);
		}

		private static ISparkSettings GetSparkSettings(Assembly callingAssembly)
		{
			var sparkSettings = new SparkSettings();

			sparkSettings.AddAssembly(callingAssembly);
			
#if DEBUG
			sparkSettings.SetDebug(true);
#endif

			sparkSettings.SetAutomaticEncoding(false);
			sparkSettings.NullBehaviour = NullBehaviour.Strict;

			return sparkSettings;
		}
	}
}