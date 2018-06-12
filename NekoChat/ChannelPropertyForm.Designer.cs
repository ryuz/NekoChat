namespace NekoChat
{
    partial class ChannelPropertyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChannelPropertyForm));
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.TextBoxPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxKey = new System.Windows.Forms.TextBox();
            this.buttonPathRef = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.TextBoxChannelName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBoxLogPath = new System.Windows.Forms.TextBox();
            this.buttonLogRef = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // TextBoxPath
            // 
            resources.ApplyResources(this.TextBoxPath, "TextBoxPath");
            this.TextBoxPath.Name = "TextBoxPath";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // TextBoxName
            // 
            resources.ApplyResources(this.TextBoxName, "TextBoxName");
            this.TextBoxName.Name = "TextBoxName";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // TextBoxKey
            // 
            resources.ApplyResources(this.TextBoxKey, "TextBoxKey");
            this.TextBoxKey.Name = "TextBoxKey";
            // 
            // buttonPathRef
            // 
            resources.ApplyResources(this.buttonPathRef, "buttonPathRef");
            this.buttonPathRef.Name = "buttonPathRef";
            this.buttonPathRef.UseVisualStyleBackColor = true;
            this.buttonPathRef.Click += new System.EventHandler(this.buttonPathRef_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // TextBoxChannelName
            // 
            resources.ApplyResources(this.TextBoxChannelName, "TextBoxChannelName");
            this.TextBoxChannelName.Name = "TextBoxChannelName";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // TextBoxLogPath
            // 
            resources.ApplyResources(this.TextBoxLogPath, "TextBoxLogPath");
            this.TextBoxLogPath.Name = "TextBoxLogPath";
            // 
            // buttonLogRef
            // 
            resources.ApplyResources(this.buttonLogRef, "buttonLogRef");
            this.buttonLogRef.Name = "buttonLogRef";
            this.buttonLogRef.UseVisualStyleBackColor = true;
            this.buttonLogRef.Click += new System.EventHandler(this.buttonLogRef_Click);
            // 
            // ChannelPropertyForm
            // 
            this.AcceptButton = this.buttonOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.buttonLogRef);
            this.Controls.Add(this.TextBoxLogPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TextBoxChannelName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonPathRef);
            this.Controls.Add(this.TextBoxKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextBoxName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxPath);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChannelPropertyForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.CahnnelSetForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonPathRef;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox TextBoxPath;
        public System.Windows.Forms.TextBox TextBoxChannelName;
        public System.Windows.Forms.TextBox TextBoxName;
        public System.Windows.Forms.TextBox TextBoxKey;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox TextBoxLogPath;
        private System.Windows.Forms.Button buttonLogRef;
    }
}