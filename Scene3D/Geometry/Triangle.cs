using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Algebra;



namespace Scene3D
{
    public class Triangle
    {
        public Vertex[] Verticies { get; private set; }

        public Triangle(Vertex vertex0, Vertex vertex1, Vertex vertex2)
        {
            Verticies = new Vertex[3];
            Verticies[0] = vertex0;
            Verticies[1] = vertex1;
            Verticies[2] = vertex2;
        }

        public Vector GetNormalVector()
        {
            Vector A = Verticies[1].PositionVector - Verticies[0].PositionVector; 
            Vector B = Verticies[2].PositionVector - Verticies[0].PositionVector;
            Vector C = Vector.Cross(A, B);
            C.Normalize();
            return C;
        }

        public Vector GetMiddle()
        {
            Vector middle =
                ((Verticies[0].PositionVector
                + Verticies[1].PositionVector
                + Verticies[2].PositionVector) / 3);
            return middle;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(Vertex vertex in Verticies)
            {
                stringBuilder.Append($"{vertex}");
            }
            return stringBuilder.ToString();
        }
    }


}
