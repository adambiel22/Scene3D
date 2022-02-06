
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
        private Transformation cubeTransformation;
        private Transformation sphereTransformation;
        double angle;
        double angleIncrement;
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
            render.PixelShader = new PhongPixelShader();
            render.TriangleDrawer = new TriangleDrawer();
            scene = new PyramidScene(pictureBox.Width, pictureBox.Height);
            pyramidTransformation = scene.TransformatedBlocks[0].Transformation;

            render.Scene = scene;

            angle = 0.0;
            angleIncrement = 0.1;
            _timer = timer;
            _timer.Interval = 100;
            _timer.AutoReset = false;
            _timer.Elapsed += Timer_Elapsed;

            pictureBox.Click += PictureBox_Click;            
            pictureBox.Paint += paint;
            pictureBox.Resize += PictureBox_Resize;
        }

        private void PictureBox_Resize(object sender, EventArgs e)
        {
            scene.Projection.AspectRatio = (double)PictureBox.Height / PictureBox.Width;
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
            //_timer.Stop();
            angle += angleIncrement;
            pyramidTransformation.SetTransformation(new Matrix(new double[,]
            {
                //{Math.Cos(angle), -Math.Sin(angle), 0, 50 },
                //{Math.Sin(angle), Math.Cos(angle), 0, 50 },
                //{0, 0, 1, 5 },
                //{0, 0, 0, 1 }

                {Math.Cos(2*angle), 0 , -Math.Sin(2*angle), 50 },
                {0, 1, 0, 50 },
                {Math.Sin(2*angle), 0, Math.Cos(2*angle), 5 },
                {0, 0, 0, 1 }
            }));
            PictureBox.Invalidate();
            _timer.Start();
        }

        private void paint(object sender, PaintEventArgs e)
        {
            PictureBox.Image = render.RenderScene(PictureBox.Width, PictureBox.Height);
        }
    }
}
