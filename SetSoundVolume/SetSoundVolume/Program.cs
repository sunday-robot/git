using System;
using System.Windows.Controls;

namespace SetSoundVolume {
    class Program {
        [STAThread]
        static void Main(string[] args) {
            var me = new MediaElement();
            double volume = me.Volume;
            Console.WriteLine("current volume = %f\n", volume);
        }
    }
}
