using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CSGO_Dedicated_Server_Tool
{
    class Config
    {
        public void ReadDefaultConfig()
        {
            using (StreamReader _sr = new StreamReader(Directory.GetCurrentDirectory() + @"\configs\config.cfg", false))
            {
                string _line;
                string[] _lineTemp;

                while ((_line = _sr.ReadLine()) != null)
                {
                    _lineTemp = _line.Split('=');

                    if (_lineTemp[0] == "SERVER_NAME")
                        Global._SERVER_LIST.Add(_lineTemp[1]);
                }

                _sr.Close();
            }
        }

        public void ReadArgConfig()
        {
            // Create the config file if it doesn't exist
            if (!File.Exists(Directory.GetCurrentDirectory() + @"\configs\config_args" + Global._SERVER_NAME + ".cfg"))
            {
                using (FileStream _fs = File.Create(Directory.GetCurrentDirectory() + @"\configs\config_args" + Global._SERVER_NAME + ".cfg"))
                {
                    _fs.Close();
                }

                ReadArgConfig();
            }
            else
            {
                // Read the Command Line Args config
                try
                {
                    using (StreamReader _sr = new StreamReader(Directory.GetCurrentDirectory() + @"\configs\config_args" + Global._SERVER_NAME + ".cfg"))
                    {
                        string _line;
                        List<string> _tempArgs = new List<string>();

                        while ((_line = _sr.ReadLine()) != null)
                        {
                            _tempArgs.Add(_line);
                        }

                        Global.cmdLineForm.SetCommandLineArgs(_tempArgs);

                        _sr.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to read config!\nMessage: " + ex.Message);
                }
            }
        }
    }
}
