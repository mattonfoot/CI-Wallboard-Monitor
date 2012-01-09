using LateRooms.CI.Monitor.Web.Helpers;

namespace LateRooms.CI.Monitor.Web.Config.Models
{
	public class ConfigLoader
	{
		private readonly XmlFileLoader _xmlFileLoader;

		public ConfigLoader(XmlFileLoader xmlFileLoader)
		{
			_xmlFileLoader = xmlFileLoader;
		}

		public MonitorConfig From(string configPath)
		{
			return _xmlFileLoader.Get<MonitorConfig>(configPath);
		}
	}
}