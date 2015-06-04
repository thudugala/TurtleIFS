using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TurtleEazyCheckout.Forms;

namespace TestTurtleIFS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string originalMessage = string.Empty;

                FormJiraIssueFinder issueFinder = new FormJiraIssueFinder();

                if (issueFinder.ShowDialog() == DialogResult.OK)
                {
                    originalMessage = issueFinder.CommitMessage;
                }              
            }
            catch (Exception)
            {                
                
            }
        }
    }
}
