using Algebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki
{
    public class RectangleFaceYZ : Block
    {
        public RectangleFaceYZ(double y, double z, int triangulationLevel) : base(0)
        {
            int levelY;
            int levelZ;
            if (y > z)
            {
                levelY = triangulationLevel;
                levelZ = (int)Math.Ceiling(z * triangulationLevel / y);
            }
            else if (y < z)
            {
                levelY = (int)Math.Ceiling(y * triangulationLevel / z);
                levelZ = triangulationLevel;
            }
            else
            {
                levelY = triangulationLevel;
                levelZ = triangulationLevel;
            }
            double yLen = y / levelY;
            double zLen = z / levelZ;


            Verticies = new Vertex[(levelY + 1) * (levelZ + 1)];

            for (int i = 0; i <= levelY; i++)
            {
                for (int j = 0; j <= levelZ; j++)
                {
                    Verticies[i * (levelZ + 1) + j] = new Vertex(
                        new Vector(0, yLen * i, zLen * j, 1),
                        new Vector(1, 0, 0, 0));
                }
            }
            for (int i = 0; i < levelY; i++)
            {
                for (int j = 0; j < levelZ; j++)
                {
                    Triangles.Add((
                        i * (levelZ + 1) + j,
                        (i + 1) * (levelZ + 1) + j,
                        (i + 1) * (levelZ + 1) + j + 1));
                    Triangles.Add((
                        i * (levelZ + 1) + j,
                        (i + 1) * (levelZ + 1) + j + 1,
                        i * (levelZ + 1) + j + 1));
                }
            }

        }

    }
}
