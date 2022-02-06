using Algebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki
{
    public abstract class BlockWithCameraAnimation : IAnimation
    {
        public TransformatedBlock TransformatedBlock { get; set; }
        public Camera Camera { get; set; }
        public Vector CameraOffset { get; }

        public BlockWithCameraAnimation(TransformatedBlock transformatedBlock, Camera camera, Vector cameraOffset)
        {
            TransformatedBlock = transformatedBlock;
            Camera = camera;
            CameraOffset = cameraOffset;
        }

        public abstract void NextFrame(double timeOffset);
    }
}
