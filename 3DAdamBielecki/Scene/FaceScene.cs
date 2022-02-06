using Algebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki
{
    public class FaceScene : Scene
    {
        public FaceScene(int width, int height) : base()
        {
            Lights.Add(new PointLight(Color.White, 100, 100, 100));
            Vector cameraPosition = new Vector(300, 50, 50, 1);
            Cameras.Add(new Camera(
                cameraPosition,
                new Vector(50, 50, 0, 1),
                new Vector(0, 0, 1, 0),
                new Projection(Math.PI / 4, 400, 50, (double)height / width)));
            SetCurrentCamera(0);

            TransformatedBlock xyFace = new TransformatedBlock(
                new RectangleFaceXY(100, 100, 10),
                new Transformation(new double[,]
                {
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 },
                }),
                new Surface(1, 1, 0.2, 10, Color.Azure)
                );

            TransformatedBlock yzFace = new TransformatedBlock(
                new RectangleFaceYZ(100, 100, 10),
                new Transformation(new double[,]
                {
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 },
                }),
                new Surface(1, 1, 0.2, 10, Color.Azure)
                );

            TransformatedBlock zxFace = new TransformatedBlock(
                new RectangleFaceZX(100, 100, 10),
                new Transformation(new double[,]
                {
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 },
                }),
                new Surface(1, 1, 0.2, 10, Color.Azure)
                );

            TransformatedBlock cube = new TransformatedBlock(
                new Cuboid(5, 20, 20, 20),
                new Transformation(new double[,]
                {
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 },
                }),
                new Surface(1, 1, 0.2, 10, Color.Azure)
                );

            TransformatedBlocks.Add(cube);
            //TransformatedBlocks.Add(xyFace);
            //TransformatedBlocks.Add(zxFace);
            //TransformatedBlocks.Add(yzFace);
        }
    }
}
