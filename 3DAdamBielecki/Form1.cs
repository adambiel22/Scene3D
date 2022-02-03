using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3DAdamBielecki._3DScene;
using _3DAdamBielecki.Bitmapping;
using _3DAdamBielecki.Shading;
using MathNet.Numerics.LinearAlgebra.Double;

namespace _3DAdamBielecki
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Render render = new Render();
            render.PixelShader = new MockedPixelShader();
            render.PixelTester = new MockedPixelTester();
            render.TriangleDrawer = new TriangleDrawer();
            Scene scene = new Scene();
            scene.Camera = new Camera(
                VectorExtender.Vector4D(0, 0, 2, 1),
                VectorExtender.Vector4D(0, 0, 0, 1),
                VectorExtender.Vector4D(0, 0, 1, 0));
            scene.Lights = new Light[] {new Light()}
            pictureBox.Image = 
        }

    }
}
