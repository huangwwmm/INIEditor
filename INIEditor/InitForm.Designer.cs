namespace INIEditor
{
    partial class InitForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.m_ConfigTypeComboBox = new System.Windows.Forms.ComboBox();
            this.m_OKButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "配置类型：";
            // 
            // m_ConfigTypeComboBox
            // 
            this.m_ConfigTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ConfigTypeComboBox.FormattingEnabled = true;
            this.m_ConfigTypeComboBox.Location = new System.Drawing.Point(78, 34);
            this.m_ConfigTypeComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_ConfigTypeComboBox.Name = "m_ConfigTypeComboBox";
            this.m_ConfigTypeComboBox.Size = new System.Drawing.Size(327, 20);
            this.m_ConfigTypeComboBox.TabIndex = 2;
            // 
            // m_OKButton
            // 
            this.m_OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_OKButton.Location = new System.Drawing.Point(353, 7);
            this.m_OKButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_OKButton.Name = "m_OKButton";
            this.m_OKButton.Size = new System.Drawing.Size(50, 20);
            this.m_OKButton.TabIndex = 5;
            this.m_OKButton.Text = "确定";
            this.m_OKButton.UseVisualStyleBackColor = true;
            this.m_OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // InitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 62);
            this.Controls.Add(this.m_OKButton);
            this.Controls.Add(this.m_ConfigTypeComboBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InitForm";
            this.Text = "选择配置";
            this.Load += new System.EventHandler(this.OnInitForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox m_ConfigTypeComboBox;
        private System.Windows.Forms.Button m_OKButton;
    }
}