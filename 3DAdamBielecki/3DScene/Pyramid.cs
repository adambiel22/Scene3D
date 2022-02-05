using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algebra;

namespace _3DAdamBielecki._3DScene
{
    public class Pyramid : Block
    {
        private List<Vertex> vertices;
        public Pyramid(int x = 1, int y = 1, int z = 1) : base()
        {
            vertices = new List<Vertex>();

            //TODO: zmienić na odpowiednie wektory normalne.
            //Teraz te przy podstawie są błędne, bo nie są skierowane do środka ciężkości ostrosłupa.
            Vertex[] pyramidVerices = new Vertex[]
            {
                new Vertex(new Vector(0, 0, 2 * z, 1),
                    new Vector(0, 0, 1, 0)),
                new Vertex(new Vector(x, y, 0, 1),
                    new Vector(1, 1, -1, 0)),
                new Vertex(new Vector(x, -y, 0, 1),
                    new Vector(1, -1, -1, 0)),
                new Vertex(new Vector(-x, -y, 0, 1),
                    new Vector(-1, -1, -1, 0)),
                new Vertex(new Vector(-x, y, 0, 1),
                    new Vector(-1, 1, -1, 0))
            };
            foreach (Vertex vertex in pyramidVerices)
            {
                vertex.NormalVector.Normalize();
            }
            vertices.AddRange(pyramidVerices);

            //TODO: zastanowić się czy nie trzeba w jakiejś
            //odpowiedniej kolejności dodawać te trójkąty??
            Triangles.AddRange(new Triangle[]
            {
                new Triangle(pyramidVerices[0], pyramidVerices[2], pyramidVerices[1]),
                new Triangle(pyramidVerices[0], pyramidVerices[1], pyramidVerices[4]),
                new Triangle(pyramidVerices[0], pyramidVerices[3], pyramidVerices[2]),
                new Triangle(pyramidVerices[0], pyramidVerices[4], pyramidVerices[3]),
                new Triangle(pyramidVerices[1], pyramidVerices[2], pyramidVerices[3]),
                new Triangle(pyramidVerices[1], pyramidVerices[3], pyramidVerices[4]),
            });
        }
    }
}
