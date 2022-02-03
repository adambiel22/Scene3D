﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki.Shading
{
    class MockedPixelShader : PixelShader
    {
        protected override Color computeColor(double alfa, double beta, double gamma)
        {
            return Surface.Color;
        }
    }
}
