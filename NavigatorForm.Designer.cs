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
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_toInit = new System.Windows.Forms.Button();
            this.btn_backup = new System.Windows.Forms.Button();
            this.btn_RunViz = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Set_KTViz_Directory = new System.Windows.Forms.Button();
            this.btn_Set_Working_Directory = new System.Windows.Forms.Button();
            this.btn_Set_USV_Directory = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tb_output = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_analyze = new System.Windows.Forms.Button();
            this.btn_maneuver = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_realTargets = new System.Windows.Forms.Button();
            this.btn_follow_route = new System.Windows.Forms.Button();
            this.btn_Simulate = new System.Windows.Forms.Button();
            this.rb_base = new System.Windows.Forms.RadioButton();
            this.rb_rvo = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_follow_ongoing = new System.Windows.Forms.Button();
            this.tb_timeStep = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tb_ktviz_dir = new System.Windows.Forms.TextBox();
            this.tb_working_dir = new System.Windows.Forms.TextBox();
            this.tb_usv_dir = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(632, 416);
            this.splitContainer1.SplitterDistance = 227;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.btn_toInit);
            this.panel3.Controls.Add(this.btn_backup);
            this.panel3.Controls.Add(this.btn_RunViz);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 345);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(225, 69);
            this.panel3.TabIndex = 3;
            // 
            // btn_toInit
            // 
            this.btn_toInit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_toInit.Location = new System.Drawing.Point(0, 0);
            this.btn_toInit.Name = "btn_toInit";
            this.btn_toInit.Size = new System.Drawing.Size(225, 23);
            this.btn_toInit.TabIndex = 9;
            this.btn_toInit.Text = "Return to Init State";
            this.btn_toInit.UseVisualStyleBackColor = true;
            this.btn_toInit.Click += new System.EventHandler(this.btn_toInit_Click);
            // 
            // btn_backup
            // 
            this.btn_backup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_backup.Location = new System.Drawing.Point(0, 23);
            this.btn_backup.Name = "btn_backup";
            this.btn_backup.Size = new System.Drawing.Size(225, 23);
            this.btn_backup.TabIndex = 8;
            this.btn_backup.Text = "Save Current as Init State";
            this.btn_backup.UseVisualStyleBackColor = true;
            this.btn_backup.Click += new System.EventHandler(this.btn_backup_Click);
            // 
            // btn_RunViz
            // 
            this.btn_RunViz.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_RunViz.Location = new System.Drawing.Point(0, 46);
            this.btn_RunViz.Name = "btn_RunViz";
            this.btn_RunViz.Size = new System.Drawing.Size(225, 23);
            this.btn_RunViz.TabIndex = 2;
            this.btn_RunViz.Text = "KTViz";
            this.btn_RunViz.UseVisualStyleBackColor = true;
            this.btn_RunViz.Click += new System.EventHandler(this.btn_RunViz_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Set_KTViz_Directory);
            this.panel1.Controls.Add(this.btn_Set_Working_Directory);
            this.panel1.Controls.Add(this.btn_Set_USV_Directory);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 69);
            this.panel1.TabIndex = 1;
            // 
            // btn_Set_KTViz_Directory
            // 
            this.btn_Set_KTViz_Directory.AutoSize = true;
            this.btn_Set_KTViz_Directory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Set_KTViz_Directory.Location = new System.Drawing.Point(0, 46);
            this.btn_Set_KTViz_Directory.Name = "btn_Set_KTViz_Directory";
            this.btn_Set_KTViz_Directory.Size = new System.Drawing.Size(225, 23);
            this.btn_Set_KTViz_Directory.TabIndex = 2;
            this.btn_Set_KTViz_Directory.Text = "Set KTViz Directory";
            this.btn_Set_KTViz_Directory.UseVisualStyleBackColor = true;
            this.btn_Set_KTViz_Directory.Click += new System.EventHandler(this.btn_Set_KTViz_Directory_Click);
            // 
            // btn_Set_Working_Directory
            // 
            this.btn_Set_Working_Directory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Set_Working_Directory.Location = new System.Drawing.Point(0, 23);
            this.btn_Set_Working_Directory.Name = "btn_Set_Working_Directory";
            this.btn_Set_Working_Directory.Size = new System.Drawing.Size(225, 23);
            this.btn_Set_Working_Directory.TabIndex = 1;
            this.btn_Set_Working_Directory.Text = "Set Working Directory";
            this.btn_Set_Working_Directory.UseVisualStyleBackColor = true;
            this.btn_Set_Working_Directory.Click += new System.EventHandler(this.btn_Set_Working_Directory_Click);
            // 
            // btn_Set_USV_Directory
            // 
            this.btn_Set_USV_Directory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Set_USV_Directory.Location = new System.Drawing.Point(0, 0);
            this.btn_Set_USV_Directory.Name = "btn_Set_USV_Directory";
            this.btn_Set_USV_Directory.Size = new System.Drawing.Size(225, 23);
            this.btn_Set_USV_Directory.TabIndex = 0;
            this.btn_Set_USV_Directory.Text = "Set USV Directory";
            this.btn_Set_USV_Directory.UseVisualStyleBackColor = true;
            this.btn_Set_USV_Directory.Click += new System.EventHandler(this.btn_Set_USV_Directory_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 69);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tb_output);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel5);
            this.splitContainer2.Panel2.Controls.Add(this.panel4);
            this.splitContainer2.Size = new System.Drawing.Size(398, 345);
            this.splitContainer2.SplitterDistance = 235;
            this.splitContainer2.TabIndex = 10;
            // 
            // tb_output
            // 
            this.tb_output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_output.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tb_output.Location = new System.Drawing.Point(0, 0);
            this.tb_output.Multiline = true;
            this.tb_output.Name = "tb_output";
            this.tb_output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_output.Size = new System.Drawing.Size(398, 235);
            this.tb_output.TabIndex = 8;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btn_analyze);
            this.panel5.Controls.Add(this.btn_maneuver);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(152, 106);
            this.panel5.TabIndex = 11;
            // 
            // btn_analyze
            // 
            this.btn_analyze.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_analyze.Location = new System.Drawing.Point(0, 23);
            this.btn_analyze.Name = "btn_analyze";
            this.btn_analyze.Size = new System.Drawing.Size(152, 23);
            this.btn_analyze.TabIndex = 7;
            this.btn_analyze.Text = "analyze";
            this.btn_analyze.UseVisualStyleBackColor = true;
            this.btn_analyze.Click += new System.EventHandler(this.btn_analyze_Click);
            // 
            // btn_maneuver
            // 
            this.btn_maneuver.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_maneuver.Location = new System.Drawing.Point(0, 0);
            this.btn_maneuver.Name = "btn_maneuver";
            this.btn_maneuver.Size = new System.Drawing.Size(152, 23);
            this.btn_maneuver.TabIndex = 6;
            this.btn_maneuver.Text = "maneuver";
            this.btn_maneuver.UseVisualStyleBackColor = true;
            this.btn_maneuver.Click += new System.EventHandler(this.btn_maneuver_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_realTargets);
            this.panel4.Controls.Add(this.btn_follow_route);
            this.panel4.Controls.Add(this.btn_Simulate);
            this.panel4.Controls.Add(this.rb_base);
            this.panel4.Controls.Add(this.rb_rvo);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.btn_follow_ongoing);
            this.panel4.Controls.Add(this.tb_timeStep);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(152, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(246, 106);
            this.panel4.TabIndex = 10;
            // 
            // btn_realTargets
            // 
            this.btn_realTargets.Location = new System.Drawing.Point(9, 75);
            this.btn_realTargets.Name = "btn_realTargets";
            this.btn_realTargets.Size = new System.Drawing.Size(110, 22);
            this.btn_realTargets.TabIndex = 15;
            this.btn_realTargets.Text = "create real targets";
            this.btn_realTargets.UseVisualStyleBackColor = true;
            this.btn_realTargets.Click += new System.EventHandler(this.btn_realTargets_Click);
            // 
            // btn_follow_route
            // 
            this.btn_follow_route.Location = new System.Drawing.Point(141, 34);
            this.btn_follow_route.Name = "btn_follow_route";
            this.btn_follow_route.Size = new System.Drawing.Size(94, 20);
            this.btn_follow_route.TabIndex = 14;
            this.btn_follow_route.Text = "follow route";
            this.btn_follow_route.UseVisualStyleBackColor = true;
            this.btn_follow_route.Click += new System.EventHandler(this.btn_follow_route_Click);
            // 
            // btn_Simulate
            // 
            this.btn_Simulate.Location = new System.Drawing.Point(141, 60);
            this.btn_Simulate.Name = "btn_Simulate";
            this.btn_Simulate.Size = new System.Drawing.Size(94, 20);
            this.btn_Simulate.TabIndex = 13;
            this.btn_Simulate.Text = "simulate";
            this.btn_Simulate.UseVisualStyleBackColor = true;
            this.btn_Simulate.Click += new System.EventHandler(this.btn_simulate_Click);
            // 
            // rb_base
            // 
            this.rb_base.AutoSize = true;
            this.rb_base.Checked = true;
            this.rb_base.Location = new System.Drawing.Point(9, 49);
            this.rb_base.Name = "rb_base";
            this.rb_base.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rb_base.Size = new System.Drawing.Size(79, 17);
            this.rb_base.TabIndex = 12;
            this.rb_base.TabStop = true;
            this.rb_base.Text = "prefer Base";
            this.rb_base.UseVisualStyleBackColor = true;
            // 
            // rb_rvo
            // 
            this.rb_rvo.AutoSize = true;
            this.rb_rvo.Location = new System.Drawing.Point(9, 34);
            this.rb_rvo.Name = "rb_rvo";
            this.rb_rvo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rb_rvo.Size = new System.Drawing.Size(78, 17);
            this.rb_rvo.TabIndex = 11;
            this.rb_rvo.Text = "prefer RVO";
            this.rb_rvo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "timeStep";
            // 
            // btn_follow_ongoing
            // 
            this.btn_follow_ongoing.Location = new System.Drawing.Point(141, 8);
            this.btn_follow_ongoing.Name = "btn_follow_ongoing";
            this.btn_follow_ongoing.Size = new System.Drawing.Size(94, 20);
            this.btn_follow_ongoing.TabIndex = 8;
            this.btn_follow_ongoing.Text = "follow actual";
            this.btn_follow_ongoing.UseVisualStyleBackColor = true;
            this.btn_follow_ongoing.Click += new System.EventHandler(this.btn_followOngoing_Click);
            // 
            // tb_timeStep
            // 
            this.tb_timeStep.Location = new System.Drawing.Point(60, 8);
            this.tb_timeStep.Name = "tb_timeStep";
            this.tb_timeStep.Size = new System.Drawing.Size(75, 20);
            this.tb_timeStep.TabIndex = 9;
            this.tb_timeStep.Text = "60";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tb_ktviz_dir);
            this.panel2.Controls.Add(this.tb_working_dir);
            this.panel2.Controls.Add(this.tb_usv_dir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(398, 69);
            this.panel2.TabIndex = 5;
            // 
            // tb_ktviz_dir
            // 
            this.tb_ktviz_dir.Location = new System.Drawing.Point(3, 48);
            this.tb_ktviz_dir.Name = "tb_ktviz_dir";
            this.tb_ktviz_dir.ReadOnly = true;
            this.tb_ktviz_dir.Size = new System.Drawing.Size(386, 20);
            this.tb_ktviz_dir.TabIndex = 2;
            // 
            // tb_working_dir
            // 
            this.tb_working_dir.Location = new System.Drawing.Point(3, 25);
            this.tb_working_dir.Name = "tb_working_dir";
            this.tb_working_dir.ReadOnly = true;
            this.tb_working_dir.Size = new System.Drawing.Size(386, 20);
            this.tb_working_dir.TabIndex = 1;
            // 
            // tb_usv_dir
            // 
            this.tb_usv_dir.Location = new System.Drawing.Point(3, 3);
            this.tb_usv_dir.Name = "tb_usv_dir";
            this.tb_usv_dir.ReadOnly = true;
            this.tb_usv_dir.Size = new System.Drawing.Size(386, 20);
            this.tb_usv_dir.TabIndex = 0;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // NavigatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 416);
            this.Controls.Add(this.splitContainer1);
            this.Name = "NavigatorForm";
            this.Text = "Navigator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NavigatorForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Set_USV_Directory;
        private System.Windows.Forms.Button btn_Set_Working_Directory;
        private System.Windows.Forms.Button btn_Set_KTViz_Directory;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tb_ktviz_dir;
        private System.Windows.Forms.TextBox tb_working_dir;
        private System.Windows.Forms.TextBox tb_usv_dir;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btn_RunViz;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_analyze;
        private System.Windows.Forms.Button btn_maneuver;
        private System.Windows.Forms.TextBox tb_output;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btn_toInit;
        private System.Windows.Forms.Button btn_backup;
        private System.Windows.Forms.Button btn_follow_ongoing;
        private System.Windows.Forms.TextBox tb_timeStep;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rb_base;
        private System.Windows.Forms.RadioButton rb_rvo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Simulate;
        private System.Windows.Forms.Button btn_follow_route;
        private System.Windows.Forms.Button btn_realTargets;
    }
}

