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
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void buttonNeko_Click(object sender, EventArgs e)
        {
            PasswordForm dlg = new PasswordForm();

            dlg.TextBoxPassword.Text = "";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Program.Password = dlg.TextBoxPassword.Text;
            }
            dlg.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

