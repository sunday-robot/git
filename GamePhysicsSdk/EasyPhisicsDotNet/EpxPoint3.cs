namespace EasyPhisicsDotNet
{
    public class EpxPoint3
    {
        public float x;
        public float y;
        public float z;

        public EpxPoint3() { }
        public EpxPoint3(EpxPoint3 p)
        {
            x = p.x;
            y = p.y;
            z = p.z;
        }
        public EpxPoint3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public EpxPoint3(float s)
        {
            x = s;
            y = s;
            z = s;
        }
    }
}
