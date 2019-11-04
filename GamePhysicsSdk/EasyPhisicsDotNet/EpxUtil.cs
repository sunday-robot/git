namespace EasyPhisicsDotNet
{
    public class EpxUtil
    {
        public static float EPX_CLAMP(float s, float p1, float p2)
        {
            if (s < p1)
                return p1;
            if (s > p2)
                return p2;
            return s;
        }
    }
}
