using System;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Storage;

namespace Algebra
{
    public class Matrix4D : DenseMatrix
    {
        //internal Matrix matrix;

        //public Matrix4D(double[,] array)
        //{
        //    if (array.GetLength(1) != array.GetLength(2) || array.GetLength(1) > 4 || array.GetLength(1) == 0 )
        //    {
        //        throw new ArgumentException();
        //    }
        //    matrix = DenseMatrix.OfArray(array);
        //}
        //private Matrix4D(Matrix matrix)
        //{
        //    this.matrix = matrix;
        //}

        //public Matrix4D Inverse()
        //{
        //    return new Matrix4D((Matrix)matrix.Inverse());
        //}

        //public static Vector4D operator *(Matrix4D a, Vector4D b)
        //    => new Vector4D();
        public Matrix4D(DenseColumnMajorMatrixStorage<double> storage) : base(storage)
        {
        }

        public Matrix4D(int order) : base(order)
        {
        }

        public Matrix4D(int rows, int columns) : base(rows, columns)
        {
        }

        public Matrix4D(int rows, int columns, double[] storage) : base(rows, columns, storage)
        {
        }
    }
}
