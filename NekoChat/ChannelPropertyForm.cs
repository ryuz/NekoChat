using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NekoChat
{
    public partial class ChannelPropertyForm : Form
    {
        public ChannelPropertyForm()
        {
            InitializeComponent();
        }

        private void CahnnelSetForm_Load(object sender, EventArgs e)
        {
        }
        
        // チャンネルパス参照
        private void buttonPathRef_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            folderBrowserDialog.Description  = "channel path";
            folderBrowserDialog.RootFolder   = System.Environment.SpecialFolder.MyComputer;
            folderBrowserDialog.SelectedPath = this.TextBoxPath.Text;
            folderBrowserDialog.ShowNewFolderButton = true;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.TextBoxPath.Text = folderBrowserDialog.SelectedPath;
            }
            folderBrowserDialog.Dispose();
        }
        
        // ログ保存パス
        private void buttonLogRef_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            folderBrowserDialog.Description  = "log path";
            folderBrowserDialog.RootFolder   = System.Environment.SpecialFolder.MyComputer;
            folderBrowserDialog.SelectedPath = this.TextBoxLogPath.Text;
            folderBrowserDialog.ShowNewFolderButton = true;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.TextBoxLogPath.Text = folderBrowserDialog.SelectedPath;
            }
            folderBrowserDialog.Dispose();
        }
    }
}

