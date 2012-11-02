//  Copyright (c) 2012 Beau Hastings. All rights reserved.
//  License: GNU GPL version 2, see LICENSE for more details.
//  Author: Beau Hastings <beausy@gmail.com>
using System;
using System.IO;
using System.Windows.Forms;
using ndreg_Editor.Data;
using ndreg_Editor.Utilities;

namespace ndreg_Editor
{
    public partial class frmMain : Form
    {
        string ndreg_path = Application.StartupPath + @"\ndreg.xrg";
        NdcInfo ndc_info = new NdcInfo();
        const uint XOR_INT = 0xDCDCDCDC;
        const uint XOR_CHAR = 0xDC;

        public frmMain()
        {
            InitializeComponent();
            loadNdreg(ndreg_path);
        }

        private void reloadNdreg(string path)
        {
            NdcInfo ndc_info = new NdcInfo();
            loadNdreg(path);
        }

        private void loadNdreg(string path)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show("File not found: " + path,
                    "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] search = new Byte[16] {
                0x6E, 0x64, 0x63, 0x20, 0x69, 0x6E, 0x66, 0x6F,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
            }; // "ndc info"

            using (BinaryReader br = new BinaryReader(File.Open(this.ndreg_path, FileMode.Open)))
            {
                int byte_read;

                do {
                    try {
                        byte_read = br.ReadByte();
                    }
                    catch (EndOfStreamException) {
                        break;
                    }

                    if ((byte)byte_read != search[0])
                        continue;

                    try {
                        br.BaseStream.Seek(-1, SeekOrigin.Current);
                    }
                    catch (IOException) {
                        MessageBox.Show("Failed seeking to end of ndc info", "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    try {
                        if (!Common.ByteArraysEqual(br.ReadBytes(search.Length), search))
                            continue;
                    }
                    catch (IOException ex) {
                        MessageBox.Show(ex.Message, "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    catch (ObjectDisposedException) {
                        MessageBox.Show("The stream is closed", "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    ndc_info.pos.start     = br.BaseStream.Position - search.Length;
                    ndc_info.pos.end       = br.BaseStream.Position;
                    try
                    {
                        ndc_info.len = br.ReadUInt32();
                        ndc_info.status_server = Common.Xorcize(br.ReadBytes(32), XOR_CHAR);
                        ndc_info.status_port = Common.Xorcize(br.ReadUInt32(), XOR_INT);
                        ndc_info.patch_server = Common.Xorcize(br.ReadBytes(64), XOR_CHAR);
                        ndc_info.login_server = Common.Xorcize(br.ReadBytes(32), XOR_CHAR);
                        ndc_info.login_port = Common.Xorcize(br.ReadUInt32(), XOR_INT);
                    }
                    catch (EndOfStreamException)
                    {
                        MessageBox.Show("End of the stream was reached prematurely. File could be corrupted", "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(ex.Message, "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    catch (ObjectDisposedException)
                    {
                        MessageBox.Show("The stream is closed", "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    txtStatusServer.Text = Common.ByteToText(ndc_info.status_server);
                    txtStatusPort.Text   = ndc_info.status_port.ToString();
                    txtPatchServer.Text  = Common.ByteToText(ndc_info.patch_server);
                    txtLoginServer.Text  = Common.ByteToText(ndc_info.login_server);
                    txtLoginPort.Text    = ndc_info.login_port.ToString();

                    btnSave.Enabled = true;
                    break;
                } while (byte_read != -1);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtStatusServer.Text))
            {
                MessageBox.Show("Please enter a status server", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(txtPatchServer.Text))
            {
                MessageBox.Show("Please enter a patch server", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(txtLoginServer.Text))
            {
                MessageBox.Show("Please enter a login server", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(txtStatusPort.Text))
            {
                MessageBox.Show("Please enter a status port", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(txtLoginPort.Text))
            {
                MessageBox.Show("Please enter a login port", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Common.NdcStringToFixedByteArray(txtStatusServer.Text, ref ndc_info.status_server, XOR_CHAR);
            Common.NdcStringToFixedByteArray(txtPatchServer.Text, ref ndc_info.patch_server, XOR_CHAR);
            Common.NdcStringToFixedByteArray(txtLoginServer.Text, ref ndc_info.login_server, XOR_CHAR);

            ndc_info.status_port = Common.Xorcize(Convert.ToUInt32(txtStatusPort.Text), XOR_INT);
            ndc_info.login_port = Common.Xorcize(Convert.ToUInt32(txtLoginPort.Text), XOR_INT);
            ndc_info.calculateLen();

            using (BinaryWriter bw = new BinaryWriter(File.Open(this.ndreg_path, FileMode.Open, FileAccess.Write)))
            {
                try {
                    bw.BaseStream.Seek(ndc_info.pos.end, SeekOrigin.Begin);
                }
                catch (IOException) {
                    MessageBox.Show("Failed seeking to ndc info end position: " + ndc_info.pos.end.ToString(),
                        "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try {
                    bw.Write(BitConverter.GetBytes(ndc_info.len));
                    bw.Write(ndc_info.status_server);
                    bw.Write(BitConverter.GetBytes(ndc_info.status_port));
                    bw.Write(ndc_info.patch_server);
                    bw.Write(ndc_info.login_server);
                    bw.Write(BitConverter.GetBytes(ndc_info.login_port));
                }
                catch (IOException ex) {
                    MessageBox.Show(ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (ObjectDisposedException) {
                    MessageBox.Show("The stream is closed", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (ArgumentNullException) {
                    MessageBox.Show("Buffer is null", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            MessageBox.Show("File was saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            reloadNdreg(ndreg_path);
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (!File.Exists(ndreg_path))
            {
                MessageBox.Show("File not found: " + ndreg_path,
                    "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string backup_path = ndreg_path + ".1";
            for (int i = 2; File.Exists(backup_path); i++)
                backup_path = ndreg_path + "." + i.ToString();

            try
            {
                File.Copy(ndreg_path, backup_path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
