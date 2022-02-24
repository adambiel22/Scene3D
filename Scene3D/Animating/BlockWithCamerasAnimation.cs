using Algebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scene3D
{
    public abstract class BlockWithCamerasAnimation : IAnimation
    {
        public TransformatedBlock TransformatedBlock { get; set; }
        public Camera FollowCamera { get; set; }
        public Camera FixedCamera { get; set; }
        public Reflector Reflector { get; set; }
        public Vector CameraOffset { get; }

        public BlockWithCamerasAnimation(
            TransformatedBlock transformatedBlock,
            Vector cameraOffset, Camera followCamera,
            Camera fixedCamera, Reflector reflector)
        {
            TransformatedBlock = transformatedBlock;
            CameraOffset = cameraOffset;
            FollowCamera = followCamera;
            FixedCamera = fixedCamera;
            Reflector = reflector;
        }

        public abstract void NextFrame(TimeSpan timeOffset);
    }
}
