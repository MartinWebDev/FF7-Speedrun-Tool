namespace FF7_Speedrun_Control_UI_Forms
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaveFrameLock = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFrameLock = new System.Windows.Forms.TextBox();
            this.btnLaunchFPSFix = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnEndRun = new System.Windows.Forms.Button();
            this.btnStartRun = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnSaveFrameLock);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFrameLock);
            this.groupBox1.Controls.Add(this.btnLaunchFPSFix);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 482);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FPS Fix Settings";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(358, 355);
            this.label3.TabIndex = 3;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // btnSaveFrameLock
            // 
            this.btnSaveFrameLock.Location = new System.Drawing.Point(213, 35);
            this.btnSaveFrameLock.Name = "btnSaveFrameLock";
            this.btnSaveFrameLock.Size = new System.Drawing.Size(131, 33);
            this.btnSaveFrameLock.TabIndex = 2;
            this.btnSaveFrameLock.Text = "Save New Value";
            this.btnSaveFrameLock.UseVisualStyleBackColor = true;
            this.btnSaveFrameLock.Click += new System.EventHandler(this.btnSaveFrameLock_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "FPS Fix Value";
            // 
            // txtFrameLock
            // 
            this.txtFrameLock.Location = new System.Drawing.Point(107, 40);
            this.txtFrameLock.Name = "txtFrameLock";
            this.txtFrameLock.Size = new System.Drawing.Size(100, 22);
            this.txtFrameLock.TabIndex = 0;
            this.txtFrameLock.TextChanged += new System.EventHandler(this.txtFrameLock_TextChanged);
            // 
            // btnLaunchFPSFix
            // 
            this.btnLaunchFPSFix.Location = new System.Drawing.Point(213, 84);
            this.btnLaunchFPSFix.Name = "btnLaunchFPSFix";
            this.btnLaunchFPSFix.Size = new System.Drawing.Size(131, 33);
            this.btnLaunchFPSFix.TabIndex = 0;
            this.btnLaunchFPSFix.Text = "Launch FPSFix";
            this.btnLaunchFPSFix.UseVisualStyleBackColor = true;
            this.btnLaunchFPSFix.Click += new System.EventHandler(this.btnLaunchGame_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtLog);
            this.groupBox2.Controls.Add(this.btnEndRun);
            this.groupBox2.Controls.Add(this.btnStartRun);
            this.groupBox2.Location = new System.Drawing.Point(400, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(453, 482);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Game Control";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Log";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.Window;
            this.txtLog.Location = new System.Drawing.Point(6, 107);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(441, 369);
            this.txtLog.TabIndex = 3;
            // 
            // btnEndRun
            // 
            this.btnEndRun.Location = new System.Drawing.Point(146, 35);
            this.btnEndRun.Name = "btnEndRun";
            this.btnEndRun.Size = new System.Drawing.Size(134, 33);
            this.btnEndRun.TabIndex = 2;
            this.btnEndRun.Text = "End Speedrun";
            this.btnEndRun.UseVisualStyleBackColor = true;
            this.btnEndRun.Click += new System.EventHandler(this.btnEndRun_Click);
            // 
            // btnStartRun
            // 
            this.btnStartRun.Location = new System.Drawing.Point(6, 35);
            this.btnStartRun.Name = "btnStartRun";
            this.btnStartRun.Size = new System.Drawing.Size(134, 33);
            this.btnStartRun.TabIndex = 1;
            this.btnStartRun.Text = "Start Speedrun";
            this.btnStartRun.UseVisualStyleBackColor = true;
            this.btnStartRun.Click += new System.EventHandler(this.btnStartRun_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 504);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMain";
            this.Text = "FF7 Speedrun Control";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSaveFrameLock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFrameLock;
        private System.Windows.Forms.Button btnEndRun;
        private System.Windows.Forms.Button btnStartRun;
        private System.Windows.Forms.Button btnLaunchFPSFix;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

