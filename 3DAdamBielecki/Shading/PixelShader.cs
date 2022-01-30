using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki.Shading
{
    public abstract class PixelShader
    {
        public Light[] Lights { get; set; }
        public PixelTester PixelTester { get; set; }
        public Action<int, int, Color> SetPixel { get; set; }
        public Triangle Triangle { get; set; }
        public Material Material { get; set; }

        public void ShadePixel(int x, int y)
        {
            Vector pixelPosition = computePixelPosition(x, y);  
            if (!PixelTester.isPixelToDraw(pixelPosition))
            {
                return;
            }
            Color color = computeColor(pixelPosition);
            SetPixel((int)pixelPosition[0], (int)pixelPosition[2], color);
        }

        protected abstract Color computeColor(Vector pixelPosition);

        private Vector computePixelPosition(int x, int y)
        {
            throw new NotImplementedException();
        }
        //aby narysować trójkąt potrzebujemy:
        //- trójkąta: wierzchołki, wektory normalne, itd
        //- materiału: stałe do phonga i kolor
        //- źródeł światła
        //- metody do stawiania pixela o zadanym kolorze.
        //- zBuffer jako sprawdzacz Czy w ogóle liczyć pixel
        //- metodę/obiekt do rasteryzacji/rysowania trójkąta.
        //      - Do tej metody trzeba dostarczyć funkcję do stawiania pixela bez koloru
    }
}
