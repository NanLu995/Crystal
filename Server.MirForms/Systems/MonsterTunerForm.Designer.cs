namespace Server.MirForms.Systems
{
    partial class MonsterTunerForm
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
            SelectMonsterComboBox = new ComboBox();
            updateButton = new Button();
            CoolEyeTextBox = new TextBox();
            label12 = new Label();
            ViewRangeTextBox = new TextBox();
            label33 = new Label();
            MSpeedTextBox = new TextBox();
            label6 = new Label();
            ASpeedTextBox = new TextBox();
            label5 = new Label();
            LevelTextBox = new TextBox();
            label4 = new Label();
            EffectTextBox = new TextBox();
            label2 = new Label();
            AgilityTextBox = new TextBox();
            label26 = new Label();
            AccuracyTextBox = new TextBox();
            label27 = new Label();
            HPTextBox = new TextBox();
            label25 = new Label();
            MaxSCTextBox = new TextBox();
            label22 = new Label();
            MinSCTextBox = new TextBox();
            label23 = new Label();
            MaxMCTextBox = new TextBox();
            label18 = new Label();
            MinMCTextBox = new TextBox();
            label19 = new Label();
            MaxDCTextBox = new TextBox();
            label20 = new Label();
            MinDCTextBox = new TextBox();
            label21 = new Label();
            MaxMACTextBox = new TextBox();
            label16 = new Label();
            MinMACTextBox = new TextBox();
            label17 = new Label();
            MaxACTextBox = new TextBox();
            label15 = new Label();
            MinACTextBox = new TextBox();
            label14 = new Label();
            MonsterNameTextBox = new TextBox();
            label3 = new Label();
            SaveButton = new Button();
            SuspendLayout();
            // 
            // SelectMonsterComboBox
            // 
            SelectMonsterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            SelectMonsterComboBox.FormattingEnabled = true;
            SelectMonsterComboBox.Location = new Point(13, 9);
            SelectMonsterComboBox.Margin = new Padding(4);
            SelectMonsterComboBox.Name = "SelectMonsterComboBox";
            SelectMonsterComboBox.Size = new Size(228, 25);
            SelectMonsterComboBox.TabIndex = 0;
            SelectMonsterComboBox.SelectedIndexChanged += SelectMonsterComboBox_SelectedIndexChanged;
            // 
            // updateButton
            // 
            updateButton.Location = new Point(19, 283);
            updateButton.Margin = new Padding(4);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(88, 30);
            updateButton.TabIndex = 59;
            updateButton.Text = "更新";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += updateButton_Click;
            // 
            // CoolEyeTextBox
            // 
            CoolEyeTextBox.Location = new Point(646, 75);
            CoolEyeTextBox.Margin = new Padding(4);
            CoolEyeTextBox.MaxLength = 3;
            CoolEyeTextBox.Name = "CoolEyeTextBox";
            CoolEyeTextBox.Size = new Size(34, 23);
            CoolEyeTextBox.TabIndex = 123;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(587, 78);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(56, 17);
            label12.TabIndex = 124;
            label12.Text = "是否反隐";
            // 
            // ViewRangeTextBox
            // 
            ViewRangeTextBox.Location = new Point(518, 75);
            ViewRangeTextBox.Margin = new Padding(4);
            ViewRangeTextBox.MaxLength = 3;
            ViewRangeTextBox.Name = "ViewRangeTextBox";
            ViewRangeTextBox.Size = new Size(34, 23);
            ViewRangeTextBox.TabIndex = 121;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new Point(459, 78);
            label33.Margin = new Padding(4, 0, 4, 0);
            label33.Name = "label33";
            label33.Size = new Size(56, 17);
            label33.TabIndex = 122;
            label33.Text = "视觉范围";
            // 
            // MSpeedTextBox
            // 
            MSpeedTextBox.Location = new Point(254, 244);
            MSpeedTextBox.Margin = new Padding(4);
            MSpeedTextBox.MaxLength = 5;
            MSpeedTextBox.Name = "MSpeedTextBox";
            MSpeedTextBox.Size = new Size(34, 23);
            MSpeedTextBox.TabIndex = 104;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(195, 247);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(56, 17);
            label6.TabIndex = 120;
            label6.Text = "移动速度";
            // 
            // ASpeedTextBox
            // 
            ASpeedTextBox.Location = new Point(108, 244);
            ASpeedTextBox.Margin = new Padding(4);
            ASpeedTextBox.MaxLength = 5;
            ASpeedTextBox.Name = "ASpeedTextBox";
            ASpeedTextBox.Size = new Size(34, 23);
            ASpeedTextBox.TabIndex = 103;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(49, 247);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(56, 17);
            label5.TabIndex = 119;
            label5.Text = "攻击速度";
            // 
            // LevelTextBox
            // 
            LevelTextBox.Location = new Point(387, 74);
            LevelTextBox.Margin = new Padding(4);
            LevelTextBox.MaxLength = 3;
            LevelTextBox.Name = "LevelTextBox";
            LevelTextBox.Size = new Size(34, 23);
            LevelTextBox.TabIndex = 87;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(328, 78);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(56, 17);
            label4.TabIndex = 118;
            label4.Text = "怪物等级";
            // 
            // EffectTextBox
            // 
            EffectTextBox.Location = new Point(254, 74);
            EffectTextBox.Margin = new Padding(4);
            EffectTextBox.MaxLength = 3;
            EffectTextBox.Name = "EffectTextBox";
            EffectTextBox.Size = new Size(34, 23);
            EffectTextBox.TabIndex = 86;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(193, 77);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(57, 17);
            label2.TabIndex = 117;
            label2.Text = "Lib(宠物)";
            // 
            // AgilityTextBox
            // 
            AgilityTextBox.Location = new Point(254, 211);
            AgilityTextBox.Margin = new Padding(4);
            AgilityTextBox.MaxLength = 3;
            AgilityTextBox.Name = "AgilityTextBox";
            AgilityTextBox.Size = new Size(34, 23);
            AgilityTextBox.TabIndex = 102;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(207, 214);
            label26.Margin = new Padding(4, 0, 4, 0);
            label26.Name = "label26";
            label26.Size = new Size(44, 17);
            label26.TabIndex = 116;
            label26.Text = "敏捷度";
            // 
            // AccuracyTextBox
            // 
            AccuracyTextBox.Location = new Point(108, 210);
            AccuracyTextBox.Margin = new Padding(4);
            AccuracyTextBox.MaxLength = 3;
            AccuracyTextBox.Name = "AccuracyTextBox";
            AccuracyTextBox.Size = new Size(34, 23);
            AccuracyTextBox.TabIndex = 101;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(61, 213);
            label27.Margin = new Padding(4, 0, 4, 0);
            label27.Name = "label27";
            label27.Size = new Size(44, 17);
            label27.TabIndex = 115;
            label27.Text = "准确度";
            // 
            // HPTextBox
            // 
            HPTextBox.Location = new Point(108, 108);
            HPTextBox.Margin = new Padding(4);
            HPTextBox.MaxLength = 10;
            HPTextBox.Name = "HPTextBox";
            HPTextBox.Size = new Size(83, 23);
            HPTextBox.TabIndex = 88;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(37, 111);
            label25.Margin = new Padding(4, 0, 4, 0);
            label25.Name = "label25";
            label25.Size = new Size(68, 17);
            label25.TabIndex = 114;
            label25.Text = "怪物生命值";
            // 
            // MaxSCTextBox
            // 
            MaxSCTextBox.Location = new Point(646, 176);
            MaxSCTextBox.Margin = new Padding(4);
            MaxSCTextBox.MaxLength = 3;
            MaxSCTextBox.Name = "MaxSCTextBox";
            MaxSCTextBox.Size = new Size(34, 23);
            MaxSCTextBox.TabIndex = 100;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(563, 179);
            label22.Margin = new Padding(4, 0, 4, 0);
            label22.Name = "label22";
            label22.Size = new Size(80, 17);
            label22.TabIndex = 113;
            label22.Text = "最大道术攻击";
            // 
            // MinSCTextBox
            // 
            MinSCTextBox.Location = new Point(646, 143);
            MinSCTextBox.Margin = new Padding(4);
            MinSCTextBox.MaxLength = 3;
            MinSCTextBox.Name = "MinSCTextBox";
            MinSCTextBox.Size = new Size(34, 23);
            MinSCTextBox.TabIndex = 99;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(564, 146);
            label23.Margin = new Padding(4, 0, 4, 0);
            label23.Name = "label23";
            label23.Size = new Size(80, 17);
            label23.TabIndex = 112;
            label23.Text = "最小道术攻击";
            // 
            // MaxMCTextBox
            // 
            MaxMCTextBox.Location = new Point(518, 177);
            MaxMCTextBox.Margin = new Padding(4);
            MaxMCTextBox.MaxLength = 3;
            MaxMCTextBox.Name = "MaxMCTextBox";
            MaxMCTextBox.Size = new Size(34, 23);
            MaxMCTextBox.TabIndex = 98;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(435, 180);
            label18.Margin = new Padding(4, 0, 4, 0);
            label18.Name = "label18";
            label18.Size = new Size(80, 17);
            label18.TabIndex = 111;
            label18.Text = "最大魔法攻击";
            // 
            // MinMCTextBox
            // 
            MinMCTextBox.Location = new Point(518, 142);
            MinMCTextBox.Margin = new Padding(4);
            MinMCTextBox.MaxLength = 3;
            MinMCTextBox.Name = "MinMCTextBox";
            MinMCTextBox.Size = new Size(34, 23);
            MinMCTextBox.TabIndex = 97;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(304, 180);
            label19.Margin = new Padding(4, 0, 4, 0);
            label19.Name = "label19";
            label19.Size = new Size(80, 17);
            label19.TabIndex = 110;
            label19.Text = "最大物理攻击";
            // 
            // MaxDCTextBox
            // 
            MaxDCTextBox.Location = new Point(387, 177);
            MaxDCTextBox.Margin = new Padding(4);
            MaxDCTextBox.MaxLength = 3;
            MaxDCTextBox.Name = "MaxDCTextBox";
            MaxDCTextBox.Size = new Size(34, 23);
            MaxDCTextBox.TabIndex = 95;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(171, 179);
            label20.Margin = new Padding(4, 0, 4, 0);
            label20.Name = "label20";
            label20.Size = new Size(80, 17);
            label20.TabIndex = 109;
            label20.Text = "最大魔法防御";
            // 
            // MinDCTextBox
            // 
            MinDCTextBox.Location = new Point(387, 142);
            MinDCTextBox.Margin = new Padding(4);
            MinDCTextBox.MaxLength = 3;
            MinDCTextBox.Name = "MinDCTextBox";
            MinDCTextBox.Size = new Size(34, 23);
            MinDCTextBox.TabIndex = 94;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(25, 179);
            label21.Margin = new Padding(4, 0, 4, 0);
            label21.Name = "label21";
            label21.Size = new Size(80, 17);
            label21.TabIndex = 108;
            label21.Text = "最大物理防御";
            // 
            // MaxMACTextBox
            // 
            MaxMACTextBox.Location = new Point(254, 176);
            MaxMACTextBox.Margin = new Padding(4);
            MaxMACTextBox.MaxLength = 3;
            MaxMACTextBox.Name = "MaxMACTextBox";
            MaxMACTextBox.Size = new Size(34, 23);
            MaxMACTextBox.TabIndex = 93;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(435, 145);
            label16.Margin = new Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new Size(80, 17);
            label16.TabIndex = 107;
            label16.Text = "最小魔法攻击";
            // 
            // MinMACTextBox
            // 
            MinMACTextBox.Location = new Point(254, 143);
            MinMACTextBox.Margin = new Padding(4);
            MinMACTextBox.MaxLength = 3;
            MinMACTextBox.Name = "MinMACTextBox";
            MinMACTextBox.Size = new Size(34, 23);
            MinMACTextBox.TabIndex = 92;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(304, 145);
            label17.Margin = new Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new Size(80, 17);
            label17.TabIndex = 96;
            label17.Text = "最小物理攻击";
            // 
            // MaxACTextBox
            // 
            MaxACTextBox.Location = new Point(108, 176);
            MaxACTextBox.Margin = new Padding(4);
            MaxACTextBox.MaxLength = 3;
            MaxACTextBox.Name = "MaxACTextBox";
            MaxACTextBox.Size = new Size(34, 23);
            MaxACTextBox.TabIndex = 91;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(171, 146);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(80, 17);
            label15.TabIndex = 106;
            label15.Text = "最小魔法防御";
            // 
            // MinACTextBox
            // 
            MinACTextBox.Location = new Point(108, 143);
            MinACTextBox.Margin = new Padding(4);
            MinACTextBox.MaxLength = 3;
            MinACTextBox.Name = "MinACTextBox";
            MinACTextBox.Size = new Size(34, 23);
            MinACTextBox.TabIndex = 90;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(25, 146);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(80, 17);
            label14.TabIndex = 105;
            label14.Text = "最小物理防御";
            // 
            // MonsterNameTextBox
            // 
            MonsterNameTextBox.Location = new Point(108, 44);
            MonsterNameTextBox.Margin = new Padding(4);
            MonsterNameTextBox.Name = "MonsterNameTextBox";
            MonsterNameTextBox.Size = new Size(134, 23);
            MonsterNameTextBox.TabIndex = 85;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(49, 47);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(56, 17);
            label3.TabIndex = 89;
            label3.Text = "怪物名称";
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(113, 283);
            SaveButton.Margin = new Padding(4);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(88, 30);
            SaveButton.TabIndex = 125;
            SaveButton.Text = "保存DB";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // MonsterTunerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(690, 322);
            Controls.Add(SaveButton);
            Controls.Add(CoolEyeTextBox);
            Controls.Add(label12);
            Controls.Add(ViewRangeTextBox);
            Controls.Add(label33);
            Controls.Add(MSpeedTextBox);
            Controls.Add(label6);
            Controls.Add(ASpeedTextBox);
            Controls.Add(label5);
            Controls.Add(LevelTextBox);
            Controls.Add(label4);
            Controls.Add(EffectTextBox);
            Controls.Add(label2);
            Controls.Add(AgilityTextBox);
            Controls.Add(label26);
            Controls.Add(AccuracyTextBox);
            Controls.Add(label27);
            Controls.Add(HPTextBox);
            Controls.Add(label25);
            Controls.Add(MaxSCTextBox);
            Controls.Add(label22);
            Controls.Add(MinSCTextBox);
            Controls.Add(label23);
            Controls.Add(MaxMCTextBox);
            Controls.Add(label18);
            Controls.Add(MinMCTextBox);
            Controls.Add(label19);
            Controls.Add(MaxDCTextBox);
            Controls.Add(label20);
            Controls.Add(MinDCTextBox);
            Controls.Add(label21);
            Controls.Add(MaxMACTextBox);
            Controls.Add(label16);
            Controls.Add(MinMACTextBox);
            Controls.Add(label17);
            Controls.Add(MaxACTextBox);
            Controls.Add(label15);
            Controls.Add(MinACTextBox);
            Controls.Add(label14);
            Controls.Add(MonsterNameTextBox);
            Controls.Add(label3);
            Controls.Add(updateButton);
            Controls.Add(SelectMonsterComboBox);
            Margin = new Padding(4);
            Name = "MonsterTunerForm";
            Text = "怪物调节列表";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox SelectMonsterComboBox;
        private Button updateButton;
        private TextBox CoolEyeTextBox;
        private Label label12;
        private TextBox ViewRangeTextBox;
        private Label label33;
        private TextBox MSpeedTextBox;
        private Label label6;
        private TextBox ASpeedTextBox;
        private Label label5;
        private TextBox LevelTextBox;
        private Label label4;
        private TextBox EffectTextBox;
        private Label label2;
        private TextBox AgilityTextBox;
        private Label label26;
        private TextBox AccuracyTextBox;
        private Label label27;
        private TextBox HPTextBox;
        private Label label25;
        private TextBox MaxSCTextBox;
        private Label label22;
        private TextBox MinSCTextBox;
        private Label label23;
        private TextBox MaxMCTextBox;
        private Label label18;
        private TextBox MinMCTextBox;
        private Label label19;
        private TextBox MaxDCTextBox;
        private Label label20;
        private TextBox MinDCTextBox;
        private Label label21;
        private TextBox MaxMACTextBox;
        private Label label16;
        private TextBox MinMACTextBox;
        private Label label17;
        private TextBox MaxACTextBox;
        private Label label15;
        private TextBox MinACTextBox;
        private Label label14;
        private TextBox MonsterNameTextBox;
        private Label label3;
        private Button SaveButton;
    }
}