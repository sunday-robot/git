using System;
using System.IO;

namespace GenerateSinWav
{
    class Program
    {
        public static void Main(string[] args)
        {
            var helz = Double.Parse(args[0]);
            var wavFileName = args[1];
            uint samplingRate = 48000;   // サンプリングレート[Hz](CDは44100,地デジなどは48000)

            _Generate(helz, 5.0, wavFileName, samplingRate);
        }

        private static void _WriteHeader(BinaryWriter bw, string s)
        {
            var ca = s.ToCharArray();
            var ba = new byte[4];
            ba[0] = (byte)ca[0];
            ba[1] = (byte)ca[1];
            ba[2] = (byte)ca[2];
            ba[3] = (byte)ca[3];
            bw.Write(ba, 0, 4);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frequency">音の周波数[Hz]</param>
        /// <param name="length">長さ[s]</param>
        /// <param name="wavFileName">.wavファイルのパス名</param>
        /// <param name="samplingRate">サンプリングレート[Hz(samples/s)]</param>
        private static void _Generate(double frequency, double length, string wavFileName, uint samplingRate)
        {
            // サンプルの個数
            var sampleCount = (uint)(length * samplingRate);

            var wavFile = new BinaryWriter(File.Create(wavFileName));

            _WriteHeader(wavFile, "RIFF");          // RIFF ヘッダ
            wavFile.Write((uint)(2 * sampleCount + 40 - 8));    // ファイルサイズ(ファイル全体のサイズ - 8)

            _WriteHeader(wavFile, "WAVE");          // WAVE ヘッダ

            _WriteHeader(wavFile, "fmt ");          // chunkID (fmt チャンク)
            wavFile.Write((uint)16);                // chunkSize (fmt チャンクのバイト数 無圧縮 wav は 16)
            wavFile.Write((ushort)1);               // wFromatTag (無圧縮 PCM = 1)
            wavFile.Write((ushort)1);               // wChannels (モノラル = 1, ステレオ = 2)
            wavFile.Write((uint)samplingRate);      // dwSamplesPerSec (サンプリングレート(Hz))
            wavFile.Write((uint)(2 * 1 * samplingRate));  // dwAvgBytesPerSec (Byte/秒) 2byte * 1ch * sampling_rate 
            wavFile.Write((ushort)(2 * 1));         // wBlockAlign (Byte/サンプル*チャンネル)
            wavFile.Write((ushort)16);              // wBitsPerSample (bit/サンプル)

            _WriteHeader(wavFile, "data");          // chunkID (data チャンク)
            wavFile.Write((uint)(sampleCount * 2)); // chunkSize (データ長 Byte)
            for (int i = 0; i < sampleCount; i++)
            {
                var r = i * frequency * 2 * Math.PI / samplingRate;
                var v = (short)(Math.Sin(r) * short.MaxValue);
                wavFile.Write(v);
            }

            wavFile.Close();
        }
    }
}
