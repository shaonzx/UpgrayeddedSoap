using System.Text;
using System.Xml.Serialization;

namespace UpgrayeddedSoap.Helpers
{
    public static class CandyDataFormatter
    {
        public static T Deserialize<T>(string input)
        {
            var reqSerializer = new XmlSerializer(typeof(T));
            using (var stringReader = new StringReader(input))
            {
                return (T)reqSerializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
            }
        }

        public static string Serialize<T>(T input)
        {
            var respSerializer = new XmlSerializer(typeof(T));
            using (var ms = new MemoryStream())
            {
                respSerializer.Serialize(ms, input);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }
}
