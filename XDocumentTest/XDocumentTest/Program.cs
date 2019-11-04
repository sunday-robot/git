using System;
using System.Xml.Linq;

namespace XDocumentTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestBasicType.Test();
            //TestEmptyArray.Test();
            //TestArray.Test();
            //TestSimpleList.Test();
            //TestSimpleClass.Test();
            //TestComplexClass.Test();
            TestDictionary.Test();

            //test1();
        }

        static void test1()
        {
            var re = new XElement("root");
            re.Add(new XAttribute("createdBy", "秋山"));
            re.Add(new XAttribute("createdAt", DateTime.Now));
            re.Add(new XElement("stroke"));
            re.Add(new XElement("stroke"));

            var xd = new XDocument();
            xd.Add(re);
            xd.Save("test.xml");
        }
    }
}
