using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CSGO_Dedicated_Server_Tool
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            tbxServerLocation.Text = Global._SERVER_INSTALL_DIR;
            try
            {
                tbxServerName.Text = Global._SERVER_LIST[Global._CURRENT_SERVER_INDEX];
            }
            catch (Exception)
            {
                Application.Exit();
            }
        }

        private void btnFindServerLocation_Click(object sender, EventArgs e)
        {
            OpenFileDialog _fileDialog = new OpenFileDialog();

            if (_fileDialog.ShowDialog() == DialogResult.OK)
            {
                string _dir = _fileDialog.FileName.Replace(_fileDialog.SafeFileName, "");
                MessageBox.Show(_dir);
                tbxServerLocation.Text = _dir;

                tbxServerName.Text = _fileDialog.SafeFileName;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Global._SERVER_INSTALL_DIR = tbxServerLocation.Text;
                Global._SERVER_NAME = tbxServerName.Text;

                try
                {
                    Global._SERVER_LIST[Global._CURRENT_SERVER_INDEX] = tbxServerName.Text;
                }
                catch (Exception)
                {
                    Application.Exit();
                }
                

                // Read from config.cfg -> redirect to config_servername.cfg
                using (StreamWriter _sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\configs\config.cfg", true))
                {
                    _sw.WriteLine("SERVER_NAME=" + Global._SERVER_LIST[Global._CURRENT_SERVER_INDEX]);

                    _sw.Close();
                }

                using (StreamWriter _sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\configs\config_" + Global._SERVER_NAME + ".cfg", false))
                {
                    _sw.WriteLine("SERVER_NAME=" + Global._SERVER_LIST[Global._CURRENT_SERVER_INDEX]);
                    _sw.WriteLine("SERVER_DIR=" + Global._SERVER_INSTALL_DIR);

                    _sw.Close();
                }

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Message: " + ex.Message, "Error");
            }

            
        }

        public void UpdateTextBoxes(string _dir, string _serverName)
        {
            tbxServerLocation.Text = _dir;
            tbxServerName.Text = _serverName;
        }
    }
}
