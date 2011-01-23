using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;


namespace NekoChat
{
    public partial class MainForm : Form
    {
        private ArrayList   channelArray;
        private int         channelIndex;
        private string      keywords = "";
        private int         histryIndex = -1;
        private string      histryOrign = "";
        private bool        keywordWindowPopup = false;
        private bool        keywordTaskbarBlink = true;
        private const string defaultChannelKey = "neko";
        private const string registryKey = "neko800";

        [DllImport("user32.dll")]
        static extern Int32 FlashWindowEx(ref FLASHWINFO pwfi);

        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public UInt32 cbSize;    // FLASHWINFO構造体のサイズ
            public IntPtr hwnd;      // 点滅対象のウィンドウ・ハンドル
            public UInt32 dwFlags;   // 以下の「FLASHW_XXX」のいずれか
            public UInt32 uCount;    // 点滅する回数
            public UInt32 dwTimeout; // 点滅する間隔（ミリ秒単位）
        }

        // 点滅を止める
        public const UInt32 FLASHW_STOP = 0;
        // タイトルバーを点滅させる
        public const UInt32 FLASHW_CAPTION = 1;
        // タスクバー・ボタンを点滅させる
        public const UInt32 FLASHW_TRAY = 2;
        // タスクバー・ボタンとタイトルバーを点滅させる
        public const UInt32 FLASHW_ALL = 3;
        // FLASHW_STOPが指定されるまでずっと点滅させる
        public const UInt32 FLASHW_TIMER = 4;
        // ウィンドウが最前面に来るまでずっと点滅させる
        public const UInt32 FLASHW_TIMERNOFG = 12;


        // コンストラクタ
        public MainForm()
        {
            InitializeComponent();
            channelArray = new ArrayList();
            channelIndex = -1;

            ((InputTextBox)textBoxInput).SetOwnerForm(this);
        }

        // 開始
        private void MainForm_Load(object sender, EventArgs e)
        {
            richTextBoxView.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
            loadConfiguration();
            updateChannelList();
            updateView();

            timer.Enabled = true;
        }
        
