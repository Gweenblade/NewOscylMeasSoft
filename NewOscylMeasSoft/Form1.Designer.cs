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
            this.InteferometerParameters = new System.Windows.Forms.Label();
            this.FrameInteferometer = new System.Windows.Forms.Label();
            this.InteferometerSlider = new System.Windows.Forms.TrackBar();
            this.ZedInteferogram = new ZedGraph.ZedGraphControl();
            this.ZedIntegral = new ZedGraph.ZedGraphControl();
            this.DeleteFrame = new System.Windows.Forms.Button();
            this.FrameLabel = new System.Windows.Forms.Label();
            this.DataSlider = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.OnlyPico = new System.Windows.Forms.Button();
            this.ReadFilesAveTB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ResultsAnalizer = new System.Windows.Forms.Button();
            this.CutoffTest = new System.Windows.Forms.Button();
            this.IgnoredColumsForData = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.IgnoredColumnsForInteferometer = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.LoadInteferometer = new System.Windows.Forms.Button();
            this.FindInterferogram = new System.Windows.Forms.Button();
            this.CutOffFunction = new System.Windows.Forms.Button();
            this.FileSeparator = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LoadData = new System.Windows.Forms.Button();
            this.CutoffTB = new System.Windows.Forms.TextBox();
            this.Cutoff = new System.Windows.Forms.Label();
            this.IntegralBtn = new System.Windows.Forms.Button();
            this.FindFile = new System.Windows.Forms.Button();
            this.Bar1Label = new System.Windows.Forms.Label();
            this.Bar2Label = new System.Windows.Forms.Label();
            this.ZedSignal = new ZedGraph.ZedGraphControl();
            this.TrackMin = new System.Windows.Forms.TrackBar();
            this.TrackMax = new System.Windows.Forms.TrackBar();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.PauseBtn = new System.Windows.Forms.Button();
            this.StopBtn = new System.Windows.Forms.Button();
            this.StartBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.WavemeterInit = new System.Windows.Forms.Button();
            this.PathToFileLabel = new System.Windows.Forms.Label();
            this.TestLabel = new System.Windows.Forms.TextBox();
            this.DataSaverDialog = new System.Windows.Forms.SaveFileDialog();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MeasurementNumberLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TriggerBtnOff = new System.Windows.Forms.RadioButton();
            this.TriggerBtnOn = new System.Windows.Forms.RadioButton();
            this.MeasuresTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AveragesTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CheckOne = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.WavemeterSignal = new ZedGraph.ZedGraphControl();
            this.label1 = new System.Windows.Forms.Label();
            this.OscilloSignal = new ZedGraph.ZedGraphControl();
            this.InteferometerPathway = new System.Windows.Forms.OpenFileDialog();
            this.CutoffSaver = new System.Windows.Forms.SaveFileDialog();
            this.ForRandomDataReads = new System.Windows.Forms.OpenFileDialog();
            this.TriggerGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InteferometerSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSlider)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackMax)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // OscilInit
            // 
            this.OscilInit.Location = new System.Drawing.Point(167, 681);
            this.OscilInit.Name = "OscilInit";
            this.OscilInit.Size = new System.Drawing.Size(138, 20);
            this.OscilInit.TabIndex = 0;
            this.OscilInit.Text = "Oscilloscope initialization";
            this.OscilInit.UseVisualStyleBackColor = true;
            this.OscilInit.Click += new System.EventHandler(this.button1_Click);
            // 
            // TriggerGroup
            // 
            this.TriggerGroup.Controls.Add(this.InteferometerParameters);
            this.TriggerGroup.Controls.Add(this.FrameInteferometer);
            this.TriggerGroup.Controls.Add(this.InteferometerSlider);
            this.TriggerGroup.Controls.Add(this.ZedInteferogram);
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
            // InteferometerParameters
            // 
            this.InteferometerParameters.AutoSize = true;
            this.InteferometerParameters.Location = new System.Drawing.Point(731, 27);
            this.InteferometerParameters.Name = "InteferometerParameters";
            this.InteferometerParameters.Size = new System.Drawing.Size(0, 13);
            this.InteferometerParameters.TabIndex = 23;
            // 
            // FrameInteferometer
            // 
            this.FrameInteferometer.AutoSize = true;
            this.FrameInteferometer.Location = new System.Drawing.Point(1179, 374);
            this.FrameInteferometer.Name = "FrameInteferometer";
            this.FrameInteferometer.Size = new System.Drawing.Size(83, 13);
            this.FrameInteferometer.TabIndex = 22;
            this.FrameInteferometer.Text = "Frame number : ";
            // 
            // InteferometerSlider
            // 
            this.InteferometerSlider.BackColor = System.Drawing.Color.Bisque;
            this.InteferometerSlider.Location = new System.Drawing.Point(729, 358);
            this.InteferometerSlider.Maximum = 0;
            this.InteferometerSlider.Name = "InteferometerSlider";
            this.InteferometerSlider.Size = new System.Drawing.Size(444, 45);
            this.InteferometerSlider.TabIndex = 21;
            this.InteferometerSlider.Scroll += new System.EventHandler(this.InteferometerSlider_Scroll);
            this.InteferometerSlider.ValueChanged += new System.EventHandler(this.InteferometerSlider_ValueChanged);
            this.InteferometerSlider.MouseUp += new System.Windows.Forms.MouseEventHandler(this.InteferometerSlider_MouseUp);
            // 
            // ZedInteferogram
            // 
            this.ZedInteferogram.Location = new System.Drawing.Point(727, 23);
            this.ZedInteferogram.Name = "ZedInteferogram";
            this.ZedInteferogram.ScrollGrace = 0D;
            this.ZedInteferogram.ScrollMaxX = 0D;
            this.ZedInteferogram.ScrollMaxY = 0D;
            this.ZedInteferogram.ScrollMaxY2 = 0D;
            this.ZedInteferogram.ScrollMinX = 0D;
            this.ZedInteferogram.ScrollMinY = 0D;
            this.ZedInteferogram.ScrollMinY2 = 0D;
            this.ZedInteferogram.Size = new System.Drawing.Size(543, 334);
            this.ZedInteferogram.TabIndex = 17;
            // 
            // ZedIntegral
            // 
            this.ZedIntegral.Location = new System.Drawing.Point(729, 409);
            this.ZedIntegral.Name = "ZedIntegral";
            this.ZedIntegral.ScrollGrace = 0D;
            this.ZedIntegral.ScrollMaxX = 0D;
            this.ZedIntegral.ScrollMaxY = 0D;
            this.ZedIntegral.ScrollMaxY2 = 0D;
            this.ZedIntegral.ScrollMinX = 0D;
            this.ZedIntegral.ScrollMinY = 0D;
            this.ZedIntegral.ScrollMinY2 = 0D;
            this.ZedIntegral.Size = new System.Drawing.Size(543, 334);
            this.ZedIntegral.TabIndex = 16;
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
            this.DataSlider.BackColor = System.Drawing.Color.Bisque;
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
            this.groupBox2.Controls.Add(this.ReadFilesAveTB);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.ResultsAnalizer);
            this.groupBox2.Controls.Add(this.CutoffTest);
            this.groupBox2.Controls.Add(this.IgnoredColumsForData);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.IgnoredColumnsForInteferometer);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.LoadInteferometer);
            this.groupBox2.Controls.Add(this.FindInterferogram);
            this.groupBox2.Controls.Add(this.CutOffFunction);
            this.groupBox2.Controls.Add(this.FileSeparator);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.LoadData);
            this.groupBox2.Controls.Add(this.CutoffTB);
            this.groupBox2.Controls.Add(this.Cutoff);
            this.groupBox2.Controls.Add(this.IntegralBtn);
            this.groupBox2.Controls.Add(this.FindFile);
            this.groupBox2.Location = new System.Drawing.Point(13, 614);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(695, 132);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File analysis parameters";
            // 
            // OnlyPico
            // 
            this.OnlyPico.Location = new System.Drawing.Point(353, 807);
            this.OnlyPico.Name = "OnlyPico";
            this.OnlyPico.Size = new System.Drawing.Size(75, 23);
            this.OnlyPico.TabIndex = 26;
            this.OnlyPico.Text = "Only Pico";
            this.OnlyPico.UseVisualStyleBackColor = true;
            this.OnlyPico.Click += new System.EventHandler(this.OnlyPico_Click);
            // 
            // ReadFilesAveTB
            // 
            this.ReadFilesAveTB.Location = new System.Drawing.Point(488, 102);
            this.ReadFilesAveTB.Name = "ReadFilesAveTB";
            this.ReadFilesAveTB.Size = new System.Drawing.Size(21, 20);
            this.ReadFilesAveTB.TabIndex = 27;
            this.ReadFilesAveTB.Text = "20";
            this.ReadFilesAveTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(331, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Number of avareges in file: ";
            // 
            // ResultsAnalizer
            // 
            this.ResultsAnalizer.Location = new System.Drawing.Point(546, 44);
            this.ResultsAnalizer.Name = "ResultsAnalizer";
            this.ResultsAnalizer.Size = new System.Drawing.Size(75, 36);
            this.ResultsAnalizer.TabIndex = 25;
            this.ResultsAnalizer.Text = "Results Analizer";
            this.ResultsAnalizer.UseVisualStyleBackColor = true;
            this.ResultsAnalizer.Click += new System.EventHandler(this.button1_Click_4);
            // 
            // CutoffTest
            // 
            this.CutoffTest.Location = new System.Drawing.Point(546, 17);
            this.CutoffTest.Name = "CutoffTest";
            this.CutoffTest.Size = new System.Drawing.Size(75, 23);
            this.CutoffTest.TabIndex = 26;
            this.CutoffTest.Text = "CutoffTest";
            this.CutoffTest.UseVisualStyleBackColor = true;
            this.CutoffTest.Click += new System.EventHandler(this.CutoffTest_Click);
            // 
            // IgnoredColumsForData
            // 
            this.IgnoredColumsForData.Location = new System.Drawing.Point(488, 61);
            this.IgnoredColumsForData.Name = "IgnoredColumsForData";
            this.IgnoredColumsForData.Size = new System.Drawing.Size(21, 20);
            this.IgnoredColumsForData.TabIndex = 32;
            this.IgnoredColumsForData.Text = "0";
            this.IgnoredColumsForData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(332, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Ignored columns (Data):";
            // 
            // IgnoredColumnsForInteferometer
            // 
            this.IgnoredColumnsForInteferometer.Location = new System.Drawing.Point(488, 82);
            this.IgnoredColumnsForInteferometer.Name = "IgnoredColumnsForInteferometer";
            this.IgnoredColumnsForInteferometer.Size = new System.Drawing.Size(21, 20);
            this.IgnoredColumnsForInteferometer.TabIndex = 30;
            this.IgnoredColumnsForInteferometer.Text = "0";
            this.IgnoredColumnsForInteferometer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(332, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Ignored columns (Inteferometer):";
            // 
            // LoadInteferometer
            // 
            this.LoadInteferometer.Enabled = false;
            this.LoadInteferometer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LoadInteferometer.Location = new System.Drawing.Point(118, 64);
            this.LoadInteferometer.Name = "LoadInteferometer";
            this.LoadInteferometer.Size = new System.Drawing.Size(97, 39);
            this.LoadInteferometer.TabIndex = 28;
            this.LoadInteferometer.Text = "Load Inteferogram";
            this.LoadInteferometer.UseVisualStyleBackColor = true;
            this.LoadInteferometer.Click += new System.EventHandler(this.Button2_Click_1);
            // 
            // FindInterferogram
            // 
            this.FindInterferogram.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FindInterferogram.Location = new System.Drawing.Point(6, 64);
            this.FindInterferogram.Name = "FindInterferogram";
            this.FindInterferogram.Size = new System.Drawing.Size(110, 39);
            this.FindInterferogram.TabIndex = 27;
            this.FindInterferogram.Text = "Find Interferogram";
            this.FindInterferogram.UseVisualStyleBackColor = true;
            this.FindInterferogram.Click += new System.EventHandler(this.FindInterferogram_Click);
            // 
            // CutOffFunction
            // 
            this.CutOffFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CutOffFunction.Location = new System.Drawing.Point(221, 64);
            this.CutOffFunction.Name = "CutOffFunction";
            this.CutOffFunction.Size = new System.Drawing.Size(105, 39);
            this.CutOffFunction.TabIndex = 26;
            this.CutOffFunction.Text = "Aply cutoff";
            this.CutOffFunction.UseVisualStyleBackColor = true;
            this.CutOffFunction.Click += new System.EventHandler(this.CutOffFunction_Click);
            // 
            // FileSeparator
            // 
            this.FileSeparator.Location = new System.Drawing.Point(488, 40);
            this.FileSeparator.Name = "FileSeparator";
            this.FileSeparator.Size = new System.Drawing.Size(21, 20);
            this.FileSeparator.TabIndex = 21;
            this.FileSeparator.Text = ":";
            this.FileSeparator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(332, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Data separator in file";
            // 
            // LoadData
            // 
            this.LoadData.Enabled = false;
            this.LoadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LoadData.Location = new System.Drawing.Point(118, 19);
            this.LoadData.Name = "LoadData";
            this.LoadData.Size = new System.Drawing.Size(97, 39);
            this.LoadData.TabIndex = 19;
            this.LoadData.Text = "Load Data";
            this.LoadData.UseVisualStyleBackColor = true;
            this.LoadData.Click += new System.EventHandler(this.LoadData_Click);
            // 
            // CutoffTB
            // 
            this.CutoffTB.Location = new System.Drawing.Point(488, 19);
            this.CutoffTB.Name = "CutoffTB";
            this.CutoffTB.Size = new System.Drawing.Size(21, 20);
            this.CutoffTB.TabIndex = 19;
            this.CutoffTB.Text = "5";
            this.CutoffTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Cutoff
            // 
            this.Cutoff.AutoSize = true;
            this.Cutoff.Location = new System.Drawing.Point(332, 22);
            this.Cutoff.Name = "Cutoff";
            this.Cutoff.Size = new System.Drawing.Size(102, 13);
            this.Cutoff.TabIndex = 18;
            this.Cutoff.Text = "Set cut off value (%)";
            // 
            // IntegralBtn
            // 
            this.IntegralBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.IntegralBtn.Location = new System.Drawing.Point(221, 19);
            this.IntegralBtn.Name = "IntegralBtn";
            this.IntegralBtn.Size = new System.Drawing.Size(105, 39);
            this.IntegralBtn.TabIndex = 19;
            this.IntegralBtn.Text = "Calculate Integral";
            this.IntegralBtn.UseVisualStyleBackColor = true;
            this.IntegralBtn.Click += new System.EventHandler(this.IntegralBtn_Click);
            // 
            // FindFile
            // 
            this.FindFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FindFile.Location = new System.Drawing.Point(6, 19);
            this.FindFile.Name = "FindFile";
            this.FindFile.Size = new System.Drawing.Size(110, 39);
            this.FindFile.TabIndex = 17;
            this.FindFile.Text = "Find File";
            this.FindFile.UseVisualStyleBackColor = true;
            this.FindFile.Click += new System.EventHandler(this.FindFile_Click);
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
            this.TrackMin.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.TrackMin.Location = new System.Drawing.Point(13, 471);
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
            this.TrackMax.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.TrackMax.Location = new System.Drawing.Point(13, 514);
            this.TrackMax.Maximum = 2046;
            this.TrackMax.Minimum = 1;
            this.TrackMax.Name = "TrackMax";
            this.TrackMax.Size = new System.Drawing.Size(649, 45);
            this.TrackMax.TabIndex = 10;
            this.TrackMax.Value = 1;
            this.TrackMax.Scroll += new System.EventHandler(this.TrackMax_Scroll);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SaveBtn.Location = new System.Drawing.Point(167, 729);
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
            this.PauseBtn.Location = new System.Drawing.Point(89, 807);
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
            this.StopBtn.Location = new System.Drawing.Point(170, 807);
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
            this.StartBtn.Location = new System.Drawing.Point(8, 807);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 23);
            this.StartBtn.TabIndex = 18;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = false;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
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
            this.WavemeterInit.Enabled = false;
            this.WavemeterInit.Location = new System.Drawing.Point(168, 705);
            this.WavemeterInit.Name = "WavemeterInit";
            this.WavemeterInit.Size = new System.Drawing.Size(138, 20);
            this.WavemeterInit.TabIndex = 15;
            this.WavemeterInit.Text = "Wavemeter Initializaction";
            this.WavemeterInit.UseVisualStyleBackColor = true;
            this.WavemeterInit.Click += new System.EventHandler(this.WavemeterInit_Click);
            // 
            // PathToFileLabel
            // 
            this.PathToFileLabel.AutoSize = true;
            this.PathToFileLabel.ForeColor = System.Drawing.Color.Blue;
            this.PathToFileLabel.Location = new System.Drawing.Point(10, 833);
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
            this.TestLabel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
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
            this.groupBox1.Controls.Add(this.OnlyPico);
            this.groupBox1.Controls.Add(this.MeasurementNumberLabel);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.MeasuresTB);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.AveragesTB);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.CheckOne);
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
            // MeasurementNumberLabel
            // 
            this.MeasurementNumberLabel.AutoSize = true;
            this.MeasurementNumberLabel.Location = new System.Drawing.Point(350, 27);
            this.MeasurementNumberLabel.Name = "MeasurementNumberLabel";
            this.MeasurementNumberLabel.Size = new System.Drawing.Size(110, 13);
            this.MeasurementNumberLabel.TabIndex = 24;
            this.MeasurementNumberLabel.Text = "Number of measures: ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TriggerBtnOff);
            this.groupBox3.Controls.Add(this.TriggerBtnOn);
            this.groupBox3.Location = new System.Drawing.Point(308, 681);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(188, 44);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Trigger";
            // 
            // TriggerBtnOff
            // 
            this.TriggerBtnOff.AutoSize = true;
            this.TriggerBtnOff.Checked = true;
            this.TriggerBtnOff.Location = new System.Drawing.Point(103, 18);
            this.TriggerBtnOff.Name = "TriggerBtnOff";
            this.TriggerBtnOff.Size = new System.Drawing.Size(73, 17);
            this.TriggerBtnOff.TabIndex = 1;
            this.TriggerBtnOff.TabStop = true;
            this.TriggerBtnOff.Text = "Trigger off";
            this.TriggerBtnOff.UseVisualStyleBackColor = true;
            // 
            // TriggerBtnOn
            // 
            this.TriggerBtnOn.AutoSize = true;
            this.TriggerBtnOn.Location = new System.Drawing.Point(12, 18);
            this.TriggerBtnOn.Name = "TriggerBtnOn";
            this.TriggerBtnOn.Size = new System.Drawing.Size(73, 17);
            this.TriggerBtnOn.TabIndex = 0;
            this.TriggerBtnOn.Text = "Trigger on";
            this.TriggerBtnOn.UseVisualStyleBackColor = true;
            this.TriggerBtnOn.CheckedChanged += new System.EventHandler(this.TriggerBtnOn_CheckedChanged);
            // 
            // MeasuresTB
            // 
            this.MeasuresTB.Location = new System.Drawing.Point(168, 754);
            this.MeasuresTB.Name = "MeasuresTB";
            this.MeasuresTB.Size = new System.Drawing.Size(100, 20);
            this.MeasuresTB.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 757);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Number of measurement points";
            // 
            // AveragesTB
            // 
            this.AveragesTB.Location = new System.Drawing.Point(168, 778);
            this.AveragesTB.Name = "AveragesTB";
            this.AveragesTB.Size = new System.Drawing.Size(100, 20);
            this.AveragesTB.TabIndex = 26;
            this.AveragesTB.TextChanged += new System.EventHandler(this.AveragesTB_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 781);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Number of averages -";
            // 
            // CheckOne
            // 
            this.CheckOne.Location = new System.Drawing.Point(311, 729);
            this.CheckOne.Name = "CheckOne";
            this.CheckOne.Size = new System.Drawing.Size(75, 21);
            this.CheckOne.TabIndex = 16;
            this.CheckOne.Text = "Check one";
            this.CheckOne.UseVisualStyleBackColor = true;
            this.CheckOne.Click += new System.EventHandler(this.CheckOne_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 733);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Choose file for data -";
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
            // InteferometerPathway
            // 
            this.InteferometerPathway.FileName = "openFileDialog1";
            this.InteferometerPathway.FileOk += new System.ComponentModel.CancelEventHandler(this.InteferometerPathway_FileOk);
            // 
            // ForRandomDataReads
            // 
            this.ForRandomDataReads.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1825, 912);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TriggerGroup);
            this.Controls.Add(this.TestLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TriggerGroup.ResumeLayout(false);
            this.TriggerGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InteferometerSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSlider)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackMax)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.TextBox CutoffTB;
        private System.Windows.Forms.Label Cutoff;
        private ZedGraph.ZedGraphControl ZedInteferogram;
        private ZedGraph.ZedGraphControl ZedIntegral;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ResultsAnalizer;
        public ZedGraph.ZedGraphControl OscilloSignal;
        public ZedGraph.ZedGraphControl WavemeterSignal;
        private System.Windows.Forms.Button CheckOne;
        private System.Windows.Forms.TextBox AveragesTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox MeasuresTB;
        private System.Windows.Forms.TextBox FileSeparator;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button CutOffFunction;
        private System.Windows.Forms.Button LoadInteferometer;
        private System.Windows.Forms.Button FindInterferogram;
        private System.Windows.Forms.OpenFileDialog InteferometerPathway;
        private System.Windows.Forms.TrackBar InteferometerSlider;
        private System.Windows.Forms.Label FrameInteferometer;
        private System.Windows.Forms.TextBox IgnoredColumnsForInteferometer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox IgnoredColumsForData;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label InteferometerParameters;
        private System.Windows.Forms.SaveFileDialog CutoffSaver;
        private System.Windows.Forms.Button CutoffTest;
        private System.Windows.Forms.OpenFileDialog ForRandomDataReads;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton TriggerBtnOff;
        private System.Windows.Forms.RadioButton TriggerBtnOn;
        private System.Windows.Forms.Button OnlyPico;
        private System.Windows.Forms.Label MeasurementNumberLabel;
        private System.Windows.Forms.TextBox ReadFilesAveTB;
        private System.Windows.Forms.Label label9;
    }
}

