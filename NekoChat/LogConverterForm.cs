using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace NekoChat
{
    public partial class LogConverterForm : Form
    {
        public LogConverterForm()
        {
            InitializeComponent();
        }

        // 入力パス参照
        private void buttonInputRef_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            folderBrowserDialog.Description = "input path";
            folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            folderBrowserDialog.SelectedPath = this.TextBoxInputPath.Text;
            folderBrowserDialog.ShowNewFolderButton = true;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.TextBoxInputPath.Text = folderBrowserDialog.SelectedPath;
            }
            folderBrowserDialog.Dispose();
        }

        // 出力パス参照
        private void buttonOutputRef_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            folderBrowserDialog.Description = "output path";
            folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            folderBrowserDialog.SelectedPath = this.TextBoxOutputPath.Text;
            folderBrowserDialog.ShowNewFolderButton = true;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.TextBoxOutputPath.Text = folderBrowserDialog.SelectedPath;
            }
            folderBrowserDialog.Dispose();
        }

        // ログ変換
        private void logConvert(string inputName, string outputName, string key)
        {
            ChatFile cf = new ChatFile(inputName, key);
            cf.Read();
            if (!cf.Authenticated || cf.Text.Length <= 0)
            {
                return;
            }

            if ( Directory.Exists(outputName) )
            {
                return;
            }

            try
            {
                using (FileStream fs = new FileStream(outputName, FileMode.Create, FileAccess.Write, FileShare.Read))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(cf.Text);
                }
            }
            catch (IOException)
            {
            }
        }
        
        private void buttonConvert_Click(object sender, EventArgs e)
        {
            /* 変換 */
            DirectoryInfo di = new DirectoryInfo(this.TextBoxInputPath.Text);
            FileInfo[] fi = di.GetFiles("*.txt");
            for (int i = 0; i < fi.Length; i++)
            {
                string inputName = fi[i].FullName;
                string outputName = Path.Combine(TextBoxOutputPath.Text, fi[i].Name);
                logConvert(inputName, outputName, TextBoxKey.Text);
            }

            /* 変換完了 */
            MessageBox.Show("Compleated", "log convert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);            
        }
    }
}
