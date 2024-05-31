using Warp_6Core;
using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Design;

namespace Warp_6Core
{
    class Gameplay
    {
        private static string savePath = Directory.GetCurrentDirectory() + "\\Save\\";
        public static sbyte currentPointOnMap = 125;//Переменная показывающая позицию на которую будет выставлен корабль в начале
        //public static string SavePath { get { return savePath; } }
        public static DirectoryInfo directoryInfo = new DirectoryInfo(savePath);
        public static void CreateDirectory() => Directory.CreateDirectory(savePath);
        public static bool FileExists(string saveName) => File.Exists(savePath + saveName +".txt");
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
                enemy.ships[NumOfShip].SetOnSpiral(ref currentPointOnMap, false);
                enemy.list.RemoveAt(0);
                Display.DrawWhiteRectangle(NumOfShip, true);
                
                greenGoesFirst = false;
            }
            else message = "Вам повезло! Противник еще не прибыл! Вы ходите первым.";

            Display.ImageRefresh();
            MessageBox.Show(message, "Кто начинает");
        }
        public static void WhoGoesFirst(ref bool greenGoesFirst)
        {
            Random rnd = new Random();
            string message;
            if (rnd.Next() % 2 != 0)
            {
                message = "О нет! Противник прибыл раньше вас! Вы ходите вторым.";
                greenGoesFirst = false;
            }
            else message = "Вам повезло! Противник еще не прибыл! Вы ходите первым.";

            Display.ImageRefresh();
            MessageBox.Show(message, "Кто начинает");
        }
        public static void InitializationAllShips(Ship[] playerOne, Ship[] playerTwo)
        {
            for (sbyte i = 0; i < 9; i++)
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
            StreamWriter SaveFile = new StreamWriter(savePath + SaveName + ".txt");

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
        public static void DownloadingDataInShips(Player PlayerOne, Enemy enemy, string SaveName, ref string gamePhase)
        {
            StreamReader SaveFile = new StreamReader(savePath + SaveName+".txt");

            for (short i = 0; i < 126; i++) Display.position[i].busy = false;

            for (short i = 0; i < 9; i++)
            {
                PlayerOne.ships[i].speed = sbyte.Parse(SaveFile.ReadLine());
                PlayerOne.ships[i].position = sbyte.Parse(SaveFile.ReadLine());
                PlayerOne.ships[i].inGame = bool.Parse(SaveFile.ReadLine());
                if (PlayerOne.ships[i].position > -1) Display.position[PlayerOne.ships[i].position].busy = true;

                enemy.ships[i].speed = sbyte.Parse(SaveFile.ReadLine());
                enemy.ships[i].position = sbyte.Parse(SaveFile.ReadLine());
                enemy.ships[i].inGame = bool.Parse(SaveFile.ReadLine());
                if (enemy.ships[i].position > -1) Display.position[enemy.ships[i].position].busy = true;
            }

            PlayerOne.shipInCerter = sbyte.Parse(SaveFile.ReadLine());
            enemy.shipInCerter = sbyte.Parse(SaveFile.ReadLine());
            short listCount = sbyte.Parse(SaveFile.ReadLine());
            enemy.list.Clear();
            while (listCount > 0)
            {
                enemy.list.Add(sbyte.Parse(SaveFile.ReadLine()));
                listCount--;
            }
            currentPointOnMap = sbyte.Parse(SaveFile.ReadLine());
            gamePhase = SaveFile.ReadLine();
            SaveFile.Close();
        }
    }
}
