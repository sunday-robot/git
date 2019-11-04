using System.Collections.Generic;

namespace XDocumentTest
{
    static class TestDictionary
    {
        public static void Test()
        {
            var str2int = new Dictionary<string, int>() { { "abc", 1 }, { "def", 0 }, { "ghi", -2 } };
            XmlUtil.SaveAsXml(nameof(str2int), str2int, $"{nameof(str2int)}.xml");
            var xe = XmlUtil.ConvertToXElement(nameof(str2int), str2int);
            var recovered = (Dictionary<string, int>)XmlUtil.CreateFromXmlElement(typeof(Dictionary<string, int>), xe);
        }
    }
}
