﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        AppManager appManager;
        public Form1()
        {
            InitializeComponent();
            appManager = new AppManager(pictureBox);

            fovNumericUpDown.Maximum = 150;
            fovNumericUpDown.Minimum = 40;
            fovNumericUpDown.Value = 90;

            numericUpDown2.Value = 50;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox.Invalidate();
        }

        private void fovNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            appManager.SetFieldOfView((int)fovNumericUpDown.Value);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            appManager.SetCameraPosition((int)numericUpDown2.Value);
        }
    }
}
