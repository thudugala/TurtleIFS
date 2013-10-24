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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxJiraDescription = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonJira = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLcsBugDescription = new System.Windows.Forms.TextBox();
            this.checkBoxMultidev = new System.Windows.Forms.CheckBox();
            this.textBoxLcsBugId = new System.Windows.Forms.TextBox();
            this.textBoxJiraId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Jira ID:";
            // 
            // textBoxJiraDescription
            // 
            this.textBoxJiraDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxJiraDescription.Location = new System.Drawing.Point(277, 12);
            this.textBoxJiraDescription.Name = "textBoxJiraDescription";
            this.textBoxJiraDescription.Size = new System.Drawing.Size(386, 20);
            this.textBoxJiraDescription.TabIndex = 3;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(587, 65);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 7;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonJira
            // 
            this.buttonJira.Location = new System.Drawing.Point(241, 10);
            this.buttonJira.Name = "buttonJira";
            this.buttonJira.Size = new System.Drawing.Size(30, 23);
            this.buttonJira.TabIndex = 2;
            this.buttonJira.Text = "...";
            this.buttonJira.UseVisualStyleBackColor = true;
            this.buttonJira.Click += new System.EventHandler(this.buttonJira_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "LCS Bug ID:";
            // 
            // textBoxLcsBugDescription
            // 
            this.textBoxLcsBugDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLcsBugDescription.Location = new System.Drawing.Point(277, 38);
            this.textBoxLcsBugDescription.Name = "textBoxLcsBugDescription";
            this.textBoxLcsBugDescription.Size = new System.Drawing.Size(385, 20);
            this.textBoxLcsBugDescription.TabIndex = 5;
            // 
            // checkBoxMultidev
            // 
            this.checkBoxMultidev.AutoSize = true;
            this.checkBoxMultidev.Checked = global::TurtleIFS.Properties.Settings.Default.LcsMultiDev;
            this.checkBoxMultidev.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TurtleIFS.Properties.Settings.Default, "LcsMultiDev", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxMultidev.Location = new System.Drawing.Point(85, 64);
            this.checkBoxMultidev.Name = "checkBoxMultidev";
            this.checkBoxMultidev.Size = new System.Drawing.Size(66, 17);
            this.checkBoxMultidev.TabIndex = 6;
            this.checkBoxMultidev.Text = "Multidev";
            this.checkBoxMultidev.UseVisualStyleBackColor = true;
            // 
            // textBoxLcsBugId
            // 
            this.textBoxLcsBugId.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TurtleIFS.Properties.Settings.Default, "LcsBugId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxLcsBugId.Location = new System.Drawing.Point(85, 38);
            this.textBoxLcsBugId.Name = "textBoxLcsBugId";
            this.textBoxLcsBugId.Size = new System.Drawing.Size(150, 20);
            this.textBoxLcsBugId.TabIndex = 4;
            this.textBoxLcsBugId.Text = global::TurtleIFS.Properties.Settings.Default.LcsBugId;
            // 
            // textBoxJiraId
            // 
            this.textBoxJiraId.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TurtleIFS.Properties.Settings.Default, "JiraID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxJiraId.Location = new System.Drawing.Point(85, 12);
            this.textBoxJiraId.Name = "textBoxJiraId";
            this.textBoxJiraId.Size = new System.Drawing.Size(150, 20);
            this.textBoxJiraId.TabIndex = 1;
            this.textBoxJiraId.Text = global::TurtleIFS.Properties.Settings.Default.JiraID;
            // 
            // FormJiraIssueFinder
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 100);
            this.Controls.Add(this.checkBoxMultidev);
            this.Controls.Add(this.textBoxLcsBugDescription);
            this.Controls.Add(this.textBoxLcsBugId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonJira);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBoxJiraDescription);
            this.Controls.Add(this.textBoxJiraId);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormJiraIssueFinder";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jira Issue Finder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxJiraId;
        private System.Windows.Forms.TextBox textBoxJiraDescription;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonJira;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLcsBugId;
        private System.Windows.Forms.TextBox textBoxLcsBugDescription;
        private System.Windows.Forms.CheckBox checkBoxMultidev;
    }
}