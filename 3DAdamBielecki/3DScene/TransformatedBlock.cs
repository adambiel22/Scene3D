using _3DAdamBielecki.Shading;

namespace _3DAdamBielecki._3DScene
{
    public class TransformatedBlock : Block
    {
        public Transformation Transformation { get; private set; }
        public Surface Surface { get; private set; }

        public TransformatedBlock(Block block, Transformation transformation, Surface surface)
        {
            Triangles = block.Triangles;
            Transformation = transformation;
            Surface = surface;
        }
    }
}