using System.Collections.Generic;

namespace _3DAdamBielecki
{
    public class Scene
    {
        public List<TransformatedBlock> TransformatedBlocks { get; private set; }
        public Camera CurrentCamera { get; private set; }
        public List<Camera> Cameras { get; private set; }
        public List<Light> Lights { get; private set; }
        public List<IAnimation> Animations { get; private set; }

        public Scene()
        {
            TransformatedBlocks = new List<TransformatedBlock>();
            Lights = new List<Light>();
            Animations = new List<IAnimation>();
            Cameras = new List<Camera>();
        }

        public void SetCurrentCamera(int index)
        {
            CurrentCamera = Cameras[index];
        }
    }
}