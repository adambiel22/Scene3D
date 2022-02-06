using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki
{
    public class Render
    {
        public Scene Scene { get; set; }
        public TriangleDrawer TriangleDrawer { get; set; } 
        public PixelShader PixelShader { get; set; }

        private int counter;

        public Render()
        {
            this.counter = 0;
        }

        public Bitmap RenderScene(int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            BitmapManager bitmapManager = new LockBitmapManager();
            bitmapManager.StartDrawing(bitmap);
            
            ZBuffor zBuffor = new ZBuffor(width, height);
            PixelShader.Lights = Scene.Lights;
            PixelShader.ZBuffor = zBuffor;
            PixelShader.SetPixel = bitmapManager.SetPixel;
            PixelShader.Camera = Scene.CurrentCamera;
            //Debug.WriteLine($"Rendering no: {++counter}");
            foreach(TransformatedBlock transformatedBlock in Scene.TransformatedBlocks)
            {
                PixelShader.Surface = transformatedBlock.Surface;
                // przenieść transformację całego bloku tutaj
                Vertex[] verticiesInWorld =
                    transformatedBlock
                    .Transformation
                    .TransformVerticies(transformatedBlock.Verticies);
                //Vertex[] projectedVerticies =
                //    Scene.CurrentCamera.ProjectVericies(verticiesInWorld);
                foreach ((int, int, int) triangle in transformatedBlock.Triangles) 
                {
                    Triangle triangleInWorld =
                        new Triangle(
                            verticiesInWorld[triangle.Item1],
                            verticiesInWorld[triangle.Item2],
                            verticiesInWorld[triangle.Item3]);
                    Triangle projectedTriangle =
                        projectTriangle(triangleInWorld, Scene.CurrentCamera, Scene.CurrentCamera.Projection);
                        //new Triangle(
                        //    projectedVerticies[triangle.Item1],
                        //    projectedVerticies[triangle.Item2],
                        //    projectedVerticies[triangle.Item3]);
                    if (isTriangleFrontedToCamera(projectedTriangle, Scene.CurrentCamera) && isTriangleInCube(projectedTriangle))
                    {
                        PixelShader.SetTriangleInWorld(triangleInWorld);
                        stretchTriangle(projectedTriangle, width, height);
                        PixelShader.ProjectedTriangle = projectedTriangle;
                        TriangleDrawer.DrawTriangle(projectedTriangle, PixelShader.ShadePixel,
                            (x, y) => bitmapManager.SetPixel(x, y, Color.Black));
                    }
                }
            }
            bitmapManager.EndDrawing();
            return bitmap;
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
                vertex.PositionVector[1] = (int)(height * ((-vertex.PositionVector[1] + 1) / 2));
            }
        }

        private bool isTriangleInCube(Triangle triangle)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (triangle.Verticies[i].PositionVector[j] >= 1
                        || triangle.Verticies[i].PositionVector[j] <= -1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool isTriangleFrontedToCamera(Triangle triangle, Camera camera)
        {
            return triangle.GetNormalVector() * camera.UpVector > 0;
        }
    }
}
