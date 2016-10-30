using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSGO_Dedicated_Server_Tool
{
    public partial class CommandLineArgs : Form
    {
        List<string> _cmdArgs = new List<string>();

        public CommandLineArgs()
        {
            InitializeComponent();
        }

        // Returns the command line args back to the main form
        public List<string> GetCommandLineArgs()
        {
            return _cmdArgs;
        }

        public void SetCommandLineArgs(List<string> _args)
        {
            _cmdArgs = _args;
        }

        private void lnkSteamAccountCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lnkSteamAccountCode.LinkVisited = true;
            try
            {
                System.Diagnostics.Process.Start("https://steamcommunity.com/dev/managegameservers"); // Default Browser
            }
            catch(Exception)
            {
                System.Diagnostics.Process.Start("iexplore.exe", "https://steamcommunity.com/dev/managegameservers");
            } 
        }

        private void lnkAuthKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lnkSteamAccountCode.LinkVisited = true;
            try
            {
                System.Diagnostics.Process.Start("http://steamcommunity.com/dev/apikey");
            }
            catch (Exception)
            {
                System.Diagnostics.Process.Start("iexplore.exe", "http://steamcommunity.com/dev/apikey");
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Clear CMDARGS
            _cmdArgs.Clear();

            // Add the values to the list
            if (tbxIP.Text != "")
                _cmdArgs.Add("-ip " + tbxIP.Text.Trim());

            if (tbxPort.Text != "")
                _cmdArgs.Add("-port " + tbxPort.Text.Trim());

            if (cmbTickRate.SelectedItem != null)
                _cmdArgs.Add("-tickrate " + cmbTickRate.SelectedItem.ToString().Trim());

            if (cmbGameMode.SelectedItem != null)
            {
                switch (cmbGameMode.SelectedItem.ToString().Trim())
                {
                    case "Competitive":
                        _cmdArgs.Add("+game_mode 1 +game_type 0");
                        break;
                    case "Casual":
                        _cmdArgs.Add("+game_mode 0 +game_type 0");
                        break;
                    case "Deathmatch":
                        _cmdArgs.Add("+game_mode 2 +game_type 1");
                        break;
                    case "Arms Race":
                        _cmdArgs.Add("+game_mode 0 +game_type 1");
                        break;
                    case "Demolition":
                        _cmdArgs.Add("+game_mode 1 +game_type 1");
                        break;
                }
            }

            if (tbxMap.Text != "")
                _cmdArgs.Add("+map " + tbxMap.Text.Trim());

            if (numMaxPlayers.Value == 0)
                _cmdArgs.Add("-maxplayers 10");
            else
                _cmdArgs.Add("-maxplayers " + numMaxPlayers.Value.ToString().Trim());

            if (tbxSteamAccount.Text != "")
                _cmdArgs.Add("+sv_setsteamaccount " + tbxSteamAccount.Text.Trim());

            if (tbxWorkshopStartMap.Text != "")
                _cmdArgs.Add("+workshop_start_map " + tbxWorkshopStartMap.Text.Trim());

            if (tbxWorkshopCollection.Text != "")
                _cmdArgs.Add("+host_workshop_collection " + tbxWorkshopCollection.Text.Trim());

            if (tbxAuthKey.Text != "")
                _cmdArgs.Add("-authkey " + tbxAuthKey.Text.Trim());

            // Add the custom commands to the list
            string[] _customArgs = tbxCustom.Text.Split(' ');

            foreach (string _arg in _customArgs)
            {
                _cmdArgs.Add(" " + _arg.Trim());
            }

            // Save to config file (config_args.cfg)
            using (StreamWriter _sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\configs\config_args" + Global._SERVER_NAME + ".cfg", false))
            {
                foreach (string _arg in _cmdArgs)
                {
                    _sw.WriteLine(_arg);
                }

                _sw.Close();
            }

            Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        public void ClearAndShow()
        {
            this.Show();

            tbxIP.Clear();
            tbxPort.Clear();
            cmbTickRate.SelectedValue = null;
            cmbGameMode.SelectedValue = null;
            tbxMap.Clear();
            numMaxPlayers.Value = 0;
            tbxSteamAccount.Clear();
            tbxWorkshopStartMap.Clear();
            tbxWorkshopCollection.Clear();
            tbxAuthKey.Clear();
            tbxCustom.Clear();

            // Set textboxes
            foreach (string _arg in _cmdArgs)
            {
                string[] _temp = _arg.Split(' ');

                if (_temp[0] == "-ip")
                    tbxIP.Text = _temp[1];
                else if (_temp[0] == "-port")
                    tbxPort.Text = _temp[1];
                else if (_temp[0] == "-tickrate")
                    cmbTickRate.SelectedValue = _temp[1].Trim();
                else if (_temp[0] == "+game_mode")
                {
                    if (_temp[1] == "0" && _temp[3] == "0")
                        cmbGameMode.SelectedItem = "Casual";
                    else if (_temp[1] == "1" && _temp[3] == "0")
                        cmbGameMode.SelectedItem = "Competitive";
                    else if (_temp[1] == "0" && _temp[3] == "1")
                        cmbGameMode.SelectedItem = "Arms Race";
                    else if (_temp[1] == "1" && _temp[3] == "1")
                        cmbGameMode.SelectedItem = "Demolition";
                    else if (_temp[1] == "1" && _temp[3] == "2")
                        cmbGameMode.SelectedItem = "Deathmatch";
                }

                else if (_temp[0] == "+map")
                    tbxMap.Text = _temp[1];
                else if (_temp[0] == "-maxplayers")
                    numMaxPlayers.Value = int.Parse(_temp[1]);
                else if (_temp[0] == "+sv_setsteamaccount")
                    tbxSteamAccount.Text = _temp[1];
                else if (_temp[0] == "+workshop_start_map")
                    tbxWorkshopStartMap.Text = _temp[1];
                else if (_temp[0] == "+host_workshop_collection")
                    tbxWorkshopCollection.Text = _temp[1];
                else if (_temp[0] == "-authkey")
                    tbxAuthKey.Text = _temp[1];
            }
        }

        private void CommandLineArgs_Load(object sender, EventArgs e)
        {
            // Init textboxes
            ClearAndShow();
        }
    }
}
