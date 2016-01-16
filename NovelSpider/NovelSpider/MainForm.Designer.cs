namespace NovelSpider
{
    partial class MainForm
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
            this.MainContainer = new System.Windows.Forms.SplitContainer();
            this.NovelContainer = new System.Windows.Forms.SplitContainer();
            this.treeViewChapter = new System.Windows.Forms.TreeView();
            this.BrowserContent = new System.Windows.Forms.WebBrowser();
            this.StatusContainer = new System.Windows.Forms.SplitContainer();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.WindowContainer = new System.Windows.Forms.SplitContainer();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.StripDownload = new System.Windows.Forms.ToolStripButton();
            this.StripLocal = new System.Windows.Forms.ToolStripButton();
            this.StripOption = new System.Windows.Forms.ToolStripButton();
            this.StripAbout = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).BeginInit();
            this.MainContainer.Panel1.SuspendLayout();
            this.MainContainer.Panel2.SuspendLayout();
            this.MainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NovelContainer)).BeginInit();
            this.NovelContainer.Panel1.SuspendLayout();
            this.NovelContainer.Panel2.SuspendLayout();
            this.NovelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatusContainer)).BeginInit();
            this.StatusContainer.Panel1.SuspendLayout();
            this.StatusContainer.Panel2.SuspendLayout();
            this.StatusContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WindowContainer)).BeginInit();
            this.WindowContainer.Panel1.SuspendLayout();
            this.WindowContainer.Panel2.SuspendLayout();
            this.WindowContainer.SuspendLayout();
            this.toolStripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainContainer
            // 
            this.MainContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.MainContainer.IsSplitterFixed = true;
            this.MainContainer.Location = new System.Drawing.Point(0, 0);
            this.MainContainer.Name = "MainContainer";
            this.MainContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainContainer.Panel1
            // 
            this.MainContainer.Panel1.Controls.Add(this.NovelContainer);
            // 
            // MainContainer.Panel2
            // 
            this.MainContainer.Panel2.Controls.Add(this.StatusContainer);
            this.MainContainer.Size = new System.Drawing.Size(624, 378);
            this.MainContainer.SplitterDistance = 352;
            this.MainContainer.SplitterWidth = 1;
            this.MainContainer.TabIndex = 1;
            // 
            // NovelContainer
            // 
            this.NovelContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NovelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NovelContainer.Location = new System.Drawing.Point(0, 0);
            this.NovelContainer.Name = "NovelContainer";
            // 
            // NovelContainer.Panel1
            // 
            this.NovelContainer.Panel1.Controls.Add(this.treeViewChapter);
            // 
            // NovelContainer.Panel2
            // 
            this.NovelContainer.Panel2.Controls.Add(this.BrowserContent);
            this.NovelContainer.Size = new System.Drawing.Size(620, 348);
            this.NovelContainer.SplitterDistance = 206;
            this.NovelContainer.SplitterWidth = 1;
            this.NovelContainer.TabIndex = 0;
            // 
            // treeViewChapter
            // 
            this.treeViewChapter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewChapter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewChapter.Location = new System.Drawing.Point(0, 0);
            this.treeViewChapter.Name = "treeViewChapter";
            this.treeViewChapter.Size = new System.Drawing.Size(204, 346);
            this.treeViewChapter.TabIndex = 0;
            this.treeViewChapter.DoubleClick += new System.EventHandler(this.treeViewChapter_DoubleClick);
            this.treeViewChapter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeViewChapter_KeyDown);
            // 
            // BrowserContent
            // 
            this.BrowserContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowserContent.Location = new System.Drawing.Point(0, 0);
            this.BrowserContent.MinimumSize = new System.Drawing.Size(20, 18);
            this.BrowserContent.Name = "BrowserContent";
            this.BrowserContent.Size = new System.Drawing.Size(411, 346);
            this.BrowserContent.TabIndex = 0;
            this.BrowserContent.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // StatusContainer
            // 
            this.StatusContainer.BackColor = System.Drawing.SystemColors.ControlLight;
            this.StatusContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatusContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusContainer.IsSplitterFixed = true;
            this.StatusContainer.Location = new System.Drawing.Point(0, 0);
            this.StatusContainer.Name = "StatusContainer";
            // 
            // StatusContainer.Panel1
            // 
            this.StatusContainer.Panel1.Controls.Add(this.textBoxStatus);
            // 
            // StatusContainer.Panel2
            // 
            this.StatusContainer.Panel2.Controls.Add(this.progressBar);
            this.StatusContainer.Size = new System.Drawing.Size(620, 21);
            this.StatusContainer.SplitterDistance = 341;
            this.StatusContainer.SplitterWidth = 1;
            this.StatusContainer.TabIndex = 0;
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxStatus.Location = new System.Drawing.Point(0, 0);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(339, 14);
            this.textBoxStatus.TabIndex = 0;
            this.textBoxStatus.Text = "就绪";
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.SystemColors.Window;
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(0, 0);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(276, 19);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 0;
            this.progressBar.Value = 38;
            // 
            // WindowContainer
            // 
            this.WindowContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WindowContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.WindowContainer.IsSplitterFixed = true;
            this.WindowContainer.Location = new System.Drawing.Point(0, 0);
            this.WindowContainer.Name = "WindowContainer";
            this.WindowContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // WindowContainer.Panel1
            // 
            this.WindowContainer.Panel1.Controls.Add(this.toolStripMenu);
            // 
            // WindowContainer.Panel2
            // 
            this.WindowContainer.Panel2.Controls.Add(this.MainContainer);
            this.WindowContainer.Size = new System.Drawing.Size(624, 407);
            this.WindowContainer.SplitterDistance = 25;
            this.WindowContainer.TabIndex = 2;
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripDownload,
            this.StripLocal,
            this.StripOption,
            this.StripAbout,
            this.toolStripSeparator1,
            this.toolStripTextBox1});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(624, 25);
            this.toolStripMenu.TabIndex = 0;
            // 
            // StripDownload
            // 
            this.StripDownload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StripDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StripDownload.Name = "StripDownload";
            this.StripDownload.Size = new System.Drawing.Size(51, 22);
            this.StripDownload.Text = "下载(&D)";
            this.StripDownload.ToolTipText = "下载新的小说";
            this.StripDownload.Click += new System.EventHandler(this.StripDownload_Click);
            // 
            // StripLocal
            // 
            this.StripLocal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StripLocal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StripLocal.Name = "StripLocal";
            this.StripLocal.Size = new System.Drawing.Size(51, 22);
            this.StripLocal.Text = "本地(&L)";
            this.StripLocal.ToolTipText = "打开本地存储管理";
            this.StripLocal.Click += new System.EventHandler(this.StripLocal_Click);
            // 
            // StripOption
            // 
            this.StripOption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StripOption.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StripOption.Name = "StripOption";
            this.StripOption.Size = new System.Drawing.Size(51, 22);
            this.StripOption.Text = "选项(&O)";
            this.StripOption.ToolTipText = "更改程序的工作方式";
            this.StripOption.Click += new System.EventHandler(this.StripOption_Click);
            // 
            // StripAbout
            // 
            this.StripAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StripAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StripAbout.Name = "StripAbout";
            this.StripAbout.Size = new System.Drawing.Size(51, 22);
            this.StripAbout.Text = "关于(&A)";
            this.StripAbout.ToolTipText = "关于本程序";
            this.StripAbout.Click += new System.EventHandler(this.StripAbout_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(300, 25);
            this.toolStripTextBox1.ToolTipText = "在此处搜索(当前阶段未实现)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 407);
            this.Controls.Add(this.WindowContainer);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.Text = "NovelSpider";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainContainer.Panel1.ResumeLayout(false);
            this.MainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).EndInit();
            this.MainContainer.ResumeLayout(false);
            this.NovelContainer.Panel1.ResumeLayout(false);
            this.NovelContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NovelContainer)).EndInit();
            this.NovelContainer.ResumeLayout(false);
            this.StatusContainer.Panel1.ResumeLayout(false);
            this.StatusContainer.Panel1.PerformLayout();
            this.StatusContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StatusContainer)).EndInit();
            this.StatusContainer.ResumeLayout(false);
            this.WindowContainer.Panel1.ResumeLayout(false);
            this.WindowContainer.Panel1.PerformLayout();
            this.WindowContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WindowContainer)).EndInit();
            this.WindowContainer.ResumeLayout(false);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer MainContainer;
        private System.Windows.Forms.SplitContainer StatusContainer;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.SplitContainer NovelContainer;
        private System.Windows.Forms.TreeView treeViewChapter;
        private System.Windows.Forms.WebBrowser BrowserContent;
        private System.Windows.Forms.SplitContainer WindowContainer;
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton StripDownload;
        private System.Windows.Forms.ToolStripButton StripLocal;
        private System.Windows.Forms.ToolStripButton StripOption;
        private System.Windows.Forms.ToolStripButton StripAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
    }
}

