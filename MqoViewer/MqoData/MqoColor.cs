namespace MQData
{
    /// <summary>
    /// 色(R, G, B, Aそれぞれ0～1)
    /// </summary>
    public class MqoColor
    {
        public double Red;
        public double Green;
        public double Blue;
        public double Alpha;

        public MqoColor(double r, double g, double b, double a = 1.0)
        {
            Red = r;
            Green = g;
            Blue = b;
            Alpha = a;
        }

        public override string ToString()
        {
            return
                "Red = " + Red + "\n"
                + "Green = " + Green + "\n"
                + "Blue = " + Blue + "\n"
                + "Alpha = " + Alpha + "\n";
        }
    }
}
