using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scene3D
{
    class LockBitmapManager : BitmapManager
    {
        private BitmapLocker bitmapLocker;
        public override void EndDrawing()
        {
            bitmapLocker.UnlockBits();
        }

        public override Color GetPixel(int x, int y)
        {
            return bitmapLocker.GetPixel(x, y);
        }

        public override void SetPixel(int x, int y, Color color)
        {
            bitmapLocker.SetPixel(x, y, color);
        }

        public override void StartDrawing(Bitmap managedBitmap)
        {
            bitmapLocker = new BitmapLocker(managedBitmap);
        }
    }
}
