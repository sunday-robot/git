using System;
using System.Collections.Generic;
using System.Drawing;

namespace ColorConverter
{
    class Program {
        public static void ConvertTest(string fileName) {
            var colorTuples = new List<Tuple<Color, Color>>();
            colorTuples.Add(new Tuple<Color,Color>(Color.FromArgb(128, 128, 128), Color.FromArgb(255, 255, 255)));
            Bitmap src = (Bitmap) Image.FromFile(fileName);
            var colorConverter = new MyColorConverter(colorTuples);
            var dest = ImageConverter.Convert(src, colorConverter);
            dest.Save("dest_" + fileName);
        }

        public static void Main(string[] args) {
            ConvertTest("Tulips.jpg");
        }
    }
}
