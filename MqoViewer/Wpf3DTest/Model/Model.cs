using System.Windows.Media.Media3D;

namespace Wpf3DTest.Model
{
    public sealed class Model
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

    }
}
