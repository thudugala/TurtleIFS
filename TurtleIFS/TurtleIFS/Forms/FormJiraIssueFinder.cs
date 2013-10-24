using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Atlassian.Jira;

namespace TurtleIFS.Forms
{
    public partial class FormJiraIssueFinder : Form
    {
        public String CommitMessage { get; private set; }

        private Jira myJira;

        public FormJiraIssueFinder()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxJiraId.Text) == false)
                {
                    this.CommitMessage = textBoxJiraId.Text + ": " + textBoxJiraDescription.Text;
                }
                else if (string.IsNullOrWhiteSpace(textBoxLcsBugId.Text) == false)
                {
                    this.CommitMessage = "LCS";
                    if (checkBoxMultidev.Checked)
                    {
                        this.CommitMessage += "{MULTIDEV}";
                    }
                    this.CommitMessage += "-" + textBoxLcsBugId.Text + ": " + textBoxLcsBugDescription.Text;
                }
                this.CommitMessage = this.CommitMessage.Trim();

                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonJira_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.myJira == null)
                {
                    if (string.IsNullOrWhiteSpace(Properties.Settings.Default.JiraServer) ||
                        string.IsNullOrWhiteSpace(Properties.Settings.Default.JiraUserName) ||
                        string.IsNullOrWhiteSpace(Properties.Settings.Default.JiraPassword))
                    {
                        FormJiraLogging logging = new FormJiraLogging();
                        logging.ShowDialog(this);
                    }

                    this.myJira = new Jira(Properties.Settings.Default.JiraServer.Trim(),
                                           Properties.Settings.Default.JiraUserName.Trim(),
                                           Properties.Settings.Default.JiraPassword.Trim());
                    this.myJira.Debug = false;
                    this.myJira.MaxIssuesPerRequest = int.MaxValue;
                }
                Issue jiraIssue = this.myJira.GetIssue(textBoxJiraId.Text.Trim());
                if (jiraIssue != null)
                {
                    textBoxJiraDescription.Text = jiraIssue.Summary;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Jira", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
