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
                new RectangleFace(100, 100, 5),
                new Transformation(new double[,]
                {
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 },
                }),
                new Surface(1, 0.1, 0.2, 2, Color.Gray)
                );

            TransformatedBlock sphere = new TransformatedBlock(
                new Sphere(3, 2.5),
                new Transformation(new double[,]
                {
                    { 1, 0, 0, 50 },
                    { 0, 1, 0, 50 },
                    { 0, 0, 1, 2.5 },
                    { 0, 0, 0, 1 },
                }),
                new Surface(1, 1, 0.2, 10, Color.Red)
                );

            TransformatedBlock pyramid1 = new TransformatedBlock(
                new Pyramid(2.5, 2.5, 2.5),
                new Transformation(new double[,]
                {
                    { 1, 0, 0, 10 },
                    { 0, 1, 0, 50 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 },
                }),
                new Surface(1, 1, 0.2, 10, Color.Coral)
                );

            TransformatedBlock pyramid2 = new TransformatedBlock(
                new Pyramid(2.5, 2.5, 2.5),
                new Transformation(new double[,]
                {
                    { 1, 0, 0, 20 },
                    { 0, 1, 0, 60 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 },
                }),
                new Surface(1, 1, 0.2, 10, Color.CornflowerBlue)
                );

            TransformatedBlock pyramid3 = new TransformatedBlock(
                new Pyramid(2.5, 2.5, 2.5),
                new Transformation(new double[,]
                {
                    { 1, 0, 0, 30 },
                    { 0, 1, 0, 70 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 },
                }),
                new Surface(1, 1, 0.2, 10, Color.Azure)
                );


            TransformatedBlocks.Add(floor);
            TransformatedBlocks.Add(sphere);
            TransformatedBlocks.Add(pyramid1);
            TransformatedBlocks.Add(pyramid2);
            TransformatedBlocks.Add(pyramid3);

            definePhillars();
        }

        private void definePhillars()
        {
            double h = 50 * Math.Sqrt(3) / 2.0;
            TransformatedBlock phillar1 = new TransformatedBlock(
                new Cuboid(4.0, 4.0, 30.0),
                new Transformation(new double[,]
                {
                                { 1, 0, 0, 25 },
                                { 0, 1, 0,  (100-h)/2},
                                { 0, 0, 1, 0 },
                                { 0, 0, 0, 1 },
                }),
                new Surface(1, 0, 0.2, 10, Color.BurlyWood)
            ) ;
            TransformatedBlock phillar2 = new TransformatedBlock(
                new Cuboid(4.0, 4.0, 30.0),
                new Transformation(new double[,]
                {
                                { 1, 0, 0, 50 },
                                { 0, 1, 0, 100 - (100-h)/2 },
                                { 0, 0, 1, 0 },
                                { 0, 0, 0, 1 },
                }),
                new Surface(1, 0, 0.2, 10, Color.BurlyWood)
            );
            TransformatedBlock phillar3 = new TransformatedBlock(
                new Cuboid(4.0, 4.0, 30.0),
                new Transformation(new double[,]
                {
                                { 1, 0, 0, 75 },
                                { 0, 1, 0, (100-h)/2 },
                                { 0, 0, 1, 0 },
                                { 0, 0, 0, 1 },
                }),
                new Surface(1, 0, 0.2, 10, Color.BurlyWood)
            );

            TransformatedBlocks.Add(phillar1);
            TransformatedBlocks.Add(phillar2);
            TransformatedBlocks.Add(phillar3);

        }
    }
}
