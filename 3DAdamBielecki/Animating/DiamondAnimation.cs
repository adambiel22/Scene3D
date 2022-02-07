using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki
{
    class DiamondAnimation : IAnimation
    {
        public TransformatedBlock DiamondX { get; set; }
        public TransformatedBlock DiamondY { get; set; }
        public TransformatedBlock DiamondZ { get; set; }
        public double AngleVelocity { get; set; }

        public DiamondAnimation(
            TransformatedBlock diamondX,
            TransformatedBlock diamondY,
            TransformatedBlock diamondZ, double angleVelocity)
        {
            DiamondX = diamondX;
            DiamondY = diamondY;
            DiamondZ = diamondZ;
            AngleVelocity = angleVelocity;
        }

        public void NextFrame(TimeSpan timeOffset)
        {
            double timeOffsetSeconds = timeOffset.TotalSeconds;
            double dAngle = AngleVelocity * timeOffsetSeconds;
            DiamondX.Transformation.AddXAxisRotation(dAngle);
            DiamondY.Transformation.AddYAxisRotation(dAngle);
            DiamondZ.Transformation.AddZAxisRotation(dAngle);
        }
    }
}
