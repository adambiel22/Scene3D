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
            Vector toCamera = Camera.CameraPosition - middle;
            toCamera.Normalize();
            (double iR, double iG, double iB) = (Surface.AmbientConst, Surface.AmbientConst, Surface.AmbientConst);
            foreach (Light light in Lights)
            {
                Vector toLight = light.ComputeToLightVector(middle);
                toLight.Normalize();
                Vector mirrorReflectance = normalVector * (2 * (normalVector * toLight)) - toLight;
                double diffuse = Surface.DiffuseConst * (normalVector * toLight);
                double specular = Surface.SpecularConst * Math.Pow(toCamera * mirrorReflectance, Surface.NShiny);
                iR += light.Color.r * (diffuse + specular);
                iG += light.Color.g * (diffuse + specular);
                iB += light.Color.b * (diffuse + specular);
            }

            //Czy trzeba dodać też Max 0? Będzie tak jak iR lub iG lub iB wyjdzie ujemne. Kiedy tak może być??
            byte R = (byte)Math.Min(Surface.Color.R * iR, 255.0);
            byte G = (byte)Math.Min(Surface.Color.G * iG, 255.0);
            byte B = (byte)Math.Min(Surface.Color.B * iB, 255.0);

            colorForTriangle = Color.FromArgb(255, R, G, B);
        }
    }
}
