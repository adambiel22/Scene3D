
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
        public Render Render { get; private set; }
        public Scene Scene { get; private set; }
        private System.Timers.Timer timer;
        private Stopwatch stopwatch;
        bool timerRunning;
        public Button button;

        public PictureBox PictureBox { get; set; }


        //public int GetCameraPosition()
        //{
        //    return scene.Camera.CameraPosition[0] /;
        //}

        public void SetCameraPosition(int value)
        {
            Scene.CurrentCamera.CameraPosition[1] = (double)value / 100 - 4.0;
            Scene.CurrentCamera.GenerateViewMarix();
            if (!timerRunning) PictureBox.Invalidate();
        }

        public int GetFieldOfView()
        {
            return (int)(Scene.CurrentCamera.Projection.FieldOfView * 180 / Math.PI);
        }

        public void SetFieldOfView(int value)
        {
            Scene.CurrentCamera.Projection.FieldOfView = value * Math.PI / 180 ;
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

            Render = new Render();
            Render.PixelShader = new ConstantPixelShader();
            Render.TriangleDrawer = new TriangleDrawer();
            Render.Fogg = new Fogg(Color.White, 0.8, 0.9, false);
            Scene = new StandardScene(pictureBox.Width, pictureBox.Height);

            Render.Scene = Scene;

            timerRunning = false;
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
            Scene.Cameras.ForEach((camera) =>
            {
                camera.Projection.AspectRatio = (double)PictureBox.Height / PictureBox.Width;
            });
            PictureBox.Invalidate();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            TimeSpan timeOffset = stopwatch.Elapsed;
            stopwatch.Restart();
            foreach (IAnimation animation in Scene.Animations)
            {
                animation.NextFrame(timeOffset);
            }
            PictureBox.Invalidate();
        }

        internal void StopAnimation()
        {
            timerRunning = false;
            timer.Stop();
            stopwatch.Reset();
        }

        internal void StartAnimation()
        {
            timerRunning = true;
            timer.Start();
            stopwatch.Restart();
        }

        private void pictureBox_paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(
                Render.RenderScene(PictureBox.Width, PictureBox.Height),
                new Point(0, 0));
            if (timerRunning) timer.Start();
        }
    }
}
