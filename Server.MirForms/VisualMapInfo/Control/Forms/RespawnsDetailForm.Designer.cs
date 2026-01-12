namespace Server.MirForms.VisualMapInfo.Control.Forms
{
    partial class RespawnsDetailForm
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
            Spread = new TextBox();
            label3 = new Label();
            Y = new TextBox();
            label2 = new Label();
            DoneButton = new Button();
            X = new TextBox();
            label1 = new Label();
            Delay = new TextBox();
            label4 = new Label();
            Count = new TextBox();
            label5 = new Label();
            label6 = new Label();
            RoutePath = new TextBox();
            label7 = new Label();
            Direction = new TextBox();
            label8 = new Label();
            RDelay = new TextBox();
            label9 = new Label();
            label10 = new Label();
            SuspendLayout();
            // 
            // Spread
            // 
            Spread.Location = new Point(83, 84);
            Spread.Margin = new Padding(4, 4, 4, 4);
            Spread.Name = "Spread";
            Spread.Size = new Size(61, 23);
            Spread.TabIndex = 13;
            Spread.KeyPress += Chk;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 88);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(35, 17);
            label3.TabIndex = 12;
            label3.Text = "展开:";
            // 
            // Y
            // 
            Y.Location = new Point(83, 50);
            Y.Margin = new Padding(4, 4, 4, 4);
            Y.Name = "Y";
            Y.Size = new Size(61, 23);
            Y.TabIndex = 11;
            Y.KeyPress += Chk;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 54);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(18, 17);
            label2.TabIndex = 10;
            label2.Text = "Y:";
            // 
            // DoneButton
            // 
            DoneButton.Location = new Point(209, 170);
            DoneButton.Margin = new Padding(4, 4, 4, 4);
            DoneButton.Name = "DoneButton";
            DoneButton.Size = new Size(122, 31);
            DoneButton.TabIndex = 9;
            DoneButton.Text = "完成";
            DoneButton.UseVisualStyleBackColor = true;
            DoneButton.Click += DoneButton_Click;
            // 
            // X
            // 
            X.Location = new Point(83, 16);
            X.Margin = new Padding(4, 4, 4, 4);
            X.Name = "X";
            X.Size = new Size(61, 23);
            X.TabIndex = 8;
            X.KeyPress += Chk;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 20);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(19, 17);
            label1.TabIndex = 7;
            label1.Text = "X:";
            // 
            // Delay
            // 
            Delay.Location = new Point(215, 50);
            Delay.Margin = new Padding(4, 4, 4, 4);
            Delay.Name = "Delay";
            Delay.Size = new Size(61, 23);
            Delay.TabIndex = 17;
            Delay.KeyPress += Chk;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(163, 54);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(35, 17);
            label4.TabIndex = 16;
            label4.Text = "延迟:";
            // 
            // Count
            // 
            Count.Location = new Point(215, 16);
            Count.Margin = new Padding(4, 4, 4, 4);
            Count.Name = "Count";
            Count.Size = new Size(61, 23);
            Count.TabIndex = 15;
            Count.KeyPress += Chk;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(163, 20);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(35, 17);
            label5.TabIndex = 14;
            label5.Text = "总数:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(284, 54);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(43, 17);
            label6.TabIndex = 18;
            label6.Text = "(分钟)";
            // 
            // RoutePath
            // 
            RoutePath.Location = new Point(215, 118);
            RoutePath.Margin = new Padding(4, 4, 4, 4);
            RoutePath.Name = "RoutePath";
            RoutePath.Size = new Size(116, 23);
            RoutePath.TabIndex = 19;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(163, 122);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(35, 17);
            label7.TabIndex = 20;
            label7.Text = "线路:";
            // 
            // Direction
            // 
            Direction.Location = new Point(83, 118);
            Direction.Margin = new Padding(4, 4, 4, 4);
            Direction.Name = "Direction";
            Direction.Size = new Size(61, 23);
            Direction.TabIndex = 21;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(32, 122);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(35, 17);
            label8.TabIndex = 22;
            label8.Text = "方向:";
            // 
            // RDelay
            // 
            RDelay.Location = new Point(215, 84);
            RDelay.Margin = new Padding(4, 4, 4, 4);
            RDelay.Name = "RDelay";
            RDelay.Size = new Size(61, 23);
            RDelay.TabIndex = 23;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(155, 88);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(43, 17);
            label9.TabIndex = 24;
            label9.Text = "R延时:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(284, 88);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(40, 17);
            label10.TabIndex = 25;
            label10.Text = "(分钟)";
            // 
            // RespawnsDetailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(355, 217);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(RDelay);
            Controls.Add(label8);
            Controls.Add(Direction);
            Controls.Add(label7);
            Controls.Add(RoutePath);
            Controls.Add(label6);
            Controls.Add(Delay);
            Controls.Add(label4);
            Controls.Add(Count);
            Controls.Add(label5);
            Controls.Add(Spread);
            Controls.Add(label3);
            Controls.Add(Y);
            Controls.Add(label2);
            Controls.Add(DoneButton);
            Controls.Add(X);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 4, 4, 4);
            MaximizeBox = false;
            Name = "RespawnsDetailForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "复活";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox Spread;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox Y;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DoneButton;
        public System.Windows.Forms.TextBox X;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox Delay;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox Count;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox RoutePath;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox Direction;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox RDelay;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}