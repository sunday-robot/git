namespace EasyPhisicsDotNet
{
    class EpxVectirFunction
    {
        static void epxCalcTangentVector(EpxVector3 normal, out EpxVector3 tangent1, out EpxVector3 tangent2)
        {
            var n = new EpxVector3(0, normal.Y, normal.Z);
            EpxVector3 vec;
            if (n.LengthSqr() < float.Epsilon)
                vec = new EpxVector3(0.0f, 1.0f, 0.0f);
            else
                vec = new EpxVector3(1.0f, 0.0f, 0.0f);
            tangent1 = normal.cross(vec).Normalize();
            tangent2 = tangent1.cross(normal).Normalize();
        }
    }
}
