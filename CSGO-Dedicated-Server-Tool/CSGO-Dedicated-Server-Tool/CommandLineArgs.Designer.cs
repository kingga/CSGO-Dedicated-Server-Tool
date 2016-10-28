namespace CSGO_Dedicated_Server_Tool
{
    partial class CommandLineArgs
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
            this.lblTickRate = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblMaxPlayers = new System.Windows.Forms.Label();
            this.lblMap = new System.Windows.Forms.Label();
            this.lblGameMode = new System.Windows.Forms.Label();
            this.lblSteamAccount = new System.Windows.Forms.Label();
            this.lblWorkshopCollection = new System.Windows.Forms.Label();
            this.lblWorkshopStartMap = new System.Windows.Forms.Label();
            this.lblAuthKey = new System.Windows.Forms.Label();
            this.lblCustom = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.cmbTickRate = new System.Windows.Forms.ComboBox();
            this.tbxPort = new System.Windows.Forms.TextBox();
            this.tbxIP = new System.Windows.Forms.TextBox();
            this.cmbGameMode = new System.Windows.Forms.ComboBox();
            this.tbxMap = new System.Windows.Forms.TextBox();
            this.numMaxPlayers = new System.Windows.Forms.NumericUpDown();
            this.tbxSteamAccount = new System.Windows.Forms.TextBox();
            this.tbxWorkshopStartMap = new System.Windows.Forms.TextBox();
            this.tbxWorkshopCollection = new System.Windows.Forms.TextBox();
            this.tbxAuthKey = new System.Windows.Forms.TextBox();
            this.tbxCustom = new System.Windows.Forms.TextBox();
            this.lnkSteamAccountCode = new System.Windows.Forms.LinkLabel();
            this.lnkAuthKey = new System.Windows.Forms.LinkLabel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTickRate
            // 
            this.lblTickRate.AutoSize = true;
            this.lblTickRate.Location = new System.Drawing.Point(12, 68);
            this.lblTickRate.Name = "lblTickRate";
            this.lblTickRate.Size = new System.Drawing.Size(57, 13);
            this.lblTickRate.TabIndex = 1;
            this.lblTickRate.Text = "Tick Rate:";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(12, 42);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 13);
            this.lblPort.TabIndex = 3;
            this.lblPort.Text = "Port:";
            // 
            // lblMaxPlayers
            // 
            this.lblMaxPlayers.AutoSize = true;
            this.lblMaxPlayers.Location = new System.Drawing.Point(12, 147);
            this.lblMaxPlayers.Name = "lblMaxPlayers";
            this.lblMaxPlayers.Size = new System.Drawing.Size(67, 13);
            this.lblMaxPlayers.TabIndex = 4;
            this.lblMaxPlayers.Text = "Max Players:";
            // 
            // lblMap
            // 
            this.lblMap.AutoSize = true;
            this.lblMap.Location = new System.Drawing.Point(12, 122);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(31, 13);
            this.lblMap.TabIndex = 5;
            this.lblMap.Text = "Map:";
            // 
            // lblGameMode
            // 
            this.lblGameMode.AutoSize = true;
            this.lblGameMode.Location = new System.Drawing.Point(12, 95);
            this.lblGameMode.Name = "lblGameMode";
            this.lblGameMode.Size = new System.Drawing.Size(68, 13);
            this.lblGameMode.TabIndex = 6;
            this.lblGameMode.Text = "Game Mode:";
            // 
            // lblSteamAccount
            // 
            this.lblSteamAccount.AutoSize = true;
            this.lblSteamAccount.Location = new System.Drawing.Point(246, 16);
            this.lblSteamAccount.Name = "lblSteamAccount";
            this.lblSteamAccount.Size = new System.Drawing.Size(111, 13);
            this.lblSteamAccount.TabIndex = 7;
            this.lblSteamAccount.Text = "Steam Account Code:";
            // 
            // lblWorkshopCollection
            // 
            this.lblWorkshopCollection.AutoSize = true;
            this.lblWorkshopCollection.Location = new System.Drawing.Point(246, 68);
            this.lblWorkshopCollection.Name = "lblWorkshopCollection";
            this.lblWorkshopCollection.Size = new System.Drawing.Size(108, 13);
            this.lblWorkshopCollection.TabIndex = 8;
            this.lblWorkshopCollection.Text = "Workshop Collection:";
            // 
            // lblWorkshopStartMap
            // 
            this.lblWorkshopStartMap.AutoSize = true;
            this.lblWorkshopStartMap.Location = new System.Drawing.Point(246, 42);
            this.lblWorkshopStartMap.Name = "lblWorkshopStartMap";
            this.lblWorkshopStartMap.Size = new System.Drawing.Size(108, 13);
            this.lblWorkshopStartMap.TabIndex = 9;
            this.lblWorkshopStartMap.Text = "Workshop Start Map:";
            // 
            // lblAuthKey
            // 
            this.lblAuthKey.AutoSize = true;
            this.lblAuthKey.Location = new System.Drawing.Point(246, 95);
            this.lblAuthKey.Name = "lblAuthKey";
            this.lblAuthKey.Size = new System.Drawing.Size(105, 13);
            this.lblAuthKey.TabIndex = 10;
            this.lblAuthKey.Text = "Workshop Auth Key:";
            // 
            // lblCustom
            // 
            this.lblCustom.AutoSize = true;
            this.lblCustom.Location = new System.Drawing.Point(12, 175);
            this.lblCustom.Name = "lblCustom";
            this.lblCustom.Size = new System.Drawing.Size(45, 13);
            this.lblCustom.TabIndex = 11;
            this.lblCustom.Text = "Custom:";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(12, 16);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(20, 13);
            this.lblIP.TabIndex = 0;
            this.lblIP.Text = "IP:";
            // 
            // cmbTickRate
            // 
            this.cmbTickRate.FormattingEnabled = true;
            this.cmbTickRate.Items.AddRange(new object[] {
            "102.4",
            "128",
            "64"});
            this.cmbTickRate.Location = new System.Drawing.Point(106, 65);
            this.cmbTickRate.Name = "cmbTickRate";
            this.cmbTickRate.Size = new System.Drawing.Size(121, 21);
            this.cmbTickRate.TabIndex = 12;
            // 
            // tbxPort
            // 
            this.tbxPort.Location = new System.Drawing.Point(106, 39);
            this.tbxPort.Name = "tbxPort";
            this.tbxPort.Size = new System.Drawing.Size(121, 20);
            this.tbxPort.TabIndex = 13;
            // 
            // tbxIP
            // 
            this.tbxIP.Location = new System.Drawing.Point(106, 13);
            this.tbxIP.Name = "tbxIP";
            this.tbxIP.Size = new System.Drawing.Size(121, 20);
            this.tbxIP.TabIndex = 14;
            // 
            // cmbGameMode
            // 
            this.cmbGameMode.FormattingEnabled = true;
            this.cmbGameMode.Items.AddRange(new object[] {
            "Competitive",
            "Casual",
            "Deathmatch",
            "Arms Race",
            "Demolition"});
            this.cmbGameMode.Location = new System.Drawing.Point(106, 92);
            this.cmbGameMode.Name = "cmbGameMode";
            this.cmbGameMode.Size = new System.Drawing.Size(121, 21);
            this.cmbGameMode.TabIndex = 15;
            // 
            // tbxMap
            // 
            this.tbxMap.Location = new System.Drawing.Point(106, 119);
            this.tbxMap.Name = "tbxMap";
            this.tbxMap.Size = new System.Drawing.Size(121, 20);
            this.tbxMap.TabIndex = 16;
            // 
            // numMaxPlayers
            // 
            this.numMaxPlayers.Location = new System.Drawing.Point(106, 145);
            this.numMaxPlayers.Name = "numMaxPlayers";
            this.numMaxPlayers.Size = new System.Drawing.Size(121, 20);
            this.numMaxPlayers.TabIndex = 17;
            // 
            // tbxSteamAccount
            // 
            this.tbxSteamAccount.Location = new System.Drawing.Point(399, 13);
            this.tbxSteamAccount.Name = "tbxSteamAccount";
            this.tbxSteamAccount.Size = new System.Drawing.Size(211, 20);
            this.tbxSteamAccount.TabIndex = 18;
            // 
            // tbxWorkshopStartMap
            // 
            this.tbxWorkshopStartMap.Location = new System.Drawing.Point(399, 39);
            this.tbxWorkshopStartMap.Name = "tbxWorkshopStartMap";
            this.tbxWorkshopStartMap.Size = new System.Drawing.Size(211, 20);
            this.tbxWorkshopStartMap.TabIndex = 19;
            // 
            // tbxWorkshopCollection
            // 
            this.tbxWorkshopCollection.Location = new System.Drawing.Point(399, 65);
            this.tbxWorkshopCollection.Name = "tbxWorkshopCollection";
            this.tbxWorkshopCollection.Size = new System.Drawing.Size(211, 20);
            this.tbxWorkshopCollection.TabIndex = 20;
            // 
            // tbxAuthKey
            // 
            this.tbxAuthKey.Location = new System.Drawing.Point(399, 92);
            this.tbxAuthKey.Name = "tbxAuthKey";
            this.tbxAuthKey.Size = new System.Drawing.Size(211, 20);
            this.tbxAuthKey.TabIndex = 21;
            // 
            // tbxCustom
            // 
            this.tbxCustom.Location = new System.Drawing.Point(106, 172);
            this.tbxCustom.Name = "tbxCustom";
            this.tbxCustom.Size = new System.Drawing.Size(504, 20);
            this.tbxCustom.TabIndex = 22;
            // 
            // lnkSteamAccountCode
            // 
            this.lnkSteamAccountCode.AutoSize = true;
            this.lnkSteamAccountCode.Location = new System.Drawing.Point(12, 220);
            this.lnkSteamAccountCode.Name = "lnkSteamAccountCode";
            this.lnkSteamAccountCode.Size = new System.Drawing.Size(153, 13);
            this.lnkSteamAccountCode.TabIndex = 23;
            this.lnkSteamAccountCode.TabStop = true;
            this.lnkSteamAccountCode.Text = "Get Your Steam Account Code";
            this.lnkSteamAccountCode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSteamAccountCode_LinkClicked);
            // 
            // lnkAuthKey
            // 
            this.lnkAuthKey.AutoSize = true;
            this.lnkAuthKey.Location = new System.Drawing.Point(12, 239);
            this.lnkAuthKey.Name = "lnkAuthKey";
            this.lnkAuthKey.Size = new System.Drawing.Size(95, 13);
            this.lnkAuthKey.TabIndex = 24;
            this.lnkAuthKey.TabStop = true;
            this.lnkAuthKey.Text = "Get Your Auth Key";
            this.lnkAuthKey.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAuthKey_LinkClicked);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(534, 228);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 25;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(453, 228);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // CommandLineArgs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 261);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lnkAuthKey);
            this.Controls.Add(this.lnkSteamAccountCode);
            this.Controls.Add(this.tbxCustom);
            this.Controls.Add(this.tbxAuthKey);
            this.Controls.Add(this.tbxWorkshopCollection);
            this.Controls.Add(this.tbxWorkshopStartMap);
            this.Controls.Add(this.tbxSteamAccount);
            this.Controls.Add(this.numMaxPlayers);
            this.Controls.Add(this.tbxMap);
            this.Controls.Add(this.cmbGameMode);
            this.Controls.Add(this.tbxIP);
            this.Controls.Add(this.tbxPort);
            this.Controls.Add(this.cmbTickRate);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.lblCustom);
            this.Controls.Add(this.lblAuthKey);
            this.Controls.Add(this.lblWorkshopStartMap);
            this.Controls.Add(this.lblWorkshopCollection);
            this.Controls.Add(this.lblSteamAccount);
            this.Controls.Add(this.lblGameMode);
            this.Controls.Add(this.lblMap);
            this.Controls.Add(this.lblMaxPlayers);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblTickRate);
            this.Name = "CommandLineArgs";
            this.Text = "Command Line Arguments";
            this.Load += new System.EventHandler(this.CommandLineArgs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numMaxPlayers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTickRate;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblMaxPlayers;
        private System.Windows.Forms.Label lblMap;
        private System.Windows.Forms.Label lblGameMode;
        private System.Windows.Forms.Label lblSteamAccount;
        private System.Windows.Forms.Label lblWorkshopCollection;
        private System.Windows.Forms.Label lblWorkshopStartMap;
        private System.Windows.Forms.Label lblAuthKey;
        private System.Windows.Forms.Label lblCustom;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.ComboBox cmbTickRate;
        private System.Windows.Forms.TextBox tbxPort;
        private System.Windows.Forms.TextBox tbxIP;
        private System.Windows.Forms.ComboBox cmbGameMode;
        private System.Windows.Forms.TextBox tbxMap;
        private System.Windows.Forms.NumericUpDown numMaxPlayers;
        private System.Windows.Forms.TextBox tbxSteamAccount;
        private System.Windows.Forms.TextBox tbxWorkshopStartMap;
        private System.Windows.Forms.TextBox tbxWorkshopCollection;
        private System.Windows.Forms.TextBox tbxAuthKey;
        private System.Windows.Forms.TextBox tbxCustom;
        private System.Windows.Forms.LinkLabel lnkSteamAccountCode;
        private System.Windows.Forms.LinkLabel lnkAuthKey;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}