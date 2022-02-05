using _3DAdamBielecki._3DScene;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki.Shading
{
    public class GourandPixelShader : PixelShader
    {
        private Color v0Color;
        private Color v1Color;
        private Color v2Color;
        public override void SetTriangleInWorld(Triangle triangle)
        {
            v0Color = PhongIllumination.ComputeIllumination(
                triangle.Verticies[0].PositionVector,
                triangle.Verticies[0].NormalVector,
                Camera.CameraPosition,
                Surface,
                Lights);

            v1Color = PhongIllumination.ComputeIllumination(
                triangle.Verticies[1].PositionVector,
                triangle.Verticies[1].NormalVector,
                Camera.CameraPosition,
                Surface,
                Lights);

            v2Color = PhongIllumination.ComputeIllumination(
                triangle.Verticies[2].PositionVector,
                triangle.Verticies[2].NormalVector,
                Camera.CameraPosition,
                Surface,
                Lights);
        }

        protected override Color computeColor(double alfa, double beta, double gamma)
        {
            //return Color.FromArgb(
            //    (byte)Math.Min(Math.Max(v0Color.A * alfa + v1Color.A * beta + v2Color.A * gamma, 0.0), 255.0),
            //    (byte)Math.Min(Math.Max(v0Color.R * alfa + v1Color.R * beta + v2Color.R * gamma, 0.0), 255.0),
            //    (byte)Math.Min(Math.Max(v0Color.G * alfa + v1Color.G * beta + v2Color.G * gamma, 0.0), 255.0),
            //    (byte)Math.Min(Math.Max(v0Color.B * alfa + v1Color.B * beta + v2Color.B * gamma, 0.0), 255.0)
            //    );
            return Color.FromArgb(
                (byte)(v0Color.A * alfa + v1Color.A * beta + v2Color.A * gamma),
                (byte)(v0Color.R * alfa + v1Color.R * beta + v2Color.R * gamma),
                (byte)(v0Color.G * alfa + v1Color.G * beta + v2Color.G * gamma),
                (byte)(v0Color.B * alfa + v1Color.B * beta + v2Color.B * gamma)
                );
        }
    }
}
