using System.Collections.Generic;

namespace _3DAdamBielecki
{
    public class Block
    {
        public List<(int, int, int)> Triangles { get; protected set; }
        public Vertex[] Verticies { get; protected set; } 
        public Block()
        {
            Triangles = new List<(int, int, int)>(); 
        }
    }
}