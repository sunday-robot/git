using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

namespace XDocumentTest
{
    static partial class XmlUtil
    {
        public static XElement ConvertToXElement(string name, object o)
        {
            if (isLeafType(o))
                return new XElement(name, o);
            else
            {
                var xe = new XElement(name);
                if (o is Array)
                    foreach (var e in (Array)o)
                        xe.Add(ConvertToXElement("element", e));
                else if (o is IDictionary)
                    foreach (DictionaryEntry e in (IDictionary)o)
                        xe.Add(new XElement("element", new XAttribute("key", e.Key), new XAttribute("value", e.Value)));
                else if (o is IEnumerable)
                    foreach (var e in ((IEnumerable)o))
                        xe.Add(ConvertToXElement("element", e));
                else
                {
                    var properties = o.GetType().GetProperties();
                    foreach (var p in properties)
                    {
                        if (!p.CanRead)
                            continue;
                        if (!p.CanWrite)
                            continue;
                        var v = p.GetValue(o);
                        if (isLeafType(v))
                            xe.Add(new XAttribute(p.Name, v));
                        else
                            xe.Add(ConvertToXElement(p.Name, v));
                    }
                }
                return xe;
            }
        }

        static bool isLeafType(object o)
        {
            return (o is bool)
                || (o is byte)
                || (o is sbyte)
                || (o is ushort)
                || (o is short)
                || (o is uint)
                || (o is int)
                || (o is ulong)
                || (o is long)
                || (o is float)
                || (o is double)
                || (o is char)
                || (o is string)
                || (o is DateTime);
        }
    }
}
