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
            this.NumOfWaveforms = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.HowManyPoints = new System.Windows.Forms.Label();
            this.NumberOfPointsBox = new System.Windows.Forms.TextBox();
            this.Bar1Label = new System.Windows.Forms.Label();
            this.Bar2Label = new System.Windows.Forms.Label();
            this.ZedSignal = new ZedGraph.ZedGraphControl();
            this.TrackMin = new System.Windows.Forms.TrackBar();
            this.TrackMax = new System.Windows.Forms.TrackBar();
            this.PathToFileLabel = new System.Windows.Forms.Label();
            this.Groupmeasure = new System.Windows.Forms.GroupBox();
            this.TestLabel = new System.Windows.Forms.TextBox();
            this.ZedIntegral = new ZedGraph.ZedGraphControl();
            this.DataSaverDialog = new System.Windows.Forms.SaveFileDialog();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.TriggerGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSlider)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackMax)).BeginInit();
            this.Groupmeasure.SuspendLayout();
            this.SuspendLayout();
            // 
            // OscilInit
            // 
            this.OscilInit.Location = new System.Drawing.Point(407, 64);
            this.OscilInit.Name = "OscilInit";
            this.OscilInit.Size = new System.Drawing.Size(88, 35);
            this.OscilInit.TabIndex = 0;
            this.OscilInit.Text = "Oscilloscope initialization";
            this.OscilInit.UseVisualStyleBackColor = true;
            this.OscilInit.Click += new System.EventHandler(this.button1_Click);
            // 
            // TriggerGroup
            // 
            this.TriggerGroup.Controls.Add(this.DeleteFrame);
            this.TriggerGroup.Controls.Add(this.FrameLabel);
            this.TriggerGroup.Controls.Add(this.DataSlider);
            this.TriggerGroup.Controls.Add(this.groupBox2);
            this.TriggerGroup.Controls.Add(this.Bar1Label);
            this.TriggerGroup.Controls.Add(this.Bar2Label);
            this.TriggerGroup.Controls.Add(this.ZedSignal);
            this.TriggerGroup.Controls.Add(this.TrackMin);
            this.TriggerGroup.Controls.Add(this.TrackMax);
            this.TriggerGroup.Location = new System.Drawing.Point(12, 12);
            this.TriggerGroup.Name = "TriggerGroup";
            this.TriggerGroup.Size = new System.Drawing.Size(714, 764);
            this.TriggerGroup.TabIndex = 8;
            this.TriggerGroup.TabStop = false;
            this.TriggerGroup.Text = "Trigger control";
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
            this.groupBox2.Controls.Add(this.IntegralBtn);
            this.groupBox2.Controls.Add(this.SaveBtn);
            this.groupBox2.Controls.Add(this.PauseBtn);
            this.groupBox2.Controls.Add(this.StopBtn);
            this.groupBox2.Controls.Add(this.StartBtn);
            this.groupBox2.Controls.Add(this.FindFile);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.WavemeterInit);
            this.groupBox2.Controls.Add(this.NumOfWaveforms);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.OscilInit);
            this.groupBox2.Controls.Add(this.HowManyPoints);
            this.groupBox2.Controls.Add(this.NumberOfPointsBox);
            this.groupBox2.Location = new System.Drawing.Point(13, 614);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(695, 131);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Experiment parameters";
            // 
            // LoadData
            // 
            this.LoadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LoadData.Location = new System.Drawing.Point(501, 11);
            this.LoadData.Name = "LoadData";
            this.LoadData.Size = new System.Drawing.Size(88, 38);
            this.LoadData.TabIndex = 19;
            this.LoadData.Text = "Load Data";
            this.LoadData.UseVisualStyleBackColor = true;
            this.LoadData.Click += new System.EventHandler(this.LoadData_Click);
            // 
            // IntegralBtn
            // 
            this.IntegralBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.IntegralBtn.Location = new System.Drawing.Point(595, 11);
            this.IntegralBtn.Name = "IntegralBtn";
            this.IntegralBtn.Size = new System.Drawing.Size(75, 39);
            this.IntegralBtn.TabIndex = 19;
            this.IntegralBtn.Text = "Calculate Integral";
            this.IntegralBtn.UseVisualStyleBackColor = true;
            this.IntegralBtn.Click += new System.EventHandler(this.IntegralBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SaveBtn.Location = new System.Drawing.Point(263, 13);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(129, 85);
            this.SaveBtn.TabIndex = 21;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // PauseBtn
            // 
            this.PauseBtn.BackColor = System.Drawing.Color.White;
            this.PauseBtn.Enabled = false;
            this.PauseBtn.Location = new System.Drawing.Point(87, 96);
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
            this.StopBtn.Location = new System.Drawing.Point(168, 97);
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
            this.StartBtn.Location = new System.Drawing.Point(6, 96);
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
            this.FindFile.Location = new System.Drawing.Point(407, 10);
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
            this.label3.Location = new System.Drawing.Point(6, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Where do you want to save measurements?";
            // 
            // WavemeterInit
            // 
            this.WavemeterInit.Location = new System.Drawing.Point(501, 63);
            this.WavemeterInit.Name = "WavemeterInit";
            this.WavemeterInit.Size = new System.Drawing.Size(88, 36);
            this.WavemeterInit.TabIndex = 15;
            this.WavemeterInit.Text = "Wavemeter Initializaction";
            this.WavemeterInit.UseVisualStyleBackColor = true;
            this.WavemeterInit.Click += new System.EventHandler(this.WavemeterInit_Click);
            // 
            // NumOfWaveforms
            // 
            this.NumOfWaveforms.Location = new System.Drawing.Point(214, 41);
            this.NumOfWaveforms.Name = "NumOfWaveforms";
            this.NumOfWaveforms.Size = new System.Drawing.Size(30, 20);
            this.NumOfWaveforms.TabIndex = 14;
            this.NumOfWaveforms.Text = "10";
            this.NumOfWaveforms.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "How many measures on one waveform?";
            // 
            // HowManyPoints
            // 
            this.HowManyPoints.AutoSize = true;
            this.HowManyPoints.Location = new System.Drawing.Point(6, 19);
            this.HowManyPoints.Name = "HowManyPoints";
            this.HowManyPoints.Size = new System.Drawing.Size(174, 13);
            this.HowManyPoints.TabIndex = 12;
            this.HowManyPoints.Text = "How many point on one waveform?";
            // 
            // NumberOfPointsBox
            // 
            this.NumberOfPointsBox.Location = new System.Drawing.Point(214, 17);
            this.NumberOfPointsBox.Name = "NumberOfPointsBox";
            this.NumberOfPointsBox.Size = new System.Drawing.Size(30, 20);
            this.NumberOfPointsBox.TabIndex = 11;
            this.NumberOfPointsBox.Text = "2048";
            this.NumberOfPointsBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumberOfPointsBox.TextChanged += new System.EventHandler(this.NumberOfPointsBox_TextChanged_1);
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
            this.PathToFileLabel.Location = new System.Drawing.Point(22, 779);
            this.PathToFileLabel.Name = "PathToFileLabel";
            this.PathToFileLabel.Size = new System.Drawing.Size(35, 13);
            this.PathToFileLabel.TabIndex = 14;
            this.PathToFileLabel.Text = "Path: ";
            // 
            // Groupmeasure
            // 
            this.Groupmeasure.Controls.Add(this.TestLabel);
            this.Groupmeasure.Controls.Add(this.ZedIntegral);
            this.Groupmeasure.Location = new System.Drawing.Point(732, 12);
            this.Groupmeasure.Name = "Groupmeasure";
            this.Groupmeasure.Size = new System.Drawing.Size(729, 764);
            this.Groupmeasure.TabIndex = 13;
            this.Groupmeasure.TabStop = false;
            this.Groupmeasure.Text = "Measured Data";
            this.Groupmeasure.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // TestLabel
            // 
            this.TestLabel.Location = new System.Drawing.Point(198, 612);
            this.TestLabel.Multiline = true;
            this.TestLabel.Name = "TestLabel";
            this.TestLabel.Size = new System.Drawing.Size(424, 146);
            this.TestLabel.TabIndex = 4;
            // 
            // ZedIntegral
            // 
            this.ZedIntegral.Location = new System.Drawing.Point(15, 19);
            this.ZedIntegral.Name = "ZedIntegral";
            this.ZedIntegral.ScrollGrace = 0D;
            this.ZedIntegral.ScrollMaxX = 0D;
            this.ZedIntegral.ScrollMaxY = 0D;
            this.ZedIntegral.ScrollMaxY2 = 0D;
            this.ZedIntegral.ScrollMinX = 0D;
            this.ZedIntegral.ScrollMinY = 0D;
            this.ZedIntegral.ScrollMinY2 = 0D;
            this.ZedIntegral.Size = new System.Drawing.Size(691, 550);
            this.ZedIntegral.TabIndex = 3;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1493, 896);
            this.Controls.Add(this.Groupmeasure);
            this.Controls.Add(this.TriggerGroup);
            this.Controls.Add(this.PathToFileLabel);
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
            this.Groupmeasure.ResumeLayout(false);
            this.Groupmeasure.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OscilInit;
        private System.Windows.Forms.GroupBox TriggerGroup;
        private ZedGraph.ZedGraphControl ZedSignal;
        private System.Windows.Forms.Label HowManyPoints;
        private System.Windows.Forms.TrackBar TrackMin;
        private System.Windows.Forms.TextBox NumberOfPointsBox;
        private System.Windows.Forms.TrackBar TrackMax;
        private System.Windows.Forms.GroupBox Groupmeasure;
        private ZedGraph.ZedGraphControl ZedIntegral;
        private System.Windows.Forms.Label Bar1Label;
        private System.Windows.Forms.Label Bar2Label;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox NumOfWaveforms;
        private System.Windows.Forms.Label label2;
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
    }
}

