
namespace _3DAdamBielecki
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.fovNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.shadingTab = new System.Windows.Forms.TabControl();
            this.cameraTabPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.camerasListView = new System.Windows.Forms.ListView();
            this.shadingTabPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.phongRadioButton = new System.Windows.Forms.RadioButton();
            this.gourandRadioButton = new System.Windows.Forms.RadioButton();
            this.constantRadioButton = new System.Windows.Forms.RadioButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.animationCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fovNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.shadingTab.SuspendLayout();
            this.cameraTabPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.shadingTabPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox.Location = new System.Drawing.Point(12, 68);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(844, 541);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            // 
            // fovNumericUpDown
            // 
            this.fovNumericUpDown.Location = new System.Drawing.Point(12, 23);
            this.fovNumericUpDown.Name = "fovNumericUpDown";
            this.fovNumericUpDown.Size = new System.Drawing.Size(150, 27);
            this.fovNumericUpDown.TabIndex = 1;
            this.fovNumericUpDown.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.fovNumericUpDown.ValueChanged += new System.EventHandler(this.fovNumericUpDown_ValueChanged);
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(537, 23);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(150, 27);
            this.numericUpDown3.TabIndex = 3;
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(218, 12);
            this.trackBar.Maximum = 800;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(278, 56);
            this.trackBar.TabIndex = 5;
            this.trackBar.Value = 50;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // shadingTab
            // 
            this.shadingTab.Controls.Add(this.cameraTabPage);
            this.shadingTab.Controls.Add(this.shadingTabPage);
            this.shadingTab.Controls.Add(this.tabPage1);
            this.shadingTab.Dock = System.Windows.Forms.DockStyle.Right;
            this.shadingTab.Location = new System.Drawing.Point(874, 0);
            this.shadingTab.Multiline = true;
            this.shadingTab.Name = "shadingTab";
            this.shadingTab.SelectedIndex = 0;
            this.shadingTab.Size = new System.Drawing.Size(313, 621);
            this.shadingTab.TabIndex = 8;
            // 
            // cameraTabPage
            // 
            this.cameraTabPage.Controls.Add(this.groupBox1);
            this.cameraTabPage.Location = new System.Drawing.Point(4, 29);
            this.cameraTabPage.Name = "cameraTabPage";
            this.cameraTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.cameraTabPage.Size = new System.Drawing.Size(305, 588);
            this.cameraTabPage.TabIndex = 0;
            this.cameraTabPage.Text = "Camera";
            this.cameraTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.camerasListView);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 125);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose camera";
            // 
            // camerasListView
            // 
            this.camerasListView.HideSelection = false;
            this.camerasListView.Location = new System.Drawing.Point(6, 26);
            this.camerasListView.MultiSelect = false;
            this.camerasListView.Name = "camerasListView";
            this.camerasListView.Size = new System.Drawing.Size(287, 93);
            this.camerasListView.TabIndex = 4;
            this.camerasListView.UseCompatibleStateImageBehavior = false;
            this.camerasListView.View = System.Windows.Forms.View.List;
            this.camerasListView.SelectedIndexChanged += new System.EventHandler(this.camerLlistView_SelectedIndexChanged);
            // 
            // shadingTabPage
            // 
            this.shadingTabPage.Controls.Add(this.groupBox2);
            this.shadingTabPage.Location = new System.Drawing.Point(4, 29);
            this.shadingTabPage.Name = "shadingTabPage";
            this.shadingTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.shadingTabPage.Size = new System.Drawing.Size(305, 588);
            this.shadingTabPage.TabIndex = 1;
            this.shadingTabPage.Text = "Shading";
            this.shadingTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.phongRadioButton);
            this.groupBox2.Controls.Add(this.gourandRadioButton);
            this.groupBox2.Controls.Add(this.constantRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(294, 125);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Shading mode";
            // 
            // phongRadioButton
            // 
            this.phongRadioButton.AutoSize = true;
            this.phongRadioButton.Location = new System.Drawing.Point(7, 87);
            this.phongRadioButton.Name = "phongRadioButton";
            this.phongRadioButton.Size = new System.Drawing.Size(128, 24);
            this.phongRadioButton.TabIndex = 2;
            this.phongRadioButton.TabStop = true;
            this.phongRadioButton.Text = "Phong shading";
            this.phongRadioButton.UseVisualStyleBackColor = true;
            this.phongRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // gourandRadioButton
            // 
            this.gourandRadioButton.AutoSize = true;
            this.gourandRadioButton.Location = new System.Drawing.Point(7, 57);
            this.gourandRadioButton.Name = "gourandRadioButton";
            this.gourandRadioButton.Size = new System.Drawing.Size(143, 24);
            this.gourandRadioButton.TabIndex = 1;
            this.gourandRadioButton.TabStop = true;
            this.gourandRadioButton.Text = "Gourand shading";
            this.gourandRadioButton.UseVisualStyleBackColor = true;
            this.gourandRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // constantRadioButton
            // 
            this.constantRadioButton.AutoSize = true;
            this.constantRadioButton.Checked = true;
            this.constantRadioButton.Location = new System.Drawing.Point(7, 27);
            this.constantRadioButton.Name = "constantRadioButton";
            this.constantRadioButton.Size = new System.Drawing.Size(144, 24);
            this.constantRadioButton.TabIndex = 0;
            this.constantRadioButton.TabStop = true;
            this.constantRadioButton.Text = "Constant shading";
            this.constantRadioButton.UseVisualStyleBackColor = true;
            this.constantRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.animationCheckBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(305, 588);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Animation";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // animationCheckBox
            // 
            this.animationCheckBox.AutoSize = true;
            this.animationCheckBox.Location = new System.Drawing.Point(12, 15);
            this.animationCheckBox.Name = "animationCheckBox";
            this.animationCheckBox.Size = new System.Drawing.Size(147, 24);
            this.animationCheckBox.TabIndex = 0;
            this.animationCheckBox.Text = "Enable animation";
            this.animationCheckBox.UseVisualStyleBackColor = true;
            this.animationCheckBox.CheckedChanged += new System.EventHandler(this.animationCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 621);
            this.Controls.Add(this.shadingTab);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.fovNumericUpDown);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fovNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.shadingTab.ResumeLayout(false);
            this.cameraTabPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.shadingTabPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.NumericUpDown fovNumericUpDown;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage shadingTabPage;
        private System.Windows.Forms.TabControl shadingTab;
        private System.Windows.Forms.TabPage cameraTabPage;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView camerasListView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton phongRadioButton;
        private System.Windows.Forms.RadioButton gourandRadioButton;
        private System.Windows.Forms.RadioButton constantRadioButton;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox animationCheckBox;
    }
}

