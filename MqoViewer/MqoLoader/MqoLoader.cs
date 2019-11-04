using MQData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Mq
{
    public static class MqoLoader
    {
        /// <summary>
        /// .mqoファイルをロードし、MqoDataを返す。
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>MqoData</returns>
        public static MQDocument Load(string filePath)
        {
            var sr = new StreamReader(filePath);
            string s;

            // 1行目(mqoファイルのシグニチャ)
            s = sr.ReadLine();
            if (s != "Metasequoia Document")
                throw new Exception("This is not mqo file.");

            // 2行目(バージョン)
            s = sr.ReadLine();
            switch (s)
            {
                case "Format Text Ver 1.0":
                    break;
                case "Format Text Ver 1.1":
                    break;
                default:
                    throw new Exception("Version check error.");

            }

            var scanner = new Scanner(sr);
            scanner.SetLineNumber(2);

            try
            {
                var mqoData = _GetMqoData(scanner);
                return mqoData;
            }
            catch (Exception e)
            {
                throw new MqoLoaderException(e, scanner.GetLineNumber());
            }
        }

        private static MQData.MQDocument _GetMqoData(Scanner scanner)
        {
            var mqoData = new MQData.MQDocument();

            while (true)
            {
                if (!scanner.FetchLine())
                    throw new Exception("Unexpected EOF");
                var token = scanner.Get();
                if (token.Equals(_ThumbnailSymbol))
                    _SkipMqoThumbnail(scanner);             // Thumbnailチャンク(たぶんサムネイル画像データ)
                else if (token.Equals(_SceneSymbol))
                    mqoData.Scene = _GetMqoScene(scanner);             // Sceneチャンク(視点情報など)
                else if (token.Equals(_BackImageSymbol))
                    mqoData.BackImage = _GetMqoBackImage(scanner);             // BackImageチャンク
                else if (token.Equals(_MaterialSymbol))
                    mqoData.Materials = _GetMqoMaterials(scanner);             // Materialチャンク
                else if (token.Equals(_ObjectSymbol))
                    mqoData.MQObjects.Add(_GetMqoObject(scanner, mqoData.Materials));             // Objectチャンク
                else if (token.Equals(_EofSymbol))
                {
                    // "Eof"の後に何もデータがないことを確認する
                    if (scanner.Get() != null || scanner.FetchLine())
                        throw new Exception("this Mqo file has some data after Eof symbol.");
                    break;
                }
                else
                    throw new Exception("Unknown chunk name : " + token);
            }
            return mqoData;
        }

        #region MqoThumbnail
        private static void _SkipMqoThumbnail(Scanner scanner)
        {
            Object token;

            int width = _GetInteger(scanner);
            int height = _GetInteger(scanner);
            int bitCount = _GetInteger(scanner);
            object pixelType = scanner.Get();
            object dataFormatType = scanner.Get();
            token = scanner.Get();
            if (!token.Equals(_LeftBraceSymbol))
                throw new Exception("LoadScene() failed.");

            while (true)
            {
                scanner.FetchLine();
                token = scanner.Get();
                if (token.Equals(_RightBraceSymbol))
                    return;
            }
        }
        #endregion MqoThumbnail

        #region MqoScene
        static MqoScene _GetMqoScene(Scanner scanner)
        {
            Object token;

            // "Scene"チャンクヘッダーの残りが"{"だけであることを確認する。
            if (!scanner.Get().Equals(_LeftBraceSymbol)
                || scanner.Get() != null)
                throw new Exception("LoadScene() failed.");

            var scene = new MqoScene();

            while (true)
            {
                scanner.FetchLine();
                token = scanner.Get();

                if (token.Equals(_PosSymbol))
                    scene.Pos = _GetMqoPoint3D(scanner);
                else if (token.Equals(_LookAtSymbol))
                    scene.LookAt = _GetMqoPoint3D(scanner);
                else if (token.Equals(_HeadSymbol))
                    scene.Head = _GetDouble(scanner);
                else if (token.Equals(_PichSymbol))
                    scene.Pich = _GetDouble(scanner);
                else if (token.Equals(_BankSymbol))
                    scene.Bank = _GetDouble(scanner);
                else if (token.Equals(_OrthoSymbol))
                    scene.Ortho = _GetBool(scanner);
                else if (token.Equals(_Zoom2Symbol))
                    scene.Zoom2 = _GetDouble(scanner);
                else if (token.Equals(_AmbSymbol))
                    scene.Amb = _GetMqoColor(scanner);
                else if (token.Equals(_FrontClipSymbol))
                    scene.FrontClip = _GetDouble(scanner);
                else if (token.Equals(_BackClipSymbol))
                    scene.BackClip = _GetDouble(scanner);
                else if (token.Equals(_DirLightsSymbol))
                    scene.Dirlights = _GetMqoDirLights(scanner);
                else if (token.Equals(_RightBraceSymbol))
                    break;
                else if (token.Equals(_ZoomPersSymbol))
                    scene.ZoomPers = _GetDouble(scanner);
                else
                    throw new Exception("LoadScene() failed.");
            }

            return scene;
        }

        private static System.Collections.Generic.List<MqoLight> _GetMqoDirLights(Scanner scanner)
        {
            Object token;

            // dirlightの後の数値(光源の数らしいが必要ないので型のチェックを行うのみ)
            token = scanner.Get();
            if (!(token is double))
                throw new Exception("_LoadMqoDirLights() failed.");

            token = scanner.Get();
            if (!token.Equals(_LeftBraceSymbol))
                throw new Exception("_LoadMqoDirLights() failed.");

            var dirLights = new List<MqoLight>();
            while (true)
            {
                scanner.FetchLine();
                token = scanner.Get();
                if (token.Equals(_LightSymbol))
                    dirLights.Add(_GetMqoLight(scanner));
                else if (token.Equals(_RightBraceSymbol))
                    break;
                else
                    throw new Exception("_LoadMqoDirLights() failed.");
            }
            return dirLights;
        }

        private static MqoLight _GetMqoLight(Scanner scanner)
        {
            Object token;
            var light = new MqoLight();

            token = scanner.Get();
            if (!token.Equals(_LeftBraceSymbol))
                throw new Exception("_LoadMqoLight() failed.");

            while (true)
            {
                scanner.FetchLine();
                token = scanner.Get();
                if (token.Equals(_DirSymbol))
                    light.Dir = _GetMqoPoint3D(scanner);
                else if (token.Equals(_ColorSymbol))
                    light.Color = _GetMqoColor(scanner);
                else if (token.Equals(_RightBraceSymbol))
                    break;
                else
                    throw new Exception("_LoadMqoLight() failed.");
            }
            return light;
        }

        #endregion MqoScene

        #region MqoBackImage
        private static MqoBackImage _GetMqoBackImage(Scanner scanner)
        {
            Object token;

            var backImage = new MqoBackImage();

            token = scanner.Get();
            if (!token.Equals(_LeftBraceSymbol))
                throw new Exception("LoadScene() failed.");

            while (true)
            {
                scanner.FetchLine();
                token = scanner.Get();
                if (token.Equals(_RightBraceSymbol))
                    break;
                if (token.Equals(_PersSymbol))
                    backImage.Pers = _GetMqoBackImageElement(scanner);
                else if (token.Equals(_TopSymbol))
                    backImage.Top = _GetMqoBackImageElement(scanner);
                else if (token.Equals(_FrontSymbol))
                    backImage.Front = _GetMqoBackImageElement(scanner);
                else if (token.Equals(_LeftSymbol))
                    backImage.Left = _GetMqoBackImageElement(scanner);
                else
                    throw new Exception("_GetMqoBackImage() failed.");
            }

            return backImage;
        }

        private static MqoBackImageElement _GetMqoBackImageElement(Scanner scanner)
        {
            var bie = new MqoBackImageElement();

            bie.FilePath = (string)scanner.Get();
            bie.Left = (double)scanner.Get();
            bie.Top = (double)scanner.Get();
            bie.Right = (double)scanner.Get();
            bie.Bottom = (double)scanner.Get();

            return bie;
        }

        #endregion MqoBackImage

        #region MqoMaterials
        private static List<MqoMaterial> _GetMqoMaterials(Scanner scanner)
        {
            Object token;

            // マテリアルの数(チェックのみで使用しない)
            token = scanner.Get();
            if (!(token is double))
                throw new Exception("_GetMqoMaterials() failed.");

            token = scanner.Get();
            if (!token.Equals(_LeftBraceSymbol))
                throw new Exception("_GetMqoMaterials() failed.");

            var materials = new List<MqoMaterial>();

            while (true)
            {
                scanner.FetchLine();
                token = scanner.Get();
                if (token.Equals(_RightBraceSymbol))
                    break;
                var material = new MqoMaterial();
                material.Name = (string)token;

                for (token = scanner.Get(); token != null; token = scanner.Get())
                {
                    if (token.Equals(_ShaderSymbol))
                    {
                        material.ShaderNo = _ObjectToInteger(_GetAttributeParameters(scanner)[0]);
                    }
                    else if (token.Equals(_ColSymbol))
                    {
                        material.Col = _ObjectToMqoColor(_GetAttributeParameters(scanner));
                    }
                    else if (token.Equals(_DifSymbol))
                    {
                        material.Diff = (Double)_GetAttributeParameters(scanner)[0];
                    }
                    else if (token.Equals(_AmbSymbol))
                    {
                        material.Amb = (Double)_GetAttributeParameters(scanner)[0];
                    }
                    else if (token.Equals(_EmiSymbol))
                    {
                        material.Emi = (Double)_GetAttributeParameters(scanner)[0];
                    }
                    else if (token.Equals(_SpcSymbol))
                    {
                        material.Spc = (Double)_GetAttributeParameters(scanner)[0];
                    }
                    else if (token.Equals(_PowerSymbol))
                    {
                        material.Power = (Double)_GetAttributeParameters(scanner)[0];
                    }
                    else if (token.Equals(_TexSymbol))
                    {
                        material.Tex = (string)_GetAttributeParameters(scanner)[0];
                    }
                    else if (token.Equals(_BumpSymbol))
                    {
                        material.Bump = (string)_GetAttributeParameters(scanner)[0];
                    }
                    else if (token.Equals(_ProjTypeSymbol))
                    {
                        material.ProjType = _ObjectToInteger(_GetAttributeParameters(scanner)[0]);
                    }
                    else if (token.Equals(_ProjPosSymbol))
                    {
                        material.ProjPos = _ObjectListToMqoPoint3D(_GetAttributeParameters(scanner));
                    }
                    else if (token.Equals(_ProjScaleSymbol))
                    {
                        material.ProjScale = _ObjectListToMqoPoint3D(_GetAttributeParameters(scanner));
                    }
                    else if (token.Equals(_ProjAngleSymbol))
                    {
                        material.ProjAngle = _ObjectListToMqoPoint3D(_GetAttributeParameters(scanner));
                    }
                    else if (token.Equals(_ReflectSymbol))
                    {
                        material.Reflect = (Double)_GetAttributeParameters(scanner)[0];
                    }
                    else
                    {
                        throw new Exception("unknown Material parameter [" + token + "]");
                    }
                }

                materials.Add(material);
            }

            return materials;
        }

        private static MQPoint _ObjectListToMqoPoint3D(List<object> list)
        {
            return new MQPoint((double)list[0], (double)list[1], (double)list[2]);
        }

        private static MqoColor _ObjectToMqoColor(List<object> list)
        {
            return new MqoColor((Double)list[0], (Double)list[1], (Double)list[2], (Double)list[3]);
        }

        private static int _ObjectToInteger(object o)
        {
            return (int)((Double)o);
        }

        #endregion MqoMaterials

        #region MqoObject
        private static MQObject _GetMqoObject(Scanner scanner, List<MqoMaterial> materials)
        {
            var mqoObject = new MQObject();

            mqoObject.Name = (string)scanner.Get();

            if (!scanner.Get().Equals(_LeftBraceSymbol)
                || scanner.Get() != null)
                throw new Exception("_GetMqoObject()");

            while (true)
            {
                scanner.FetchLine();
                var token = scanner.Get();
                if (token.Equals(_DepthSymbol))
                    mqoObject.Depth = scanner.GetInteger();
                else if (token.Equals(_FoldingSymbol))
                    mqoObject.Folding = scanner.GetInteger();
                else if (token.Equals(_ScaleSymbol))
                    mqoObject.Scale = _GetMqoPoint3D(scanner);
                else if (token.Equals(_RotationSymbol))
                    mqoObject.Rotation = _GetMqoPoint3D(scanner);
                else if (token.Equals(_TranslationSymbol))
                    mqoObject.Translation = _GetMqoPoint3D(scanner);
                else if (token.Equals(_PatchSymbol))
                    mqoObject.Patch = scanner.GetInteger();
                else if (token.Equals(_PatchTriSymbol))
                    mqoObject.PatchTri = scanner.GetInteger();
                else if (token.Equals(_SegmentSymbol))
                    mqoObject.Segment = scanner.GetInteger();
                else if (token.Equals(_VisibleSymbol))
                    mqoObject.Visible = scanner.GetInteger();
                else if (token.Equals(_LockingSymbol))
                    mqoObject.Locking = scanner.GetInteger();
                else if (token.Equals(_ShadingSymbol))
                    mqoObject.Shading = scanner.GetInteger();
                else if (token.Equals(_FacetSymbol))
                    mqoObject.Facet = scanner.GetInteger();
                else if (token.Equals(_ColorSymbol))
                    mqoObject.Color = _GetMqoColor(scanner);
                else if (token.Equals(_ColorTypeSymbol))
                    mqoObject.ColorType = scanner.GetInteger();
                else if (token.Equals(_MirrorSymbol))
                    mqoObject.Mirror = scanner.GetInteger();
                else if (token.Equals(_MirrorAxisSymbol))
                    mqoObject.MirrorAxis = scanner.GetInteger();
                else if (token.Equals(_MirrorDisSymbol))
                    mqoObject.MirrorDis = (double)scanner.Get();
                else if (token.Equals(_LatheSymbol))
                    mqoObject.Lathe = scanner.GetInteger();
                else if (token.Equals(_LatheAxisSymbol))
                    mqoObject.LatheAxis = scanner.GetInteger();
                else if (token.Equals(_LatheSegSymbol))
                    mqoObject.LatheSeg = scanner.GetInteger();
                else if (token.Equals(_VertexSymbol))
                    _GetMqoVertexes(scanner, mqoObject.Vertexes);
                else if (token.Equals(_BVertexSymbol))
                {
                    // mqoObject.Vertexes = _GetMqoBVerteexes(scanner);
                    throw new Exception("_GetMqoObject() : bvertex is not supported.");
                }
                else if (token.Equals(_FaceSymbol))
                    _GetMqoFaces(scanner, materials, mqoObject.Vertexes, mqoObject.Faces);
                else if (token.Equals(_RightBraceSymbol))
                    break;
                else
                    throw new Exception("_GetMqoObject()");
            }

            return mqoObject;
        }

        private static void _GetMqoVertexes(Scanner scanner, List<MQPoint> vertexes)
        {
            // 頂点の数を取得
            var vertexCount = scanner.GetInteger();

            // "{"と改行の確認
            if (!scanner.Get().Equals(_LeftBraceSymbol)
                || scanner.Get() != null)
                throw new Exception("_GetMqoVertexes() failed.");

            for (int i = 0; i < vertexCount; i++)
            {
                scanner.FetchLine();
                var vertex = _GetMqoPoint3D(scanner);
                vertexes.Add(vertex);
            }

            scanner.FetchLine();

            // "{" と改行の確認
            if (!scanner.Get().Equals(_RightBraceSymbol)
                || scanner.Get() != null)
                throw new Exception("_GetMqoVertexes() failed.");
        }

        private static List<MqoFace> _GetMqoFaces(Scanner scanner, List<MqoMaterial> materials, List<MQPoint> vertexes, List<MqoFace> faces)
        {

            // 面の数
            var faceCount = scanner.GetInteger();

            // "{"の確認
            if (!scanner.Get().Equals(_LeftBraceSymbol)
                || scanner.Get() != null)
                throw new Exception("_GetMqoFaces() failed.");

            for (int i = 0; i < faceCount; i++)
            {
                scanner.FetchLine();
                var face = _GetMqoFace(scanner, materials, vertexes);
                faces.Add(face);
            }

            scanner.FetchLine();

            // "{" と改行の確認
            if (!scanner.Get().Equals(_RightBraceSymbol)
                || scanner.Get() != null)
                throw new Exception("_GetMqoFaces() failed.");

            return faces;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scanner"></param>
        /// <param name="materials"></param>
        /// <param name="vertexes"></param>
        /// <returns></returns>
        private static MqoFace _GetMqoFace(Scanner scanner, List<MqoMaterial> materials, List<MQPoint> allVertexes)
        {
            // 頂点の数
            var vertexCount = scanner.GetInteger();

            var face = new MqoFace();

            for (var token = scanner.Get(); token != null; token = scanner.Get())
            {
                var values = _GetAttributeParameters(scanner);

                if (token.Equals(_VSymbol))                    // 頂点インデックス
                    face.VertexIndeces = _ObjectListToIntgerList(values);
                else if (token.Equals(_MSymbol))// 材質インデックス(-1(材質設定なし)、0～材質数-1)
                    face.MaterialIndex = _ObjectToInteger(values[0]);
                else if (token.Equals(_UVSymbol)) // UV座標(頂点数 * 2個のdouble)
                    face.UVs = _DoubleValuesToUVs(values);
                else if (token.Equals(_COLSymbol))    // 頂点カラー
                    face.Col = 0;   // 頂点カラーは廃止らしいので無視。
                else if (token.Equals(_CRSSymbol))    // Catmull-Clark曲面用のエッジの折れ目(頂点数分の数が存在)
                    face.Crs = 0;   // boolean が頂点数分とのことだがよくわからないので無視。
                else
                    throw new Exception("未知のfaceアトリビュートです。" + values);
            }

            return face;
        }

        private static List<int> _ObjectListToIntgerList(List<object> list)
        {
            var l = new List<int>();
            foreach (var o in list)
            {
                l.Add(_ObjectToInteger(o));
            }
            return l;
        }

        private static List<MqoUV> _DoubleValuesToUVs(List<object> list)
        {
            var uvs = new List<MqoUV>();
            for (int i = 0; i < list.Count; i += 2)
            {
                uvs.Add(new MqoUV((double)list[i], (double)list[i + 1]));
            }
            return uvs;
        }

        private static MqoColor _GetMqoColor(Scanner scanner)
        {
            var r = (double)scanner.Get();
            var g = (double)scanner.Get();
            var b = (double)scanner.Get();
            return new MqoColor(r, g, b);
        }

        #endregion MqoObject

        #region MqoSymbols

        private static Regex _AlphabetSymbol = new Regex(@"[_A-Za-z][_0-9A-Za-z]*");
        private static Symbol _LeftParenSymbol = new Symbol("(");
        private static Symbol _RightParenSymbol = new Symbol(")");
        private static Symbol _LeftBraceSymbol = new Symbol("{");
        private static Symbol _RightBraceSymbol = new Symbol("}");
        private static Symbol _ThumbnailSymbol = new Symbol("Thumbnail");
        private static Symbol _SceneSymbol = new Symbol("Scene");
        private static Symbol _PosSymbol = new Symbol("pos");
        private static Symbol _LookAtSymbol = new Symbol("lookat");
        private static Symbol _HeadSymbol = new Symbol("head");
        private static Symbol _PichSymbol = new Symbol("pich");
        private static Symbol _BankSymbol = new Symbol("bank");
        private static Symbol _OrthoSymbol = new Symbol("ortho");
        private static Symbol _Zoom2Symbol = new Symbol("zoom2");
        private static Symbol _AmbSymbol = new Symbol("amb");
        private static Symbol _FrontClipSymbol = new Symbol("frontclip");
        private static Symbol _BackClipSymbol = new Symbol("backclip");
        private static Symbol _DirLightsSymbol = new Symbol("dirlights");
        private static Symbol _LightSymbol = new Symbol("light");
        private static Symbol _DirSymbol = new Symbol("dir");
        private static Symbol _ColorSymbol = new Symbol("color");
        private static Symbol _BackImageSymbol = new Symbol("BackImage");
        private static Symbol _MaterialSymbol = new Symbol("Material");
        private static Symbol _ObjectSymbol = new Symbol("Object");
        private static Symbol _EofSymbol = new Symbol("Eof");
        private static Symbol _PersSymbol = new Symbol("pers");
        private static Symbol _TopSymbol = new Symbol("top");
        private static Symbol _FrontSymbol = new Symbol("front");
        private static Symbol _LeftSymbol = new Symbol("left");
        private static Symbol _DepthSymbol = new Symbol("depth");
        private static Symbol _FoldingSymbol = new Symbol("folding");
        private static Symbol _ScaleSymbol = new Symbol("scale");
        private static Symbol _RotationSymbol = new Symbol("rotation");
        private static Symbol _TranslationSymbol = new Symbol("translation");
        private static Symbol _PatchSymbol = new Symbol("patch");
        private static Symbol _PatchTriSymbol = new Symbol("patchtri");
        private static Symbol _SegmentSymbol = new Symbol("segment");
        private static Symbol _VisibleSymbol = new Symbol("visible");
        private static Symbol _LockingSymbol = new Symbol("locking");
        private static Symbol _ShadingSymbol = new Symbol("shading");
        private static Symbol _FacetSymbol = new Symbol("facet");
        private static Symbol _ColorTypeSymbol = new Symbol("color_type");
        private static Symbol _MirrorSymbol = new Symbol("mirror");
        private static Symbol _MirrorAxisSymbol = new Symbol("mirror_axis");
        private static Symbol _MirrorDisSymbol = new Symbol("mirror_dis");
        private static Symbol _LatheSymbol = new Symbol("lathe");
        private static Symbol _LatheAxisSymbol = new Symbol("lathe_axis");
        private static Symbol _LatheSegSymbol = new Symbol("lathe_seg");
        private static Symbol _VertexSymbol = new Symbol("vertex");
        private static Symbol _BVertexSymbol = new Symbol("bvertex");
        private static Symbol _FaceSymbol = new Symbol("face");
        private static Symbol _ShaderSymbol = new Symbol("shader");
        private static Symbol _ColSymbol = new Symbol("col");
        private static Symbol _DifSymbol = new Symbol("dif");
        private static Symbol _EmiSymbol = new Symbol("emi");
        private static Symbol _SpcSymbol = new Symbol("spc");
        private static Symbol _PowerSymbol = new Symbol("power");
        private static Symbol _TexSymbol = new Symbol("tex");
        private static Symbol _VSymbol = new Symbol("V");
        private static Symbol _UVSymbol = new Symbol("UV");
        private static Symbol _MSymbol = new Symbol("M");
        private static Symbol _CRSSymbol = new Symbol("CRS");
        private static Symbol _COLSymbol = new Symbol("COL");
        private static Symbol _BumpSymbol = new Symbol("bump");
        private static Symbol _ProjTypeSymbol = new Symbol("proj_type");
        private static Symbol _ProjPosSymbol = new Symbol("proj_pos");
        private static Symbol _ProjScaleSymbol = new Symbol("proj_scale");
        private static Symbol _ProjAngleSymbol = new Symbol("proj_angle");
        private static Symbol _ZoomPersSymbol = new Symbol("zoom_pers");
        private static Symbol _ReflectSymbol = new Symbol("reflect");

        private static Symbol _Symbol = new Symbol("");

        #endregion MqoSymbols

        #region MqoCommon

        /// <summary>
        /// 以下の様な形式の属性のパラメーターのリストを取得する。
        /// 属性名 + "(" + パラメーター(空白で区切り複数羅列されうる) + ")"
        /// </summary>
        /// <param name="scanner"></param>
        /// <returns></returns>
        private static List<Object> _GetAttributeParameters(Scanner scanner)
        {
            if (!scanner.Get().Equals(_LeftParenSymbol))
                throw new Exception("_GetAttribute()");

            var parameters = new List<Object>();
            for (var token = scanner.Get(); !token.Equals(_RightParenSymbol); token = scanner.Get())
            {
                parameters.Add(token);
            }

            return parameters;
        }

        private static int _GetInteger(Scanner scanner)
        {
            return (int)_GetDouble(scanner);
        }

        private static double _GetDouble(Scanner scanner)
        {
            return (double)scanner.Get();
        }

        private static bool _GetBool(Scanner scanner)
        {
            return _GetDouble(scanner) != 0;
        }

        private static MQPoint _GetMqoPoint3D(Scanner scanner)
        {
            var x = (double)scanner.Get();
            var y = (double)scanner.Get();
            var z = (double)scanner.Get();
            return new MQPoint(x, y, z);
        }

        #endregion MqoCommon

    }
}
