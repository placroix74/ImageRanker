namespace ImageRanker
{
    partial class RankOne
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.radioPickLeft = new System.Windows.Forms.RadioButton();
            this.radioExcludeLeft = new System.Windows.Forms.RadioButton();
            this.radioPickRight = new System.Windows.Forms.RadioButton();
            this.radioExcludeRight = new System.Windows.Forms.RadioButton();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonAbort = new System.Windows.Forms.Button();
            this.radioPickBoth = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(464, 464);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(484, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(464, 464);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // radioPickLeft
            // 
            this.radioPickLeft.AutoSize = true;
            this.radioPickLeft.Location = new System.Drawing.Point(294, 482);
            this.radioPickLeft.Name = "radioPickLeft";
            this.radioPickLeft.Size = new System.Drawing.Size(46, 17);
            this.radioPickLeft.TabIndex = 6;
            this.radioPickLeft.TabStop = true;
            this.radioPickLeft.Tag = "PickLeft";
            this.radioPickLeft.Text = "Pick";
            this.radioPickLeft.UseVisualStyleBackColor = true;
            // 
            // radioExcludeLeft
            // 
            this.radioExcludeLeft.AutoSize = true;
            this.radioExcludeLeft.Location = new System.Drawing.Point(128, 482);
            this.radioExcludeLeft.Name = "radioExcludeLeft";
            this.radioExcludeLeft.Size = new System.Drawing.Size(63, 17);
            this.radioExcludeLeft.TabIndex = 5;
            this.radioExcludeLeft.TabStop = true;
            this.radioExcludeLeft.Tag = "ExcludeLeft";
            this.radioExcludeLeft.Text = "Exclude";
            this.radioExcludeLeft.UseVisualStyleBackColor = true;
            // 
            // radioPickRight
            // 
            this.radioPickRight.AutoSize = true;
            this.radioPickRight.Location = new System.Drawing.Point(617, 482);
            this.radioPickRight.Name = "radioPickRight";
            this.radioPickRight.Size = new System.Drawing.Size(46, 17);
            this.radioPickRight.TabIndex = 1;
            this.radioPickRight.TabStop = true;
            this.radioPickRight.Tag = "PickRight";
            this.radioPickRight.Text = "Pick";
            this.radioPickRight.UseVisualStyleBackColor = true;
            // 
            // radioExcludeRight
            // 
            this.radioExcludeRight.AutoSize = true;
            this.radioExcludeRight.Location = new System.Drawing.Point(766, 482);
            this.radioExcludeRight.Name = "radioExcludeRight";
            this.radioExcludeRight.Size = new System.Drawing.Size(63, 17);
            this.radioExcludeRight.TabIndex = 2;
            this.radioExcludeRight.TabStop = true;
            this.radioExcludeRight.Tag = "ExcludeRight";
            this.radioExcludeRight.Text = "Exclude";
            this.radioExcludeRight.UseVisualStyleBackColor = true;
            // 
            // buttonNext
            // 
            this.buttonNext.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonNext.Location = new System.Drawing.Point(401, 513);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            // 
            // buttonAbort
            // 
            this.buttonAbort.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.buttonAbort.Location = new System.Drawing.Point(484, 513);
            this.buttonAbort.Name = "buttonAbort";
            this.buttonAbort.Size = new System.Drawing.Size(75, 23);
            this.buttonAbort.TabIndex = 4;
            this.buttonAbort.Text = "Abort";
            this.buttonAbort.UseVisualStyleBackColor = true;
            // 
            // radioPickBoth
            // 
            this.radioPickBoth.AutoSize = true;
            this.radioPickBoth.Location = new System.Drawing.Point(443, 482);
            this.radioPickBoth.Name = "radioPickBoth";
            this.radioPickBoth.Size = new System.Drawing.Size(71, 17);
            this.radioPickBoth.TabIndex = 0;
            this.radioPickBoth.TabStop = true;
            this.radioPickBoth.Tag = "PickBoth";
            this.radioPickBoth.Text = "Pick Both";
            this.radioPickBoth.UseVisualStyleBackColor = true;
            // 
            // RankOne
            // 
            this.AcceptButton = this.buttonNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonAbort;
            this.ClientSize = new System.Drawing.Size(960, 548);
            this.Controls.Add(this.radioPickBoth);
            this.Controls.Add(this.buttonAbort);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.radioExcludeRight);
            this.Controls.Add(this.radioPickRight);
            this.Controls.Add(this.radioExcludeLeft);
            this.Controls.Add(this.radioPickLeft);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "RankOne";
            this.Text = "RankOne";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RankOne_FormClosing);
            this.Shown += new System.EventHandler(this.RankOne_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RadioButton radioPickLeft;
        private System.Windows.Forms.RadioButton radioExcludeLeft;
        private System.Windows.Forms.RadioButton radioPickRight;
        private System.Windows.Forms.RadioButton radioExcludeRight;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonAbort;
        private System.Windows.Forms.RadioButton radioPickBoth;
    }
}