        // 閉じる
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.notifyIcon.Visible = false;
            saveConfiguration();
            for (int i = 0; i < channelArray.Count; i++)
            {
                ChatChannel cc = (ChatChannel)channelArray[i];
                cc.Dispose();
            }
        }

        // 終了(メニュー)
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 最小化
        private void MainForm_ClientSizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                // 最小化
                this.Visible = false;
                this.ShowInTaskbar = false;
            }
        }

        // アクティブになった
        private void MainForm_Activated(object sender, EventArgs e)
        {
            // アイコン復帰
            this.notifyIcon.Icon = Properties.Resources.icon_small;
        }

        // タスクトレイクリック
        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                windowRestore();
            }
        }

        private void windowRestore()
        {
            // 復元
            this.Visible = true;
            this.ShowInTaskbar = true;
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            this.Activate();

            // アイコン復帰
            this.notifyIcon.Icon = Properties.Resources.icon_small;

            // 末尾に移動
            viewTextScrollToEnd();
            consoleTextScrollToEnd();
        }
        
        // 設定保存
        private void saveConfiguration()
        {
            for (int i = 0; i < this.channelArray.Count; i++)
            {
                ChatChannel cc = (ChatChannel)this.channelArray[i];

                String keyPath = @"Software\Ryuz\NekoChat\channels\" + i.ToString();
                Microsoft.Win32.RegistryKey regkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(keyPath);

                regkey.SetValue("path", cc.ChannelPath);
                regkey.SetValue("nicknemae", cc.NickName);
                regkey.SetValue("channelname", cc.ChannelName);
                regkey.SetValue("key", CryptString.EncryptString(cc.Key, registryKey));
                regkey.SetValue("log", cc.LogPath);

                //閉じる
                regkey.Close();
            }

            Microsoft.Win32.RegistryKey regkey2 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Ryuz\NekoChat\channels\");
            regkey2.SetValue("num", this.channelArray.Count);
            regkey2.SetValue("current", this.channelIndex);
            regkey2.Close();

            Microsoft.Win32.RegistryKey regkey3 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Ryuz\NekoChat\options\");
            regkey3.SetValue("keywords", this.keywords);
            regkey3.SetValue("keyword-window-popup", this.keywordWindowPopup ? 1 : 0);
            regkey3.SetValue("keyword-taskbar-blink", this.keywordTaskbarBlink ? 1 : 0);
            regkey3.SetValue("password", CryptString.EncryptString(Program.Password, registryKey));
            regkey3.Close();
        }

        // 設定読出
        private void loadConfiguration()
        {
            Microsoft.Win32.RegistryKey regkey3 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Ryuz\NekoChat\options\");
            this.keywords = (string)regkey3.GetValue("keywords", "");
            this.keywordWindowPopup  = ((int)regkey3.GetValue("keyword-window-popup", 0) != 0);
            this.keywordTaskbarBlink = ((int)regkey3.GetValue("keyword-taskbar-blink", 0) != 0);

            Program.Password = CryptString.DecryptString((string)regkey3.GetValue("password", ""), registryKey);
            regkey3.Close();

            Microsoft.Win32.RegistryKey regkey2 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Ryuz\NekoChat\channels\");
            int num = (int)regkey2.GetValue("num", 0);
            this.channelIndex = (int)regkey2.GetValue("current", -1);
            regkey2.Close();

            if (this.channelIndex < 0) this.channelIndex = 0;
            if (this.channelIndex >= num) this.channelIndex = num - 1;

            this.channelArray.Clear();
            for (int i = 0; i < num; i++)
            {
                ChatChannel cc;

                String keyPath = @"Software\Ryuz\NekoChat\channels\" + i.ToString();
                Microsoft.Win32.RegistryKey regkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(keyPath);

                string path = (string)regkey.GetValue("path", "");
                string nickName = (string)regkey.GetValue("nicknemae", "");
                string channelName = (string)regkey.GetValue("channelname", "");
                string ckey = (string)regkey.GetValue("key", "");
                string log = (string)regkey.GetValue("log", "");
                String key = CryptString.DecryptString(ckey, registryKey);
                cc = new ChatChannel(channelName, nickName, path, key, log);
                this.channelArray.Add(cc);

                //閉じる
                regkey.Close();
            }

            string pass = CryptString.MakeMd5String(Program.Password + "piyo");
            if (pass != "b0e65fc9c127eefe6a57a9ef858cd9bc")
            {
                toolsToolStripMenuItem.Enabled = false;
                toolsToolStripMenuItem.Visible = false;
                return;
            }
        }
        
        // 文字入力
        const Keys pasteKeys = Keys.V | Keys.Control;
        private void textBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if ( channelIndex < 0 || channelIndex >= channelArray.Count )
            {
                return;
            }
            ChatChannel cc = (ChatChannel)channelArray[channelIndex];
                        
            if (e.KeyCode == Keys.Enter && textBoxInput.Text != "" )    // Enter
            {
                // 文字列取り出し
                string text = textBoxInput.Text;
                textBoxInput.Text = "";
                
                // メッセージを作る
                string message = DateTime.Now.ToString("HH:mm:ss ") + String.Format("{0,-8} ", cc.NickName) + text;
               
                // 書き込み
                cc.WriteMessage(message);
                
                // 表示に追加
                richTextBoxView.Text += message + "\n";
                viewTextScrollToEnd();

                // ヒストリに追加
                cc.AddHistry(text);
                histryIndex = -1;
                histryOrign = "";
            }
        }

        // 末尾に移動
        private void viewTextScrollToEnd()
        {
            richTextBoxView.SelectionStart = richTextBoxView.TextLength;
            richTextBoxView.SelectionLength = 0;
            richTextBoxView.ScrollToCaret();
        }

        // 末尾に移動
        private void consoleTextScrollToEnd()
        {
            // 末尾に移動
            richTextBoxConsole.SelectionStart = richTextBoxConsole.TextLength;
            richTextBoxConsole.SelectionLength = 0;
            richTextBoxConsole.ScrollToCaret();
        }
        
        // up/down キー
        public void InputUpDownKey(Keys keyData)
        {
            if (channelIndex < 0 || channelIndex >= channelArray.Count)
            {
                return;
            }

            ChatChannel cc = (ChatChannel)channelArray[channelIndex];

            if (keyData == Keys.Up)    // Up
            {
                if (histryIndex + 1 >= cc.GetHistryCount())
                {
                    return;
                }
                if (histryIndex == -1)
                {
                    histryOrign = textBoxInput.Text;
                }
                histryIndex++;
                textBoxInput.Text = cc.GetHistry(histryIndex);
                textBoxInput.Focus();
                textBoxInput.SelectionStart = textBoxInput.TextLength;
                textBoxInput.Select(textBoxInput.Text.Length + 1, 0);
            }
            else if (keyData == Keys.Down)    // Down
            {
                if (histryIndex < 0 )
                {
                    return;
                }
                histryIndex--;
                if (histryIndex == -1)
                {
                    textBoxInput.Text = histryOrign;
                }
                else
                {
                    textBoxInput.Text = cc.GetHistry(histryIndex);
                }
                textBoxInput.Focus();
                textBoxInput.SelectionStart = textBoxInput.TextLength;
                textBoxInput.Select(textBoxInput.Text.Length + 1, 0);
            }
        }

        // 複数行の貼り付け
        public void PasteText(string text)
        {
            if (channelIndex < 0 || channelIndex >= channelArray.Count)
            {
                return;
            }
            ChatChannel cc = (ChatChannel)channelArray[channelIndex];

            PasteForm dlg = new PasteForm();
            string [] textArray = text.Replace("\r\n", "\n").TrimEnd('\n').Split('\n');
            dlg.textBox.Text = "";
            for (int i = 0; i < textArray.Length; i++)
            {
                dlg.textBox.AppendText("> " + textArray[i] + "\r\n");
            }
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            text = dlg.textBox.Text;
            textArray = text.Replace("\r\n", "\n").TrimEnd('\n').Split('\n');
            for (int i = 0; i < textArray.Length; i++)
            {
                string message = DateTime.Now.ToString("HH:mm:ss ") + String.Format("{0,-8} ", cc.NickName) + textArray[i];
                cc.WriteMessage(message);
                richTextBoxView.Text += message + "\n";
                viewTextScrollToEnd();
            }
        }
        
        // 表示の更新
        private int viewIndex = -1;
        private void updateView()
        {
            ChatChannel cc;
            bool newHit = false;
            bool keyHit = false;
            bool update = false;

            // 更新チェック
            for (int index = 0; index < channelArray.Count; index++)
            {
                cc = (ChatChannel)channelArray[index];

                // 新メッセージ読み出し
                string strNew = cc.ReadMessage();
                if (strNew.Length > 0)
                {
                    newHit = true;
                    cc.UnviewedMessage = true;
                }
                string[] taNew = strNew.Split('\n');

                // 表示更新
                if (index == channelIndex)
                {
                    // Viewに表示
                    if (viewIndex != channelIndex || 
                        (strNew.Length > 0 || (richTextBoxView.Text.Length == 0 && cc.Text.Length > 0)))
                    {
                        richTextBoxView.Text = cc.Text;
                        viewTextScrollToEnd();
                    }
                }
                else
                {
                    // コンソールに出力
                    for (int i = 0; i < taNew.Count(); i++)
                    {
                        if (taNew[i].Length > 0)
                        {
                            richTextBoxConsole.Text += "<" + cc.ChannelName + "> " + taNew[i] + "\n";
                            consoleTextScrollToEnd();
                        }
                    }
                }

                // キーワードチェック
                string[] taKey = this.keywords.Split('\n');
                for (int i = 0; i < taKey.Length; i++)
                {
                    if (taKey[i].Length > 0)
                    {
                        for (int j = 0; j < taNew.Length; j++)
                        {
                            if (taNew[j].Length > 8+1+8)
                            {
                                if (taNew[j].LastIndexOf(taKey[i].TrimEnd('\r', '\n')) >= 18 )
                                {
                                    keyHit = true;
                                    cc.UnviewedKeyword = true;
                                }
                            }
                        }
                    }
                }
            }

            // キーワードチェック
            if (keyHit)
            {
                // ウィンドウポップアップ
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.notifyIcon.Icon = Properties.Resources.icon_small_yellow;
                    if (this.keywordWindowPopup)
                    {
                        windowRestore();
                    }
                }
                else
                {
                    if (this.keywordWindowPopup)
                    {
                        this.Focus();
                        this.Activate();
                    }
                }

                // タスクバー点滅
                if (this.keywordTaskbarBlink)
                {
                    FLASHWINFO fInfo = new FLASHWINFO();
                    fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
                    fInfo.hwnd = this.Handle;
                    fInfo.dwFlags = FLASHW_ALL;
                    fInfo.uCount = 5;         // 点滅する回数
                    fInfo.dwTimeout = 0;

                    FlashWindowEx(ref fInfo);
                }
            }
            else if (newHit && this.WindowState == FormWindowState.Minimized)
            {
                this.notifyIcon.Icon = Properties.Resources.icon_small_blue;
            }

            if (channelIndex >= 0 )
            {
                cc = (ChatChannel)channelArray[channelIndex];
                if ( viewIndex != channelIndex || cc.UnviewedMessage )
                {
//                    richTextBoxView.Text = cc.Text;
                    viewIndex = channelIndex;
                    update = true;

                    // 未読フラグクリア
                    cc.UnviewedMessage = false;
                    cc.UnviewedKeyword = false;

                    // 末尾に移動
                    richTextBoxView.SelectionStart = richTextBoxView.TextLength;
                    richTextBoxView.SelectionLength = 0;
                    richTextBoxView.ScrollToCaret();

                    // ユーザーリストの更新
                    listBoxUser.Items.Clear();
                    ArrayList ul = cc.UserList;
                    for (int i = 0; i < ul.Count; i++)
                    {
                        listBoxUser.Items.Add(ul[i]);
                    }
                }
            }

            if (newHit | update)
            {
                this.listBoxChannel.Invalidate();
            }
        }


        // チャンネル変更
        private void changeChannel(int newIndex, bool forced)
        {
            if (newIndex < 0) newIndex = 0;
            if (newIndex >= channelArray.Count) newIndex = channelArray.Count - 1;

            if (newIndex != this.channelIndex || forced)
            {
                this.channelIndex = newIndex;
                histryIndex = -1;
                histryOrign = "";
                updateView();
            }
        }

        // チャンネルリストの表示更新
        private void updateChannelList()
        {
            this.listBoxChannel.Items.Clear();
            for (int i = 0; i < channelArray.Count; i++)
            {
                ChatChannel cc = (ChatChannel)channelArray[i];
                String channelName = cc.ChannelName + "(" + cc.ChannelPath + ")";
                this.listBoxChannel.Items.Add(channelName);
            }
            if (channelArray.Count > 0)
            {
                this.listBoxChannel.SetSelected(channelIndex, true);
            }
        }

        // チャンネルリストのオーナー描画
        private void listBoxChannel_DrawItem(object sender, DrawItemEventArgs e)
        {
            // 描画するインデックスをチェック
            if (e.Index < 0 || e.Index >= channelArray.Count)
            {
                return;
            }
            
            // 描画する範囲を取得
      //      Rectangle rc = e.Bounds;

            // 対応するチャンネル取得
            ChatChannel cc = (ChatChannel)channelArray[e.Index];
            
            // 描画するインデックスに対応した色を取得
            Color bclr;
            Color fclr;


            if ( this.channelIndex == e.Index )
            {
                // 選択チャネル
                fclr = Color.White;
                bclr = Color.DarkBlue;
            }
            else if (cc.UnviewedKeyword)
            {
                // キーワード未読
                fclr = Color.Black; // e.ForeColor;
                bclr = Color.Yellow;
            }
            else if (cc.UnviewedMessage)
            {
                // メッセージ未読
                fclr = Color.Black; // e.ForeColor;
                bclr = Color.LightBlue;
            }
            else
            {
                // 非選択
                fclr = Color.Black;         // e.ForeColor;
                bclr = Color.Transparent;   // e.BackColor;
            }

            // バックを塗りつぶし
            Brush bbr = new SolidBrush(bclr);
            e.Graphics.FillRectangle(bbr, e.Bounds);
            bbr.Dispose();
            
            // 文字列描画
            Brush fbr = new SolidBrush(fclr);
            e.Graphics.DrawString(cc.ChannelName + " (" + cc.ChannelPath + ")", Font, fbr, e.Bounds);
            fbr.Dispose();
            
            // 選択枠を描画する
            e.DrawFocusRectangle();
        }

        // チャンネルボックス選択
        private void listBoxChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeChannel(this.listBoxChannel.SelectedIndex, false);
        }
        

        // チャンネル追加
        private void chanelAdd()
        {
            ChannelPropertyForm dlg = new ChannelPropertyForm();
            dlg.TextBoxKey.Text = defaultChannelKey;
            dlg.TextBoxPath.Text        = "";
            dlg.TextBoxChannelName.Text = "";
            dlg.TextBoxName.Text        = Environment.UserName;
            dlg.TextBoxLogPath.Text = "";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ChatChannel cc = new ChatChannel(dlg.TextBoxChannelName.Text, dlg.TextBoxName.Text, dlg.TextBoxPath.Text, dlg.TextBoxKey.Text, dlg.TextBoxLogPath.Text);
                this.channelIndex = channelArray.Add(cc);

                saveConfiguration();
                updateChannelList();
                updateView();
            }
            dlg.Dispose();
        }

        // チャンネルのプロパティ
        private void channelProparity()
        {
            if (channelIndex < 0 || channelIndex >= channelArray.Count)
            {
                return;
            }

            ChatChannel cc = (ChatChannel)channelArray[channelIndex];

            ChannelPropertyForm dlg = new ChannelPropertyForm();
            dlg.TextBoxKey.Text         = cc.Key;
            dlg.TextBoxPath.Text        = cc.ChannelPath;
            dlg.TextBoxChannelName.Text = cc.ChannelName;
            dlg.TextBoxName.Text        = cc.NickName;
            dlg.TextBoxLogPath.Text = cc.LogPath;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                cc.Dispose();
                cc = new ChatChannel(dlg.TextBoxChannelName.Text, dlg.TextBoxName.Text, dlg.TextBoxPath.Text, dlg.TextBoxKey.Text, dlg.TextBoxLogPath.Text);
                channelArray[this.channelIndex] = cc;

                saveConfiguration();
                updateChannelList();
                updateView();
            }
            dlg.Dispose();
        }

        // チャンネル削除
        private void channelDelete()
        {
            if (channelIndex < 0 || channelIndex >= channelArray.Count)
            {
                return;
            }
            if (MessageBox.Show("Really ?", "delete channel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            ChatChannel cc = (ChatChannel)channelArray[channelIndex];

            cc.Dispose();
            channelArray.RemoveAt(channelIndex);
            changeChannel(channelIndex, true);
            updateChannelList();
            saveConfiguration();
        }


        // チャンネル追加(メニュー)
        private void channleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chanelAdd();
        }

        // チャンネルプロパティー(メニュー)
        private void proparityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            channelProparity();
        }

        // チャンネル削除(メニュー)
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            channelDelete();
        }


        // キーワード設定
        private void keywordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KeywordForm dlg = new KeywordForm();
            dlg.KeyWords = this.keywords;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.keywords = dlg.KeyWords;
            }
        }

        // タイマ更新
        private void timer1_Tick(object sender, EventArgs e)
        {
            updateView();
        }


        // リロード
        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateView();
        }


        // ログ変換
        private void logConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pass = CryptString.MakeMd5String(Program.Password + "hoge");
            if (pass != "1e8738d8ca8cecfb194180a427f5ae85" )
            {
                return;
            }

            LogConverterForm dlg = new LogConverterForm();
            if (channelIndex >= 0 && channelIndex < channelArray.Count)
            {
                ChatChannel cc = (ChatChannel)channelArray[channelIndex];
                dlg.TextBoxInputPath.Text = cc.ChannelPath;
                dlg.TextBoxOutputPath.Text = cc.LogPath;
                dlg.TextBoxKey.Text = cc.Key;
            }
            else
            {
                dlg.TextBoxInputPath.Text = "";
                dlg.TextBoxOutputPath.Text = "";
                dlg.TextBoxKey.Text = defaultChannelKey;
            }
            dlg.ShowDialog();
        }

        // Options
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionForm of = new OptionForm();

            of.CheckBoxWindowPopup.Checked = this.keywordWindowPopup;
            of.CheckBoxTaskbarBlink.Checked = this.keywordTaskbarBlink;
            if (of.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            this.keywordWindowPopup = of.CheckBoxWindowPopup.Checked;
            this.keywordTaskbarBlink = of.CheckBoxTaskbarBlink.Checked;
            saveConfiguration();
        }
        
        // About
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutForm dlg = new AboutForm();
            dlg.ShowDialog();
        }



    }
}
