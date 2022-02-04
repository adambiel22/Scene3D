using MathNet.Numerics.LinearAlgebra.Double;
using System;

namespace _3DAdamBielecki._3DScene
{
    public class Projection
    {
        private Matrix projectionMatrix;
        private double fieldOfView;
        private double farPlaneDistance;
        private double aspectRatio;
        private double nearPlaneDistance;
        public double FieldOfView { get => fieldOfView; set { fieldOfView = value; UpdateProjectionMatrix(); } }
        public double FarPlaneDistance { get => farPlaneDistance; set { farPlaneDistance = value; UpdateProjectionMatrix(); } }
        public double AspectRatio { get => aspectRatio; set { aspectRatio = value; UpdateProjectionMatrix(); } }
        public double NearPlaneDistance { get => nearPlaneDistance; set { nearPlaneDistance = value; UpdateProjectionMatrix(); } }
        public int ScreenWidth { get; set; }
        public int ScreenHeight { get; set; }

        public Projection(double fieldOfView, double farPlaneDistance, double nearPlaneDistance, double aspectRatio)
        {
            this.fieldOfView = fieldOfView;
            this.farPlaneDistance = farPlaneDistance;
            this.aspectRatio = aspectRatio;
            this.nearPlaneDistance = nearPlaneDistance;
            projectionMatrix = DenseMatrix.Create(4, 4, 0);
            UpdateProjectionMatrix();
        }

        public Vector Project(Vector vector)
        {
            Vector projectedVector = (Vector)(projectionMatrix * vector);
            projectedVector[0] /= projectedVector[3];
            projectedVector[1] /= projectedVector[3];
            projectedVector[2] /= projectedVector[3];
            projectedVector[3] = 1;
            return projectedVector;
        }
        private void UpdateProjectionMatrix()
        {
            double focalLength = 1.0 / Math.Tan(FieldOfView / 2);

            projectionMatrix[0, 0] = focalLength;
            projectionMatrix[1, 1] = focalLength / aspectRatio;
            projectionMatrix[2, 2] =
                (farPlaneDistance + nearPlaneDistance)
                / (nearPlaneDistance - farPlaneDistance);
            projectionMatrix[2, 3] =
                2 * nearPlaneDistance * nearPlaneDistance
                / (nearPlaneDistance - farPlaneDistance);
            projectionMatrix[3, 2] = -1;
        }
    }
}