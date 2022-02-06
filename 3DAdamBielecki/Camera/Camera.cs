﻿using System;
using System.Diagnostics;
using Algebra;

namespace _3DAdamBielecki
{
    public class Camera
    {
        public Matrix viewMatrix;
        private Vector cameraPosition;
        private Vector cameraTarget;
        private Vector upVector;
        public Vector CameraPosition { get => cameraPosition; set { cameraPosition = value; GenerateViewMarix(); } }
        public Vector CameraTarget { get => cameraTarget; set { cameraTarget = value; GenerateViewMarix(); } }
        public Vector UpVector { get => upVector; set { upVector = value; GenerateViewMarix(); } }
        public Projection Projection { get; set; }

        public Camera(Vector cameraPosition, Vector cameraTarget, Vector upVector, Projection projection)
        {
            this.cameraPosition = cameraPosition;
            this.cameraTarget = cameraTarget;
            this.upVector = upVector;
            Projection = projection;
            GenerateViewMarix();
        }

        public Vector LookAt(Vector vector)
        {
            return viewMatrix * vector;
        }

        public void GenerateViewMarix()
        {
            Vector zAxis = (cameraPosition - cameraTarget);
            zAxis.Normalize();
            Vector xAxis = Vector.Cross(upVector, zAxis);
            zAxis.Normalize();
            Vector yAxis = Vector.Cross(zAxis, xAxis);

            viewMatrix = new Matrix(new Vector[] { xAxis, yAxis, zAxis, cameraPosition });
            viewMatrix = viewMatrix.Inverse();
        }
    }
}