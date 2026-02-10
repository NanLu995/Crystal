namespace Server
{
    partial class ConfigForm
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
            SaveButton = new Button();
            configTabs = new TabControl();
            tabPage1 = new TabPage();
            groupBox1 = new GroupBox();
            label11 = new Label();
            DBVersionLabel = new Label();
            ServerVersionLabel = new Label();
            label10 = new Label();
            VersionCheckBox = new CheckBox();
            VPathBrowseButton = new Button();
            VPathTextBox = new TextBox();
            label1 = new Label();
            tabPage2 = new TabPage();
            gbServerSettings = new GroupBox();
            SaveDelayTextBox = new TextBox();
            label6 = new Label();
            label12 = new Label();
            gbHTTPService = new GroupBox();
            label15 = new Label();
            HTTPTrustedIPAddressTextBox = new TextBox();
            label14 = new Label();
            HTTPIPAddressTextBox = new TextBox();
            label13 = new Label();
            StartHTTPCheckBox = new CheckBox();
            gbConnectionSettings = new GroupBox();
            RelogDelayTextBox = new TextBox();
            label7 = new Label();
            maxConnectionsPerIP = new TextBox();
            lblMaxConnectionsPerIP = new Label();
            MaxUserTextBox = new TextBox();
            label5 = new Label();
            TimeOutTextBox = new TextBox();
            label4 = new Label();
            gbServerConnection = new GroupBox();
            IPAddressTextBox = new TextBox();
            label2 = new Label();
            PortTextBox = new TextBox();
            label3 = new Label();
            tabPage3 = new TabPage();
            gbGameWorld = new GroupBox();
            SafeZoneHealingCheckBox = new CheckBox();
            SafeZoneBorderCheckBox = new CheckBox();
            ObserveCheckBox = new CheckBox();
            WarehousePasswordCheckBox = new CheckBox();
            gbCharacterScreen = new GroupBox();
            StartGameCheckBox = new CheckBox();
            NCharacterCheckBox = new CheckBox();
            DCharacterCheckBox = new CheckBox();
            AllowAssassinCheckBox = new CheckBox();
            AllowArcherCheckBox = new CheckBox();
            gbLoginScreen = new GroupBox();
            AccountCheckBox = new CheckBox();
            PasswordCheckBox = new CheckBox();
            LoginCheckBox = new CheckBox();
            tabPage6 = new TabPage();
            gbRestedExpRates = new GroupBox();
            label22 = new Label();
            label23 = new Label();
            label21 = new Label();
            label20 = new Label();
            tbRestedPeriod = new TextBox();
            tbRestedBuffLength = new TextBox();
            tbMaxRestedBonus = new TextBox();
            tbRestedExpBonus = new TextBox();
            lblMaxRestedBonus = new Label();
            lblRestedExpBonus = new Label();
            lblRestedBuffLength = new Label();
            lblPeriod = new Label();
            gbGlobals = new GroupBox();
            label19 = new Label();
            label18 = new Label();
            dropRateInput = new NumericUpDown();
            lblDropRate = new Label();
            expRateInput = new NumericUpDown();
            lblExpRate = new Label();
            tabPage5 = new TabPage();
            groupBox2 = new GroupBox();
            ReaddArcDrops = new Button();
            ReaddSinDrops = new Button();
            RemoveArcDrops = new Button();
            RemoveSinDrops = new Button();
            Resolution_textbox = new TextBox();
            label9 = new Label();
            label16 = new Label();
            lineMessageTimeTextBox = new TextBox();
            label17 = new Label();
            gameMasterEffect_CheckBox = new CheckBox();
            label8 = new Label();
            VPathDialog = new OpenFileDialog();
            configTabs.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPage2.SuspendLayout();
            gbServerSettings.SuspendLayout();
            gbHTTPService.SuspendLayout();
            gbConnectionSettings.SuspendLayout();
            gbServerConnection.SuspendLayout();
            tabPage3.SuspendLayout();
            gbGameWorld.SuspendLayout();
            gbCharacterScreen.SuspendLayout();
            gbLoginScreen.SuspendLayout();
            tabPage6.SuspendLayout();
            gbRestedExpRates.SuspendLayout();
            gbGlobals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dropRateInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)expRateInput).BeginInit();
            tabPage5.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // SaveButton
            // 
            SaveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SaveButton.Location = new Point(406, 446);
            SaveButton.Margin = new Padding(3, 5, 3, 5);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(87, 29);
            SaveButton.TabIndex = 6;
            SaveButton.Text = "关闭";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // configTabs
            // 
            configTabs.Controls.Add(tabPage1);
            configTabs.Controls.Add(tabPage2);
            configTabs.Controls.Add(tabPage3);
            configTabs.Controls.Add(tabPage6);
            configTabs.Controls.Add(tabPage5);
            configTabs.Location = new Point(14, 16);
            configTabs.Margin = new Padding(3, 5, 3, 5);
            configTabs.Name = "configTabs";
            configTabs.SelectedIndex = 0;
            configTabs.Size = new Size(484, 426);
            configTabs.TabIndex = 5;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Controls.Add(VersionCheckBox);
            tabPage1.Controls.Add(VPathBrowseButton);
            tabPage1.Controls.Add(VPathTextBox);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 26);
            tabPage1.Margin = new Padding(3, 5, 3, 5);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 5, 3, 5);
            tabPage1.Size = new Size(476, 396);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "版本信息";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(DBVersionLabel);
            groupBox1.Controls.Add(ServerVersionLabel);
            groupBox1.Controls.Add(label10);
            groupBox1.Location = new Point(7, 301);
            groupBox1.Margin = new Padding(3, 5, 3, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 5, 3, 5);
            groupBox1.Size = new Size(460, 84);
            groupBox1.TabIndex = 25;
            groupBox1.TabStop = false;
            groupBox1.Text = "服务器版本信息";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(29, 55);
            label11.Margin = new Padding(5, 0, 5, 0);
            label11.Name = "label11";
            label11.Size = new Size(44, 17);
            label11.TabIndex = 23;
            label11.Text = "数据库";
            // 
            // DBVersionLabel
            // 
            DBVersionLabel.AutoSize = true;
            DBVersionLabel.Location = new Point(89, 56);
            DBVersionLabel.Name = "DBVersionLabel";
            DBVersionLabel.Size = new Size(92, 17);
            DBVersionLabel.TabIndex = 24;
            DBVersionLabel.Text = "服务器版本信息";
            // 
            // ServerVersionLabel
            // 
            ServerVersionLabel.AutoSize = true;
            ServerVersionLabel.Location = new Point(89, 26);
            ServerVersionLabel.Name = "ServerVersionLabel";
            ServerVersionLabel.Size = new Size(52, 17);
            ServerVersionLabel.TabIndex = 7;
            ServerVersionLabel.Text = "Version";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(29, 28);
            label10.Margin = new Padding(5, 0, 5, 0);
            label10.Name = "label10";
            label10.Size = new Size(44, 17);
            label10.TabIndex = 22;
            label10.Text = "服务器";
            // 
            // VersionCheckBox
            // 
            VersionCheckBox.AutoSize = true;
            VersionCheckBox.Location = new Point(104, 56);
            VersionCheckBox.Margin = new Padding(3, 5, 3, 5);
            VersionCheckBox.Name = "VersionCheckBox";
            VersionCheckBox.Size = new Size(111, 21);
            VersionCheckBox.TabIndex = 3;
            VersionCheckBox.Text = "检查登录器版本";
            VersionCheckBox.UseVisualStyleBackColor = true;
            // 
            // VPathBrowseButton
            // 
            VPathBrowseButton.Location = new Point(436, 18);
            VPathBrowseButton.Margin = new Padding(3, 5, 3, 5);
            VPathBrowseButton.Name = "VPathBrowseButton";
            VPathBrowseButton.Size = new Size(33, 29);
            VPathBrowseButton.TabIndex = 2;
            VPathBrowseButton.Text = "...";
            VPathBrowseButton.UseVisualStyleBackColor = true;
            VPathBrowseButton.Click += VPathBrowseButton_Click;
            // 
            // VPathTextBox
            // 
            VPathTextBox.Location = new Point(104, 22);
            VPathTextBox.Margin = new Padding(3, 5, 3, 5);
            VPathTextBox.Name = "VPathTextBox";
            VPathTextBox.ReadOnly = true;
            VPathTextBox.Size = new Size(324, 23);
            VPathTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 24);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(68, 17);
            label1.TabIndex = 0;
            label1.Text = "登录器路径";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(gbServerSettings);
            tabPage2.Controls.Add(gbHTTPService);
            tabPage2.Controls.Add(gbConnectionSettings);
            tabPage2.Controls.Add(gbServerConnection);
            tabPage2.Location = new Point(4, 26);
            tabPage2.Margin = new Padding(3, 5, 3, 5);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 5, 3, 5);
            tabPage2.Size = new Size(476, 396);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "网络";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // gbServerSettings
            // 
            gbServerSettings.Controls.Add(SaveDelayTextBox);
            gbServerSettings.Controls.Add(label6);
            gbServerSettings.Controls.Add(label12);
            gbServerSettings.Location = new Point(17, 114);
            gbServerSettings.Name = "gbServerSettings";
            gbServerSettings.Size = new Size(196, 68);
            gbServerSettings.TabIndex = 3;
            gbServerSettings.TabStop = false;
            gbServerSettings.Text = "数据库设置";
            // 
            // SaveDelayTextBox
            // 
            SaveDelayTextBox.Location = new Point(90, 28);
            SaveDelayTextBox.Margin = new Padding(3, 5, 3, 5);
            SaveDelayTextBox.MaxLength = 5;
            SaveDelayTextBox.Name = "SaveDelayTextBox";
            SaveDelayTextBox.Size = new Size(61, 23);
            SaveDelayTextBox.TabIndex = 25;
            SaveDelayTextBox.TextChanged += CheckUShort;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 32);
            label6.Name = "label6";
            label6.Size = new Size(83, 17);
            label6.TabIndex = 24;
            label6.Text = "保存数据延时:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(157, 32);
            label12.Name = "label12";
            label12.Size = new Size(32, 17);
            label12.TabIndex = 26;
            label12.Text = "分钟";
            // 
            // gbHTTPService
            // 
            gbHTTPService.Controls.Add(label15);
            gbHTTPService.Controls.Add(HTTPTrustedIPAddressTextBox);
            gbHTTPService.Controls.Add(label14);
            gbHTTPService.Controls.Add(HTTPIPAddressTextBox);
            gbHTTPService.Controls.Add(label13);
            gbHTTPService.Controls.Add(StartHTTPCheckBox);
            gbHTTPService.Location = new Point(17, 189);
            gbHTTPService.Name = "gbHTTPService";
            gbHTTPService.Size = new Size(440, 182);
            gbHTTPService.TabIndex = 2;
            gbHTTPService.TabStop = false;
            gbHTTPService.Text = "HTTP 服务";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(20, 115);
            label15.Name = "label15";
            label15.Size = new Size(173, 17);
            label15.TabIndex = 22;
            label15.Text = "(HTTP 服务只允许受信任的 IP)";
            // 
            // HTTPTrustedIPAddressTextBox
            // 
            HTTPTrustedIPAddressTextBox.Location = new Point(150, 83);
            HTTPTrustedIPAddressTextBox.Margin = new Padding(3, 5, 3, 5);
            HTTPTrustedIPAddressTextBox.MaxLength = 30;
            HTTPTrustedIPAddressTextBox.Name = "HTTPTrustedIPAddressTextBox";
            HTTPTrustedIPAddressTextBox.Size = new Size(198, 23);
            HTTPTrustedIPAddressTextBox.TabIndex = 21;
            HTTPTrustedIPAddressTextBox.TextChanged += HTTPTrustedIPAddressTextBox_TextChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(20, 86);
            label14.Name = "label14";
            label14.Size = new Size(109, 17);
            label14.TabIndex = 20;
            label14.Text = "HTTP 可信 IP 地址";
            // 
            // HTTPIPAddressTextBox
            // 
            HTTPIPAddressTextBox.Location = new Point(150, 54);
            HTTPIPAddressTextBox.Margin = new Padding(3, 5, 3, 5);
            HTTPIPAddressTextBox.MaxLength = 30;
            HTTPIPAddressTextBox.Name = "HTTPIPAddressTextBox";
            HTTPIPAddressTextBox.Size = new Size(198, 23);
            HTTPIPAddressTextBox.TabIndex = 19;
            HTTPIPAddressTextBox.TextChanged += HTTPIPAddressTextBox_TextChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(20, 58);
            label13.Name = "label13";
            label13.Size = new Size(77, 17);
            label13.TabIndex = 18;
            label13.Text = "HTTP IP地址";
            // 
            // StartHTTPCheckBox
            // 
            StartHTTPCheckBox.AutoSize = true;
            StartHTTPCheckBox.Location = new Point(20, 28);
            StartHTTPCheckBox.Margin = new Padding(3, 5, 3, 5);
            StartHTTPCheckBox.Name = "StartHTTPCheckBox";
            StartHTTPCheckBox.Size = new Size(105, 21);
            StartHTTPCheckBox.TabIndex = 23;
            StartHTTPCheckBox.Text = "启用HTTP服务";
            StartHTTPCheckBox.UseVisualStyleBackColor = true;
            StartHTTPCheckBox.CheckedChanged += StartHTTPCheckBox_CheckedChanged;
            // 
            // gbConnectionSettings
            // 
            gbConnectionSettings.Controls.Add(RelogDelayTextBox);
            gbConnectionSettings.Controls.Add(label7);
            gbConnectionSettings.Controls.Add(maxConnectionsPerIP);
            gbConnectionSettings.Controls.Add(lblMaxConnectionsPerIP);
            gbConnectionSettings.Controls.Add(MaxUserTextBox);
            gbConnectionSettings.Controls.Add(label5);
            gbConnectionSettings.Controls.Add(TimeOutTextBox);
            gbConnectionSettings.Controls.Add(label4);
            gbConnectionSettings.Location = new Point(232, 20);
            gbConnectionSettings.Name = "gbConnectionSettings";
            gbConnectionSettings.Size = new Size(225, 162);
            gbConnectionSettings.TabIndex = 1;
            gbConnectionSettings.TabStop = false;
            gbConnectionSettings.Text = "连接设置";
            // 
            // RelogDelayTextBox
            // 
            RelogDelayTextBox.Location = new Point(93, 18);
            RelogDelayTextBox.Margin = new Padding(3, 5, 3, 5);
            RelogDelayTextBox.MaxLength = 5;
            RelogDelayTextBox.Name = "RelogDelayTextBox";
            RelogDelayTextBox.Size = new Size(108, 23);
            RelogDelayTextBox.TabIndex = 27;
            RelogDelayTextBox.TextChanged += CheckUShort;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 22);
            label7.Name = "label7";
            label7.Size = new Size(83, 17);
            label7.TabIndex = 26;
            label7.Text = "重新登录延时:";
            // 
            // maxConnectionsPerIP
            // 
            maxConnectionsPerIP.Location = new Point(137, 109);
            maxConnectionsPerIP.Margin = new Padding(3, 5, 3, 5);
            maxConnectionsPerIP.MaxLength = 5;
            maxConnectionsPerIP.Name = "maxConnectionsPerIP";
            maxConnectionsPerIP.Size = new Size(64, 23);
            maxConnectionsPerIP.TabIndex = 25;
            // 
            // lblMaxConnectionsPerIP
            // 
            lblMaxConnectionsPerIP.AutoSize = true;
            lblMaxConnectionsPerIP.Location = new Point(6, 112);
            lblMaxConnectionsPerIP.Name = "lblMaxConnectionsPerIP";
            lblMaxConnectionsPerIP.Size = new Size(87, 17);
            lblMaxConnectionsPerIP.TabIndex = 24;
            lblMaxConnectionsPerIP.Text = "最大连接数/IP:";
            // 
            // MaxUserTextBox
            // 
            MaxUserTextBox.Location = new Point(137, 78);
            MaxUserTextBox.Margin = new Padding(3, 5, 3, 5);
            MaxUserTextBox.MaxLength = 5;
            MaxUserTextBox.Name = "MaxUserTextBox";
            MaxUserTextBox.Size = new Size(64, 23);
            MaxUserTextBox.TabIndex = 17;
            MaxUserTextBox.TextChanged += CheckUShort;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 82);
            label5.Name = "label5";
            label5.Size = new Size(68, 17);
            label5.TabIndex = 16;
            label5.Text = "最大登录数";
            // 
            // TimeOutTextBox
            // 
            TimeOutTextBox.Location = new Point(93, 48);
            TimeOutTextBox.Margin = new Padding(3, 5, 3, 5);
            TimeOutTextBox.MaxLength = 5;
            TimeOutTextBox.Name = "TimeOutTextBox";
            TimeOutTextBox.Size = new Size(108, 23);
            TimeOutTextBox.TabIndex = 15;
            TimeOutTextBox.TextChanged += CheckUShort;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 51);
            label4.Name = "label4";
            label4.Size = new Size(56, 17);
            label4.TabIndex = 14;
            label4.Text = "连接超时";
            // 
            // gbServerConnection
            // 
            gbServerConnection.Controls.Add(IPAddressTextBox);
            gbServerConnection.Controls.Add(label2);
            gbServerConnection.Controls.Add(PortTextBox);
            gbServerConnection.Controls.Add(label3);
            gbServerConnection.Location = new Point(17, 20);
            gbServerConnection.Name = "gbServerConnection";
            gbServerConnection.Size = new Size(196, 85);
            gbServerConnection.TabIndex = 0;
            gbServerConnection.TabStop = false;
            gbServerConnection.Text = "服务器连接";
            // 
            // IPAddressTextBox
            // 
            IPAddressTextBox.Location = new Point(77, 18);
            IPAddressTextBox.Margin = new Padding(3, 5, 3, 5);
            IPAddressTextBox.MaxLength = 15;
            IPAddressTextBox.Name = "IPAddressTextBox";
            IPAddressTextBox.Size = new Size(108, 23);
            IPAddressTextBox.TabIndex = 11;
            IPAddressTextBox.TextChanged += IPAddressCheck;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 22);
            label2.Name = "label2";
            label2.Size = new Size(46, 17);
            label2.TabIndex = 10;
            label2.Text = "IP地址:";
            // 
            // PortTextBox
            // 
            PortTextBox.Location = new Point(77, 48);
            PortTextBox.Margin = new Padding(3, 5, 3, 5);
            PortTextBox.MaxLength = 5;
            PortTextBox.Name = "PortTextBox";
            PortTextBox.Size = new Size(48, 23);
            PortTextBox.TabIndex = 13;
            PortTextBox.TextChanged += CheckUShort;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 51);
            label3.Name = "label3";
            label3.Size = new Size(47, 17);
            label3.TabIndex = 12;
            label3.Text = "端口号:";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(gbGameWorld);
            tabPage3.Controls.Add(gbCharacterScreen);
            tabPage3.Controls.Add(gbLoginScreen);
            tabPage3.Location = new Point(4, 26);
            tabPage3.Margin = new Padding(3, 5, 3, 5);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3, 5, 3, 5);
            tabPage3.Size = new Size(476, 396);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "权限";
            tabPage3.UseVisualStyleBackColor = true;
            tabPage3.Click += tabPage3_Click;
            // 
            // gbGameWorld
            // 
            gbGameWorld.Controls.Add(SafeZoneHealingCheckBox);
            gbGameWorld.Controls.Add(SafeZoneBorderCheckBox);
            gbGameWorld.Controls.Add(ObserveCheckBox);
            gbGameWorld.Controls.Add(WarehousePasswordCheckBox);
            gbGameWorld.Location = new Point(190, 20);
            gbGameWorld.Name = "gbGameWorld";
            gbGameWorld.Size = new Size(272, 335);
            gbGameWorld.TabIndex = 2;
            gbGameWorld.TabStop = false;
            gbGameWorld.Text = "游戏世界";
            // 
            // SafeZoneHealingCheckBox
            // 
            SafeZoneHealingCheckBox.AutoSize = true;
            SafeZoneHealingCheckBox.Location = new Point(24, 59);
            SafeZoneHealingCheckBox.Margin = new Padding(3, 5, 3, 5);
            SafeZoneHealingCheckBox.Name = "SafeZoneHealingCheckBox";
            SafeZoneHealingCheckBox.Size = new Size(135, 21);
            SafeZoneHealingCheckBox.TabIndex = 1;
            SafeZoneHealingCheckBox.Text = "启用安全区恢复功能";
            SafeZoneHealingCheckBox.UseVisualStyleBackColor = true;
            SafeZoneHealingCheckBox.CheckedChanged += SafeZoneHealingCheckBox_CheckedChanged;
            // 
            // SafeZoneBorderCheckBox
            // 
            SafeZoneBorderCheckBox.AutoSize = true;
            SafeZoneBorderCheckBox.Location = new Point(24, 28);
            SafeZoneBorderCheckBox.Margin = new Padding(3, 5, 3, 5);
            SafeZoneBorderCheckBox.Name = "SafeZoneBorderCheckBox";
            SafeZoneBorderCheckBox.Size = new Size(111, 21);
            SafeZoneBorderCheckBox.TabIndex = 0;
            SafeZoneBorderCheckBox.Text = "启用安全区边框";
            SafeZoneBorderCheckBox.UseVisualStyleBackColor = true;
            SafeZoneBorderCheckBox.CheckedChanged += SafeZoneBorderCheckBox_CheckedChanged;
            // 
            // ObserveCheckBox
            // 
            ObserveCheckBox.AutoSize = true;
            ObserveCheckBox.Location = new Point(24, 89);
            ObserveCheckBox.Margin = new Padding(3, 5, 3, 5);
            ObserveCheckBox.Name = "ObserveCheckBox";
            ObserveCheckBox.Size = new Size(75, 21);
            ObserveCheckBox.TabIndex = 30;
            ObserveCheckBox.Text = "观察模式";
            ObserveCheckBox.UseVisualStyleBackColor = true;
            // 
            // WarehousePasswordCheckBox
            // 
            WarehousePasswordCheckBox.AutoSize = true;
            WarehousePasswordCheckBox.Location = new Point(6, 104);
            WarehousePasswordCheckBox.Margin = new Padding(3, 4, 3, 4);
            WarehousePasswordCheckBox.Name = "WarehousePasswordCheckBox";
            WarehousePasswordCheckBox.Size = new Size(187, 19);
            WarehousePasswordCheckBox.TabIndex = 31;
            WarehousePasswordCheckBox.Text = "Warehouse Password";
            WarehousePasswordCheckBox.UseVisualStyleBackColor = true;
            // 
            // gbCharacterScreen
            // 
            gbCharacterScreen.Controls.Add(StartGameCheckBox);
            gbCharacterScreen.Controls.Add(NCharacterCheckBox);
            gbCharacterScreen.Controls.Add(DCharacterCheckBox);
            gbCharacterScreen.Controls.Add(AllowAssassinCheckBox);
            gbCharacterScreen.Controls.Add(AllowArcherCheckBox);
            gbCharacterScreen.Location = new Point(17, 175);
            gbCharacterScreen.Name = "gbCharacterScreen";
            gbCharacterScreen.Size = new Size(157, 184);
            gbCharacterScreen.TabIndex = 1;
            gbCharacterScreen.TabStop = false;
            gbCharacterScreen.Text = "角色管理";
            // 
            // StartGameCheckBox
            // 
            StartGameCheckBox.AutoSize = true;
            StartGameCheckBox.Location = new Point(17, 147);
            StartGameCheckBox.Margin = new Padding(3, 5, 3, 5);
            StartGameCheckBox.Name = "StartGameCheckBox";
            StartGameCheckBox.Size = new Size(123, 21);
            StartGameCheckBox.TabIndex = 11;
            StartGameCheckBox.Text = "允许角色登录游戏";
            StartGameCheckBox.UseVisualStyleBackColor = true;
            // 
            // NCharacterCheckBox
            // 
            NCharacterCheckBox.AutoSize = true;
            NCharacterCheckBox.Location = new Point(17, 27);
            NCharacterCheckBox.Margin = new Padding(3, 5, 3, 5);
            NCharacterCheckBox.Name = "NCharacterCheckBox";
            NCharacterCheckBox.Size = new Size(99, 21);
            NCharacterCheckBox.TabIndex = 9;
            NCharacterCheckBox.Text = "允许新建角色";
            NCharacterCheckBox.UseVisualStyleBackColor = true;
            // 
            // DCharacterCheckBox
            // 
            DCharacterCheckBox.AutoSize = true;
            DCharacterCheckBox.Location = new Point(17, 57);
            DCharacterCheckBox.Margin = new Padding(3, 5, 3, 5);
            DCharacterCheckBox.Name = "DCharacterCheckBox";
            DCharacterCheckBox.Size = new Size(99, 21);
            DCharacterCheckBox.TabIndex = 10;
            DCharacterCheckBox.Text = "允许删除角色";
            DCharacterCheckBox.UseVisualStyleBackColor = true;
            // 
            // AllowAssassinCheckBox
            // 
            AllowAssassinCheckBox.AutoSize = true;
            AllowAssassinCheckBox.Location = new Point(17, 87);
            AllowAssassinCheckBox.Margin = new Padding(3, 5, 3, 5);
            AllowAssassinCheckBox.Name = "AllowAssassinCheckBox";
            AllowAssassinCheckBox.Size = new Size(123, 21);
            AllowAssassinCheckBox.TabIndex = 12;
            AllowAssassinCheckBox.Text = "允许创建刺客职业";
            AllowAssassinCheckBox.UseVisualStyleBackColor = true;
            // 
            // AllowArcherCheckBox
            // 
            AllowArcherCheckBox.AutoSize = true;
            AllowArcherCheckBox.Location = new Point(17, 117);
            AllowArcherCheckBox.Margin = new Padding(3, 5, 3, 5);
            AllowArcherCheckBox.Name = "AllowArcherCheckBox";
            AllowArcherCheckBox.Size = new Size(123, 21);
            AllowArcherCheckBox.TabIndex = 13;
            AllowArcherCheckBox.Text = "允许创建弓箭职业";
            AllowArcherCheckBox.UseVisualStyleBackColor = true;
            // 
            // gbLoginScreen
            // 
            gbLoginScreen.Controls.Add(AccountCheckBox);
            gbLoginScreen.Controls.Add(PasswordCheckBox);
            gbLoginScreen.Controls.Add(LoginCheckBox);
            gbLoginScreen.Location = new Point(17, 20);
            gbLoginScreen.Name = "gbLoginScreen";
            gbLoginScreen.Size = new Size(157, 147);
            gbLoginScreen.TabIndex = 0;
            gbLoginScreen.TabStop = false;
            gbLoginScreen.Text = "登录管理";
            // 
            // AccountCheckBox
            // 
            AccountCheckBox.AutoSize = true;
            AccountCheckBox.Location = new Point(19, 26);
            AccountCheckBox.Margin = new Padding(3, 5, 3, 5);
            AccountCheckBox.Name = "AccountCheckBox";
            AccountCheckBox.Size = new Size(111, 21);
            AccountCheckBox.TabIndex = 6;
            AccountCheckBox.Text = "允许创建新账户";
            AccountCheckBox.UseVisualStyleBackColor = true;
            // 
            // PasswordCheckBox
            // 
            PasswordCheckBox.AutoSize = true;
            PasswordCheckBox.Location = new Point(19, 56);
            PasswordCheckBox.Margin = new Padding(3, 5, 3, 5);
            PasswordCheckBox.Name = "PasswordCheckBox";
            PasswordCheckBox.Size = new Size(123, 21);
            PasswordCheckBox.TabIndex = 7;
            PasswordCheckBox.Text = "允许账户更改密码";
            PasswordCheckBox.UseVisualStyleBackColor = true;
            // 
            // LoginCheckBox
            // 
            LoginCheckBox.AutoSize = true;
            LoginCheckBox.Location = new Point(19, 86);
            LoginCheckBox.Margin = new Padding(3, 5, 3, 5);
            LoginCheckBox.Name = "LoginCheckBox";
            LoginCheckBox.Size = new Size(99, 21);
            LoginCheckBox.TabIndex = 8;
            LoginCheckBox.Text = "允许账户登录";
            LoginCheckBox.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            tabPage6.Controls.Add(gbRestedExpRates);
            tabPage6.Controls.Add(gbGlobals);
            tabPage6.Location = new Point(4, 26);
            tabPage6.Name = "tabPage6";
            tabPage6.Padding = new Padding(3);
            tabPage6.Size = new Size(476, 396);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "增益比率";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // gbRestedExpRates
            // 
            gbRestedExpRates.Controls.Add(label22);
            gbRestedExpRates.Controls.Add(label23);
            gbRestedExpRates.Controls.Add(label21);
            gbRestedExpRates.Controls.Add(label20);
            gbRestedExpRates.Controls.Add(tbRestedPeriod);
            gbRestedExpRates.Controls.Add(tbRestedBuffLength);
            gbRestedExpRates.Controls.Add(tbMaxRestedBonus);
            gbRestedExpRates.Controls.Add(tbRestedExpBonus);
            gbRestedExpRates.Controls.Add(lblMaxRestedBonus);
            gbRestedExpRates.Controls.Add(lblRestedExpBonus);
            gbRestedExpRates.Controls.Add(lblRestedBuffLength);
            gbRestedExpRates.Controls.Add(lblPeriod);
            gbRestedExpRates.Location = new Point(17, 151);
            gbRestedExpRates.Name = "gbRestedExpRates";
            gbRestedExpRates.Size = new Size(228, 170);
            gbRestedExpRates.TabIndex = 8;
            gbRestedExpRates.TabStop = false;
            gbRestedExpRates.Text = "休息经验";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(158, 99);
            label22.Name = "label22";
            label22.Size = new Size(19, 17);
            label22.TabIndex = 12;
            label22.Text = "%";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(158, 135);
            label23.Name = "label23";
            label23.Size = new Size(14, 17);
            label23.TabIndex = 12;
            label23.Text = "倍";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(158, 63);
            label21.Name = "label21";
            label21.Size = new Size(32, 17);
            label21.TabIndex = 12;
            label21.Text = "分钟";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(158, 27);
            label20.Name = "label20";
            label20.Size = new Size(32, 17);
            label20.TabIndex = 12;
            label20.Text = "分钟";
            // 
            // tbRestedPeriod
            // 
            tbRestedPeriod.Location = new Point(96, 24);
            tbRestedPeriod.Name = "tbRestedPeriod";
            tbRestedPeriod.Size = new Size(56, 23);
            tbRestedPeriod.TabIndex = 11;
            tbRestedPeriod.KeyPress += tbRestedPeriod_KeyPress;
            // 
            // tbRestedBuffLength
            // 
            tbRestedBuffLength.Location = new Point(96, 60);
            tbRestedBuffLength.Name = "tbRestedBuffLength";
            tbRestedBuffLength.Size = new Size(56, 23);
            tbRestedBuffLength.TabIndex = 11;
            tbRestedBuffLength.KeyPress += tbRestedBuffLength_KeyPress;
            // 
            // tbMaxRestedBonus
            // 
            tbMaxRestedBonus.Location = new Point(96, 132);
            tbMaxRestedBonus.Name = "tbMaxRestedBonus";
            tbMaxRestedBonus.Size = new Size(56, 23);
            tbMaxRestedBonus.TabIndex = 11;
            tbMaxRestedBonus.KeyPress += tbMaxRestedBonus_KeyPress;
            // 
            // tbRestedExpBonus
            // 
            tbRestedExpBonus.Location = new Point(96, 96);
            tbRestedExpBonus.Name = "tbRestedExpBonus";
            tbRestedExpBonus.Size = new Size(56, 23);
            tbRestedExpBonus.TabIndex = 11;
            tbRestedExpBonus.KeyPress += tbRestedExpBonus_KeyPress;
            // 
            // lblMaxRestedBonus
            // 
            lblMaxRestedBonus.AutoSize = true;
            lblMaxRestedBonus.Location = new Point(13, 135);
            lblMaxRestedBonus.Name = "lblMaxRestedBonus";
            lblMaxRestedBonus.Size = new Size(59, 17);
            lblMaxRestedBonus.TabIndex = 0;
            lblMaxRestedBonus.Text = "最大奖励:";
            // 
            // lblRestedExpBonus
            // 
            lblRestedExpBonus.AutoSize = true;
            lblRestedExpBonus.Location = new Point(13, 99);
            lblRestedExpBonus.Name = "lblRestedExpBonus";
            lblRestedExpBonus.Size = new Size(59, 17);
            lblRestedExpBonus.TabIndex = 0;
            lblRestedExpBonus.Text = "经验奖励:";
            // 
            // lblRestedBuffLength
            // 
            lblRestedBuffLength.AutoSize = true;
            lblRestedBuffLength.Location = new Point(13, 63);
            lblRestedBuffLength.Name = "lblRestedBuffLength";
            lblRestedBuffLength.Size = new Size(59, 17);
            lblRestedBuffLength.TabIndex = 0;
            lblRestedBuffLength.Text = "增益时间:";
            // 
            // lblPeriod
            // 
            lblPeriod.AutoSize = true;
            lblPeriod.Location = new Point(13, 27);
            lblPeriod.Name = "lblPeriod";
            lblPeriod.Size = new Size(35, 17);
            lblPeriod.TabIndex = 0;
            lblPeriod.Text = "周期:";
            // 
            // gbGlobals
            // 
            gbGlobals.Controls.Add(label19);
            gbGlobals.Controls.Add(label18);
            gbGlobals.Controls.Add(dropRateInput);
            gbGlobals.Controls.Add(lblDropRate);
            gbGlobals.Controls.Add(expRateInput);
            gbGlobals.Controls.Add(lblExpRate);
            gbGlobals.Location = new Point(17, 20);
            gbGlobals.Name = "gbGlobals";
            gbGlobals.Size = new Size(228, 113);
            gbGlobals.TabIndex = 7;
            gbGlobals.TabStop = false;
            gbGlobals.Text = "全局";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(139, 72);
            label19.Name = "label19";
            label19.Size = new Size(14, 17);
            label19.TabIndex = 11;
            label19.Text = "倍";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(139, 32);
            label18.Name = "label18";
            label18.Size = new Size(14, 17);
            label18.TabIndex = 12;
            label18.Text = "倍";
            // 
            // dropRateInput
            // 
            dropRateInput.DecimalPlaces = 2;
            dropRateInput.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            dropRateInput.Location = new Point(82, 69);
            dropRateInput.Name = "dropRateInput";
            dropRateInput.Size = new Size(51, 23);
            dropRateInput.TabIndex = 9;
            // 
            // lblDropRate
            // 
            lblDropRate.AutoSize = true;
            lblDropRate.Location = new Point(13, 72);
            lblDropRate.Name = "lblDropRate";
            lblDropRate.Size = new Size(59, 17);
            lblDropRate.TabIndex = 7;
            lblDropRate.Text = "掉落比率:";
            // 
            // expRateInput
            // 
            expRateInput.DecimalPlaces = 2;
            expRateInput.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            expRateInput.Location = new Point(82, 29);
            expRateInput.Name = "expRateInput";
            expRateInput.Size = new Size(51, 23);
            expRateInput.TabIndex = 10;
            // 
            // lblExpRate
            // 
            lblExpRate.AutoSize = true;
            lblExpRate.Location = new Point(13, 32);
            lblExpRate.Name = "lblExpRate";
            lblExpRate.Size = new Size(59, 17);
            lblExpRate.TabIndex = 8;
            lblExpRate.Text = "经验比率:";
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(groupBox2);
            tabPage5.Controls.Add(Resolution_textbox);
            tabPage5.Controls.Add(label9);
            tabPage5.Controls.Add(label16);
            tabPage5.Controls.Add(lineMessageTimeTextBox);
            tabPage5.Controls.Add(label17);
            tabPage5.Controls.Add(gameMasterEffect_CheckBox);
            tabPage5.Location = new Point(4, 26);
            tabPage5.Margin = new Padding(3, 5, 3, 5);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3, 5, 3, 5);
            tabPage5.Size = new Size(476, 396);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "游戏特性";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ReaddArcDrops);
            groupBox2.Controls.Add(ReaddSinDrops);
            groupBox2.Controls.Add(RemoveArcDrops);
            groupBox2.Controls.Add(RemoveSinDrops);
            groupBox2.Location = new Point(19, 216);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(160, 161);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "掉落管理设置";
            // 
            // ReaddArcDrops
            // 
            ReaddArcDrops.Location = new Point(8, 124);
            ReaddArcDrops.Name = "ReaddArcDrops";
            ReaddArcDrops.Size = new Size(144, 26);
            ReaddArcDrops.TabIndex = 3;
            ReaddArcDrops.Text = "重加弓箭手掉落";
            ReaddArcDrops.UseVisualStyleBackColor = true;
            ReaddArcDrops.Click += ReaddArcDrops_Click;
            // 
            // ReaddSinDrops
            // 
            ReaddSinDrops.Location = new Point(8, 58);
            ReaddSinDrops.Name = "ReaddSinDrops";
            ReaddSinDrops.Size = new Size(144, 26);
            ReaddSinDrops.TabIndex = 2;
            ReaddSinDrops.Text = "重加刺客掉落";
            ReaddSinDrops.UseVisualStyleBackColor = true;
            ReaddSinDrops.Click += ReaddSinDrops_Click;
            // 
            // RemoveArcDrops
            // 
            RemoveArcDrops.Location = new Point(8, 91);
            RemoveArcDrops.Name = "RemoveArcDrops";
            RemoveArcDrops.Size = new Size(144, 26);
            RemoveArcDrops.TabIndex = 1;
            RemoveArcDrops.Text = "删除弓箭手掉落";
            RemoveArcDrops.UseVisualStyleBackColor = true;
            RemoveArcDrops.Click += RemoveArcDrops_Click;
            // 
            // RemoveSinDrops
            // 
            RemoveSinDrops.Location = new Point(8, 25);
            RemoveSinDrops.Name = "RemoveSinDrops";
            RemoveSinDrops.Size = new Size(144, 26);
            RemoveSinDrops.TabIndex = 0;
            RemoveSinDrops.Text = "删除刺客掉落";
            RemoveSinDrops.UseVisualStyleBackColor = true;
            RemoveSinDrops.Click += RemoveSinDrops_Click;
            // 
            // Resolution_textbox
            // 
            Resolution_textbox.Location = new Point(170, 102);
            Resolution_textbox.Margin = new Padding(3, 5, 3, 5);
            Resolution_textbox.Name = "Resolution_textbox";
            Resolution_textbox.Size = new Size(93, 23);
            Resolution_textbox.TabIndex = 32;
            Resolution_textbox.TextChanged += Resolution_textbox_TextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(22, 105);
            label9.Name = "label9";
            label9.Size = new Size(92, 17);
            label9.TabIndex = 31;
            label9.Text = "允许最大分辨率 :";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(217, 70);
            label16.Name = "label16";
            label16.Size = new Size(32, 17);
            label16.TabIndex = 29;
            label16.Text = "分钟";
            // 
            // lineMessageTimeTextBox
            // 
            lineMessageTimeTextBox.Location = new Point(170, 67);
            lineMessageTimeTextBox.Margin = new Padding(3, 5, 3, 5);
            lineMessageTimeTextBox.MaxLength = 5;
            lineMessageTimeTextBox.Name = "lineMessageTimeTextBox";
            lineMessageTimeTextBox.Size = new Size(41, 23);
            lineMessageTimeTextBox.TabIndex = 28;
            lineMessageTimeTextBox.Text = "10";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(22, 70);
            label17.Name = "label17";
            label17.Size = new Size(111, 17);
            label17.TabIndex = 27;
            label17.Text = "在线信息显示频率 :";
            // 
            // gameMasterEffect_CheckBox
            // 
            gameMasterEffect_CheckBox.AutoSize = true;
            gameMasterEffect_CheckBox.Location = new Point(22, 28);
            gameMasterEffect_CheckBox.Margin = new Padding(3, 5, 3, 5);
            gameMasterEffect_CheckBox.Name = "gameMasterEffect_CheckBox";
            gameMasterEffect_CheckBox.Size = new Size(99, 21);
            gameMasterEffect_CheckBox.TabIndex = 2;
            gameMasterEffect_CheckBox.Text = "游戏特效显示";
            gameMasterEffect_CheckBox.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.Location = new Point(0, 0);
            label8.Name = "label8";
            label8.Size = new Size(100, 23);
            label8.TabIndex = 0;
            // 
            // VPathDialog
            // 
            VPathDialog.FileName = "Mir2.Exe";
            VPathDialog.Filter = "Executable Files (*.exe)|*.exe";
            VPathDialog.Multiselect = true;
            // 
            // ConfigForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 487);
            Controls.Add(SaveButton);
            Controls.Add(configTabs);
            Margin = new Padding(3, 5, 3, 5);
            Name = "ConfigForm";
            Text = "服务器设置";
            FormClosed += ConfigForm_FormClosed;
            configTabs.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage2.ResumeLayout(false);
            gbServerSettings.ResumeLayout(false);
            gbServerSettings.PerformLayout();
            gbHTTPService.ResumeLayout(false);
            gbHTTPService.PerformLayout();
            gbConnectionSettings.ResumeLayout(false);
            gbConnectionSettings.PerformLayout();
            gbServerConnection.ResumeLayout(false);
            gbServerConnection.PerformLayout();
            tabPage3.ResumeLayout(false);
            gbGameWorld.ResumeLayout(false);
            gbGameWorld.PerformLayout();
            gbCharacterScreen.ResumeLayout(false);
            gbCharacterScreen.PerformLayout();
            gbLoginScreen.ResumeLayout(false);
            gbLoginScreen.PerformLayout();
            tabPage6.ResumeLayout(false);
            gbRestedExpRates.ResumeLayout(false);
            gbRestedExpRates.PerformLayout();
            gbGlobals.ResumeLayout(false);
            gbGlobals.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dropRateInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)expRateInput).EndInit();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TabControl configTabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox RelogDelayTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox VersionCheckBox;
        private System.Windows.Forms.Button VPathBrowseButton;
        private System.Windows.Forms.TextBox VPathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox MaxUserTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TimeOutTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox IPAddressTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog VPathDialog;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox StartGameCheckBox;
        private System.Windows.Forms.CheckBox DCharacterCheckBox;
        private System.Windows.Forms.CheckBox NCharacterCheckBox;
        private System.Windows.Forms.CheckBox LoginCheckBox;
        private System.Windows.Forms.CheckBox PasswordCheckBox;
        private System.Windows.Forms.CheckBox AccountCheckBox;
        private System.Windows.Forms.TextBox SaveDelayTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.CheckBox SafeZoneBorderCheckBox;
        private System.Windows.Forms.CheckBox SafeZoneHealingCheckBox;
        private System.Windows.Forms.CheckBox AllowArcherCheckBox;
        private System.Windows.Forms.CheckBox AllowAssassinCheckBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Resolution_textbox;
        private System.Windows.Forms.Label ServerVersionLabel;
        private System.Windows.Forms.Label DBVersionLabel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox gameMasterEffect_CheckBox;
        private System.Windows.Forms.TextBox HTTPIPAddressTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox HTTPTrustedIPAddressTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox StartHTTPCheckBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox lineMessageTimeTextBox;
        private System.Windows.Forms.Label label17;
        private TextBox maxConnectionsPerIP;
        private Label lblMaxConnectionsPerIP;
        private TabPage tabPage6;
        private GroupBox gbRestedExpRates;
        private GroupBox gbGlobals;
        private Label label19;
        private Label label18;
        private NumericUpDown dropRateInput;
        private Label lblDropRate;
        private NumericUpDown expRateInput;
        private Label lblExpRate;
        private Label lblMaxRestedBonus;
        private Label lblRestedExpBonus;
        private Label lblRestedBuffLength;
        private Label lblPeriod;
        private TextBox tbRestedBuffLength;
        private TextBox tbMaxRestedBonus;
        private TextBox tbRestedExpBonus;
        private TextBox tbRestedPeriod;
        private Label label22;
        private Label label23;
        private Label label21;
        private Label label20;
        private GroupBox groupBox2;
        private Button ReaddArcDrops;
        private Button ReaddSinDrops;
        private Button RemoveArcDrops;
        private Button RemoveSinDrops;
        private CheckBox ObserveCheckBox;
        private CheckBox WarehousePasswordCheckBox;
        private GroupBox gbHTTPService;
        private GroupBox gbConnectionSettings;
        private GroupBox gbServerConnection;
        private GroupBox gbServerSettings;
        private GroupBox gbLoginScreen;
        private GroupBox gbCharacterScreen;
        private GroupBox gbGameWorld;
    }
}