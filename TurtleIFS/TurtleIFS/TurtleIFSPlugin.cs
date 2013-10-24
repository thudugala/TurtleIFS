using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using TurtleIFS.Classes;
using TurtleIFS.Forms;
using System.Windows.Forms;

namespace TurtleIFS
{
    [ComVisible(true), Guid("DD5D4E0F-9012-4333-AFD4-0F9CC45C8C89"), ClassInterface(ClassInterfaceType.None)]
    public class TurtleIFSPlugin : Interop.BugTraqProvider.IBugTraqProvider
    {
        private List<TicketItem> selectedTickets = new List<TicketItem>();

        public bool ValidateParameters(IntPtr hParentWnd, string parameters)
        {
            return true;
        }

        public string GetLinkText(IntPtr hParentWnd, string parameters)
        {
            return "Select Jira Issue";
        }
                
        public string GetCommitMessage(IntPtr hParentWnd, string parameters, string commonRoot, string[] pathList, string originalMessage)
        {
            try
            {
                FormJiraIssueFinder issueFinder = new FormJiraIssueFinder();

                if (issueFinder.ShowDialog() != DialogResult.OK)
                {
                    return originalMessage;
                }
                else
                {
                    return issueFinder.CommitMessage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CommitMessage2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }                          
    }
}
