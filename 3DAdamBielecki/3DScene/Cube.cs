using Algebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki._3DScene
{
    public class Cube : Block
    {
        private List<Vertex> vertices;
        public Cube() : base()
        {
            vertices = new List<Vertex>();

            //TODO: zmienić na odpowiednie wektory normalne.
            //Teraz te przy podstawie są błędne, bo nie są skierowane do środka ciężkości ostrosłupa.
            Vertex[] cubeVerices = new Vertex[]
            {
                new Vertex(new Vector(0, 0, 0, 1),
                    new Vector(0, 0, 1, 0)),
                new Vertex(new Vector(1, 0, 0, 1),
                    new Vector(Math.Sqrt(2)/2, Math.Sqrt(2)/2, 0, 0)),
                new Vertex(new Vector(1, 1, 0, 1),
                    new Vector(Math.Sqrt(2) / 2, -Math.Sqrt(2) /  2, 0, 0)),
                new Vertex(new Vector(0, 1, 0, 1),
                    new Vector(-Math.Sqrt(2)/2, -Math.Sqrt(2)/2, 0, 0)),
                new Vertex(new Vector(0, 0, 1, 1),
                    new Vector(-Math.Sqrt(2)/2, Math.Sqrt(2)/2, 0, 0)),
                new Vertex(new Vector(1, 0, 1, 1),
                    new Vector(-Math.Sqrt(2)/2, Math.Sqrt(2)/2, 0, 0)),
                new Vertex(new Vector(1, 1, 1, 1),
                    new Vector(-Math.Sqrt(2)/2, Math.Sqrt(2)/2, 0, 0)),
                new Vertex(new Vector(0, 1, 1, 1),
                    new Vector(-Math.Sqrt(2)/2, Math.Sqrt(2)/2, 0, 0)),
            };
            vertices.AddRange(cubeVerices);

            //TODO: zastanowić się czy nie trzeba w jakiejś
            //odpowiedniej kolejności dodawać wiecrzchołki tych trójkątów??
            Triangles.AddRange(new Triangle[]
            {
                new Triangle(cubeVerices[0], cubeVerices[1], cubeVerices[2]),
                new Triangle(cubeVerices[0], cubeVerices[2], cubeVerices[3]),
                new Triangle(cubeVerices[6], cubeVerices[5], cubeVerices[4]),
                new Triangle(cubeVerices[6], cubeVerices[4], cubeVerices[7]),
                new Triangle(cubeVerices[1], cubeVerices[5], cubeVerices[2]),
                new Triangle(cubeVerices[2], cubeVerices[5], cubeVerices[6]),
                new Triangle(cubeVerices[0], cubeVerices[3], cubeVerices[4]),
                new Triangle(cubeVerices[2], cubeVerices[6], cubeVerices[3]),
                new Triangle(cubeVerices[6], cubeVerices[7], cubeVerices[3]),
                new Triangle(cubeVerices[5], cubeVerices[1], cubeVerices[0]),
                new Triangle(cubeVerices[4], cubeVerices[5], cubeVerices[0]),
            });
        }
    }
}
