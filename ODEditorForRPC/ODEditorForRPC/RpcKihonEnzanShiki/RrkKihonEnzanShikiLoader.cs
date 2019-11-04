using System.Xml;

namespace RpcKihonEnzanShiki {
    public static class RpcKihonEnzanShikiLoader {
        public static RpcKihonEnzanShikiList Load(string fileName) {
            var list = new RpcKihonEnzanShikiList();
            var xml = new XmlDocument();
            xml.Load(fileName);
            var nodes = xml.SelectNodes("/ReactionProfileCheckFormula/FormulaType/FormulaTypeInfo");
            foreach (XmlElement e in nodes) {
                var fs = e.SelectSingleNode("FormulaString");
                if ((fs == null) || (fs.InnerText == ""))
                    continue;
                var no = int.Parse(e.GetAttribute("No"));
                list.Add(new RpcKihonEnzanShiki(no, fs.InnerText));
            }
            return list;
        }
    }
}
