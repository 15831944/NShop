namespace NShop.Manage
{
    partial class MemberMng
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemberMng));
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.varMemo = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.varBirthday = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.varShortCode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.varMemberNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.varAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.varMemberName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.varIDNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.varPhoneNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.varFeedback = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.varScores = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.varSize = new System.Windows.Forms.ComboBox();
            this.varStyle = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(436, 313);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保 存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.varScores);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(627, 341);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(627, 307);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(619, 281);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "会员基本信息";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.varMemo);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.varBirthday);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.varShortCode);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.varMemberNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.varAddress);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.varMemberName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.varIDNo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.varPhoneNo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(8, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(603, 265);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // varMemo
            // 
            this.varMemo.Location = new System.Drawing.Point(87, 181);
            this.varMemo.Name = "varMemo";
            this.varMemo.Size = new System.Drawing.Size(493, 68);
            this.varMemo.TabIndex = 49;
            this.varMemo.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 184);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 12);
            this.label12.TabIndex = 48;
            this.label12.Text = "备 注：";
            // 
            // varBirthday
            // 
            this.varBirthday.Location = new System.Drawing.Point(396, 104);
            this.varBirthday.Name = "varBirthday";
            this.varBirthday.Size = new System.Drawing.Size(184, 21);
            this.varBirthday.TabIndex = 47;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(325, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 46;
            this.label11.Text = "会员生日：";
            // 
            // varShortCode
            // 
            this.varShortCode.Location = new System.Drawing.Point(396, 65);
            this.varShortCode.Name = "varShortCode";
            this.varShortCode.Size = new System.Drawing.Size(184, 21);
            this.varShortCode.TabIndex = 43;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(325, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 44;
            this.label10.Text = "助记码：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(275, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 42;
            this.label9.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(584, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 41;
            this.label8.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(-340, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 40;
            this.label6.Text = "*";
            // 
            // varMemberNo
            // 
            this.varMemberNo.Location = new System.Drawing.Point(396, 25);
            this.varMemberNo.Name = "varMemberNo";
            this.varMemberNo.Size = new System.Drawing.Size(184, 21);
            this.varMemberNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(325, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 38;
            this.label1.Text = "会员卡号：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(274, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 36;
            this.label7.Text = "*";
            // 
            // varAddress
            // 
            this.varAddress.Location = new System.Drawing.Point(87, 144);
            this.varAddress.Name = "varAddress";
            this.varAddress.Size = new System.Drawing.Size(493, 21);
            this.varAddress.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 34;
            this.label4.Text = "联系地址：";
            // 
            // varMemberName
            // 
            this.varMemberName.Location = new System.Drawing.Point(87, 65);
            this.varMemberName.Name = "varMemberName";
            this.varMemberName.Size = new System.Drawing.Size(184, 21);
            this.varMemberName.TabIndex = 2;
            this.varMemberName.Leave += new System.EventHandler(this.varMemberName_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 32;
            this.label2.Text = "会员姓名：";
            // 
            // varIDNo
            // 
            this.varIDNo.Location = new System.Drawing.Point(87, 104);
            this.varIDNo.Name = "varIDNo";
            this.varIDNo.Size = new System.Drawing.Size(184, 21);
            this.varIDNo.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 24;
            this.label5.Text = "身份证号：";
            // 
            // varPhoneNo
            // 
            this.varPhoneNo.Location = new System.Drawing.Point(87, 25);
            this.varPhoneNo.Name = "varPhoneNo";
            this.varPhoneNo.Size = new System.Drawing.Size(184, 21);
            this.varPhoneNo.TabIndex = 0;
            this.varPhoneNo.Leave += new System.EventHandler(this.varPhoneNo_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "会员手机：";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(619, 281);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "服装行业";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.varStyle);
            this.groupBox2.Controls.Add(this.varSize);
            this.groupBox2.Controls.Add(this.varFeedback);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Location = new System.Drawing.Point(8, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(603, 265);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // varFeedback
            // 
            this.varFeedback.Location = new System.Drawing.Point(89, 66);
            this.varFeedback.Name = "varFeedback";
            this.varFeedback.Size = new System.Drawing.Size(476, 181);
            this.varFeedback.TabIndex = 51;
            this.varFeedback.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(35, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 12);
            this.label13.TabIndex = 50;
            this.label13.Text = "反 馈：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(-340, 38);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(11, 12);
            this.label18.TabIndex = 40;
            this.label18.Text = "*";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(335, 30);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 12);
            this.label19.TabIndex = 38;
            this.label19.Text = "风 格：";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(35, 29);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(47, 12);
            this.label24.TabIndex = 23;
            this.label24.Text = "码 数：";
            // 
            // varScores
            // 
            this.varScores.Location = new System.Drawing.Point(30, 312);
            this.varScores.Name = "varScores";
            this.varScores.Size = new System.Drawing.Size(184, 21);
            this.varScores.TabIndex = 4;
            this.varScores.Text = "0";
            this.varScores.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(517, 312);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关 闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // varSize
            // 
            this.varSize.FormattingEnabled = true;
            this.varSize.Items.AddRange(new object[] {
            "07",
            "09",
            "11",
            "13",
            "15"});
            this.varSize.Location = new System.Drawing.Point(89, 26);
            this.varSize.Name = "varSize";
            this.varSize.Size = new System.Drawing.Size(177, 20);
            this.varSize.TabIndex = 54;
            // 
            // varStyle
            // 
            this.varStyle.FormattingEnabled = true;
            this.varStyle.Items.AddRange(new object[] {
            "瑞丽",
            "嘻皮",
            "百搭",
            "淑女",
            "韩版",
            "民族",
            "欧美",
            "学院",
            "通勤",
            "中性",
            "嘻哈",
            "田园",
            "朋克",
            "OL",
            "洛丽塔",
            "街头",
            "简约",
            "波西米亚"});
            this.varStyle.Location = new System.Drawing.Point(388, 26);
            this.varStyle.Name = "varStyle";
            this.varStyle.Size = new System.Drawing.Size(177, 20);
            this.varStyle.TabIndex = 55;
            // 
            // MemberMng
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 341);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MemberMng";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "会员信息管理";
            this.Load += new System.EventHandler(this.MemberMng_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox varScores;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox varMemo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker varBirthday;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox varShortCode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox varMemberNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox varAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox varMemberName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox varIDNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox varPhoneNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.RichTextBox varFeedback;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox varStyle;
        private System.Windows.Forms.ComboBox varSize;
    }
}