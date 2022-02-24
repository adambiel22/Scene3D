using Algebra;
using System;

namespace Scene3D
{
    public class RectangleFaceXY : Block
    {
        public RectangleFaceXY(double x, double y, int triangulationLevel) : base(0)
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
                    Verticies[i * (levelY + 1) + j] = new Vertex(
                        new Vector(xLen * i, yLen * j, 0, 1),
                        new Vector(0, 0, 1, 0));
                }
            }
            for (int i = 0; i < levelX; i++)
            {
                for (int j = 0; j < levelY; j++)
                {
                    Triangles.Add((
                        i * (levelY + 1) + j,
                        (i + 1) * (levelY + 1) + j,
                        (i + 1) * (levelY + 1)+ j + 1));
                    Triangles.Add((
                        i * (levelY + 1) + j,
                        (i + 1) * (levelY + 1) + j + 1,
                        i * (levelY + 1) + j + 1));
                }
            }

        }

    }
}
