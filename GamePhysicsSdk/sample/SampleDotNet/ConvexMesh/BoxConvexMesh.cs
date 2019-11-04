using EasyPhisicsDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDotNet.ConvexMesh
{
    public class BoxConvexMesh : EpxConvexMesh
    {
        private static float[] vertices = {
            -1f, -1f, 1f, 
            1f, -1f, 1f, 
            -1f, 1f, 1f, 
            1f, 1f, 1f, 
            -1f, 1f, -1f, 
            1f, 1f, -1f, 
            -1f, -1f, -1f, 
            1f, -1f, -1f};

        private static int[] indices = {
            0, 1, 2, 
            2, 1, 3, 
            2, 3, 4, 
            4, 3, 5, 
            4, 5, 6, 
            6, 5, 7, 
            6, 7, 0, 
            0, 7, 1, 
            1, 7, 3, 
            3, 7, 5, 
            6, 0, 4, 
            4, 0, 2};

        public BoxConvexMesh(EpxVector3 scale) :
            base(vertices, indices, scale)
        {
        }
    }
}
