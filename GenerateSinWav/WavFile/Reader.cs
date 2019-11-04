using System;
using System.IO;

namespace WavFile
{
    public class Reader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Wavファイルには不要なデータ項目がいくつかあるが、これらについてはチェックなどせず、単に無視している。
        /// </remarks>
        /// <param name="filePath"></param>
        /// <param name="samplingRate"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static void Read(string filePath, out int samplingRate, out short[] left, out short[] right)
        {
            var wavFile = new BinaryReader(File.OpenRead(filePath));

            _ReadHeader(wavFile, "RIFF");
            wavFile.ReadUInt32(); // ファイルサイズ(正確にはファイル全体のサイズから8を引いたもの)

            _ReadHeader(wavFile, "WAVE");

            _ReadHeader(wavFile, "fmt ");
            wavFile.ReadUInt32(); // fmt チャンクのバイト数 無圧縮 wav は 16
            var wFormatTag = wavFile.ReadUInt16(); // 無圧縮 PCM = 1
            var wChannels = wavFile.ReadUInt16(); // モノラル = 1, ステレオ = 2
            var dwSamplesPerSec = wavFile.ReadUInt32(); // サンプリングレート(Hz)
            wavFile.ReadUInt32(); // 一秒あたりのバイト数(Byte/秒)(何の意味もないデータ項目) 2byte * wChannels * wSamplesPerSec ?
            wavFile.ReadUInt16(); // 1ブロック(サンプル * チャンネル数のことらしい)のバイト数?(モノラル16bitなら2、ステレオ16bitなら4)
            var wBitsPerSamle = wavFile.ReadUInt16(); // 1サンプルのビット数(16ビットならモノラルでもステレオでも16)

            if (wFormatTag != 1)
                throw new Exception("無圧縮PCMデータ以外は対応していません。");
            if (wChannels != 1 && wChannels != 2)
                throw new Exception("3チャンネル以上のデータには対応していません。");
            if (wBitsPerSamle != 16)
                throw new Exception("16ビットデータ以外には対応していません。");

            samplingRate = (int)dwSamplesPerSec;

            _ReadHeader(wavFile, "data");
            var dataChunkSize = wavFile.ReadUInt32();

            uint sampleCount;
            if (wChannels == 1)
            {
                sampleCount = dataChunkSize / 2;
                right = null;
            }
            else
            {
                sampleCount = dataChunkSize / 4;
                right = new short[sampleCount];
            }
            left = new short[sampleCount];

            for (int i = 0; i < sampleCount; i++)
            {
                left[i] = wavFile.ReadInt16();
                if (wChannels == 2)
                    right[i] = wavFile.ReadInt16();
            }

            wavFile.Close();
        }

        private static void _ReadHeader(BinaryReader br, string s)
        {
            var ba = new byte[s.Length];
            br.Read(ba, 0, s.Length);

            var ca = s.ToCharArray();
            for (int i = 0; i < s.Length; i++)
            {
                if (ba[i] != (byte)ca[i])
                    throw new Exception(String.Format("ファイルヘッダーが異常です。expected = {0}, actual = {1}", s, ba.ToString()));
            }
        }
    }
}
