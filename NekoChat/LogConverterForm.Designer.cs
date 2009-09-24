namespace NekoChat
{
    partial class LogConverterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogConverterForm));
            this.TextBoxInputPath = new System.Windows.Forms.TextBox();
            this.TextBoxOutputPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonInputRef = new System.Windows.Forms.Button();
            this.buttonOutputRef = new System.Windows.Forms.Button();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBoxInputPath
            // 
            this.TextBoxInputPath.AccessibleDescription = null;
            this.TextBoxInputPath.AccessibleName = null;
            resources.ApplyResources(this.TextBoxInputPath, "TextBoxInputPath");
            this.TextBoxInputPath.BackgroundImage = null;
            this.TextBoxInputPath.Font = null;
            this.TextBoxInputPath.Name = "TextBoxInputPath";
            // 
            // TextBoxOutputPath
            // 
            this.TextBoxOutputPath.AccessibleDescription = null;
            this.TextBoxOutputPath.AccessibleName = null;
            resources.ApplyResources(this.TextBoxOutputPath, "TextBoxOutputPath");
            this.TextBoxOutputPath.BackgroundImage = null;
            this.TextBoxOutputPath.Font = null;
            this.TextBoxOutputPath.Name = "TextBoxOutputPath";
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Font = null;
            this.label2.Name = "label2";
            // 
            // TextBoxKey
            // 
            this.TextBoxKey.AccessibleDescription = null;
            this.TextBoxKey.AccessibleName = null;
            resources.ApplyResources(this.TextBoxKey, "TextBoxKey");
            this.TextBoxKey.BackgroundImage = null;
            this.TextBoxKey.Font = null;
            this.TextBoxKey.Name = "TextBoxKey";
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Font = null;
            this.label3.Name = "label3";
            // 
            // buttonInputRef
            // 
            this.buttonInputRef.AccessibleDescription = null;
            this.buttonInputRef.AccessibleName = null;
            resources.ApplyResources(this.buttonInputRef, "buttonInputRef");
            this.buttonInputRef.BackgroundImage = null;
            this.buttonInputRef.Font = null;
            this.buttonInputRef.Name = "buttonInputRef";
            this.buttonInputRef.UseVisualStyleBackColor = true;
            this.buttonInputRef.Click += new System.EventHandler(this.buttonInputRef_Click);
            // 
            // buttonOutputRef
            // 
            this.buttonOutputRef.AccessibleDescription = null;
            this.buttonOutputRef.AccessibleName = null;
            resources.ApplyResources(this.buttonOutputRef, "buttonOutputRef");
            this.buttonOutputRef.BackgroundImage = null;
            this.buttonOutputRef.Font = null;
            this.buttonOutputRef.Name = "buttonOutputRef";
            this.buttonOutputRef.UseVisualStyleBackColor = true;
            this.buttonOutputRef.Click += new System.EventHandler(this.buttonOutputRef_Click);
            // 
            // buttonConvert
            // 
            this.buttonConvert.AccessibleDescription = null;
            this.buttonConvert.AccessibleName = null;
            resources.ApplyResources(this.buttonConvert, "buttonConvert");
            this.buttonConvert.BackgroundImage = null;
            this.buttonConvert.Font = null;
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.AccessibleDescription = null;
            this.buttonClose.AccessibleName = null;
            resources.ApplyResources(this.buttonClose, "buttonClose");
            this.buttonClose.BackgroundImage = null;
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Font = null;
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // LogConverterForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.buttonClose;
            this.ControlBox = false;
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.buttonOutputRef);
            this.Controls.Add(this.buttonInputRef);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextBoxKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxOutputPath);
            this.Controls.Add(this.TextBoxInputPath);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogConverterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonInputRef;
        private System.Windows.Forms.Button buttonOutputRef;
        public System.Windows.Forms.TextBox TextBoxInputPath;
        public System.Windows.Forms.TextBox TextBoxOutputPath;
        public System.Windows.Forms.TextBox TextBoxKey;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.Button buttonClose;
    }
}