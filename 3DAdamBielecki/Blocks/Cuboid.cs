using Algebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki
{
    public class Cuboid : Block
    {

        public Cuboid(double x = 1.0, double y = 1.0, double z = 1.0) : base()
        {
            Verticies = new Vertex[]
            {
                new Vertex(new Vector(0.0, 0.0, 0.0, 1.0),
                    new Vector(-x / 2.0, -y / 2.0, -z / 2, 0)),
                new Vertex(new Vector(x, 0.0, 0.0, 1.0),
                    new Vector(x / 2.0, -y / 2.0, -z / 2.0, 0.0)),
                new Vertex(new Vector(x, y, 0.0, 1.0),
                    new Vector(x / 2.0, y / 2.0, -z / 2.0, 0.0)),
                new Vertex(new Vector(0.0, y, 0.0, 1.0),
                    new Vector(-x / 2.0, y / 2.0, -z / 2.0, 0.0)),
                new Vertex(new Vector(0.0, 0.0, z, 1.0),
                    new Vector(-x / 2.0, -y / 2.0, z / 2.0, 0.0)),
                new Vertex(new Vector(x, 0.0, z, 1.0),
                    new Vector(x / 2.0, -y / 2.0, z / 2.0, 0.0)),
                new Vertex(new Vector(x, y, z, 1.0),
                    new Vector(x / 2.0, y / 2.0, z / 2.0, 0.0)),
                new Vertex(new Vector(0.0, y, z, 1.0),
                    new Vector(-x / 2.0, y / 2.0, z / 2.0, 0.0)),
            };
            foreach(Vertex vertex in Verticies)
            {
                vertex.NormalVector.Normalize();
            }

            Triangles.AddRange(new (int, int, int)[]
            {
                (0, 2, 1),
                (0, 3, 2),
                (6, 4, 5),
                (6, 7, 4),
                (1, 2, 5),
                (2, 6, 5),
                (0, 4, 3),
                (4, 7, 3),
                (2, 3, 6),
                (6, 3, 7),
                (5, 0, 1),
                (4, 0, 5),
            });
        }
    }
}
