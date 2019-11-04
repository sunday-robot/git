using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace BftConverter
{
    public static class BftLoader
    {
        static Color[] defaultPalette2;
        static Color[] defaultPalette16;
        static BftLoader()
        {
            defaultPalette2 = new[] {
            Color.FromArgb(0x00, 0x00, 0x00),   // 0
            Color.FromArgb(0xff, 0xff, 0xff)};  // 1
            defaultPalette16 = new[] {
            Color.FromArgb(0x00, 0x00, 0x00),   // 0
            Color.FromArgb(0x00, 0x00, 0xff),   // 1
            Color.FromArgb(0xff, 0x00, 0x00),   // 2
            Color.FromArgb(0xff, 0x00, 0xff),   // 3
            Color.FromArgb(0x00, 0xff, 0x00),   // 4
            Color.FromArgb(0x00, 0x00, 0xff),   // 5
            Color.FromArgb(0xff, 0xff, 0x00),   // 6
            Color.FromArgb(0xff, 0xff, 0xff),   // 7
            Color.FromArgb(0x44, 0x44, 0x44),   // 8
            Color.FromArgb(0x00, 0x00, 0x88),   // 9
            Color.FromArgb(0x88, 0x00, 0x00),   // 10
            Color.FromArgb(0x88, 0x00, 0x88),   // 11
            Color.FromArgb(0x00, 0x88, 0x00),   // 12
            Color.FromArgb(0x00, 0x88, 0x88),   // 13
            Color.FromArgb(0x88, 0x88, 0x00),   // 14
            Color.FromArgb(0x88, 0x88, 0x88)};  // 15
        }

        public static List<Bitmap> Load(string filePath, int transparentColorNumber)
        {
            var data = loadData(filePath);
            return getBitmapFromBftData(data, transparentColorNumber);
        }

        static byte[] loadData(string filePath)
        {
            var fs = new FileStream(filePath, System.IO.FileMode.Open);
            var data = new byte[fs.Length];
            fs.Read(data, 0, (int)fs.Length);
            fs.Close();
            return data;
        }

        static bool byteStringCompare(byte[] buf, int offset, string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (buf[offset + i] != s[i])
                {
                    return false;
                }
            }
            return true;
        }

        static short bytesToShort(byte[] buf, int offset)
        {
            return (short)(buf[offset] + (((short)buf[offset + 1]) << 8));
        }

        static int getBftHeaderInfo(byte[] data, out int width, out int height, out int colorCount, out int count, out Color[] palette)
        {
            if (!byteStringCompare(data, 0, "BFNT\x1a"))
            {
                throw new Exception("This is not B-Font File.");
            }
            int offset = 5;
            int bftCol = data[offset++];
            if ((bftCol & 0x7f) > 3)
            {
                throw new Exception("Too many colors.");
            }
            int bftTtl = data[offset++];
            offset++;   // skip count
            width = bytesToShort(data, offset); offset += 2;
            height = bytesToShort(data, offset); offset += 2;
            int bftStart = bytesToShort(data, offset); offset += 2;
            int bftEnd = bytesToShort(data, offset); offset += 2;
            count = bftEnd - bftStart + 1;
            offset += 8;   // skip font name
            offset += 4;    // skip time
            int bftExtSize = bytesToShort(data, offset); offset += 2;
            int bftHdrSize = bytesToShort(data, offset); offset += 2;
            colorCount = 2 << (bftCol & 0x7f);

            if ((bftCol & 0x80) != 0)
            {
                palette = new Color[colorCount];
                for (int i = 0; i < colorCount; i++)
                {
                    // ファイル内の値は、16階調での値を単純に16倍したものでしかない。したがって最高輝度であっても255ではなく、15 * 16の240でしかないので補正する。
                    int b = (data[offset++] >> 4) * 0x11;
                    int r = (data[offset++] >> 4) * 0x11;
                    int g = (data[offset++] >> 4) * 0x11;
                    palette[i] = Color.FromArgb(r, g, b);
                }
            }
            else
            {
                switch (colorCount)
                {
                    case 2:
                        palette = defaultPalette2;
                        break;
                    case 16:
                        palette = defaultPalette16;
                        break;
                    default:
                        throw new Exception("Sorry not implemented.");
                }

            }
            return offset;
        }

        static List<Bitmap> getBitmapFromBftData(byte[] data, int transparentColorNumber)
        {
            int width;
            int height;
            int colorCount;
            int count;
            Color[] palette;
            int offset = getBftHeaderInfo(data, out width, out height, out colorCount, out count, out palette);
            Func<int, int> x;
            x = (a) => a * 2;
            ReadAndCreateBitmap readAndCreateBitmap;
            switch (colorCount)
            {
                case 16:
                    readAndCreateBitmap = readAndCreateBitmap16;
                    break;
                case 2:
                    readAndCreateBitmap = readAndCreateBitmap2;
                    break;
                default:
                    throw new Exception("Sorry not implemented.");
            }

            var bl = new List<Bitmap>();
            for (int i = 0; i < count; i++)
            {
                Bitmap bi = readAndCreateBitmap(data, ref offset, width, height, palette, transparentColorNumber);
                bl.Add(bi);
            }
            return bl;
        }

        delegate Bitmap ReadAndCreateBitmap(byte[] buf, ref int offset, int width, int height, Color[] palettes, int transparentColorNumber);

        static Bitmap readAndCreateBitmap2(byte[] buf, ref int offset, int width, int height, Color[] palettes, int transparentColorNumber)
        {
            var bm = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x += 8)
                {
                    byte b = buf[offset++];
                    for (int i = 0; i < 8; i++)
                    {
                        int colorNumber = b >> 7;
                        b <<= 1;
                        if (colorNumber == transparentColorNumber)
                            bm.SetPixel(x + i, y, Color.FromKnownColor(KnownColor.Transparent));
                        else
                            bm.SetPixel(x + i, y, palettes[colorNumber]);
                    }
                }
            }
            return bm;
        }

        static Bitmap readAndCreateBitmap16(byte[] buf, ref int offset, int width, int height, Color[] palettes, int transparentColorNumber)
        {
            var bm = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x += 2)
                {
                    int p1 = buf[offset] >> 4;
                    int p2 = buf[offset] & 0xf;
                    if (p1 == transparentColorNumber)
                        bm.SetPixel(x, y, Color.FromKnownColor(KnownColor.Transparent));
                    else
                        bm.SetPixel(x, y, palettes[p1]);

                    if (p2 == transparentColorNumber)
                        bm.SetPixel(x + 1, y, Color.FromKnownColor(KnownColor.Transparent));
                    else
                        bm.SetPixel(x + 1, y, palettes[p2]);
                    offset++;
                }
            }
            return bm;
        }

    }
}
