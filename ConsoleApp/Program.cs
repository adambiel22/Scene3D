using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Diagnostics;


namespace _3DAdamBielecki
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Vector v1 = DenseVector.OfArray(new double[] { Math.Sqrt(2) / 2, Math.Sqrt(2) / 2 });
            Console.WriteLine(Math.Sqrt(v1[0]*v1[0] + v1[1] * v1[1]));
        }

    }
}
