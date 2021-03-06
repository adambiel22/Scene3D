using Algebra;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scene3D
{
    public class Sphere : Block
    {
        private int triangulationLevel;
        private double radius;

        public Sphere(int triangulationLevel, double radius) : base(2 * (int)Math.Pow(4, triangulationLevel) - 2)
        {
            this.triangulationLevel = triangulationLevel;
            this.radius = radius;
            generateTriangulation();
        }

        private void generateTriangulation()
        {
            initializeVerticies();
            int vindex = 6;
            recursion(0, 1, 2, 1, ref vindex);
            recursion(0, 4, 1, 1, ref vindex);
            recursion(0, 3, 4, 1, ref vindex);
            recursion(0, 2, 3, 1, ref vindex);
            recursion(5, 2, 1, 1, ref vindex);
            recursion(5, 1, 4, 1, ref vindex);
            recursion(5, 4, 3, 1, ref vindex);
            recursion(5, 3, 2, 1, ref vindex);
        }

        private void initializeVerticies()
        {
            Vector position;
            Vector normalVector;
            position = new Vector(0, 0, radius, 1);
            normalVector = new Vector(position);
            normalVector.Normalize();
            Verticies[0] = new Vertex(position, normalVector);

            position = new Vector(radius, 0, 0, 1);
            normalVector = new Vector(position);
            normalVector.Normalize();
            Verticies[1] = new Vertex(position, normalVector);

            position = new Vector(0, radius, 0, 1);
            normalVector = new Vector(position);
            normalVector.Normalize();
            Verticies[2] = new Vertex(position, normalVector);

            position = new Vector(-radius, 0, 0, 1);
            normalVector = new Vector(position);
            normalVector.Normalize();
            Verticies[3] = new Vertex(position, normalVector);

            position = new Vector(0, -radius, 0, 1);
            normalVector = new Vector(position);
            normalVector.Normalize();
            Verticies[4] = new Vertex(position, normalVector);

            position = new Vector(0, 0, -radius, 1);
            normalVector = new Vector(position);
            normalVector.Normalize();
            Verticies[5] = new Vertex(position, normalVector);
        }

        private void recursion(int v_0, int v_1, int v_2, int n, ref int vindex)
        {
            if (n == triangulationLevel)
            {
                Triangles.Add((v_0, v_1, v_2));
                return;
            }

            Vector position;
            Vector normalVector;

            normalVector = Verticies[v_0].PositionVector + Verticies[v_1].PositionVector;
            normalVector.Normalize();
            position = normalVector * radius;
            position[3] = 1;
            Verticies[vindex++] = new Vertex(position, normalVector);

            normalVector = Verticies[v_1].PositionVector + Verticies[v_2].PositionVector;
            normalVector.Normalize();
            position = normalVector * radius;
            position[3] = 1;
            Verticies[vindex++] = new Vertex(position, normalVector);

            normalVector = Verticies[v_2].PositionVector + Verticies[v_0].PositionVector;
            normalVector.Normalize();
            position = normalVector * radius;
            position[3] = 1;
            Verticies[vindex++] = new Vertex(position, normalVector);

            int w0Index = vindex - 3;
            int w1Index = vindex - 2;
            int w2Index = vindex - 1;

            recursion(v_0, w0Index, w2Index, n + 1, ref vindex);
            recursion(w0Index, v_1, w1Index, n + 1, ref vindex);
            recursion(w2Index, w1Index, v_2, n + 1, ref vindex);
            recursion(w1Index, w2Index, w0Index, n + 1, ref vindex);
        }
    }
}
