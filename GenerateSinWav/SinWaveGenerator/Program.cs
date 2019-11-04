using System;
using WavFile;

namespace GenerateSinWav
{
    class Program
    {
        public static void Main(string[] args)
        {
            var helz = Double.Parse(args[0]);
            var wavFileName = args[1];
            var samplingRate = 48000;   // サンプリングレート[Hz](CDは44100,地デジなどは48000)

            _Generate(helz, 5.0, wavFileName, samplingRate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frequency">音の周波数[Hz]</param>
        /// <param name="length">長さ[s]</param>
        /// <param name="wavFileName">.wavファイルのパス名</param>
        /// <param name="samplingRate">サンプリングレート[Hz(samples/s)]</param>
        private static void _Generate(double frequency, double length, string wavFileName, int samplingRate)
        {
            // サンプルの個数
            var sampleCount = (int)(length * samplingRate);
            var left = new short[sampleCount];
            var right = new short[sampleCount];

            for (int i = 0; i < sampleCount; i++)
            {
                var r = i * frequency * 2 * Math.PI / samplingRate;
                var v = (short)(Math.Sin(r) * short.MaxValue);
                left[i] = (short)(v);
                left[i] = (short)0;
                right[i] = (short)((double)v * i / sampleCount);
            }

            Writer.Write(wavFileName, samplingRate, sampleCount, left, right);
        }
    }
}
