using Algebra;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki._3DScene
{
    public class Sphere : Block
    {
        private int triangulationLevel;
        private double radius;
        private Vector[] verticies;

        public Sphere(int triangulationLevel, double radius)
        {
            this.triangulationLevel = triangulationLevel;
            this.radius = radius;
            generateTriangulation();
            //Triangle t = Triangles[0];
            //Triangles = new List<Triangle>();
            //Triangles.Add(t);
            foreach (Vector vector in verticies)
            {
                Debug.WriteLine(vector);
            }
            foreach (Triangle tr in Triangles)
            {
                Debug.WriteLine(tr);
            }
        }

        private void generateTriangulation()
        {
            verticies = new Vector[2*(int)Math.Pow(4, triangulationLevel)];
            verticies[0] = new Vector(0, 0, radius, 1);
            verticies[1] = new Vector(radius, 0, 0, 1);
            verticies[2] = new Vector(0, radius, 0, 1);
            verticies[3] = new Vector(-radius, 0, 0, 1);
            verticies[4] = new Vector(0, -radius, 0, 1);
            verticies[5] = new Vector(0, 0, -radius, 1);
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

        private void recursion(int v_0, int v_1, int v_2, int n, ref int vindex)
        {
            if (n == triangulationLevel)
            {
                Vector v0Normal = new Vector(verticies[v_0]);
                Vector v1Normal = new Vector(verticies[v_1]);
                Vector v2Normal = new Vector(verticies[v_2]);
                v0Normal.Normalize();
                v1Normal.Normalize();
                v2Normal.Normalize();

                Triangles.Add(new Triangle(
                    new Vertex(verticies[v_0], v0Normal),
                    new Vertex(verticies[v_1], v1Normal),
                    new Vertex(verticies[v_2], v2Normal)));
                return;
            }

            Vector w_0 = (verticies[v_0] + verticies[v_1]);
            w_0.Normalize();
            w_0 = w_0 * radius;
            w_0[3] = 1;
            verticies[vindex++] = w_0;

            Vector w_1 = (verticies[v_1] + verticies[v_2]);
            w_1.Normalize();
            w_1 = w_1 * radius;
            w_1[3] = 1;
            verticies[vindex++] = w_1;

            Vector w_2 = (verticies[v_2] + verticies[v_0]);
            w_2.Normalize();
            w_2 = w_2 * radius;
            w_2[3] = 1;
            verticies[vindex++] = w_2;

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
