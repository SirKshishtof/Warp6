using Drawing;
using Players;
using System;
using System.IO;
using System.Windows.Forms;

namespace Game
{
    public delegate void Delegation(int index);

    public class Gameplay
    {
        public short currentPoint = 125;

        public void MovingOfShip(Display display, ref Ship ship, ref short shipInCenter, string message,  Delegation del)
        {
            display.position[ship.position].busy = false;
            if ((ship.position - ship.speed) < 0) ShipOutOfGame(ref ship,ref shipInCenter, message,  del);
            else
            {
                ship.position -= ship.speed;
                while (display.position[ship.position].busy && ship.InGame)
                {
                    if (display.position[ship.position].jump == -1) ShipOutOfGame(ref ship, ref shipInCenter, message,  del);
                    else ship.position = display.position[ship.position].jump;
                }
                display.position[ship.position].busy = true;
            }
        }

        void ShipOutOfGame(ref Ship ship, ref short shipInCenter, string message, Delegation del)
        {
            shipInCenter++;
            ship.InGame = false;
            string winOrLoss;
            if (message.Contains("Вы победили!")) { del(ship.index); winOrLoss = "Победа!"; }
            else { winOrLoss = "Проигрыш..."; }
            if (shipInCenter == 6)
            {
                DialogResult result = MessageBox.Show(message, winOrLoss, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) Application.Restart();
                else Application.Exit();
            }
        }

        public bool MaxSppeed(Ship ship)
        {
            if (ship.type == 1 && ship.speed == 4 ||
                ship.type == 2 && ship.speed == 6 ||
                ship.type == 3 && ship.speed == 8) return true;

            return false;
        }

        public void SetShipOnSpiral(Display display, ref Ship ship, bool isThatMyShip)
        {
            ship.position = currentPoint;
            display.position[currentPoint].busy = true;
            float x = display.X_GetCoord(ship);
            float y = display.Y_GetCoord(ship);
            switch (ship.type)
            {
                case 1: { display.DrawTriangle(isThatMyShip, x, y, ship.index + 1, ship.speed); } break;
                case 2: { display.DrawRectangle(isThatMyShip, x, y, ship.index + 1, ship.speed); } break;
                case 3: { display.DrawCircle(isThatMyShip, x, y, ship.index + 1, ship.speed); } break;
            }
            currentPoint--;
        }

        public void WhoGoesFirst(Display display, Enemy enemy)
        {
            Random rnd = new Random();
            string message;
            if (rnd.Next() % 2 != 0)
            {
                message = "О нет! Противник прибыл раньше вас! Вы ходите вторым.";
                short NumOfShip = enemy.list[0];
                SetShipOnSpiral(display, ref enemy.player.ships[NumOfShip], false);
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

        short SettingOfShipSpeed(Ship ship)
        {
            Random rnd = new Random();
            short x = 0;

            switch (ship.type)
            {
                case 1: x = 4; break;
                case 2: x = 6; break;
                case 3: x = 8; break;
            }

            return (short)(rnd.Next() % x + 1);
        }
        public void InitializationAllShips(Ship[] playerOne, Ship[] playerTwo)
        {
            for (short i = 0; i < 9; i++)
            {
                playerOne[i].speed = SettingOfShipSpeed(playerOne[i]);//Задание скорости корабля
                playerOne[i].InGame = true;

                playerTwo[i].speed = SettingOfShipSpeed(playerTwo[i]);//Задание скорости корабля
                playerTwo[i].InGame = true;

            }
        }
        public void SaveInformationAboutShips(string savePath,Player playerOne, Enemy enemy, bool stepbuttonVisible)
        {
            StreamWriter SaveFile = new StreamWriter(savePath);

            for (int i = 0; i < 9; i++)
            {
                SaveFile.WriteLine(playerOne.ships[i].speed);
                SaveFile.WriteLine(playerOne.ships[i].position);
                SaveFile.WriteLine(playerOne.ships[i].InGame);

                SaveFile.WriteLine(enemy.player.ships[i].speed);
                SaveFile.WriteLine(enemy.player.ships[i].position);
                SaveFile.WriteLine(enemy.player.ships[i].InGame);
            }
            SaveFile.WriteLine(playerOne.shipInCerter);
            SaveFile.WriteLine(enemy.player.shipInCerter);
            SaveFile.WriteLine(enemy.list.Count);
            for (short i = 0; i < enemy.list.Count; i++) SaveFile.WriteLine(enemy.list[i]);
            SaveFile.WriteLine(currentPoint);
            if (stepbuttonVisible) SaveFile.WriteLine(true);
            else SaveFile.WriteLine(false);
            SaveFile.Close();
        }
        public void DownloadingDataInShips(string savePath, Display display, Player PlayerOne, Enemy enemy, ref bool startGame)
        {
            StreamReader SaveFile = new StreamReader(savePath);

            for (short i = 0; i < 126; i++) display.position[i].busy = false;

            for (short i = 0; i < 9; i++)
            {
                PlayerOne.ships[i].speed = short.Parse(SaveFile.ReadLine());
                PlayerOne.ships[i].position = short.Parse(SaveFile.ReadLine());
                PlayerOne.ships[i].InGame = bool.Parse(SaveFile.ReadLine());
                if (PlayerOne.ships[i].position > -1) display.position[PlayerOne.ships[i].position].busy = true;

                enemy.player.ships[i].speed = short.Parse(SaveFile.ReadLine());
                enemy.player.ships[i].position = short.Parse(SaveFile.ReadLine());
                enemy.player.ships[i].InGame = bool.Parse(SaveFile.ReadLine());
                if (enemy.player.ships[i].position > -1) display.position[enemy.player.ships[i].position].busy = true;
            }

            PlayerOne.shipInCerter = short.Parse(SaveFile.ReadLine());
            enemy.player.shipInCerter = short.Parse(SaveFile.ReadLine());
            short listCount = short.Parse(SaveFile.ReadLine());
            enemy.list.Clear();
            while (listCount > 0)
            {
                enemy.list.Add(short.Parse(SaveFile.ReadLine()));
                listCount--;
            }
            currentPoint = short.Parse(SaveFile.ReadLine());
            startGame = bool.Parse(SaveFile.ReadLine());
            SaveFile.Close();
        }

        public void DownloadingDataInShips(string savePath, Display display, Player playerOne, Player playerTwo, ref bool startGame)
        {
            StreamReader SaveFile = new StreamReader(savePath);

            for (short i = 0; i < 126; i++) display.position[i].busy = false;

            for (short i = 0; i < 9; i++)
            {
                playerOne.ships[i].speed = short.Parse(SaveFile.ReadLine());
                playerOne.ships[i].position = short.Parse(SaveFile.ReadLine());
                playerOne.ships[i].InGame = bool.Parse(SaveFile.ReadLine());
                if (playerOne.ships[i].position > -1) display.position[playerOne.ships[i].position].busy = true;

                playerTwo.ships[i].speed = short.Parse(SaveFile.ReadLine());
                playerTwo.ships[i].position = short.Parse(SaveFile.ReadLine());
                playerTwo.ships[i].InGame = bool.Parse(SaveFile.ReadLine());
                if (playerTwo.ships[i].position > -1) display.position[playerTwo.ships[i].position].busy = true;
            }

            playerOne.shipInCerter = short.Parse(SaveFile.ReadLine());
            playerTwo.shipInCerter = short.Parse(SaveFile.ReadLine());
            currentPoint = short.Parse(SaveFile.ReadLine());
            startGame = bool.Parse(SaveFile.ReadLine());
            SaveFile.Close();
        }

    }
}
