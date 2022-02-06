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
        private Vertex[,] verticies;
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
                

            verticies = new Vertex[levelX + 1, levelY + 1];

            for (int i = 0; i <= levelX; i++)
            {
                for (int j = 0; j <= levelY; j++)
                {
                    verticies[i, j] = new Vertex(
                        new Vector(xLen * i, yLen * j, 0, 1),
                        new Vector(0, 0, 1, 0));
                }
            }
            for (int i = 0; i < levelX; i++)
            {
                for (int j = 0; j < levelY; j++)
                {
                    Triangles.Add(new Triangle(
                        verticies[i, j],
                        verticies[i + 1, j],
                        verticies[i + 1, j + 1]));
                    Triangles.Add(new Triangle(
                        verticies[i, j],
                        verticies[i + 1, j + 1],
                        verticies[i, j + 1]));
                }
            }

        }

    }
}
