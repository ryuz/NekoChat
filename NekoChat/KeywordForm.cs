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
    public partial class KeywordForm : Form
    {
        public string KeyWords { get; set; }

        public KeywordForm()
        {
            InitializeComponent();
        }

        private void KeywordForm_Load(object sender, EventArgs e)
        {
            textBoxKeywords.Text = this.KeyWords;
        }

        private void textBoxKeywords_TextChanged(object sender, EventArgs e)
        {
            this.KeyWords = textBoxKeywords.Text;
        }
    }
}
