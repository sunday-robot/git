using System.IO;

namespace WavFile
{
    public class Writer
    {
        public static void Write(string filePath, int samplingRate, int sampleCount, short[] left, short[] right)
        {
            var channelCount = (right == null) ? 1 : 2;

            var wavFile = new BinaryWriter(File.Create(filePath));

            _WriteHeader(wavFile, "RIFF");          // RIFF ヘッダ
            wavFile.Write((uint)(2 * sampleCount + 40 - 8));    // ファイルサイズ(ファイル全体のサイズ - 8)

            _WriteHeader(wavFile, "WAVE");          // WAVE ヘッダ

            _WriteHeader(wavFile, "fmt ");          // chunkID (fmt チャンク)
            wavFile.Write((uint)16);                // chunkSize (fmt チャンクのバイト数 無圧縮 wav は 16)
            wavFile.Write((ushort)1);               // wFromatTag (無圧縮 PCM = 1)
            wavFile.Write((ushort)channelCount); // wChannels (モノラル = 1, ステレオ = 2)
            wavFile.Write((uint)samplingRate);      // dwSamplesPerSec (サンプリングレート(Hz))
            wavFile.Write((uint)(2 * channelCount * samplingRate));  // dwAvgBytesPerSec (Byte/秒) 2byte * ch * sampling_rate 
            wavFile.Write((ushort)(2 * channelCount)); // wBlockAlign (Byte/サンプル*チャンネル)
            wavFile.Write((ushort)16);              // wBitsPerSample (bit/サンプル)

            _WriteHeader(wavFile, "data");          // chunkID (data チャンク)
            wavFile.Write((uint)(sampleCount * 2)); // chunkSize (データ長 Byte)
            for (int i = 0; i < sampleCount; i++)
            {
                wavFile.Write(left[i]);
                if (right != null)
                    wavFile.Write(right[i]);
            }

            wavFile.Close();
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
    }
}
