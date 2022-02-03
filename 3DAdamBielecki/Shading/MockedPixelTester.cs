using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki.Shading
{
    class MockedPixelTester : PixelTester
    {
        public override bool isPixelToDraw(int x, int y, double z)
        {
            return true;
        }
    }
}
