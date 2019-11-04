using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace OpenTkTest
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        // 考え方：
        // ワールド座標系において、カメラの位置、向きは固定。
        // モデル座標系を、GUI操作で平行移動、回転させる。

        /// <summary>
        /// 移動ボタン押下の移動量
        /// </summary>
        private const float moveUnit= 1;

        /// <summary>
        /// 回転ボタンの回転量(度)
        /// </summary>
        private const float rollUnit = 15;

        /// <summary>
        /// モデル座標系の位置
        /// </summary>
        private Vector3 modelAxisPosition = new Vector3(0, 0, 50);

        /// <summary>
        /// モデル座標系のY軸回転角度(度、0～360)
        /// </summary>
        private float modelAxisHead;

        /// <summary>
        /// モデル座標系のX軸回転角度(度、-90～90)
        /// </summary>
        private float modelAxisPitch;

        //        private Visual3 rootMV;  // 編集対象モデルのルート(原点位置での回転はできるが、平行移動はできない)


        public MainWindow()
        {
            InitializeComponent();
        }

        //glControlの起動時に実行される。
        private void glControl_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color4.Black);
            GL.Enable(EnableCap.DepthTest);
        }

        //glControlのサイズ変更時に実行される。
        private void glControl_Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, glControl.Size.Width, glControl.Size.Height);
            GL.MatrixMode(MatrixMode.Projection);
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, (float)glControl.Size.Width / (float)glControl.Size.Height, 1.0f, 64.0f);
            GL.LoadMatrix(ref projection);
        }

        //glControlの描画時に実行される。
        private void glControl_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //paintSquare1();
            //paintSquare2();
            paintCube();
        }

        private void paintSquare1()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
            GL.LoadMatrix(ref modelview);

            GL.Begin(BeginMode.Quads);

            GL.Color4(Color4.White);
            GL.Vertex3(-1.0f, 1.0f, 4.0f);
            GL.Color4(Color4.Red);
            GL.Vertex3(-1.0f, -1.0f, 4.0f);
            GL.Color4(Color4.Lime);
            GL.Vertex3(1.0f, -1.0f, 4.0f);
            GL.Color4(Color4.Blue);
            GL.Vertex3(1.0f, 1.0f, 4.0f);

            GL.End();
            glControl.SwapBuffers();
        }

        private void paintSquare2()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            Matrix4 modelview = Matrix4.LookAt(new Vector3(0, 0, -4), Vector3.Zero, Vector3.UnitY);
            GL.LoadMatrix(ref modelview);

            GL.Begin(BeginMode.Quads);

            GL.Color4(Color4.White);
            GL.Vertex3(-1.0f, 1.0f, 0f);
            GL.Color4(Color4.Red);
            GL.Vertex3(-1.0f, -1.0f, 0f);
            GL.Color4(Color4.Lime);
            GL.Vertex3(1.0f, -1.0f, 0f);
            GL.Color4(Color4.Blue);
            GL.Vertex3(1.0f, 1.0f, 0f);

            GL.End();
            glControl.SwapBuffers();
        }

        private void paintCube()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            Matrix4 modelview = Matrix4.LookAt(new Vector3(0, 0, -4), Vector3.Zero, Vector3.UnitY);
            GL.LoadMatrix(ref modelview);

            GL.Begin(BeginMode.Quads);

            GL.Color4(Color4.White);
            GL.Vertex3(-1.0f, 1.0f, 0f);
            GL.Color4(Color4.Red);
            GL.Vertex3(-1.0f, -1.0f, 0f);
            GL.Color4(Color4.Lime);
            GL.Vertex3(1.0f, -1.0f, 0f);
            GL.Color4(Color4.Blue);
            GL.Vertex3(1.0f, 1.0f, 0f);

            GL.End();
            glControl.SwapBuffers();
        }
        #region カメラ平行移動ボタン
        private void _UpdateCameraTransform()
        {
//            this.viewPort3D.Camera.Transform = new TranslateTransform3D(cameraPosition);
//            Console.WriteLine("camera position = ({0},{1},{2})", cameraPosition.X, cameraPosition.Y, cameraPosition.Z);
        }

        private void MoveUpButton_Click(object sender, RoutedEventArgs e)
        {
            modelAxisPosition.Y -= moveUnit;
            _UpdateCameraTransform();
        }

        private void MoveDownButton_Click(object sender, RoutedEventArgs e)
        {
            modelAxisPosition.Y += moveUnit;
            _UpdateCameraTransform();
        }

        private void MoveLeftButton_Click(object sender, RoutedEventArgs e)
        {
            modelAxisPosition.X += moveUnit;
            _UpdateCameraTransform();
        }

        private void MoveRightButton_Click(object sender, RoutedEventArgs e)
        {
            modelAxisPosition.X -= moveUnit;
            _UpdateCameraTransform();
        }

        private void MoveForwardButton_Click(object sender, RoutedEventArgs e)
        {
            modelAxisPosition.Z -= moveUnit;
            _UpdateCameraTransform();
        }

        private void MoveBackwardButton_Click(object sender, RoutedEventArgs e)
        {
            modelAxisPosition.Z += moveUnit;
            _UpdateCameraTransform();
        }

        #endregion カメラ平行移動ボタン
        #region 被写体回転ボタン

        private void _UpdateRootMVTransform()
        {
            rootMV.Transform = _CreateRotationTransform(modelAxisHead, modelAxisPitch);
            Console.WriteLine("rootModelHead, Pitch = ({0},{1})", modelAxisHead, modelAxisPitch);
        }

        /// <summary>
        /// ヘッド、ピッチを元に、Transform3Dを生成する。
        /// </summary>
        /// <param name="head">ヘッド(単位は度)</param>
        /// <param name="pitch">ピッチ(単位は度)</param>
        /// <returns>Transform3D</returns>
        private static Transform3D _CreateRotationTransform(float head, float pitch)
        {
            var hq = new Quaternion(new Vector3(0, 1, 0), head);
            var pq = new Quaternion(new Vector3(1, 0, 0), pitch);
            var q = pq * hq;
            var qr = new QuaternionRotation3D(q);
            var rt = new RotateTransform3D(qr);
            return rt;
        }

        private void RollUpButton_Click(object sender, RoutedEventArgs e)
        {
            modelAxisPitch = Math.Max(modelAxisPitch - rollUnit, -90);
            _UpdateRootMVTransform();
        }

        private void RollDownButton_Click(object sender, RoutedEventArgs e)
        {
            modelAxisPitch = Math.Min(modelAxisPitch + rollUnit, 90);
            _UpdateRootMVTransform();
        }

        private static float _CorrectAngle(double angle, double min)
        {
            var a = Math.Floor((angle - min) / 360);
            var b = angle - a * 360;
            return b;
        }

        private void RollLeftButton_Click(object sender, RoutedEventArgs e)
        {
            modelAxisHead = _CorrectAngle(modelAxisHead + rollUnit, -90);
            _UpdateRootMVTransform();
        }

        private void RollRightButton_Click(object sender, RoutedEventArgs e)
        {
            modelAxisHead = _CorrectAngle(modelAxisHead - rollUnit, -90);
            _UpdateRootMVTransform();
        }
        #endregion
    }
}
