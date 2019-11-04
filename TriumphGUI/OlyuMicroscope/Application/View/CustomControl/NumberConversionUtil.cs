using System;

namespace Olympus.LI.Triumph.Application.View.CustomControl.Infrastructure.LocalizeUtil {
    public class NumberConversionUtil {
        public static bool DoubleTryParse(String s, out double d) {
            return Double.TryParse(s, out d);
        }
        public static double DoubleParse(String s) {
            return Double.Parse(s);
        }
    }
}
