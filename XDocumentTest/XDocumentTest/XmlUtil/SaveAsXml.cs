using System.Xml.Linq;

namespace XDocumentTest
{
    static partial class XmlUtil
    {
        public static void SaveAsXml(string name, object o, string filePath)
        {
            var r = new XDocument();
            r.Add(XmlUtil.ConvertToXElement(name, o));
            r.Save(filePath);
        }
    }
}
