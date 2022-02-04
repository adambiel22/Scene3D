using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _3DAdamBielecki
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Vector v1 = DenseVector.OfArray(new double[] { 1, 1, 1 });
            Vector v0 = DenseVector.OfArray(new double[] { 1, 1, 1, 1 });
            Debug.WriteLine(v1);
            Debug.WriteLine(v0);
            Debug.WriteLine(v1 - v0);
        }

    }
}
