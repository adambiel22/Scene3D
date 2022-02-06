﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;


namespace _3DAdamBielecki
{
    public abstract class PixelShader
    {
        public IEnumerable<Light> Lights { get; set; }
        public ZBuffor ZBuffor { get; set; }
        public Action<int, int, Color> SetPixel { get; set; }
        public Camera Camera { get; set; }
        public Triangle ProjectedTriangle { get; set; }
        public Surface Surface { get; set; }

        public abstract void SetTriangleInWorld(Triangle triangle);

        public void ShadePixel(int pixelX, int pixelY)
        {
            if (pixelX == 842 && pixelY == 536)
            {
                Debug.WriteLine("fasd");
            }
            var (alpha, beta, gamma) = 
                BarycentricCoordinates.CartesianToBarycentric(ProjectedTriangle, pixelX, pixelY);


            var point =
                BarycentricCoordinates.BarycentricToEuclidean(ProjectedTriangle, alpha, beta, gamma);

            //porady ogólne:
            //wektor normaln do trjkąta można obliczyć jako średnią arytmetyczną wektorów normalnych z wierzchołków
            //jak mnożymy wektory normalne przez macierz to ostatnia współrzędna to 0;

            if (!ZBuffor.isPixelToDraw(pixelX, pixelY, point.z))
            {
                return;
            }
            Color color = computeColor(alpha, beta, gamma);
            SetPixel(pixelX, pixelY, color);
        }

        protected abstract Color computeColor(double alfa, double beta, double gamma);

        //aby narysować trójkąt potrzebujemy:
        //- trójkąta: wierzchołki, wektory normalne, itd
        //- materiału: stałe do phonga i kolor
        //- źródeł światła
        //- metody do stawiania pixela o zadanym kolorze.
        //- zBuffer jako sprawdzacz Czy w ogóle liczyć pixel
        //- metodę/obiekt do rasteryzacji/rysowania trójkąta.
        //      - Do tej metody trzeba dostarczyć funkcję do stawiania pixela bez koloru
        //
    }
}
