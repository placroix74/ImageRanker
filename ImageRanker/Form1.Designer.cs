namespace ImageRanker
{
    partial class Form1
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
            this.listImages = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rankImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rankingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadRankingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRankingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listImages
            // 
            this.listImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listImages.Location = new System.Drawing.Point(0, 27);
            this.listImages.Name = "listImages";
            this.listImages.Size = new System.Drawing.Size(508, 378);
            this.listImages.TabIndex = 0;
            this.listImages.UseCompatibleStateImageBehavior = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.rankingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(508, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImagesToolStripMenuItem,
            this.rankImagesToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.fileToolStripMenuItem.Text = "Images";
            // 
            // loadImagesToolStripMenuItem
            // 
            this.loadImagesToolStripMenuItem.Name = "loadImagesToolStripMenuItem";
            this.loadImagesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadImagesToolStripMenuItem.Text = "&Load...";
            this.loadImagesToolStripMenuItem.Click += new System.EventHandler(this.loadImagesToolStripMenuItem_Click);
            // 
            // rankImagesToolStripMenuItem
            // 
            this.rankImagesToolStripMenuItem.Name = "rankImagesToolStripMenuItem";
            this.rankImagesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rankImagesToolStripMenuItem.Text = "&Rank...";
            this.rankImagesToolStripMenuItem.Click += new System.EventHandler(this.rankImagesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // rankingToolStripMenuItem
            // 
            this.rankingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadRankingToolStripMenuItem,
            this.saveRankingToolStripMenuItem});
            this.rankingToolStripMenuItem.Name = "rankingToolStripMenuItem";
            this.rankingToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.rankingToolStripMenuItem.Text = "Ranking";
            // 
            // loadRankingToolStripMenuItem
            // 
            this.loadRankingToolStripMenuItem.Name = "loadRankingToolStripMenuItem";
            this.loadRankingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadRankingToolStripMenuItem.Text = "Load...";
            this.loadRankingToolStripMenuItem.Click += new System.EventHandler(this.loadRankingToolStripMenuItem_Click);
            // 
            // saveRankingToolStripMenuItem
            // 
            this.saveRankingToolStripMenuItem.Name = "saveRankingToolStripMenuItem";
            this.saveRankingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveRankingToolStripMenuItem.Text = "Save...";
            this.saveRankingToolStripMenuItem.Click += new System.EventHandler(this.saveRankingToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 407);
            this.Controls.Add(this.listImages);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listImages;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rankImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rankingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadRankingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveRankingToolStripMenuItem;
    }
}

