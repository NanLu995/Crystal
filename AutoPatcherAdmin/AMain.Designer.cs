namespace AutoPatcherAdmin
{
    partial class AMain
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
            ClientTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            HostTextBox = new TextBox();
            label3 = new Label();
            LoginTextBox = new TextBox();
            label4 = new Label();
            PasswordTextBox = new TextBox();
            ProcessButton = new Button();
            progressBar1 = new ProgressBar();
            ActionLabel = new Label();
            label5 = new Label();
            progressBar2 = new ProgressBar();
            SpeedLabel = new Label();
            label7 = new Label();
            FileLabel = new Label();
            label8 = new Label();
            ListButton = new Button();
            AllowCleanCheckBox = new CheckBox();
            DownloadExistingButton = new Button();
            btnFixGZ = new Button();
            ProtocolDropDown = new ComboBox();
            label6 = new Label();
            SuspendLayout();
            // 
            // ClientTextBox
            // 
            ClientTextBox.Location = new Point(134, 21);
            ClientTextBox.Margin = new Padding(4);
            ClientTextBox.Name = "ClientTextBox";
            ClientTextBox.Size = new Size(345, 23);
            ClientTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(76, 25);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(47, 17);
            label1.TabIndex = 1;
            label1.Text = "客户端:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 69);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(59, 17);
            label2.TabIndex = 4;
            label2.Text = "主机地址:";
            // 
            // HostTextBox
            // 
            HostTextBox.Location = new Point(134, 65);
            HostTextBox.Margin = new Padding(4);
            HostTextBox.Name = "HostTextBox";
            HostTextBox.Size = new Size(345, 23);
            HostTextBox.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(90, 114);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(35, 17);
            label3.TabIndex = 6;
            label3.Text = "登录:";
            // 
            // LoginTextBox
            // 
            LoginTextBox.Location = new Point(134, 110);
            LoginTextBox.Margin = new Padding(4);
            LoginTextBox.Name = "LoginTextBox";
            LoginTextBox.Size = new Size(345, 23);
            LoginTextBox.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(90, 158);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(35, 17);
            label4.TabIndex = 8;
            label4.Text = "密码:";
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(134, 154);
            PasswordTextBox.Margin = new Padding(4);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(345, 23);
            PasswordTextBox.TabIndex = 7;
            // 
            // ProcessButton
            // 
            ProcessButton.Location = new Point(16, 238);
            ProcessButton.Margin = new Padding(4);
            ProcessButton.Name = "ProcessButton";
            ProcessButton.Size = new Size(110, 39);
            ProcessButton.TabIndex = 9;
            ProcessButton.Text = "增量同步";
            ProcessButton.UseVisualStyleBackColor = true;
            ProcessButton.Click += ProcessButton_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(16, 311);
            progressBar1.Margin = new Padding(4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(506, 27);
            progressBar1.TabIndex = 12;
            // 
            // ActionLabel
            // 
            ActionLabel.AutoSize = true;
            ActionLabel.Location = new Point(80, 284);
            ActionLabel.Margin = new Padding(4, 0, 4, 0);
            ActionLabel.Name = "ActionLabel";
            ActionLabel.Size = new Size(32, 17);
            ActionLabel.TabIndex = 11;
            ActionLabel.Text = "空闲";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(38, 284);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(35, 17);
            label5.TabIndex = 10;
            label5.Text = "操作:";
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(16, 407);
            progressBar2.Margin = new Padding(4);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(506, 17);
            progressBar2.TabIndex = 13;
            // 
            // SpeedLabel
            // 
            SpeedLabel.AutoSize = true;
            SpeedLabel.Location = new Point(80, 379);
            SpeedLabel.Margin = new Padding(4, 0, 4, 0);
            SpeedLabel.Name = "SpeedLabel";
            SpeedLabel.Size = new Size(32, 17);
            SpeedLabel.TabIndex = 15;
            SpeedLabel.Text = "空闲";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(38, 379);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(35, 17);
            label7.TabIndex = 14;
            label7.Text = "速度:";
            // 
            // FileLabel
            // 
            FileLabel.AutoSize = true;
            FileLabel.Location = new Point(80, 357);
            FileLabel.Margin = new Padding(4, 0, 4, 0);
            FileLabel.Name = "FileLabel";
            FileLabel.Size = new Size(32, 17);
            FileLabel.TabIndex = 17;
            FileLabel.Text = "空闲";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(38, 357);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(35, 17);
            label8.TabIndex = 16;
            label8.Text = "文件:";
            // 
            // ListButton
            // 
            ListButton.Location = new Point(400, 238);
            ListButton.Margin = new Padding(4);
            ListButton.Name = "ListButton";
            ListButton.Size = new Size(110, 39);
            ListButton.TabIndex = 20;
            ListButton.Text = "仅上传文件清单";
            ListButton.UseVisualStyleBackColor = true;
            ListButton.Click += ListButton_Click;
            // 
            // AllowCleanCheckBox
            // 
            AllowCleanCheckBox.AutoSize = true;
            AllowCleanCheckBox.Location = new Point(134, 199);
            AllowCleanCheckBox.Margin = new Padding(4);
            AllowCleanCheckBox.Name = "AllowCleanCheckBox";
            AllowCleanCheckBox.Size = new Size(135, 21);
            AllowCleanCheckBox.TabIndex = 22;
            AllowCleanCheckBox.Text = "允许整理服务器文件";
            AllowCleanCheckBox.UseVisualStyleBackColor = true;
            // 
            // DownloadExistingButton
            // 
            DownloadExistingButton.Location = new Point(272, 238);
            DownloadExistingButton.Margin = new Padding(4);
            DownloadExistingButton.Name = "DownloadExistingButton";
            DownloadExistingButton.Size = new Size(110, 39);
            DownloadExistingButton.TabIndex = 23;
            DownloadExistingButton.Text = "下载服务器数据";
            DownloadExistingButton.UseVisualStyleBackColor = true;
            DownloadExistingButton.Click += DownloadExistingButton_Click;
            // 
            // btnFixGZ
            // 
            btnFixGZ.Location = new Point(144, 238);
            btnFixGZ.Margin = new Padding(4);
            btnFixGZ.Name = "btnFixGZ";
            btnFixGZ.Size = new Size(110, 39);
            btnFixGZ.TabIndex = 24;
            btnFixGZ.Text = "修复服务器后缀";
            btnFixGZ.UseVisualStyleBackColor = true;
            btnFixGZ.Click += BtnFixGZ_Click;
            // 
            // ProtocolDropDown
            // 
            ProtocolDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            ProtocolDropDown.FormattingEnabled = true;
            ProtocolDropDown.Items.AddRange(new object[] { "Ftp", "SFtp" });
            ProtocolDropDown.Location = new Point(357, 195);
            ProtocolDropDown.Margin = new Padding(4);
            ProtocolDropDown.Name = "ProtocolDropDown";
            ProtocolDropDown.Size = new Size(123, 25);
            ProtocolDropDown.TabIndex = 25;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(290, 199);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(59, 17);
            label6.TabIndex = 26;
            label6.Text = "链接协议:";
            // 
            // AMain
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(533, 439);
            Controls.Add(label6);
            Controls.Add(ProtocolDropDown);
            Controls.Add(btnFixGZ);
            Controls.Add(DownloadExistingButton);
            Controls.Add(AllowCleanCheckBox);
            Controls.Add(ListButton);
            Controls.Add(FileLabel);
            Controls.Add(label8);
            Controls.Add(SpeedLabel);
            Controls.Add(label7);
            Controls.Add(progressBar2);
            Controls.Add(progressBar1);
            Controls.Add(ActionLabel);
            Controls.Add(label5);
            Controls.Add(ProcessButton);
            Controls.Add(label4);
            Controls.Add(PasswordTextBox);
            Controls.Add(label3);
            Controls.Add(LoginTextBox);
            Controls.Add(label2);
            Controls.Add(HostTextBox);
            Controls.Add(label1);
            Controls.Add(ClientTextBox);
            Margin = new Padding(4);
            Name = "AMain";
            Text = "自动更新管理窗口";
            Load += AMain_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ClientTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox HostTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button ProcessButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label ActionLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label SpeedLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label FileLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button ListButton;
        private System.Windows.Forms.CheckBox AllowCleanCheckBox;
        private System.Windows.Forms.Button DownloadExistingButton;
        private System.Windows.Forms.Button btnFixGZ;
        private System.Windows.Forms.ComboBox ProtocolDropDown;
        private System.Windows.Forms.Label label6;
    }
}

