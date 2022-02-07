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
        public Form1()
        {
            InitializeComponent();
            appManager = new AppManager(pictureBox);
            
            foreach(Camera camera in appManager.Scene.Cameras)
            {
                var item = new ListViewItem(camera.Name);
                item.Tag = camera;
                camerasListView.Items.Add(item);
            }
            if (camerasListView.Items.Count > 0)
            {
                camerasListView.Items[0].Selected = true;
            }

            fovNumericUpDown.Maximum = 150;
            fovNumericUpDown.Minimum = 40;
            fovNumericUpDown.Value = 45;

            trackBar.Value = 50;

        }
        private void fovNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("fov changed");
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

        private void camerLlistView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (camerasListView.SelectedIndices.Count > 0)
            {
                appManager.Scene.SetCurrentCamera(camerasListView.SelectedIndices[0]);
                pictureBox.Invalidate();
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (constantRadioButton.Checked)
            {
                appManager.Render.PixelShader = new ConstantPixelShader();
            }
            else if (gourandRadioButton.Checked)
            {
                appManager.Render.PixelShader = new GourandPixelShader();
            }
            else if (constantRadioButton.Checked)
            {
                appManager.Render.PixelShader = new PhongPixelShader();
            }
            pictureBox.Invalidate();
        }

        private void animationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (animationCheckBox.Checked)
            {
                appManager.StartAnimation();
            }   
            else
            {
                appManager.StopAnimation();
            }
        }
    }
}
