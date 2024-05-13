using Drawing;
using Players;
using System;
using System.IO;
using System.Windows.Forms;

namespace Game
{
    class Gameplay
    {
        static string savePath = Directory.GetCurrentDirectory() + "\\Save\\";

        public static string SavePath { get { return savePath; } }
        
        public static short currentPointOnMap = 125;//Переменная показывающая позицию на которую будет выставлен корабль в начале
        public static void MovingOfShip(ref Ship ship, ref short shipInCenter, string message) 
        {
            Display.position[ship.position].busy = false;
            if ((ship.position - ship.speed) < 0) ShipOutOfGame(ref ship,ref shipInCenter, message);
            else
            {
                ship.position -= ship.speed;
                while (Display.position[ship.position].busy && ship.inGame)
                {
                    if (Display.position[ship.position].jump == -1) ShipOutOfGame(ref ship, ref shipInCenter, message);
                    else ship.position = Display.position[ship.position].jump;
                }
                Display.position[ship.position].busy = true;
            }
        }
        static void ShipOutOfGame(ref Ship ship, ref short shipInCenter, string message)
        {
            shipInCenter++;
            ship.inGame = false;
            string winOrLoss;
            if (message.Contains("Вы победили!")) winOrLoss = "Победа!"; 
            else winOrLoss = "Проигрыш..."; 
            if (shipInCenter == 6)
            {
                DialogResult result = MessageBox.Show(message, winOrLoss, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) Application.Restart();
                else Application.Exit();
            }
        }
        public static bool MaxSppeed(Ship ship)
        {
            if (ship.type == 1 && ship.speed == 4 ||
                ship.type == 2 && ship.speed == 6 ||
                ship.type == 3 && ship.speed == 8) return true;

            return false;
        }
        public static void SetShipOnSpiral(ref Ship ship, bool isThatMyShip)
        {
            ship.position = currentPointOnMap;
            Display.position[currentPointOnMap].busy = true;
            float x = Display.X_GetCoord(ship);
            float y = Display.Y_GetCoord(ship);
            switch (ship.type) 
            {
                case 1: { Display.DrawTriangle(isThatMyShip, x, y, ship.index + 1, ship.speed); } break;
                case 2: { Display.DrawRectangle(isThatMyShip, x, y, ship.index + 1, ship.speed); } break;
                case 3: { Display.DrawCircle(isThatMyShip, x, y, ship.index + 1, ship.speed); } break;
            }
            currentPointOnMap--;
        }
        public static void WhoGoesFirst( Enemy enemy,ref bool greenGoesFirst)
        {
            Random rnd = new Random();
            string message;
            if (rnd.Next() % 2 != 0)
            {
                message = "О нет! Противник прибыл раньше вас! Вы ходите вторым.";
                short NumOfShip = enemy.list[0];
                SetShipOnSpiral( ref enemy.ships[NumOfShip], false);
                Display.DrawWhiteRectangle(NumOfShip, true);
                enemy.list.RemoveAt(0);
                greenGoesFirst = false;
            }
            else message = "Вам повезло! Противник еще не прибыл! Вы ходите первым.";
            
            Display.PictureBoxRefresh();
            Display.DrawImage();
            MessageBox.Show(message, "Кто начинает");
        }
        static short SettingOfShipSpeed(Ship ship)
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
        public static void InitializationAllShips(Ship[] playerOne, Ship[] playerTwo)
        {
            for (short i = 0; i < 9; i++)
            {
                playerOne[i].speed = SettingOfShipSpeed(playerOne[i]);//Задание скорости корабля
                playerOne[i].inGame = true;

                playerTwo[i].speed = SettingOfShipSpeed(playerTwo[i]);//Задание скорости корабля
                playerTwo[i].inGame = true;

            }
        }
        public static void SaveInformationAboutShips(string SaveName, Player playerOne, Enemy enemy, bool stepbuttonVisible)
        {
            StreamWriter SaveFile = new StreamWriter(SaveName + savePath);

            for (int i = 0; i < 9; i++)
            {
                SaveFile.WriteLine(playerOne.ships[i].speed);
                SaveFile.WriteLine(playerOne.ships[i].position);
                SaveFile.WriteLine(playerOne.ships[i].inGame);

                SaveFile.WriteLine(enemy.ships[i].speed);
                SaveFile.WriteLine(enemy.ships[i].position);
                SaveFile.WriteLine(enemy.ships[i].inGame);
            }
            SaveFile.WriteLine(playerOne.shipInCerter);
            SaveFile.WriteLine(enemy.shipInCerter);
            SaveFile.WriteLine(enemy.list.Count);
            for (short i = 0; i < enemy.list.Count; i++) SaveFile.WriteLine(enemy.list[i]);
            SaveFile.WriteLine(currentPointOnMap);
            if (stepbuttonVisible) SaveFile.WriteLine(true);
            else SaveFile.WriteLine(false);
            SaveFile.Close();
        }
        public static void DownloadingDataInShips(string savePath, Player PlayerOne, Enemy enemy, ref bool startGame)
        {
            StreamReader SaveFile = new StreamReader(savePath);

            for (short i = 0; i < 126; i++) Display.position[i].busy = false;

            for (short i = 0; i < 9; i++)
            {
                PlayerOne.ships[i].speed = short.Parse(SaveFile.ReadLine());
                PlayerOne.ships[i].position = short.Parse(SaveFile.ReadLine());
                PlayerOne.ships[i].inGame = bool.Parse(SaveFile.ReadLine());
                if (PlayerOne.ships[i].position > -1) Display.position[PlayerOne.ships[i].position].busy = true;

                enemy.ships[i].speed = short.Parse(SaveFile.ReadLine());
                enemy.ships[i].position = short.Parse(SaveFile.ReadLine());
                enemy.ships[i].inGame = bool.Parse(SaveFile.ReadLine());
                if (enemy.ships[i].position > -1) Display.position[enemy.ships[i].position].busy = true;
            }

            PlayerOne.shipInCerter = short.Parse(SaveFile.ReadLine());
            enemy.shipInCerter = short.Parse(SaveFile.ReadLine());
            short listCount = short.Parse(SaveFile.ReadLine());
            enemy.list.Clear();
            while (listCount > 0)
            {
                enemy.list.Add(short.Parse(SaveFile.ReadLine()));
                listCount--;
            }
            currentPointOnMap = short.Parse(SaveFile.ReadLine());
            startGame = bool.Parse(SaveFile.ReadLine());
            SaveFile.Close();
        }
        public static void DownloadingDataInShips(string savePath, Player playerOne, Player playerTwo, ref bool startGame)
        {
            StreamReader SaveFile = new StreamReader(savePath);

            for (short i = 0; i < 126; i++) Display.position[i].busy = false;

            for (short i = 0; i < 9; i++)
            {
                playerOne.ships[i].speed = short.Parse(SaveFile.ReadLine());
                playerOne.ships[i].position = short.Parse(SaveFile.ReadLine());
                playerOne.ships[i].inGame = bool.Parse(SaveFile.ReadLine());
                if (playerOne.ships[i].position > -1) Display.position[playerOne.ships[i].position].busy = true;

                playerTwo.ships[i].speed = short.Parse(SaveFile.ReadLine());
                playerTwo.ships[i].position = short.Parse(SaveFile.ReadLine());
                playerTwo.ships[i].inGame = bool.Parse(SaveFile.ReadLine());
                if (playerTwo.ships[i].position > -1) Display.position[playerTwo.ships[i].position].busy = true;
            }

            playerOne.shipInCerter = short.Parse(SaveFile.ReadLine());
            playerTwo.shipInCerter = short.Parse(SaveFile.ReadLine());
            currentPointOnMap = short.Parse(SaveFile.ReadLine());
            startGame = bool.Parse(SaveFile.ReadLine());
            SaveFile.Close();
        }
    }
}
