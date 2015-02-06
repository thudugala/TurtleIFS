namespace TurtleIFS.Forms
{
    partial class FormJiraLogging
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJiraLogging));
            this.elementHostLogging = new System.Windows.Forms.Integration.ElementHost();
            this.userControlJiraLogging1 = new TurtleIFS.Forms.UserControlJiraLogging();
            this.SuspendLayout();
            // 
            // elementHostLogging
            // 
            this.elementHostLogging.BackColorTransparent = true;
            this.elementHostLogging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHostLogging.Location = new System.Drawing.Point(0, 0);
            this.elementHostLogging.Name = "elementHostLogging";
            this.elementHostLogging.Size = new System.Drawing.Size(458, 207);
            this.elementHostLogging.TabIndex = 0;
            this.elementHostLogging.Text = "elementHostLogging";
            this.elementHostLogging.Child = this.userControlJiraLogging1;
            // 
            // FormJiraLogging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 207);
            this.Controls.Add(this.elementHostLogging);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(354, 160);
            this.Name = "FormJiraLogging";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Jira Logging";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHostLogging;
        private UserControlJiraLogging userControlJiraLogging1;

    }
}