using System;
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

            foreach (Light light in appManager.Scene.Lights)
            {
                var item = new ListViewItem(light.Name);
                item.Tag = light;
                item.Checked = light.Enabled;
                lightsListView.Items.Add(item);
            }
            lightsListView.ItemCheck += LightsListView_ItemCheck;

            nearTrackBar.Value = (int)(appManager.Render.Fogg.Near * 100);
            farTrackBar.Minimum = (int)(appManager.Render.Fogg.Near * 100);
            nearLabel.Text = nearTrackBar.Value.ToString();

            nearTrackBar.Maximum = (int)(appManager.Render.Fogg.Far * 100);
            farTrackBar.Value = (int)(appManager.Render.Fogg.Far * 100);
            farLabel.Text = farTrackBar.Value.ToString();

            nearTrackBar.Scroll += nearTrackBar_Scroll;
            farTrackBar.Scroll += farTrackBar_Scroll;

            fovNumericUpDown.Maximum = 150;
            fovNumericUpDown.Minimum = 40;
            fovNumericUpDown.Value = 45;

            trackBar.Value = 50;

        }

        private void LightsListView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ((Light)lightsListView.Items[e.Index].Tag).Enabled = e.NewValue == CheckState.Checked;
            pictureBox.Invalidate();
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
            else if (phongRadioButton.Checked)
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

        private void shadingTab_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gridCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            appManager.Render.TriangleDrawer.GridEnable = gridCheckBox.Checked;
            pictureBox.Invalidate();
        }

        private void foggCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            appManager.Render.PixelShader.Fogg.Enabled = foggCheckBox.Checked;
            pictureBox.Invalidate();
        }

        private void nearTrackBar_Scroll(object sender, EventArgs e)
        {
            appManager.Render.Fogg.Near = nearTrackBar.Value / 100.0;
            farTrackBar.Minimum = nearTrackBar.Value;
            nearLabel.Text = nearTrackBar.Value.ToString();
            if (appManager.Render.Fogg.Enabled) pictureBox.Invalidate();
        }

        private void farTrackBar_Scroll(object sender, EventArgs e)
        {
            appManager.Render.Fogg.Far = farTrackBar.Value / 100.0;
            nearTrackBar.Maximum = farTrackBar.Value;
            farLabel.Text = farTrackBar.Value.ToString();
            if (appManager.Render.Fogg.Enabled) pictureBox.Invalidate();
        }
    }
}
