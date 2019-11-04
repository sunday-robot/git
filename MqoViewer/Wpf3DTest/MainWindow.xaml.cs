using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Wpf3DTest
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private Visual3D rootMV;  // 編集対象モデルのルート(原点位置での回転はできるが、平行移動はできない)

        private const double cameraDX = 1;
        private const double cameraDY = 1;
        private const double cameraDZ = 1;
        private Vector3D cameraPosition = new Vector3D(0, 0, 50);

        // ルートモデルの位置と向き
        // Z軸回転はできない。
        private const double rootMVDHead = 15;
        private const double rootMVDPitch = 15;
        private double rootMVHead;  // ルートモデルのY軸回転角度(単位は度、0～360)
        private double rootMVPitch; // ルートモデルのX軸回転角度(単位は度、-90～90)

        public MainWindow()
        {
            InitializeComponent();
            viewPort3D.Children.Clear();
            viewPort3D.Children.Add(_CreateLightVisual3D());
            rootMV = _CreateRootModelVisual3D();
            viewPort3D.Children.Add(rootMV);
            viewPort3D.Camera = _CreateCamera();

            _UpdateRootMVTransform();
            _UpdateCameraTransform();
        }

        #region 照明のVisual3Dを生成する
        /// <summary>
        /// 光源のVisual3Dを生成する。
        /// </summary>
        private static Visual3D _CreateLightVisual3D()
        {
            var mv = new ModelVisual3D();
            mv.Transform = new TranslateTransform3D(12, 12, 12);
            // .Childrenには何も追加しない。(親子関係のある光源などあるのか?)
            mv.Content = _CreatePointLightModel3D();
            return mv;
        }

        /// <summary>
        /// </summary>
        /// <returns>点光源のLight(LightはModel3Dのサブクラス)</returns>
        private static Light _CreatePointLightModel3D()
        {
            var light = new PointLight();
            // .Positionは初期値のまま(光源の位置は、この光源モデルを持つVisual3DのTransformで設定する)
            light.Color = Colors.White;
            light.Range = 150;
            light.ConstantAttenuation = 1.0;
            light.LinearAttenuation = 0;
            light.QuadraticAttenuation = 0;
            return light;
        }
        #endregion 照明のVisual3Dを生成する

        #region 被写体のVisual3Dを生成する

        /// <summary>
        /// ViewPort3D.Children[0].Content
        /// </summary>
        /// <returns></returns>
        private static Visual3D _CreateRootModelVisual3D()
        {
            var mv = new ModelVisual3D(); // Visual3Dが何なのかよくわからない。被写体と照明を含むものだが、Visual3DがViewport3Dに複数含まれるというのが意味不明。
            // .Transformは初期値(何も変換しない単位行列)のまま
            mv.Content = _CreateModel();
            return mv;
        }

        /// <summary>
        /// ViewPort3D.Children[0].Content.Children[0].Children[0] 被写体その1
        /// ViewPort3D.Children[0].Content.Children[0].Children[1] 被写体その2
        /// ViewPort3D.Children[0].Content.Children[0].Children[2] 被写体その3
        /// </summary>
        /// <returns></returns>
        private static Model3D _CreateModel()
        {
            var models = new Model3DGroup();

            var model = new GeometryModel3D();
            model.Geometry = Geometry3DFactory.CreateFlatCube(0, 0, 0, 5);
            model.Material = new DiffuseMaterial(new SolidColorBrush(Colors.Red));
            // .Transformがあるが、設定しない。そもそも存在してはいけないのではないか?
            models.Children.Add(model);

            model = new GeometryModel3D();
            model.Geometry = Geometry3DFactory.CreateFlatCube(5, 0, 0, 2);
            model.Material = new DiffuseMaterial(new SolidColorBrush(Colors.Green));
            // .BackMaterialは面の裏側のMaterial。GeometryModelが閉じた多面体の場合は設定する必要はないはず。
            models.Children.Add(model);

            model = new GeometryModel3D();
            model.Geometry = Geometry3DFactory.CreateFlatCube(-5, 0, 0, 2);
            model.Material = new DiffuseMaterial(new SolidColorBrush(Colors.Blue));
            models.Children.Add(model);

            return models;
        }

        #endregion 被写体のVisual3Dを生成する

        #region カメラを生成する
        private static PerspectiveCamera _CreateCamera()
        {
            var camera = new PerspectiveCamera();
            camera.Position = new Point3D(0, 0, 100);
            camera.LookDirection = new Vector3D(0, 0, -1);
            camera.FieldOfView = 45;
            return camera;
        }
        #endregion カメラを生成する

