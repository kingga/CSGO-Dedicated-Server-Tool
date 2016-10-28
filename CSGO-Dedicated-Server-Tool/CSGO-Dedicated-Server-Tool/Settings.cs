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
    public partial class Settings : Form
    {
        public string _SERVER_INSTALL_DIR = "";

        public Settings()
        {
            InitializeComponent();

            using (StreamReader _sr = new StreamReader(Directory.GetCurrentDirectory() + @"\configs\config.cfg"))
            {
                string _line;
                string[] _lineTemp;

                while ((_line = _sr.ReadLine()) != null)
                {
                    _lineTemp = _line.Split('=');



                    if (_lineTemp[0] == "INSTALL_DIR")
                        _SERVER_INSTALL_DIR = _lineTemp[1];
                }
            }

            tbxServerLocation.Text = _SERVER_INSTALL_DIR;
        }

        private void btnFindServerLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog _folderDialog = new FolderBrowserDialog();

            if (_folderDialog.ShowDialog() == DialogResult.OK)
            {
                tbxServerLocation.Text = _folderDialog.SelectedPath;
                _SERVER_INSTALL_DIR = _folderDialog.SelectedPath;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _SERVER_INSTALL_DIR = tbxServerLocation.Text;

            using (StreamWriter _sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\configs\config.cfg", false))
            {
                _sw.WriteLine("INSTALL_DIR=" + _SERVER_INSTALL_DIR);
            }

            this.Hide();
        }
    }
}
