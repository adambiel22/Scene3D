using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3DAdamBielecki._3DScene;
using MathNet.Numerics.LinearAlgebra.Double;

namespace _3DAdamBielecki.Shading
{
    public class ConstantPixelShader : PixelShader
    {
        private Color color;
        public override Triangle TriangleInWorld
        {
            get => base.TriangleInWorld;
            set { base.TriangleInWorld = value; computeConstantColor(); }
        }

        protected override Color computeColor(double alfa, double beta, double gamma)
        {
            return color;
        }

        private void computeConstantColor()
        {
            Vector normalVector = (Vector)TriangleInWorld.GetNormalVector().SubVector(0, 3);
            Vector middle = TriangleInWorld.GetMiddle();
            Vector toCamera = (Vector)(Camera.CameraPosition - middle).Normalize(2);
            foreach (Light light in Lights)
            {
                Vector toLight = (Vector)light.ComputeToLightVector(middle).SubVector(0, 3).Normalize(2);
                double diffuse = Surface.diffuseConst * normalVector.DotProduct(toLight);
                //double specular = 
            }
        }
    }
}
