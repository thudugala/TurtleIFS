using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Lync.Model.Extensibility;
using Microsoft.Lync.Model;

namespace TurtleIFS.Classes
{
    internal class NotifierLync
    {
        private Automation _Automation;
        private List<string> inviteeList;
        private Dictionary<AutomationModalitySettings, object> _ModalitySettings;
        private AutomationModalities _ChosenMode;

        private string subject = "IFS Issue Finder";

        internal NotifierLync()
        {
            try
            {
                _Automation = LyncClient.GetAutomation();

                // Create a generic Dictionary object to contain conversation setting objects.
                _ModalitySettings = new Dictionary<AutomationModalitySettings, object>();
                _ModalitySettings.Add(AutomationModalitySettings.Subject, subject);
                _ModalitySettings.Add(AutomationModalitySettings.SendFirstInstantMessageImmediately, true);

                _ChosenMode = AutomationModalities.InstantMessage;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void SendMessage(bool productGroupProject, bool productGroupServiceAsset)
        {
            Properties.Settings.Default.SupportPerson = Properties.Resources.SupportPersonOther;
            if (productGroupProject)
            {
                Properties.Settings.Default.SupportPerson = Properties.Resources.SupportPersonProjects;
            }
            else if (productGroupServiceAsset)
            {
                Properties.Settings.Default.SupportPerson = Properties.Resources.SupportPersonServiceAsset;
            }

            this.SendMessage(Properties.Settings.Default.SupportPerson, Properties.Resources.HeaderMessage);
        }

        internal void SendMessage(string inviteeEmail, string imText)
        {
            try
            {
                // Create a generic List object to contain a contact URI.
                // Ensure that a valid URI is added.
                inviteeList = new List<string>();
                inviteeList.Add(inviteeEmail);

                if (_ModalitySettings.ContainsKey(AutomationModalitySettings.FirstInstantMessage))
                {
                    _ModalitySettings[AutomationModalitySettings.FirstInstantMessage] = subject + "! : " + imText;
                }
                else
                {
                    _ModalitySettings.Add(AutomationModalitySettings.FirstInstantMessage, subject + "! : " + imText);
                }
                // Start the conversation.
                IAsyncResult ar = _Automation.BeginStartConversation(_ChosenMode,
                                                                     inviteeList,
                                                                     _ModalitySettings,
                                                                     null,
                                                                     null);


                //Block UI thread until conversation is started
                _Automation.EndStartConversation(ar);
            }
            catch (Exception)
            {

            }
        }
    }
}
