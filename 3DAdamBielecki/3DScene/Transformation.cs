using System;
using MathNet.Numerics.LinearAlgebra.Double;

namespace _3DAdamBielecki._3DScene
{
    public class Transformation
    {
        private Matrix transformationMatrix;
        
        public Transformation()
        {
            transformationMatrix = DenseMatrix.CreateIdentity(4);
        }

        public void AddTransformation(Matrix matrix)
        {
            transformationMatrix = (Matrix)(transformationMatrix * matrix);
        }

        public void SetTransformation(Matrix matrix)
        {
            if (matrix.ColumnCount != 4 || matrix.RowCount != 4)
            {
                throw new ArgumentException("Transformation matrix should by 4x4");
            }
            transformationMatrix = matrix;
        }

        public Triangle Transform(Triangle triangle)
        {
            return triangle;
        }

        public Vector Transform(Vector vector)
        {
            return (Vector)(transformationMatrix * vector);
        }
    }
}
