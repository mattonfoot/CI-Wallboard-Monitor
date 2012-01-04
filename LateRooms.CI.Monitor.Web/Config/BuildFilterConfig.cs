﻿using System.Xml.Serialization;

namespace LateRooms.CI.Monitor.Web.Config
{
	[XmlRoot("filter")]
	public class BuildFilterConfig
	{
		[XmlAttribute("pattern")]
		public string Pattern { get; set; }
	}
}