using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki._3DScene
{
    public class Pyramid : Block
    {
        private List<Vertex> vertices;
        public Pyramid() : base()
        {
            vertices = new List<Vertex>();

            //TODO: zmienić na odpowiednie wektory normalne.
            //Teraz te przy podstawie są błędne, bo nie są skierowane do środka ciężkości ostrosłupa.
            Vertex[] pyramidVerices = new Vertex[]
            {
                new Vertex(VectorExtender.Vector4D(0, 0, 2, 1),
                    VectorExtender.Vector4D(0, 0, 1, 0)),
                new Vertex(VectorExtender.Vector4D(1, 1, 0, 1),
                    VectorExtender.Vector4D(Math.Sqrt(2)/2, Math.Sqrt(2)/2, 0, 0)),
                new Vertex(VectorExtender.Vector4D(1, -1, 0, 1),
                    VectorExtender.Vector4D(Math.Sqrt(2)/2, -Math.Sqrt(2)/2, 0, 0)),
                new Vertex(VectorExtender.Vector4D(-1, -1, 0, 1),
                    VectorExtender.Vector4D(-Math.Sqrt(2)/2, -Math.Sqrt(2)/2, 0, 0)),
                new Vertex(VectorExtender.Vector4D(-1, 1, 0, 1),
                    VectorExtender.Vector4D(-Math.Sqrt(2)/2, Math.Sqrt(2)/2, 0, 0))
            };
            vertices.AddRange(pyramidVerices);

            //TODO: zastanowić się czy nie trzeba w jakiejś
            //odpowiedniej kolejności dodawać te trójkąty??
            Triangles.AddRange(new Triangle[]
            {
                new Triangle(pyramidVerices[0], pyramidVerices[1], pyramidVerices[2]),
                new Triangle(pyramidVerices[0], pyramidVerices[1], pyramidVerices[4]),
                new Triangle(pyramidVerices[0], pyramidVerices[3], pyramidVerices[2]),
                new Triangle(pyramidVerices[0], pyramidVerices[3], pyramidVerices[4]),
                new Triangle(pyramidVerices[1], pyramidVerices[2], pyramidVerices[3]),
                new Triangle(pyramidVerices[1], pyramidVerices[3], pyramidVerices[4]),
            });
        }
    }
}
