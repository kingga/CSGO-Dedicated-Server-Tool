namespace CSGO_Dedicated_Server_Tool
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.lblServerDirectory = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbxServerLocation = new System.Windows.Forms.TextBox();
            this.btnFindServerLocation = new System.Windows.Forms.Button();
            this.lblServerName = new System.Windows.Forms.Label();
            this.tbxServerName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblServerDirectory
            // 
            this.lblServerDirectory.AutoSize = true;
            this.lblServerDirectory.Location = new System.Drawing.Point(13, 15);
            this.lblServerDirectory.Name = "lblServerDirectory";
            this.lblServerDirectory.Size = new System.Drawing.Size(86, 13);
            this.lblServerDirectory.TabIndex = 0;
            this.lblServerDirectory.Text = "Server Directory:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(335, 37);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbxServerLocation
            // 
            this.tbxServerLocation.Location = new System.Drawing.Point(106, 12);
            this.tbxServerLocation.Name = "tbxServerLocation";
            this.tbxServerLocation.Size = new System.Drawing.Size(223, 20);
            this.tbxServerLocation.TabIndex = 2;
            // 
            // btnFindServerLocation
            // 
            this.btnFindServerLocation.Location = new System.Drawing.Point(335, 10);
            this.btnFindServerLocation.Name = "btnFindServerLocation";
            this.btnFindServerLocation.Size = new System.Drawing.Size(75, 23);
            this.btnFindServerLocation.TabIndex = 3;
            this.btnFindServerLocation.Text = "Search";
            this.btnFindServerLocation.UseVisualStyleBackColor = true;
            this.btnFindServerLocation.Click += new System.EventHandler(this.btnFindServerLocation_Click);
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(13, 42);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(72, 13);
            this.lblServerName.TabIndex = 4;
            this.lblServerName.Text = "Server Name:";
            // 
            // tbxServerName
            // 
            this.tbxServerName.Location = new System.Drawing.Point(106, 39);
            this.tbxServerName.Name = "tbxServerName";
            this.tbxServerName.Size = new System.Drawing.Size(223, 20);
            this.tbxServerName.TabIndex = 5;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 72);
            this.Controls.Add(this.tbxServerName);
            this.Controls.Add(this.lblServerName);
            this.Controls.Add(this.btnFindServerLocation);
            this.Controls.Add(this.tbxServerLocation);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblServerDirectory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblServerDirectory;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox tbxServerLocation;
        private System.Windows.Forms.Button btnFindServerLocation;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.TextBox tbxServerName;
    }
}