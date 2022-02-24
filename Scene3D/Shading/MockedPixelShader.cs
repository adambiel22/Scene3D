using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scene3D
{
    class MockedPixelShader : PixelShader
    {
        public override void SetTriangleInWorld(Triangle triangle)
        {
            return;
        }

        protected override Color computeColor(double alfa, double beta, double gamma)
        {
            return Surface.Color;
        }
    }
}
