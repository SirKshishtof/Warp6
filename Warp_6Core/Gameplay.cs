using Warp_6Core;
using System;
using System.IO;
using System.Windows.Forms;

namespace Warp_6Core
{
    class Gameplay
    {
        private static string savePath = Directory.GetCurrentDirectory() + "\\Save\\";
        public static short currentPointOnMap = 125;//Переменная показывающая позицию на которую будет выставлен корабль в начале
        public static string SavePath { get { return savePath; } }

        static void foo<T>(T id)
        {

        }

        public static bool MaxSppeed(Ship ship)
        {
            if (ship.type == 1 && ship.speed == 4 ||
                ship.type == 2 && ship.speed == 6 ||
                ship.type == 3 && ship.speed == 8) return true;

            return false;
        }
        public static void WhoGoesFirst(Enemy enemy,ref bool greenGoesFirst)
        {
            Random rnd = new Random();
            string message;
            if (rnd.Next() % 2 != 0)
            {
                message = "О нет! Противник прибыл раньше вас! Вы ходите вторым.";
                short NumOfShip = enemy.list[0];
                //SetShipOnSpiral( ref enemy.ships[NumOfShip], false);
                Warp_6Core.Display.DrawWhiteRectangle(NumOfShip, true);
                enemy.list.RemoveAt(0);
                greenGoesFirst = false;
            }
            else message = "Вам повезло! Противник еще не прибыл! Вы ходите первым.";

            Warp_6Core.Display.ImageRefresh();
            MessageBox.Show(message, "Кто начинает");
        }
        public static void InitializationAllShips(Ship[] playerOne, Ship[] playerTwo)
        {
            for (short i = 0; i < 9; i++)
            {
                playerOne[i].SetSpeed(); ;//Задание скорости корабля
                playerOne[i].inGame = true;
                playerOne[i].position = -1;

                playerTwo[i].SetSpeed();//Задание скорости корабля
                playerTwo[i].inGame = true;
                playerTwo[i].position = -1;
            }
        }
        public static void SaveInformationAboutShips(Player playerOne, Enemy enemy, string SaveName, string gamePhase)
        {
            StreamWriter SaveFile = new StreamWriter(savePath + SaveName);

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
            SaveFile.WriteLine(gamePhase);
            SaveFile.Close();
        }
        public static void DownloadingDataInShips(Player PlayerOne, Enemy enemy, string savePath, ref string gamePhase)
        {
            StreamReader SaveFile = new StreamReader(savePath);

            for (short i = 0; i < 126; i++) Warp_6Core.Display.position[i].busy = false;

            for (short i = 0; i < 9; i++)
            {
                PlayerOne.ships[i].speed = short.Parse(SaveFile.ReadLine());
                PlayerOne.ships[i].position = short.Parse(SaveFile.ReadLine());
                PlayerOne.ships[i].inGame = bool.Parse(SaveFile.ReadLine());
                if (PlayerOne.ships[i].position > -1) Warp_6Core.Display.position[PlayerOne.ships[i].position].busy = true;

                enemy.ships[i].speed = short.Parse(SaveFile.ReadLine());
                enemy.ships[i].position = short.Parse(SaveFile.ReadLine());
                enemy.ships[i].inGame = bool.Parse(SaveFile.ReadLine());
                if (enemy.ships[i].position > -1) Warp_6Core.Display.position[enemy.ships[i].position].busy = true;
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
            gamePhase = SaveFile.ReadLine();
            SaveFile.Close();
        }
        //public static void DownloadingDataInShips(string savePath, Player playerOne, Player playerTwo, ref bool startGame)
        //{
        //    StreamReader SaveFile = new StreamReader(savePath);

        //    for (short i = 0; i < 126; i++) Display.position[i].busy = false;

        //    for (short i = 0; i < 9; i++)
        //    {
        //        playerOne.ships[i].speed = short.Parse(SaveFile.ReadLine());
        //        playerOne.ships[i].position = short.Parse(SaveFile.ReadLine());
        //        playerOne.ships[i].inGame = bool.Parse(SaveFile.ReadLine());
        //        if (playerOne.ships[i].position > -1) Display.position[playerOne.ships[i].position].busy = true;

        //        playerTwo.ships[i].speed = short.Parse(SaveFile.ReadLine());
        //        playerTwo.ships[i].position = short.Parse(SaveFile.ReadLine());
        //        playerTwo.ships[i].inGame = bool.Parse(SaveFile.ReadLine());
        //        if (playerTwo.ships[i].position > -1) Display.position[playerTwo.ships[i].position].busy = true;
        //    }

        //    playerOne.shipInCerter = short.Parse(SaveFile.ReadLine());
        //    playerTwo.shipInCerter = short.Parse(SaveFile.ReadLine());
        //    currentPointOnMap = short.Parse(SaveFile.ReadLine());
        //    startGame = bool.Parse(SaveFile.ReadLine());
        //    SaveFile.Close();
        //}
    }
}
