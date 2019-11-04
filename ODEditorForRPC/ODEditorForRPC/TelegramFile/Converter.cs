using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramFile {
    public static class Converter {
        public static int BytesToInt(byte[] data, int index) {
            return data[index] * 256 + data[index + 1];
        }

        public static byte[] IntToBytes(int data) {
            var bytes = new byte[2];
            bytes[0] = (byte) ((data & 0xff00) >> 8);
            bytes[1] = (byte) (data & 0xff);
            return bytes;
        }
    }
}
