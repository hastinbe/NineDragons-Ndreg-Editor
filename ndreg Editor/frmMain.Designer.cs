//  Copyright (c) 2012 Beau Hastings. All rights reserved.
//  License: GNU GPL version 2, see LICENSE for more details.
//  Author: Beau Hastings <beausy@gmail.com>
namespace ndreg_Editor
{
    partial class frmMain
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
            this.lblStatusServer = new System.Windows.Forms.Label();
            this.lblStatusPort = new System.Windows.Forms.Label();
            this.lblPatchServer = new System.Windows.Forms.Label();
            this.lblLoginServer = new System.Windows.Forms.Label();
            this.lblLoginPort = new System.Windows.Forms.Label();
            this.txtStatusServer = new System.Windows.Forms.TextBox();
            this.txtStatusPort = new System.Windows.Forms.TextBox();
            this.txtPatchServer = new System.Windows.Forms.TextBox();
            this.txtLoginServer = new System.Windows.Forms.TextBox();
            this.txtLoginPort = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblStatusServer
            //
            this.lblStatusServer.AutoSize = true;
            this.lblStatusServer.Location = new System.Drawing.Point(15, 18);
            this.lblStatusServer.Name = "lblStatusServer";
            this.lblStatusServer.Size = new System.Drawing.Size(84, 18);
            this.lblStatusServer.TabIndex = 0;
            this.lblStatusServer.Text = "Status server:";
            //
            // lblStatusPort
            //
            this.lblStatusPort.AutoSize = true;
            this.lblStatusPort.Location = new System.Drawing.Point(272, 18);
            this.lblStatusPort.Name = "lblStatusPort";
            this.lblStatusPort.Size = new System.Drawing.Size(74, 18);
            this.lblStatusPort.TabIndex = 1;
            this.lblStatusPort.Text = "Status port:";
            //
            // lblPatchServer
            //
            this.lblPatchServer.AutoSize = true;
            this.lblPatchServer.Location = new System.Drawing.Point(15, 113);
            this.lblPatchServer.Name = "lblPatchServer";
            this.lblPatchServer.Size = new System.Drawing.Size(82, 18);
            this.lblPatchServer.TabIndex = 2;
            this.lblPatchServer.Text = "Patch server:";
            //
            // lblLoginServer
            //
            this.lblLoginServer.AutoSize = true;
            this.lblLoginServer.Location = new System.Drawing.Point(15, 65);
            this.lblLoginServer.Name = "lblLoginServer";
            this.lblLoginServer.Size = new System.Drawing.Size(79, 18);
            this.lblLoginServer.TabIndex = 3;
            this.lblLoginServer.Text = "Login server:";
            //
            // lblLoginPort
            //
            this.lblLoginPort.AutoSize = true;
            this.lblLoginPort.Location = new System.Drawing.Point(271, 65);
            this.lblLoginPort.Name = "lblLoginPort";
            this.lblLoginPort.Size = new System.Drawing.Size(69, 18);
            this.lblLoginPort.TabIndex = 4;
            this.lblLoginPort.Text = "Login port:";
            //
            // txtStatusServer
            //
            this.txtStatusServer.Location = new System.Drawing.Point(18, 40);
            this.txtStatusServer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStatusServer.MaxLength = 32;
            this.txtStatusServer.Name = "txtStatusServer";
            this.txtStatusServer.Size = new System.Drawing.Size(247, 21);
            this.txtStatusServer.TabIndex = 1;
            //
            // txtStatusPort
            //
            this.txtStatusPort.Location = new System.Drawing.Point(275, 40);
            this.txtStatusPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStatusPort.MaxLength = 5;
            this.txtStatusPort.Name = "txtStatusPort";
            this.txtStatusPort.Size = new System.Drawing.Size(86, 21);
            this.txtStatusPort.TabIndex = 2;
            //
            // txtPatchServer
            //
            this.txtPatchServer.Location = new System.Drawing.Point(18, 135);
            this.txtPatchServer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPatchServer.MaxLength = 64;
            this.txtPatchServer.Name = "txtPatchServer";
            this.txtPatchServer.Size = new System.Drawing.Size(342, 21);
            this.txtPatchServer.TabIndex = 3;
            //
            // txtLoginServer
            //
            this.txtLoginServer.Location = new System.Drawing.Point(18, 88);
            this.txtLoginServer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLoginServer.MaxLength = 32;
            this.txtLoginServer.Name = "txtLoginServer";
            this.txtLoginServer.Size = new System.Drawing.Size(247, 21);
            this.txtLoginServer.TabIndex = 4;
            //
            // txtLoginPort
            //
            this.txtLoginPort.Location = new System.Drawing.Point(275, 88);
            this.txtLoginPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLoginPort.MaxLength = 5;
            this.txtLoginPort.Name = "txtLoginPort";
            this.txtLoginPort.Size = new System.Drawing.Size(86, 21);
            this.txtLoginPort.TabIndex = 5;
            //
            // btnSave
            //
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(276, 170);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 27);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnReload
            //
            this.btnReload.Location = new System.Drawing.Point(185, 170);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(85, 27);
            this.btnReload.TabIndex = 6;
            this.btnReload.Text = "&Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            //
            // btnBackup
            //
            this.btnBackup.Location = new System.Drawing.Point(94, 170);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(85, 27);
            this.btnBackup.TabIndex = 8;
            this.btnBackup.Text = "&Backup";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            //
            // frmMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 211);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtLoginPort);
            this.Controls.Add(this.txtLoginServer);
            this.Controls.Add(this.txtPatchServer);
            this.Controls.Add(this.txtStatusPort);
            this.Controls.Add(this.txtStatusServer);
            this.Controls.Add(this.lblLoginPort);
            this.Controls.Add(this.lblLoginServer);
            this.Controls.Add(this.lblPatchServer);
            this.Controls.Add(this.lblStatusPort);
            this.Controls.Add(this.lblStatusServer);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.Text = "ndreg Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatusServer;
        private System.Windows.Forms.Label lblStatusPort;
        private System.Windows.Forms.Label lblPatchServer;
        private System.Windows.Forms.Label lblLoginServer;
        private System.Windows.Forms.Label lblLoginPort;
        private System.Windows.Forms.TextBox txtStatusServer;
        private System.Windows.Forms.TextBox txtStatusPort;
        private System.Windows.Forms.TextBox txtPatchServer;
        private System.Windows.Forms.TextBox txtLoginServer;
        private System.Windows.Forms.TextBox txtLoginPort;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnBackup;
    }
}

