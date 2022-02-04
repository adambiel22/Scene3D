﻿using _3DAdamBielecki._3DScene;
using _3DAdamBielecki.Shading;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Algebra;

namespace _3DAdamBielecki
{
    public class AppManager
    {
        private Render render;
        private Scene scene;
        public PictureBox PictureBox { get; set; }

        //public int GetCameraPosition()
        //{
        //    return scene.Camera.CameraPosition[0] /;
        //}

        public void SetCameraPosition(int value)
        {
            scene.Camera.CameraPosition[1] = (double)value / 100 - 4.0;
            scene.Camera.GenerateViewMarix();
            PictureBox.Invalidate();
        }

        public int GetFieldOfView()
        {
            return (int)(scene.Projection.FieldOfView * 180 / Math.PI);
        }

        public void SetFieldOfView(int value)
        {
            scene.Projection.FieldOfView = value * Math.PI / 180 ;
            PictureBox.Invalidate();
        }

        public AppManager(PictureBox pictureBox)
        {
            PictureBox = pictureBox;

            render = new Render();
            render.PixelShader = new MockedPixelShader();
            render.TriangleDrawer = new TriangleDrawer();
            scene = new Scene();
            scene.Camera = new Camera(
                new Vector(3, 0.5, 0.5, 1),
                new Vector(0, 0, 0, 1),
                new Vector(0, 0, 1, 0));
            scene.TransformatedBlocks.Add(new TransformatedBlock(
                new Pyramid(),
                new Transformation(),
                new Surface(Color.BlueViolet)));
            scene.TransformatedBlocks.Add(new TransformatedBlock(
                new Cube(),
                new Transformation(new double[,]
                {
                    {2, 0, 0, -2.5},
                    {0, 2, 0, -2.5},
                    {0, 0, 0.25, -1},
                    {0, 0, 0, 1}
                }),
                new Surface(Color.Bisque)));
            scene.Projection = new Projection(Math.PI / 4, 100, 1, 1);
            render.Scene = scene;

            pictureBox.Paint += paint;
        }

        private void paint(object sender, PaintEventArgs e)
        {
            PictureBox.Image = render.RenderScene(PictureBox.Width, PictureBox.Height);
        }
    }
}