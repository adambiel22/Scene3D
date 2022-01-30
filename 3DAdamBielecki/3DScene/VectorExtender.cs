using System;

namespace _3DAdamBielecki._3DScene
{
    using DLA = MathNet.Numerics.LinearAlgebra.Double;

    public static class VectorExtender
    {
        public static DLA.Vector Cross(DLA.Vector left, DLA.Vector right)
        {
            if ((left.Count != 3 || right.Count != 3))
            {
                string message = "Vectors must have a length of 3.";
                throw new Exception(message);
            }
            DLA.Vector result = new DLA.DenseVector(3);
            result[0] = left[1] * right[2] - left[2] * right[1];
            result[1] = -left[0] * right[2] + left[2] * right[0];
            result[2] = left[0] * right[1] - left[1] * right[0];

            return result;
        }
    }
}
