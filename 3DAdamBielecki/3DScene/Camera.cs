using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra;
using System;

namespace _3DAdamBielecki._3DScene
{
    public class Camera
    {
        private Matrix viewMatrix;
        private Vector cameraPosition;
        private Vector cameraTarget;
        private Vector upVector;

        public Vector CameraPosition { get => cameraPosition; set { cameraPosition = value; generateViewMarix(); } }
        public Vector CameraTarget { get => cameraTarget; set { cameraTarget = value; generateViewMarix(); }
}
        public Vector UpVector { get => upVector; set { upVector = value; generateViewMarix(); } }

        public Camera(Vector cameraPosition, Vector cameraTarget, Vector upVector)
        {
            this.cameraPosition = cameraPosition;
            this.cameraTarget = cameraTarget;
            this.upVector = upVector;
            generateViewMarix();
        }

        public Vector LookAt(Vector vector)
        {
            return (Vector)(viewMatrix * vector);
        }

        private void generateViewMarix()
        {
            Vector<double> zAxis = (cameraPosition - cameraTarget).Normalize(2);
            Vector<double> xAxis = VectorExtender.Cross(upVector, (Vector)zAxis).Normalize(2);
            Vector<double> yAxis = VectorExtender.Cross((Vector)zAxis, (Vector)xAxis);

            viewMatrix =
                (Matrix)DenseMatrix.OfColumnVectors(new Vector<double>[] { xAxis, yAxis, zAxis, cameraPosition })
                .InsertRow(3, DenseVector.OfArray(new double[] { 0, 0, 0, 1 }));
            viewMatrix = (Matrix)viewMatrix.Inverse();
        }
    }
}