namespace INIEditor
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.m_PropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.m_ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_CopyHelpTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_SaveToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ResetToDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_CommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ContextMenuStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_PropertyGrid
            // 
            this.m_PropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_PropertyGrid.ContextMenuStrip = this.m_ContextMenuStrip;
            this.m_PropertyGrid.Location = new System.Drawing.Point(0, 27);
            this.m_PropertyGrid.Margin = new System.Windows.Forms.Padding(2);
            this.m_PropertyGrid.Name = "m_PropertyGrid";
            this.m_PropertyGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.m_PropertyGrid.Size = new System.Drawing.Size(545, 499);
            this.m_PropertyGrid.TabIndex = 0;
            // 
            // m_ContextMenuStrip
            // 
            this.m_ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_CopyHelpTextToolStripMenuItem});
            this.m_ContextMenuStrip.Name = "m_ContextMenuStrip";
            this.m_ContextMenuStrip.Size = new System.Drawing.Size(149, 26);
            // 
            // m_CopyHelpTextToolStripMenuItem
            // 
            this.m_CopyHelpTextToolStripMenuItem.Name = "m_CopyHelpTextToolStripMenuItem";
            this.m_CopyHelpTextToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.m_CopyHelpTextToolStripMenuItem.Text = "复制帮助文本";
            this.m_CopyHelpTextToolStripMenuItem.Click += new System.EventHandler(this.OnCopyHelpTextToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.m_CommandToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(545, 25);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_OpenToolStripMenuItem,
            this.m_SaveToolStripMenuItem,
            this.m_SaveToToolStripMenuItem,
            this.toolStripSeparator1,
            this.m_CloseToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // m_OpenToolStripMenuItem
            // 
            this.m_OpenToolStripMenuItem.Name = "m_OpenToolStripMenuItem";
            this.m_OpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.m_OpenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.m_OpenToolStripMenuItem.Text = "打开";
            this.m_OpenToolStripMenuItem.Click += new System.EventHandler(this.OnOpenToolStripMenuItem_Click);
            // 
            // m_SaveToolStripMenuItem
            // 
            this.m_SaveToolStripMenuItem.Name = "m_SaveToolStripMenuItem";
            this.m_SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.m_SaveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.m_SaveToolStripMenuItem.Text = "保存";
            this.m_SaveToolStripMenuItem.Click += new System.EventHandler(this.OnSaveToolStripMenuItem_Click);
            // 
            // m_SaveToToolStripMenuItem
            // 
            this.m_SaveToToolStripMenuItem.Name = "m_SaveToToolStripMenuItem";
            this.m_SaveToToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.m_SaveToToolStripMenuItem.Text = "另存为";
            this.m_SaveToToolStripMenuItem.Click += new System.EventHandler(this.OnSaveToToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(109, 6);
            // 
            // m_CloseToolStripMenuItem
            // 
            this.m_CloseToolStripMenuItem.Name = "m_CloseToolStripMenuItem";
            this.m_CloseToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.m_CloseToolStripMenuItem.Text = "关闭";
            this.m_CloseToolStripMenuItem.Click += new System.EventHandler(this.OnCloseToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_ResetToolStripMenuItem,
            this.m_ResetToDefaultToolStripMenuItem});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // m_ResetToolStripMenuItem
            // 
            this.m_ResetToolStripMenuItem.Name = "m_ResetToolStripMenuItem";
            this.m_ResetToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.m_ResetToolStripMenuItem.Text = "重置";
            this.m_ResetToolStripMenuItem.Click += new System.EventHandler(this.OnResetToolStripMenuItem_Click);
            // 
            // m_ResetToDefaultToolStripMenuItem
            // 
            this.m_ResetToDefaultToolStripMenuItem.Name = "m_ResetToDefaultToolStripMenuItem";
            this.m_ResetToDefaultToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.m_ResetToDefaultToolStripMenuItem.Text = "恢复默认";
            this.m_ResetToDefaultToolStripMenuItem.Click += new System.EventHandler(this.OnResetToDefaultToolStripMenuItem_Click);
            // 
            // m_CommandToolStripMenuItem
            // 
            this.m_CommandToolStripMenuItem.Name = "m_CommandToolStripMenuItem";
            this.m_CommandToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.m_CommandToolStripMenuItem.Text = "指令";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 520);
            this.Controls.Add(this.m_PropertyGrid);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "INI Editor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.m_ContextMenuStrip.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid m_PropertyGrid;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_SaveToToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem m_CloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_ResetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_ResetToDefaultToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip m_ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem m_CopyHelpTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_CommandToolStripMenuItem;
    }
}

