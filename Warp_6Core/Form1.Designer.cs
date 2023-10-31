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
            OnPosition = new System.Windows.Forms.Button();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            Go = new System.Windows.Forms.RadioButton();
            Power = new System.Windows.Forms.RadioButton();
            MoreSpeed = new System.Windows.Forms.Button();
            LessSpeed = new System.Windows.Forms.Button();
            ShowSpeed = new System.Windows.Forms.TextBox();
            Ship1 = new System.Windows.Forms.RadioButton();
            Ship2 = new System.Windows.Forms.RadioButton();
            Ship3 = new System.Windows.Forms.RadioButton();
            Ship6 = new System.Windows.Forms.RadioButton();
            Ship5 = new System.Windows.Forms.RadioButton();
            Ship4 = new System.Windows.Forms.RadioButton();
            Ship9 = new System.Windows.Forms.RadioButton();
            Ship8 = new System.Windows.Forms.RadioButton();
            Ship7 = new System.Windows.Forms.RadioButton();
            groupAction = new System.Windows.Forms.GroupBox();
            groupShip = new System.Windows.Forms.GroupBox();
            Rules = new System.Windows.Forms.Button();
            ShipInCenterLabel = new System.Windows.Forms.Label();
            MyShipsCenterLabel = new System.Windows.Forms.Label();
            EnemyShipsCenterLebel = new System.Windows.Forms.Label();
            MyShipsCenterTextbox = new System.Windows.Forms.TextBox();
            EnemyShipsCenterTextbox = new System.Windows.Forms.TextBox();
            textBox1 = new System.Windows.Forms.TextBox();
            Start = new System.Windows.Forms.Button();
            Step = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupAction.SuspendLayout();
            groupShip.SuspendLayout();
            SuspendLayout();
            // 
            // OnPosition
            // 
            OnPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            OnPosition.Location = new System.Drawing.Point(139, 689);
            OnPosition.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            OnPosition.Name = "OnPosition";
            OnPosition.Size = new System.Drawing.Size(268, 58);
            OnPosition.TabIndex = 0;
            OnPosition.Text = "На позицию";
            OnPosition.UseVisualStyleBackColor = true;
            OnPosition.Visible = false;
            OnPosition.Click += OnPosition_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.Color.White;
            pictureBox1.Location = new System.Drawing.Point(511, 1);
            pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(1389, 1055);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Go
            // 
            Go.AutoSize = true;
            Go.Location = new System.Drawing.Point(20, 65);
            Go.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Go.Name = "Go";
            Go.Size = new System.Drawing.Size(286, 43);
            Go.TabIndex = 2;
            Go.TabStop = true;
            Go.Text = "Передвижение ";
            Go.UseVisualStyleBackColor = true;
            Go.CheckedChanged += Go_CheckedChanged;
            // 
            // Power
            // 
            Power.AutoSize = true;
            Power.Location = new System.Drawing.Point(20, 126);
            Power.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Power.Name = "Power";
            Power.Size = new System.Drawing.Size(202, 43);
            Power.TabIndex = 3;
            Power.TabStop = true;
            Power.Text = "Мощность";
            Power.UseVisualStyleBackColor = true;
            Power.CheckedChanged += Power_CheckedChanged;
            // 
            // MoreSpeed
            // 
            MoreSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            MoreSpeed.Location = new System.Drawing.Point(418, 508);
            MoreSpeed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MoreSpeed.Name = "MoreSpeed";
            MoreSpeed.Size = new System.Drawing.Size(42, 58);
            MoreSpeed.TabIndex = 4;
            MoreSpeed.Text = ">";
            MoreSpeed.UseVisualStyleBackColor = true;
            MoreSpeed.Visible = false;
            // 
            // LessSpeed
            // 
            LessSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LessSpeed.Location = new System.Drawing.Point(360, 509);
            LessSpeed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            LessSpeed.Name = "LessSpeed";
            LessSpeed.Size = new System.Drawing.Size(42, 56);
            LessSpeed.TabIndex = 5;
            LessSpeed.Text = "<";
            LessSpeed.UseVisualStyleBackColor = true;
            LessSpeed.Visible = false;
            // 
            // ShowSpeed
            // 
            ShowSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ShowSpeed.Location = new System.Drawing.Point(360, 446);
            ShowSpeed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            ShowSpeed.Name = "ShowSpeed";
            ShowSpeed.Size = new System.Drawing.Size(100, 45);
            ShowSpeed.TabIndex = 6;
            ShowSpeed.Visible = false;
            // 
            // Ship1
            // 
            Ship1.AutoSize = true;
            Ship1.Location = new System.Drawing.Point(41, 80);
            Ship1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Ship1.Name = "Ship1";
            Ship1.Size = new System.Drawing.Size(57, 43);
            Ship1.TabIndex = 8;
            Ship1.TabStop = true;
            Ship1.Text = "1";
            Ship1.UseVisualStyleBackColor = true;
            // 
            // Ship2
            // 
            Ship2.AutoSize = true;
            Ship2.Location = new System.Drawing.Point(122, 80);
            Ship2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Ship2.Name = "Ship2";
            Ship2.Size = new System.Drawing.Size(57, 43);
            Ship2.TabIndex = 9;
            Ship2.TabStop = true;
            Ship2.Text = "2";
            Ship2.UseVisualStyleBackColor = true;
            // 
            // Ship3
            // 
            Ship3.AutoSize = true;
            Ship3.Location = new System.Drawing.Point(196, 80);
            Ship3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Ship3.Name = "Ship3";
            Ship3.Size = new System.Drawing.Size(57, 43);
            Ship3.TabIndex = 10;
            Ship3.TabStop = true;
            Ship3.Text = "3";
            Ship3.UseVisualStyleBackColor = true;
            // 
            // Ship6
            // 
            Ship6.AutoSize = true;
            Ship6.Location = new System.Drawing.Point(196, 141);
            Ship6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Ship6.Name = "Ship6";
            Ship6.Size = new System.Drawing.Size(57, 43);
            Ship6.TabIndex = 13;
            Ship6.TabStop = true;
            Ship6.Text = "6";
            Ship6.UseVisualStyleBackColor = true;
            // 
            // Ship5
            // 
            Ship5.AutoSize = true;
            Ship5.Location = new System.Drawing.Point(122, 141);
            Ship5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Ship5.Name = "Ship5";
            Ship5.Size = new System.Drawing.Size(57, 43);
            Ship5.TabIndex = 12;
            Ship5.TabStop = true;
            Ship5.Text = "5";
            Ship5.UseVisualStyleBackColor = true;
            // 
            // Ship4
            // 
            Ship4.AutoSize = true;
            Ship4.Location = new System.Drawing.Point(41, 141);
            Ship4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Ship4.Name = "Ship4";
            Ship4.Size = new System.Drawing.Size(57, 43);
            Ship4.TabIndex = 11;
            Ship4.TabStop = true;
            Ship4.Text = "4";
            Ship4.UseVisualStyleBackColor = true;
            // 
            // Ship9
            // 
            Ship9.AutoSize = true;
            Ship9.Location = new System.Drawing.Point(196, 202);
            Ship9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Ship9.Name = "Ship9";
            Ship9.Size = new System.Drawing.Size(57, 43);
            Ship9.TabIndex = 16;
            Ship9.TabStop = true;
            Ship9.Text = "9";
            Ship9.UseVisualStyleBackColor = true;
            // 
            // Ship8
            // 
            Ship8.AutoSize = true;
            Ship8.Location = new System.Drawing.Point(122, 202);
            Ship8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Ship8.Name = "Ship8";
            Ship8.Size = new System.Drawing.Size(57, 43);
            Ship8.TabIndex = 15;
            Ship8.TabStop = true;
            Ship8.Text = "8";
            Ship8.UseVisualStyleBackColor = true;
            // 
            // Ship7
            // 
            Ship7.AutoSize = true;
            Ship7.Location = new System.Drawing.Point(41, 202);
            Ship7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Ship7.Name = "Ship7";
            Ship7.Size = new System.Drawing.Size(57, 43);
            Ship7.TabIndex = 14;
            Ship7.TabStop = true;
            Ship7.Text = "7";
            Ship7.UseVisualStyleBackColor = true;
            // 
            // groupAction
            // 
            groupAction.Controls.Add(Power);
            groupAction.Controls.Add(Go);
            groupAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            groupAction.Location = new System.Drawing.Point(12, 425);
            groupAction.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupAction.Name = "groupAction";
            groupAction.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupAction.Size = new System.Drawing.Size(315, 188);
            groupAction.TabIndex = 7;
            groupAction.TabStop = false;
            groupAction.Text = "Выбор действия";
            groupAction.Visible = false;
            // 
            // groupShip
            // 
            groupShip.Controls.Add(Ship9);
            groupShip.Controls.Add(Ship8);
            groupShip.Controls.Add(Ship7);
            groupShip.Controls.Add(Ship6);
            groupShip.Controls.Add(Ship5);
            groupShip.Controls.Add(Ship4);
            groupShip.Controls.Add(Ship3);
            groupShip.Controls.Add(Ship2);
            groupShip.Controls.Add(Ship1);
            groupShip.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            groupShip.Location = new System.Drawing.Point(139, 95);
            groupShip.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupShip.Name = "groupShip";
            groupShip.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupShip.Size = new System.Drawing.Size(292, 289);
            groupShip.TabIndex = 17;
            groupShip.TabStop = false;
            groupShip.Text = "Корабли";
            groupShip.Visible = false;
            // 
            // Rules
            // 
            Rules.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Rules.Location = new System.Drawing.Point(12, 15);
            Rules.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Rules.Name = "Rules";
            Rules.Size = new System.Drawing.Size(138, 54);
            Rules.TabIndex = 18;
            Rules.Text = "Правила";
            Rules.UseVisualStyleBackColor = true;
            Rules.Click += Rules_Click;
            // 
            // ShipInCenterLabel
            // 
            ShipInCenterLabel.AutoSize = true;
            ShipInCenterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ShipInCenterLabel.Location = new System.Drawing.Point(125, 817);
            ShipInCenterLabel.Name = "ShipInCenterLabel";
            ShipInCenterLabel.Size = new System.Drawing.Size(302, 39);
            ShipInCenterLabel.TabIndex = 19;
            ShipInCenterLabel.Text = "Корабли в центре";
            ShipInCenterLabel.Visible = false;
            // 
            // MyShipsCenterLabel
            // 
            MyShipsCenterLabel.AutoSize = true;
            MyShipsCenterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            MyShipsCenterLabel.Location = new System.Drawing.Point(169, 882);
            MyShipsCenterLabel.Name = "MyShipsCenterLabel";
            MyShipsCenterLabel.Size = new System.Drawing.Size(105, 39);
            MyShipsCenterLabel.TabIndex = 20;
            MyShipsCenterLabel.Text = "Ваши";
            MyShipsCenterLabel.Visible = false;
            // 
            // EnemyShipsCenterLebel
            // 
            EnemyShipsCenterLebel.AutoSize = true;
            EnemyShipsCenterLebel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            EnemyShipsCenterLebel.Location = new System.Drawing.Point(67, 945);
            EnemyShipsCenterLebel.Name = "EnemyShipsCenterLebel";
            EnemyShipsCenterLebel.Size = new System.Drawing.Size(207, 39);
            EnemyShipsCenterLebel.TabIndex = 21;
            EnemyShipsCenterLebel.Text = "Противника";
            EnemyShipsCenterLebel.Visible = false;
            // 
            // MyShipsCenterTextbox
            // 
            MyShipsCenterTextbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            MyShipsCenterTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            MyShipsCenterTextbox.Location = new System.Drawing.Point(290, 878);
            MyShipsCenterTextbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MyShipsCenterTextbox.Name = "MyShipsCenterTextbox";
            MyShipsCenterTextbox.Size = new System.Drawing.Size(85, 45);
            MyShipsCenterTextbox.TabIndex = 22;
            MyShipsCenterTextbox.Text = "9";
            MyShipsCenterTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            MyShipsCenterTextbox.Visible = false;
            // 
            // EnemyShipsCenterTextbox
            // 
            EnemyShipsCenterTextbox.AcceptsReturn = true;
            EnemyShipsCenterTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            EnemyShipsCenterTextbox.Location = new System.Drawing.Point(290, 945);
            EnemyShipsCenterTextbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            EnemyShipsCenterTextbox.Name = "EnemyShipsCenterTextbox";
            EnemyShipsCenterTextbox.Size = new System.Drawing.Size(85, 45);
            EnemyShipsCenterTextbox.TabIndex = 23;
            EnemyShipsCenterTextbox.Text = "9";
            EnemyShipsCenterTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            EnemyShipsCenterTextbox.Visible = false;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(360, 33);
            textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(145, 27);
            textBox1.TabIndex = 24;
            // 
            // Start
            // 
            Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Start.Location = new System.Drawing.Point(139, 689);
            Start.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Start.Name = "Start";
            Start.Size = new System.Drawing.Size(268, 58);
            Start.TabIndex = 25;
            Start.Text = "Начать игру";
            Start.UseVisualStyleBackColor = true;
            Start.Visible = false;
            Start.Click += Start_Click;
            // 
            // Step
            // 
            Step.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Step.Location = new System.Drawing.Point(139, 689);
            Step.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Step.Name = "Step";
            Step.Size = new System.Drawing.Size(268, 58);
            Step.TabIndex = 26;
            Step.Text = "Ход";
            Step.UseVisualStyleBackColor = true;
            Step.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1902, 1055);
            Controls.Add(Step);
            Controls.Add(Start);
            Controls.Add(textBox1);
            Controls.Add(EnemyShipsCenterTextbox);
            Controls.Add(MyShipsCenterTextbox);
            Controls.Add(EnemyShipsCenterLebel);
            Controls.Add(MyShipsCenterLabel);
            Controls.Add(ShipInCenterLabel);
            Controls.Add(Rules);
            Controls.Add(groupShip);
            Controls.Add(groupAction);
            Controls.Add(ShowSpeed);
            Controls.Add(LessSpeed);
            Controls.Add(MoreSpeed);
            Controls.Add(pictureBox1);
            Controls.Add(OnPosition);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupAction.ResumeLayout(false);
            groupAction.PerformLayout();
            groupShip.ResumeLayout(false);
            groupShip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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

