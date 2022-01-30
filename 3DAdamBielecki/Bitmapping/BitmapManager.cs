using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki.Bitmapping
{
    public abstract class BitmapManager : IPixelSetter
    {
        public abstract void SetPixel(int x, int y, Color color);
        public abstract Color GetPixel(int x, int y);
        public abstract void StartDrawing(Bitmap managedBitmap);
        public abstract void EndDrawing();
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
