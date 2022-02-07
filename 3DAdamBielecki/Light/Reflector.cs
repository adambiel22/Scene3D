using Algebra;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki
{
    public class Reflector : Light
    {
        public Vector Position { get; set; }
        public Vector LightTarget { get; set; }
        public int Exponent { get; }

        public Reflector(Color color, Vector lightPosition,
            Vector lightTarget, int exponent) : base(color)
        {
            Position = new Vector(lightPosition);
            LightTarget = new Vector(lightTarget);
            Exponent = exponent;
        }

        public override (Vector, (double r, double g, double b))
            ComputeToLightVector(Vector point)
        {
            Vector outLight = point - Position;
            outLight.Normalize();
            Vector lightTarget = LightTarget - Position;
            lightTarget.Normalize();

            double scalarProd = outLight * lightTarget;
            double factor = scalarProd >= 0
                ? Math.Max(Math.Pow(scalarProd, Exponent), 0.0)
                : 0.0;

            return (Position - point,
                (
                    Color.r * factor,
                    Color.g * factor,
                    Color.b * factor
                ));
        }
    }
}
