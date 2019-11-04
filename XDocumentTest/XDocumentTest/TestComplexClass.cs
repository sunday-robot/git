using System;
using System.Collections.Generic;

namespace XDocumentTest
{
    internal class TestComplexClass
    {
        internal static void Test()
        {
            var complexClass = new ComplexClass();
            complexClass.A = 1;
            complexClass.B = "あ";
            complexClass.C = new List<string> { "abc", "def" };
            complexClass.D.A = 2;
            complexClass.D.B = "い";
            complexClass.D.C = new List<string> { "あいう", "えおか" };
            XmlUtil.SaveAsXml(nameof(complexClass), complexClass, $"{nameof(complexClass)}.xml");
        }
    }
}