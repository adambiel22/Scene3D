using System.Drawing;

namespace _3DAdamBielecki.Shading
{
    public class Surface
    {
        public double diffuseConst { get; set; }
        public double specularConst { get; set; }
        public double ambientConst { get; set; }
        public (double, double, double) Color { get; set; }
    }
}