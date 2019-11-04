using Mq;
using MQData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZakuPipeExp
{
    /// <summary>
    /// メタセコイア用pythonスクリプトZakuPipeの習作
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var doc = MqoLoader.Load(@"..\..\test\test.mqo");
                ZakuPipeExp(doc.MQObjects[1]);
            }
            catch (IOException e)
            {
                Console.Write(e);
                return;
            }
        }

        static void ZakuPipeExp(MQObject pathObject)
        {
            var edgesList = _ExtractRans(_ExtractEdgeFaces(pathObject));
            foreach (var edges in edgesList)
                _CreatePipe(edges);
        }

        private static void _CreatePipe(List<int> edges)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// MQObjectから、辺(2点からなるMQFace)を抽出する。(ただそれだけ。LINQを使うとシンプルに記述できるのだろうか?)
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        static List<MqoFace> _ExtractEdgeFaces(MQObject o)
        {
            var edges = new List<MqoFace>();
            foreach (var face in o.Faces)
                if (face.VertexIndeces.Count == 2)
                    edges.Add(face);
            return edges;
        }

        class Polyline
        {
            List<int> _VertexIndeces = new List<int>();
            public Polyline(int vi0, int vi1)
            {
                _VertexIndeces.Add(vi0);
                _VertexIndeces.Add(vi1);
            }
        }

        /// <summary>
        /// つながった辺(連、ran)を抽出する。
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        private static List<List<int>> _ExtractRans(List<MqoFace> edges)
        {


            var wrongVertexIndces = new HashSet<int>();
            var rans = new List<List<int>>();
            foreach (var edge in edges)
            {
                var v0 = edge.VertexIndeces[0];
                var v1 = edge.VertexIndeces[1];
                foreach (var ran in rans)
                {
                    var idx = ran.IndexOf(v0);
                    if (idx == 0)
                    {
                        ran.Insert(0, v1);
                    }
                    var i1 = ran.IndexOf(edge.VertexIndeces[1]);

                }
            }
            return rans;
        }

        //static List<List<MQPoint>> _ExtractEdgesList(MQObject pathObject)
        //{
        //    var edges = _ExtractEdgeFaces(pathObject);

        //    var hvis = new List<int>();
        //    var tvis = new List<int>();
        //    var hvi = edges[0].VertexIndeces[0];
        //    var tvi = edges[0].VertexIndeces[1];
        //    hvis.Add(hvi);
        //    tvis.Add(tvi);

        //    edges.RemoveAt(0);
        //    while (edges.Count > 0)
        //    {
        //        foreach (var edge in edges)
        //        {
        //            var vi0 = edge.VertexIndeces[0];
        //            var vi1 = edge.VertexIndeces[0];

        //            if (_ConnectEdge(hvis, vi0, vi1)
        //                || _ConnectEdge(hvis, vi1, vi0)
        //                || _ConnectEdge(tvis, vi0, vi1)
        //                || _ConnectEdge(tvis, vi1, vi0))
        //                edges.Remove(edge);
        //        }
        //    }
        //}

        private static void _CreateZakuPipe(List<MQPoint> edges)
        {
            throw new NotImplementedException();
        }


        private static bool _ConnectEdge(List<int> hvis, int vi0, int vi1)
        {
            if (hvis.Last() != vi0)
                return false;
            hvis.Add(vi1);
            return true;
        }
    }
}
