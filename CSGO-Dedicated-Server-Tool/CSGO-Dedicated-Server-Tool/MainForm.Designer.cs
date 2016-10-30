namespace CSGO_Dedicated_Server_Tool
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnStartServer = new System.Windows.Forms.Button();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.pnlBasicControls = new System.Windows.Forms.Panel();
            this.btnLaunchOptions = new System.Windows.Forms.Button();
            this.btnRestartServer = new System.Windows.Forms.Button();
            this.pnlLogging = new System.Windows.Forms.Panel();
            this.btnViewChatLog = new System.Windows.Forms.Button();
            this.btnViewConsoleLog = new System.Windows.Forms.Button();
            this.btnLogConsole = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnInstallMetamodSourcemod = new System.Windows.Forms.Button();
            this.btnImportPlugin = new System.Windows.Forms.Button();
            this.btnImportConfigFile = new System.Windows.Forms.Button();
            this.pnlMisc = new System.Windows.Forms.Panel();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnBackupServer = new System.Windows.Forms.Button();
            this._refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblServerDirectory = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblServerName = new System.Windows.Forms.Label();
            this.pnlServers = new System.Windows.Forms.Panel();
            this.lbxServers = new System.Windows.Forms.ListBox();
            this.tbxServerName = new System.Windows.Forms.TextBox();
            this.lblCreateServerName = new System.Windows.Forms.Label();
            this.btnAddServer = new System.Windows.Forms.Button();
            this.btnRemoveServer = new System.Windows.Forms.Button();
            this.pnlBasicControls.SuspendLayout();
            this.pnlLogging.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlMisc.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.pnlServers.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(3, 3);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(153, 23);
            this.btnStartServer.TabIndex = 0;
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // btnStopServer
            // 
            this.btnStopServer.Enabled = false;
            this.btnStopServer.Location = new System.Drawing.Point(3, 32);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(153, 23);
            this.btnStopServer.TabIndex = 1;
            this.btnStopServer.Text = "Stop Server";
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // pnlBasicControls
            // 
            this.pnlBasicControls.Controls.Add(this.btnLaunchOptions);
            this.pnlBasicControls.Controls.Add(this.btnRestartServer);
            this.pnlBasicControls.Controls.Add(this.btnStartServer);
            this.pnlBasicControls.Controls.Add(this.btnStopServer);
            this.pnlBasicControls.Location = new System.Drawing.Point(13, 13);
            this.pnlBasicControls.Name = "pnlBasicControls";
            this.pnlBasicControls.Size = new System.Drawing.Size(159, 120);
            this.pnlBasicControls.TabIndex = 2;
            // 
            // btnLaunchOptions
            // 
            this.btnLaunchOptions.Location = new System.Drawing.Point(4, 92);
            this.btnLaunchOptions.Name = "btnLaunchOptions";
            this.btnLaunchOptions.Size = new System.Drawing.Size(152, 23);
            this.btnLaunchOptions.TabIndex = 3;
            this.btnLaunchOptions.Text = "Launch Options";
            this.btnLaunchOptions.UseVisualStyleBackColor = true;
            this.btnLaunchOptions.Click += new System.EventHandler(this.btnLaunchOptions_Click);
            // 
            // btnRestartServer
            // 
            this.btnRestartServer.Enabled = false;
            this.btnRestartServer.Location = new System.Drawing.Point(4, 62);
            this.btnRestartServer.Name = "btnRestartServer";
            this.btnRestartServer.Size = new System.Drawing.Size(152, 23);
            this.btnRestartServer.TabIndex = 2;
            this.btnRestartServer.Text = "Restart Server";
            this.btnRestartServer.UseVisualStyleBackColor = true;
            this.btnRestartServer.Click += new System.EventHandler(this.btnRestartServer_Click);
            // 
            // pnlLogging
            // 
            this.pnlLogging.Controls.Add(this.btnViewChatLog);
            this.pnlLogging.Controls.Add(this.btnViewConsoleLog);
            this.pnlLogging.Controls.Add(this.btnLogConsole);
            this.pnlLogging.Location = new System.Drawing.Point(13, 139);
            this.pnlLogging.Name = "pnlLogging";
            this.pnlLogging.Size = new System.Drawing.Size(159, 92);
            this.pnlLogging.TabIndex = 3;
            // 
            // btnViewChatLog
            // 
            this.btnViewChatLog.Location = new System.Drawing.Point(4, 64);
            this.btnViewChatLog.Name = "btnViewChatLog";
            this.btnViewChatLog.Size = new System.Drawing.Size(152, 23);
            this.btnViewChatLog.TabIndex = 2;
            this.btnViewChatLog.Text = "View Chat Log";
            this.btnViewChatLog.UseVisualStyleBackColor = true;
            this.btnViewChatLog.Click += new System.EventHandler(this.btnViewChatLog_Click);
            // 
            // btnViewConsoleLog
            // 
            this.btnViewConsoleLog.Location = new System.Drawing.Point(4, 34);
            this.btnViewConsoleLog.Name = "btnViewConsoleLog";
            this.btnViewConsoleLog.Size = new System.Drawing.Size(152, 23);
            this.btnViewConsoleLog.TabIndex = 1;
            this.btnViewConsoleLog.Text = "View Console Log";
            this.btnViewConsoleLog.UseVisualStyleBackColor = true;
            this.btnViewConsoleLog.Click += new System.EventHandler(this.btnViewConsoleLog_Click);
            // 
            // btnLogConsole
            // 
            this.btnLogConsole.Location = new System.Drawing.Point(4, 4);
            this.btnLogConsole.Name = "btnLogConsole";
            this.btnLogConsole.Size = new System.Drawing.Size(152, 23);
            this.btnLogConsole.TabIndex = 0;
            this.btnLogConsole.Text = "Log Console";
            this.btnLogConsole.UseVisualStyleBackColor = true;
            this.btnLogConsole.Click += new System.EventHandler(this.btnLogConsole_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnInstallMetamodSourcemod);
            this.panel1.Controls.Add(this.btnImportPlugin);
            this.panel1.Controls.Add(this.btnImportConfigFile);
            this.panel1.Location = new System.Drawing.Point(13, 238);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(159, 91);
            this.panel1.TabIndex = 4;
            // 
            // btnInstallMetamodSourcemod
            // 
            this.btnInstallMetamodSourcemod.Location = new System.Drawing.Point(4, 34);
            this.btnInstallMetamodSourcemod.Name = "btnInstallMetamodSourcemod";
            this.btnInstallMetamodSourcemod.Size = new System.Drawing.Size(152, 23);
            this.btnInstallMetamodSourcemod.TabIndex = 2;
            this.btnInstallMetamodSourcemod.Text = "Install Metamod/Sourcemod";
            this.btnInstallMetamodSourcemod.UseVisualStyleBackColor = true;
            this.btnInstallMetamodSourcemod.Click += new System.EventHandler(this.btnInstallMetamodSourcemod_Click);
            // 
            // btnImportPlugin
            // 
            this.btnImportPlugin.Enabled = false;
            this.btnImportPlugin.Location = new System.Drawing.Point(4, 63);
            this.btnImportPlugin.Name = "btnImportPlugin";
            this.btnImportPlugin.Size = new System.Drawing.Size(152, 23);
            this.btnImportPlugin.TabIndex = 1;
            this.btnImportPlugin.Text = "Import Plugin";
            this.btnImportPlugin.UseVisualStyleBackColor = true;
            this.btnImportPlugin.Click += new System.EventHandler(this.btnImportPlugin_Click);
            // 
            // btnImportConfigFile
            // 
            this.btnImportConfigFile.Location = new System.Drawing.Point(4, 4);
            this.btnImportConfigFile.Name = "btnImportConfigFile";
            this.btnImportConfigFile.Size = new System.Drawing.Size(152, 23);
            this.btnImportConfigFile.TabIndex = 0;
            this.btnImportConfigFile.Text = "Import Config File";
            this.btnImportConfigFile.UseVisualStyleBackColor = true;
            this.btnImportConfigFile.Click += new System.EventHandler(this.btnImportConfigFile_Click);
            // 
            // pnlMisc
            // 
            this.pnlMisc.Controls.Add(this.btnAbout);
            this.pnlMisc.Controls.Add(this.btnSettings);
            this.pnlMisc.Controls.Add(this.btnBackupServer);
            this.pnlMisc.Location = new System.Drawing.Point(13, 336);
            this.pnlMisc.Name = "pnlMisc";
            this.pnlMisc.Size = new System.Drawing.Size(159, 90);
            this.pnlMisc.TabIndex = 5;
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(4, 62);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(152, 23);
            this.btnAbout.TabIndex = 2;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(4, 33);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(152, 23);
            this.btnSettings.TabIndex = 1;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnBackupServer
            // 
            this.btnBackupServer.Location = new System.Drawing.Point(4, 4);
            this.btnBackupServer.Name = "btnBackupServer";
            this.btnBackupServer.Size = new System.Drawing.Size(152, 23);
            this.btnBackupServer.TabIndex = 0;
            this.btnBackupServer.Text = "Backup Server";
            this.btnBackupServer.UseVisualStyleBackColor = true;
            this.btnBackupServer.Click += new System.EventHandler(this.btnBackupServer_Click);
            // 
            // _refreshTimer
            // 
            this._refreshTimer.Enabled = true;
            this._refreshTimer.Interval = 5000;
            this._refreshTimer.Tick += new System.EventHandler(this._refreshTimer_Tick);
            // 
            // pnlStatus
            // 
            this.pnlStatus.Controls.Add(this.lblServerDirectory);
            this.pnlStatus.Controls.Add(this.lblStatus);
            this.pnlStatus.Controls.Add(this.lblServerName);
            this.pnlStatus.Location = new System.Drawing.Point(178, 13);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(286, 85);
            this.pnlStatus.TabIndex = 6;
            // 
            // lblServerDirectory
            // 
            this.lblServerDirectory.AutoSize = true;
            this.lblServerDirectory.Location = new System.Drawing.Point(3, 32);
            this.lblServerDirectory.Name = "lblServerDirectory";
            this.lblServerDirectory.Size = new System.Drawing.Size(86, 13);
            this.lblServerDirectory.TabIndex = 2;
            this.lblServerDirectory.Text = "Server Directory:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(3, 62);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Status:";
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(3, 3);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(72, 13);
            this.lblServerName.TabIndex = 0;
            this.lblServerName.Text = "Server Name:";
            // 
            // pnlServers
            // 
            this.pnlServers.Controls.Add(this.btnRemoveServer);
            this.pnlServers.Controls.Add(this.btnAddServer);
            this.pnlServers.Controls.Add(this.lblCreateServerName);
            this.pnlServers.Controls.Add(this.tbxServerName);
            this.pnlServers.Controls.Add(this.lbxServers);
            this.pnlServers.Location = new System.Drawing.Point(178, 105);
            this.pnlServers.Name = "pnlServers";
            this.pnlServers.Size = new System.Drawing.Size(286, 321);
            this.pnlServers.TabIndex = 7;
            // 
            // lbxServers
            // 
            this.lbxServers.FormattingEnabled = true;
            this.lbxServers.Location = new System.Drawing.Point(3, 3);
            this.lbxServers.Name = "lbxServers";
            this.lbxServers.Size = new System.Drawing.Size(280, 225);
            this.lbxServers.TabIndex = 0;
            this.lbxServers.SelectedIndexChanged += new System.EventHandler(this.lbxServers_SelectedIndexChanged);
            // 
            // tbxServerName
            // 
            this.tbxServerName.Location = new System.Drawing.Point(81, 236);
            this.tbxServerName.Name = "tbxServerName";
            this.tbxServerName.Size = new System.Drawing.Size(201, 20);
            this.tbxServerName.TabIndex = 1;
            // 
            // lblCreateServerName
            // 
            this.lblCreateServerName.AutoSize = true;
            this.lblCreateServerName.Location = new System.Drawing.Point(3, 239);
            this.lblCreateServerName.Name = "lblCreateServerName";
            this.lblCreateServerName.Size = new System.Drawing.Size(72, 13);
            this.lblCreateServerName.TabIndex = 2;
            this.lblCreateServerName.Text = "Server Name:";
            // 
            // btnAddServer
            // 
            this.btnAddServer.Location = new System.Drawing.Point(3, 263);
            this.btnAddServer.Name = "btnAddServer";
            this.btnAddServer.Size = new System.Drawing.Size(278, 23);
            this.btnAddServer.TabIndex = 3;
            this.btnAddServer.Text = "Add Server";
            this.btnAddServer.UseVisualStyleBackColor = true;
            this.btnAddServer.Click += new System.EventHandler(this.btnAddServer_Click);
            // 
            // btnRemoveServer
            // 
            this.btnRemoveServer.Location = new System.Drawing.Point(3, 293);
            this.btnRemoveServer.Name = "btnRemoveServer";
            this.btnRemoveServer.Size = new System.Drawing.Size(278, 23);
            this.btnRemoveServer.TabIndex = 4;
            this.btnRemoveServer.Text = "Remove Server";
            this.btnRemoveServer.UseVisualStyleBackColor = true;
            this.btnRemoveServer.Click += new System.EventHandler(this.btnRemoveServer_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 438);
            this.Controls.Add(this.pnlServers);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.pnlMisc);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlLogging);
            this.Controls.Add(this.pnlBasicControls);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "CS:GO Dedicated Server Tool";
            this.pnlBasicControls.ResumeLayout(false);
            this.pnlLogging.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlMisc.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.pnlServers.ResumeLayout(false);
            this.pnlServers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.Panel pnlBasicControls;
        private System.Windows.Forms.Button btnLaunchOptions;
        private System.Windows.Forms.Button btnRestartServer;
        private System.Windows.Forms.Panel pnlLogging;
        private System.Windows.Forms.Button btnViewChatLog;
        private System.Windows.Forms.Button btnViewConsoleLog;
        private System.Windows.Forms.Button btnLogConsole;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnInstallMetamodSourcemod;
        private System.Windows.Forms.Button btnImportPlugin;
        private System.Windows.Forms.Button btnImportConfigFile;
        private System.Windows.Forms.Panel pnlMisc;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnBackupServer;
        private System.Windows.Forms.Timer _refreshTimer;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblServerDirectory;
        private System.Windows.Forms.Panel pnlServers;
        private System.Windows.Forms.ListBox lbxServers;
        private System.Windows.Forms.Label lblCreateServerName;
        private System.Windows.Forms.TextBox tbxServerName;
        private System.Windows.Forms.Button btnRemoveServer;
        private System.Windows.Forms.Button btnAddServer;
    }
}

