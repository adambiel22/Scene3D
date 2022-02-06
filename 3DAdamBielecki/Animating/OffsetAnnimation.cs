using Algebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki
{
    public class OffsetAnnimation : BlockAnimation
    {
        private Vector velocityVector;
        private double distance;

        public double Velocity
        {
            get => velocityVector.Norm();
            set { velocityVector.Normalize(); velocityVector = velocityVector * value; }
        }

        public double Lenght { get; private set; }

        public OffsetAnnimation(TransformatedBlock transformatedBlock, double velocity, double length)
            : base(transformatedBlock)
        {
            velocityVector = new Vector(1, 0, 0, 0);
            velocityVector = velocityVector * velocity;
            Lenght = length;
            distance = 0.0;
        }

        public override void NextFrame(double timeOffset)
        {
            changeVelocityVector(timeOffset);
            Vector offset = new Vector(
                timeOffset * velocityVector[0],
                timeOffset * velocityVector[1],
                timeOffset * velocityVector[2]);
            TransformatedBlock
                .Transformation
                .AddTransformation(new double[,]
            {
                { 1, 0, 0, offset[0] },
                { 0, 1, 0, offset[1] },
                { 0, 0, 1, offset[2] },
                { 0, 0, 0, 1 },
            });
        }

        private void changeVelocityVector(double timeOffset)
        {
            distance += timeOffset * velocityVector.Norm();
            if (distance >= Lenght)
            {
                velocityVector[0] *= -1;
                velocityVector[1] *= -1;
                velocityVector[2] *= -1;
                distance = 0;
            }
        }
    }
}
