using System.Collections.Generic;

namespace _3DAdamBielecki._3DScene
{
    public class Block
    {
        public List<Triangle> Triangles { get; protected set; }
        public Block()
        {
            Triangles = new List<Triangle>();
        }
    }
}