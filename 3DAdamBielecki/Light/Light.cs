using System.Drawing;
using Algebra;

namespace _3DAdamBielecki
{
    public abstract class Light
    {
        public string Name { get; set; }
        protected (double r, double g, double b) Color { get; set; }
        public bool Enabled { get; set; }

        public abstract (Vector, (double r, double g, double b)) 
            ComputeToLightVector(Vector point);
        public Light(Color color, bool enabled = true, string name = "")
        {
            Color = (color.R / 255.0, color.G / 255.0, color.B / 255.0);
            Name = name;
            Enabled = enabled;
        }
    }
}