using System;

namespace MultipleSinWave
{
    class Program
    {
        private static void _Usage()
        {
            Console.Write("Usage: <wavファイル> <長さ(秒)> <波形データ>+\n");
            Console.Write("<波形データ> := <波形種類> <周波数(Hz)>\n");
            Console.Write("<波形種類> := s(sin curve)|b(square)\n");
        }

        public static void Main(string[] args)
        {
            if ((args.Length < 4) || (args.Length % 2 != 0))
            {
                _Usage();
                return;
            }

            var wavFileName = args[0];
            var length = Double.Parse(args[1]); // 音の長さ[sec]

            int samplingRate = 48000;   // サンプリングレート[Hz](CDは44100,地デジなどは48000)
            var waveData = new double[(int)(samplingRate * length)];

            for (int i = 2; i < args.Length; i += 2)
            {
                var type = args[i]; // 波形
                var frequency = Double.Parse(args[i + 1]); // 周波数[Hz]
                switch (Char.ToUpper(type[0]))
                {
                    case 'S':
                        WaveData.WaveData.AddSinWave(waveData, samplingRate, frequency, 0, 1);
                        break;
                    case 'B':
                        WaveData.WaveData.AddSquareWave(waveData, samplingRate, frequency, 0, 1);
                        break;
                }
            }

            WaveData.WaveData.NomalizeVolume(waveData);

            var wavData = WaveData.WaveData.ConvertToWavData(waveData);

            WavFile.Writer.Write(wavFileName, samplingRate, wavData.Length, wavData, null);
        }
    }
}
