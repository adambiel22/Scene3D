using Algebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scene3D
{
    public class RectangleFaceZX : Block
    {
        public RectangleFaceZX(double z, double x, int triangulationLevel) : base(0)
        {
            int levelZ;
            int levelX;
            if (z > x)
            {
                levelZ = triangulationLevel;
                levelX = (int)Math.Ceiling(x * triangulationLevel / z);
            }
            else if (z < x)
            {
                levelZ = (int)Math.Ceiling(z * triangulationLevel / x);
                levelX = triangulationLevel;
            }
            else
            {
                levelZ = triangulationLevel;
                levelX = triangulationLevel;
            }
            double zLen = z / levelZ;
            double xLen = x / levelX;


            Verticies = new Vertex[(levelZ + 1) * (levelX + 1)];

            for (int i = 0; i <= levelZ; i++)
            {
                for (int j = 0; j <= levelX; j++)
                {
                    Verticies[i * (levelX + 1) + j] = new Vertex(
                        new Vector(xLen * j, 0, zLen * i, 1),
                        new Vector(0, 1, 0, 0));
                }
            }
            for (int i = 0; i < levelZ; i++)
            {
                for (int j = 0; j < levelX; j++)
                {
                    Triangles.Add((
                        i * (levelX + 1) + j,
                        (i + 1) * (levelX + 1) + j,
                        (i + 1) * (levelX + 1) + j + 1));
                    Triangles.Add((
                        i * (levelX + 1) + j,
                        (i + 1) * (levelX + 1) + j + 1,
                        i * (levelX + 1) + j + 1));
                }
            }

        }

    }
}
