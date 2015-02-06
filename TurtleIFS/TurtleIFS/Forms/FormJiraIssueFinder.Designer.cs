namespace TurtleIFS.Forms
{
    partial class FormJiraIssueFinder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJiraIssueFinder));
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonIssueFinder = new System.Windows.Forms.Button();
            this.progressBarLoding = new System.Windows.Forms.ProgressBar();
            this.backgroundWorkerGetDescription = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonResetSettings = new System.Windows.Forms.Button();
            this.buttonContactSupport = new System.Windows.Forms.Button();
            this.contextMenuStripProductGroup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.projectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceAsetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radioButtonLcs = new System.Windows.Forms.RadioButton();
            this.radioButtonJira = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxMultidev = new System.Windows.Forms.CheckBox();
            this.textBoxIssueId = new System.Windows.Forms.TextBox();
            this.contextMenuStripProductGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDescription.Location = new System.Drawing.Point(12, 99);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(420, 49);
            this.textBoxDescription.TabIndex = 6;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Location = new System.Drawing.Point(357, 155);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Add Jira Id";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonIssueFinder
            // 
            this.buttonIssueFinder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonIssueFinder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIssueFinder.Location = new System.Drawing.Point(330, 70);
            this.buttonIssueFinder.Name = "buttonIssueFinder";
            this.buttonIssueFinder.Size = new System.Drawing.Size(30, 23);
            this.buttonIssueFinder.TabIndex = 4;
            this.buttonIssueFinder.Text = "...";
            this.buttonIssueFinder.UseVisualStyleBackColor = true;
            this.buttonIssueFinder.Click += new System.EventHandler(this.buttonIssueFinder_Click);
            // 
            // progressBarLoding
            // 
            this.progressBarLoding.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarLoding.Location = new System.Drawing.Point(0, 186);
            this.progressBarLoding.Name = "progressBarLoding";
            this.progressBarLoding.Size = new System.Drawing.Size(444, 10);
            this.progressBarLoding.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarLoding.TabIndex = 13;
            this.progressBarLoding.Visible = false;
            // 
            // backgroundWorkerGetDescription
            // 
            this.backgroundWorkerGetDescription.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerGetDescription_DoWork);
            this.backgroundWorkerGetDescription.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerGetDescription_RunWorkerCompleted);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.MediumPurple;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(10);
            this.label3.Size = new System.Drawing.Size(444, 65);
            this.label3.TabIndex = 14;
            this.label3.Text = "Get IFS Commit Message";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonResetSettings
            // 
            this.buttonResetSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonResetSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResetSettings.Location = new System.Drawing.Point(42, 155);
            this.buttonResetSettings.Name = "buttonResetSettings";
            this.buttonResetSettings.Size = new System.Drawing.Size(86, 23);
            this.buttonResetSettings.TabIndex = 16;
            this.buttonResetSettings.TabStop = false;
            this.buttonResetSettings.Text = "Reset Settings";
            this.buttonResetSettings.UseVisualStyleBackColor = true;
            this.buttonResetSettings.Click += new System.EventHandler(this.buttonResetSettings_Click);
            // 
            // buttonContactSupport
            // 
            this.buttonContactSupport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonContactSupport.AutoSize = true;
            this.buttonContactSupport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonContactSupport.ContextMenuStrip = this.contextMenuStripProductGroup;
            this.buttonContactSupport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonContactSupport.Image = global::TurtleIFS.Properties.Resources.contactSupport;
            this.buttonContactSupport.Location = new System.Drawing.Point(12, 154);
            this.buttonContactSupport.Name = "buttonContactSupport";
            this.buttonContactSupport.Size = new System.Drawing.Size(24, 24);
            this.buttonContactSupport.TabIndex = 17;
            this.buttonContactSupport.TabStop = false;
            this.buttonContactSupport.UseVisualStyleBackColor = true;
            this.buttonContactSupport.Click += new System.EventHandler(this.buttonContactSupport_Click);
            // 
            // contextMenuStripProductGroup
            // 
            this.contextMenuStripProductGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectsToolStripMenuItem,
            this.serviceAsetToolStripMenuItem,
            this.otherToolStripMenuItem});
            this.contextMenuStripProductGroup.Name = "contextMenuStripProductGroup";
            this.contextMenuStripProductGroup.Size = new System.Drawing.Size(168, 70);
            this.contextMenuStripProductGroup.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripProductGroup_Opening);
            // 
            // projectsToolStripMenuItem
            // 
            this.projectsToolStripMenuItem.CheckOnClick = true;
            this.projectsToolStripMenuItem.Name = "projectsToolStripMenuItem";
            this.projectsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.projectsToolStripMenuItem.Text = "Projects";
            // 
            // serviceAsetToolStripMenuItem
            // 
            this.serviceAsetToolStripMenuItem.CheckOnClick = true;
            this.serviceAsetToolStripMenuItem.Name = "serviceAsetToolStripMenuItem";
            this.serviceAsetToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.serviceAsetToolStripMenuItem.Text = "Service And Asset";
            // 
            // otherToolStripMenuItem
            // 
            this.otherToolStripMenuItem.Checked = true;
            this.otherToolStripMenuItem.CheckOnClick = true;
            this.otherToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.otherToolStripMenuItem.Name = "otherToolStripMenuItem";
            this.otherToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.otherToolStripMenuItem.Text = "Other";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::TurtleIFS.Properties.Resources.ifs_logo_frame;
            this.pictureBox1.Location = new System.Drawing.Point(390, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // radioButtonLcs
            // 
            this.radioButtonLcs.AutoSize = true;
            this.radioButtonLcs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonLcs.Location = new System.Drawing.Point(56, 3);
            this.radioButtonLcs.Name = "radioButtonLcs";
            this.radioButtonLcs.Size = new System.Drawing.Size(44, 17);
            this.radioButtonLcs.TabIndex = 2;
            this.radioButtonLcs.Text = "LCS";
            this.radioButtonLcs.UseVisualStyleBackColor = true;
            this.radioButtonLcs.CheckedChanged += new System.EventHandler(this.radioButtonLcs_CheckedChanged);
            // 
            // radioButtonJira
            // 
            this.radioButtonJira.AutoSize = true;
            this.radioButtonJira.Checked = true;
            this.radioButtonJira.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonJira.Location = new System.Drawing.Point(3, 3);
            this.radioButtonJira.Name = "radioButtonJira";
            this.radioButtonJira.Size = new System.Drawing.Size(47, 17);
            this.radioButtonJira.TabIndex = 1;
            this.radioButtonJira.TabStop = true;
            this.radioButtonJira.Text = "JIRA";
            this.radioButtonJira.UseVisualStyleBackColor = true;
            this.radioButtonJira.CheckedChanged += new System.EventHandler(this.radioButtonJira_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.radioButtonJira);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonLcs);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 70);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(103, 23);
            this.flowLayoutPanel1.TabIndex = 20;
            // 
            // checkBoxMultidev
            // 
            this.checkBoxMultidev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxMultidev.AutoSize = true;
            this.checkBoxMultidev.Checked = global::TurtleIFS.Properties.Settings.Default.LcsMultiDev;
            this.checkBoxMultidev.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TurtleIFS.Properties.Settings.Default, "LcsMultiDev", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxMultidev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxMultidev.Location = new System.Drawing.Point(369, 74);
            this.checkBoxMultidev.Name = "checkBoxMultidev";
            this.checkBoxMultidev.Size = new System.Drawing.Size(63, 17);
            this.checkBoxMultidev.TabIndex = 5;
            this.checkBoxMultidev.Text = "Multidev";
            this.checkBoxMultidev.UseVisualStyleBackColor = true;
            // 
            // textBoxIssueId
            // 
            this.textBoxIssueId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxIssueId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxIssueId.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TurtleIFS.Properties.Settings.Default, "IssueID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxIssueId.Location = new System.Drawing.Point(121, 71);
            this.textBoxIssueId.Name = "textBoxIssueId";
            this.textBoxIssueId.Size = new System.Drawing.Size(203, 20);
            this.textBoxIssueId.TabIndex = 3;
            this.textBoxIssueId.Text = global::TurtleIFS.Properties.Settings.Default.IssueID;
            // 
            // FormJiraIssueFinder
            // 
            this.AcceptButton = this.buttonAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(444, 196);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.buttonContactSupport);
            this.Controls.Add(this.buttonResetSettings);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBarLoding);
            this.Controls.Add(this.checkBoxMultidev);
            this.Controls.Add(this.buttonIssueFinder);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxIssueId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormJiraIssueFinder";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Turtle IFS";
            this.Load += new System.EventHandler(this.FormJiraIssueFinder_Load);
            this.contextMenuStripProductGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxIssueId;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonIssueFinder;
        private System.Windows.Forms.CheckBox checkBoxMultidev;
        private System.Windows.Forms.ProgressBar progressBarLoding;
        private System.ComponentModel.BackgroundWorker backgroundWorkerGetDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonResetSettings;
        private System.Windows.Forms.Button buttonContactSupport;
        private System.Windows.Forms.RadioButton radioButtonJira;
        private System.Windows.Forms.RadioButton radioButtonLcs;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripProductGroup;
        private System.Windows.Forms.ToolStripMenuItem projectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceAsetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otherToolStripMenuItem;
    }
}