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
            this.button1 = new System.Windows.Forms.Button();
            this.Checkone = new System.Windows.Forms.Button();
            this.DeleteFrame = new System.Windows.Forms.Button();
            this.FrameLabel = new System.Windows.Forms.Label();
            this.DataSlider = new System.Windows.Forms.TrackBar();
            this.PathToFileLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AWinit = new System.Windows.Forms.Button();
            this.IntegralBtn = new System.Windows.Forms.Button();
            this.TestBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.ReadDataBtn = new System.Windows.Forms.Button();
            this.PauseBtn = new System.Windows.Forms.Button();
            this.StopBtn = new System.Windows.Forms.Button();
            this.StartBtn = new System.Windows.Forms.Button();
            this.LoadingData = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.WavemeterInit = new System.Windows.Forms.Button();
            this.NumOfWaveforms = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.HowManyPoints = new System.Windows.Forms.Label();
            this.NumberOfPointsBox = new System.Windows.Forms.TextBox();
            this.ChannelsOption = new System.Windows.Forms.GroupBox();
            this.SetTriggerButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TriggerVoltageBox = new System.Windows.Forms.TextBox();
            this.TriggerHisBox = new System.Windows.Forms.TextBox();
            this.HisLabel = new System.Windows.Forms.Label();
            this.LabelVol = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CH4Sig = new System.Windows.Forms.CheckBox();
            this.CH3Sig = new System.Windows.Forms.CheckBox();
            this.CH2Sig = new System.Windows.Forms.CheckBox();
            this.CH1Sig = new System.Windows.Forms.CheckBox();
            this.TriggOptions = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.EdgeOptions = new System.Windows.Forms.ComboBox();
            this.CH4Trigg = new System.Windows.Forms.RadioButton();
            this.CH3Trigg = new System.Windows.Forms.RadioButton();
            this.CH2Trigg = new System.Windows.Forms.RadioButton();
            this.CH1Trigg = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.TriggOFF = new System.Windows.Forms.RadioButton();
            this.TriggON = new System.Windows.Forms.RadioButton();
            this.Bar1Label = new System.Windows.Forms.Label();
            this.Bar2Label = new System.Windows.Forms.Label();
            this.ZedSignal = new ZedGraph.ZedGraphControl();
            this.TrackMin = new System.Windows.Forms.TrackBar();
            this.TrackMax = new System.Windows.Forms.TrackBar();
            this.Groupmeasure = new System.Windows.Forms.GroupBox();
            this.TestLabel = new System.Windows.Forms.TextBox();
            this.ZedIntegral = new ZedGraph.ZedGraphControl();
            this.DataSaverDialog = new System.Windows.Forms.SaveFileDialog();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.TriggerGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSlider)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.ChannelsOption.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.TriggOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackMax)).BeginInit();
            this.Groupmeasure.SuspendLayout();
            this.SuspendLayout();
            // 
            // OscilInit
            // 
            this.OscilInit.Location = new System.Drawing.Point(307, 10);
            this.OscilInit.Name = "OscilInit";
            this.OscilInit.Size = new System.Drawing.Size(75, 35);
            this.OscilInit.TabIndex = 0;
            this.OscilInit.Text = "Oscilloscope initialization";
            this.OscilInit.UseVisualStyleBackColor = true;
            this.OscilInit.Click += new System.EventHandler(this.button1_Click);
            // 
            // TriggerGroup
            // 
            this.TriggerGroup.Controls.Add(this.button1);
            this.TriggerGroup.Controls.Add(this.Checkone);
            this.TriggerGroup.Controls.Add(this.DeleteFrame);
            this.TriggerGroup.Controls.Add(this.FrameLabel);
            this.TriggerGroup.Controls.Add(this.DataSlider);
            this.TriggerGroup.Controls.Add(this.PathToFileLabel);
            this.TriggerGroup.Controls.Add(this.groupBox2);
            this.TriggerGroup.Controls.Add(this.ChannelsOption);
            this.TriggerGroup.Controls.Add(this.Bar1Label);
            this.TriggerGroup.Controls.Add(this.Bar2Label);
            this.TriggerGroup.Controls.Add(this.ZedSignal);
            this.TriggerGroup.Controls.Add(this.TrackMin);
            this.TriggerGroup.Controls.Add(this.TrackMax);
            this.TriggerGroup.Location = new System.Drawing.Point(12, 12);
            this.TriggerGroup.Name = "TriggerGroup";
            this.TriggerGroup.Size = new System.Drawing.Size(714, 850);
            this.TriggerGroup.TabIndex = 8;
            this.TriggerGroup.TabStop = false;
            this.TriggerGroup.Text = "Trigger control";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(507, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_3);
            // 
            // Checkone
            // 
            this.Checkone.Location = new System.Drawing.Point(617, 19);
            this.Checkone.Name = "Checkone";
            this.Checkone.Size = new System.Drawing.Size(75, 23);
            this.Checkone.TabIndex = 18;
            this.Checkone.Text = "Check signal";
            this.Checkone.UseVisualStyleBackColor = true;
            // 
            // DeleteFrame
            // 
            this.DeleteFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DeleteFrame.Location = new System.Drawing.Point(668, 557);
            this.DeleteFrame.Name = "DeleteFrame";
            this.DeleteFrame.Size = new System.Drawing.Size(43, 32);
            this.DeleteFrame.TabIndex = 15;
            this.DeleteFrame.Text = "Delete Frame";
            this.DeleteFrame.UseVisualStyleBackColor = true;
            // 
            // FrameLabel
            // 
            this.FrameLabel.AutoSize = true;
            this.FrameLabel.Location = new System.Drawing.Point(556, 568);
            this.FrameLabel.Name = "FrameLabel";
            this.FrameLabel.Size = new System.Drawing.Size(83, 13);
            this.FrameLabel.TabIndex = 14;
            this.FrameLabel.Text = "Frame number : ";
            // 
            // DataSlider
            // 
            this.DataSlider.BackColor = System.Drawing.Color.Gainsboro;
            this.DataSlider.Location = new System.Drawing.Point(13, 554);
            this.DataSlider.Maximum = 0;
            this.DataSlider.Name = "DataSlider";
            this.DataSlider.Size = new System.Drawing.Size(543, 45);
            this.DataSlider.TabIndex = 4;
            this.DataSlider.Scroll += new System.EventHandler(this.DataSlider_Scroll);
            this.DataSlider.ValueChanged += new System.EventHandler(this.DataSlider_ValueChanged);
            this.DataSlider.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DataSlider_MouseUp);
            // 
            // PathToFileLabel
            // 
            this.PathToFileLabel.AutoSize = true;
            this.PathToFileLabel.ForeColor = System.Drawing.Color.Blue;
            this.PathToFileLabel.Location = new System.Drawing.Point(6, 826);
            this.PathToFileLabel.Name = "PathToFileLabel";
            this.PathToFileLabel.Size = new System.Drawing.Size(35, 13);
            this.PathToFileLabel.TabIndex = 14;
            this.PathToFileLabel.Text = "Path: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AWinit);
            this.groupBox2.Controls.Add(this.IntegralBtn);
            this.groupBox2.Controls.Add(this.TestBtn);
            this.groupBox2.Controls.Add(this.SaveBtn);
            this.groupBox2.Controls.Add(this.ReadDataBtn);
            this.groupBox2.Controls.Add(this.PauseBtn);
            this.groupBox2.Controls.Add(this.StopBtn);
            this.groupBox2.Controls.Add(this.StartBtn);
            this.groupBox2.Controls.Add(this.LoadingData);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.WavemeterInit);
            this.groupBox2.Controls.Add(this.NumOfWaveforms);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.OscilInit);
            this.groupBox2.Controls.Add(this.HowManyPoints);
            this.groupBox2.Controls.Add(this.NumberOfPointsBox);
            this.groupBox2.Location = new System.Drawing.Point(13, 602);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(387, 210);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Experiment parameters";
            // 
            // AWinit
            // 
            this.AWinit.Location = new System.Drawing.Point(306, 91);
            this.AWinit.Name = "AWinit";
            this.AWinit.Size = new System.Drawing.Size(75, 32);
            this.AWinit.TabIndex = 19;
            this.AWinit.Text = "Ad Win Init";
            this.AWinit.UseVisualStyleBackColor = true;
            this.AWinit.Click += new System.EventHandler(this.AWinit_Click);
            // 
            // IntegralBtn
            // 
            this.IntegralBtn.Location = new System.Drawing.Point(6, 84);
            this.IntegralBtn.Name = "IntegralBtn";
            this.IntegralBtn.Size = new System.Drawing.Size(75, 39);
            this.IntegralBtn.TabIndex = 19;
            this.IntegralBtn.Text = "Calculate Integral";
            this.IntegralBtn.UseVisualStyleBackColor = true;
            this.IntegralBtn.Click += new System.EventHandler(this.IntegralBtn_Click);
            // 
            // TestBtn
            // 
            this.TestBtn.Location = new System.Drawing.Point(115, 122);
            this.TestBtn.Name = "TestBtn";
            this.TestBtn.Size = new System.Drawing.Size(75, 23);
            this.TestBtn.TabIndex = 22;
            this.TestBtn.Text = "Test";
            this.TestBtn.UseVisualStyleBackColor = true;
            this.TestBtn.Click += new System.EventHandler(this.TestBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(227, 69);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(52, 22);
            this.SaveBtn.TabIndex = 21;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // ReadDataBtn
            // 
            this.ReadDataBtn.Location = new System.Drawing.Point(9, 148);
            this.ReadDataBtn.Name = "ReadDataBtn";
            this.ReadDataBtn.Size = new System.Drawing.Size(75, 23);
            this.ReadDataBtn.TabIndex = 17;
            this.ReadDataBtn.Text = "Read Data";
            this.ReadDataBtn.UseVisualStyleBackColor = true;
            this.ReadDataBtn.Click += new System.EventHandler(this.ReadDataBtn_Click);
            // 
            // PauseBtn
            // 
            this.PauseBtn.BackColor = System.Drawing.Color.White;
            this.PauseBtn.Enabled = false;
            this.PauseBtn.Location = new System.Drawing.Point(90, 177);
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
            this.StopBtn.Location = new System.Drawing.Point(169, 177);
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
            this.StartBtn.Location = new System.Drawing.Point(9, 177);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 23);
            this.StartBtn.TabIndex = 18;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = false;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // LoadingData
            // 
            this.LoadingData.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LoadingData.Location = new System.Drawing.Point(245, 150);
            this.LoadingData.Name = "LoadingData";
            this.LoadingData.Size = new System.Drawing.Size(136, 53);
            this.LoadingData.TabIndex = 17;
            this.LoadingData.Text = "Load data to analyse";
            this.LoadingData.UseVisualStyleBackColor = true;
            this.LoadingData.Click += new System.EventHandler(this.LoadingData_Click);
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
            this.WavemeterInit.Location = new System.Drawing.Point(306, 49);
            this.WavemeterInit.Name = "WavemeterInit";
            this.WavemeterInit.Size = new System.Drawing.Size(75, 36);
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
            // ChannelsOption
            // 
            this.ChannelsOption.Controls.Add(this.SetTriggerButton);
            this.ChannelsOption.Controls.Add(this.textBox1);
            this.ChannelsOption.Controls.Add(this.label5);
            this.ChannelsOption.Controls.Add(this.TriggerVoltageBox);
            this.ChannelsOption.Controls.Add(this.TriggerHisBox);
            this.ChannelsOption.Controls.Add(this.HisLabel);
            this.ChannelsOption.Controls.Add(this.LabelVol);
            this.ChannelsOption.Controls.Add(this.groupBox1);
            this.ChannelsOption.Controls.Add(this.TriggOptions);
            this.ChannelsOption.Controls.Add(this.label1);
            this.ChannelsOption.Controls.Add(this.TriggOFF);
            this.ChannelsOption.Controls.Add(this.TriggON);
            this.ChannelsOption.Location = new System.Drawing.Point(406, 602);
            this.ChannelsOption.Name = "ChannelsOption";
            this.ChannelsOption.Size = new System.Drawing.Size(292, 242);
            this.ChannelsOption.TabIndex = 13;
            this.ChannelsOption.TabStop = false;
            this.ChannelsOption.Text = "Channel Options";
            // 
            // SetTriggerButton
            // 
            this.SetTriggerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SetTriggerButton.Location = new System.Drawing.Point(169, 215);
            this.SetTriggerButton.Name = "SetTriggerButton";
            this.SetTriggerButton.Size = new System.Drawing.Size(117, 23);
            this.SetTriggerButton.TabIndex = 14;
            this.SetTriggerButton.Text = "Set trigger param.";
            this.SetTriggerButton.UseVisualStyleBackColor = true;
            this.SetTriggerButton.Click += new System.EventHandler(this.SetTriggerButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(113, 217);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(52, 20);
            this.textBox1.TabIndex = 16;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Delay (ms)";
            // 
            // TriggerVoltageBox
            // 
            this.TriggerVoltageBox.Location = new System.Drawing.Point(113, 195);
            this.TriggerVoltageBox.Name = "TriggerVoltageBox";
            this.TriggerVoltageBox.Size = new System.Drawing.Size(52, 20);
            this.TriggerVoltageBox.TabIndex = 14;
            this.TriggerVoltageBox.Text = "1000";
            this.TriggerVoltageBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TriggerHisBox
            // 
            this.TriggerHisBox.Location = new System.Drawing.Point(231, 195);
            this.TriggerHisBox.Name = "TriggerHisBox";
            this.TriggerHisBox.Size = new System.Drawing.Size(55, 20);
            this.TriggerHisBox.TabIndex = 15;
            this.TriggerHisBox.Text = "10";
            this.TriggerHisBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // HisLabel
            // 
            this.HisLabel.AutoSize = true;
            this.HisLabel.Location = new System.Drawing.Point(166, 198);
            this.HisLabel.Name = "HisLabel";
            this.HisLabel.Size = new System.Drawing.Size(58, 13);
            this.HisLabel.TabIndex = 15;
            this.HisLabel.Text = "Trigger His";
            // 
            // LabelVol
            // 
            this.LabelVol.AutoSize = true;
            this.LabelVol.Location = new System.Drawing.Point(8, 198);
            this.LabelVol.Name = "LabelVol";
            this.LabelVol.Size = new System.Drawing.Size(103, 13);
            this.LabelVol.TabIndex = 14;
            this.LabelVol.Text = "Trigger Voltage [mV]";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CH4Sig);
            this.groupBox1.Controls.Add(this.CH3Sig);
            this.groupBox1.Controls.Add(this.CH2Sig);
            this.groupBox1.Controls.Add(this.CH1Sig);
            this.groupBox1.Location = new System.Drawing.Point(6, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 72);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Read signals from channels";
            // 
            // CH4Sig
            // 
            this.CH4Sig.AutoSize = true;
            this.CH4Sig.Location = new System.Drawing.Point(170, 49);
            this.CH4Sig.Name = "CH4Sig";
            this.CH4Sig.Size = new System.Drawing.Size(86, 17);
            this.CH4Sig.TabIndex = 3;
            this.CH4Sig.Text = "CHANNEL 4";
            this.CH4Sig.UseVisualStyleBackColor = true;
            // 
            // CH3Sig
            // 
            this.CH3Sig.AutoSize = true;
            this.CH3Sig.Location = new System.Drawing.Point(8, 49);
            this.CH3Sig.Name = "CH3Sig";
            this.CH3Sig.Size = new System.Drawing.Size(86, 17);
            this.CH3Sig.TabIndex = 2;
            this.CH3Sig.Text = "CHANNEL 3";
            this.CH3Sig.UseVisualStyleBackColor = true;
            // 
            // CH2Sig
            // 
            this.CH2Sig.AutoSize = true;
            this.CH2Sig.Location = new System.Drawing.Point(170, 19);
            this.CH2Sig.Name = "CH2Sig";
            this.CH2Sig.Size = new System.Drawing.Size(86, 17);
            this.CH2Sig.TabIndex = 1;
            this.CH2Sig.Text = "CHANNEL 2";
            this.CH2Sig.UseVisualStyleBackColor = true;
            this.CH2Sig.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // CH1Sig
            // 
            this.CH1Sig.AutoSize = true;
            this.CH1Sig.Checked = true;
            this.CH1Sig.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CH1Sig.Location = new System.Drawing.Point(8, 19);
            this.CH1Sig.Name = "CH1Sig";
            this.CH1Sig.Size = new System.Drawing.Size(86, 17);
            this.CH1Sig.TabIndex = 0;
            this.CH1Sig.Text = "CHANNEL 1";
            this.CH1Sig.UseVisualStyleBackColor = true;
            // 
            // TriggOptions
            // 
            this.TriggOptions.Controls.Add(this.label4);
            this.TriggOptions.Controls.Add(this.EdgeOptions);
            this.TriggOptions.Controls.Add(this.CH4Trigg);
            this.TriggOptions.Controls.Add(this.CH3Trigg);
            this.TriggOptions.Controls.Add(this.CH2Trigg);
            this.TriggOptions.Controls.Add(this.CH1Trigg);
            this.TriggOptions.Enabled = false;
            this.TriggOptions.Location = new System.Drawing.Point(6, 44);
            this.TriggOptions.Name = "TriggOptions";
            this.TriggOptions.Size = new System.Drawing.Size(280, 72);
            this.TriggOptions.TabIndex = 3;
            this.TriggOptions.TabStop = false;
            this.TriggOptions.Text = "Triggering Channel";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Edge";
            // 
            // EdgeOptions
            // 
            this.EdgeOptions.FormattingEnabled = true;
            this.EdgeOptions.Items.AddRange(new object[] {
            "Ascending",
            "Descending"});
            this.EdgeOptions.Location = new System.Drawing.Point(95, 38);
            this.EdgeOptions.Name = "EdgeOptions";
            this.EdgeOptions.Size = new System.Drawing.Size(67, 21);
            this.EdgeOptions.TabIndex = 15;
            this.EdgeOptions.SelectedIndexChanged += new System.EventHandler(this.EdgeOptions_SelectedIndexChanged);
            // 
            // CH4Trigg
            // 
            this.CH4Trigg.AutoSize = true;
            this.CH4Trigg.Location = new System.Drawing.Point(170, 48);
            this.CH4Trigg.Name = "CH4Trigg";
            this.CH4Trigg.Size = new System.Drawing.Size(85, 17);
            this.CH4Trigg.TabIndex = 3;
            this.CH4Trigg.TabStop = true;
            this.CH4Trigg.Text = "CHANNEL 4";
            this.CH4Trigg.UseVisualStyleBackColor = true;
            // 
            // CH3Trigg
            // 
            this.CH3Trigg.AutoSize = true;
            this.CH3Trigg.Location = new System.Drawing.Point(6, 49);
            this.CH3Trigg.Name = "CH3Trigg";
            this.CH3Trigg.Size = new System.Drawing.Size(85, 17);
            this.CH3Trigg.TabIndex = 2;
            this.CH3Trigg.TabStop = true;
            this.CH3Trigg.Text = "CHANNEL 3";
            this.CH3Trigg.UseVisualStyleBackColor = true;
            // 
            // CH2Trigg
            // 
            this.CH2Trigg.AutoSize = true;
            this.CH2Trigg.Location = new System.Drawing.Point(170, 19);
            this.CH2Trigg.Name = "CH2Trigg";
            this.CH2Trigg.Size = new System.Drawing.Size(85, 17);
            this.CH2Trigg.TabIndex = 1;
            this.CH2Trigg.TabStop = true;
            this.CH2Trigg.Text = "CHANNEL 2";
            this.CH2Trigg.UseVisualStyleBackColor = true;
            this.CH2Trigg.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // CH1Trigg
            // 
            this.CH1Trigg.AutoSize = true;
            this.CH1Trigg.Location = new System.Drawing.Point(6, 19);
            this.CH1Trigg.Name = "CH1Trigg";
            this.CH1Trigg.Size = new System.Drawing.Size(85, 17);
            this.CH1Trigg.TabIndex = 0;
            this.CH1Trigg.TabStop = true;
            this.CH1Trigg.Text = "CHANNEL 1";
            this.CH1Trigg.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(83, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "State of trigger";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // TriggOFF
            // 
            this.TriggOFF.AutoSize = true;
            this.TriggOFF.Checked = true;
            this.TriggOFF.Location = new System.Drawing.Point(231, 21);
            this.TriggOFF.Name = "TriggOFF";
            this.TriggOFF.Size = new System.Drawing.Size(45, 17);
            this.TriggOFF.TabIndex = 1;
            this.TriggOFF.TabStop = true;
            this.TriggOFF.Text = "OFF";
            this.TriggOFF.UseVisualStyleBackColor = true;
            // 
            // TriggON
            // 
            this.TriggON.AutoSize = true;
            this.TriggON.Location = new System.Drawing.Point(13, 21);
            this.TriggON.Name = "TriggON";
            this.TriggON.Size = new System.Drawing.Size(41, 17);
            this.TriggON.TabIndex = 0;
            this.TriggON.Text = "ON";
            this.TriggON.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TriggON.UseVisualStyleBackColor = true;
            this.TriggON.CheckedChanged += new System.EventHandler(this.TriggON_CheckedChanged);
            // 
            // Bar1Label
            // 
            this.Bar1Label.AutoSize = true;
            this.Bar1Label.Location = new System.Drawing.Point(673, 485);
            this.Bar1Label.Name = "Bar1Label";
            this.Bar1Label.Size = new System.Drawing.Size(9, 13);
            this.Bar1Label.TabIndex = 4;
            this.Bar1Label.Text = "l";
            // 
            // Bar2Label
            // 
            this.Bar2Label.AutoSize = true;
            this.Bar2Label.Location = new System.Drawing.Point(673, 528);
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
            this.ZedSignal.Load += new System.EventHandler(this.ZedTrigger_Load);
            // 
            // TrackMin
            // 
            this.TrackMin.Location = new System.Drawing.Point(13, 470);
            this.TrackMin.Maximum = 2047;
            this.TrackMin.Name = "TrackMin";
            this.TrackMin.Size = new System.Drawing.Size(649, 45);
            this.TrackMin.TabIndex = 9;
            this.TrackMin.Scroll += new System.EventHandler(this.TrackMin_Scroll);
            // 
            // TrackMax
            // 
            this.TrackMax.Location = new System.Drawing.Point(13, 513);
            this.TrackMax.Maximum = 2047;
            this.TrackMax.Name = "TrackMax";
            this.TrackMax.Size = new System.Drawing.Size(649, 45);
            this.TrackMax.TabIndex = 10;
            this.TrackMax.Scroll += new System.EventHandler(this.TrackMax_Scroll);
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
            this.ClientSize = new System.Drawing.Size(1483, 869);
            this.Controls.Add(this.Groupmeasure);
            this.Controls.Add(this.TriggerGroup);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TriggerGroup.ResumeLayout(false);
            this.TriggerGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSlider)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ChannelsOption.ResumeLayout(false);
            this.ChannelsOption.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TriggOptions.ResumeLayout(false);
            this.TriggOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackMax)).EndInit();
            this.Groupmeasure.ResumeLayout(false);
            this.Groupmeasure.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox ChannelsOption;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton TriggOFF;
        private System.Windows.Forms.RadioButton TriggON;
        private System.Windows.Forms.GroupBox TriggOptions;
        private System.Windows.Forms.RadioButton CH4Trigg;
        private System.Windows.Forms.RadioButton CH3Trigg;
        private System.Windows.Forms.RadioButton CH2Trigg;
        private System.Windows.Forms.RadioButton CH1Trigg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CH4Sig;
        private System.Windows.Forms.CheckBox CH3Sig;
        private System.Windows.Forms.CheckBox CH2Sig;
        private System.Windows.Forms.CheckBox CH1Sig;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox NumOfWaveforms;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button WavemeterInit;
        private System.Windows.Forms.Label PathToFileLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox EdgeOptions;
        private System.Windows.Forms.Button LoadingData;
        private System.Windows.Forms.TrackBar DataSlider;
        private System.Windows.Forms.Button DeleteFrame;
        private System.Windows.Forms.Label FrameLabel;
        private System.Windows.Forms.Button Checkone;
        private System.Windows.Forms.Button PauseBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.SaveFileDialog DataSaverDialog;
        private System.Windows.Forms.TextBox TriggerVoltageBox;
        private System.Windows.Forms.TextBox TriggerHisBox;
        private System.Windows.Forms.Label HisLabel;
        private System.Windows.Forms.Label LabelVol;
        private System.Windows.Forms.Button SetTriggerButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ReadDataBtn;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.Button TestBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.TextBox TestLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button IntegralBtn;
        private System.Windows.Forms.Button AWinit;
    }
}

