using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XDocumentTest
{
    public static partial class XmlUtil
    {
        public static object CreateFromXmlElement(Type t, XElement xe)
        {
            if (t == typeof(bool))
                return bool.Parse(xe.Value);
            if (t == typeof(byte))
                return byte.Parse(xe.Value);
            if (t == typeof(sbyte))
                return sbyte.Parse(xe.Value);
            if (t == typeof(ushort))
                return ushort.Parse(xe.Value);
            if (t == typeof(short))
                return short.Parse(xe.Value);
            if (t == typeof(uint))
                return uint.Parse(xe.Value);
            if (t == typeof(int))
                return int.Parse(xe.Value);
            if (t == typeof(ulong))
                return ulong.Parse(xe.Value);
            if (t == typeof(long))
                return long.Parse(xe.Value);
            if (t == typeof(float))
                return float.Parse(xe.Value);
            if (t == typeof(double))
                return double.Parse(xe.Value);
            if (t == typeof(string))
                return xe.Value;
            if (t == typeof(DateTime))
                return DateTime.Parse(xe.Value);
            if (t.IsArray)
            {
                var et = t.GetElementType();
                var listType = typeof(List<>).MakeGenericType(et);
                return listType.GetMethod("ToArray").Invoke(createListFromXElement(et, xe.Elements()), null);
            }
            if (t.IsGenericType)
            {
                var gta = t.GenericTypeArguments;
                switch (gta.Length)
                {
                    case 1:
                        // リスト
                        break;
                    case 2:
                        // 連想配列
#if false
                        var keyType = gta[0];
                        var valueType = gta[1];
                        var dictionaryType = typeof(Dictionary).MakeGenericType(gta);
                        var dictionary = Activator.CreateInstance(dictionaryType);
                        var addMethod = dictionaryType.GetMethod("Add");
                        foreach (var xee in xe.Elements())
                        {
                            var key = xee.Attribute("key");
                            var value = xee.Attribute("value");
                            addMethod.Invoke(dictionary, new object[] { CreateFromXmlElement(keyType, key), CreateFromXmlElement(valueType, value) });
                        }
#endif
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            foreach (var i in t.GetInterfaces())
            {
                Console.WriteLine(i);
                //if (i.IsGenericType
                //    && (i.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
                //{
                //    var et = i.GenericTypeArguments[0];
                //    return createListFromXElement(et, xe.Elements());
                //}
            }
            return null;
        }
        static object createListFromXElement(Type elementType, IEnumerable<XElement> xElements)
        {
            var listType = typeof(List<>).MakeGenericType(elementType);
            var list = Activator.CreateInstance(listType);
            var addMethod = listType.GetMethod("Add");
            foreach (var xee in xElements)
                addMethod.Invoke(list, new object[] { CreateFromXmlElement(elementType, xee) });
            return list;
        }
    }
}
