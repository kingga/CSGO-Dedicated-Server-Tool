using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSGO_Dedicated_Server_Tool
{
    public partial class MainForm : Form
    {
        bool _isProcNotRunningAllowed = true;           // This is used to see if the program crashed or if it was shut down manually
        Process _proc = null;                           // SRCDS Process
        List<string> _procArgs = new List<string>();    // SRCDS Arguments
        string[] _defaultProcArgs = { "-game csgo", "-console", "-condebug", "-usercon", "+net_port_trt 1", "+exec server.cfg" };

        string _filename = "srcds.exe";

        // Directories
        public string _SERVER_INSTALL_DIR = String.Format(@"C:\steam\");
        public string _SERVER_LOG_DIR = String.Format(@"C:\Steam\CSGO-Servers\Logs\");
        public string _SERVER_CRASH_LOG_DIR = String.Format(@"C:\Steam\CSGO-Servers\Logs\CrashLogs\");
        public string _SERVER_SAVED_LOG_DIR = String.Format(@"C:\Steam\CSGO-Servers\Logs\Saved\");

        // Forms
        CommandLineArgs cmdLineForm;

        public MainForm()
        {
            InitializeComponent();

            _procArgs.AddRange(_defaultProcArgs);

            // Init Forms
            cmdLineForm = new CommandLineArgs();
            cmdLineForm.ControlBox = false;

            // Read the Command Line Args config
            using (StreamReader _sr = new StreamReader(Directory.GetCurrentDirectory() + @"\configs\config_args.cfg"))
            {
                string _line;
                List<string> _tempArgs = new List<string>();

                while ((_line = _sr.ReadLine()) != null)
                {
                    _tempArgs.Add(_line);
                }

                cmdLineForm.SetCommandLineArgs(_tempArgs);
            }

            _procArgs.AddRange(cmdLineForm.GetCommandLineArgs());
        }

        // serverName will be enough to link to the x_server.exe (srcds) file where x is the value of serverName
        private void StartServer(string _serverName, List<string> _procStartArgs)
        {
            // Turn the _procStartArgs into a single string
            StringBuilder _strBuilder = new StringBuilder();
            string _procArgsStr = "";
            _strBuilder.Append("start \"\" " + _serverName);

            // Refresh Arguments
            _procStartArgs.Clear();
            _procStartArgs.AddRange(_defaultProcArgs);
            _procStartArgs.AddRange(cmdLineForm.GetCommandLineArgs());

            // Loop through each item in the list and append it to the string
            foreach (string _arg in _procStartArgs)
            {
                _strBuilder.Append(" " + _arg);
            }

            _procArgsStr = _strBuilder.ToString();

            Console.WriteLine("PROCESS ARGUMENT LINE: " + _procArgsStr);

            try
            {
                if (_procArgsStr != "") // Make sure there are some available arguments to parse through
                {
                    string _batchDir = _SERVER_INSTALL_DIR;
                    _proc = new Process();
                    _proc.StartInfo.WorkingDirectory = _batchDir;
                    _proc.StartInfo.FileName = _serverName /*+ "_server.exe"*/;
                    _proc.StartInfo.Arguments = _procArgsStr;
                    _proc.StartInfo.CreateNoWindow = false;
                    _proc.Start();

                    _isProcNotRunningAllowed = false; // If the process crashes it will be restarted

                    // Enable buttons
                    btnStopServer.Enabled = true;
                    btnRestartServer.Enabled = true;
                }
                else
                {
                    Console.WriteLine("Arguments are empty!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred: {0},{1}", ex.Message, ex.StackTrace.ToString());
                MessageBox.Show("Exception Occurred: " + ex.Message, "Start Server Error!");
            }
        }

        private void TerminateServer()
        {
            // Copy log to 'Logs' directory with a unique name (date/time)
            string _sourceFile = Path.Combine(_SERVER_INSTALL_DIR + @"csgo\", "console.log");
            string _destFile = Path.Combine(_SERVER_LOG_DIR, DateTime.Now.ToString("yyyy-M-dd--HH-mm-ss") + "-console.log");
            string _destChatFile = Path.Combine(_SERVER_LOG_DIR, DateTime.Now.ToString("yyyy-M-dd--HH-mm-ss") + "-chat.log");

            try
            {
                try
                {
                    // Terminate the process
                    _proc.CloseMainWindow();
                    _proc.Close(); // Free memory
                    _proc = null; // Null _proc so it can be restarted

                    _isProcNotRunningAllowed = true;

                    // Disbale butons
                    btnStopServer.Enabled = false;
                    btnRestartServer.Enabled = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception Occurred: {0},{1}", ex.Message, ex.StackTrace.ToString());
                    MessageBox.Show("Exception Occurred: " + ex.Message, "Close Server Error!");

                    // Disable buttons
                    btnStopServer.Enabled = false;
                    btnRestartServer.Enabled = false;
                }

                // Check if the destination folder already exist else create it
                if (!Directory.Exists(_SERVER_LOG_DIR))
                {
                    Directory.CreateDirectory(_SERVER_LOG_DIR);
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
                DialogResult _dialogResult = MessageBox.Show("The log file has failed to copy!\nWould you like to continue anyway?", "IO Error!", MessageBoxButtons.YesNo);
                if (_dialogResult == DialogResult.Yes)
                {
                    // Do Nothing
                }
                else if (_dialogResult == DialogResult.No)
                {
                    return; // Break out of the function
                }
            }
        }

        private void RestartServer(string _serverName)
        {
            // Terminate Server
            TerminateServer();

            // Check if 'serverName' is closed
            // Start the server
            if (_proc == null)
                StartServer(_serverName, _procArgs);
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

            if (_proc == null)
                StartServer(_filename, _procArgs);
            else
            {
                DialogResult _dialogResult = MessageBox.Show("The server is already running!\nWould you like to restart the server?", "Start Server", MessageBoxButtons.YesNo);

                if (_dialogResult == DialogResult.Yes)
                    RestartServer(_filename);
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

            if (!(_proc.HasExited) && _proc != null)
                TerminateServer();
            else
                MessageBox.Show("The server is currently not running!\nIf the server is running and this program fails to detect it please close the server manually.", "Close Server", MessageBoxButtons.OK);
        }

        private void btnRestartServer_Click(object sender, EventArgs e)
        {
            // Check if server is currently running and check if it is allowed to be 'not' running

            // TRUE
            // Restart Server

            // FALSE
            // PROMT - "THE SERVER IS CURRENTLY NOT RUNNING!\nIf the server is running and this program fails to detect it please close the server manually.", OK

            if (_proc != null)
                RestartServer(_filename);
        }

        private void btnLaunchOptions_Click(object sender, EventArgs e)
        {
            // Open a new form that gives a textbox where the user may enter their arguments
            // Supply a list of commonly used arguments below
            cmdLineForm.Show();
        }

        private void btnLogConsole_Click(object sender, EventArgs e)
        {
            // Copy the current session log and paste it in the 'Logs\Saved' folder with a unique name (date/time)
            // Copy log to 'Logs' directory with a unique name (date/time)
            string _sourceFile = Path.Combine(_SERVER_INSTALL_DIR + @"csgo\", "console.log");
            string _destFile = Path.Combine(_SERVER_SAVED_LOG_DIR, DateTime.Now.ToString("yyyy-M-dd--HH-mm-ss") + "-console.log");
            string _destChatFile = Path.Combine(_SERVER_SAVED_LOG_DIR, DateTime.Now.ToString("yyyy-M-dd--HH-mm-ss") + "-chat.log");

            try
            {
                // Check if the destination folder already exist else create it
                if (!Directory.Exists(_SERVER_SAVED_LOG_DIR))
                {
                    Directory.CreateDirectory(_SERVER_SAVED_LOG_DIR);
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
                MessageBox.Show("The log file has failed to copy!", "IO Error!");
            }
        }

        private void btnViewConsoleLog_Click(object sender, EventArgs e)
        {
            // VIEW CONSOLE LOG WILL SHOW THE LOG DIRECTORY
            string _folder = _SERVER_LOG_DIR;
            string _file = "*-console.log";
            string _uri = "search:query=" + _file + "&crumb=location:" + _folder;
            Process.Start(new ProcessStartInfo(_uri));
        }

        private void btnViewChatLog_Click(object sender, EventArgs e)
        {
            // VIEW CHAT LOG WILL SHOW THE LOG DIRECTORY
            string _folder = _SERVER_LOG_DIR;
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
                string _destFile = _SERVER_INSTALL_DIR + @"\csgo\cfg\" + _fileDialog.SafeFileName;

                try
                {
                    // Check if the destination folder already exist else create it
                    if (!Directory.Exists(_SERVER_INSTALL_DIR + @"\csgo\cfg\"))
                    {
                        Directory.CreateDirectory(_SERVER_INSTALL_DIR + @"\csgo\cfg\");
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
            string _installPath = _SERVER_INSTALL_DIR + @"\csgo\";

            if (!Directory.Exists(_SERVER_INSTALL_DIR + @"\csgo\addons\"))
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
                string _destFile = _SERVER_INSTALL_DIR + @"\csgo\addons\sourcemod\plugins\" + _fileDialog.SafeFileName;

                try
                {
                    // Check if the destination folder already exist else create it
                    if (!Directory.Exists(_SERVER_INSTALL_DIR + @"\csgo\addons\sourcemod\plugins\"))
                    {
                        Directory.CreateDirectory(_SERVER_INSTALL_DIR + @"\csgo\addons\sourcemod\plugins\");
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

        }

        private void btnAbout_Click(object sender, EventArgs e)
        {

        }

        // Used to check if the server crashed
        private void _refreshTimer_Tick(object sender, EventArgs e)
        {
            // Start server on crash
            if (_isProcNotRunningAllowed == false)
            {
                if (_proc.HasExited)
                {
                    // Log crash and restart the server
                    // Copy log to 'Logs' directory with a unique name (date/time)
                    string _sourceFile = Path.Combine(_SERVER_INSTALL_DIR + @"csgo\", "console.log");
                    string _destFolder = Path.Combine(_SERVER_CRASH_LOG_DIR, DateTime.Now.ToString("yyyy-M-dd--HH-mm-ss"));
                    string _destFile = Path.Combine(_destFolder, DateTime.Now.ToString("yyyy-M-dd--HH-mm-ss") + "-console.log");
                    string _crashInfoFile = Path.Combine(_destFolder, "CrashInfo.txt");
                    string _destChatFile = Path.Combine(_destFolder, DateTime.Now.ToString("yyyy-M-dd--HH-mm-ss") + "-chat.log");

                    try
                    {
                        // Check if the destination folder already exist else create it
                        if (!Directory.Exists(_SERVER_CRASH_LOG_DIR))
                        {
                            Directory.CreateDirectory(_SERVER_CRASH_LOG_DIR);
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

                    StartServer(_filename, _procArgs);
                }   
            }  
        }
    }
}
