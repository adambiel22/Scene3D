using _3DAdamBielecki._3DScene;
using _3DAdamBielecki.Bitmapping;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki.Shading
{
    public class Render
    {
        public Scene Scene { get; set; }
        public TriangleDrawer TriangleDrawer { get; set; } 
        public PixelShader PixelShader { get; set; } 
        public PixelTester PixelTester { get; set; }

        public Bitmap RenderScene(int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            BitmapManager bitmapManager = new LockBitmapManager();
            bitmapManager.StartDrawing(bitmap);

            //TODO: inizjalizacja PixelTestera czyli Z-buffora
            PixelShader.Lights = Scene.Lights;
            PixelShader.PixelTester = PixelTester;
            PixelShader.SetPixel = bitmapManager.SetPixel;
            foreach(TransformatedBlock transformatedBlock in Scene.TransformatedBlocks)
            {
                PixelShader.Surface = transformatedBlock.Surface;
                foreach(Triangle triangle in transformatedBlock.Triangles)
                {
                    Triangle triangleInWorld = transformTriangle(triangle, transformatedBlock.Transformation);
                    Triangle projectedTriangle = projectTriangle(triangleInWorld, Scene.Camera, Scene.Projection);
                    //TODO: sprawdzenie czy trójkąt nie wychodzi poza obszar i czy jest zwrócony przodem do kamery
                    PixelShader.TriangleInWorld = triangleInWorld;
                    stretchTriangle(projectedTriangle, width, height);
                    PixelShader.ProjectedTriangle = projectedTriangle;
                    TriangleDrawer.DrawTriangle(projectedTriangle, PixelShader.ShadePixel,
                        (x, y) => bitmapManager.SetPixel(x, y, Color.Black));
                }
            }
            bitmapManager.EndDrawing();
            return bitmap;
        }

        private Triangle transformTriangle(Triangle triangle, Transformation transformation)
        {
            Vertex[] verticiesInWorld = new Vertex[3];
            for (int i = 0; i < 3; i++)
            {
                verticiesInWorld[i] = new Vertex(
                    transformation.TransformPoint(triangle.Verticies[i].PositionVector),
                    transformation.TransformNormalVector(triangle.Verticies[i].NormalVector));
            }
            return new Triangle(verticiesInWorld[0], verticiesInWorld[1], verticiesInWorld[2]);
        }

        private Triangle projectTriangle(Triangle triangle, Camera camera, Projection projection)
        {
            Vertex[] projectedVerticies = new Vertex[3];
            for (int i = 0; i < 3; i++)
            {
                projectedVerticies[i] = new Vertex(
                    projection.Project(
                        camera.LookAt(triangle.Verticies[i].PositionVector)));
            }
            return new Triangle(projectedVerticies[0], projectedVerticies[1], projectedVerticies[2]);
        }

        private void stretchTriangle(Triangle triangle, int width, int height)
        {
            foreach(Vertex vertex in triangle.Verticies)
            {
                vertex.PositionVector[0] = (int)(width * ((vertex.PositionVector[0] + 1) / 2));
                vertex.PositionVector[1] = (int)(height * ((vertex.PositionVector[1] + 1) / 2));
            }
        }
    }
}
