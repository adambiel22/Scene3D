using _3DAdamBielecki.Bitmapping;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki.Shading
{
    public class Shader
    {
        Scene Scene { get; set; }
        TriangleDrawer TriangleDrawer { get; set; } 
        PixelShader PixelShader { get; set; } 
        PixelTester PixelTester { get; set; }

        private BitmapManager bitmapManager;

        Bitmap DoShading(int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            bitmapManager.StartDrawing(bitmap);
            //inizjalizacja Z-buffora
            PixelShader.Lights = Scene.Lights;
            PixelShader.PixelTester = PixelTester;
            PixelShader.SetPixel = bitmapManager.SetPixel;
            foreach(TransformatedBlock transformatedBlock in Scene.TransformatedBlocks)
            {
                PixelShader.Material = transformatedBlock.Material;
                foreach(Triangle triangle in transformatedBlock.Triangles)
                {
                    Triangle projectedTriangle = Scene.Projection.Project(
                        Scene.Camera.LookAt(
                        transformatedBlock.Transformation.Transform(triangle)));
                    //sprawdzenie czy trójkąt nie wychodzi poza obszar i czy jest zwrócony przodem do kamery
                    PixelShader.Triangle = projectedTriangle;
                    TriangleDrawer.DrawTriangle(projectedTriangle, PixelShader.ShadePixel);
                }
            }
            bitmapManager.EndDrawing();
            return bitmap;
        }
    }
}
