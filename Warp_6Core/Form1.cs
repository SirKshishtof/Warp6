﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Ships;
using Drawing;

namespace Warp_6
{
    public partial class Form1 : Form
    {
        Display display;
        
        Ship[] myShips = new Ship[9];
        Enemy enemy = new Enemy();
        Random rnd = new Random();
        RadioButton[] shipRadioButtons = new RadioButton[9];

        short enemyShipsInCenter = 0;
        short myShipsInCenter = 0;
        short currentPoint = 125;
        string savePath = Directory.GetCurrentDirectory() + "\\Save\\";
        string rulesPath = Directory.GetCurrentDirectory() + "\\Rules.txt";

        const string messageYouWin= "Вы победили! Вам удалось опередить противника и выиграть эту битву! Империя гордиться вами! Начать заного?";
        const string messageBotWin = "Вы проиграли... Противник опередил вас и вы проиграли эту битву. Вы подвели империю. Начать заного?";
        
        
        void WhoGoesFirst()
        {
            string message;
            if (rnd.Next() % 2 != 0)
            {
                message = "О нет! Противник прибыл раньше вас! Вы ходите вторым.";
                short NumOfShip = enemy.list[0];
                SetShipOnSpiral(ref enemy.ships[NumOfShip], NumOfShip, ref currentPoint, false);
                display.DrawWhiteRectangle(NumOfShip, true);
                enemy.list.RemoveAt(0);
            }
            else
            {
                message = "Вам повезло! Противник еще не прибыл! Вы ходите первым.";
            }
            display.PictureBoxRefresh();
            display.DrawImage();
            MessageBox.Show(message, "Кто начинает");
        }
        void InitializationAllShipsSpeed()
        {
            for (short i = 0; i < 4; i++)
            {
                myShips[i].speed = (short)(rnd.Next() % 4 + 1);//Задание скорости корабля
                myShips[i].InGame = true;

                enemy.ships[i].speed = (short)(rnd.Next() % 4 + 1); ;//Задание скорости корабля
                enemy.ships[i].InGame = true;
            }

            for (short i = 4; i < 7; i++)
            {
                myShips[i].speed = (short)(rnd.Next() % 6 + 1);//Задание скорости корабля
                myShips[i].InGame = true;

                enemy.ships[i].speed = (short)(rnd.Next() % 6 + 1); ;//Задание скорости корабля
                enemy.ships[i].InGame = true;
            }

            for (short i = 7; i < 9; i++)
            {
                myShips[i].speed = (short)(rnd.Next() % 8 + 1);//Задание скорости корабля
                myShips[i].InGame = true;

                enemy.ships[i].speed = (short)(rnd.Next() % 8 + 1); ;//Задание скорости корабля
                enemy.ships[i].InGame = true;
            }
        }
        void SetShipOnSpiral(ref Ship ship, short numOfShip, ref short currentPoint, bool myShip)
        {
            ship.position = currentPoint;
            display.position[currentPoint].busy = true;
            switch (ship.type)
            {
                case 1: { display.DrawTriangle(myShip, display.X_CoordFromShip(ship), display.Y_CoordFromShip(ship), numOfShip + 1, ship.speed); } break;
                case 2: { display.DrawRectangle(myShip, display.X_CoordFromShip(ship), display.Y_CoordFromShip(ship), numOfShip + 1, ship.speed); } break;
                case 3: { display.DrawCircle(myShip, display.X_CoordFromShip(ship), display.Y_CoordFromShip(ship), numOfShip + 1, ship.speed); } break;
            }
            currentPoint--;
        }
        void ShipRadioButtonOff(int index)
        {
            shipRadioButtons[index].Checked = false;
            shipRadioButtons[index].Enabled = false;
            shipRadioButtons[index].BackColor = Color.WhiteSmoke;
        }
        short ShipSelection()
        {
            for (short i = 0; i < 9; i++)
            {
                if (shipRadioButtons[i].Checked) return i;
            }
            return -1;
        }
        bool MaxSppeed(Ship ship)
        {
            if (ship.type == 1 && ship.speed == 4 ||
                ship.type == 2 && ship.speed == 6 ||
                ship.type == 3 && ship.speed == 8) return true;

            return false;
        }
        void PrintSpeed(short numOfShip)
        {
            ShowSpeed.Text = myShips[numOfShip].speed.ToString();
            if (ChangeSpeed_RadioButton.Checked)
            {
                if (myShips[numOfShip].speed == 1)
                {
                    LessSpeed_Button.Enabled = false;
                    MoreSpeed_Button.Enabled = true;
                }
                else
                {
                    if (MaxSppeed(myShips[numOfShip]))
                    {
                        LessSpeed_Button.Enabled = true;
                        MoreSpeed_Button.Enabled = false;
                    }
                    else
                    {
                        LessSpeed_Button.Enabled = true;
                        MoreSpeed_Button.Enabled = true;
                    }
                }
            }
        }
        void AutoPos()
        {
            short NumOfShip;
            for (short i = 0; i < 10; i++)
            {
                NumOfShip = i;
                if (i != 9)
                {
                    SetShipOnSpiral(ref myShips[NumOfShip], NumOfShip, ref currentPoint, true);
                    ShipRadioButtonOff(NumOfShip);

                    display.DrawWhiteRectangle(NumOfShip, false);
                }
                if (enemy.list.Count > 0)
                {
                    NumOfShip = enemy.list[0];
                    SetShipOnSpiral(ref enemy.ships[NumOfShip], NumOfShip, ref currentPoint, false);
                    display.DrawWhiteRectangle(NumOfShip, true);
                    enemy.list.RemoveAt(0);

                    bool shipNotEnabled = true;
                    for (short j = 0; j < 9; j++)
                    {
                        if (shipRadioButtons[j].Enabled) { shipNotEnabled = false; break; }
                    }

                    if (enemy.list.Count == 0 && shipNotEnabled)
                    {
                        OnPosition_Button.Text = "Начать игру";
                        break;
                    }
                }
                else
                {
                    OnPosition_Button.Text = "Начать игру";
                }

            }
            AutoPosChB.Checked = false;
        }
        void ShipOutOfGame(TextBox ShipsCenterTextbox, ref Ship ship, ref short ShipsInCenter, short numOfShip, string message)
        {
            ShipsInCenter++;
            string winOrLoss = "Проигрыш...";
            if (message.Contains("Вы победили!")) { ShipRadioButtonOff(numOfShip); winOrLoss = "Победа!"; } 
            ShipsCenterTextbox.Text = ShipsInCenter.ToString();
            ship.InGame = false;
            if (myShipsInCenter == 6)
            {
                DialogResult result = MessageBox.Show(message, winOrLoss, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) Application.Restart();
                else Application.Exit();
            }
        }
        void MovingOfShip(TextBox ShipsCenterTextbox, ref Ship ship, ref short ShipsInCenter, short numOfShip, string message)
        {
            display.position[ship.position].busy = false;
            if ((ship.position - ship.speed) < 0) ShipOutOfGame(ShipsCenterTextbox, ref ship, ref ShipsInCenter, numOfShip, message);
            else
            {
                ship.position -= ship.speed;
                while (display.position[ship.position].busy && ship.InGame)
                {
                    if (display.position[ship.position].jump == -1) ShipOutOfGame(ShipsCenterTextbox, ref ship, ref ShipsInCenter, numOfShip, message);
                    else ship.position = display.position[ship.position].jump;
                }
                display.position[ship.position].busy = true;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //bitmap = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            //graph_bitmap = Graphics.FromImage(bitmap);
            //graphics = pictureBox.CreateGraphics();
            display = new Display(pictureBox);

            for (short i = 0; i < shipRadioButtons.Length; i++) shipRadioButtons[i] = new System.Windows.Forms.RadioButton();

            shipRadioButtons[0] = Ship_0;
            shipRadioButtons[1] = Ship_1;
            shipRadioButtons[2] = Ship_2;
            shipRadioButtons[3] = Ship_3;
            shipRadioButtons[4] = Ship_4;
            shipRadioButtons[5] = Ship_5;
            shipRadioButtons[6] = Ship_6;
            shipRadioButtons[7] = Ship_7;
            shipRadioButtons[8] = Ship_8;

            for (short i = 0; i < 4; i++)
            {
                myShips[i] = new Ship(1);
                enemy.ships[i] = new Ship(1);
            }

            for (short i = 4; i < 7; i++)
            {
                myShips[i] = new Ship(2);
                enemy.ships[i] = new Ship(2);
            }

            for (short i = 7; i < 9; i++)
            {
                myShips[i] = new Ship(3);
                enemy.ships[i] = new Ship(3);
            }

            enemy.EnemyShipSorting();
            Directory.CreateDirectory(savePath);
        }

        private void Ship_0_CheckedChanged(object sender, EventArgs e) => PrintSpeed(0);
        private void Ship_1_CheckedChanged(object sender, EventArgs e) => PrintSpeed(1);
        private void Ship_2_CheckedChanged(object sender, EventArgs e) => PrintSpeed(2);
        private void Ship_3_CheckedChanged(object sender, EventArgs e) => PrintSpeed(3);
        private void Ship_4_CheckedChanged(object sender, EventArgs e) => PrintSpeed(4);
        private void Ship_5_CheckedChanged(object sender, EventArgs e) => PrintSpeed(5);
        private void Ship_6_CheckedChanged(object sender, EventArgs e) => PrintSpeed(6);
        private void Ship_7_CheckedChanged(object sender, EventArgs e) => PrintSpeed(7);
        private void Ship_8_CheckedChanged(object sender, EventArgs e) => PrintSpeed(8);
        private void Go_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            LessSpeed_Button.Enabled = false;
            MoreSpeed_Button.Enabled = false;
        }
        private void ChangeSpeed_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            int numOfShip = ShipSelection();
            if (numOfShip != -1)
            {
                if (myShips[numOfShip].speed == 1)
                {

                    LessSpeed_Button.Enabled = false;
                    MoreSpeed_Button.Enabled = true;
                }
                else
                {
                    if (MaxSppeed(myShips[numOfShip]))
                    {
                        LessSpeed_Button.Enabled = true;
                        MoreSpeed_Button.Enabled = false;
                    }
                    else
                    {
                        LessSpeed_Button.Enabled = true;
                        MoreSpeed_Button.Enabled = true;
                    }
                }
            }
        }
        
