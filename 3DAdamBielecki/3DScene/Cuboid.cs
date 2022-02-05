using Algebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki._3DScene
{
    public class Cuboid : Block
    {
        private List<Vertex> vertices;
        public Cuboid(int x = 1, int y = 1, int z = 1) : base()
        {
            vertices = new List<Vertex>();

            //TODO: zmienić na odpowiednie wektory normalne.
            //Teraz te przy podstawie są błędne, bo nie są skierowane do środka ciężkości ostrosłupa.
            Vertex[] cubeVerices = new Vertex[]
            {
                new Vertex(new Vector(0, 0, 0, 1),
                    new Vector(-x / 2, -y / 2, -z / 2, 0)),
                new Vertex(new Vector(x, 0, 0, 1),
                    new Vector(x / 2, -y / 2, -z / 2, 0)),
                new Vertex(new Vector(x, y, 0, 1),
                    new Vector(x / 2, y / 2, -z / 2, 0)),
                new Vertex(new Vector(0, y, 0, 1),
                    new Vector(-x / 2, y / 2, -z / 2, 0)),
                new Vertex(new Vector(0, 0, z, 1),
                    new Vector(-x / 2, -y / 2, z / 2, 0)),
                new Vertex(new Vector(x, 0, z, 1),
                    new Vector(x / 2, -y / 2, z / 2, 0)),
                new Vertex(new Vector(x, y, z, 1),
                    new Vector(x / 2, y / 2, z / 2, 0)),
                new Vertex(new Vector(0, y, z, 1),
                    new Vector(-x / 2, y / 2, z / 2, 0)),
            };
            foreach(Vertex vertex in cubeVerices)
            {
                vertex.NormalVector.Normalize();
            }
            vertices.AddRange(cubeVerices);

            //TODO: zastanowić się czy nie trzeba w jakiejś
            //odpowiedniej kolejności dodawać wiecrzchołki tych trójkątów??
            Triangles.AddRange(new Triangle[]
            {

                new Triangle(cubeVerices[0], cubeVerices[2], cubeVerices[1]),
                new Triangle(cubeVerices[0], cubeVerices[3], cubeVerices[2]),
                new Triangle(cubeVerices[6], cubeVerices[4], cubeVerices[5]),
                new Triangle(cubeVerices[6], cubeVerices[7], cubeVerices[4]),
                new Triangle(cubeVerices[1], cubeVerices[2], cubeVerices[5]),
                new Triangle(cubeVerices[2], cubeVerices[6], cubeVerices[5]),
                new Triangle(cubeVerices[0], cubeVerices[4], cubeVerices[3]),
                new Triangle(cubeVerices[4], cubeVerices[7], cubeVerices[3]),
                new Triangle(cubeVerices[2], cubeVerices[3], cubeVerices[6]),
                new Triangle(cubeVerices[6], cubeVerices[3], cubeVerices[7]),
                new Triangle(cubeVerices[5], cubeVerices[0], cubeVerices[1]),
                new Triangle(cubeVerices[4], cubeVerices[0], cubeVerices[5]),
            });
        }
    }
}
