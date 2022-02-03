using System.Collections.Generic;

namespace _3DAdamBielecki._3DScene
{
    public class Scene
    {
        public List<TransformatedBlock> TransformatedBlocks { get; private set; }
        public Camera Camera { get; set; }
        public Projection Projection { get; set; }
        public Light[] Lights { get; set; }
    }
}