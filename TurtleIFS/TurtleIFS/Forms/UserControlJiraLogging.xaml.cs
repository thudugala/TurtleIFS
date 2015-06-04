using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TurtleEazyCheckout.Forms
{
    /// <summary>
    /// Interaction logic for UserControlJiraLogging.xaml
    /// </summary>
    public partial class UserControlJiraLogging : UserControl
    {
        public delegate void SaveButtonEventHandler(object sender, EventArgs args);
        public event SaveButtonEventHandler OnSaveButtonClick;

        public UserControlJiraLogging()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Properties.Settings.Default.JiraPassword = passwordBoxPassword.Password;
                Properties.Settings.Default.Save();

                if (this.OnSaveButtonClick != null)
                {
                    this.OnSaveButtonClick(this, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Saving Settings", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
