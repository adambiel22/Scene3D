using Algebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scene3D
{
    public class PointLight : Light
    {
        public Vector Position { get; set; }
        
        public override (Vector, (double r, double g, double b))
            ComputeToLightVector(Vector point)
        {
            return (Position - point, Color);
        }

        public PointLight(Color color,
            double x, double y, double z,
            bool enabled = true, string name = "") : base(color, enabled, name)
        {
            Position = new Vector(x, y, z, 1);
        }
    }
}
