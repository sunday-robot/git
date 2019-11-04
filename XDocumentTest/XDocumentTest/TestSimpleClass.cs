using System.Collections.Generic;

namespace XDocumentTest
{
    static class TestSimpleClass
    {
        public static void Test()
        {
            var simpleClass = new SimpleClass();
            simpleClass.A = 1;
            simpleClass.B = "あ";
            simpleClass.C = new List<string> { "abc", "def" };
            XmlUtil.SaveAsXml(nameof(simpleClass), simpleClass, $"{nameof(simpleClass)}.xml");
        }
    }
}