#if false
        private Matrix3D _GetCameraMatrix3D()
        {
#if false
            // カメラ座標系での世界の中心位置と、同じくカメラ座標系での世界の傾きから、
            // 世界座標系でのカメラの位置及び向きを表すｘｘを返したいだけなのだが、
            // どうにもわかりにくい。MS(特にWPFの連中)はもっと分かりやすくできないのか?
            // →Trnasformというクラスがわかりにくさの原因ではないかと思う。
            var p = new Point3D(worldPosition.X, worldPosition.Y, worldPosition.Z);
            var rh = new Quaternion(0, 1, 0, worldHead);
            rh.Normalize();
            var rp = new Quaternion(1, 0, 0, worldPitch);
            rp.Normalize();

            var m = new Matrix3D(); // 4x4行列
            printMatrix3D(m);
            m.Translate(new Vector3D(p.X, p.Y, p.Z));
            m.Rotate(rh * rp);
            printMatrix3D(m);
            Console.WriteLine("rh = {0}, rp = {1}, rh * rp = {2}", rh, rp, rh * rp);
            printMatrix3D(m);
            return m;
#else
            Matrix3D cameraMatrix3D = rootMatrix3D;
            cameraMatrix3D.Invert();
            return cameraMatrix3D;
#endif
        }
#endif
        private static void _PrintMatrix3D(Matrix3D m)
        {
            Console.WriteLine("({0:f3}, {1:f3}, {2:f3}, {3:f3})", m.M11, m.M12, m.M13, m.M14);
            Console.WriteLine("({0:f3}, {1:f3}, {2:f3}, {3:f3})", m.M21, m.M22, m.M23, m.M24);
            Console.WriteLine("({0:f3}, {1:f3}, {2:f3}, {3:f3})", m.M31, m.M32, m.M33, m.M34);
            Console.WriteLine("({0:f3}, {1:f3}, {2:f3}, {3:f3})", m.OffsetX, m.OffsetY, m.OffsetZ, m.M44);
            Console.WriteLine("|{0:f3}|", m.Determinant);
        }

        #region カメラ平行移動ボタン
        private void _UpdateCameraTransform()
        {
            this.viewPort3D.Camera.Transform = new TranslateTransform3D(cameraPosition);
            Console.WriteLine("camera position = ({0},{1},{2})", cameraPosition.X, cameraPosition.Y, cameraPosition.Z);
        }

        private void MoveUpButton_Click(object sender, RoutedEventArgs e)
        {
            cameraPosition.Y -= cameraDY;
            _UpdateCameraTransform();
        }

        private void MoveDownButton_Click(object sender, RoutedEventArgs e)
        {
            cameraPosition.Y += cameraDY;
            _UpdateCameraTransform();
        }

        private void MoveLeftButton_Click(object sender, RoutedEventArgs e)
        {
            cameraPosition.X += cameraDX;
            _UpdateCameraTransform();
        }

        private void MoveRightButton_Click(object sender, RoutedEventArgs e)
        {
            cameraPosition.X -= cameraDX;
            _UpdateCameraTransform();
        }

        private void MoveForwardButton_Click(object sender, RoutedEventArgs e)
        {
            cameraPosition.Z -= cameraDZ;
            _UpdateCameraTransform();
        }

        private void MoveBackwardButton_Click(object sender, RoutedEventArgs e)
        {
            cameraPosition.Z += cameraDZ;
            _UpdateCameraTransform();
        }

        #endregion カメラ平行移動ボタン

        #region 被写体回転ボタン

        private void _UpdateRootMVTransform()
        {
            rootMV.Transform = _CreateRotationTransform(rootMVHead, rootMVPitch);
            Console.WriteLine("rootModelHead, Pitch = ({0},{1})", rootMVHead, rootMVPitch);
        }

        /// <summary>
        /// ヘッド、ピッチを元に、Transform3Dを生成する。
        /// </summary>
        /// <param name="head">ヘッド(単位は度)</param>
        /// <param name="pitch">ピッチ(単位は度)</param>
        /// <returns>Transform3D</returns>
        private static Transform3D _CreateRotationTransform(double head, double pitch)
        {
            var hq = new Quaternion(new Vector3D(0, 1, 0), head);
            var pq = new Quaternion(new Vector3D(1, 0, 0), pitch);
            var q = pq * hq;
            var qr = new QuaternionRotation3D(q);
            var rt = new RotateTransform3D(qr);
            return rt;
        }

        private void RollUpButton_Click(object sender, RoutedEventArgs e)
        {
            rootMVPitch = Math.Max(rootMVPitch - rootMVDPitch, -90);
            _UpdateRootMVTransform();
        }

        private void RollDownButton_Click(object sender, RoutedEventArgs e)
        {
            rootMVPitch = Math.Min(rootMVPitch + rootMVDPitch, 90);
            _UpdateRootMVTransform();
        }

        private static double _CorrectAngle(double angle, double min)
        {
            var a = Math.Floor((angle - min) / 360);
            var b = angle - a * 360;
            return b;
        }

        private void RollLeftButton_Click(object sender, RoutedEventArgs e)
        {
            rootMVHead = _CorrectAngle(rootMVHead + rootMVDHead, -90);
            _UpdateRootMVTransform();
        }

        private void RollRightButton_Click(object sender, RoutedEventArgs e)
        {
            rootMVHead = _CorrectAngle(rootMVHead - rootMVDHead, -90);
            _UpdateRootMVTransform();
        }
        #endregion
    }
}
