using System;
using MathNet.Numerics.LinearAlgebra;

namespace Algebra
{
    public class Matrix
    {
        double[,] matrixArray;
        public Matrix(double[,] array)
        {
            if (array.GetLength(1) != array.GetLength(2) || array.GetLength(1) > 4 || array.GetLength(1) == 0)
            {
                throw new ArgumentException();
            }
            matrixArray = array;
        }

        public Matrix(Vector[] array)
        {
            matrixArray = new double[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    matrixArray[i, j] = array[j][i];
                }
            }
        }

        public Matrix()
        {
            matrixArray = new double[4, 4];
        }

        public double this[int index1, int intex2]
        {
            get { return matrixArray[index1, intex2]; }
            set { matrixArray[index1, intex2] = value; }
        }

        private Matrix(Matrix matrix)
        {
            this.matrixArray = matrix.matrixArray;
        }

        public Matrix Inverse()
        {
            Matrix<double> matrix1 = CreateMatrix.DenseOfArray(matrixArray);
            return new Matrix(matrix1.Inverse().ToArray());
        }

        public static Vector operator *(Matrix M, Vector v)
        {
            return new Vector(new double[]
            {
                M[0,0] * v[0] + M[0,1] * v[1] + M[0,2] * v[2] + M[0,3] * v[3],
                M[1,0] * v[0] + M[1,1] * v[1] + M[1,2] * v[2] + M[1,3] * v[3],
                M[2,0] * v[0] + M[2,1] * v[1] + M[2,2] * v[2] + M[2,3] * v[3],
                M[3,0] * v[0] + M[3,1] * v[1] + M[3,2] * v[2] + M[3,3] * v[3]
            });
        }
        public static Matrix operator *(Matrix A, Matrix B)
        {
            Matrix C = new Matrix();
            for (int i = 0; i < 4; i++) 
            {
                for (int j = 0; j < 4; j++)
                {
                    C[i, j] = 0;
                    for (int k = 0; k < 4; k++)
                    {
                        C[i, j] += A[i, k] * B[k, j];
                    }
                }
            }
            return C;
        }
    }
}
