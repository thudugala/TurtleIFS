using System;
using System.ComponentModel;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using Atlassian.Jira;
using mshtml;
using TurtleIFS.Classes;

namespace TurtleIFS.Forms
{
    public partial class FormJiraIssueFinder : Form
    {
        public String CommitMessage { get; private set; }

        private NotifierLync myNotifierLync;
        private Jira myJira;
        private readonly string LCS_BUG_URI = "http://lcs.corpnet.ifsworld.com/login/secured/buglnw/BlBug.page?BUG_ID=";

        public FormJiraIssueFinder()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonJira.Checked)
                {
                    this.CommitMessage = textBoxIssueId.Text + ": " + textBoxDescription.Text;
                }
                else if (radioButtonLcs.Checked)
                {
                    this.CommitMessage = "LCS";
                    if (checkBoxMultidev.Checked)
                    {
                        this.CommitMessage += "{MULTIDEV}";
                    }
                    this.CommitMessage += "-" + textBoxIssueId.Text + ": " + textBoxDescription.Text;
                }
                this.CommitMessage = this.CommitMessage.Trim();

                this.SaveSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.JiraSelected = this.radioButtonJira.Checked;

            Properties.Settings.Default.Save();
        }

        private void buttonIssueFinder_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetControlVisibility(true);

                if (backgroundWorkerGetDescription.IsBusy == false)
                {
                    if (radioButtonJira.Checked)
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

                        backgroundWorkerGetDescription.RunWorkerAsync(new BwArguments(JobType.JIRA, textBoxIssueId.Text));
                    }
                    else if (radioButtonLcs.Checked)
                    {
                        backgroundWorkerGetDescription.RunWorkerAsync(new BwArguments(JobType.LCS, textBoxIssueId.Text));
                    }
                    else
                    {
                        this.SetControlVisibility(false);
                    }
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
                        textBoxDescription.Text = arg.Message;
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
            this.Cursor = (visible) ? Cursors.WaitCursor : Cursors.Default;

            progressBarLoding.Visible = visible;

            buttonIssueFinder.Enabled = !visible;
            buttonAdd.Enabled = !visible;
            buttonResetSettings.Enabled = !visible;
        }

        private void buttonResetSettings_Click(object sender, EventArgs e)
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

        #region Set Add Button Text

        private void SetAddButtonText()
        {
            if (radioButtonJira.Checked)
            {
                buttonAdd.Text = "Add JIRA Id";
            }
            else if (radioButtonLcs.Checked)
            {
                buttonAdd.Text = "Add LCS Id";
            }
        }

        private void radioButtonJira_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.SetAddButtonText();
            }
            catch (Exception)
            {
            }
        }

        private void radioButtonLcs_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.SetAddButtonText();
            }
            catch (Exception)
            {
            }
        }

        #endregion

        private void buttonContactSupport_Click(object sender, EventArgs e)
        {
            try
            {
                if (myNotifierLync != null)
                {
                    DialogResult contact = MessageBox.Show("Do you really need to contact Me? :| ",
                                                           "Contact Support",
                                                           MessageBoxButtons.YesNo);
                    if (contact == DialogResult.Yes)
                    {
                        myNotifierLync.SendMessage(projectsToolStripMenuItem.Checked, serviceAsetToolStripMenuItem.Checked);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void FormJiraIssueFinder_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text += " [" + Assembly.GetExecutingAssembly().GetName().Version + "]";

                if (Properties.Settings.Default.JiraSelected)
                {
                    this.radioButtonJira.Checked = true;
                }
                else
                {
                    this.radioButtonLcs.Checked = true;
                }

                myNotifierLync = new NotifierLync();
            }
            catch (Exception)
            {
                buttonContactSupport.Enabled = false;
            }
        }

        private void contextMenuStripProductGroup_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Properties.Settings.Default.SupportPerson) ||
                   Properties.Settings.Default.SupportPerson == Properties.Resources.SupportPersonOther)
                {
                    projectsToolStripMenuItem.Checked = false;
                    serviceAsetToolStripMenuItem.Checked = false;
                    otherToolStripMenuItem.Checked = true;
                }
                else if (Properties.Settings.Default.SupportPerson == Properties.Resources.SupportPersonProjects)
                {
                    projectsToolStripMenuItem.Checked = true;
                    serviceAsetToolStripMenuItem.Checked = false;
                    otherToolStripMenuItem.Checked = false;
                }
                else if (Properties.Settings.Default.SupportPerson == Properties.Resources.SupportPersonServiceAsset)
                {
                    projectsToolStripMenuItem.Checked = false;
                    serviceAsetToolStripMenuItem.Checked = true;
                    otherToolStripMenuItem.Checked = false;
                }
            }
            catch (Exception)
            {
            }
        }
    }
}