using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algebra;

namespace Scene3D
{
    public class Pyramid : Block
    {
        public Pyramid(double x = 1.0, double y = 1.0, double z = 1.0) : base(5)
        {
            Verticies = new Vertex[]
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
            foreach (Vertex vertex in Verticies)
            {
                vertex.NormalVector.Normalize();
            }

            Triangles.AddRange(new (int,int,int)[]
            {
                (0, 2, 1),
                (0, 1, 4),
                (0, 3, 2),
                (0, 4, 3),
                (1, 2, 3),
                (1, 3, 4),
            });
        }
    }
}
