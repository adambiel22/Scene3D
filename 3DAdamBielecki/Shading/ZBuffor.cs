using System;

namespace _3DAdamBielecki.Shading
{
    public class ZBuffor
    {
        private double[,] zArray;
        public ZBuffor(int width, int height)
        {
            zArray = new double[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    zArray[i, j] = double.MaxValue;
                }
            }
        }

        public bool isPixelToDraw(int x, int y, double z)
        {
            if (Math.Log(z) <= Math.Log(zArray[x, y])) 
            {
                zArray[x, y] = z;
                return true;
            }
            return false;
        }
    }
}