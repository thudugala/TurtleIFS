using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Atlassian.Jira;
using System.Net;
using System.IO;
using mshtml;
using TurtleIFS.Classes;

namespace TurtleIFS.Forms
{
    public partial class FormJiraIssueFinder : Form
    {
        public String CommitMessage { get; private set; }

        private Jira myJira;
        private readonly string LCS_BUG_URI = "http://lcs.corpnet.ifsworld.com/login/secured/buglnw/BlBug.page?BUG_ID=";

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
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonJira_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetControlVisibility(true);

                if (backgroundWorkerGetDescription.IsBusy == false)
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

                    backgroundWorkerGetDescription.RunWorkerAsync(new BwArguments(JobType.JIRA, textBoxJiraId.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error Jira", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonLcs_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetControlVisibility(true);

                if (backgroundWorkerGetDescription.IsBusy == false)
                {
                    backgroundWorkerGetDescription.RunWorkerAsync(new BwArguments(JobType.LCS, textBoxLcsBugId.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error Jira", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorkerGetDescription_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // Do not access the form's BackgroundWorker reference directly.
                // Instead, use the reference provided by the sender parameter.
                BackgroundWorker worker = sender as BackgroundWorker;

                if (worker.CancellationPending == false)
                {
                    BwArguments arg = e.Argument as BwArguments;

                    if (arg.Type == JobType.JIRA)
                    {
                        arg.Message = this.GetJiraDescription(arg.ID);
                    }
                    else if (arg.Type == JobType.LCS)
                    {
                        arg.Message = this.GetLcsDescription(arg.ID);
                    }

                    e.Result = arg;
                }

                // If the operation was canceled by the user, 
                // set the DoWorkEventArgs.Cancel property to true.
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception)
            {
                //throw the exception so that RunWorkerCompleted can catch it.
                throw;
            }
        }

        private string GetLcsDescription(string lcsId)
        {
            if (string.IsNullOrWhiteSpace(lcsId) == false)
            {
                WebClient client = new WebClient();
                client.Headers.Add("user-agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/6.0)");
                client.UseDefaultCredentials = true;

                string htmlContent = client.DownloadString(this.LCS_BUG_URI + lcsId);

                // Obtain the document interface
                IHTMLDocument2 htmlDocument = (IHTMLDocument2)new mshtml.HTMLDocument();

                // Construct the document
                htmlDocument.write(htmlContent);

                // Extract all elements
                IHTMLElementCollection allElements = htmlDocument.all;

                bool bugTitlefound = false;
                foreach (IHTMLElement element in allElements)
                {
                    if (element.outerText == "Bug Title")
                    {
                        bugTitlefound = true;
                    }
                    if (bugTitlefound &&
                        string.IsNullOrWhiteSpace(element.outerText) == false &&
                        element.outerText != "Bug Title")
                    {
                        return element.outerText;
                    }
                }
            }
            return string.Empty;
        }

        private string GetJiraDescription(string JiraId)
        {
            if (string.IsNullOrWhiteSpace(JiraId) == false)
            {
                Issue jiraIssue = this.myJira.GetIssue(JiraId);
                if (jiraIssue != null)
                {
                    return jiraIssue.Summary;
                }
            }
            return string.Empty;
        }

        private void backgroundWorkerGetDescription_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (e.Result != null && e.Result is BwArguments)
                    {
                        BwArguments arg = (e.Result as BwArguments);
                        if (arg.Type == JobType.JIRA)
                        {
                            textBoxJiraDescription.Text = arg.Message;
                        }
                        else if (arg.Type == JobType.LCS)
                        {
                            textBoxLcsBugDescription.Text = arg.Message;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.SetControlVisibility(false);
            }
        }

        private void SetControlVisibility(bool visible)
        {
            progressBarLoding.Visible = visible;
            buttonJira.Enabled = !visible;
            buttonLcs.Enabled = !visible;
            buttonOk.Enabled = !visible;
        }

        private void resetSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
