using Algebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki
{
    public class RectangleFace : Block
    {
        public RectangleFace(double x, double y, int triangulationLevel)
        {
            int levelX;
            int levelY;
            if (x > y)
            {
                levelX = triangulationLevel;
                levelY = (int)Math.Ceiling(y * triangulationLevel / x);
            }
            else if (x < y)
            {
                levelX = (int)Math.Ceiling(x * triangulationLevel / y);
                levelY = triangulationLevel;
            }
            else
            {
                levelX = triangulationLevel;
                levelY = triangulationLevel;
            }
            double xLen = x / levelX;
            double yLen = y / levelY;


            Verticies = new Vertex[(levelX + 1) * (levelY + 1)];

            for (int i = 0; i <= levelX; i++)
            {
                for (int j = 0; j <= levelY; j++)
                { 
                    Verticies[i * (levelX + 1) + j] = new Vertex(
                        new Vector(xLen * i, yLen * j, 0, 1),
                        new Vector(0, 0, 1, 0));
                }
            }
            for (int i = 0; i < levelX; i++)
            {
                for (int j = 0; j < levelY; j++)
                {
                    Triangles.Add((
                        i * (levelX + 1) + j,
                        (i + 1) * (levelX + 1) + j,
                        (i + 1) * (levelX + 1)+ j + 1));
                    Triangles.Add((
                        i * (levelX + 1) + j,
                        (i + 1) * (levelX + 1) + j + 1,
                        i * (levelX + 1) + j + 1));
                }
            }

        }

    }
}
