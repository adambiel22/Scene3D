using _3DAdamBielecki._3DScene;
using _3DAdamBielecki.Shading;
using System;
using System.Drawing;
using Algebra;
using System.Timers;
using System.Windows.Forms;

namespace _3DAdamBielecki
{
    public class AppManager
    {
        private Render render;
        private Scene scene;
        private System.Timers.Timer _timer;
        private Transformation pyramidTransformation;

        public Button button;
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

        public AppManager(PictureBox pictureBox, System.Timers.Timer timer)
        {
            PictureBox = pictureBox;

            render = new Render();
            render.PixelShader = new MockedPixelShader();
            render.TriangleDrawer = new TriangleDrawer();
            scene = new Scene();
            scene.Camera = new Camera(
                new Vector(3, 0.5, 0.5, 1),
                new Vector(0, 0.5, 0.5, 1),
                new Vector(0, 0, 1, 0));
            pyramidTransformation = new Transformation(new double[,]
                {
                    {1, 0, 0, 0 },
                    {0, 1, 0, 0 },
                    {0, 0, 1, 0 },
                    {0, 0, 0, 1 }
                });
            //scene.TransformatedBlocks.Add(new TransformatedBlock(
            //    new Pyramid(10, 10, 10),
            //    pyramidTransformation,
            //    new Surface(Color.BlueViolet)));
            scene.TransformatedBlocks.Add(new TransformatedBlock(
                new Cuboid(1, 1, 1),
                new Transformation(new double[,]
                {
                    {1, 0, 0, 0},
                    {0, 1, 0, 0},
                    {0, 0, 1, 0},
                    {0, 0, 0, 1}
                }),
                new Surface(Color.Bisque)));
            scene.Projection = new Projection(Math.PI / 4, 100, 1, 1);
            render.Scene = scene;

            _timer = timer;
            _timer.Interval = 100;
            _timer.Elapsed += Timer_Elapsed;

            pictureBox.Click += PictureBox_Click;            
            pictureBox.Paint += paint;
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            _timer.Stop();
            //pyramidTransformation.AddTransformation(new Matrix(new double[,]
            //{
            //    {Math.Cos(0.1), -Math.Sin(0.1), 0, 0 },
            //    {Math.Sin(0.1), Math.Cos(0.1), 0, 0 },
            //    {0, 0, 1, 0 },
            //    {0, 0, 0, 1 }
            //}));
            //PictureBox.Invalidate();
            
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();
            PictureBox.Image = null;
            pyramidTransformation.AddTransformation(new Matrix(new double[,]
            {
                {Math.Cos(3), -Math.Sin(3), 0, 0 },
                {Math.Sin(3), Math.Cos(3), 0, 0 },
                {0, 0, 1, 0 },
                {0, 0, 0, 1 }
            }));
            PictureBox.Invalidate();
            //_timer.Start();
        }

        private void paint(object sender, PaintEventArgs e)
        {
            PictureBox.Image = render.RenderScene(PictureBox.Width, PictureBox.Height);
        }
    }
}
