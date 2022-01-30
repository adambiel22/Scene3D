using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MathNet.Numerics.LinearAlgebra.Double;



namespace _3DAdamBielecki._3DScene
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
            Vector A = (Vector)(Verticies[1].PositionVector - Verticies[0].PositionVector); 
            Vector B = (Vector)(Verticies[2].PositionVector - Verticies[0].PositionVector);
            Vector C = VectorExtender.Cross(A, B);
            return (Vector)C.Normalize(2);
        }
    }


}
