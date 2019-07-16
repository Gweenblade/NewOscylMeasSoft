namespace NewOscylMeasSoft
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.OscilInit = new System.Windows.Forms.Button();
            this.TriggerGroup = new System.Windows.Forms.GroupBox();
            this.DeleteFrame = new System.Windows.Forms.Button();
            this.FrameLabel = new System.Windows.Forms.Label();
            this.DataSlider = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LoadData = new System.Windows.Forms.Button();
            this.IntegralBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.PauseBtn = new System.Windows.Forms.Button();
            this.StopBtn = new System.Windows.Forms.Button();
            this.StartBtn = new System.Windows.Forms.Button();
            this.FindFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.WavemeterInit = new System.Windows.Forms.Button();
            this.Bar1Label = new System.Windows.Forms.Label();
            this.Bar2Label = new System.Windows.Forms.Label();
            this.ZedSignal = new ZedGraph.ZedGraphControl();
            this.TrackMin = new System.Windows.Forms.TrackBar();
            this.TrackMax = new System.Windows.Forms.TrackBar();
            this.PathToFileLabel = new System.Windows.Forms.Label();
            this.TestLabel = new System.Windows.Forms.TextBox();
            this.DataSaverDialog = new System.Windows.Forms.SaveFileDialog();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OscilloSignal = new ZedGraph.ZedGraphControl();
            this.label1 = new System.Windows.Forms.Label();
            this.ShowOneInterferometer = new System.Windows.Forms.Button();
            this.CutoffParameter = new System.Windows.Forms.TextBox();
            this.Cutoff = new System.Windows.Forms.Label();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.ZedIntegral = new ZedGraph.ZedGraphControl();
            this.WavemeterSignal = new ZedGraph.ZedGraphControl();
            this.label2 = new System.Windows.Forms.Label();
            this.TriggerGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSlider)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackMax)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OscilInit
            // 
            this.OscilInit.Location = new System.Drawing.Point(158, 681);
            this.OscilInit.Name = "OscilInit";
            this.OscilInit.Size = new System.Drawing.Size(138, 20);
            this.OscilInit.TabIndex = 0;
            this.OscilInit.Text = "Oscilloscope initialization";
            this.OscilInit.UseVisualStyleBackColor = true;
            this.OscilInit.Click += new System.EventHandler(this.button1_Click);
            // 
            // TriggerGroup
            // 
            this.TriggerGroup.Controls.Add(this.ShowOneInterferometer);
            this.TriggerGroup.Controls.Add(this.zedGraphControl1);
            this.TriggerGroup.Controls.Add(this.ZedIntegral);
            this.TriggerGroup.Controls.Add(this.DeleteFrame);
            this.TriggerGroup.Controls.Add(this.FrameLabel);
            this.TriggerGroup.Controls.Add(this.DataSlider);
            this.TriggerGroup.Controls.Add(this.groupBox2);
            this.TriggerGroup.Controls.Add(this.Bar1Label);
            this.TriggerGroup.Controls.Add(this.Bar2Label);
            this.TriggerGroup.Controls.Add(this.ZedSignal);
            this.TriggerGroup.Controls.Add(this.TrackMin);
            this.TriggerGroup.Controls.Add(this.TrackMax);
            this.TriggerGroup.Location = new System.Drawing.Point(532, 12);
            this.TriggerGroup.Name = "TriggerGroup";
            this.TriggerGroup.Size = new System.Drawing.Size(1440, 757);
            this.TriggerGroup.TabIndex = 8;
            this.TriggerGroup.TabStop = false;
            this.TriggerGroup.Text = "Data analysis section";
            // 
            // DeleteFrame
            // 
            this.DeleteFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DeleteFrame.Location = new System.Drawing.Point(668, 566);
            this.DeleteFrame.Name = "DeleteFrame";
            this.DeleteFrame.Size = new System.Drawing.Size(43, 32);
            this.DeleteFrame.TabIndex = 15;
            this.DeleteFrame.Text = "Delete Frame";
            this.DeleteFrame.UseVisualStyleBackColor = true;
            // 
            // FrameLabel
            // 
            this.FrameLabel.AutoSize = true;
            this.FrameLabel.Location = new System.Drawing.Point(556, 577);
            this.FrameLabel.Name = "FrameLabel";
            this.FrameLabel.Size = new System.Drawing.Size(83, 13);
            this.FrameLabel.TabIndex = 14;
            this.FrameLabel.Text = "Frame number : ";
            // 
            // DataSlider
            // 
            this.DataSlider.BackColor = System.Drawing.Color.Gainsboro;
            this.DataSlider.Location = new System.Drawing.Point(13, 563);
            this.DataSlider.Maximum = 0;
            this.DataSlider.Name = "DataSlider";
            this.DataSlider.Size = new System.Drawing.Size(543, 45);
            this.DataSlider.TabIndex = 4;
            this.DataSlider.Scroll += new System.EventHandler(this.DataSlider_Scroll);
            this.DataSlider.ValueChanged += new System.EventHandler(this.DataSlider_ValueChanged);
            this.DataSlider.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DataSlider_MouseUp);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LoadData);
            this.groupBox2.Controls.Add(this.CutoffParameter);
            this.groupBox2.Controls.Add(this.Cutoff);
            this.groupBox2.Controls.Add(this.IntegralBtn);
            this.groupBox2.Controls.Add(this.FindFile);
            this.groupBox2.Location = new System.Drawing.Point(13, 614);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(695, 73);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Experiment parameters";
            // 
            // LoadData
            // 
            this.LoadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LoadData.Location = new System.Drawing.Point(100, 19);
            this.LoadData.Name = "LoadData";
            this.LoadData.Size = new System.Drawing.Size(88, 39);
            this.LoadData.TabIndex = 19;
            this.LoadData.Text = "Load Data";
            this.LoadData.UseVisualStyleBackColor = true;
            this.LoadData.Click += new System.EventHandler(this.LoadData_Click);
            // 
            // IntegralBtn
            // 
            this.IntegralBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.IntegralBtn.Location = new System.Drawing.Point(194, 20);
            this.IntegralBtn.Name = "IntegralBtn";
            this.IntegralBtn.Size = new System.Drawing.Size(88, 39);
            this.IntegralBtn.TabIndex = 19;
            this.IntegralBtn.Text = "Calculate Integral";
            this.IntegralBtn.UseVisualStyleBackColor = true;
            this.IntegralBtn.Click += new System.EventHandler(this.IntegralBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SaveBtn.Location = new System.Drawing.Point(158, 729);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(138, 21);
            this.SaveBtn.TabIndex = 21;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // PauseBtn
            // 
            this.PauseBtn.BackColor = System.Drawing.Color.White;
            this.PauseBtn.Enabled = false;
            this.PauseBtn.Location = new System.Drawing.Point(91, 757);
            this.PauseBtn.Name = "PauseBtn";
            this.PauseBtn.Size = new System.Drawing.Size(75, 23);
            this.PauseBtn.TabIndex = 20;
            this.PauseBtn.Text = "Pause";
            this.PauseBtn.UseVisualStyleBackColor = false;
            this.PauseBtn.Click += new System.EventHandler(this.PauseBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.BackColor = System.Drawing.Color.White;
            this.StopBtn.Enabled = false;
            this.StopBtn.Location = new System.Drawing.Point(172, 757);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(75, 23);
            this.StopBtn.TabIndex = 19;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = false;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // StartBtn
            // 
            this.StartBtn.BackColor = System.Drawing.Color.Green;
            this.StartBtn.Location = new System.Drawing.Point(10, 757);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 23);
            this.StartBtn.TabIndex = 18;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = false;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // FindFile
            // 
            this.FindFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FindFile.Location = new System.Drawing.Point(6, 19);
            this.FindFile.Name = "FindFile";
            this.FindFile.Size = new System.Drawing.Size(88, 39);
            this.FindFile.TabIndex = 17;
            this.FindFile.Text = "Find File";
            this.FindFile.UseVisualStyleBackColor = true;
            this.FindFile.Click += new System.EventHandler(this.FindFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 685);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Set oscilloscope parameters -";
            // 
            // WavemeterInit
            // 
            this.WavemeterInit.Location = new System.Drawing.Point(159, 705);
            this.WavemeterInit.Name = "WavemeterInit";
            this.WavemeterInit.Size = new System.Drawing.Size(138, 20);
            this.WavemeterInit.TabIndex = 15;
            this.WavemeterInit.Text = "Wavemeter Initializaction";
            this.WavemeterInit.UseVisualStyleBackColor = true;
            this.WavemeterInit.Click += new System.EventHandler(this.WavemeterInit_Click);
            // 
            // Bar1Label
            // 
            this.Bar1Label.AutoSize = true;
            this.Bar1Label.Location = new System.Drawing.Point(673, 494);
            this.Bar1Label.Name = "Bar1Label";
            this.Bar1Label.Size = new System.Drawing.Size(9, 13);
            this.Bar1Label.TabIndex = 4;
            this.Bar1Label.Text = "l";
            // 
            // Bar2Label
            // 
            this.Bar2Label.AutoSize = true;
            this.Bar2Label.Location = new System.Drawing.Point(673, 537);
            this.Bar2Label.Name = "Bar2Label";
            this.Bar2Label.Size = new System.Drawing.Size(9, 13);
            this.Bar2Label.TabIndex = 5;
            this.Bar2Label.Text = "l";
            // 
            // ZedSignal
            // 
            this.ZedSignal.Location = new System.Drawing.Point(13, 19);
            this.ZedSignal.Name = "ZedSignal";
            this.ZedSignal.ScrollGrace = 0D;
            this.ZedSignal.ScrollMaxX = 0D;
            this.ZedSignal.ScrollMaxY = 0D;
            this.ZedSignal.ScrollMaxY2 = 0D;
            this.ZedSignal.ScrollMinX = 0D;
            this.ZedSignal.ScrollMinY = 0D;
            this.ZedSignal.ScrollMinY2 = 0D;
            this.ZedSignal.Size = new System.Drawing.Size(679, 450);
            this.ZedSignal.TabIndex = 8;
            this.ZedSignal.ZoomStepFraction = 1D;
            this.ZedSignal.Load += new System.EventHandler(this.ZedSignal_Load);
            // 
            // TrackMin
            // 
            this.TrackMin.Location = new System.Drawing.Point(13, 479);
            this.TrackMin.Maximum = 2046;
            this.TrackMin.Minimum = 1;
            this.TrackMin.Name = "TrackMin";
            this.TrackMin.Size = new System.Drawing.Size(649, 45);
            this.TrackMin.TabIndex = 9;
            this.TrackMin.Value = 1;
            this.TrackMin.Scroll += new System.EventHandler(this.TrackMin_Scroll);
            // 
            // TrackMax
            // 
            this.TrackMax.Location = new System.Drawing.Point(13, 522);
            this.TrackMax.Maximum = 2046;
            this.TrackMax.Minimum = 1;
            this.TrackMax.Name = "TrackMax";
            this.TrackMax.Size = new System.Drawing.Size(649, 45);
            this.TrackMax.TabIndex = 10;
            this.TrackMax.Value = 1;
            this.TrackMax.Scroll += new System.EventHandler(this.TrackMax_Scroll);
            // 
            // PathToFileLabel
            // 
            this.PathToFileLabel.AutoSize = true;
            this.PathToFileLabel.ForeColor = System.Drawing.Color.Blue;
            this.PathToFileLabel.Location = new System.Drawing.Point(10, 783);
            this.PathToFileLabel.Name = "PathToFileLabel";
            this.PathToFileLabel.Size = new System.Drawing.Size(35, 13);
            this.PathToFileLabel.TabIndex = 14;
            this.PathToFileLabel.Text = "Path: ";
            this.PathToFileLabel.Click += new System.EventHandler(this.PathToFileLabel_Click);
            // 
            // TestLabel
            // 
            this.TestLabel.Location = new System.Drawing.Point(572, 775);
            this.TestLabel.Multiline = true;
            this.TestLabel.Name = "TestLabel";
            this.TestLabel.Size = new System.Drawing.Size(237, 108);
            this.TestLabel.TabIndex = 4;
            this.TestLabel.TextChanged += new System.EventHandler(this.TestLabel_TextChanged);
            // 
            // DataSaverDialog
            // 
            this.DataSaverDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.DataSaverDialog_FileOk);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "openFileDialog1";
            this.OpenFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog_FileOk);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.WavemeterSignal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.OscilloSignal);
            this.groupBox1.Controls.Add(this.WavemeterInit);
            this.groupBox1.Controls.Add(this.PauseBtn);
            this.groupBox1.Controls.Add(this.StopBtn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.StartBtn);
            this.groupBox1.Controls.Add(this.PathToFileLabel);
            this.groupBox1.Controls.Add(this.SaveBtn);
            this.groupBox1.Controls.Add(this.OscilInit);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 854);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Signal";
            // 
            // OscilloSignal
            // 
            this.OscilloSignal.Location = new System.Drawing.Point(6, 23);
            this.OscilloSignal.Name = "OscilloSignal";
            this.OscilloSignal.ScrollGrace = 0D;
            this.OscilloSignal.ScrollMaxX = 0D;
            this.OscilloSignal.ScrollMaxY = 0D;
            this.OscilloSignal.ScrollMaxY2 = 0D;
            this.OscilloSignal.ScrollMinX = 0D;
            this.OscilloSignal.ScrollMinY = 0D;
            this.OscilloSignal.ScrollMinY2 = 0D;
            this.OscilloSignal.Size = new System.Drawing.Size(500, 325);
            this.OscilloSignal.TabIndex = 16;
            this.OscilloSignal.ZoomStepFraction = 1D;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 733);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Choose file for data -";
            // 
            // ShowOneInterferometer
            // 
            this.ShowOneInterferometer.Location = new System.Drawing.Point(727, 19);
            this.ShowOneInterferometer.Name = "ShowOneInterferometer";
            this.ShowOneInterferometer.Size = new System.Drawing.Size(84, 26);
            this.ShowOneInterferometer.TabIndex = 20;
            this.ShowOneInterferometer.Text = "Recalcuate";
            this.ShowOneInterferometer.UseVisualStyleBackColor = true;
            // 
            // CutoffParameter
            // 
            this.CutoffParameter.Location = new System.Drawing.Point(396, 19);
            this.CutoffParameter.Name = "CutoffParameter";
            this.CutoffParameter.Size = new System.Drawing.Size(100, 20);
            this.CutoffParameter.TabIndex = 19;
            // 
            // Cutoff
            // 
            this.Cutoff.AutoSize = true;
            this.Cutoff.Location = new System.Drawing.Point(288, 22);
            this.Cutoff.Name = "Cutoff";
            this.Cutoff.Size = new System.Drawing.Size(102, 13);
            this.Cutoff.TabIndex = 18;
            this.Cutoff.Text = "Set cut off value (%)";
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(727, 19);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(691, 334);
            this.zedGraphControl1.TabIndex = 17;
            // 
            // ZedIntegral
            // 
            this.ZedIntegral.Location = new System.Drawing.Point(727, 411);
            this.ZedIntegral.Name = "ZedIntegral";
            this.ZedIntegral.ScrollGrace = 0D;
            this.ZedIntegral.ScrollMaxX = 0D;
            this.ZedIntegral.ScrollMaxY = 0D;
            this.ZedIntegral.ScrollMaxY2 = 0D;
            this.ZedIntegral.ScrollMinX = 0D;
            this.ZedIntegral.ScrollMinY = 0D;
            this.ZedIntegral.ScrollMinY2 = 0D;
            this.ZedIntegral.Size = new System.Drawing.Size(691, 334);
            this.ZedIntegral.TabIndex = 16;
            // 
            // WavemeterSignal
            // 
            this.WavemeterSignal.Location = new System.Drawing.Point(6, 350);
            this.WavemeterSignal.Name = "WavemeterSignal";
            this.WavemeterSignal.ScrollGrace = 0D;
            this.WavemeterSignal.ScrollMaxX = 0D;
            this.WavemeterSignal.ScrollMaxY = 0D;
            this.WavemeterSignal.ScrollMaxY2 = 0D;
            this.WavemeterSignal.ScrollMinX = 0D;
            this.WavemeterSignal.ScrollMinY = 0D;
            this.WavemeterSignal.ScrollMinY2 = 0D;
            this.WavemeterSignal.Size = new System.Drawing.Size(500, 325);
            this.WavemeterSignal.TabIndex = 23;
            this.WavemeterSignal.ZoomStepFraction = 1D;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 709);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Initialize wavemeter -";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1993, 912);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TriggerGroup);
            this.Controls.Add(this.TestLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TriggerGroup.ResumeLayout(false);
            this.TriggerGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSlider)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackMax)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OscilInit;
        private System.Windows.Forms.GroupBox TriggerGroup;
        private ZedGraph.ZedGraphControl ZedSignal;
        private System.Windows.Forms.TrackBar TrackMin;
        private System.Windows.Forms.TrackBar TrackMax;
        private System.Windows.Forms.Label Bar1Label;
        private System.Windows.Forms.Label Bar2Label;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button WavemeterInit;
        private System.Windows.Forms.Label PathToFileLabel;
        private System.Windows.Forms.Button FindFile;
        private System.Windows.Forms.TrackBar DataSlider;
        private System.Windows.Forms.Button DeleteFrame;
        private System.Windows.Forms.Label FrameLabel;
        private System.Windows.Forms.Button PauseBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.SaveFileDialog DataSaverDialog;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.TextBox TestLabel;
        private System.Windows.Forms.Button IntegralBtn;
        private System.Windows.Forms.Button LoadData;
        private System.Windows.Forms.GroupBox groupBox1;
        private ZedGraph.ZedGraphControl OscilloSignal;
        private System.Windows.Forms.Button ShowOneInterferometer;
        private System.Windows.Forms.TextBox CutoffParameter;
        private System.Windows.Forms.Label Cutoff;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private ZedGraph.ZedGraphControl ZedIntegral;
        private System.Windows.Forms.Label label1;
        private ZedGraph.ZedGraphControl WavemeterSignal;
        private System.Windows.Forms.Label label2;
    }
}

