using System.IO;
using System.Windows.Media.Imaging;

namespace WpfPaint
{
    public class PngWriter
    {
        static readonly PngBitmapEncoder pngEncoder = new PngBitmapEncoder();

        public static void Write(BitmapSource bitmapSource, string filePath)
        {
            var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            pngEncoder.Frames.Add(BitmapFrame.Create(bitmapSource));
            pngEncoder.Save(stream);
            pngEncoder.Frames.Clear();
            stream.Close();
        }
    }
}
