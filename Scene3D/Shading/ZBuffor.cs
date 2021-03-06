using System;

namespace Scene3D
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
            
            if (x >= 0 && x <= zArray.GetLength(0) - 1
                && y >= 0 && y <= zArray.GetLength(1) - 1
                && Math.Log(z + 1) <= Math.Log(zArray[x, y])) 
            {
                zArray[x, y] = z + 1;
                return true;
            }
            return false;
        }
    }
}