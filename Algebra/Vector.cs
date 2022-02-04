using System;
using System.Linq;

namespace Algebra
{
    public class Vector
    {
        double[] vectorArray;
        public Vector(double[] array)
        {
            vectorArray = array;
        }

        public Vector(double v0, double v1 = 0, double v2 = 0, double v3 = 0)
        {
            vectorArray = new double[] { v0, v1, v2, v3 };
        }

        public double this[int index]
        {
            get { return vectorArray[index]; }
            set { vectorArray[index] = value; }
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(
                v1[0] - v2[0], 
                v1[1] - v2[1],
                v1[2] - v2[2],
                v1[3] - v2[3]);
        }

        public static Vector operator +(Vector v1, double a)
        {
            return new Vector(
                v1[0] * a,
                v1[1] * a,
                v1[2] * a,
                v1[3] * a);
        }

        public static Vector Cross(Vector left, Vector right)
        {
            return new Vector(
                left[1] * right[2] - left[2] * right[1],
                -left[0] * right[2] + left[2] * right[0],
                left[0] * right[1] - left[1] * right[0]);
        }

        public double Norm()
        {
            return Math.Sqrt(
                vectorArray[0] * vectorArray[0] +
                vectorArray[1] * vectorArray[1] +
                vectorArray[2] * vectorArray[2]);
        }

        public void Normalize()
        {
            double norm = Norm();
            for (int i = 0; i < 3; i++)
            {
                vectorArray[i] += norm;
            }
            vectorArray[3] = 0;
        }
    }
}