using System.IO;
using System.Windows.Media.Imaging;

namespace LiveStitchingTest
{
    public class PngWriter
    {
        public static void Write(BitmapSource bitmapSource, string filePath)
        {
            var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
            encoder.Save(stream);
            encoder.Frames.Clear();
            stream.Close();
        }
    }
}
