using MathNet.Numerics.LinearAlgebra.Double;
using System.Drawing;

namespace _3DAdamBielecki._3DScene
{
    public abstract class Light
    {
        public (double r, double g, double b) Color { get; set; }
        public abstract Vector ComputeToLightVector(Vector point);
    }
}