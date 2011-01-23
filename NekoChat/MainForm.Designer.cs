namespace NekoChat
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.richTextBoxView = new System.Windows.Forms.RichTextBox();
            this.textBoxInput = new NekoChat.InputTextBox();
            this.richTextBoxConsole = new System.Windows.Forms.RichTextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listBoxUser = new System.Windows.Forms.ListBox();
            this.listBoxChannel = new System.Windows.Forms.ListBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.channleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proparityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.keywordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logConverterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.AccessibleDescription = null;
            this.splitContainer1.AccessibleName = null;
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.BackgroundImage = null;
            this.splitContainer1.Font = null;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AccessibleDescription = null;
            this.splitContainer1.Panel1.AccessibleName = null;
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.BackgroundImage = null;
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            this.splitContainer1.Panel1.Font = null;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AccessibleDescription = null;
            this.splitContainer1.Panel2.AccessibleName = null;
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.BackgroundImage = null;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Font = null;
            // 
            // splitContainer3
            // 
            this.splitContainer3.AccessibleDescription = null;
            this.splitContainer3.AccessibleName = null;
            resources.ApplyResources(this.splitContainer3, "splitContainer3");
            this.splitContainer3.BackgroundImage = null;
            this.splitContainer3.Font = null;
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.AccessibleDescription = null;
            this.splitContainer3.Panel1.AccessibleName = null;
            resources.ApplyResources(this.splitContainer3.Panel1, "splitContainer3.Panel1");
            this.splitContainer3.Panel1.BackgroundImage = null;
            this.splitContainer3.Panel1.Controls.Add(this.richTextBoxView);
            this.splitContainer3.Panel1.Controls.Add(this.textBoxInput);
            this.splitContainer3.Panel1.Font = null;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.AccessibleDescription = null;
            this.splitContainer3.Panel2.AccessibleName = null;
            resources.ApplyResources(this.splitContainer3.Panel2, "splitContainer3.Panel2");
            this.splitContainer3.Panel2.BackgroundImage = null;
            this.splitContainer3.Panel2.Controls.Add(this.richTextBoxConsole);
            this.splitContainer3.Panel2.Font = null;
            // 
            // richTextBoxView
            // 
            this.richTextBoxView.AccessibleDescription = null;
            this.richTextBoxView.AccessibleName = null;
            resources.ApplyResources(this.richTextBoxView, "richTextBoxView");
            this.richTextBoxView.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxView.BackgroundImage = null;
            this.richTextBoxView.Name = "richTextBoxView";
            this.richTextBoxView.ReadOnly = true;
            // 
            // textBoxInput
            // 
            this.textBoxInput.AccessibleDescription = null;
            this.textBoxInput.AccessibleName = null;
            resources.ApplyResources(this.textBoxInput, "textBoxInput");
            this.textBoxInput.BackgroundImage = null;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxInput_KeyDown);
            // 
            // richTextBoxConsole
            // 
            this.richTextBoxConsole.AccessibleDescription = null;
            this.richTextBoxConsole.AccessibleName = null;
            resources.ApplyResources(this.richTextBoxConsole, "richTextBoxConsole");
            this.richTextBoxConsole.BackgroundImage = null;
            this.richTextBoxConsole.Font = null;
            this.richTextBoxConsole.Name = "richTextBoxConsole";
            // 
            // splitContainer2
            // 
            this.splitContainer2.AccessibleDescription = null;
            this.splitContainer2.AccessibleName = null;
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.BackgroundImage = null;
            this.splitContainer2.Font = null;
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AccessibleDescription = null;
            this.splitContainer2.Panel1.AccessibleName = null;
            resources.ApplyResources(this.splitContainer2.Panel1, "splitContainer2.Panel1");
            this.splitContainer2.Panel1.BackgroundImage = null;
            this.splitContainer2.Panel1.Controls.Add(this.listBoxUser);
            this.splitContainer2.Panel1.Font = null;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AccessibleDescription = null;
            this.splitContainer2.Panel2.AccessibleName = null;
            resources.ApplyResources(this.splitContainer2.Panel2, "splitContainer2.Panel2");
            this.splitContainer2.Panel2.BackgroundImage = null;
            this.splitContainer2.Panel2.Controls.Add(this.listBoxChannel);
            this.splitContainer2.Panel2.Font = null;
            // 
            // listBoxUser
            // 
            this.listBoxUser.AccessibleDescription = null;
            this.listBoxUser.AccessibleName = null;
            resources.ApplyResources(this.listBoxUser, "listBoxUser");
            this.listBoxUser.BackgroundImage = null;
            this.listBoxUser.FormattingEnabled = true;
            this.listBoxUser.Name = "listBoxUser";
            // 
            // listBoxChannel
            // 
            this.listBoxChannel.AccessibleDescription = null;
            this.listBoxChannel.AccessibleName = null;
            resources.ApplyResources(this.listBoxChannel, "listBoxChannel");
            this.listBoxChannel.BackgroundImage = null;
            this.listBoxChannel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxChannel.Font = null;
            this.listBoxChannel.FormattingEnabled = true;
            this.listBoxChannel.Name = "listBoxChannel";
            this.listBoxChannel.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxChannel_DrawItem);
            this.listBoxChannel.SelectedIndexChanged += new System.EventHandler(this.listBoxChannel_SelectedIndexChanged);
            // 
            // menuStrip
            // 
            this.menuStrip.AccessibleDescription = null;
            this.menuStrip.AccessibleName = null;
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.BackgroundImage = null;
            this.menuStrip.Font = null;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.channleToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Name = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.AccessibleDescription = null;
            this.fileToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            this.fileToolStripMenuItem.BackgroundImage = null;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeyDisplayString = null;
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.AccessibleDescription = null;
            this.exitToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.BackgroundImage = null;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // channleToolStripMenuItem
            // 
            this.channleToolStripMenuItem.AccessibleDescription = null;
            this.channleToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.channleToolStripMenuItem, "channleToolStripMenuItem");
            this.channleToolStripMenuItem.BackgroundImage = null;
            this.channleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.proparityToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.channleToolStripMenuItem.Name = "channleToolStripMenuItem";
            this.channleToolStripMenuItem.ShortcutKeyDisplayString = null;
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.AccessibleDescription = null;
            this.addToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.addToolStripMenuItem, "addToolStripMenuItem");
            this.addToolStripMenuItem.BackgroundImage = null;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.addToolStripMenuItem.Click += new System.EventHandler(this.channleToolStripMenuItem_Click);
            // 
            // proparityToolStripMenuItem
            // 
            this.proparityToolStripMenuItem.AccessibleDescription = null;
            this.proparityToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.proparityToolStripMenuItem, "proparityToolStripMenuItem");
            this.proparityToolStripMenuItem.BackgroundImage = null;
            this.proparityToolStripMenuItem.Name = "proparityToolStripMenuItem";
            this.proparityToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.proparityToolStripMenuItem.Click += new System.EventHandler(this.proparityToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.AccessibleDescription = null;
            this.deleteToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.deleteToolStripMenuItem, "deleteToolStripMenuItem");
            this.deleteToolStripMenuItem.BackgroundImage = null;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.AccessibleDescription = null;
            this.toolStripMenuItem1.AccessibleName = null;
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.BackgroundImage = null;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keywordsToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeyDisplayString = null;
            // 
            // keywordsToolStripMenuItem
            // 
            this.keywordsToolStripMenuItem.AccessibleDescription = null;
            this.keywordsToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.keywordsToolStripMenuItem, "keywordsToolStripMenuItem");
            this.keywordsToolStripMenuItem.BackgroundImage = null;
            this.keywordsToolStripMenuItem.Name = "keywordsToolStripMenuItem";
            this.keywordsToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.keywordsToolStripMenuItem.Click += new System.EventHandler(this.keywordsToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.AccessibleDescription = null;
            this.optionsToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            this.optionsToolStripMenuItem.BackgroundImage = null;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.AccessibleDescription = null;
            this.toolsToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            this.toolsToolStripMenuItem.BackgroundImage = null;
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logConverterToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.ShortcutKeyDisplayString = null;
            // 
            // logConverterToolStripMenuItem
            // 
            this.logConverterToolStripMenuItem.AccessibleDescription = null;
            this.logConverterToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.logConverterToolStripMenuItem, "logConverterToolStripMenuItem");
            this.logConverterToolStripMenuItem.BackgroundImage = null;
            this.logConverterToolStripMenuItem.Name = "logConverterToolStripMenuItem";
            this.logConverterToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.logConverterToolStripMenuItem.Click += new System.EventHandler(this.logConverterToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.AccessibleDescription = null;
            this.aboutToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.BackgroundImage = null;
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeyDisplayString = null;
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.AccessibleDescription = null;
            this.aboutToolStripMenuItem1.AccessibleName = null;
            resources.ApplyResources(this.aboutToolStripMenuItem1, "aboutToolStripMenuItem1");
            this.aboutToolStripMenuItem1.BackgroundImage = null;
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.ShortcutKeyDisplayString = null;
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AccessibleDescription = null;
            this.statusStrip1.AccessibleName = null;
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.BackgroundImage = null;
            this.statusStrip1.Font = null;
            this.statusStrip1.Name = "statusStrip1";
            // 
            // timer
            // 
            this.timer.Interval = 200;
            this.timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon
            // 
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // MainForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip);
            this.Font = null;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ClientSizeChanged += new System.EventHandler(this.MainForm_ClientSizeChanged);
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox listBoxUser;
        private System.Windows.Forms.ListBox listBoxChannel;
        private System.Windows.Forms.ToolStripMenuItem channleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem proparityToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBoxView;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem keywordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private InputTextBox textBoxInput;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logConverterToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.RichTextBox richTextBoxConsole;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    }
}

