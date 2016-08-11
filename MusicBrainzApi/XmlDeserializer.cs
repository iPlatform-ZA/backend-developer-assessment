using System.IO;
using System.Xml.Serialization;

namespace MusicBrainsAPI
{
    internal class XmlDeserializer
    {
        public static T Deserialize<T>(string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (TextReader textReader = new StringReader(xmlString))
            {
                return (T)serializer.Deserialize(textReader);
            }
        }
    }
}
