using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki._3DScene
{
    public class TriangleProjector
    {
        public Transformation Transformation { get; set; }
        public Camera Camera { get; set; }
        public Projection Projection { get; set; }
        
        public Triangle ProjectTriangle(Triangle triangle)
        {
            Vector[] verticiesInWorld = new Vector[3];
            Vector[] pro = new Vector[3];
            for (int i = 0; i < 3; i++) 
            {
                vectors[i] = DenseVector.OfArray(new double[] {
                    triangle.Verticies[i].PositionVector[0],
                    triangle.Verticies[i].PositionVector[1],
                    triangle.Verticies[i].PositionVector[2],
                    1
                });
                vectors[i] =
                    Projection.Project(
                        Camera.LookAt(
                            Transformation.Transform(vectors[i])));
                //jeszcze potrzebna jest transformacja wektora normalnego
            }
            //a tutaj jeszcze potrzebne jest rozciągnięcie do ekranu? no chyba tak.
            Triangle projectedTriangle = new Triangle()
        }
    }
}
