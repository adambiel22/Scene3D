using Algebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki._3DScene
{
    public class PointLight : Light
    {
        public Vector Position { get; set; }
        public override Vector ComputeToLightVector(Vector point)
        {
            return Position - point;
        }
        public PointLight(Color color, double x, double y, double z) : base(color)
        {
            Position = new Vector(x, y, z, 1);
        }
    }
}
