﻿using _3DAdamBielecki._3DScene;
using System;
using System.Drawing;

namespace _3DAdamBielecki.Shading
{
    public class TriangleDrawer
    {
        public void DrawTriangle(Triangle triangle, Action<int,int> setPixel, Action<int, int> setBorderPixel)
        {
            Point v0 = new Point(
                (int)triangle.Verticies[0].PositionVector[0],
                (int)triangle.Verticies[0].PositionVector[1]);
            Point v1 = new Point(
                (int)triangle.Verticies[1].PositionVector[0],
                (int)triangle.Verticies[1].PositionVector[1]);
            Point v2 = new Point(
                (int)triangle.Verticies[2].PositionVector[0],
                (int)triangle.Verticies[2].PositionVector[1]);
            Point[] triangleVerticies = new Point[] { v0, v1, v2 };
            PolygonDrawer.FillPolygon(triangleVerticies, setPixel);
            PolygonDrawer.DrawPolygon(triangleVerticies, setBorderPixel);

        }
    }
}