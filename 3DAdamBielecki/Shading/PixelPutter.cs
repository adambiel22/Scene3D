using System.Drawing;

namespace _3DAdamBielecki.Shading
{
    public abstract class PixelPutter
    {
        public abstract void PutPixel(int x, int y, Color color);
    }
}