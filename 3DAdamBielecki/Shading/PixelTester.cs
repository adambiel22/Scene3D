using MathNet.Numerics.LinearAlgebra.Double;

namespace _3DAdamBielecki.Shading
{
    public abstract class PixelTester
    {
        public abstract bool isPixelToDraw(Vector pixelPosition);
    }
}