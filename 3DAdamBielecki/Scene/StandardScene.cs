using Algebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki
{
    public class StandardScene : Scene
    {
        public StandardScene(int width, int height) : base()
        {
            Lights.Add(new PointLight(Color.White, 100, 100, 100));
            Vector cameraPosition = new Vector(300, 50, 50, 1);
            Camera = new Camera(
                cameraPosition,
                new Vector(50, 50, 0, 1),
                new Vector(0, 0, 1, 0));
            Projection = new Projection(Math.PI / 4, 400, 50, (double)height / width);
            //Lights.Add(new PointLight(Color.White, 3, 2, 3));

            TransformatedBlock floor = new TransformatedBlock(
                new Cuboid(100, 100, 5),
                new Transformation(new double[,]
                {
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 },
                }),
                new Surface(1, 1, 0.2, 10, Color.Azure)
                );

            TransformatedBlock sphere = new TransformatedBlock(
                new Sphere(3, 10),
                new Transformation(new double[,]
                {
                    { 1, 0, 0, 50 },
                    { 0, 1, 0, 50 },
                    { 0, 0, 1, 15 },
                    { 0, 0, 0, 1 },
                }),
                new Surface(1, 1, 0.2, 10, Color.Red)
                );

            TransformatedBlocks.Add(floor);
            TransformatedBlocks.Add(sphere);
        }
    }
}
