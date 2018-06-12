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
            resources.ApplyResources(this.TextBoxInputPath, "TextBoxInputPath");
            this.TextBoxInputPath.Name = "TextBoxInputPath";
            // 
            // TextBoxOutputPath
            // 
            resources.ApplyResources(this.TextBoxOutputPath, "TextBoxOutputPath");
            this.TextBoxOutputPath.Name = "TextBoxOutputPath";
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
            // TextBoxKey
            // 
            resources.ApplyResources(this.TextBoxKey, "TextBoxKey");
            this.TextBoxKey.Name = "TextBoxKey";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // buttonInputRef
            // 
            resources.ApplyResources(this.buttonInputRef, "buttonInputRef");
            this.buttonInputRef.Name = "buttonInputRef";
            this.buttonInputRef.UseVisualStyleBackColor = true;
            this.buttonInputRef.Click += new System.EventHandler(this.buttonInputRef_Click);
            // 
            // buttonOutputRef
            // 
            resources.ApplyResources(this.buttonOutputRef, "buttonOutputRef");
            this.buttonOutputRef.Name = "buttonOutputRef";
            this.buttonOutputRef.UseVisualStyleBackColor = true;
            this.buttonOutputRef.Click += new System.EventHandler(this.buttonOutputRef_Click);
            // 
            // buttonConvert
            // 
            resources.ApplyResources(this.buttonConvert, "buttonConvert");
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // buttonClose
            // 
            resources.ApplyResources(this.buttonClose, "buttonClose");
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // LogConverterForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
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