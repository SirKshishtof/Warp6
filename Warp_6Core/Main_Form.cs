using System;
using System.Drawing;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Warp_6Core;
using static System.Windows.Forms.DataFormats;

namespace Warp_6
{
    public partial class MainForm : Form
    {
        RadioButton[] shipRadioButtons = new RadioButton[9];

        Player playerOne = new Player(true);
        Player playerTwo = new Player(false);
        Enemy enemy = new Enemy(false);

        bool greenGoesFirst = true;

        const string messageYouWin = "Вы победили! Вам удалось опередить противника и выиграть эту битву! Империя гордиться вами! Начать заного?";
        const string messageWin = "Вы проиграли... Противник опередил вас и вы проиграли эту битву. Вы подвели империю. Начать заного?";

        
        public MainForm()
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
            Gameplay.CreateDirectory();
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
                        playerOne.ships[NumOfShip].SetOnSpiral(ref Gameplay.currentPointOnMap, playerOne.brush);
                        Display.DrawWhiteRectangle(NumOfShip, false);

                        if (enemy.list.Count > 0)
                        {
                            Thread.Sleep(1000);
                            NumOfShip = enemy.list[0];
                            enemy.ships[NumOfShip].SetOnSpiral(ref Gameplay.currentPointOnMap, enemy.brush);
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
                    PositionButtonVisible_OnOff(false, false);
                    ActionItemsVisible_OnOff(true);
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
                    playerOne.ships[numOfShip].Move(ref playerOne.shipInCerter, messageYouWin);
                    playerMadeStep = true;
                    if (short.Parse(PlayerOneShipsCenter_Textbox.Text) < playerOne.shipInCerter)
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
            Display.DrawMapAndShips(playerOne.ships, enemy.ships);

            if (playerMadeStep)
            {
                EnemyStep();
            }

            Step_Button.Enabled = true;
        }
        private void СreateSave_Button_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex("[\\\\/:*?\"<>|]");
            MatchCollection matches = reg.Matches(SaveName_Textbox.Text);
            if (matches.Count == 0)
            {
                string gamesPhase;
                if (Step_Button.Visible) { gamesPhase = "3"; }
                else
                {
                    if (OnPosition_Button.Text == "Начать игру") { gamesPhase = "2"; }
                    else { gamesPhase = "1"; }
                }
                Gameplay.SaveInformationAboutShips(playerOne, enemy, SaveName_Textbox.Text, gamesPhase);

                InvalidСharacters_Label.Visible = false;
                СreateSave_Button.Visible = false;
                SaveName_Label.Visible = false;
                SaveName_Textbox.Visible = false;
                SaveGame_ToolStripMenuItem.Text = "Сохранить игру";
                ActionItemsEnabled_OnOff(true);
                Warp_6Core.Display.ImageRefresh();
            }
            else InvalidСharacters_Label.Visible = true;
        }
        private void NewGame_Button_Click(object sender, EventArgs e)
        {
            if (NewGame_Button.Text == "Новая игра") NewGameMenu_OnOff(true);
            else NewGameMenu_OnOff(false);
        }
        private void GameWithAI_Buttom_Click(object sender, EventArgs e)
        {
            StartMenu();
            Gameplay.InitializationAllShips(playerOne.ships, enemy.ships);
            enemy.EnemyShipSorting();
            Display.DrawMapAndShips(playerOne.ships, enemy.ships);
            Gameplay.WhoGoesFirst(enemy, ref greenGoesFirst);
        }
        private void GameWithPerson_Button_Click(object sender, EventArgs e)
        {
            StartMenu();
            NetForm newForm = new NetForm();
            newForm.Show();
            //Gameplay.InitializationAllShips(playerOne.ships, playerTwo.ships);
            //Display.DrawMapAndShips(playerOne.ships, playerTwo.ships);
            //Gameplay.WhoGoesFirst(enemy, ref greenGoesFirst);
        }
        private void DownloadGame_Button_Click(object sender, EventArgs e)
        {
            if (DownloadGame_Button.Text == "Загрузить игру")
            {
                //DirectoryInfo directoryInfo = new DirectoryInfo(Gameplay.SavePath);
                FileInfo[] files = Gameplay.directoryInfo.GetFiles("*.txt");   //directoryInfo.GetFiles("*.txt");
                foreach (FileInfo fi in files) Save_List.Items.Add(fi.Name.ToString().Replace(".txt", ""));
                
                DownloadMenuButton_OnOff(true);
            }
            else DownloadMenuButton_OnOff(false);
            
        }
        private void LoadingTheSelectedSave_Button_Click(object sender, EventArgs e)
        {
            bool wantToLoad = true;

            if (Save_List.SelectedItem != null && Gameplay.FileExists(Save_List.SelectedItem.ToString()))
            {
                if (!NewGame_Button.Visible)
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
                    LoadingTheSelectedSave_Button.Visible = false;
                    Save_List.Visible = false;
                    ActionItemsEnabled_OnOff(true);

                    string gamePhase = "";
                    string save = Save_List.SelectedItem + ".txt";

                    Gameplay.DownloadingDataInShips(playerOne, enemy, Save_List.SelectedItem.ToString(), ref gamePhase);
                    Display.DrawMapAndShips(playerOne.ships, enemy.ships);

                    PlayerOneShipsCenter_Textbox.Text = playerOne.shipInCerter.ToString();
                    PlayerTwoShipsCenter_Textbox.Text = enemy.shipInCerter.ToString();

                    for (short i = 0; i < 9; i++) ShipRadioButtons_OnOff(i, false);

                    switch (gamePhase)
                    {
                        case "1":
                            {
                                PositionButtonVisible_OnOff(true, false);
                                ActionItemsVisible_OnOff(false);
                                for (short i = 0; i < 9; i++) if (playerOne.ships[i].position == -1) ShipRadioButtons_OnOff(i, true);
                            }
                            break;
                        case "2":
                            {
                                PositionButtonVisible_OnOff(true, true);
                                ActionItemsVisible_OnOff(false);
                            }
                            break;
                        case "3":
                            {
                                PositionButtonVisible_OnOff(false, false);
                                ActionItemsVisible_OnOff(true);
                                for (short i = 0; i < 9; i++) if (playerOne.ships[i].inGame) ShipRadioButtons_OnOff(i, true);
                                ShowSpeed_Textbox.Text = "";
                            }
                            break;
                    }

                    Display.ImageRefresh();
                }
            }
            else { }
        }
        private void GameExit_Button_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Хотите выйти из игры?\n Весь не сохранённый прогресс будет потерян.", "Выход", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) Application.Exit();
        }

        private void Rules_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string rulesPath = Directory.GetCurrentDirectory() + "\\Rules.txt";
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
                PositionButtonVisible_OnOff(true, false);
                ActionItemsVisible_OnOff(false);
                PlayerOneShipsCenter_Textbox.Text = 0.ToString();
                PlayerTwoShipsCenter_Textbox.Text = 0.ToString();

                Gameplay.currentPointOnMap = 125;

                AutoPosChB.Visible = true;
                AutoPosChB.Checked = false;

                MainMenu_Off();

                for (short i = 0; i < 9; i++)
                {
                    shipRadioButtons[i].Enabled = true;
                    shipRadioButtons[i].BackColor = Color.Transparent;
                }

                Gameplay.InitializationAllShips(playerOne.ships, enemy.ships);
                enemy.EnemyShipSorting();
                Display.DrawMapAndShips(playerOne.ships, enemy.ships);
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
                FileInfo[] files = Gameplay.directoryInfo.GetFiles("*.txt");
                Save_List.Items.Clear();
                foreach (FileInfo fi in files)Save_List.Items.Add(fi.Name.ToString().Replace(".txt", ""));
                
                Save_List.Location = new Point(758, 289);
                LoadingTheSelectedSave_Button.Location = new Point(867, 695);
                DownloadMenuStripMenu_OnOff(true);
                ActionItems_OnOff(false);
            }
            else
            {
                DownloadMenuStripMenu_OnOff(false);
                ActionItems_OnOff(true);
                Display.ImageRefresh();
            }
        }

    }
}//792 //776//737//688//628//443