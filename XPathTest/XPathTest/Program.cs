using System;
using System.Xml;

namespace XPathTest {
    class Program {
        static void Main(string[] args) {
            try {
                var doc = new XmlDocument();
                doc.Load(args[0]);
                var nodes = doc.SelectNodes(args[1]);
                foreach (var node in nodes) {
                    _Pp(node, 0);
                }
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        private static void _Pp(Object node, int depth) {
            if (node is XmlAttribute) {
                _PpAttribute((XmlAttribute)node, depth);
            } else if (node is XmlElement) {
                _PpElement((XmlElement)node, depth);
            } else if (node is XmlDocument) {
                _PpDocument((XmlDocument)node);
            } else if (node is XmlText) {
                _PpText((XmlText)node, depth);
            } else {
                Console.Write(node.ToString());
            }
        }

        private static void _PpAttribute(XmlAttribute attribute, int depth) {
            var spaces = new String(' ', depth);
            Console.WriteLine("{0}@{1} = \"{2}\"", spaces, attribute.Name, attribute.Value);
        }

        private static void _PpElement(XmlElement element, int depth) {
            var spaces = new String(' ', depth);
            Console.WriteLine("{0}<{1}>", spaces, element.Name);
            foreach (var attr in element.Attributes) {
                _PpAttribute((XmlAttribute)attr, depth + 1);
            }
            foreach (var child in element.ChildNodes) {
                _Pp(child, depth + 1);
            }
        }

        private static void _PpDocument(XmlDocument document) {
            var decl = (XmlDeclaration)document.FirstChild;
            Console.WriteLine("xml version = {0}, encodiong = {1}", decl.Version, decl.Encoding);
            _PpElement(document.DocumentElement, 0);
        }

        private static void _PpText(XmlText text, int depth) {
            var spaces = new String(' ', depth);
            Console.WriteLine("{0}\"{1}\"", spaces, text.Value);
        }
    }
}
