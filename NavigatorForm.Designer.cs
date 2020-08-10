﻿namespace SuperNavigator
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
            this.btn_RunViz = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Set_KTViz_Directory = new System.Windows.Forms.Button();
            this.btn_Set_Working_Directory = new System.Windows.Forms.Button();
            this.btn_Set_USV_Directory = new System.Windows.Forms.Button();
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
            this.panel1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.btn_RunViz);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(532, 372);
            this.splitContainer1.SplitterDistance = 247;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 2;
            // 
            // btn_RunViz
            // 
            this.btn_RunViz.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_RunViz.Location = new System.Drawing.Point(0, 347);
            this.btn_RunViz.Name = "btn_RunViz";
            this.btn_RunViz.Size = new System.Drawing.Size(245, 23);
            this.btn_RunViz.TabIndex = 2;
            this.btn_RunViz.Text = "KTViz";
            this.btn_RunViz.UseVisualStyleBackColor = true;
            this.btn_RunViz.Click += new System.EventHandler(this.btn_RunViz_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.btn_Set_KTViz_Directory);
            this.panel1.Controls.Add(this.btn_Set_Working_Directory);
            this.panel1.Controls.Add(this.btn_Set_USV_Directory);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 69);
            this.panel1.TabIndex = 1;
            // 
            // btn_Set_KTViz_Directory
            // 
            this.btn_Set_KTViz_Directory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Set_KTViz_Directory.Location = new System.Drawing.Point(0, 46);
            this.btn_Set_KTViz_Directory.Name = "btn_Set_KTViz_Directory";
            this.btn_Set_KTViz_Directory.Size = new System.Drawing.Size(245, 23);
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
            this.btn_Set_Working_Directory.Size = new System.Drawing.Size(245, 23);
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
            this.btn_Set_USV_Directory.Size = new System.Drawing.Size(245, 23);
            this.btn_Set_USV_Directory.TabIndex = 0;
            this.btn_Set_USV_Directory.Text = "Set USV Directory";
            this.btn_Set_USV_Directory.UseVisualStyleBackColor = true;
            this.btn_Set_USV_Directory.Click += new System.EventHandler(this.btn_Set_USV_Directory_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tb_ktviz_dir);
            this.panel2.Controls.Add(this.tb_working_dir);
            this.panel2.Controls.Add(this.tb_usv_dir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(278, 69);
            this.panel2.TabIndex = 5;
            // 
            // tb_ktviz_dir
            // 
            this.tb_ktviz_dir.Location = new System.Drawing.Point(3, 48);
            this.tb_ktviz_dir.Name = "tb_ktviz_dir";
            this.tb_ktviz_dir.ReadOnly = true;
            this.tb_ktviz_dir.Size = new System.Drawing.Size(266, 20);
            this.tb_ktviz_dir.TabIndex = 2;
            // 
            // tb_working_dir
            // 
            this.tb_working_dir.Location = new System.Drawing.Point(3, 25);
            this.tb_working_dir.Name = "tb_working_dir";
            this.tb_working_dir.ReadOnly = true;
            this.tb_working_dir.Size = new System.Drawing.Size(266, 20);
            this.tb_working_dir.TabIndex = 1;
            // 
            // tb_usv_dir
            // 
            this.tb_usv_dir.Location = new System.Drawing.Point(3, 3);
            this.tb_usv_dir.Name = "tb_usv_dir";
            this.tb_usv_dir.ReadOnly = true;
            this.tb_usv_dir.Size = new System.Drawing.Size(266, 20);
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
            this.ClientSize = new System.Drawing.Size(532, 372);
            this.Controls.Add(this.splitContainer1);
            this.Name = "NavigatorForm";
            this.Text = "Navigator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NavigatorForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
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
    }
}

