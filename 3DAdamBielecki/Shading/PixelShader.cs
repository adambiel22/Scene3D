using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;


namespace _3DAdamBielecki
{
    public abstract class PixelShader
    {
        public IEnumerable<Light> Lights { get; set; }
        public ZBuffor ZBuffor { get; set; }
        public Action<int, int, Color> SetPixel { get; set; }
        public Camera Camera { get; set; }
        public Triangle ProjectedTriangle { get; set; }
        public Surface Surface { get; set; }
        public Fogg Fogg { get; set; }

        protected PixelShader()
        {
            Fogg = new Fogg(Color.White, 0.8, 0.9, false);
        }

        public abstract void SetTriangleInWorld(Triangle triangle);

        public void ShadePixel(int pixelX, int pixelY)
        {
            var (alpha, beta, gamma) = 
                BarycentricCoordinates.CartesianToBarycentric(ProjectedTriangle, pixelX, pixelY);


            var point =
                BarycentricCoordinates.BarycentricToEuclidean(ProjectedTriangle, alpha, beta, gamma);


            double foggEffect = Fogg.ComputeFogg(point.z);
            if (foggEffect == 1.0 || !ZBuffor.isPixelToDraw(pixelX, pixelY, point.z))
            {
                return;
            }
            Color color = Fogg.ComputeColor(
                computeColor(alpha, beta, gamma),
                foggEffect);
            SetPixel(pixelX, pixelY, color);
        }

        protected abstract Color computeColor(double alfa, double beta, double gamma);
    }
}
