using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki
{
    public class Fogg
    {
        public Color Color { get; set; }
        public double Near { get; set; }
        public double Far { get; set; }
        public bool Enabled { get; set; }

        public Fogg(Color color, double near, double far, bool enabled = false)
        {
            if (near > far)
            {
                throw new ArgumentException("near < far");
            }
            Color = color;
            Far = far;
            Near = near;
            Enabled = enabled;
        }

        public double ComputeFogg(double distance)
        {
            if (!Enabled || distance < Near)
            {
                return 0.0;
            }
            else if (distance > Far)
            {
                return 1.0;
            }
            else
            {
                return (distance - Near) / (Far - Near);
            }
        }

        public Color ComputeColor(Color color, double foggEffect)
        {
            return Color.FromArgb(color.A,
                (int)Math.Min(color.R * (1 - foggEffect) + Color.R * foggEffect, 255),
                (int)Math.Min(color.G * (1 - foggEffect) + Color.G * foggEffect, 255),
                (int)Math.Min(color.B * (1 - foggEffect) + Color.B * foggEffect, 255));

        }
    }
}
