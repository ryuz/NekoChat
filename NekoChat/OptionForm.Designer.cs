namespace NekoChat
{
    partial class OptionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionForm));
            this.CheckBoxKeywordWindowPopup = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.CheckBoxAnywordWindowPopup = new System.Windows.Forms.CheckBox();
            this.CheckBoxKeywordTaskbarBlink = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckBoxKeywordWindowPopup
            // 
            resources.ApplyResources(this.CheckBoxKeywordWindowPopup, "CheckBoxKeywordWindowPopup");
            this.CheckBoxKeywordWindowPopup.Name = "CheckBoxKeywordWindowPopup";
            this.CheckBoxKeywordWindowPopup.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.CheckBoxAnywordWindowPopup);
            this.tabPage1.Controls.Add(this.CheckBoxKeywordTaskbarBlink);
            this.tabPage1.Controls.Add(this.CheckBoxKeywordWindowPopup);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // CheckBoxAnywordWindowPopup
            // 
            resources.ApplyResources(this.CheckBoxAnywordWindowPopup, "CheckBoxAnywordWindowPopup");
            this.CheckBoxAnywordWindowPopup.Name = "CheckBoxAnywordWindowPopup";
            this.CheckBoxAnywordWindowPopup.UseVisualStyleBackColor = true;
            // 
            // CheckBoxKeywordTaskbarBlink
            // 
            resources.ApplyResources(this.CheckBoxKeywordTaskbarBlink, "CheckBoxKeywordTaskbarBlink");
            this.CheckBoxKeywordTaskbarBlink.Name = "CheckBoxKeywordTaskbarBlink";
            this.CheckBoxKeywordTaskbarBlink.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // buttonOk
            // 
            resources.ApplyResources(this.buttonOk, "buttonOk");
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // OptionForm
            // 
            this.AcceptButton = this.buttonOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        public System.Windows.Forms.CheckBox CheckBoxKeywordWindowPopup;
        public System.Windows.Forms.CheckBox CheckBoxKeywordTaskbarBlink;
        public System.Windows.Forms.CheckBox CheckBoxAnywordWindowPopup;
    }
}