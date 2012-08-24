namespace CloudRaid
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.txtSourceDirs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOutputDirs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btSyncronize = new System.Windows.Forms.Button();
            this.btBrowseFiles = new System.Windows.Forms.Button();
            this.lbSourceSize = new System.Windows.Forms.Label();
            this.btChecks = new System.Windows.Forms.Button();
            this.lbOutputSize = new System.Windows.Forms.Label();
            this.lbOutputFree = new System.Windows.Forms.Label();
            this.lbOutputUsed = new System.Windows.Forms.Label();
            this.gbSource = new System.Windows.Forms.GroupBox();
            this.gbOutput = new System.Windows.Forms.GroupBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lbProgress = new System.Windows.Forms.Label();
            this.gbSource.SuspendLayout();
            this.gbOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSourceDirs
            // 
            this.txtSourceDirs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSourceDirs.Location = new System.Drawing.Point(12, 41);
            this.txtSourceDirs.Multiline = true;
            this.txtSourceDirs.Name = "txtSourceDirs";
            this.txtSourceDirs.Size = new System.Drawing.Size(655, 100);
            this.txtSourceDirs.TabIndex = 0;
            this.txtSourceDirs.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source directories";
            // 
            // txtOutputDirs
            // 
            this.txtOutputDirs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutputDirs.Location = new System.Drawing.Point(12, 178);
            this.txtOutputDirs.Multiline = true;
            this.txtOutputDirs.Name = "txtOutputDirs";
            this.txtOutputDirs.Size = new System.Drawing.Size(655, 100);
            this.txtOutputDirs.TabIndex = 2;
            this.txtOutputDirs.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output directories";
            // 
            // btSyncronize
            // 
            this.btSyncronize.Location = new System.Drawing.Point(508, 306);
            this.btSyncronize.Name = "btSyncronize";
            this.btSyncronize.Size = new System.Drawing.Size(75, 23);
            this.btSyncronize.TabIndex = 4;
            this.btSyncronize.Text = "Syncronize";
            this.btSyncronize.UseVisualStyleBackColor = true;
            this.btSyncronize.Click += new System.EventHandler(this.btSyncronize_Click);
            // 
            // btBrowseFiles
            // 
            this.btBrowseFiles.Location = new System.Drawing.Point(592, 306);
            this.btBrowseFiles.Name = "btBrowseFiles";
            this.btBrowseFiles.Size = new System.Drawing.Size(75, 23);
            this.btBrowseFiles.TabIndex = 5;
            this.btBrowseFiles.Text = "Browser";
            this.btBrowseFiles.UseVisualStyleBackColor = true;
            // 
            // lbSourceSize
            // 
            this.lbSourceSize.AutoSize = true;
            this.lbSourceSize.Location = new System.Drawing.Point(17, 28);
            this.lbSourceSize.Name = "lbSourceSize";
            this.lbSourceSize.Size = new System.Drawing.Size(109, 13);
            this.lbSourceSize.TabIndex = 6;
            this.lbSourceSize.Text = "Souce size: unknown";
            // 
            // btChecks
            // 
            this.btChecks.Location = new System.Drawing.Point(424, 306);
            this.btChecks.Name = "btChecks";
            this.btChecks.Size = new System.Drawing.Size(75, 23);
            this.btChecks.TabIndex = 7;
            this.btChecks.Text = "Checks";
            this.btChecks.UseVisualStyleBackColor = true;
            this.btChecks.Click += new System.EventHandler(this.btChecks_Click);
            // 
            // lbOutputSize
            // 
            this.lbOutputSize.AutoSize = true;
            this.lbOutputSize.Location = new System.Drawing.Point(6, 28);
            this.lbOutputSize.Name = "lbOutputSize";
            this.lbOutputSize.Size = new System.Drawing.Size(110, 13);
            this.lbOutputSize.TabIndex = 8;
            this.lbOutputSize.Text = "Output size: unknown";
            // 
            // lbOutputFree
            // 
            this.lbOutputFree.AutoSize = true;
            this.lbOutputFree.Location = new System.Drawing.Point(6, 102);
            this.lbOutputFree.Name = "lbOutputFree";
            this.lbOutputFree.Size = new System.Drawing.Size(110, 13);
            this.lbOutputFree.TabIndex = 9;
            this.lbOutputFree.Text = "Output free: unknown";
            // 
            // lbOutputUsed
            // 
            this.lbOutputUsed.AutoSize = true;
            this.lbOutputUsed.Location = new System.Drawing.Point(6, 65);
            this.lbOutputUsed.Name = "lbOutputUsed";
            this.lbOutputUsed.Size = new System.Drawing.Size(115, 13);
            this.lbOutputUsed.TabIndex = 10;
            this.lbOutputUsed.Text = "Output used: unknown";
            // 
            // gbSource
            // 
            this.gbSource.Controls.Add(this.lbSourceSize);
            this.gbSource.Location = new System.Drawing.Point(18, 306);
            this.gbSource.Name = "gbSource";
            this.gbSource.Size = new System.Drawing.Size(154, 135);
            this.gbSource.TabIndex = 11;
            this.gbSource.TabStop = false;
            this.gbSource.Text = "Source:";
            // 
            // gbOutput
            // 
            this.gbOutput.Controls.Add(this.lbOutputSize);
            this.gbOutput.Controls.Add(this.lbOutputFree);
            this.gbOutput.Controls.Add(this.lbOutputUsed);
            this.gbOutput.Location = new System.Drawing.Point(203, 306);
            this.gbOutput.Name = "gbOutput";
            this.gbOutput.Size = new System.Drawing.Size(154, 135);
            this.gbOutput.TabIndex = 12;
            this.gbOutput.TabStop = false;
            this.gbOutput.Text = "Output:";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(424, 383);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(243, 23);
            this.progressBar.TabIndex = 13;
            // 
            // lbProgress
            // 
            this.lbProgress.AutoSize = true;
            this.lbProgress.Location = new System.Drawing.Point(515, 367);
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.Size = new System.Drawing.Size(68, 13);
            this.lbProgress.TabIndex = 14;
            this.lbProgress.Text = "Progress: 0%";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 481);
            this.Controls.Add(this.lbProgress);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.gbOutput);
            this.Controls.Add(this.gbSource);
            this.Controls.Add(this.btChecks);
            this.Controls.Add(this.btBrowseFiles);
            this.Controls.Add(this.btSyncronize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOutputDirs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSourceDirs);
            this.Name = "FrmMain";
            this.Text = "CloudRAID";
            this.gbSource.ResumeLayout(false);
            this.gbSource.PerformLayout();
            this.gbOutput.ResumeLayout(false);
            this.gbOutput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox txtSourceDirs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOutputDirs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btSyncronize;
        private System.Windows.Forms.Button btBrowseFiles;
        private System.Windows.Forms.Label lbSourceSize;
        private System.Windows.Forms.Label lbOutputSize;
        private System.Windows.Forms.Label lbOutputFree;
        private System.Windows.Forms.Label lbOutputUsed;
        private System.Windows.Forms.GroupBox gbSource;
        private System.Windows.Forms.GroupBox gbOutput;
        public System.Windows.Forms.ProgressBar progressBar;
        public System.Windows.Forms.Label lbProgress;
        public System.Windows.Forms.Button btChecks;
    }
}

