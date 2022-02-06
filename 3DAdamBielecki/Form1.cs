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

namespace _3DAdamBielecki
{
    public partial class Form1 : Form
    {
        AppManager appManager;
        private System.Timers.Timer timer;
        bool enabled;
        public Form1()
        {
            InitializeComponent();
            enabled = false;
            timer = new System.Timers.Timer();
            appManager = new AppManager(pictureBox, timer);

            fovNumericUpDown.Maximum = 150;
            fovNumericUpDown.Minimum = 40;
            fovNumericUpDown.Value = 45;

            trackBar.Value = 50;

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (enabled == true)
            {
                enabled = false;
                timer.Stop();
            }
            else
            {
                enabled = true;
                timer.Start();
            }
        }

        private void fovNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            appManager.SetFieldOfView((int)fovNumericUpDown.Value);
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            appManager.SetCameraPosition(trackBar.Value);
            label1.Text = $"{trackBar.Value}";
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            Debug.WriteLine(e.Location);
        }


    }
}
