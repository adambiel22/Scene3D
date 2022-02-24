using System.Collections.Generic;
using System.Linq;

namespace Scene3D
{
    public class Block
    {
        public List<(int, int, int)> Triangles { get; protected set; }
        public Vertex[] Verticies { get; set; } 
        public Block(int vertexNo)
        {
            Verticies = new Vertex[vertexNo];
            Triangles = new List<(int, int, int)>(); 
        }

        protected void AddBlock(Block block)
        {
            (int, int, int)[] triangles = block.Triangles.ToArray();
            for (int i = 0; i < triangles.Length; i++)
            {
                triangles[i] = (
                    triangles[i].Item1 + Verticies.Length,
                    triangles[i].Item2 + Verticies.Length,
                    triangles[i].Item3 + Verticies.Length);
            }
            Triangles.AddRange(triangles);
            Verticies = Enumerable.Concat(Verticies, block.Verticies).ToArray();
        }

        public void InsideOutRotation()
        {
            (int, int, int)[] triangles = Triangles.ToArray();
            for (int i = 0; i < triangles.Length; i++)
            {
                triangles[i] = (
                    triangles[i].Item1,
                    triangles[i].Item3,
                    triangles[i].Item2);
            }
            Triangles = new List<(int, int, int)>(triangles);
            foreach(Vertex v in Verticies)
            {
                v.NormalVector[0] *= -1;
                v.NormalVector[1] *= -1;
                v.NormalVector[2] *= -1;
            }
        }
    }
}