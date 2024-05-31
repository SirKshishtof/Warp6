using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warp_6Core;

namespace Warp_6
{
    public partial class MainForm : Form
    {
        void ShipRadioButtonOff(int index)
        {
            shipRadioButtons[index].Checked = false;
            shipRadioButtons[index].Enabled = false;
            shipRadioButtons[index].BackColor = Color.WhiteSmoke;
        }
        sbyte ShipSelection()
        {
            for (sbyte i = 0; i < 9; i++)
            {
                if (shipRadioButtons[i].Checked) return i;
            }
            return -1;
        }
        void LessMoreSpeedEnabled_OnOff(bool less, bool more)
        {
            LessSpeed_Button.Enabled = less;
            MoreSpeed_Button.Enabled = more;
        }
        void PrintSpeed(short numOfShip)
        {
            ShowSpeed_Textbox.Text = playerOne.ships[numOfShip].speed.ToString();
            if (ChangeSpeed_RadioButton.Checked)
            {
                if (playerOne.ships[numOfShip].speed == 1) LessMoreSpeedEnabled_OnOff(false, true);
                else
                {
                    if (Gameplay.MaxSppeed(playerOne.ships[numOfShip])) LessMoreSpeedEnabled_OnOff(true, false);
                    else LessMoreSpeedEnabled_OnOff(true, true);
                }
            }
        }
        void MainMenu_Off()
        {
            NewGame_Button.Visible = false;
            DownloadGame_Button.Visible = false;
            GroupShip.Visible = true;
            NewGame_ToolStripMenuItem.Visible = true;
            DownloadGame_ToolStripMenuItem.Visible = true;
            SaveGame_ToolStripMenuItem.Visible = true;
            GameExit_Button.Enabled = true;
            GameExit_Button.Width = 177;
            GameExit_Button.Height = 33;
            GameExit_Button.Location = new Point(1730, 1035);//(1713, 955)
            GameExit_Button.Font = new Font("Segoe UI", 12);
            GameWithAI_Button.Visible = false;
            GameWithPerson_Button.Visible = false;
        }
        void DownloadMenuButton_OnOff(bool on)
        {
            Save_List.Visible = on;
            LoadingTheSelectedSave_Button.Visible = on;
            NewGame_Button.Enabled = !on;
            GameExit_Button.Enabled = !on;
            if (on) DownloadGame_Button.Text = "Назад";
            else DownloadGame_Button.Text = "Загрузить игру";
        }
        void NewGameMenu_OnOff(bool on)
        {
            GameWithAI_Button.Visible = on;
            GameWithPerson_Button.Visible = on;
            DownloadGame_Button.Enabled = !on;
            GameExit_Button.Enabled = !on;
            if (on) NewGame_Button.Text = "Назад";
            else NewGame_Button.Text = "Новая игра";
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
        void DownloadMenuStripMenu_OnOff(bool on)
        {
            Save_List.Visible = on;
            LoadingTheSelectedSave_Button.Visible = on;
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
        void PositionButtonVisible_OnOff(bool on, bool startGame)
        {
            OnPosition_Button.Visible = on;
            Step_Button.Visible = !on;
            if (startGame) OnPosition_Button.Text = "Начать игру";
            else OnPosition_Button.Text = "На позицию";
        }
        void ActionItemsVisible_OnOff(bool on)
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
        void ActionItemsEnabled_OnOff(bool on)
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
                        enemy.ships[numOfShip].Move(ref enemy.shipInCerter, messageWin);
                        PlayerTwoShipsCenter_Textbox.Text = enemy.shipInCerter.ToString();
                        PlayerTwoStep_Texbox.Text = "  " + (numOfShip + 1) + ":  Move";
                    }
                    break;
                case 10: PlayerTwoStep_Texbox.Text = "  " + (numOfShip + 1) + ":  " + enemy.ships[numOfShip].speed + " -> " + (--enemy.ships[numOfShip].speed); break;
                case 11: PlayerTwoStep_Texbox.Text = "  " + (numOfShip + 1) + ":  " + enemy.ships[numOfShip].speed + " -> " + (++enemy.ships[numOfShip].speed); break;
            }
            Thread.Sleep(1500);
            Display.DrawMapAndShips(playerOne.ships, enemy.ships);
        }
        void StartMenu()
        {
            MainMenu_Off();
            PlayerOneShipsCenter_Textbox.Text = "0";
            PlayerTwoShipsCenter_Textbox.Text = "0";
            OnPosition_Button.Visible = true;
        }
        void AutoPos()
        {
            short NumOfShip;
            for (short i = 0; i < 10; i++)
            {
                NumOfShip = i;
                if (i != 9)
                {
                    playerOne.ships[NumOfShip].SetOnSpiral(ref Gameplay.currentPointOnMap, playerOne.brush);
                    ShipRadioButtonOff(NumOfShip);
                    Warp_6Core.Display.DrawWhiteRectangle(NumOfShip, false);
                }
                if (enemy.list.Count > 0)
                {
                    NumOfShip = enemy.list[0];
                    enemy.ships[NumOfShip].SetOnSpiral(ref Gameplay.currentPointOnMap, enemy.brush);
                    Warp_6Core.Display.DrawWhiteRectangle(NumOfShip, true);
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
    }
}
