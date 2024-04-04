using System;
using System.Drawing;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Players;
using Drawing;
using Game;

namespace Warp_6
{
    public partial class Form1 : Form
    {
        Enemy enemy = new Enemy();
        RadioButton[] shipRadioButtons = new RadioButton[9];
        Player playerOne;
        //Player playerTwo;
        bool greenGoesFirst = true;
        string savePath = Directory.GetCurrentDirectory() + "\\Save\\";
        string rulesPath = Directory.GetCurrentDirectory() + "\\Rules.txt";
        
        const string messageYouWin= "Вы победили! Вам удалось опередить противника и выиграть эту битву! Империя гордиться вами! Начать заного?";
        const string messageBotWin = "Вы проиграли... Противник опередил вас и вы проиграли эту битву. Вы подвели империю. Начать заного?";
        
        public void ShipRadioButtonOff(int index)
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
        void PrintSpeed(short numOfShip)
        {
            ShowSpeed_Textbox.Text = playerOne.ships[numOfShip].speed.ToString();
            if (ChangeSpeed_RadioButton.Checked)
            {
                if (playerOne.ships[numOfShip].speed == 1)
                {
                    LessSpeed_Button.Enabled = false;
                    MoreSpeed_Button.Enabled = true;
                }
                else
                {
                    if (Gameplay.MaxSppeed(playerOne.ships[numOfShip]))
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
        void MainMenu_Off()
        {
            NewGame_Buttom.Visible = false;
            DownloadGame_Buttom.Visible = false;
            GroupShip.Visible = true;
            NewGame_ToolStripMenuItem.Visible = true;
            DownloadGame_ToolStripMenuItem.Visible = true;
            SaveGame_ToolStripMenuItem.Visible = true;
            GameExit_Buttom.Enabled = true;
            GameExit_Buttom.Width = 177;
            GameExit_Buttom.Height = 33;
            GameExit_Buttom.Location = new Point(1713, 955);
            GameExit_Buttom.Font = new Font("Segoe UI", 12);
            
        }
        void DownloadMenu_OnOff(bool on)
        {
            Save_List.Visible = on;
            LoadingTheSelectedSave_Buttom.Visible = on;
            NewGame_Buttom.Enabled = !on;
            GameExit_Buttom.Enabled = !on;
        }
        void SaveGame_OnOff(bool on)
        {
            СreateSave_Button.Visible = on;
            SaveName_Label.Visible = on;
            SaveName_Textbox.Visible = on;
            DownloadGame_ToolStripMenuItem.Enabled = !on;
            NewGame_ToolStripMenuItem.Enabled = !on;
            if (on) SaveGame_ToolStripMenuItem.Text = "Отменить сохранение";
            else SaveGame_ToolStripMenuItem.Text = "Сохранить игру";

        }
        void DownloadGame_OnOff(bool on)
        {
            Save_List.Visible = on;
            LoadingTheSelectedSave_Buttom.Visible = on;
            SaveGame_ToolStripMenuItem.Enabled = !on;
            NewGame_ToolStripMenuItem.Enabled = !on;
            if (on) DownloadGame_ToolStripMenuItem.Text = "Отменить загрузку";
            else DownloadGame_ToolStripMenuItem.Text = "Загрузить игру";
        }
        void ActionItems_OnOff(bool on)
        {
            GroupShip.Enabled = on;
            Go_RadioButton.Enabled = on;
            GroupAction.Enabled = on;
            Step_Button.Enabled = on;
            OnPosition_Button.Enabled = on;
            NewGame_ToolStripMenuItem.Enabled = on;
        }
        void PositionButtonVisible(bool on, bool startGame)
        {
            OnPosition_Button.Visible = on;
            Step_Button.Visible = !on;
            if (startGame) OnPosition_Button.Text = "Начать игру";
            else OnPosition_Button.Text = "На позицию";
        }
        void ActionItemsVisible(bool on)
        {
            GroupAction.Visible = on;
            ShowSpeed_Textbox.Visible = on;
            Speed_Lable.Visible = on;
            MoreSpeed_Button.Visible = on;
            LessSpeed_Button.Visible = on;
            ShipInCenter_Label.Visible = on;
            PlayerOneShipsCenter_Label.Visible = on;
            PlayerTwoShipsCenter_Lebel.Visible = on;
            PlayerOneShipsCenter_Textbox.Visible = on;
            PlayerTwoShipsCenter_Textbox.Visible = on;
            Step_Button.Visible = on;
            PlayerTwoStep_Texbox.Visible = on;
            PlayerTwoStep_Texbox.Text = "";
        }
        void ActionItemsEnabled(bool on)
        {
            Go_RadioButton.Enabled = on;
            Step_Button.Enabled = on;
            GroupShip.Enabled = on;
            OnPosition_Button.Enabled = on;
            GroupAction.Enabled = on;
            GroupAction.Enabled = on;
            DownloadGame_ToolStripMenuItem.Enabled = on;
            NewGame_ToolStripMenuItem.Enabled = on;
            SaveGame_ToolStripMenuItem.Enabled = on;
        }
        void ShipRadioButtons_OnOff(short index, bool on)
        {
            shipRadioButtons[index].Enabled = on;
            if (on) shipRadioButtons[index].BackColor = Color.Transparent;
            else shipRadioButtons[index].BackColor = Color.WhiteSmoke;
        }
        void EnemyStep()
        {
            short action = enemy.RandomStep();
            Code.Text = action.ToString();
            if (action == -1) action = -10;
            short numOfShip = (short)(action / 100);
            action = (short)(action % 100);
            switch (action)
            {
                case 0:
                    {
                        Gameplay.MovingOfShip( ref enemy.player.ships[numOfShip], ref enemy.player.shipInCerter, messageBotWin);
                        PlayerTwoShipsCenter_Textbox.Text = enemy.player.shipInCerter.ToString();
                        PlayerTwoStep_Texbox.Text = "  " + (numOfShip + 1) + ":  Move";
                    }
                    break;
                case 10: PlayerTwoStep_Texbox.Text = "  " + (numOfShip + 1) + ":  " + enemy.player.ships[numOfShip].speed + " -> " + (--enemy.player.ships[numOfShip].speed); break;
                case 11: PlayerTwoStep_Texbox.Text = "  " + (numOfShip + 1) + ":  " + enemy.player.ships[numOfShip].speed + " -> " + (++enemy.player.ships[numOfShip].speed); break;
            }
            Thread.Sleep(1500);
            Display.DrawMapAndShips(playerOne.ships, enemy.player.ships);
        }
        void AutoPos()
        {
            short NumOfShip;
            for (short i = 0; i < 10; i++)
            {
                NumOfShip = i;
                if (i != 9)
                {
                    Gameplay.SetShipOnSpiral(ref playerOne.ships[NumOfShip], playerOne.brush);
                    ShipRadioButtonOff(NumOfShip);

                    Display.DrawWhiteRectangle(NumOfShip, false);
                }
                if (enemy.list.Count > 0)
                {
                    NumOfShip = enemy.list[0];
                    Gameplay.SetShipOnSpiral(ref enemy.player.ships[NumOfShip], enemy.player.brush);
                    Display.DrawWhiteRectangle(NumOfShip, true);
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
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Display.InitializationMap(pictureBox);
            for (short i = 0; i < shipRadioButtons.Length; i++) shipRadioButtons[i] = new RadioButton();

            shipRadioButtons[0] = Ship_0;
            shipRadioButtons[1] = Ship_1;
            shipRadioButtons[2] = Ship_2;
            shipRadioButtons[3] = Ship_3;
            shipRadioButtons[4] = Ship_4;
            shipRadioButtons[5] = Ship_5;
            shipRadioButtons[6] = Ship_6;
            shipRadioButtons[7] = Ship_7;
            shipRadioButtons[8] = Ship_8;

            playerOne = new Player(true);
            enemy.player = new Player(false);
            
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
                if (playerOne.ships[numOfShip].speed == 1)
                {

                    LessSpeed_Button.Enabled = false;
                    MoreSpeed_Button.Enabled = true;
                }
                else
                {
                    if (Gameplay.MaxSppeed(playerOne.ships[numOfShip]))
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
                        Gameplay.SetShipOnSpiral(ref playerOne.ships[NumOfShip], playerOne.brush);
                        Display.DrawWhiteRectangle(NumOfShip, false);

                        if (enemy.list.Count > 0)
                        {
                            Thread.Sleep(1000);
                            NumOfShip = enemy.list[0];
                            Gameplay.SetShipOnSpiral(ref enemy.player.ships[NumOfShip], enemy.player.brush);
                            Display.DrawWhiteRectangle(NumOfShip, true);
                            enemy.list.RemoveAt(0);

                            bool shipNotEnabled = true;
                            
                            if (enemy.list.Count == 0)
                            {
                                for (short j = 0; j < 9; j++) if (shipRadioButtons[j].Enabled) { shipNotEnabled = false; break; }
                                if (shipNotEnabled) OnPosition_Button.Text = "Начать игру";
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
                    PositionButtonVisible(false, false);
                    ActionItemsVisible(true);
                    if (!greenGoesFirst) EnemyStep();
                    for (short i = 0; i < 9; i++)
                    {
                        ShipRadioButtons_OnOff(i, true);
                    }
                    ShowSpeed_Textbox.Text = "";
                }
            }

            OnPosition_Button.Enabled = true;
        }
        private void LessSpeed_Button_Click(object sender, EventArgs e)
        {
            int numOfShip = ShipSelection();

            if (numOfShip != -1)
            {
                playerOne.ships[numOfShip].speed--;
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
                ShowSpeed_Textbox.Text = playerOne.ships[numOfShip].speed.ToString();
                if (playerOne.ships[numOfShip].speed == 1) LessSpeed_Button.Enabled = false;
            }
        }
        private void MoreSpeed_Button_Click(object sender, EventArgs e)
        {
            int numOfShip = ShipSelection();

            if (numOfShip != -1)
            {
                playerOne.ships[numOfShip].speed++;
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
                ShowSpeed_Textbox.Text = playerOne.ships[numOfShip].speed.ToString();
                if (Gameplay.MaxSppeed(playerOne.ships[numOfShip])) MoreSpeed_Button.Enabled = false;
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
                    Gameplay.MovingOfShip(ref playerOne.ships[numOfShip], ref playerOne.shipInCerter, messageYouWin);
                    playerMadeStep = true;
                    if (short.Parse(PlayerOneShipsCenter_Textbox.Text)<playerOne.shipInCerter)
                    { 
                        PlayerOneShipsCenter_Textbox.Text = playerOne.shipInCerter.ToString();
                        ShipRadioButtonOff(numOfShip);
                    }
                }
                else
                {
                    if (!Go_RadioButton.Enabled)
                    {
                        Go_RadioButton.Checked = true;
                        Go_RadioButton.Enabled = true;
                        MoreSpeed_Button.Enabled = false;
                        LessSpeed_Button.Enabled = false;
                        GroupShip.Enabled = true;
                        playerMadeStep = true;

                    }
                    else MessageBox.Show("Скорость не была изменена. Ход не закончен.", "Внимание!");
                }
            }
            else MessageBox.Show("Корабль не был выбран. Ход не закончен.", "Внимание!");
            Display.DrawMapAndShips(playerOne.ships, enemy.player.ships);

            if (playerMadeStep) EnemyStep();

            Step_Button.Enabled = true;
        }
        private void СreateSave_Button_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex("[\\\\/:*?\"<>|]");
            MatchCollection matches = reg.Matches(SaveName_Textbox.Text);
            if (matches.Count == 0)
            {
                string str = savePath + SaveName_Textbox.Text + ".txt";
                Gameplay.SaveInformationAboutShips(str, playerOne, enemy, Step_Button.Visible);
                
                InvalidСharacters_Label.Visible = false;
                СreateSave_Button.Visible = false;
                SaveName_Label.Visible = false;
                SaveName_Textbox.Visible = false;
                SaveGame_ToolStripMenuItem.Text = "Сохранить игру";
                ActionItemsEnabled(true);
                Refresh();
                Display.DrawImage();
            }
            else InvalidСharacters_Label.Visible = true;
        }
        private void NewGame_Buttom_Click(object sender, EventArgs e)
        {
            MainMenu_Off();

            PlayerOneShipsCenter_Textbox.Text = 0.ToString();
            PlayerTwoShipsCenter_Textbox.Text = 0.ToString();

            OnPosition_Button.Visible = true;

            Gameplay.InitializationAllShips(playerOne.ships, enemy.player.ships);
            enemy.EnemyShipSorting();
            Display.DrawMap();
            Display.DrawingShipsOnSides(playerOne.ships, enemy.player.ships);
            Gameplay.WhoGoesFirst( enemy, ref greenGoesFirst);
        }
        private void DownloadGame_Buttom_Click(object sender, EventArgs e)
        {
            if (DownloadGame_Buttom.Text == "Загрузить игру")
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(savePath);
                FileInfo[] files = directoryInfo.GetFiles("*.txt");

                foreach (FileInfo fi in files)
                {
                    Save_List.Items.Add(fi.Name.ToString().Replace(".txt", ""));
                }

                DownloadMenu_OnOff(true);
                DownloadGame_Buttom.Text = "Назад";
            }
            else
            {
                DownloadMenu_OnOff(false);
                DownloadGame_Buttom.Text = "Загрузить игру";
            }
        }
        private void LoadingTheSelectedSave_Buttom_Click(object sender, EventArgs e)
        {
            bool wantToLoad = true;
            
            if (File.Exists(savePath + Save_List.SelectedItem + ".txt"))
            {
                if (!NewGame_Buttom.Visible)
                {   
                    DialogResult result = MessageBox.Show("Хотите загрузить игру?\n Весь не сохранённый прогресс будет потерян.", "Загрузка", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No) wantToLoad = false;
                }
                else
                {
                    MainMenu_Off();
                }

                if (wantToLoad)
                {
                    DownloadGame_ToolStripMenuItem.Text = "Загрузить игру";
                    LoadingTheSelectedSave_Buttom.Visible = false;
                    Save_List.Visible = false;
                    ActionItemsEnabled(true);

                    bool onPosition = false;
                    bool step = false;
                    string save = savePath + Save_List.SelectedItem + ".txt";

                    Gameplay.DownloadingDataInShips(save, playerOne, enemy, ref step);
                    Display.DrawMap();

                    for (short i = 0; i < 9; i++)
                    {
                        Display.DrawShipAfterLoading(true, playerOne.ships[i], ref onPosition);
                        Display.DrawShipAfterLoading(false, enemy.player.ships[i], ref onPosition);
                    }

                    PlayerOneShipsCenter_Textbox.Text = playerOne.shipInCerter.ToString();
                    PlayerTwoShipsCenter_Textbox.Text = enemy.player.shipInCerter.ToString();
                    if (onPosition)
                    {
                        PositionButtonVisible(true, false);
                        bool on;
                        for (short i = 0; i < 9; i++)
                        {
                            if (playerOne.ships[i].position == -1) on = true;
                            else on = false;
                            ShipRadioButtons_OnOff(i, on);
                        }
                    }
                    else
                    {
                        if (!step)
                        { 
                            PositionButtonVisible(true, true);
                            ActionItemsVisible(false);
                        }
                        else
                        {
                            PositionButtonVisible(false, false);
                            ActionItemsVisible(true);

                            for (short i = 0; i < 9; i++) ShipRadioButtons_OnOff(i, playerOne.ships[i].inGame);
                            ShowSpeed_Textbox.Text = "";
                        }
                    }
                    Refresh();
                    Display.DrawImage();
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
                PositionButtonVisible(true, false);
                ActionItemsVisible(false);
                PlayerOneShipsCenter_Textbox.Text = 0.ToString();
                PlayerTwoShipsCenter_Textbox.Text = 0.ToString();

                Gameplay.currentPoint = 125;

                AutoPosChB.Visible = true;
                AutoPosChB.Checked = false;

                MainMenu_Off();

                for (short i = 0; i < 9; i++)
                {
                    shipRadioButtons[i].Enabled = true;
                    shipRadioButtons[i].BackColor = Color.Transparent;
                }
                
                Gameplay.InitializationAllShips(playerOne.ships, enemy.player.ships);
                enemy.EnemyShipSorting();
                Display.DrawMap();
                Display.DrawingShipsOnSides(playerOne.ships, enemy.player.ships);
                Gameplay.WhoGoesFirst(enemy, ref greenGoesFirst);
            }
        }
        private void SaveGame_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveGame_ToolStripMenuItem.Text == "Сохранить игру")
            {
                string str = DateTime.Now.ToString().Replace(":", ".").Replace(" ", "  ");

                SaveName_Textbox.Text = str;

                SaveGame_OnOff(true);
                ActionItems_OnOff(false);
            }
            else
            {
                SaveGame_OnOff(false);
                ActionItems_OnOff(true);
            }
        }
        private void DownloadGame_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DownloadGame_ToolStripMenuItem.Text == "Загрузить игру")
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(savePath);
                FileInfo[] files = directoryInfo.GetFiles("*.txt");
                Save_List.Items.Clear();
                foreach (FileInfo fi in files)
                {
                    Save_List.Items.Add(fi.Name.ToString().Replace(".txt", ""));
                }
                Save_List.Location = new Point(758, 289);
                LoadingTheSelectedSave_Buttom.Location = new Point(867, 695);
                DownloadGame_OnOff(true);
                ActionItems_OnOff(false);
            }
            else
            {
                DownloadGame_OnOff(false);
                ActionItems_OnOff(true);
                pictureBox.Refresh();
                Display.DrawImage();
            }
        }
    }
}//792 //776//737//688