namespace NShop
{
    partial class NewVersion
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
            this.labelReleaseNotes = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelUpdate = new System.Windows.Forms.Label();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonRemindLater = new System.Windows.Forms.Button();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // labelReleaseNotes
            // 
            this.labelReleaseNotes.AutoSize = true;
            this.labelReleaseNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.labelReleaseNotes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelReleaseNotes.Location = new System.Drawing.Point(93, 46);
            this.labelReleaseNotes.Name = "labelReleaseNotes";
            this.labelReleaseNotes.Size = new System.Drawing.Size(76, 16);
            this.labelReleaseNotes.TabIndex = 15;
            this.labelReleaseNotes.Text = "更新说明:";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelDescription.Location = new System.Drawing.Point(291, 13);
            this.labelDescription.MaximumSize = new System.Drawing.Size(550, 0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(254, 15);
            this.labelDescription.TabIndex = 14;
            this.labelDescription.Text = "软件已更新至最新版本 {0}. 您确定现在升级吗?";
            // 
            // labelUpdate
            // 
            this.labelUpdate.AutoSize = true;
            this.labelUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.labelUpdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelUpdate.Location = new System.Drawing.Point(93, 11);
            this.labelUpdate.MaximumSize = new System.Drawing.Size(560, 0);
            this.labelUpdate.Name = "labelUpdate";
            this.labelUpdate.Size = new System.Drawing.Size(159, 17);
            this.labelUpdate.TabIndex = 13;
            this.labelUpdate.Text = "发现有可更新版本-{0}!";
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(14, 70);
            this.webBrowser.Margin = new System.Windows.Forms.Padding(2);
            this.webBrowser.MinimumSize = new System.Drawing.Size(23, 23);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(620, 324);
            this.webBrowser.TabIndex = 9;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonUpdate.Image = global::NShop.Properties.Resources.download;
            this.buttonUpdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonUpdate.Location = new System.Drawing.Point(531, 405);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(102, 28);
            this.buttonUpdate.TabIndex = 11;
            this.buttonUpdate.Text = "立即升级";
            this.buttonUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonRemindLater
            // 
            this.buttonRemindLater.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonRemindLater.Image = global::NShop.Properties.Resources.hand_point;
            this.buttonRemindLater.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonRemindLater.Location = new System.Drawing.Point(424, 405);
            this.buttonRemindLater.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRemindLater.Name = "buttonRemindLater";
            this.buttonRemindLater.Size = new System.Drawing.Size(103, 28);
            this.buttonRemindLater.TabIndex = 12;
            this.buttonRemindLater.Text = "退出系统";
            this.buttonRemindLater.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonRemindLater.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonRemindLater.UseVisualStyleBackColor = true;
            this.buttonRemindLater.Click += new System.EventHandler(this.buttonRemindLater_Click);
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Image = global::NShop.Properties.Resources.update;
            this.pictureBoxIcon.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBoxIcon.Location = new System.Drawing.Point(14, 11);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(60, 51);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxIcon.TabIndex = 16;
            this.pictureBoxIcon.TabStop = false;
            // 
            // NewVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 441);
            this.Controls.Add(this.pictureBoxIcon);
            this.Controls.Add(this.labelReleaseNotes);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelUpdate);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonRemindLater);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewVersion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "软件更新";
            this.Load += new System.EventHandler(this.NewVersion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Label labelReleaseNotes;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelUpdate;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonRemindLater;
    }
}