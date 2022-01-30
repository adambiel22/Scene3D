using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Storage;

namespace Algebra
{
    public class Vector4D : DenseVector
    {
        //internal Vector vector;

        //public Vector4D(double[] array)
        //{
        //    vector = new D
        //}

        //public static implicit operator Vector3D(Vector4D d) => new Vector3D(new double[]{});
        public Vector4D(DenseVectorStorage<double> storage) : base(storage)
        {
        }

        public Vector4D(int length) : base(length)
        {
        }

        public Vector4D(double[] storage) : base(storage)
        {
        }
    }
}