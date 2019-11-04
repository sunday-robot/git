namespace XDocumentTest
{
    static class TestEmptyArray
    {
        public static void Test()
        {
            var emptyIntArray = new int[] { };
            XmlUtil.SaveAsXml(nameof(emptyIntArray), emptyIntArray, $"{nameof(emptyIntArray)}.xml");
        }
    }
}
