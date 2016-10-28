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
            this.lblServerDirectory = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbxServerLocation = new System.Windows.Forms.TextBox();
            this.btnFindServerLocation = new System.Windows.Forms.Button();
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
            this.btnOK.Location = new System.Drawing.Point(335, 39);
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
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 72);
            this.Controls.Add(this.btnFindServerLocation);
            this.Controls.Add(this.tbxServerLocation);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblServerDirectory);
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
    }
}