using Algebra;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki
{
    public class OffsetAnnimation : BlockWithCameraAnimation
    {
        private Vector velocityVector;
        private double distance;

        public double Velocity
        {
            get => velocityVector.Norm();
            set { velocityVector.Normalize(); velocityVector = velocityVector * value; }
        }

        public double Lenght { get; private set; }

        public OffsetAnnimation(
            TransformatedBlock transformatedBlock, Camera camera, Vector cameraOffset,
            double velocity, double length) : base(transformatedBlock, camera, cameraOffset)
        {
            velocityVector = new Vector(1, 0, 0, 0);
            velocityVector = velocityVector * velocity;
            Lenght = length;
            distance = 0.0;
        }

        public override void NextFrame(double timeOffset)
        {
            if (changeVelocityVector(timeOffset)) return;
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
            Camera.CameraPosition =
                TransformatedBlock.Transformation.TransformPoint(new Vector(0, 0, 0, 1)) + CameraOffset;
            Camera.CameraTarget = Camera.CameraPosition + velocityVector;
        }

        private bool changeVelocityVector(double timeOffset)
        {
            double norm = velocityVector.Norm();
            double newDistance = distance + timeOffset * norm;
            Debug.WriteLine(newDistance);
            if (newDistance >= Lenght)
            {
                double difference = newDistance - distance;
                velocityVector[0] *= -1;
                velocityVector[1] *= -1;
                velocityVector[2] *= -1;
                TransformatedBlock
                    .Transformation
                    .AddTransformation(new double[,]
                {
                    { 1, 0, 0, velocityVector[0] / norm * difference },
                    { 0, 1, 0, velocityVector[1] / norm * difference },
                    { 0, 0, 1, velocityVector[2] / norm * difference },
                    { 0, 0, 0, 1 },
                });

                distance = difference;
                return true;
            }
            distance = newDistance;
            return false;

        }
    }
}
