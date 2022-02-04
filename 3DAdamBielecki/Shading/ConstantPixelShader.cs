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
            Vector normalVector = TriangleInWorld.GetNormalVector();
            Vector middle = TriangleInWorld.GetMiddle();
            Vector toCamera = Camera.CameraPosition - middle;
            toCamera.Normalize();
            foreach (Light light in Lights)
            {
                Vector toLight = light.ComputeToLightVector(middle);
                toLight.Normalize();
                double diffuse = Surface.diffuseConst * (normalVector * toLight);
                //double specular = 
            }
        }
    }
}
