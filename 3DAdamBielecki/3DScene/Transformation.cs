using System;
using Algebra;
namespace _3DAdamBielecki._3DScene
{
    public class Transformation
    {
        private Matrix transformationMatrix;
        private Matrix inversedTransposedTransformationMatrix;
        
        public Transformation()
        {
            transformationMatrix = Matrix.CreateIdentity();
            inversedTransposedTransformationMatrix = transformationMatrix.Inverse().Transpose();
        }

        public void AddTransformation(Matrix matrix)
        {
            transformationMatrix = (transformationMatrix * matrix);
            inversedTransposedTransformationMatrix = transformationMatrix.Inverse().Transpose();
        }

        public void SetTransformation(Matrix matrix)
        {
            transformationMatrix = matrix;
            inversedTransposedTransformationMatrix = (Matrix)transformationMatrix.Inverse().Transpose();

        }

        public Triangle Transform(Triangle triangle)
        {
            return triangle;
        }

        public Vector TransformPoint(Vector positionVector)
        {
            return transformationMatrix * positionVector;
        }

        public Vector TransformNormalVector(Vector normalVector)
        {
            return inversedTransposedTransformationMatrix * normalVector;
        }
    }
}
