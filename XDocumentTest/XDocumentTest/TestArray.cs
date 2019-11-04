namespace XDocumentTest
{
    static class TestArray
    {
        public static void Test()
        {
            var intArray = new int[] { 1, 2, 3, 0, -1 };
            XmlUtil.SaveAsXml(nameof(intArray), intArray, $"{nameof(intArray)}.xml");
            var xe = XmlUtil.ConvertToXElement(nameof(intArray), intArray);
            var recovered = (int[]) XmlUtil.CreateFromXmlElement(typeof(int[]), xe);
        }
    }
}
