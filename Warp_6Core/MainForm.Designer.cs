namespace Warp_6
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            OnPosition = new System.Windows.Forms.Button();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            Go = new System.Windows.Forms.RadioButton();
            ChangeSpeed = new System.Windows.Forms.RadioButton();
            MoreSpeed = new System.Windows.Forms.Button();
            LessSpeed = new System.Windows.Forms.Button();
            ShowSpeed = new System.Windows.Forms.TextBox();
            Ship_0 = new System.Windows.Forms.RadioButton();
            Ship_1 = new System.Windows.Forms.RadioButton();
            Ship_2 = new System.Windows.Forms.RadioButton();
            Ship_5 = new System.Windows.Forms.RadioButton();
            Ship_4 = new System.Windows.Forms.RadioButton();
            Ship_3 = new System.Windows.Forms.RadioButton();
            Ship_8 = new System.Windows.Forms.RadioButton();
            Ship_7 = new System.Windows.Forms.RadioButton();
            Ship_6 = new System.Windows.Forms.RadioButton();
            GroupAction = new System.Windows.Forms.GroupBox();
            GroupShip = new System.Windows.Forms.GroupBox();
            ShipInCenterLabel = new System.Windows.Forms.Label();
            MyShipsCenterLabel = new System.Windows.Forms.Label();
            EnemyShipsCenterLebel = new System.Windows.Forms.Label();
            MyShipsCenterTextbox = new System.Windows.Forms.TextBox();
            EnemyShipsCenterTextbox = new System.Windows.Forms.TextBox();
            Start = new System.Windows.Forms.Button();
            Step = new System.Windows.Forms.Button();
            SpeedLable = new System.Windows.Forms.Label();
            AutoPosChB = new System.Windows.Forms.CheckBox();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            NewGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            SaveGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            DownloadGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            правилаToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            NewGameButtonMainForm = new System.Windows.Forms.Button();
            GameExit = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            GroupAction.SuspendLayout();
            GroupShip.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // OnPosition
            // 
            OnPosition.BackColor = System.Drawing.SystemColors.Control;
            OnPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            OnPosition.Location = new System.Drawing.Point(139, 644);
            OnPosition.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            OnPosition.Name = "OnPosition";
            OnPosition.Size = new System.Drawing.Size(268, 58);
            OnPosition.TabIndex = 0;
            OnPosition.Text = "На позицию";
            OnPosition.UseVisualStyleBackColor = false;
            OnPosition.Visible = false;
            OnPosition.Click += OnPosition_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.Color.Transparent;
            pictureBox1.Location = new System.Drawing.Point(511, -1);
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
            // ChangeSpeed
            // 
            ChangeSpeed.AutoSize = true;
            ChangeSpeed.Location = new System.Drawing.Point(20, 126);
            ChangeSpeed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            ChangeSpeed.Name = "ChangeSpeed";
            ChangeSpeed.Size = new System.Drawing.Size(204, 82);
            ChangeSpeed.TabIndex = 3;
            ChangeSpeed.TabStop = true;
            ChangeSpeed.Text = "Изменить \r\nскорость";
            ChangeSpeed.UseVisualStyleBackColor = true;
            ChangeSpeed.CheckedChanged += ChangeSpeed_CheckedChanged;
            // 
            // MoreSpeed
            // 
            MoreSpeed.BackColor = System.Drawing.SystemColors.Control;
            MoreSpeed.Enabled = false;
            MoreSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            MoreSpeed.Location = new System.Drawing.Point(444, 526);
            MoreSpeed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MoreSpeed.Name = "MoreSpeed";
            MoreSpeed.Size = new System.Drawing.Size(42, 58);
            MoreSpeed.TabIndex = 4;
            MoreSpeed.Text = ">";
            MoreSpeed.UseVisualStyleBackColor = false;
            MoreSpeed.Visible = false;
            MoreSpeed.Click += MoreSpeed_Click;
            // 
            // LessSpeed
            // 
            LessSpeed.BackColor = System.Drawing.SystemColors.Control;
            LessSpeed.Enabled = false;
            LessSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LessSpeed.Location = new System.Drawing.Point(386, 527);
            LessSpeed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            LessSpeed.Name = "LessSpeed";
            LessSpeed.Size = new System.Drawing.Size(42, 56);
            LessSpeed.TabIndex = 5;
            LessSpeed.Text = "<";
            LessSpeed.UseVisualStyleBackColor = false;
            LessSpeed.Visible = false;
            LessSpeed.Click += LessSpeed_Click;
            // 
            // ShowSpeed
            // 
            ShowSpeed.BackColor = System.Drawing.Color.White;
            ShowSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ShowSpeed.Location = new System.Drawing.Point(386, 464);
            ShowSpeed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            ShowSpeed.Name = "ShowSpeed";
            ShowSpeed.ReadOnly = true;
            ShowSpeed.Size = new System.Drawing.Size(100, 45);
            ShowSpeed.TabIndex = 6;
            ShowSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            ShowSpeed.Visible = false;
            // 
            // Ship_0
            // 
            Ship_0.AutoSize = true;
            Ship_0.BackColor = System.Drawing.Color.Transparent;
            Ship_0.Location = new System.Drawing.Point(41, 80);
            Ship_0.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Ship_0.Name = "Ship_0";
            Ship_0.Size = new System.Drawing.Size(57, 43);
            Ship_0.TabIndex = 8;
            Ship_0.TabStop = true;
            Ship_0.Text = "1";
            Ship_0.UseVisualStyleBackColor = false;
            Ship_0.CheckedChanged += Ship_0_CheckedChanged;
            // 
            // Ship_1
            // 
            Ship_1.AutoSize = true;
            Ship_1.BackColor = System.Drawing.Color.Transparent;
            Ship_1.Location = new System.Drawing.Point(122, 80);
            Ship_1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Ship_1.Name = "Ship_1";
            Ship_1.Size = new System.Drawing.Size(57, 43);
            Ship_1.TabIndex = 9;
            Ship_1.TabStop = true;
            Ship_1.Text = "2";
            Ship_1.UseVisualStyleBackColor = false;
            Ship_1.CheckedChanged += Ship_1_CheckedChanged;
            // 
            // Ship_2
            // 
            Ship_2.AutoSize = true;
            Ship_2.BackColor = System.Drawing.Color.Transparent;
            Ship_2.Location = new System.Drawing.Point(196, 80);
            Ship_2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Ship_2.Name = "Ship_2";
            Ship_2.Size = new System.Drawing.Size(57, 43);
            Ship_2.TabIndex = 10;
            Ship_2.TabStop = true;
            Ship_2.Text = "3";
            Ship_2.UseVisualStyleBackColor = false;
            Ship_2.CheckedChanged += Ship_2_CheckedChanged;
            // 
            // Ship_5
            // 
            Ship_5.AutoSize = true;
            Ship_5.BackColor = System.Drawing.Color.Transparent;
            Ship_5.Location = new System.Drawing.Point(196, 141);
            Ship_5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Ship_5.Name = "Ship_5";
            Ship_5.Size = new System.Drawing.Size(57, 43);
            Ship_5.TabIndex = 13;
            Ship_5.TabStop = true;
            Ship_5.Text = "6";
            Ship_5.UseVisualStyleBackColor = false;
            Ship_5.CheckedChanged += Ship_5_CheckedChanged;
            // 
            // Ship_4
            // 
            Ship_4.AutoSize = true;
            Ship_4.BackColor = System.Drawing.Color.Transparent;
            Ship_4.Location = new System.Drawing.Point(122, 141);
            Ship_4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Ship_4.Name = "Ship_4";
            Ship_4.Size = new System.Drawing.Size(57, 43);
            Ship_4.TabIndex = 12;
            Ship_4.TabStop = true;
            Ship_4.Text = "5";
            Ship_4.UseVisualStyleBackColor = false;
            Ship_4.CheckedChanged += Ship_4_CheckedChanged;
            // 
            // Ship_3
            // 
            Ship_3.AutoSize = true;
            Ship_3.BackColor = System.Drawing.Color.Transparent;
            Ship_3.Location = new System.Drawing.Point(41, 141);
            Ship_3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Ship_3.Name = "Ship_3";
            Ship_3.Size = new System.Drawing.Size(57, 43);
            Ship_3.TabIndex = 11;
            Ship_3.TabStop = true;
            Ship_3.Text = "4";
            Ship_3.UseVisualStyleBackColor = false;
            Ship_3.CheckedChanged += Ship_3_CheckedChanged;
            // 
            // Ship_8
            // 
            Ship_8.AutoSize = true;
            Ship_8.BackColor = System.Drawing.Color.Transparent;
            Ship_8.Location = new System.Drawing.Point(196, 202);
            Ship_8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Ship_8.Name = "Ship_8";
            Ship_8.Size = new System.Drawing.Size(57, 43);
            Ship_8.TabIndex = 16;
            Ship_8.TabStop = true;
            Ship_8.Text = "9";
            Ship_8.UseVisualStyleBackColor = false;
            Ship_8.CheckedChanged += Ship_8_CheckedChanged;
            // 
            // Ship_7
            // 
            Ship_7.AutoSize = true;
            Ship_7.BackColor = System.Drawing.Color.Transparent;
            Ship_7.Location = new System.Drawing.Point(122, 202);
            Ship_7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Ship_7.Name = "Ship_7";
            Ship_7.Size = new System.Drawing.Size(57, 43);
            Ship_7.TabIndex = 15;
            Ship_7.TabStop = true;
            Ship_7.Text = "8";
            Ship_7.UseVisualStyleBackColor = false;
            Ship_7.CheckedChanged += Ship_7_CheckedChanged;
            // 
            // Ship_6
            // 
            Ship_6.AutoSize = true;
            Ship_6.BackColor = System.Drawing.Color.Transparent;
            Ship_6.Location = new System.Drawing.Point(41, 202);
            Ship_6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Ship_6.Name = "Ship_6";
            Ship_6.Size = new System.Drawing.Size(57, 43);
            Ship_6.TabIndex = 14;
            Ship_6.TabStop = true;
            Ship_6.Text = "7";
            Ship_6.UseVisualStyleBackColor = false;
            Ship_6.CheckedChanged += Ship_6_CheckedChanged;
            // 
            // GroupAction
            // 
            GroupAction.Controls.Add(ChangeSpeed);
            GroupAction.Controls.Add(Go);
            GroupAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            GroupAction.Location = new System.Drawing.Point(28, 428);
            GroupAction.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            GroupAction.Name = "GroupAction";
            GroupAction.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            GroupAction.Size = new System.Drawing.Size(322, 218);
            GroupAction.TabIndex = 7;
            GroupAction.TabStop = false;
            GroupAction.Text = "Выбор действия";
            GroupAction.Visible = false;
            // 
            // GroupShip
            // 
            GroupShip.BackgroundImage = (System.Drawing.Image)resources.GetObject("GroupShip.BackgroundImage");
            GroupShip.Controls.Add(Ship_8);
            GroupShip.Controls.Add(Ship_7);
            GroupShip.Controls.Add(Ship_6);
            GroupShip.Controls.Add(Ship_5);
            GroupShip.Controls.Add(Ship_4);
            GroupShip.Controls.Add(Ship_3);
            GroupShip.Controls.Add(Ship_2);
            GroupShip.Controls.Add(Ship_1);
            GroupShip.Controls.Add(Ship_0);
            GroupShip.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            GroupShip.Location = new System.Drawing.Point(139, 95);
            GroupShip.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            GroupShip.Name = "GroupShip";
            GroupShip.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            GroupShip.Size = new System.Drawing.Size(292, 289);
            GroupShip.TabIndex = 17;
            GroupShip.TabStop = false;
            GroupShip.Text = "Корабли";
            GroupShip.Visible = false;
            // 
            // ShipInCenterLabel
            // 
            ShipInCenterLabel.AutoSize = true;
            ShipInCenterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ShipInCenterLabel.Location = new System.Drawing.Point(129, 781);
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
            MyShipsCenterLabel.Location = new System.Drawing.Point(173, 846);
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
            EnemyShipsCenterLebel.Location = new System.Drawing.Point(71, 909);
            EnemyShipsCenterLebel.Name = "EnemyShipsCenterLebel";
            EnemyShipsCenterLebel.Size = new System.Drawing.Size(207, 39);
            EnemyShipsCenterLebel.TabIndex = 21;
            EnemyShipsCenterLebel.Text = "Противника";
            EnemyShipsCenterLebel.Visible = false;
            // 
            // MyShipsCenterTextbox
            // 
            MyShipsCenterTextbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            MyShipsCenterTextbox.BackColor = System.Drawing.Color.White;
            MyShipsCenterTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            MyShipsCenterTextbox.Location = new System.Drawing.Point(294, 842);
            MyShipsCenterTextbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MyShipsCenterTextbox.Name = "MyShipsCenterTextbox";
            MyShipsCenterTextbox.ReadOnly = true;
            MyShipsCenterTextbox.Size = new System.Drawing.Size(85, 45);
            MyShipsCenterTextbox.TabIndex = 22;
            MyShipsCenterTextbox.Text = "0";
            MyShipsCenterTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            MyShipsCenterTextbox.Visible = false;
            // 
            // EnemyShipsCenterTextbox
            // 
            EnemyShipsCenterTextbox.AcceptsReturn = true;
            EnemyShipsCenterTextbox.BackColor = System.Drawing.Color.White;
            EnemyShipsCenterTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            EnemyShipsCenterTextbox.Location = new System.Drawing.Point(294, 909);
            EnemyShipsCenterTextbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            EnemyShipsCenterTextbox.Name = "EnemyShipsCenterTextbox";
            EnemyShipsCenterTextbox.ReadOnly = true;
            EnemyShipsCenterTextbox.Size = new System.Drawing.Size(85, 45);
            EnemyShipsCenterTextbox.TabIndex = 23;
            EnemyShipsCenterTextbox.Text = "0";
            EnemyShipsCenterTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            EnemyShipsCenterTextbox.Visible = false;
            // 
            // Start
            // 
            Start.BackColor = System.Drawing.SystemColors.Control;
            Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Start.Location = new System.Drawing.Point(139, 689);
            Start.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Start.Name = "Start";
            Start.Size = new System.Drawing.Size(268, 58);
            Start.TabIndex = 25;
            Start.Text = "Начать игру";
            Start.UseVisualStyleBackColor = false;
            Start.Visible = false;
            Start.Click += Start_Click;
            // 
            // Step
            // 
            Step.BackColor = System.Drawing.SystemColors.Control;
            Step.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Step.Location = new System.Drawing.Point(139, 744);
            Step.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Step.Name = "Step";
            Step.Size = new System.Drawing.Size(268, 58);
            Step.TabIndex = 26;
            Step.Text = "Ход";
            Step.UseVisualStyleBackColor = false;
            Step.Visible = false;
            Step.Click += Step_Click;
            // 
            // SpeedLable
            // 
            SpeedLable.AutoSize = true;
            SpeedLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            SpeedLable.Location = new System.Drawing.Point(370, 428);
            SpeedLable.Name = "SpeedLable";
            SpeedLable.Size = new System.Drawing.Size(138, 32);
            SpeedLable.TabIndex = 27;
            SpeedLable.Text = "Скорость";
            SpeedLable.Visible = false;
            // 
            // AutoPosChB
            // 
            AutoPosChB.AutoSize = true;
            AutoPosChB.Location = new System.Drawing.Point(370, 31);
            AutoPosChB.Name = "AutoPosChB";
            AutoPosChB.Size = new System.Drawing.Size(126, 24);
            AutoPosChB.TabIndex = 29;
            AutoPosChB.Text = "АвтоПозиция";
            AutoPosChB.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItem1, правилаToolStripMenuItem1 });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(1902, 28);
            menuStrip1.TabIndex = 33;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { NewGameToolStripMenuItem, SaveGameToolStripMenuItem, DownloadGameToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(57, 24);
            toolStripMenuItem1.Text = "Игра";
            // 
            // NewGameToolStripMenuItem
            // 
            NewGameToolStripMenuItem.Enabled = false;
            NewGameToolStripMenuItem.Name = "NewGameToolStripMenuItem";
            NewGameToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            NewGameToolStripMenuItem.Text = "Новая игра";
            NewGameToolStripMenuItem.Click += NewGameToolStripMenuItem_Click;
            // 
            // SaveGameToolStripMenuItem
            // 
            SaveGameToolStripMenuItem.Enabled = false;
            SaveGameToolStripMenuItem.Name = "SaveGameToolStripMenuItem";
            SaveGameToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            SaveGameToolStripMenuItem.Text = "Сохранить игру";
            SaveGameToolStripMenuItem.Click += SaveGameToolStripMenuItem_Click;
            // 
            // DownloadGameToolStripMenuItem
            // 
            DownloadGameToolStripMenuItem.Name = "DownloadGameToolStripMenuItem";
            DownloadGameToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            DownloadGameToolStripMenuItem.Text = "Загрузить игру";
            DownloadGameToolStripMenuItem.Click += DownloadGameToolStripMenuItem_Click;
            // 
            // правилаToolStripMenuItem1
            // 
            правилаToolStripMenuItem1.Name = "правилаToolStripMenuItem1";
            правилаToolStripMenuItem1.Size = new System.Drawing.Size(84, 24);
            правилаToolStripMenuItem1.Text = "Правила";
            правилаToolStripMenuItem1.Click += RulesToolStripMenuItem1_Click;
            // 
            // NewGameButtonMainForm
            // 
            NewGameButtonMainForm.BackColor = System.Drawing.SystemColors.Control;
            NewGameButtonMainForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            NewGameButtonMainForm.Location = new System.Drawing.Point(84, 994);
            NewGameButtonMainForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            NewGameButtonMainForm.Name = "NewGameButtonMainForm";
            NewGameButtonMainForm.Size = new System.Drawing.Size(389, 48);
            NewGameButtonMainForm.TabIndex = 18;
            NewGameButtonMainForm.Text = "Новая игра";
            NewGameButtonMainForm.UseVisualStyleBackColor = false;
            NewGameButtonMainForm.Click += NewGameButtonMainForm_Click;
            // 
            // GameExit
            // 
            GameExit.BackColor = System.Drawing.SystemColors.Control;
            GameExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            GameExit.Location = new System.Drawing.Point(1713, 955);
            GameExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            GameExit.Name = "GameExit";
            GameExit.Size = new System.Drawing.Size(177, 33);
            GameExit.TabIndex = 28;
            GameExit.Text = "Выйти из игры";
            GameExit.UseVisualStyleBackColor = false;
            GameExit.Click += GameExit_Click;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(411, 607);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(94, 29);
            button1.TabIndex = 34;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(1902, 1055);
            Controls.Add(button1);
            Controls.Add(GameExit);
            Controls.Add(AutoPosChB);
            Controls.Add(SpeedLable);
            Controls.Add(EnemyShipsCenterTextbox);
            Controls.Add(MyShipsCenterTextbox);
            Controls.Add(EnemyShipsCenterLebel);
            Controls.Add(MyShipsCenterLabel);
            Controls.Add(NewGameButtonMainForm);
            Controls.Add(ShipInCenterLabel);
            Controls.Add(GroupShip);
            Controls.Add(GroupAction);
            Controls.Add(ShowSpeed);
            Controls.Add(LessSpeed);
            Controls.Add(MoreSpeed);
            Controls.Add(pictureBox1);
            Controls.Add(OnPosition);
            Controls.Add(menuStrip1);
            Controls.Add(Step);
            Controls.Add(Start);
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "Гипер 6";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            GroupAction.ResumeLayout(false);
            GroupAction.PerformLayout();
            GroupShip.ResumeLayout(false);
            GroupShip.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RadioButton Go;
        private System.Windows.Forms.RadioButton ChangeSpeed;
        private System.Windows.Forms.Button MoreSpeed;
        private System.Windows.Forms.Button LessSpeed;
        private System.Windows.Forms.TextBox ShowSpeed;
        private System.Windows.Forms.RadioButton Ship_0;
        private System.Windows.Forms.RadioButton Ship_1;
        private System.Windows.Forms.RadioButton Ship_2;
        private System.Windows.Forms.RadioButton Ship_5;
        private System.Windows.Forms.RadioButton Ship_4;
        private System.Windows.Forms.RadioButton Ship_3;
        private System.Windows.Forms.RadioButton Ship_8;
        private System.Windows.Forms.RadioButton Ship_7;
        private System.Windows.Forms.RadioButton Ship_6;
        private System.Windows.Forms.GroupBox GroupAction;
        private System.Windows.Forms.Label ShipInCenterLabel;
        private System.Windows.Forms.Label MyShipsCenterLabel;
        private System.Windows.Forms.Label EnemyShipsCenterLebel;
        private System.Windows.Forms.TextBox MyShipsCenterTextbox;
        private System.Windows.Forms.TextBox EnemyShipsCenterTextbox;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Step;
        private System.Windows.Forms.Label SpeedLable;
        private System.Windows.Forms.CheckBox AutoPosChB;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem DownloadGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem правилаToolStripMenuItem1;
        private System.Windows.Forms.Button GameExit;
        public System.Windows.Forms.ToolStripMenuItem NewGameToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem SaveGameToolStripMenuItem;
        public System.Windows.Forms.GroupBox GroupShip;
        public System.Windows.Forms.Button OnPosition;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Button NewGameButtonMainForm;
        private System.Windows.Forms.Button button1;
    }
}

