using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NekoChat
{
    class InputTextBox : TextBox
    {
        private MainForm owner;
        public InputTextBox() : base()
        {
        }

        public void SetOwnerForm(MainForm owner)
        {
            this.owner = owner;
        }

        const int WM_PASTE = 0x302;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_PASTE)
            {
                IDataObject iData = Clipboard.GetDataObject();
                //クリップボードに文字列データがあるか確認
                if (iData.GetDataPresent(DataFormats.Text))
                {
                    //文字列データがあるときはこれを取得する
                    string textCb = ((string)iData.GetData(DataFormats.Text));
                    string text = textCb.Replace("\r\n", "\n").TrimEnd('\n');
                    string[] textArray = text.Split('\n');
                    if (textArray.Length >= 2)
                    {
                        owner.PasteText(textCb);
                        return;
                    }
                }
            }

            base.WndProc(ref m);
        }
        

        const Keys pasteKeys = Keys.V | Keys.Control;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // UP/DOWNの本来の効果を殺してオーナーでフック
            if (keyData == Keys.Up || keyData == Keys.Down)
            {
                owner.InputUpDownKey(keyData);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
