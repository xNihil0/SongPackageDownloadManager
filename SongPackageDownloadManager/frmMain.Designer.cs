﻿namespace SongPackageDownloadManager
{
    partial class frmMain
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
            this.btnGetPkgLst = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lstSongPkgs = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // btnGetPkgLst
            // 
            this.btnGetPkgLst.Location = new System.Drawing.Point(12, 12);
            this.btnGetPkgLst.Name = "btnGetPkgLst";
            this.btnGetPkgLst.Size = new System.Drawing.Size(75, 23);
            this.btnGetPkgLst.TabIndex = 0;
            this.btnGetPkgLst.Text = "Init";
            this.btnGetPkgLst.UseVisualStyleBackColor = true;
            this.btnGetPkgLst.Click += new System.EventHandler(this.btnGetPkgLst_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 41);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(820, 397);
            this.textBox1.TabIndex = 1;
            // 
            // lstSongPkgs
            // 
            this.lstSongPkgs.FormattingEnabled = true;
            this.lstSongPkgs.Location = new System.Drawing.Point(12, 41);
            this.lstSongPkgs.Name = "lstSongPkgs";
            this.lstSongPkgs.Size = new System.Drawing.Size(820, 404);
            this.lstSongPkgs.TabIndex = 2;
            this.lstSongPkgs.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 450);
            this.Controls.Add(this.lstSongPkgs);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnGetPkgLst);
            this.Name = "frmMain";
            this.Text = "Etterna Song Package ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetPkgLst;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckedListBox lstSongPkgs;
    }
}

