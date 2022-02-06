using Algebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki
{
    public class PyramidScene : Scene
    {
        public PyramidScene(int width, int height) : base()
        {
            Lights.Add(new PointLight(Color.White, 100, 100, 100));
            Vector cameraPosition = new Vector(300, 50, 50, 1);
            Cameras.Add(new Camera(
                cameraPosition,
                new Vector(50, 50, 0, 1),
                new Vector(0, 0, 1, 0)));
            SetCurrentCamera(0);

            Projection = new Projection(Math.PI / 4, 400, 50, (double)height / width);

            TransformatedBlock floor = new TransformatedBlock(
                new RectangleFace(100, 100, 10),
                new Transformation(new double[,]
                {
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 },
                }),
                new Surface(1, 1, 0.2, 10, Color.Azure)
                );
            TransformatedBlock pyramid = new TransformatedBlock(
                new Pyramid(20, 20, 20),
                new Transformation(new double[,]
                {
                    { 1, 0, 0, 50 },
                    { 0, 1, 0, 50 },
                    { 0, 0, 1, 5 },
                    { 0, 0, 0, 1 },
                }),
                new Surface(1, 1, 0.2, 10, Color.Red)
                );

            TransformatedBlocks.Add(floor);
            TransformatedBlocks.Add(pyramid);
        }
    }
}
