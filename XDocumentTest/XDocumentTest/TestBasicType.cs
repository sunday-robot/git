namespace XDocumentTest
{
    static class TestBasicType
    {
        public static void Test()
        {
            var intVar = 123;
            XmlUtil.SaveAsXml(nameof(intVar), intVar, $"{nameof(intVar)}.xml");
            var xe = XmlUtil.ConvertToXElement(nameof(intVar), intVar);
            var recoveredIntVar = (int)XmlUtil.CreateFromXmlElement(typeof(int), xe);
        }
    }
}
