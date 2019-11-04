using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ODEditorDocument {
    public static class DeepCloner {
        public static object DeepClone(object source) {
            object target = null;
            using (MemoryStream stream = new MemoryStream()) {
                // コピー元オブジェクトをシリアライズします。
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, source);
                stream.Position = 0;
                // シリアライズデータをコピー先オブジェクトにデシリアライズします。
                target = formatter.Deserialize(stream);
            }
            return target;
        }

    }
}
