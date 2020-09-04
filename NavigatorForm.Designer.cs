namespace SuperNavigator
{
    partial class NavigatorForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Set_USV_Directory = new System.Windows.Forms.Button();
            this.btn_Set_Working_Directory = new System.Windows.Forms.Button();
            this.btnOpenWorkDir = new System.Windows.Forms.Button();
            this.btn_Set_KTViz_Directory = new System.Windows.Forms.Button();
            this.tb_ktviz_dir = new System.Windows.Forms.TextBox();
            this.tb_working_dir = new System.Windows.Forms.TextBox();
            this.tb_usv_dir = new System.Windows.Forms.TextBox();
            this.labelKtvizDir = new System.Windows.Forms.Label();
            this.labelWorkDir = new System.Windows.Forms.Label();
            this.labelExecPath = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.cb_ongoing = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rb_rvo = new System.Windows.Forms.RadioButton();
            this.rb_base = new System.Windows.Forms.RadioButton();
            this.btn_auto_test = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rb_pred_none = new System.Windows.Forms.RadioButton();
            this.rb_pred_simple = new System.Windows.Forms.RadioButton();
            this.rb_pred_full = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_WorkStart = new System.Windows.Forms.Button();
            this.btn_Work_Stop = new System.Windows.Forms.Button();
            this.btn_toInit = new System.Windows.Forms.Button();
            this.btn_backup = new System.Windows.Forms.Button();
            this.btn_RunViz = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tb_output = new System.Windows.Forms.TextBox();
            this.tabPageViz = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.progressBarViz = new System.Windows.Forms.ProgressBar();
            this.pb_Viz = new System.Windows.Forms.PictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.track_images = new System.Windows.Forms.TrackBar();
            this.panel_debug = new System.Windows.Forms.Panel();
            this.btn_analyze = new System.Windows.Forms.Button();
            this.btn_realTargets = new System.Windows.Forms.Button();
            this.btn_maneuver = new System.Windows.Forms.Button();
            this.btn_follow_route = new System.Windows.Forms.Button();
            this.btn_follow_ongoing = new System.Windows.Forms.Button();
            this.panel_simulate = new System.Windows.Forms.Panel();
            this.btn_Simulate = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.NUD_timeStep = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPageViz.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Viz)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track_images)).BeginInit();
            this.panel_debug.SuspendLayout();
            this.panel_simulate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_timeStep)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Size = new System.Drawing.Size(632, 467);
            this.splitContainer1.SplitterDistance = 75;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_Set_USV_Directory);
            this.panel2.Controls.Add(this.btn_Set_Working_Directory);
            this.panel2.Controls.Add(this.btnOpenWorkDir);
            this.panel2.Controls.Add(this.btn_Set_KTViz_Directory);
            this.panel2.Controls.Add(this.tb_ktviz_dir);
            this.panel2.Controls.Add(this.tb_working_dir);
            this.panel2.Controls.Add(this.tb_usv_dir);
            this.panel2.Controls.Add(this.labelKtvizDir);
            this.panel2.Controls.Add(this.labelWorkDir);
            this.panel2.Controls.Add(this.labelExecPath);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(630, 75);
            this.panel2.TabIndex = 5;
            // 
            // btn_Set_USV_Directory
            // 
            this.btn_Set_USV_Directory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Set_USV_Directory.Location = new System.Drawing.Point(497, 3);
            this.btn_Set_USV_Directory.Name = "btn_Set_USV_Directory";
            this.btn_Set_USV_Directory.Size = new System.Drawing.Size(80, 20);
            this.btn_Set_USV_Directory.TabIndex = 0;
            this.btn_Set_USV_Directory.Text = "Browse...";
            this.btn_Set_USV_Directory.UseVisualStyleBackColor = true;
            this.btn_Set_USV_Directory.Click += new System.EventHandler(this.btn_Set_USV_Directory_Click);
            // 
            // btn_Set_Working_Directory
            // 
            this.btn_Set_Working_Directory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Set_Working_Directory.Location = new System.Drawing.Point(497, 25);
            this.btn_Set_Working_Directory.Name = "btn_Set_Working_Directory";
            this.btn_Set_Working_Directory.Size = new System.Drawing.Size(80, 20);
            this.btn_Set_Working_Directory.TabIndex = 1;
            this.btn_Set_Working_Directory.Text = "Browse...";
            this.btn_Set_Working_Directory.UseVisualStyleBackColor = true;
            this.btn_Set_Working_Directory.Click += new System.EventHandler(this.btn_Set_Working_Directory_Click);
            // 
            // btnOpenWorkDir
            // 
            this.btnOpenWorkDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenWorkDir.Location = new System.Drawing.Point(580, 25);
            this.btnOpenWorkDir.Name = "btnOpenWorkDir";
            this.btnOpenWorkDir.Size = new System.Drawing.Size(43, 20);
            this.btnOpenWorkDir.TabIndex = 3;
            this.btnOpenWorkDir.Text = "Open";
            this.btnOpenWorkDir.UseVisualStyleBackColor = true;
            this.btnOpenWorkDir.Click += new System.EventHandler(this.btnOpenWorkDir_Click);
            // 
            // btn_Set_KTViz_Directory
            // 
            this.btn_Set_KTViz_Directory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Set_KTViz_Directory.Location = new System.Drawing.Point(497, 47);
            this.btn_Set_KTViz_Directory.Name = "btn_Set_KTViz_Directory";
            this.btn_Set_KTViz_Directory.Size = new System.Drawing.Size(80, 20);
            this.btn_Set_KTViz_Directory.TabIndex = 2;
            this.btn_Set_KTViz_Directory.Text = "Browse...";
            this.btn_Set_KTViz_Directory.UseVisualStyleBackColor = true;
            this.btn_Set_KTViz_Directory.Click += new System.EventHandler(this.btn_Set_KTViz_Directory_Click);
            // 
            // tb_ktviz_dir
            // 
            this.tb_ktviz_dir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_ktviz_dir.Location = new System.Drawing.Point(99, 47);
            this.tb_ktviz_dir.Name = "tb_ktviz_dir";
            this.tb_ktviz_dir.ReadOnly = true;
            this.tb_ktviz_dir.Size = new System.Drawing.Size(392, 20);
            this.tb_ktviz_dir.TabIndex = 2;
            // 
            // tb_working_dir
            // 
            this.tb_working_dir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_working_dir.Location = new System.Drawing.Point(99, 25);
            this.tb_working_dir.Name = "tb_working_dir";
            this.tb_working_dir.ReadOnly = true;
            this.tb_working_dir.Size = new System.Drawing.Size(392, 20);
            this.tb_working_dir.TabIndex = 1;
            // 
            // tb_usv_dir
            // 
            this.tb_usv_dir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_usv_dir.Location = new System.Drawing.Point(99, 3);
            this.tb_usv_dir.Name = "tb_usv_dir";
            this.tb_usv_dir.ReadOnly = true;
            this.tb_usv_dir.Size = new System.Drawing.Size(392, 20);
            this.tb_usv_dir.TabIndex = 0;
            // 
            // labelKtvizDir
            // 
            this.labelKtvizDir.Location = new System.Drawing.Point(3, 47);
            this.labelKtvizDir.Name = "labelKtvizDir";
            this.labelKtvizDir.Size = new System.Drawing.Size(97, 20);
            this.labelKtvizDir.TabIndex = 6;
            this.labelKtvizDir.Text = "KTViz Directory";
            this.labelKtvizDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelWorkDir
            // 
            this.labelWorkDir.Location = new System.Drawing.Point(3, 25);
            this.labelWorkDir.Name = "labelWorkDir";
            this.labelWorkDir.Size = new System.Drawing.Size(97, 20);
            this.labelWorkDir.TabIndex = 5;
            this.labelWorkDir.Text = "Working Directory";
            this.labelWorkDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelExecPath
            // 
            this.labelExecPath.Location = new System.Drawing.Point(8, 3);
            this.labelExecPath.Name = "labelExecPath";
            this.labelExecPath.Size = new System.Drawing.Size(92, 20);
            this.labelExecPath.TabIndex = 4;
            this.labelExecPath.Text = "USV Executable";
            this.labelExecPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(2, 2);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.NUD_timeStep);
            this.splitContainer3.Panel1.Controls.Add(this.cb_ongoing);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            this.splitContainer3.Panel1.Controls.Add(this.panel5);
            this.splitContainer3.Panel1.Controls.Add(this.btn_auto_test);
            this.splitContainer3.Panel1.Controls.Add(this.panel1);
            this.splitContainer3.Panel1.Controls.Add(this.panel3);
            this.splitContainer3.Panel1MinSize = 150;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer3.Size = new System.Drawing.Size(626, 385);
            this.splitContainer3.SplitterDistance = 150;
            this.splitContainer3.TabIndex = 9;
            // 
            // cb_ongoing
            // 
            this.cb_ongoing.AutoSize = true;
            this.cb_ongoing.Checked = true;
            this.cb_ongoing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_ongoing.Location = new System.Drawing.Point(9, 129);
            this.cb_ongoing.Name = "cb_ongoing";
            this.cb_ongoing.Size = new System.Drawing.Size(135, 17);
            this.cb_ongoing.TabIndex = 18;
            this.cb_ongoing.Text = "-ongoing for -maneuver";
            this.cb_ongoing.UseVisualStyleBackColor = true;
            this.cb_ongoing.CheckedChanged += new System.EventHandler(this.cb_ongoing_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "timeStep";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.rb_rvo);
            this.panel5.Controls.Add(this.rb_base);
            this.panel5.Location = new System.Drawing.Point(9, 82);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(96, 41);
            this.panel5.TabIndex = 20;
            // 
            // rb_rvo
            // 
            this.rb_rvo.AutoSize = true;
            this.rb_rvo.Location = new System.Drawing.Point(3, 2);
            this.rb_rvo.Name = "rb_rvo";
            this.rb_rvo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rb_rvo.Size = new System.Drawing.Size(78, 17);
            this.rb_rvo.TabIndex = 11;
            this.rb_rvo.Text = "prefer RVO";
            this.rb_rvo.UseVisualStyleBackColor = true;
            this.rb_rvo.Click += new System.EventHandler(this.rb_prefer_CheckedChanged);
            // 
            // rb_base
            // 
            this.rb_base.AutoSize = true;
            this.rb_base.Checked = true;
            this.rb_base.Location = new System.Drawing.Point(3, 22);
            this.rb_base.Name = "rb_base";
            this.rb_base.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rb_base.Size = new System.Drawing.Size(79, 17);
            this.rb_base.TabIndex = 12;
            this.rb_base.TabStop = true;
            this.rb_base.Text = "prefer Base";
            this.rb_base.UseVisualStyleBackColor = true;
            this.rb_base.CheckedChanged += new System.EventHandler(this.rb_prefer_CheckedChanged);
            // 
            // btn_auto_test
            // 
            this.btn_auto_test.Location = new System.Drawing.Point(9, 198);
            this.btn_auto_test.Name = "btn_auto_test";
            this.btn_auto_test.Size = new System.Drawing.Size(128, 23);
            this.btn_auto_test.TabIndex = 4;
            this.btn_auto_test.Text = "Auto Test";
            this.btn_auto_test.UseVisualStyleBackColor = true;
            this.btn_auto_test.Click += new System.EventHandler(this.btn_auto_test_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rb_pred_none);
            this.panel1.Controls.Add(this.rb_pred_simple);
            this.panel1.Controls.Add(this.rb_pred_full);
            this.panel1.Location = new System.Drawing.Point(9, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(96, 54);
            this.panel1.TabIndex = 19;
            // 
            // rb_pred_none
            // 
            this.rb_pred_none.AutoSize = true;
            this.rb_pred_none.Location = new System.Drawing.Point(3, 37);
            this.rb_pred_none.Name = "rb_pred_none";
            this.rb_pred_none.Size = new System.Drawing.Size(86, 17);
            this.rb_pred_none.TabIndex = 2;
            this.rb_pred_none.Text = "no prediction";
            this.rb_pred_none.UseVisualStyleBackColor = true;
            this.rb_pred_none.CheckedChanged += new System.EventHandler(this.predictionChanged);
            // 
            // rb_pred_simple
            // 
            this.rb_pred_simple.AutoSize = true;
            this.rb_pred_simple.Location = new System.Drawing.Point(3, 20);
            this.rb_pred_simple.Name = "rb_pred_simple";
            this.rb_pred_simple.Size = new System.Drawing.Size(54, 17);
            this.rb_pred_simple.TabIndex = 1;
            this.rb_pred_simple.Text = "simple";
            this.rb_pred_simple.UseVisualStyleBackColor = true;
            this.rb_pred_simple.CheckedChanged += new System.EventHandler(this.predictionChanged);
            // 
            // rb_pred_full
            // 
            this.rb_pred_full.AutoSize = true;
            this.rb_pred_full.Checked = true;
            this.rb_pred_full.Location = new System.Drawing.Point(3, 3);
            this.rb_pred_full.Name = "rb_pred_full";
            this.rb_pred_full.Size = new System.Drawing.Size(87, 17);
            this.rb_pred_full.TabIndex = 0;
            this.rb_pred_full.TabStop = true;
            this.rb_pred_full.Text = "full prediction";
            this.rb_pred_full.UseVisualStyleBackColor = true;
            this.rb_pred_full.CheckedChanged += new System.EventHandler(this.predictionChanged);
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.btn_WorkStart);
            this.panel3.Controls.Add(this.btn_Work_Stop);
            this.panel3.Controls.Add(this.btn_toInit);
            this.panel3.Controls.Add(this.btn_backup);
            this.panel3.Controls.Add(this.btn_RunViz);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 270);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(150, 115);
            this.panel3.TabIndex = 3;
            // 
            // btn_WorkStart
            // 
            this.btn_WorkStart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_WorkStart.Location = new System.Drawing.Point(0, 0);
            this.btn_WorkStart.Name = "btn_WorkStart";
            this.btn_WorkStart.Size = new System.Drawing.Size(150, 23);
            this.btn_WorkStart.TabIndex = 10;
            this.btn_WorkStart.Text = "Work Start";
            this.btn_WorkStart.UseVisualStyleBackColor = true;
            this.btn_WorkStart.Click += new System.EventHandler(this.startFileWorker);
            // 
            // btn_Work_Stop
            // 
            this.btn_Work_Stop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_Work_Stop.Location = new System.Drawing.Point(0, 23);
            this.btn_Work_Stop.Name = "btn_Work_Stop";
            this.btn_Work_Stop.Size = new System.Drawing.Size(150, 23);
            this.btn_Work_Stop.TabIndex = 11;
            this.btn_Work_Stop.Text = "Work Stop";
            this.btn_Work_Stop.UseVisualStyleBackColor = true;
            this.btn_Work_Stop.Click += new System.EventHandler(this.btn_Work_Stop_Click);
            // 
            // btn_toInit
            // 
            this.btn_toInit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_toInit.Enabled = false;
            this.btn_toInit.Location = new System.Drawing.Point(0, 46);
            this.btn_toInit.Name = "btn_toInit";
            this.btn_toInit.Size = new System.Drawing.Size(150, 23);
            this.btn_toInit.TabIndex = 9;
            this.btn_toInit.Text = "Return to Init State";
            this.btn_toInit.UseVisualStyleBackColor = true;
            this.btn_toInit.Click += new System.EventHandler(this.btn_toInit_Click);
            // 
            // btn_backup
            // 
            this.btn_backup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_backup.Enabled = false;
            this.btn_backup.Location = new System.Drawing.Point(0, 69);
            this.btn_backup.Name = "btn_backup";
            this.btn_backup.Size = new System.Drawing.Size(150, 23);
            this.btn_backup.TabIndex = 8;
            this.btn_backup.Text = "Save Current as Init State";
            this.btn_backup.UseVisualStyleBackColor = true;
            this.btn_backup.Click += new System.EventHandler(this.btn_backup_Click);
            // 
            // btn_RunViz
            // 
            this.btn_RunViz.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_RunViz.Location = new System.Drawing.Point(0, 92);
            this.btn_RunViz.Name = "btn_RunViz";
            this.btn_RunViz.Size = new System.Drawing.Size(150, 23);
            this.btn_RunViz.TabIndex = 2;
            this.btn_RunViz.Text = "KTViz";
            this.btn_RunViz.UseVisualStyleBackColor = true;
            this.btn_RunViz.Click += new System.EventHandler(this.btn_RunViz_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tabControl);
            this.splitContainer2.Panel1MinSize = 150;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel_debug);
            this.splitContainer2.Panel2.Controls.Add(this.panel_simulate);
            this.splitContainer2.Panel2MinSize = 100;
            this.splitContainer2.Size = new System.Drawing.Size(472, 385);
            this.splitContainer2.SplitterDistance = 281;
            this.splitContainer2.TabIndex = 10;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPageViz);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(472, 281);
            this.tabControl.TabIndex = 9;
            this.tabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tb_output);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(464, 255);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Output";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tb_output
            // 
            this.tb_output.BackColor = System.Drawing.SystemColors.Window;
            this.tb_output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_output.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tb_output.Location = new System.Drawing.Point(3, 3);
            this.tb_output.Multiline = true;
            this.tb_output.Name = "tb_output";
            this.tb_output.ReadOnly = true;
            this.tb_output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_output.Size = new System.Drawing.Size(458, 249);
            this.tb_output.TabIndex = 8;
            // 
            // tabPageViz
            // 
            this.tabPageViz.Controls.Add(this.panel4);
            this.tabPageViz.Controls.Add(this.panel6);
            this.tabPageViz.Location = new System.Drawing.Point(4, 22);
            this.tabPageViz.Name = "tabPageViz";
            this.tabPageViz.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageViz.Size = new System.Drawing.Size(464, 255);
            this.tabPageViz.TabIndex = 1;
            this.tabPageViz.Text = "Viz";
            this.tabPageViz.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.progressBarViz);
            this.panel4.Controls.Add(this.pb_Viz);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(458, 221);
            this.panel4.TabIndex = 2;
            // 
            // progressBarViz
            // 
            this.progressBarViz.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBarViz.Location = new System.Drawing.Point(133, 101);
            this.progressBarViz.MarqueeAnimationSpeed = 5;
            this.progressBarViz.Maximum = 20;
            this.progressBarViz.Name = "progressBarViz";
            this.progressBarViz.Size = new System.Drawing.Size(181, 23);
            this.progressBarViz.Step = 1;
            this.progressBarViz.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarViz.TabIndex = 2;
            this.progressBarViz.Visible = false;
            // 
            // pb_Viz
            // 
            this.pb_Viz.BackColor = System.Drawing.Color.Transparent;
            this.pb_Viz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_Viz.Location = new System.Drawing.Point(0, 0);
            this.pb_Viz.Name = "pb_Viz";
            this.pb_Viz.Size = new System.Drawing.Size(458, 221);
            this.pb_Viz.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Viz.TabIndex = 0;
            this.pb_Viz.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.track_images);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(3, 224);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(458, 28);
            this.panel6.TabIndex = 1;
            // 
            // track_images
            // 
            this.track_images.AutoSize = false;
            this.track_images.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.track_images.Location = new System.Drawing.Point(0, 1);
            this.track_images.Maximum = 0;
            this.track_images.Name = "track_images";
            this.track_images.Size = new System.Drawing.Size(458, 27);
            this.track_images.TabIndex = 2;
            this.track_images.Visible = false;
            this.track_images.ValueChanged += new System.EventHandler(this.track_images_ValueChanged);
            // 
            // panel_debug
            // 
            this.panel_debug.Controls.Add(this.btn_analyze);
            this.panel_debug.Controls.Add(this.btn_realTargets);
            this.panel_debug.Controls.Add(this.btn_maneuver);
            this.panel_debug.Controls.Add(this.btn_follow_route);
            this.panel_debug.Controls.Add(this.btn_follow_ongoing);
            this.panel_debug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_debug.Enabled = false;
            this.panel_debug.Location = new System.Drawing.Point(0, 0);
            this.panel_debug.Name = "panel_debug";
            this.panel_debug.Size = new System.Drawing.Size(226, 100);
            this.panel_debug.TabIndex = 11;
            // 
            // btn_analyze
            // 
            this.btn_analyze.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_analyze.Location = new System.Drawing.Point(0, 80);
            this.btn_analyze.Name = "btn_analyze";
            this.btn_analyze.Size = new System.Drawing.Size(226, 20);
            this.btn_analyze.TabIndex = 7;
            this.btn_analyze.Text = "analyze";
            this.btn_analyze.UseVisualStyleBackColor = true;
            this.btn_analyze.Click += new System.EventHandler(this.btn_analyze_Click);
            // 
            // btn_realTargets
            // 
            this.btn_realTargets.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_realTargets.Location = new System.Drawing.Point(0, 60);
            this.btn_realTargets.Name = "btn_realTargets";
            this.btn_realTargets.Size = new System.Drawing.Size(226, 20);
            this.btn_realTargets.TabIndex = 15;
            this.btn_realTargets.Text = "real targets";
            this.btn_realTargets.UseVisualStyleBackColor = true;
            this.btn_realTargets.Click += new System.EventHandler(this.btn_realTargets_Click);
            // 
            // btn_maneuver
            // 
            this.btn_maneuver.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_maneuver.Location = new System.Drawing.Point(0, 40);
            this.btn_maneuver.Name = "btn_maneuver";
            this.btn_maneuver.Size = new System.Drawing.Size(226, 20);
            this.btn_maneuver.TabIndex = 6;
            this.btn_maneuver.Text = "maneuver";
            this.btn_maneuver.UseVisualStyleBackColor = true;
            this.btn_maneuver.Click += new System.EventHandler(this.btn_maneuver_Click);
            // 
            // btn_follow_route
            // 
            this.btn_follow_route.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_follow_route.Location = new System.Drawing.Point(0, 20);
            this.btn_follow_route.Name = "btn_follow_route";
            this.btn_follow_route.Size = new System.Drawing.Size(226, 20);
            this.btn_follow_route.TabIndex = 14;
            this.btn_follow_route.Text = "follow route";
            this.btn_follow_route.UseVisualStyleBackColor = true;
            this.btn_follow_route.Click += new System.EventHandler(this.btn_follow_route_Click);
            // 
            // btn_follow_ongoing
            // 
            this.btn_follow_ongoing.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_follow_ongoing.Location = new System.Drawing.Point(0, 0);
            this.btn_follow_ongoing.Name = "btn_follow_ongoing";
            this.btn_follow_ongoing.Size = new System.Drawing.Size(226, 20);
            this.btn_follow_ongoing.TabIndex = 8;
            this.btn_follow_ongoing.Text = "follow actual";
            this.btn_follow_ongoing.UseVisualStyleBackColor = true;
            this.btn_follow_ongoing.Click += new System.EventHandler(this.btn_followOngoing_Click);
            // 
            // panel_simulate
            // 
            this.panel_simulate.Controls.Add(this.btn_Simulate);
            this.panel_simulate.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_simulate.Enabled = false;
            this.panel_simulate.Location = new System.Drawing.Point(226, 0);
            this.panel_simulate.Name = "panel_simulate";
            this.panel_simulate.Size = new System.Drawing.Size(246, 100);
            this.panel_simulate.TabIndex = 10;
            // 
            // btn_Simulate
            // 
            this.btn_Simulate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Simulate.Location = new System.Drawing.Point(0, 0);
            this.btn_Simulate.Name = "btn_Simulate";
            this.btn_Simulate.Size = new System.Drawing.Size(246, 100);
            this.btn_Simulate.TabIndex = 13;
            this.btn_Simulate.Text = "simulate";
            this.btn_Simulate.UseVisualStyleBackColor = true;
            this.btn_Simulate.Click += new System.EventHandler(this.btn_simulate_Click);
            // 
            // NUD_timeStep
            // 
            this.NUD_timeStep.Location = new System.Drawing.Point(60, 169);
            this.NUD_timeStep.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NUD_timeStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_timeStep.Name = "NUD_timeStep";
            this.NUD_timeStep.Size = new System.Drawing.Size(75, 20);
            this.NUD_timeStep.TabIndex = 22;
            this.NUD_timeStep.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // NavigatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 467);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "NavigatorForm";
            this.Text = "Navigator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NavigatorForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPageViz.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Viz)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.track_images)).EndInit();
            this.panel_debug.ResumeLayout(false);
            this.panel_simulate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_timeStep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_Set_USV_Directory;
        private System.Windows.Forms.Button btn_Set_Working_Directory;
        private System.Windows.Forms.Button btn_Set_KTViz_Directory;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tb_ktviz_dir;
        private System.Windows.Forms.TextBox tb_working_dir;
        private System.Windows.Forms.TextBox tb_usv_dir;
        private System.Windows.Forms.Button btn_RunViz;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_analyze;
        private System.Windows.Forms.Button btn_maneuver;
        private System.Windows.Forms.TextBox tb_output;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btn_toInit;
        private System.Windows.Forms.Button btn_backup;
        private System.Windows.Forms.Button btn_follow_ongoing;
        private System.Windows.Forms.Panel panel_debug;
        private System.Windows.Forms.Panel panel_simulate;
        private System.Windows.Forms.RadioButton rb_base;
        private System.Windows.Forms.RadioButton rb_rvo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Simulate;
        private System.Windows.Forms.Button btn_follow_route;
        private System.Windows.Forms.Button btn_realTargets;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPageViz;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox pb_Viz;
        private System.Windows.Forms.Button btn_WorkStart;
        private System.Windows.Forms.TrackBar track_images;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_Work_Stop;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnOpenWorkDir;
        private System.Windows.Forms.Label labelKtvizDir;
        private System.Windows.Forms.Label labelWorkDir;
        private System.Windows.Forms.Label labelExecPath;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ProgressBar progressBarViz;
        private System.Windows.Forms.CheckBox cb_ongoing;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rb_pred_none;
        private System.Windows.Forms.RadioButton rb_pred_simple;
        private System.Windows.Forms.RadioButton rb_pred_full;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btn_auto_test;
        private System.Windows.Forms.NumericUpDown NUD_timeStep;
    }
}

