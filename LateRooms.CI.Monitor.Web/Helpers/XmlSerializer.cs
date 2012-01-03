using System.IO;
using System.Text;
using System.Xml;

namespace LateRooms.CI.Monitor.Web.Helpers
{
	public class XmlSerializer
	{
		public static string To<T>(T obj)
		{
			try
			{
				var memoryStream = new MemoryStream();
				var xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
				var xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

				xs.Serialize(xmlTextWriter, obj);
				memoryStream = (MemoryStream)xmlTextWriter.BaseStream;

				return UTF8ByteArrayToString(memoryStream.ToArray());
			}
			catch
			{
				return string.Empty;
			}
		}

		private static string UTF8ByteArrayToString(byte[] characters)
		{
			return new UTF8Encoding().GetString(characters);
		}
	}
}