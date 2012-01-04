using System;
using System.IO;
using System.Text;
using System.Xml;

namespace LateRooms.CI.Monitor.Web.Helpers
{
	public class XmlDeserializer
	{
		public static T From<T>(string xml)
		{
			var xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
			var memoryStream = new MemoryStream(StringToUTF8ByteArray(xml));

			new XmlTextWriter(memoryStream, Encoding.UTF8);

			return (T)xs.Deserialize(memoryStream);
		}

		public static T From<T>(XmlDocument xmlDoc, string originalXml) where T : new()
		{
			var xmlRoot = xmlDoc.DocumentElement;

			return xmlRoot != null ? From<T>(new XmlNodeReader(xmlRoot), originalXml) : new T();
		}

		public static T From<T>(XmlReader xmlReader, string originalXml)
		{
			var xs = new System.Xml.Serialization.XmlSerializer(typeof(T));

			return (T)xs.Deserialize(xmlReader);
		}

		private static Byte[] StringToUTF8ByteArray(string pXmlString)
		{
			return new UTF8Encoding().GetBytes(pXmlString);
		}
	}
}
