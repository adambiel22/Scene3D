using System.Drawing;
using Algebra;

namespace _3DAdamBielecki._3DScene
{
    public abstract class Light
    {
        public (double r, double g, double b) Color { get; set; }
        public abstract Vector ComputeToLightVector(Vector point);
        public Light(Color color)
        {
            Color = (color.R / 255.0, color.G / 255.0, color.B / 255.0);
        }
    }
}