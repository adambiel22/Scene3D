using System.Collections.Generic;

namespace _3DAdamBielecki
{
    public class Scene
    {
        public List<TransformatedBlock> TransformatedBlocks { get; private set; }
        public Camera Camera { get; set; }
        public Projection Projection { get; set; }
        public List<Light> Lights { get; set; }

        public Scene()
        {
            TransformatedBlocks = new List<TransformatedBlock>();
            Lights = new List<Light>();
        }
    }
}