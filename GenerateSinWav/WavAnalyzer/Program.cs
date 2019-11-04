using System;
using System.IO;

namespace WavAnalyzer
{
    /// <summary>
    /// Wavファイルを読み、フーリエ変換を行い、CSVファイルに出力する。
    /// </summary>
    class Program
    {
        private static void _Usage()
        {
            Console.Write("Usage: <wavファイル> <フーリエ級数の個数>\n");
        }

        /// <summary>
        /// WAVファイルをフーリエ変換し、フーリエ級数をCSVファイルとして出力する。
        /// </summary>
        /// <param name="args">
        /// [0] Wavファイル名
        /// [1] フーリエ級数の係数の個数(なんていえばよいのかわからない)
        /// </param>
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                _Usage();
                return;
            }

            var wavFileName = args[0];
            var n = int.Parse(args[1]);

            short[] leftWav;
            short[] rightWav;
            int samplingRate;
            WavFile.Reader.Read(wavFileName, out samplingRate, out leftWav, out rightWav);
#if false
            {
                var wave = WaveData.WaveData.ConvertFromWavData(leftWav);
                var wav = WaveData.WaveData.ConvertToWavData(wave);
                WavFile.Writer.Write(wavFileName + ".debug.wav", samplingRate, wav.Length, wav, null);
            }
#endif

            double[] a;
            double[] b;

            _FourierTransfer(leftWav, n, out a, out b);
#if true
            {
                short[] wav;
                _FourierReverseTransfer(a, b, leftWav.Length, leftWav.Length, out wav);
                WavFile.Writer.Write(wavFileName + ".debug.wav", samplingRate, wav.Length, wav, null);
            }
#endif
            _WriteFtFile(wavFileName + ".left.csv", a, b);

            if (rightWav != null)
            {
                _FourierTransfer(rightWav, n, out a, out b);
                _WriteFtFile(wavFileName + ".right.csv", a, b);
            }
        }

        private static void _FourierReverseTransfer(double[] a, double[] b, int p, int sampleCount, out short[] wav)
        {
            var wave = new double[sampleCount];
            FourierTransfer.FT.ReverseTransfer(a, b, wave);
            wav = WaveData.WaveData.ConvertToWavData(wave);
        }

        /// <summary>
        /// WAVデータをフーリエ変換し、フーリエ級数A、Bを求める。
        /// </summary>
        /// <param name="wav">16bit波形データ</param>
        /// <param name="n">フーリエ級数の要素数</param>
        /// <param name="a">フーリエ級数A</param>
        /// <param name="b">フーリエ級数B</param>
        private static void _FourierTransfer(short[] wav, int n, out double[] a, out double[] b)
        {
            var wave = WaveData.WaveData.ConvertFromWavData(wav);
            a = new double[n];
            b = new double[n];
            FourierTransfer.FT.Transfer(wave, a, b);
        }

        /// <summary>
        /// フーリエ級数をCSVファイルとして出力する。
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <param name="a">フーリエ級数A</param>
        /// <param name="b">フーリエ級数B</param>
        private static void _WriteFtFile(string fileName, double[] a, double[] b)
        {
            var w = new StreamWriter(fileName);
            for (int i = 0; i < a.Length; i++)
                w.Write("{0},{1:f3},{2:f3}\n", i, a[i], b[i]);
            w.Close();
        }

    }
}
