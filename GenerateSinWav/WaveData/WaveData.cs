using System;

namespace WaveData
{
    public class WaveData
    {
        /// <summary>
        /// 矩形波を加算する
        /// </summary>
        /// <param name="waveData">加算対象の波形データ</param>
        /// <param name="samplingRate">サンプリングレート[Hz]</param>
        /// <param name="frequency">周波数[Hz]</param>
        /// <param name="zure">位相のずれ(0.0～1.0)(0.0～2 * PIとしたほうがわかりやすい?)</param>
        /// <param name="volume">ボリューム(振幅)</param>
        public static void AddSquareWave(double[] waveData, int samplingRate, double frequency, double zure, double volume)
        {
            double k1 = frequency / samplingRate;
            for (int i = 0; i < waveData.Length; i++)
            {
                double a = i * k1 + zure;
                double rem = Math.IEEERemainder(a, 1);
                if (rem < 0.5)
                    waveData[i] = volume;
                else
                    waveData[i] = -volume;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="waveData">加算対象の波形データ</param>
        /// <param name="samplingRate">サンプリングレート[Hz]</param>
        /// <param name="frequency">周波数[Hz]</param>
        /// <param name="zure">位相のずれ(0.0～1.0)(0.0～2 * PIとしたほうがわかりやすい?)</param>
        /// <param name="volume">ボリューム(振幅)</param>
        public static void AddSinWave(double[] waveData, int samplingRate, double frequency, double zure, double volume)
        {
            double k1 = frequency * 2 * Math.PI / samplingRate;
            double k0 = zure * Math.PI * 2;
            for (int i = 0; i < waveData.Length; i++)
            {
                double theta = i * k1 + k0;
                waveData[i] += Math.Sin(theta) * volume;
            }
        }

        /// <summary>
        /// ボリュームを適正化(振幅の絶対値の最大値が1.0となるように)する。
        /// </summary>
        /// <param name="waveData"></param>
        public static void NomalizeVolume(double[] waveData)
        {
            double max = 0;
            foreach (var v in waveData)
                max = Math.Max(Math.Abs(v), max);
            for (int i = 0; i < waveData.Length; i++)
                waveData[i] /= max;
        }

        /// <summary>
        /// 16bitのWavデータに変換する。
        /// </summary>
        /// <param name="waveData"></param>
        /// <returns></returns>
        public static short[] ConvertToWavData(double[] waveData)
        {
            var wavData = new short[waveData.Length];
            for (int i = 0; i < waveData.Length; i++)
                wavData[i] = (short)(short.MaxValue * waveData[i]);
            return wavData;
        }

        /// <summary>
        /// 16bitのWavデータから変換する。
        /// </summary>
        /// <param name="waveData"></param>
        /// <returns></returns>
        public static double[] ConvertFromWavData(short[] wavData)
        {
            var waveData = new double[wavData.Length];
            for (int i = 0; i < wavData.Length; i++)
                waveData[i] = ((double)Math.Max((int)wavData[i], -short.MaxValue)) / short.MaxValue;
            return waveData;
        }
    }
}
