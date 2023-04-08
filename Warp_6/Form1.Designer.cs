namespace Warp_6
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.OnPosition = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Go = new System.Windows.Forms.RadioButton();
            this.Power = new System.Windows.Forms.RadioButton();
            this.MoreSpeed = new System.Windows.Forms.Button();
            this.LessSpeed = new System.Windows.Forms.Button();
            this.ShowSpeed = new System.Windows.Forms.TextBox();
            this.Ship1 = new System.Windows.Forms.RadioButton();
            this.Ship2 = new System.Windows.Forms.RadioButton();
            this.Ship3 = new System.Windows.Forms.RadioButton();
            this.Ship6 = new System.Windows.Forms.RadioButton();
            this.Ship5 = new System.Windows.Forms.RadioButton();
            this.Ship4 = new System.Windows.Forms.RadioButton();
            this.Ship9 = new System.Windows.Forms.RadioButton();
            this.Ship8 = new System.Windows.Forms.RadioButton();
            this.Ship7 = new System.Windows.Forms.RadioButton();
            this.groupAction = new System.Windows.Forms.GroupBox();
            this.groupShip = new System.Windows.Forms.GroupBox();
            this.Rules = new System.Windows.Forms.Button();
            this.ShipInCenterLabel = new System.Windows.Forms.Label();
            this.MyShipsCenterLabel = new System.Windows.Forms.Label();
            this.EnemyShipsCenterLebel = new System.Windows.Forms.Label();
            this.MyShipsCenterTextbox = new System.Windows.Forms.TextBox();
            this.EnemyShipsCenterTextbox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Start = new System.Windows.Forms.Button();
            this.Step = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupAction.SuspendLayout();
            this.groupShip.SuspendLayout();
            this.SuspendLayout();
            // 
            // OnPosition
            // 
            this.OnPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OnPosition.Location = new System.Drawing.Point(152, 640);
            this.OnPosition.Name = "OnPosition";
            this.OnPosition.Size = new System.Drawing.Size(268, 46);
            this.OnPosition.TabIndex = 0;
            this.OnPosition.Text = "На позицию";
            this.OnPosition.UseVisualStyleBackColor = true;
            this.OnPosition.Visible = false;
            this.OnPosition.Click += new System.EventHandler(this.OnPosition_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(511, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1499, 1080);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Go
            // 
            this.Go.AutoSize = true;
            this.Go.Location = new System.Drawing.Point(20, 52);
            this.Go.Name = "Go";
            this.Go.Size = new System.Drawing.Size(286, 43);
            this.Go.TabIndex = 2;
            this.Go.TabStop = true;
            this.Go.Text = "Передвижение ";
            this.Go.UseVisualStyleBackColor = true;
            this.Go.CheckedChanged += new System.EventHandler(this.Go_CheckedChanged);
            // 
            // Power
            // 
            this.Power.AutoSize = true;
            this.Power.Location = new System.Drawing.Point(20, 101);
            this.Power.Name = "Power";
            this.Power.Size = new System.Drawing.Size(202, 43);
            this.Power.TabIndex = 3;
            this.Power.TabStop = true;
            this.Power.Text = "Мощность";
            this.Power.UseVisualStyleBackColor = true;
            this.Power.CheckedChanged += new System.EventHandler(this.Power_CheckedChanged);
            // 
            // MoreSpeed
            // 
            this.MoreSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MoreSpeed.Location = new System.Drawing.Point(418, 481);
            this.MoreSpeed.Name = "MoreSpeed";
            this.MoreSpeed.Size = new System.Drawing.Size(42, 46);
            this.MoreSpeed.TabIndex = 4;
            this.MoreSpeed.Text = ">";
            this.MoreSpeed.UseVisualStyleBackColor = true;
            this.MoreSpeed.Visible = false;
            // 
            // LessSpeed
            // 
            this.LessSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LessSpeed.Location = new System.Drawing.Point(360, 482);
            this.LessSpeed.Name = "LessSpeed";
            this.LessSpeed.Size = new System.Drawing.Size(42, 45);
            this.LessSpeed.TabIndex = 5;
            this.LessSpeed.Text = "<";
            this.LessSpeed.UseVisualStyleBackColor = true;
            this.LessSpeed.Visible = false;
            // 
            // ShowSpeed
            // 
            this.ShowSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowSpeed.Location = new System.Drawing.Point(360, 431);
            this.ShowSpeed.Name = "ShowSpeed";
            this.ShowSpeed.Size = new System.Drawing.Size(100, 45);
            this.ShowSpeed.TabIndex = 6;
            this.ShowSpeed.Visible = false;
            // 
            // Ship1
            // 
            this.Ship1.AutoSize = true;
            this.Ship1.Location = new System.Drawing.Point(41, 64);
            this.Ship1.Name = "Ship1";
            this.Ship1.Size = new System.Drawing.Size(57, 43);
            this.Ship1.TabIndex = 8;
            this.Ship1.TabStop = true;
            this.Ship1.Text = "1";
            this.Ship1.UseVisualStyleBackColor = true;
            // 
            // Ship2
            // 
            this.Ship2.AutoSize = true;
            this.Ship2.Location = new System.Drawing.Point(41, 113);
            this.Ship2.Name = "Ship2";
            this.Ship2.Size = new System.Drawing.Size(57, 43);
            this.Ship2.TabIndex = 9;
            this.Ship2.TabStop = true;
            this.Ship2.Text = "2";
            this.Ship2.UseVisualStyleBackColor = true;
            // 
            // Ship3
            // 
            this.Ship3.AutoSize = true;
            this.Ship3.Location = new System.Drawing.Point(41, 162);
            this.Ship3.Name = "Ship3";
            this.Ship3.Size = new System.Drawing.Size(57, 43);
            this.Ship3.TabIndex = 10;
            this.Ship3.TabStop = true;
            this.Ship3.Text = "3";
            this.Ship3.UseVisualStyleBackColor = true;
            // 
            // Ship6
            // 
            this.Ship6.AutoSize = true;
            this.Ship6.Location = new System.Drawing.Point(122, 162);
            this.Ship6.Name = "Ship6";
            this.Ship6.Size = new System.Drawing.Size(57, 43);
            this.Ship6.TabIndex = 13;
            this.Ship6.TabStop = true;
            this.Ship6.Text = "6";
            this.Ship6.UseVisualStyleBackColor = true;
            // 
            // Ship5
            // 
            this.Ship5.AutoSize = true;
            this.Ship5.Location = new System.Drawing.Point(122, 113);
            this.Ship5.Name = "Ship5";
            this.Ship5.Size = new System.Drawing.Size(57, 43);
            this.Ship5.TabIndex = 12;
            this.Ship5.TabStop = true;
            this.Ship5.Text = "5";
            this.Ship5.UseVisualStyleBackColor = true;
            // 
            // Ship4
            // 
            this.Ship4.AutoSize = true;
            this.Ship4.Location = new System.Drawing.Point(122, 64);
            this.Ship4.Name = "Ship4";
            this.Ship4.Size = new System.Drawing.Size(57, 43);
            this.Ship4.TabIndex = 11;
            this.Ship4.TabStop = true;
            this.Ship4.Text = "4";
            this.Ship4.UseVisualStyleBackColor = true;
            // 
            // Ship9
            // 
            this.Ship9.AutoSize = true;
            this.Ship9.Location = new System.Drawing.Point(196, 162);
            this.Ship9.Name = "Ship9";
            this.Ship9.Size = new System.Drawing.Size(57, 43);
            this.Ship9.TabIndex = 16;
            this.Ship9.TabStop = true;
            this.Ship9.Text = "9";
            this.Ship9.UseVisualStyleBackColor = true;
            // 
            // Ship8
            // 
            this.Ship8.AutoSize = true;
            this.Ship8.Location = new System.Drawing.Point(196, 113);
            this.Ship8.Name = "Ship8";
            this.Ship8.Size = new System.Drawing.Size(57, 43);
            this.Ship8.TabIndex = 15;
            this.Ship8.TabStop = true;
            this.Ship8.Text = "8";
            this.Ship8.UseVisualStyleBackColor = true;
            // 
            // Ship7
            // 
            this.Ship7.AutoSize = true;
            this.Ship7.Location = new System.Drawing.Point(196, 64);
            this.Ship7.Name = "Ship7";
            this.Ship7.Size = new System.Drawing.Size(57, 43);
            this.Ship7.TabIndex = 14;
            this.Ship7.TabStop = true;
            this.Ship7.Text = "7";
            this.Ship7.UseVisualStyleBackColor = true;
            // 
            // groupAction
            // 
            this.groupAction.Controls.Add(this.Power);
            this.groupAction.Controls.Add(this.Go);
            this.groupAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupAction.Location = new System.Drawing.Point(12, 414);
            this.groupAction.Name = "groupAction";
            this.groupAction.Size = new System.Drawing.Size(315, 150);
            this.groupAction.TabIndex = 7;
            this.groupAction.TabStop = false;
            this.groupAction.Text = "Выбор действия";
            this.groupAction.Visible = false;
            // 
            // groupShip
            // 
            this.groupShip.Controls.Add(this.Ship9);
            this.groupShip.Controls.Add(this.Ship8);
            this.groupShip.Controls.Add(this.Ship7);
            this.groupShip.Controls.Add(this.Ship6);
            this.groupShip.Controls.Add(this.Ship5);
            this.groupShip.Controls.Add(this.Ship4);
            this.groupShip.Controls.Add(this.Ship3);
            this.groupShip.Controls.Add(this.Ship2);
            this.groupShip.Controls.Add(this.Ship1);
            this.groupShip.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupShip.Location = new System.Drawing.Point(139, 150);
            this.groupShip.Name = "groupShip";
            this.groupShip.Size = new System.Drawing.Size(292, 231);
            this.groupShip.TabIndex = 17;
            this.groupShip.TabStop = false;
            this.groupShip.Text = "Корабли";
            this.groupShip.Visible = false;
            // 
            // Rules
            // 
            this.Rules.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Rules.Location = new System.Drawing.Point(12, 12);
            this.Rules.Name = "Rules";
            this.Rules.Size = new System.Drawing.Size(138, 43);
            this.Rules.TabIndex = 18;
            this.Rules.Text = "Правила";
            this.Rules.UseVisualStyleBackColor = true;
            this.Rules.Click += new System.EventHandler(this.Rules_Click);
            // 
            // ShipInCenterLabel
            // 
            this.ShipInCenterLabel.AutoSize = true;
            this.ShipInCenterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.ShipInCenterLabel.Location = new System.Drawing.Point(129, 779);
            this.ShipInCenterLabel.Name = "ShipInCenterLabel";
            this.ShipInCenterLabel.Size = new System.Drawing.Size(302, 39);
            this.ShipInCenterLabel.TabIndex = 19;
            this.ShipInCenterLabel.Text = "Корабли в центре";
            this.ShipInCenterLabel.Visible = false;
            // 
            // MyShipsCenterLabel
            // 
            this.MyShipsCenterLabel.AutoSize = true;
            this.MyShipsCenterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.MyShipsCenterLabel.Location = new System.Drawing.Point(173, 831);
            this.MyShipsCenterLabel.Name = "MyShipsCenterLabel";
            this.MyShipsCenterLabel.Size = new System.Drawing.Size(105, 39);
            this.MyShipsCenterLabel.TabIndex = 20;
            this.MyShipsCenterLabel.Text = "Ваши";
            this.MyShipsCenterLabel.Visible = false;
            // 
            // EnemyShipsCenterLebel
            // 
            this.EnemyShipsCenterLebel.AutoSize = true;
            this.EnemyShipsCenterLebel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.EnemyShipsCenterLebel.Location = new System.Drawing.Point(71, 882);
            this.EnemyShipsCenterLebel.Name = "EnemyShipsCenterLebel";
            this.EnemyShipsCenterLebel.Size = new System.Drawing.Size(207, 39);
            this.EnemyShipsCenterLebel.TabIndex = 21;
            this.EnemyShipsCenterLebel.Text = "Противника";
            this.EnemyShipsCenterLebel.Visible = false;
            // 
            // MyShipsCenterTextbox
            // 
            this.MyShipsCenterTextbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.MyShipsCenterTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.MyShipsCenterTextbox.Location = new System.Drawing.Point(294, 828);
            this.MyShipsCenterTextbox.Name = "MyShipsCenterTextbox";
            this.MyShipsCenterTextbox.Size = new System.Drawing.Size(85, 45);
            this.MyShipsCenterTextbox.TabIndex = 22;
            this.MyShipsCenterTextbox.Text = "9";
            this.MyShipsCenterTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MyShipsCenterTextbox.Visible = false;
            // 
            // EnemyShipsCenterTextbox
            // 
            this.EnemyShipsCenterTextbox.AcceptsReturn = true;
            this.EnemyShipsCenterTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.EnemyShipsCenterTextbox.Location = new System.Drawing.Point(294, 882);
            this.EnemyShipsCenterTextbox.Name = "EnemyShipsCenterTextbox";
            this.EnemyShipsCenterTextbox.Size = new System.Drawing.Size(85, 45);
            this.EnemyShipsCenterTextbox.TabIndex = 23;
            this.EnemyShipsCenterTextbox.Text = "9";
            this.EnemyShipsCenterTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.EnemyShipsCenterTextbox.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(348, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 24;
            // 
            // Start
            // 
            this.Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Start.Location = new System.Drawing.Point(152, 640);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(268, 46);
            this.Start.TabIndex = 25;
            this.Start.Text = "Начать игру";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Visible = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Step
            // 
            this.Step.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Step.Location = new System.Drawing.Point(152, 640);
            this.Step.Name = "Step";
            this.Step.Size = new System.Drawing.Size(268, 46);
            this.Step.TabIndex = 26;
            this.Step.Text = "Ход";
            this.Step.UseVisualStyleBackColor = true;
            this.Step.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.Step);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.EnemyShipsCenterTextbox);
            this.Controls.Add(this.MyShipsCenterTextbox);
            this.Controls.Add(this.EnemyShipsCenterLebel);
            this.Controls.Add(this.MyShipsCenterLabel);
            this.Controls.Add(this.ShipInCenterLabel);
            this.Controls.Add(this.Rules);
            this.Controls.Add(this.groupShip);
            this.Controls.Add(this.groupAction);
            this.Controls.Add(this.ShowSpeed);
            this.Controls.Add(this.LessSpeed);
            this.Controls.Add(this.MoreSpeed);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.OnPosition);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupAction.ResumeLayout(false);
            this.groupAction.PerformLayout();
            this.groupShip.ResumeLayout(false);
            this.groupShip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OnPosition;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RadioButton Go;
        private System.Windows.Forms.RadioButton Power;
        private System.Windows.Forms.Button MoreSpeed;
        private System.Windows.Forms.Button LessSpeed;
        private System.Windows.Forms.TextBox ShowSpeed;
        private System.Windows.Forms.RadioButton Ship1;
        private System.Windows.Forms.RadioButton Ship2;
        private System.Windows.Forms.RadioButton Ship3;
        private System.Windows.Forms.RadioButton Ship6;
        private System.Windows.Forms.RadioButton Ship5;
        private System.Windows.Forms.RadioButton Ship4;
        private System.Windows.Forms.RadioButton Ship9;
        private System.Windows.Forms.RadioButton Ship8;
        private System.Windows.Forms.RadioButton Ship7;
        private System.Windows.Forms.GroupBox groupAction;
        private System.Windows.Forms.GroupBox groupShip;
        private System.Windows.Forms.Button Rules;
        private System.Windows.Forms.Label ShipInCenterLabel;
        private System.Windows.Forms.Label MyShipsCenterLabel;
        private System.Windows.Forms.Label EnemyShipsCenterLebel;
        private System.Windows.Forms.TextBox MyShipsCenterTextbox;
        private System.Windows.Forms.TextBox EnemyShipsCenterTextbox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Step;
    }
}

