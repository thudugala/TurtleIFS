using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TurtleIFS.Forms
{
    public partial class FormJiraLogging : Form
    {
        public FormJiraLogging()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Saving Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
