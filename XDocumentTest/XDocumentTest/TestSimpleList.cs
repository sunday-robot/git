using System.Collections.Generic;

namespace XDocumentTest
{
    static class TestSimpleList
    {
        public static void Test()
        {
            var stringList = new List<string>() { "abc", "あいう" };
            XmlUtil.SaveAsXml(nameof(stringList), stringList, $"{nameof(stringList)}.xml");
            var xe = XmlUtil.ConvertToXElement(nameof(stringList), stringList);
            var recovered = (List<string>) XmlUtil.CreateFromXmlElement(stringList.GetType(), xe);
        }
    }
}
