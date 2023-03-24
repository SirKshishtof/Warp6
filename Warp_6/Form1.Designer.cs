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
            this.start = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Go = new System.Windows.Forms.RadioButton();
            this.Power = new System.Windows.Forms.RadioButton();
            this.MorePower = new System.Windows.Forms.Button();
            this.LessPower = new System.Windows.Forms.Button();
            this.ShowPower = new System.Windows.Forms.TextBox();
            this.Ship1 = new System.Windows.Forms.RadioButton();
            this.Ship2 = new System.Windows.Forms.RadioButton();
            this.Ship3 = new System.Windows.Forms.RadioButton();
            this.Ship6 = new System.Windows.Forms.RadioButton();
            this.Ship5 = new System.Windows.Forms.RadioButton();
            this.Ship4 = new System.Windows.Forms.RadioButton();
            this.Ship9 = new System.Windows.Forms.RadioButton();
            this.Ship8 = new System.Windows.Forms.RadioButton();
            this.Ship7 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start.Location = new System.Drawing.Point(224, 642);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(114, 46);
            this.start.TabIndex = 0;
            this.start.Text = "Ход!";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // pictureBox1
            // 
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
            // MorePower
            // 
            this.MorePower.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MorePower.Location = new System.Drawing.Point(418, 481);
            this.MorePower.Name = "MorePower";
            this.MorePower.Size = new System.Drawing.Size(42, 46);
            this.MorePower.TabIndex = 4;
            this.MorePower.Text = ">";
            this.MorePower.UseVisualStyleBackColor = true;
            // 
            // LessPower
            // 
            this.LessPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LessPower.Location = new System.Drawing.Point(360, 482);
            this.LessPower.Name = "LessPower";
            this.LessPower.Size = new System.Drawing.Size(42, 45);
            this.LessPower.TabIndex = 5;
            this.LessPower.Text = "<";
            this.LessPower.UseVisualStyleBackColor = true;
            // 
            // ShowPower
            // 
            this.ShowPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowPower.Location = new System.Drawing.Point(360, 431);
            this.ShowPower.Name = "ShowPower";
            this.ShowPower.Size = new System.Drawing.Size(100, 45);
            this.ShowPower.TabIndex = 6;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Power);
            this.groupBox1.Controls.Add(this.Go);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 414);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 150);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор дейстивя";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Ship9);
            this.groupBox2.Controls.Add(this.Ship8);
            this.groupBox2.Controls.Add(this.Ship7);
            this.groupBox2.Controls.Add(this.Ship6);
            this.groupBox2.Controls.Add(this.Ship5);
            this.groupBox2.Controls.Add(this.Ship4);
            this.groupBox2.Controls.Add(this.Ship3);
            this.groupBox2.Controls.Add(this.Ship2);
            this.groupBox2.Controls.Add(this.Ship1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(139, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(292, 231);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Корабли";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ShowPower);
            this.Controls.Add(this.LessPower);
            this.Controls.Add(this.MorePower);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RadioButton Go;
        private System.Windows.Forms.RadioButton Power;
        private System.Windows.Forms.Button MorePower;
        private System.Windows.Forms.Button LessPower;
        private System.Windows.Forms.TextBox ShowPower;
        private System.Windows.Forms.RadioButton Ship1;
        private System.Windows.Forms.RadioButton Ship2;
        private System.Windows.Forms.RadioButton Ship3;
        private System.Windows.Forms.RadioButton Ship6;
        private System.Windows.Forms.RadioButton Ship5;
        private System.Windows.Forms.RadioButton Ship4;
        private System.Windows.Forms.RadioButton Ship9;
        private System.Windows.Forms.RadioButton Ship8;
        private System.Windows.Forms.RadioButton Ship7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

