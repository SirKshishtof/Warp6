﻿namespace Warp_6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            OnPosition_Button = new System.Windows.Forms.Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            Go_RadioButton = new System.Windows.Forms.RadioButton();
            ChangeSpeed_RadioButton = new System.Windows.Forms.RadioButton();
            MoreSpeed_Button = new System.Windows.Forms.Button();
            LessSpeed_Button = new System.Windows.Forms.Button();
            ShowSpeed_Textbox = new System.Windows.Forms.TextBox();
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
            ShipInCenter_Label = new System.Windows.Forms.Label();
            MyShipsCenter_Label = new System.Windows.Forms.Label();
            EnemyShipsCenter_Lebel = new System.Windows.Forms.Label();
            MyShipsCenter_Textbox = new System.Windows.Forms.TextBox();
            EnemyShipsCenter_Textbox = new System.Windows.Forms.TextBox();
            Step_Button = new System.Windows.Forms.Button();
            Speed_Lable = new System.Windows.Forms.Label();
            AutoPosChB = new System.Windows.Forms.CheckBox();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            Rules_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            NewGame_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            SaveGame_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            DownloadGame_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            GameExit_Buttom = new System.Windows.Forms.Button();
            NewGame_Buttom = new System.Windows.Forms.Button();
            DownloadGame_Buttom = new System.Windows.Forms.Button();
            SaveName_Label = new System.Windows.Forms.Label();
            SaveName_Textbox = new System.Windows.Forms.TextBox();
            СreateSave_Button = new System.Windows.Forms.Button();
            InvalidСharacters_Label = new System.Windows.Forms.Label();
            LoadingTheSelectedSave_Buttom = new System.Windows.Forms.Button();
            pictureBox = new System.Windows.Forms.PictureBox();
            Save_List = new System.Windows.Forms.ListBox();
            Code = new System.Windows.Forms.TextBox();
            PlayerTwoStep_Texbox = new System.Windows.Forms.TextBox();
            GroupAction.SuspendLayout();
            GroupShip.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // OnPosition_Button
            // 
            OnPosition_Button.BackColor = System.Drawing.SystemColors.Control;
            OnPosition_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            OnPosition_Button.Location = new System.Drawing.Point(129, 400);
            OnPosition_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            OnPosition_Button.Name = "OnPosition_Button";
            OnPosition_Button.Size = new System.Drawing.Size(268, 58);
            OnPosition_Button.TabIndex = 0;
            OnPosition_Button.Text = "На позицию";
            OnPosition_Button.UseVisualStyleBackColor = false;
            OnPosition_Button.Visible = false;
            OnPosition_Button.Click += OnPosition_Button_Click;
            // 
            // Go_RadioButton
            // 
            Go_RadioButton.AutoSize = true;
            Go_RadioButton.Checked = true;
            Go_RadioButton.Location = new System.Drawing.Point(20, 65);
            Go_RadioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Go_RadioButton.Name = "Go_RadioButton";
            Go_RadioButton.Size = new System.Drawing.Size(286, 43);
            Go_RadioButton.TabIndex = 2;
            Go_RadioButton.TabStop = true;
            Go_RadioButton.Text = "Передвижение ";
            Go_RadioButton.UseVisualStyleBackColor = true;
            Go_RadioButton.CheckedChanged += Go_RadioButton_CheckedChanged;
            // 
            // ChangeSpeed_RadioButton
            // 
            ChangeSpeed_RadioButton.AutoSize = true;
            ChangeSpeed_RadioButton.Location = new System.Drawing.Point(20, 126);
            ChangeSpeed_RadioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            ChangeSpeed_RadioButton.Name = "ChangeSpeed_RadioButton";
            ChangeSpeed_RadioButton.Size = new System.Drawing.Size(204, 82);
            ChangeSpeed_RadioButton.TabIndex = 3;
            ChangeSpeed_RadioButton.Text = "Изменить \r\nскорость";
            ChangeSpeed_RadioButton.UseVisualStyleBackColor = true;
            ChangeSpeed_RadioButton.CheckedChanged += ChangeSpeed_RadioButton_CheckedChanged;
            // 
            // MoreSpeed_Button
            // 
            MoreSpeed_Button.BackColor = System.Drawing.SystemColors.Control;
            MoreSpeed_Button.Enabled = false;
            MoreSpeed_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            MoreSpeed_Button.Location = new System.Drawing.Point(441, 559);
            MoreSpeed_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MoreSpeed_Button.Name = "MoreSpeed_Button";
            MoreSpeed_Button.Size = new System.Drawing.Size(42, 58);
            MoreSpeed_Button.TabIndex = 4;
            MoreSpeed_Button.Text = ">";
            MoreSpeed_Button.UseVisualStyleBackColor = false;
            MoreSpeed_Button.Visible = false;
            MoreSpeed_Button.Click += MoreSpeed_Button_Click;
            // 
            // LessSpeed_Button
            // 
            LessSpeed_Button.BackColor = System.Drawing.SystemColors.Control;
            LessSpeed_Button.Enabled = false;
            LessSpeed_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LessSpeed_Button.Location = new System.Drawing.Point(383, 560);
            LessSpeed_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            LessSpeed_Button.Name = "LessSpeed_Button";
            LessSpeed_Button.Size = new System.Drawing.Size(42, 56);
            LessSpeed_Button.TabIndex = 5;
            LessSpeed_Button.Text = "<";
            LessSpeed_Button.UseVisualStyleBackColor = false;
            LessSpeed_Button.Visible = false;
            LessSpeed_Button.Click += LessSpeed_Button_Click;
            // 
            // ShowSpeed_Textbox
            // 
            ShowSpeed_Textbox.BackColor = System.Drawing.Color.White;
            ShowSpeed_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ShowSpeed_Textbox.Location = new System.Drawing.Point(383, 497);
            ShowSpeed_Textbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            ShowSpeed_Textbox.Name = "ShowSpeed_Textbox";
            ShowSpeed_Textbox.ReadOnly = true;
            ShowSpeed_Textbox.Size = new System.Drawing.Size(100, 45);
            ShowSpeed_Textbox.TabIndex = 6;
            ShowSpeed_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            ShowSpeed_Textbox.Visible = false;
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
            Ship_6.Text = "7";
            Ship_6.UseVisualStyleBackColor = false;
            Ship_6.CheckedChanged += Ship_6_CheckedChanged;
            // 
            // GroupAction
            // 
            GroupAction.Controls.Add(ChangeSpeed_RadioButton);
            GroupAction.Controls.Add(Go_RadioButton);
            GroupAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            GroupAction.Location = new System.Drawing.Point(28, 451);
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
            GroupShip.Location = new System.Drawing.Point(115, 89);
            GroupShip.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            GroupShip.Name = "GroupShip";
            GroupShip.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            GroupShip.Size = new System.Drawing.Size(292, 289);
            GroupShip.TabIndex = 17;
            GroupShip.TabStop = false;
            GroupShip.Text = "Корабли";
            GroupShip.Visible = false;
            // 
            // ShipInCenter_Label
            // 
            ShipInCenter_Label.AutoSize = true;
            ShipInCenter_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ShipInCenter_Label.Location = new System.Drawing.Point(129, 781);
            ShipInCenter_Label.Name = "ShipInCenter_Label";
            ShipInCenter_Label.Size = new System.Drawing.Size(302, 39);
            ShipInCenter_Label.TabIndex = 19;
            ShipInCenter_Label.Text = "Корабли в центре";
            ShipInCenter_Label.Visible = false;
            // 
            // MyShipsCenter_Label
            // 
            MyShipsCenter_Label.AutoSize = true;
            MyShipsCenter_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            MyShipsCenter_Label.Location = new System.Drawing.Point(173, 846);
            MyShipsCenter_Label.Name = "MyShipsCenter_Label";
            MyShipsCenter_Label.Size = new System.Drawing.Size(105, 39);
            MyShipsCenter_Label.TabIndex = 20;
            MyShipsCenter_Label.Text = "Ваши";
            MyShipsCenter_Label.Visible = false;
            // 
            // EnemyShipsCenter_Lebel
            // 
            EnemyShipsCenter_Lebel.AutoSize = true;
            EnemyShipsCenter_Lebel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            EnemyShipsCenter_Lebel.Location = new System.Drawing.Point(71, 909);
            EnemyShipsCenter_Lebel.Name = "EnemyShipsCenter_Lebel";
            EnemyShipsCenter_Lebel.Size = new System.Drawing.Size(207, 39);
            EnemyShipsCenter_Lebel.TabIndex = 21;
            EnemyShipsCenter_Lebel.Text = "Противника";
            EnemyShipsCenter_Lebel.Visible = false;
            // 
            // MyShipsCenter_Textbox
            // 
            MyShipsCenter_Textbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            MyShipsCenter_Textbox.BackColor = System.Drawing.Color.White;
            MyShipsCenter_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            MyShipsCenter_Textbox.Location = new System.Drawing.Point(294, 842);
            MyShipsCenter_Textbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MyShipsCenter_Textbox.Name = "MyShipsCenter_Textbox";
            MyShipsCenter_Textbox.ReadOnly = true;
            MyShipsCenter_Textbox.Size = new System.Drawing.Size(85, 45);
            MyShipsCenter_Textbox.TabIndex = 22;
            MyShipsCenter_Textbox.Text = "0";
            MyShipsCenter_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            MyShipsCenter_Textbox.Visible = false;
            // 
            // EnemyShipsCenter_Textbox
            // 
            EnemyShipsCenter_Textbox.AcceptsReturn = true;
            EnemyShipsCenter_Textbox.BackColor = System.Drawing.Color.White;
            EnemyShipsCenter_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            EnemyShipsCenter_Textbox.Location = new System.Drawing.Point(294, 909);
            EnemyShipsCenter_Textbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            EnemyShipsCenter_Textbox.Name = "EnemyShipsCenter_Textbox";
            EnemyShipsCenter_Textbox.ReadOnly = true;
            EnemyShipsCenter_Textbox.Size = new System.Drawing.Size(85, 45);
            EnemyShipsCenter_Textbox.TabIndex = 23;
            EnemyShipsCenter_Textbox.Text = "0";
            EnemyShipsCenter_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            EnemyShipsCenter_Textbox.Visible = false;
            // 
            // Step_Button
            // 
            Step_Button.BackColor = System.Drawing.SystemColors.Control;
            Step_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Step_Button.Location = new System.Drawing.Point(156, 692);
            Step_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Step_Button.Name = "Step_Button";
            Step_Button.Size = new System.Drawing.Size(268, 58);
            Step_Button.TabIndex = 26;
            Step_Button.Text = "Ход";
            Step_Button.UseVisualStyleBackColor = false;
            Step_Button.Visible = false;
            Step_Button.Click += Step_Button_Click;
            // 
            // Speed_Lable
            // 
            Speed_Lable.AutoSize = true;
            Speed_Lable.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Speed_Lable.Location = new System.Drawing.Point(367, 461);
            Speed_Lable.Name = "Speed_Lable";
            Speed_Lable.Size = new System.Drawing.Size(138, 32);
            Speed_Lable.TabIndex = 27;
            Speed_Lable.Text = "Скорость";
            Speed_Lable.Visible = false;
            // 
            // AutoPosChB
            // 
            AutoPosChB.AutoSize = true;
            AutoPosChB.Location = new System.Drawing.Point(12, 369);
            AutoPosChB.Name = "AutoPosChB";
            AutoPosChB.Size = new System.Drawing.Size(126, 24);
            AutoPosChB.TabIndex = 29;
            AutoPosChB.Text = "АвтоПозиция";
            AutoPosChB.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { Rules_ToolStripMenuItem, NewGame_ToolStripMenuItem, SaveGame_ToolStripMenuItem, DownloadGame_ToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(1902, 28);
            menuStrip1.TabIndex = 33;
            menuStrip1.Text = "menuStrip1";
            // 
            // Rules_ToolStripMenuItem
            // 
            Rules_ToolStripMenuItem.Name = "Rules_ToolStripMenuItem";
            Rules_ToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            Rules_ToolStripMenuItem.Text = "Правила";
            Rules_ToolStripMenuItem.Click += Rules_ToolStripMenuItem_Click;
            // 
            // NewGame_ToolStripMenuItem
            // 
            NewGame_ToolStripMenuItem.Name = "NewGame_ToolStripMenuItem";
            NewGame_ToolStripMenuItem.Size = new System.Drawing.Size(103, 24);
            NewGame_ToolStripMenuItem.Text = "Новая игра";
            NewGame_ToolStripMenuItem.Visible = false;
            NewGame_ToolStripMenuItem.Click += NewGame_ToolStripMenuItem_Click_1;
            // 
            // SaveGame_ToolStripMenuItem
            // 
            SaveGame_ToolStripMenuItem.Name = "SaveGame_ToolStripMenuItem";
            SaveGame_ToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            SaveGame_ToolStripMenuItem.Text = "Сохранить игру";
            SaveGame_ToolStripMenuItem.Visible = false;
            SaveGame_ToolStripMenuItem.Click += SaveGame_ToolStripMenuItem_Click;
            // 
            // DownloadGame_ToolStripMenuItem
            // 
            DownloadGame_ToolStripMenuItem.Name = "DownloadGame_ToolStripMenuItem";
            DownloadGame_ToolStripMenuItem.Size = new System.Drawing.Size(126, 24);
            DownloadGame_ToolStripMenuItem.Text = "Загрузить игру";
            DownloadGame_ToolStripMenuItem.Visible = false;
            DownloadGame_ToolStripMenuItem.Click += DownloadGame_ToolStripMenuItem_Click;
            // 
            // GameExit_Buttom
            // 
            GameExit_Buttom.BackColor = System.Drawing.SystemColors.Control;
            GameExit_Buttom.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            GameExit_Buttom.Location = new System.Drawing.Point(780, 565);
            GameExit_Buttom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            GameExit_Buttom.Name = "GameExit_Buttom";
            GameExit_Buttom.Size = new System.Drawing.Size(360, 66);
            GameExit_Buttom.TabIndex = 28;
            GameExit_Buttom.Text = "Выйти из игры";
            GameExit_Buttom.UseVisualStyleBackColor = false;
            GameExit_Buttom.Click += GameExit_Buttom_Click;
            // 
            // NewGame_Buttom
            // 
            NewGame_Buttom.BackColor = System.Drawing.SystemColors.Control;
            NewGame_Buttom.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            NewGame_Buttom.Location = new System.Drawing.Point(780, 369);
            NewGame_Buttom.Name = "NewGame_Buttom";
            NewGame_Buttom.Size = new System.Drawing.Size(360, 66);
            NewGame_Buttom.TabIndex = 34;
            NewGame_Buttom.Text = "Новая игра";
            NewGame_Buttom.UseVisualStyleBackColor = false;
            NewGame_Buttom.Click += NewGame_Buttom_Click;
            // 
            // DownloadGame_Buttom
            // 
            DownloadGame_Buttom.BackColor = System.Drawing.SystemColors.Control;
            DownloadGame_Buttom.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            DownloadGame_Buttom.Location = new System.Drawing.Point(780, 468);
            DownloadGame_Buttom.Name = "DownloadGame_Buttom";
            DownloadGame_Buttom.Size = new System.Drawing.Size(360, 66);
            DownloadGame_Buttom.TabIndex = 35;
            DownloadGame_Buttom.Text = "Загрузить игру";
            DownloadGame_Buttom.UseVisualStyleBackColor = false;
            DownloadGame_Buttom.Click += DownloadGame_Buttom_Click;
            // 
            // SaveName_Label
            // 
            SaveName_Label.AutoSize = true;
            SaveName_Label.Location = new System.Drawing.Point(23, 39);
            SaveName_Label.Name = "SaveName_Label";
            SaveName_Label.Size = new System.Drawing.Size(167, 20);
            SaveName_Label.TabIndex = 37;
            SaveName_Label.Text = "Название сохранения:";
            SaveName_Label.Visible = false;
            // 
            // SaveName_Textbox
            // 
            SaveName_Textbox.Location = new System.Drawing.Point(192, 36);
            SaveName_Textbox.Name = "SaveName_Textbox";
            SaveName_Textbox.Size = new System.Drawing.Size(208, 27);
            SaveName_Textbox.TabIndex = 38;
            SaveName_Textbox.Visible = false;
            // 
            // СreateSave_Button
            // 
            СreateSave_Button.Location = new System.Drawing.Point(404, 35);
            СreateSave_Button.Name = "СreateSave_Button";
            СreateSave_Button.Size = new System.Drawing.Size(94, 29);
            СreateSave_Button.TabIndex = 39;
            СreateSave_Button.Text = "Сохранить";
            СreateSave_Button.UseVisualStyleBackColor = true;
            СreateSave_Button.Visible = false;
            СreateSave_Button.Click += СreateSave_Button_Click;
            // 
            // InvalidСharacters_Label
            // 
            InvalidСharacters_Label.AutoSize = true;
            InvalidСharacters_Label.ForeColor = System.Drawing.Color.Red;
            InvalidСharacters_Label.Location = new System.Drawing.Point(154, 65);
            InvalidСharacters_Label.Name = "InvalidСharacters_Label";
            InvalidСharacters_Label.Size = new System.Drawing.Size(277, 20);
            InvalidСharacters_Label.TabIndex = 40;
            InvalidСharacters_Label.Text = "Недопустимые символы: \\ / : * ? \" < > |";
            InvalidСharacters_Label.Visible = false;
            // 
            // LoadingTheSelectedSave_Buttom
            // 
            LoadingTheSelectedSave_Buttom.BackColor = System.Drawing.SystemColors.Control;
            LoadingTheSelectedSave_Buttom.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LoadingTheSelectedSave_Buttom.Location = new System.Drawing.Point(1278, 587);
            LoadingTheSelectedSave_Buttom.Name = "LoadingTheSelectedSave_Buttom";
            LoadingTheSelectedSave_Buttom.Size = new System.Drawing.Size(186, 44);
            LoadingTheSelectedSave_Buttom.TabIndex = 41;
            LoadingTheSelectedSave_Buttom.Text = "Загрузить";
            LoadingTheSelectedSave_Buttom.UseVisualStyleBackColor = false;
            LoadingTheSelectedSave_Buttom.Visible = false;
            LoadingTheSelectedSave_Buttom.Click += LoadingTheSelectedSave_Buttom_Click;
            // 
            // pictureBox
            // 
            pictureBox.BackColor = System.Drawing.Color.Transparent;
            pictureBox.Location = new System.Drawing.Point(513, 0);
            pictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new System.Drawing.Size(1389, 1055);
            pictureBox.TabIndex = 42;
            pictureBox.TabStop = false;
            // 
            // Save_List
            // 
            Save_List.FormattingEnabled = true;
            Save_List.ItemHeight = 20;
            Save_List.Location = new System.Drawing.Point(1156, 171);
            Save_List.Name = "Save_List";
            Save_List.Size = new System.Drawing.Size(404, 404);
            Save_List.TabIndex = 36;
            Save_List.Visible = false;
            // 
            // Code
            // 
            Code.Location = new System.Drawing.Point(23, 103);
            Code.Name = "Code";
            Code.Size = new System.Drawing.Size(65, 27);
            Code.TabIndex = 43;
            // 
            // PlayerTwoStep_Texbox
            // 
            PlayerTwoStep_Texbox.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            PlayerTwoStep_Texbox.Location = new System.Drawing.Point(1652, 39);
            PlayerTwoStep_Texbox.Name = "PlayerTwoStep_Texbox";
            PlayerTwoStep_Texbox.ReadOnly = true;
            PlayerTwoStep_Texbox.Size = new System.Drawing.Size(120, 38);
            PlayerTwoStep_Texbox.TabIndex = 45;
            PlayerTwoStep_Texbox.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(1902, 1055);
            Controls.Add(PlayerTwoStep_Texbox);
            Controls.Add(Code);
            Controls.Add(LoadingTheSelectedSave_Buttom);
            Controls.Add(InvalidСharacters_Label);
            Controls.Add(СreateSave_Button);
            Controls.Add(SaveName_Textbox);
            Controls.Add(SaveName_Label);
            Controls.Add(OnPosition_Button);
            Controls.Add(Save_List);
            Controls.Add(DownloadGame_Buttom);
            Controls.Add(NewGame_Buttom);
            Controls.Add(GameExit_Buttom);
            Controls.Add(AutoPosChB);
            Controls.Add(Speed_Lable);
            Controls.Add(Step_Button);
            Controls.Add(EnemyShipsCenter_Textbox);
            Controls.Add(MyShipsCenter_Textbox);
            Controls.Add(EnemyShipsCenter_Lebel);
            Controls.Add(MyShipsCenter_Label);
            Controls.Add(ShipInCenter_Label);
            Controls.Add(GroupShip);
            Controls.Add(GroupAction);
            Controls.Add(ShowSpeed_Textbox);
            Controls.Add(LessSpeed_Button);
            Controls.Add(MoreSpeed_Button);
            Controls.Add(pictureBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Гипер 6";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += Form1_Load;
            GroupAction.ResumeLayout(false);
            GroupAction.PerformLayout();
            GroupShip.ResumeLayout(false);
            GroupShip.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button OnPosition_Button;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RadioButton Go_RadioButton;
        private System.Windows.Forms.RadioButton ChangeSpeed_RadioButton;
        private System.Windows.Forms.Button MoreSpeed_Button;
        private System.Windows.Forms.Button LessSpeed_Button;
        private System.Windows.Forms.TextBox ShowSpeed_Textbox;
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
        private System.Windows.Forms.GroupBox GroupShip;
        private System.Windows.Forms.Label ShipInCenter_Label;
        private System.Windows.Forms.Label MyShipsCenter_Label;
        private System.Windows.Forms.Label EnemyShipsCenter_Lebel;
        private System.Windows.Forms.TextBox MyShipsCenter_Textbox;
        private System.Windows.Forms.TextBox EnemyShipsCenter_Textbox;
        private System.Windows.Forms.Button Step_Button;
        private System.Windows.Forms.Label Speed_Lable;
        private System.Windows.Forms.CheckBox AutoPosChB;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Rules_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewGame_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveGame_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DownloadGame_ToolStripMenuItem;
        private System.Windows.Forms.Button GameExit_Buttom;
        private System.Windows.Forms.Button NewGame_Buttom;
        private System.Windows.Forms.Button DownloadGame_Buttom;
        private System.Windows.Forms.Label SaveName_Label;
        private System.Windows.Forms.TextBox SaveName_Textbox;
        private System.Windows.Forms.Button СreateSave_Button;
        private System.Windows.Forms.Label InvalidСharacters_Label;
        private System.Windows.Forms.Button LoadingTheSelectedSave_Buttom;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ListBox Save_List;
        private System.Windows.Forms.TextBox Code;
        private System.Windows.Forms.TextBox PlayerTwoStep_Texbox;
    }
}

