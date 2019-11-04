using EasyPhisicsDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDotNet.ConvexMesh
{
    public class SphereConvexMesh : EpxConvexMesh
    {
        private static float[] sphere_vertices = {
            0.267617f, -0.500000f, -0.823639f, 
            -0.700629f, -0.500000f, -0.509037f, 
            -0.700629f, -0.500000f, 0.509037f, 
            0.267617f, -0.500000f, 0.823639f, 
            0.866025f, -0.500000f, 0.000000f, 
            0.267617f, 0.500000f, -0.823639f, 
            -0.700629f, 0.500000f, -0.509037f, 
            -0.700629f, 0.500000f, 0.509037f, 
            0.267617f, 0.500000f, 0.823639f, 
            0.866025f, 0.500000f, 0.000000f, 
            0.000000f, -1.000000f, 0.000000f, 
            0.000000f, 1.000000f, 0.000000f};

        private static int[] sphere_indices = {
            0, 1, 5, 
            5, 1, 6, 
            1, 2, 6, 
            6, 2, 7, 
            2, 3, 7, 
            7, 3, 8, 
            3, 4, 8, 
            8, 4, 9, 
            4, 0, 9, 
            9, 0, 5, 
            1, 0, 10, 
            2, 1, 10, 
            3, 2, 10, 
            4, 3, 10, 
            0, 4, 10, 
            5, 6, 11, 
            6, 7, 11, 
            7, 8, 11, 
            8, 9, 11, 
            9, 5, 11};

        public SphereConvexMesh(EpxVector3 scale) :
            base(sphere_vertices, sphere_indices, scale) {
        }
    }
}
