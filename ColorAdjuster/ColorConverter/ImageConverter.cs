using System.Drawing;

namespace ColorConverter
{
    public static class ImageConverter {
        /// <summary>
        /// ColorConverterを使用して各画素値を変換した画像を生成し、返す。
        /// </summary>
        /// <param name="image"></param>
        /// <param name="colorConverter"></param>
        /// <returns></returns>
        public static Image Convert(Bitmap image, IColorConverter colorConverter) {
            var newImage = new Bitmap(image.Width, image.Height, image.PixelFormat);
            for (int y = 0; y < image.Height; y++) {
                for (int x = 0; x < image.Width; x++) {
                    var c = image.GetPixel(x, y);
                    var d = colorConverter.Convert(c);
                    newImage.SetPixel(x, y, d);
                }
            }
            return newImage;
        }

    }
}
