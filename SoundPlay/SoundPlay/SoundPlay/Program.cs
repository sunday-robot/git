using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace SoundPlay
{
    class Program
    {
        static void Main(string[] args)
        {
            var soundPLayer = new SoundPlayer();
            //            soundPLayer.Stream = new InputStream();
            var fis = File.Open("sample.wav", FileMode.Open);
            soundPLayer.Stream = fis;
            soundPLayer.Load();
            soundPLayer.PlaySync();
        }
    }
}
