using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Contingent.Api.Models.OrdersContext;

namespace Contingent.Api.DataAccess
{
    public static class FieldsXmlHelpers
    {
        public static string FieldInfoToXml(IEnumerable<FieldInfo> fields)
        {
            var root = new XElement("Fields");
            root.Add(fields.Select(f => new XElement("Field", f.Caption, new XAttribute("id", f.Id), new XAttribute("type", f.Type))));
            return new XDocument(root).ToString(); 
        }

        public static IEnumerable<FieldInfo> FieldInfoFromXml(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return Enumerable.Empty<FieldInfo>();
            }

            return XDocument.Parse(xml).Descendants("Field").Select(e => new FieldInfo(e.Attribute("id").Value, e.Attribute("caption").Value, e.Attribute("type").Value));
        }

        public static string ValuesToXml(Dictionary<string, string> values)
        {
            var root = new XElement("Values");
            root.Add(values.Select(v => new XElement("Value", v.Value, new XAttribute("field", v.Key))));
            return new XDocument(root).ToString();
        }

        public static Dictionary<string, string> ValuesFromXml(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return new Dictionary<string, string>();
            }

            return XDocument.Parse(xml).Descendants("Value").ToDictionary(k => k.Attribute("field").Value, v => v.Value);
        }
    }
}