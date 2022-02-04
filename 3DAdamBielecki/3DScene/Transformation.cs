using System;
using MathNet.Numerics.LinearAlgebra.Double;

namespace _3DAdamBielecki._3DScene
{
    public class Transformation
    {
        private Matrix transformationMatrix;
        private Matrix inversedTransposedTransformationMatrix;
        
        public Transformation()
        {
            transformationMatrix = DenseMatrix.CreateIdentity(4);
            inversedTransposedTransformationMatrix = (Matrix)transformationMatrix.Inverse().Transpose();
        }

        public void AddTransformation(Matrix matrix)
        {
            if (matrix.ColumnCount != 4 || matrix.RowCount != 4)
            {
                throw new ArgumentException("Transformation matrix should by 4x4");
            }
            transformationMatrix = (Matrix)(transformationMatrix * matrix);
            inversedTransposedTransformationMatrix = (Matrix)transformationMatrix.Inverse().Transpose();
        }

        public void SetTransformation(Matrix matrix)
        {
            if (matrix.ColumnCount != 4 || matrix.RowCount != 4)
            {
                throw new ArgumentException("Transformation matrix should by 4x4");
            }
            transformationMatrix = matrix;
            inversedTransposedTransformationMatrix = (Matrix)transformationMatrix.Inverse().Transpose();

        }

        public Triangle Transform(Triangle triangle)
        {
            return triangle;
        }

        public Vector TransformPoint(Vector positionVector)
        {
            return (Vector)(transformationMatrix * positionVector);
        }

        public Vector TransformNormalVector(Vector normalVector)
        {
            return (Vector)(inversedTransposedTransformationMatrix * normalVector);
        }
    }
}
