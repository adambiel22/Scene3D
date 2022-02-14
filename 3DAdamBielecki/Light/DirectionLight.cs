using Algebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki
{
    public class DirectionLight : Light
    {
        public Vector Direction { get; set; }
        public DirectionLight(Vector direction, Color color, bool enabled = true, string name = "") : base(color, enabled, name)
        {
            Direction = direction;
        }

        public override (Vector, (double r, double g, double b))
            ComputeToLightVector(Vector point)
        {
            return (Direction, Color);
        }
    }
}
