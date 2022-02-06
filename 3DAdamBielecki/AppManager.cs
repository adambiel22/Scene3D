
using System;
using System.Drawing;
using Algebra;
using System.Timers;
using System.Windows.Forms;
using System.Diagnostics;

namespace _3DAdamBielecki
{
    public class AppManager
    {
        private Render render;
        private Scene scene;
        private System.Timers.Timer timer;
        private Stopwatch stopwatch;
        private Transformation pyramidTransformation;
        private Transformation cubeTransformation;
        private Transformation sphereTransformation;
        double angle;
        double angleIncrement;
        bool timerRunning;
        public Button button;
        private int counter;

        public PictureBox PictureBox { get; set; }


        //public int GetCameraPosition()
        //{
        //    return scene.Camera.CameraPosition[0] /;
        //}

        public void SetCameraPosition(int value)
        {
            scene.CurrentCamera.CameraPosition[1] = (double)value / 100 - 4.0;
            scene.CurrentCamera.GenerateViewMarix();
            if (!timerRunning) PictureBox.Invalidate();
        }

        public int GetFieldOfView()
        {
            return (int)(scene.CurrentCamera.Projection.FieldOfView * 180 / Math.PI);
        }

        public void SetFieldOfView(int value)
        {
            scene.CurrentCamera.Projection.FieldOfView = value * Math.PI / 180 ;
            if (!timerRunning) PictureBox.Invalidate();
        }

        public void TimerButtonClick(object sender, EventArgs e)
        {
            if (timerRunning)
            {
                timerRunning = false;
                timer.Stop();
                stopwatch.Reset();
            }
            else
            {
                timerRunning = true;
                timer.Start();
                stopwatch.Restart();
            }
        }

        public AppManager(PictureBox pictureBox)
        {
            PictureBox = pictureBox;

            render = new Render();
            render.PixelShader = new PhongPixelShader();
            render.TriangleDrawer = new TriangleDrawer();
            scene = new StandardScene(pictureBox.Width, pictureBox.Height);
            pyramidTransformation = scene.TransformatedBlocks[1].Transformation;

            render.Scene = scene;

            timerRunning = false;
            counter = 0;
            angle = 0.0;
            angleIncrement = 0.1;
            timer = new System.Timers.Timer();
            stopwatch = new Stopwatch();
            timer.Interval = 100;
            timer.AutoReset = false;
            timer.Elapsed += Timer_Elapsed;
         
            pictureBox.Paint += pictureBox_paint;
            pictureBox.Resize += PictureBox_Resize;
        }

        private void PictureBox_Resize(object sender, EventArgs e)
        {
            scene.CurrentCamera.Projection.AspectRatio = (double)PictureBox.Height / PictureBox.Width;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            double secondsTimeOffset = stopwatch.Elapsed.TotalSeconds;
            stopwatch.Restart();
            foreach (IAnimation animation in scene.Animations)
            {
                animation.NextFrame(secondsTimeOffset);
            }
            PictureBox.Invalidate();
        }

        private void pictureBox_paint(object sender, PaintEventArgs e)
        {
            //PictureBox.Image = render.RenderScene(PictureBox.Width, PictureBox.Height);
            e.Graphics.DrawImage(
                render.RenderScene(PictureBox.Width, PictureBox.Height),
                new Point(0, 0));
            if (timerRunning) timer.Start();
        }
    }
}
