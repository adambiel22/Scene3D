using _3DAdamBielecki._3DScene;
using Algebra;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki.Shading
{
    public static class PhongIllumination
    {
        public static Color ComputeIllumination(Vector position, Vector normalVector, Vector cameraPosition, Surface surface, IEnumerable<Light> lights)
        {
            Vector toCamera = cameraPosition - position;
            toCamera.Normalize();
            (double iR, double iG, double iB) = (surface.AmbientConst, surface.AmbientConst, surface.AmbientConst);
            foreach (Light light in lights)
            {
                Vector toLight = light.ComputeToLightVector(position);
                toLight.Normalize();
                Vector mirrorReflectance = normalVector * (2 * (normalVector * toLight)) - toLight;
                double diffuse = Math.Max(surface.DiffuseConst * (normalVector * toLight), 0);
                double specular = Math.Max(surface.SpecularConst * Math.Pow(toCamera * mirrorReflectance, surface.NShiny), 0);
                iR += light.Color.r * (diffuse + specular);
                iG += light.Color.g * (diffuse + specular);
                iB += light.Color.b * (diffuse + specular);
            }

            //Czy trzeba dodać też Max 0? Będzie tak jak iR lub iG lub iB wyjdzie ujemne. Kiedy tak może być??
            byte R = (byte)Math.Min(Math.Max(surface.Color.R * iR, 0.0), 255.0);
            byte G = (byte)Math.Min(Math.Max(surface.Color.G * iG, 0.0), 255.0);
            byte B = (byte)Math.Min(Math.Max(surface.Color.B * iB, 0.0), 255.0);



            return Color.FromArgb(255, R, G, B);
        }
    }
}
