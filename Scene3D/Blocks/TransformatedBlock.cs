
namespace Scene3D
{
    public class TransformatedBlock : Block
    {
        public Transformation Transformation { get; private set; }
        public Surface Surface { get; private set; }

        public TransformatedBlock(Block block, Transformation transformation, Surface surface) : base(0) 
        {
            Triangles = block.Triangles;
            Verticies = (Vertex[])block.Verticies.Clone();
            Transformation = transformation;
            Surface = surface;
        }
    }
}