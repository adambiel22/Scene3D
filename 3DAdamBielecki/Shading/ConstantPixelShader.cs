using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3DAdamBielecki._3DScene;
using Algebra;

namespace _3DAdamBielecki.Shading
{
    public class ConstantPixelShader : PixelShader
    {
        private Color colorForTriangle;

        protected override Color computeColor(double alfa, double beta, double gamma)
        {
            return colorForTriangle;
        }

        public override void SetTriangleInWorld(Triangle triangle)
        {
            Vector normalVector = triangle.GetNormalVector();
            Vector middle = triangle.GetMiddle();

            colorForTriangle = PhongIllumination.ComputeIllumination(
                middle,
                normalVector,
                Camera.CameraPosition,
                Surface,
                Lights);
        }
    }
}
