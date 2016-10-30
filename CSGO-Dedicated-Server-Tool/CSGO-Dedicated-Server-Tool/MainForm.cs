using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace CSGO_Dedicated_Server_Tool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();   

            // Init Config Class
            Global._cfg = new Config();

            Global._procArgs.AddRange(Global._defaultProcArgs);

            // Init Command Line Form
            Global.cmdLineForm = new CommandLineArgs();
            Global.cmdLineForm.ControlBox = false;

            Global._cfg.ReadArgConfig();

            Global._procArgs.AddRange(Global.cmdLineForm.GetCommandLineArgs());

            Global._cfg.ReadDefaultConfig();

            lbxServers.Items.AddRange(Global._SERVER_LIST.ToArray());

            // Check if there are any servers otherwise prompt the user to create one
            if (lbxServers.Items.Count == 0)
            {
                bool _success = Server.CreateServer();
                if (_success)
                {
                    lbxServers.Items.Clear();
                    
                    // Populate the server listbox
                    lbxServers.Items.AddRange(Global._SERVER_LIST.ToArray());
                }
            }

            // Init Setting Form
            Global._settingsForm = new Settings();
            Global._settingsForm.ControlBox = false;

            Global._SERVER_LOG_DIR = Global._SERVER_INSTALL_DIR + @"\Logs\";
            Global._SERVER_CRASH_LOG_DIR = Global._SERVER_INSTALL_DIR + @"\Logs\CrashLogs\";
            Global._SERVER_SAVED_LOG_DIR = Global._SERVER_INSTALL_DIR + @"\Logs\Saved\";

            // Init Status Labels
            lblServerName.Text = "Server Name: " + Global._SERVER_NAME;
            lblServerDirectory.Text = "Server Directory: " + Global._SERVER_INSTALL_DIR;
            lblStatus.ForeColor = System.Drawing.Color.Red;
            lblStatus.Text = "Status: Stopped";
    }
        

        // Copy whole directories with content
        private bool CopyDirectory(string _strSource, string _strDestination)
        {
            if (!Directory.Exists(_strDestination))
            {
                Directory.CreateDirectory(_strDestination);
            }

            DirectoryInfo _dirInfo = new DirectoryInfo(_strSource);
            FileInfo[] _files = _dirInfo.GetFiles();
            foreach (FileInfo _tempfile in _files)
            {
                _tempfile.CopyTo(Path.Combine(_strDestination, _tempfile.Name));
            }

            DirectoryInfo[] _directories = _dirInfo.GetDirectories();
            foreach (DirectoryInfo _tempdir in _directories)
            {
                CopyDirectory(Path.Combine(_strSource, _tempdir.Name), Path.Combine(_strDestination, _tempdir.Name));
            }

            return true;
        }

        // BELOW THIS POINTS ARE ALL FUNCTIONS TO DO WITH BUTTON PRESSES

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            // Check if server is currently running

            // FALSE
            // Start Server

            // TRUE
            // PROMT - "SERVER ALREADY RUNNING!\nWould you like to restart the server?", YES/NO

            if (Global._proc == null)
            {
                bool _success = Server.StartServer(Global._SERVER_LIST.ElementAt(Global._CURRENT_SERVER_INDEX), Global._procArgs);
                if (_success)
                {
                    // Set the status label
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    lblStatus.Text = "Status: Running";

                    // Enable buttons
                    btnStopServer.Enabled = true;
                    btnRestartServer.Enabled = true;
                }
            }    
            else
            {
                DialogResult _dialogResult = MessageBox.Show("The server is already running!\nWould you like to restart the server?", "Start Server", MessageBoxButtons.YesNo);

                if (_dialogResult == DialogResult.Yes)
                {
                    bool _success = Server.RestartServer(Global._SERVER_NAME);
                    if (_success)
                    {
                        // Set the status label
                        lblStatus.ForeColor = System.Drawing.Color.Green;
                        lblStatus.Text = "Status: Running";

                        // Enable buttons
                        btnStopServer.Enabled = false;
                        btnRestartServer.Enabled = false;
                    }
                }
                    
                else if (_dialogResult == DialogResult.No)
                    return; // Break from the function
            }
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            // Check if server is currently running

            // TRUE
            // Terminate Server

            // FALSE
            // PROMT - "THE SERVER IS CURRENTLY NOT RUNNING!\nIf the server is running and this program fails to detect it please close the server manually.", OK

            if (!(Global._proc.HasExited) && Global._proc != null)
            {
                bool _success = Server.TerminateServer();
                if (_success)
                {
                    // Set the status label
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "Status: Stopped";

                    // Enable buttons
                    btnStopServer.Enabled = false;
                    btnRestartServer.Enabled = false;
                }
            }
                
            else
            {
                MessageBox.Show("The server is currently not running!\nIf the server is running and this program fails to detect it please close the server manually.", "Close Server", MessageBoxButtons.OK);

                // Set the status label
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Status: Stopped";

                btnStopServer.Enabled = false;
                btnStopServer.Enabled = false;
            }
                
        }

        private void btnRestartServer_Click(object sender, EventArgs e)
        {
            // Check if server is currently running and check if it is allowed to be 'not' running

            // TRUE
            // Restart Server

            // FALSE
            // PROMT - "THE SERVER IS CURRENTLY NOT RUNNING!\nIf the server is running and this program fails to detect it please close the server manually.", OK

            if (Global._proc != null)
            {
                bool _success = Server.RestartServer(Global._SERVER_NAME);
                if (_success)
                {
                    // Enable buttons
                    btnStopServer.Enabled = true;
                    btnRestartServer.Enabled = true;
                }
            }
        }

        private void btnLaunchOptions_Click(object sender, EventArgs e)
        {
            // Open a new form that gives a textbox where the user may enter their arguments
            // Supply a list of commonly used arguments below
            Global.cmdLineForm.ClearAndShow();
        }

        private void btnLogConsole_Click(object sender, EventArgs e)
        {
            // Copy the current session log and paste it in the 'Logs\Saved' folder with a unique name (date/time)
            // Copy log to 'Logs' directory with a unique name (date/time)
            string _sourceFile = Path.Combine(Global._SERVER_INSTALL_DIR + @"\csgo\", "console.log");
            string _destFile = Path.Combine(Global._SERVER_SAVED_LOG_DIR, DateTime.Now.ToString("yyyy-M-dd--HH-mm-ss") + "-console.log");
            string _destChatFile = Path.Combine(Global._SERVER_SAVED_LOG_DIR, DateTime.Now.ToString("yyyy-M-dd--HH-mm-ss") + "-chat.log");

            try
            {
                // Check if the destination folder already exist else create it
                if (!Directory.Exists(Global._SERVER_SAVED_LOG_DIR))
                {
                    Directory.CreateDirectory(Global._SERVER_SAVED_LOG_DIR);
                }

                // Copy the log to the folder (NOTE: This will overwrite any previous version with the same name)
                File.Copy(_sourceFile, _destFile, true);

                // Write the chat log
                // Read from console.log
                string[] _lines = File.ReadAllLines(_sourceFile);

                // Write each line that has " : " to a chat log
                using (StreamWriter _sw = new StreamWriter(_destChatFile))
                {
                    foreach (string _line in _lines)
                    {
                        if (_line.Contains(" : "))
                        {
                            _sw.WriteLine(_line);
                        }
                    }

                    _sw.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred: {0},{1}", ex.Message, ex.StackTrace.ToString());
                if (ex.Message.Contains("used by another process"))
                    MessageBox.Show("The log file has failed to copy!\nMake sure to close the server before you save the log!", "IO Error!");
                else
                    MessageBox.Show("The log file has failed to copy!\nMessage: " + ex.Message, "Error");
            }
        }

        private void btnViewConsoleLog_Click(object sender, EventArgs e)
        {
            // VIEW CONSOLE LOG WILL SHOW THE LOG DIRECTORY
            string _folder = Global._SERVER_LOG_DIR;
            string _file = "*-console.log";
            string _uri = "search:query=" + _file + "&crumb=location:" + _folder;
            Process.Start(new ProcessStartInfo(_uri));
        }

        private void btnViewChatLog_Click(object sender, EventArgs e)
        {
            // VIEW CHAT LOG WILL SHOW THE LOG DIRECTORY
            string _folder = Global._SERVER_LOG_DIR;
            string _file = "*-chat.log";
            string _uri = "search:query=" + _file + "&crumb=location:" + _folder;
            Process.Start(new ProcessStartInfo(_uri));
        }

        private void btnImportConfigFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog _fileDialog = new OpenFileDialog();

            if (_fileDialog.ShowDialog() == DialogResult.OK)
            {
                string _sourceFile = Path.Combine(_fileDialog.FileName);
                string _destFile = Global._SERVER_INSTALL_DIR + @"\csgo\cfg\" + _fileDialog.SafeFileName;

                try
                {
                    // Check if the destination folder already exist else create it
                    if (!Directory.Exists(Global._SERVER_INSTALL_DIR + @"\csgo\cfg\"))
                    {
                        Directory.CreateDirectory(Global._SERVER_INSTALL_DIR + @"\csgo\cfg\");
                    }

                    // Copy the log to the folder (NOTE: This will overwrite any previous version with the same name)
                    File.Copy(_sourceFile, _destFile, true);

                    if (File.Exists(_destFile))
                    {
                        MessageBox.Show("Config file " + _fileDialog.SafeFileName + " has been imported!", "Import Config", MessageBoxButtons.OK);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception Occurred: {0},{1}", ex.Message, ex.StackTrace.ToString());
                    MessageBox.Show("The config file has failed to copy!", "IO Error!");
                }
            }
        }

        private void btnInstallMetamodSourcemod_Click(object sender, EventArgs e)
        {
            // Install Metamod
            string _sourcePath = Directory.GetCurrentDirectory() + @"\downloads\";
            string _installPath = Global._SERVER_INSTALL_DIR + @"\csgo\";

            if (!Directory.Exists(Global._SERVER_INSTALL_DIR + @"\csgo\addons\"))
            {
                bool _copied = CopyDirectory(_sourcePath, _installPath);

                if (_copied)
                {
                    MessageBox.Show("Metamod/Sourcemod Installed!", "Installer!", MessageBoxButtons.OK);
                    btnImportPlugin.Enabled = true;
                }
            }
            else
                btnImportPlugin.Enabled = true;
        }

        private void btnImportPlugin_Click(object sender, EventArgs e)
        {
            OpenFileDialog _fileDialog = new OpenFileDialog();

            if (_fileDialog.ShowDialog() == DialogResult.OK)
            {
                string _sourceFile = Path.Combine(_fileDialog.FileName);
                string _destFile = Global._SERVER_INSTALL_DIR + @"\csgo\addons\sourcemod\plugins\" + _fileDialog.SafeFileName;

                try
                {
                    // Check if the destination folder already exist else create it
                    if (!Directory.Exists(Global._SERVER_INSTALL_DIR + @"\csgo\addons\sourcemod\plugins\"))
                    {
                        Directory.CreateDirectory(Global._SERVER_INSTALL_DIR + @"\csgo\addons\sourcemod\plugins\");
                    }

                    // Copy the log to the folder (NOTE: This will overwrite any previous version with the same name)
                    File.Copy(_sourceFile, _destFile, true);

                    if (File.Exists(_destFile))
                    {
                        MessageBox.Show("Sourcemod plugin " + _fileDialog.SafeFileName + " has been imported!", "Import Plugin", MessageBoxButtons.OK);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception Occurred: {0},{1}", ex.Message, ex.StackTrace.ToString());
                    MessageBox.Show("The plugin has failed to copy!", "IO Error!");
                }
            }
        }

        private void btnBackupServer_Click(object sender, EventArgs e)
        {

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            // Update textboxes
            Global._settingsForm.UpdateTextBoxes(Global._SERVER_INSTALL_DIR, Global._SERVER_NAME);

            Global._settingsForm.Show();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Author: Isaac Skelton (/id/Kingga)\nDescription: A tool that helps with running a dedicated server.\nVersion: " + Global._APPLICATION_VERSION, "About", MessageBoxButtons.OK);
        }

        // Used to check if the server crashed also to update some labels (Main Loopish) - I lied, this isn't a button press
        private void _refreshTimer_Tick(object sender, EventArgs e)
        {
            // Start server on crash
            if (Global._isProcNotRunningAllowed == false)
            {
                if (Global._proc.HasExited)
                {
                    // Log crash and restart the server
                    // Copy log to 'Logs' directory with a unique name (date/time)
                    string _sourceFile = Path.Combine(Global._SERVER_INSTALL_DIR + @"\csgo\", "console.log");
                    string _destFolder = Path.Combine(Global._SERVER_CRASH_LOG_DIR, DateTime.Now.ToString("yyyy-M-dd--HH-mm-ss"));
                    string _destFile = Path.Combine(_destFolder, DateTime.Now.ToString("yyyy-M-dd--HH-mm-ss") + "-console.log");
                    string _crashInfoFile = Path.Combine(_destFolder, "CrashInfo.txt");
                    string _destChatFile = Path.Combine(_destFolder, DateTime.Now.ToString("yyyy-M-dd--HH-mm-ss") + "-chat.log");

                    // Set the status label
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "Status: Stopped";

                    try
                    {
                        // Check if the destination folder already exist else create it
                        if (!Directory.Exists(Global._SERVER_CRASH_LOG_DIR))
                        {
                            Directory.CreateDirectory(Global._SERVER_CRASH_LOG_DIR);
                        }

                        // Copy the log to the folder (NOTE: This will overwrite any previous version with the same name)
                        Directory.CreateDirectory(_destFolder);
                        File.Copy(_sourceFile, _destFile, true);

                        // Write the chat log
                        // Read from console.log
                        string[] _lines = File.ReadAllLines(_sourceFile);

                        // Write each line that has " : " to a chat log
                        using (StreamWriter _sw = new StreamWriter(_destChatFile))
                        {
                            foreach (string _line in _lines)
                            {
                                if (_line.Contains(" : "))
                                {
                                    _sw.WriteLine(_line);
                                }
                            }

                            _sw.Close();
                        }

                        // Write crash information to a file
                        using (StreamWriter _sr = new StreamWriter(_crashInfoFile))
                        {
                            _sr.WriteLine("CRASH DATE (yyyy-m-dd): " + DateTime.Now.ToString("yyyy-M-dd"));
                            _sr.WriteLine("CRASH TIME (HH-mm-ss): " + DateTime.Now.ToString("HH-mm-ss"));
                            _sr.WriteLine("LOG FILE: " + _destFile);
                            _sr.WriteLine("CHAT FILE: " + _destChatFile);

                            _sr.Close();
                        }     
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception Occurred: {0},{1}", ex.Message, ex.StackTrace.ToString());
                        MessageBox.Show("The log file has failed to copy!", "IO Error!");
                    }

                    bool _success = Server.StartServer(Global._SERVER_LIST.ElementAt(Global._CURRENT_SERVER_INDEX), Global._procArgs);
                    if (_success)
                    {
                        // Enable buttons
                        btnStopServer.Enabled = true;
                        btnRestartServer.Enabled = true;
                    }
                }
                else
                {
                    // Set the status label
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    lblStatus.Text = "Status: Running";
                }   
            }

            // Set labels
            lblServerName.Text = "Server Name: " + Global._SERVER_NAME;
            lblServerDirectory.Text = "Server Directory: " + Global._SERVER_INSTALL_DIR;

            // Refresh the arg list
            Global._cfg.ReadArgConfig();
        }

        private void lbxServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Global._CURRENT_SERVER_INDEX = lbxServers.SelectedIndex;

            try // Sometimes it selects index -1
            {
                using (StreamReader _sr = new StreamReader(Directory.GetCurrentDirectory() + @"\configs\config_" + lbxServers.SelectedItem + ".cfg"))
                {
                    string _line;
                    string[] _lineTemp;

                    while ((_line = _sr.ReadLine()) != null)
                    {
                        _lineTemp = _line.Split('=');

                        if (_lineTemp[0] == "SERVER_DIR")
                            Global._SERVER_INSTALL_DIR = _lineTemp[1];
                        if (_lineTemp[0] == "SERVER_NAME")
                            Global._SERVER_NAME = _lineTemp[1];
                    }

                    _sr.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Message: " + ex.Message);
            }
            

            // Set labels
            lblServerName.Text = "Server Name: " + Global._SERVER_NAME;
            lblServerDirectory.Text = "Server Directory: " + Global._SERVER_INSTALL_DIR;

            // Refresh the arg list
            Global._cfg.ReadArgConfig();
        }

        private void btnAddServer_Click(object sender, EventArgs e)
        {
            // Safe to config
            // Add to listbox
            // Select in listbox

            bool _success = Server.CreateServer();

            lbxServers.Items.Clear();
            lbxServers.Items.AddRange(Global._SERVER_LIST.ToArray());

            if (_success)
            {
                lbxServers.Refresh();
                lbxServers.SelectedIndex = Global._CURRENT_SERVER_INDEX;
            }

            // Refresh the start up args
            Global._cfg.ReadArgConfig();
        }

        private void btnRemoveServer_Click(object sender, EventArgs e)
        {

        }
    }
}