using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OpenTkTest
{
    class Cube
    {
        public Cube(int program)
        {
            Vertex[] v = new Vertex[] {
                new Vertex(new Vector3(-1.0f, 1.0f,-1.0f), new Vector3(-1.0f, 1.0f,-1.0f)),
                new Vertex(new Vector3( 1.0f, 1.0f,-1.0f), new Vector3( 1.0f, 1.0f,-1.0f)),
                new Vertex(new Vector3( 1.0f, 1.0f, 1.0f), new Vector3( 1.0f, 1.0f, 1.0f)),
                new Vertex(new Vector3(-1.0f, 1.0f, 1.0f), new Vector3(-1.0f, 1.0f, 1.0f)),
                new Vertex(new Vector3(-1.0f,-1.0f,-1.0f), new Vector3(-1.0f,-1.0f,-1.0f)),
      new Vertex(new Vector3( 1.0f,-1.0f,-1.0f), new Vector3( 1.0f,-1.0f,-1.0f)),
      new Vertex(new Vector3( 1.0f,-1.0f, 1.0f), new Vector3( 1.0f,-1.0f, 1.0f)),
      new Vertex(new Vector3(-1.0f,-1.0f, 1.0f), new Vector3(-1.0f,-1.0f, 1.0f)),
  };
            foreach (Vertex vv in v)
            {
                vv.normal.Normalize();
            }

            uint[] indices = new uint[]{
                0,1,2,
          0,2,3,
      1,0,4,
      1,4,5,
      2,1,5,
      2,5,6,
      3,2,6,
      3,6,7,
      0,3,7,
      0,7,4,
      6,5,4,
      7,6,4
  };
        }

    }

    struct Vertex
    {
        public Vector3 position;
        public Vector3 normal;

        public Vertex(Vector3 position, Vector3 normal)
        {
            this.position = position;
            this.normal = normal;
        }
        public static readonly int Stride = Marshal.SizeOf(default(Vertex));
    }
}   