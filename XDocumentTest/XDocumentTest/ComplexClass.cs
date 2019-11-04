using System.Collections.Generic;

namespace XDocumentTest
{
    public class ComplexClass
    {
        public int A { get; set; }
        public string B { get; set; }
        public List<string> C { get; set; }
        public SimpleClass D { get; set; } = new SimpleClass();
    }
}
