using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;

namespace LateRooms.CI.Monitor.Web.Builders
{
	public class RequestUrlBuilder
	{
		private readonly object _request;
		private readonly string _serverUri;

		private RequestUrlBuilder(string serverUri, object request)
		{
			_request = request;
			_serverUri = serverUri;
		}

		public static RequestUrlBuilder From(string serverUri, object request)
		{
			return new RequestUrlBuilder(serverUri, request);
		}

		public string Build()
		{
			var path = string.Empty;
			var sb = new StringBuilder();

			foreach (var prop in GetProperties(_request))
			{
				if (prop.Name.ToLower() == "uri")
				{
					path = prop.Value.ToString();
					continue;
				}

				if (sb.Length > 0) sb.Append("&");
				sb.Append(HttpUtility.UrlEncode(prop.Name));
				sb.Append("=");
				sb.Append(HttpUtility.UrlEncode(prop.Value.ToString()));
			}

			return string.Format("{0}{1}?{2}", _serverUri, path, sb);
		}

		private static IEnumerable<PropertyValue> GetProperties(object o)
		{
			return from PropertyDescriptor prop in TypeDescriptor.GetProperties(o) let val = prop.GetValue(o) 
			       where val != null 
			       select new PropertyValue {Name = prop.Name, Value = val};
		}

		private sealed class PropertyValue
		{
			public string Name { get; set; }
			public object Value { get; set; }
		}
	}
}