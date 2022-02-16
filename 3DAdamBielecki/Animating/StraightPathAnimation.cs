using Algebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki.Animating
{
    public class StraightPathAnimation : IAnimation
    {
        public Vector StartPosition { get; private set; }
        public Vector EndPosition { get; private set; }
        public double VelocityValue { get; private set; }
        public TransformatedBlock TransformatedBlock { get; set; }
        public double Period { get; private set; }

        public StraightPathAnimation(Vector startPosition,
             Vector endPosition, double velocityValue, TransformatedBlock transformatedBlock)
        {
            StartPosition = startPosition;
            EndPosition = endPosition;
            VelocityValue = velocityValue;
            Period = (EndPosition - StartPosition).Norm() / VelocityValue;
            TransformatedBlock = transformatedBlock;
        }

        public void UpdateFrame(TimeSpan elapsedTime)
        {
            double scalar = (elapsedTime.TotalSeconds % Period) / Period;
            TransformatedBlock.Transformation.SetPosition(
                StartPosition + (EndPosition - StartPosition) * scalar);
        }
    }
}
