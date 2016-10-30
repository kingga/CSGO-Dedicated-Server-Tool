using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CSGO_Dedicated_Server_Tool
{
    public static class Server
    {
        public static bool StartServer(string _serverName, List<string> _procStartArgs)
        {
            // Turn the _procStartArgs into a single string
            StringBuilder _strBuilder = new StringBuilder();
            string _procArgsStr = "";
            _strBuilder.Append("start \"\" " + _serverName);

            // Refresh Arguments
            _procStartArgs.Clear();
            _procStartArgs.AddRange(Global._defaultProcArgs);
            _procStartArgs.AddRange(Global.cmdLineForm.GetCommandLineArgs());

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
                    string _batchDir = Global._SERVER_INSTALL_DIR;
                    Global._proc = new Process();
                    Global._proc.StartInfo.WorkingDirectory = _batchDir;
                    Global._proc.StartInfo.FileName = Global._SERVER_INSTALL_DIR + @"\" + _serverName;
                    Global._proc.StartInfo.Arguments = _procArgsStr;
                    Global._proc.StartInfo.CreateNoWindow = false;
                    Global._proc.Start();

                    Global._isProcNotRunningAllowed = false; // If the process crashes it will be restarted

                    return true;
                }
                else
                {
                    Console.WriteLine("Arguments are empty!");

                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred: {0},{1}", ex.Message, ex.StackTrace.ToString());
                MessageBox.Show("Exception Occurred: " + ex.Message + "\nServer Directory: " + Global._SERVER_INSTALL_DIR + "\nServer Name: " + Global._SERVER_LIST[Global._CURRENT_SERVER_INDEX], "Start Server Error!");

                return false;
            }
        }

        public static bool TerminateServer()
        {
            // Copy log to 'Logs' directory with a unique name (date/time)
            string _sourceFile = Path.Combine(Global._SERVER_INSTALL_DIR + @"\csgo\", "console.log");
            string _destFile = Path.Combine(Global._SERVER_LOG_DIR, DateTime.Now.ToString("yyyy-M-dd--HH-mm-ss") + "-console.log");
            string _destChatFile = Path.Combine(Global._SERVER_LOG_DIR, DateTime.Now.ToString("yyyy-M-dd--HH-mm-ss") + "-chat.log");

            try
            {
                try
                {
                    // Terminate the process
                    Global._proc.CloseMainWindow();
                    Global._proc.Close(); // Free memory
                    Global._proc = null; // Null _proc so it can be restarted

                    Global._isProcNotRunningAllowed = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception Occurred: {0},{1}", ex.Message, ex.StackTrace.ToString());
                    MessageBox.Show("Exception Occurred: " + ex.Message, "Close Server Error!");

                    return false;
                }

                // Check if the destination folder already exist else create it
                if (!Directory.Exists(Global._SERVER_LOG_DIR))
                {
                    Directory.CreateDirectory(Global._SERVER_LOG_DIR);
                }

                // Copy the log to the folder (NOTE: This will overwrite any previous version with the same name)
                File.Copy(_sourceFile, _destFile, true);

                // Write the chat log
                // Read from console.log
                string[] _lines;
                try
                {
                    _lines = File.ReadAllLines(_sourceFile);
                }
                catch (Exception)
                {
                    // Delay before copy (file is probaby in use)
                    System.Threading.Thread.Sleep(500);
                    _lines = File.ReadAllLines(_sourceFile);
                }

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

                    return true;
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
                    return true; // Break out of the function
                }

                return true;
            }
        }

        public static bool RestartServer(string _serverName)
        {
            bool _success;

            // Terminate Server
            _success = TerminateServer();

            // Check if 'serverName' is closed
            // Start the server
            if (Global._proc == null)
                _success = StartServer(_serverName, Global._procArgs);

            return _success;
        }

        public static bool CreateServer()
        {
            OpenFileDialog _fileDialog = new OpenFileDialog();

            if (_fileDialog.ShowDialog() == DialogResult.OK)
            {
                // Remove the server exe from the file path string
                string _dir = _fileDialog.FileName.Replace(_fileDialog.SafeFileName, "");

                try
                {
                    Global._SERVER_INSTALL_DIR = _dir;
                    Global._SERVER_NAME = _fileDialog.SafeFileName;
                    Global._SERVER_LIST.Add(Global._SERVER_NAME);

                    // Read from config.cfg -> redirect to config_servername.cfg
                
                    using (StreamWriter _sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\configs\config.cfg", true))
                    {
                        _sw.WriteLine("SERVER_NAME=" + Global._SERVER_NAME);

                        _sw.Close();
                    }

                    using (StreamWriter _sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\configs\config_" + Global._SERVER_NAME + ".cfg", false))
                    {
                        _sw.WriteLine("SERVER_NAME=" + Global._SERVER_NAME);
                        _sw.WriteLine("SERVER_DIR=" + Global._SERVER_INSTALL_DIR);

                        _sw.Close();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Message: " + ex.Message, "IO Error!", MessageBoxButtons.OK);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