        private void OnPosition_Button_Click(object sender, EventArgs e)
        {
            OnPosition_Button.Enabled = false;
            short NumOfShip = ShipSelection();

            AutoPosChB.Visible = false;
            if (AutoPosChB.Checked) { AutoPos(); }
            else
            {
                if (OnPosition_Button.Text == "На позицию")
                {
                    if (NumOfShip != -1)
                    {
                        ShipRadioButtonOff(NumOfShip);
                        SetShipOnSpiral(ref myShips[NumOfShip], NumOfShip, ref currentPoint, true);
                        display.DrawWhiteRectangle(NumOfShip, false);

                        if (enemy.list.Count > 0)
                        {
                            Thread.Sleep(1000);
                            NumOfShip = enemy.list[0];
                            SetShipOnSpiral(ref enemy.ships[NumOfShip], NumOfShip, ref currentPoint, false);
                            display.DrawWhiteRectangle(NumOfShip, true);
                            enemy.list.RemoveAt(0);

                            bool shipNotEnabled = true;
                            for (short j = 0; j < 9; j++)
                            {
                                if (shipRadioButtons[j].Enabled) { shipNotEnabled = false; break; }
                            }

                            if (enemy.list.Count == 0 && shipNotEnabled)
                            {
                                OnPosition_Button.Text = "Начать игру";
                            }
                        }
                        else
                        {
                            OnPosition_Button.Text = "Начать игру";
                        }
                    }
                }
                else
                {
                    OnPosition_Button.Visible = false;
                    Go_RadioButton.Checked = true;
                    GroupAction.Visible = true;
                    ShowSpeed.Visible = true;
                    MoreSpeed_Button.Visible = true;
                    LessSpeed_Button.Visible = true;
                    ShipInCenterLabel.Visible = true;
                    MyShipsCenterLabel.Visible = true;
                    EnemyShipsCenterLebel.Visible = true;
                    MyShipsCenterTextbox.Visible = true;
                    EnemyShipsCenterTextbox.Visible = true;
                    Step_Button.Visible = true;
                    for (short i = 0; i < 9; i++)
                    {
                        shipRadioButtons[i].Enabled = true;
                        shipRadioButtons[i].BackColor = Color.Transparent;
                    }
                    SpeedLable.Visible = true;
                    ShowSpeed.Text = "";
                }
            }

            OnPosition_Button.Enabled = true;
        }
        private void LessSpeed_Button_Click(object sender, EventArgs e)
        {
            int numOfShip = ShipSelection();

            if (numOfShip != -1)
            {
                myShips[numOfShip].speed--;
                if (Go_RadioButton.Enabled)
                {
                    LessSpeed_Button.Enabled = false;
                    Go_RadioButton.Enabled = false;
                    GroupShip.Enabled = false;
                }
                else
                {
                    Go_RadioButton.Enabled = true;
                    GroupShip.Enabled = true;
                }
                MoreSpeed_Button.Enabled = true;
                ShowSpeed.Text = myShips[numOfShip].speed.ToString();
                if (myShips[numOfShip].speed == 1) LessSpeed_Button.Enabled = false;
            }
        }
        private void MoreSpeed_Button_Click(object sender, EventArgs e)
        {
            int numOfShip = ShipSelection();

            if (numOfShip != -1)
            {
                myShips[numOfShip].speed++;
                if (Go_RadioButton.Enabled)
                {
                    MoreSpeed_Button.Enabled = false;
                    Go_RadioButton.Enabled = false;
                    GroupShip.Enabled = false;
                }
                else
                {
                    Go_RadioButton.Enabled = true;
                    GroupShip.Enabled = true;
                }
                LessSpeed_Button.Enabled = true;
                ShowSpeed.Text = myShips[numOfShip].speed.ToString();
                if (MaxSppeed(myShips[numOfShip])) MoreSpeed_Button.Enabled = false;
            }
        }
        private void Step_Button_Click(object sender, EventArgs e)
        {
            Step_Button.Enabled = false;
            short numOfShip = ShipSelection();
            bool playerMadeStep = false;
            if (numOfShip != -1)
            {
                if (Go_RadioButton.Checked)
                {
                    MovingOfShip(MyShipsCenterTextbox, ref myShips[numOfShip], ref myShipsInCenter, numOfShip, messageYouWin);
                    playerMadeStep = true;
                }
                else
                {
                    if (!Go_RadioButton.Enabled)
                    {
                        Go_RadioButton.Checked = true;
                        Go_RadioButton.Enabled = true;
                        MoreSpeed_Button.Enabled = true;
                        LessSpeed_Button.Enabled = true;
                        GroupShip.Enabled = true;
                        LessSpeed_Button.Enabled = false;
                        MoreSpeed_Button.Enabled = false;
                        playerMadeStep = true;
                    }
                    else MessageBox.Show("Скорость не была изменена. Ход не закончен.", "Внимание!");
                }
            }
            else MessageBox.Show("Корабль не был выбран. Ход не закончен.", "Внимание!");
            

            if (playerMadeStep)
            {

                display.DrawMapAndShips(myShips, enemy.ships);
            }

            Step_Button.Enabled = true;
        }
        private void СreateSave_Button_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex("[\\\\/:*?\"<>|]");
            MatchCollection matches = reg.Matches(SaveName_Textbox.Text);
            if (matches.Count == 0)
            {
                StreamWriter SaveFile = new StreamWriter(savePath + SaveName_Textbox.Text + ".txt");

                for (int i = 0; i < 9; i++)
                {
                    SaveFile.WriteLine(myShips[i].speed);
                    SaveFile.WriteLine(myShips[i].position);
                    SaveFile.WriteLine(myShips[i].InGame);

                    SaveFile.WriteLine(enemy.ships[i].speed);
                    SaveFile.WriteLine(enemy.ships[i].position);
                    SaveFile.WriteLine(enemy.ships[i].InGame);
                }
                SaveFile.WriteLine(myShipsInCenter);
                SaveFile.WriteLine(enemyShipsInCenter);
                SaveFile.WriteLine(enemy.list.Count);
                for (short i = 0; i < enemy.list.Count; i++) SaveFile.WriteLine(enemy.list[i]);
                SaveFile.WriteLine(currentPoint);
                SaveFile.Close();

                InvalidСharacters_Label.Visible = false;
                СreateSave_Button.Visible = false;
                SaveName_Label.Visible = false;
                SaveName_Textbox.Visible = false;
                SaveGame_ToolStripMenuItem.Text = "Сохранить игру";
                Go_RadioButton.Enabled = true;
                Step_Button.Enabled = true;
                GroupShip.Enabled = true;
                OnPosition_Button.Enabled = true;
                GroupAction.Enabled = true;
                GroupAction.Enabled = true;
                DownloadGame_ToolStripMenuItem.Enabled = true;
                NewGame_ToolStripMenuItem.Enabled = true;
            }
            else InvalidСharacters_Label.Visible = true;
        }
        private void NewGame_Buttom_Click(object sender, EventArgs e)
        {
            NewGame_Buttom.Visible = false;
            OnPosition_Button.Visible = true;
            GroupShip.Visible = true;
            NewGame_Buttom.Visible = false;
            DownloadGame_Buttom.Visible = false;
            NewGame_ToolStripMenuItem.Visible = true;
            DownloadGame_ToolStripMenuItem.Visible = true;
            SaveGame_ToolStripMenuItem.Visible = true;
            GameExit_Buttom.Width = 177;
            GameExit_Buttom.Height = 33;
            GameExit_Buttom.Location = new Point(1713, 955);
            GameExit_Buttom.Font = new Font("Segoe UI", 12);
            myShipsInCenter = 0;
            enemyShipsInCenter = 0;

            InitializationAllShipsSpeed();
            enemy.EnemyShipSorting();
            display.DrawMap();
            display.DrawingShipsOnSides(myShips, enemy.ships);
            WhoGoesFirst();
        }
        private void DownloadGame_Buttom_Click(object sender, EventArgs e)
        {
            if (DownloadGame_Buttom.Text == "Загрузить игру")
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(savePath);
                FileInfo[] files = directoryInfo.GetFiles("*.txt");

                foreach (FileInfo fi in files)
                {
                    SaveList.Items.Add(fi.Name.ToString().Replace(".txt", ""));
                }

                SaveList.Visible = true;
                LoadingTheSelectedSave_Buttom.Visible = true;
                NewGame_Buttom.Enabled = false;
                GameExit_Buttom.Enabled = false;
                DownloadGame_Buttom.Text = "Назад";
            }
            else
            {
                SaveList.Visible = false;
                LoadingTheSelectedSave_Buttom.Visible = false;
                NewGame_Buttom.Enabled = true;
                GameExit_Buttom.Enabled = true;
                DownloadGame_Buttom.Text = "Загрузить игру";
            }
        }
        private void LoadingTheSelectedSave_Buttom_Click(object sender, EventArgs e)
        {
            bool wantToLoad = true;
            
            if (File.Exists(savePath + SaveList.SelectedItem + ".txt"))
            {
                if (!NewGame_Buttom.Visible)
                {   
                    DialogResult result = MessageBox.Show("Хотите загрузить игру?\n Весь не сохранённый прогресс будет потерян.", "Загрузка", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                    {
                        wantToLoad = false;
                    }
                    else
                    {
                        DownloadGame_ToolStripMenuItem.Text = "Загрузить игру";
                        GroupShip.Enabled = true;
                    }
                }
                else
                {
                    NewGame_Buttom.Visible = false;
                    DownloadGame_Buttom.Visible = false;
                    GameExit_Buttom.Enabled = true;
                    GameExit_Buttom.Width = 177;
                    GameExit_Buttom.Height = 33;
                    GameExit_Buttom.Location = new Point(1713, 955);
                    GameExit_Buttom.Font = new Font("Segoe UI", 12);
                    GroupShip.Visible = true;
                    NewGame_ToolStripMenuItem.Visible = true;
                    DownloadGame_ToolStripMenuItem.Visible = true;
                    SaveGame_ToolStripMenuItem.Visible = true;
                }

                if (wantToLoad)
                {                    
                    LoadingTheSelectedSave_Buttom.Visible = false;
                    SaveList.Visible = false;
                    GroupShip.Enabled = true;
                    Go_RadioButton.Enabled = true;
                    GroupAction.Enabled = true;
                    GroupAction.Enabled = true;
                    Step_Button.Enabled = true;
                    OnPosition_Button.Enabled = true;
                    DownloadGame_ToolStripMenuItem.Enabled = true;
                    SaveGame_ToolStripMenuItem.Enabled = true;
                    NewGame_ToolStripMenuItem.Enabled = true;

                    StreamReader SaveFile = new StreamReader(savePath + SaveList.SelectedItem + ".txt");
                    const float xLeft = 130;
                    const float xRight = 1300;
                    float yOnSide = 160;
                    float x = 0;
                    float y = 0;
                    float shift = 80;
                    bool onPosition = false;

                    for (short i = 0; i < 126; i++) display.position[i].busy = false;

                    for (short i = 0; i < 9; i++)
                    {
                        myShips[i].speed = short.Parse(SaveFile.ReadLine());
                        myShips[i].position = short.Parse(SaveFile.ReadLine());
                        myShips[i].InGame = bool.Parse(SaveFile.ReadLine());
                        if (myShips[i].position > -1) display.position[myShips[i].position].busy = true;

                        enemy.ships[i].speed = short.Parse(SaveFile.ReadLine());
                        enemy.ships[i].position = short.Parse(SaveFile.ReadLine());
                        enemy.ships[i].InGame = bool.Parse(SaveFile.ReadLine());
                        if (enemy.ships[i].position > -1) display.position[enemy.ships[i].position].busy = true;
                    }

                    myShipsInCenter = short.Parse(SaveFile.ReadLine());
                    enemyShipsInCenter = short.Parse(SaveFile.ReadLine());
                    MyShipsCenterTextbox.Text = myShipsInCenter.ToString();
                    EnemyShipsCenterTextbox.Text = enemyShipsInCenter.ToString();
                    short listCount = short.Parse(SaveFile.ReadLine());
                    enemy.list.Clear();
                    while (listCount > 0)
                    {
                        enemy.list.Add(short.Parse(SaveFile.ReadLine()));
                        listCount--;
                    }
                    currentPoint = short.Parse(SaveFile.ReadLine());
                    SaveFile.Close();
                    display.DrawMap();



                    for (short i = 0; i < 4; i++)
                    {
                        if (myShips[i].InGame) 
                        {
                            if (myShips[i].position == -1) { x = xLeft; y = yOnSide; onPosition = true; }
                            else { x = display.X_CoordFromShip(myShips[i]); y = display.Y_CoordFromShip(myShips[i]); }
                            display.DrawTriangle(true, x, y, i + 1, myShips[i].speed);
                        }

                        if (enemy.ships[i].InGame)
                        {
                            if (enemy.ships[i].position == -1) { x = xRight; y = yOnSide; }
                            else { x = display.X_CoordFromShip(enemy.ships[i]); y = display.Y_CoordFromShip(enemy.ships[i]); }
                            display.DrawTriangle(false, x, y, i + 1, enemy.ships[i].speed);
                        }

                        yOnSide += shift;
                    }

                    for (short i = 4; i < 7; i++)
                    {
                        if (myShips[i].InGame)
                        {
                            if (myShips[i].position == -1) { x = xLeft; y = yOnSide; onPosition = true; }
                            else { x = display.X_CoordFromShip(myShips[i]); y = display.Y_CoordFromShip(myShips[i]); }
                            display.DrawRectangle(true, x, y, i + 1, myShips[i].speed);
                        }

                        if (enemy.ships[i].InGame)
                        {
                            if (enemy.ships[i].position == -1) { x = xRight; y = yOnSide; }
                            else { x = display.X_CoordFromShip(enemy.ships[i]); y = display.Y_CoordFromShip(enemy.ships[i]); }
                            display.DrawRectangle(false, x, y, i + 1, enemy.ships[i].speed);
                        }

                        yOnSide += shift;
                    }

                    for (short i = 7; i < 9; i++)
                    {
                        if (myShips[i].InGame)
                        {
                            if (myShips[i].position == -1) { x = xLeft; y = yOnSide; onPosition = true; }
                            else { x = display.X_CoordFromShip(myShips[i]); y = display.Y_CoordFromShip(myShips[i]); }
                            display.DrawCircle(true, x, y, i + 1, myShips[i].speed);
                        }

                        if (enemy.ships[i].InGame)
                        {
                            if (enemy.ships[i].position == -1) { x = xRight; y = yOnSide; }
                            else { x = display.X_CoordFromShip(enemy.ships[i]); y = display.Y_CoordFromShip(enemy.ships[i]); }
                            display.DrawCircle(false, x, y, i + 1, enemy.ships[i].speed);
                        }
                       
                        yOnSide += shift;
                    }

                    if (onPosition)
                    {
                        OnPosition_Button.Visible = true;
                        OnPosition_Button.Enabled = true;
                        OnPosition_Button.Text = "На позицию";

                        for (short i = 0; i < 9; i++)
                        {
                            if (myShips[i].position == -1)
                            {
                                shipRadioButtons[i].Enabled = true;
                                shipRadioButtons[i].BackColor = Color.Transparent;
                            }
                            else
                            {
                                shipRadioButtons[i].Enabled = false;
                                shipRadioButtons[i].BackColor = Color.WhiteSmoke;
                            }
                        }
                    }
                    else
                    {
                        for (short i = 125; i < 107; i++) if (!display.position[i].busy) { onPosition = false; break; }

                        if (!onPosition)
                        {
                            OnPosition_Button.Visible = true;
                            OnPosition_Button.Enabled = true;
                            OnPosition_Button.Text = "Начать игру";
                        }
                        else
                        {   
                            OnPosition_Button.Visible = false;
                            Go_RadioButton.Checked = true;
                            GroupAction.Visible = true;
                            MoreSpeed_Button.Visible = true;
                            LessSpeed_Button.Visible = true;
                            Step_Button.Visible = true;
                            ShowSpeed.Visible = true;
                            ShipInCenterLabel.Visible = true;
                            MyShipsCenterLabel.Visible = true;
                            MyShipsCenterTextbox.Visible = true;
                            EnemyShipsCenterLebel.Visible = true;
                            EnemyShipsCenterTextbox.Visible = true;
                            LoadingTheSelectedSave_Buttom.Visible = false;
                            SaveList.Visible = false;

                            for (short i = 0; i < 9; i++)
                            {
                                if (myShips[i].InGame)
                                {
                                    shipRadioButtons[i].Enabled = true;
                                    shipRadioButtons[i].BackColor = Color.Transparent;
                                }
                                else
                                {
                                    shipRadioButtons[i].Enabled = false;
                                    shipRadioButtons[i].BackColor = Color.WhiteSmoke;
                                }
                            }

                            SpeedLable.Visible = true;
                            ShowSpeed.Text = "";
                        }
                    }
                    this.Refresh();
                    display.graphics.DrawImage(display.bitmap, 0, 0, pictureBox.Size.Width, pictureBox.Size.Height);
                }
            }
        }
        private void GameExit_Buttom_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Хотите выйти из игры?\n Весь не сохранённый прогресс будет потерян.", "Выход", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else Application.Restart();
        }

        private void Rules_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(rulesPath))
            {
                StreamReader rulesFile = new StreamReader(rulesPath);
                string mes = rulesFile.ReadToEnd();
                rulesFile.Close();
                MessageBox.Show(mes, "Правила");
            }
        }
        private void NewGame_ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Хотите начать новую игру?\n Весь не сохранённый прогресс будет потерян.", "Новая игра", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                NewGame_Buttom.Visible = false;
                OnPosition_Button.Visible = true;
                OnPosition_Button.Text = "На позицию";
                Go_RadioButton.Checked = false;
                GroupAction.Visible = false;
                ShowSpeed.Visible = false;
                MoreSpeed_Button.Visible = false;
                LessSpeed_Button.Visible = false;
                ShipInCenterLabel.Visible = false;
                MyShipsCenterLabel.Visible = false;
                EnemyShipsCenterLebel.Visible = false;
                MyShipsCenterTextbox.Visible = false;
                EnemyShipsCenterTextbox.Visible = false;
                Step_Button.Visible = false;
                AutoPosChB.Visible = true;
                AutoPosChB.Checked = false;
                SpeedLable.Visible = false;
                OnPosition_Button.Visible = true;
                myShipsInCenter = 0;
                enemyShipsInCenter = 0;
                enemyShipsInCenter = 0;
                myShipsInCenter = 0;
                currentPoint = 125;

                for (short i = 0; i < 9; i++)
                {
                    shipRadioButtons[i].Enabled = true;
                    shipRadioButtons[i].BackColor = Color.Transparent;
                }
                myShips = new Ship[9];
                enemy = new Enemy();
                InitializationAllShipsSpeed();
                enemy.EnemyShipSorting();
                display.DrawMap();
                display.DrawingShipsOnSides(myShips, enemy.ships);
                WhoGoesFirst();
            }
        }
        private void SaveGame_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveGame_ToolStripMenuItem.Text == "Сохранить игру")
            {
                СreateSave_Button.Visible = true;
                SaveName_Label.Visible = true;
                SaveName_Textbox.Visible = true;
                SaveGame_ToolStripMenuItem.Text = "Отменить сохранение";
                string str = DateTime.Now.ToString().Replace(":", ".").Replace(" ", "  ");

                SaveName_Textbox.Text = str;

                GroupShip.Enabled = false;
                Go_RadioButton.Checked = true;
                Go_RadioButton.Enabled = false;
                GroupAction.Enabled = false;
                GroupAction.Enabled = false;
                Step_Button.Enabled = false;
                OnPosition_Button.Enabled = false;
                DownloadGame_ToolStripMenuItem.Enabled = false;
                NewGame_ToolStripMenuItem.Enabled = false;
            }
            else
            {
                СreateSave_Button.Visible = false;
                SaveName_Label.Visible = false;
                SaveName_Textbox.Visible = false;
                SaveGame_ToolStripMenuItem.Text = "Сохранить игру";

                GroupShip.Enabled = true;
                Go_RadioButton.Enabled = true;
                GroupAction.Enabled = true;
                GroupAction.Enabled = true;
                Step_Button.Enabled = true;
                OnPosition_Button.Enabled = true;
                DownloadGame_ToolStripMenuItem.Enabled = true;
                NewGame_ToolStripMenuItem.Enabled = true;
            }
        }
        private void DownloadGame_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DownloadGame_ToolStripMenuItem.Text == "Загрузить игру")
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(savePath);
                FileInfo[] files = directoryInfo.GetFiles("*.txt");
                SaveList.Items.Clear();
                foreach (FileInfo fi in files)
                {
                    SaveList.Items.Add(fi.Name.ToString().Replace(".txt", ""));
                }

                SaveList.Location = new Point(758, 289);
                LoadingTheSelectedSave_Buttom.Location = new Point(867, 695);
                SaveList.Visible = true;
                LoadingTheSelectedSave_Buttom.Visible = true;
                DownloadGame_ToolStripMenuItem.Text = "Отменить загрузку";
                GroupShip.Enabled = false;
                Go_RadioButton.Checked = true;
                Go_RadioButton.Enabled = false;
                GroupAction.Enabled = false;
                GroupAction.Enabled = false;
                Step_Button.Enabled = false;
                OnPosition_Button.Enabled = false;
                SaveGame_ToolStripMenuItem.Enabled = false;
                NewGame_ToolStripMenuItem.Enabled = false;
            }
            else
            {
                SaveList.Visible = false;
                LoadingTheSelectedSave_Buttom.Visible = false;
                DownloadGame_ToolStripMenuItem.Text = "Загрузить игру";

                GroupShip.Enabled = true;
                Go_RadioButton.Enabled = true;
                GroupAction.Enabled = true;
                GroupAction.Enabled = true;
                Step_Button.Enabled = true;
                OnPosition_Button.Enabled = true;
                SaveGame_ToolStripMenuItem.Enabled = true;
                NewGame_ToolStripMenuItem.Enabled = true;

                pictureBox.Refresh();
                display.graphics.DrawImage(display.bitmap, 0, 0, pictureBox.Size.Width, pictureBox.Size.Height);
            }
        }
    }
}