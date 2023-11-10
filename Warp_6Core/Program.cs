using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warp_6Core;

namespace Warp_6
{
    //public struct Position
    //{
    //    public Position()
    //    {
    //        jump = -1;
    //    }
    //    public double x;
    //    public double y;
    //    public int jump;
    //    public bool busy;
    //}

    //struct Ship
    //{
    //    public Ship(int type)
    //    {
    //        InGame = true;
    //        this.type = type;
    //    }
    //    public int position;
    //    public int type;
    //    public int speed;
    //    public bool InGame;
    //}

    //class Enemy
    //{
    //    public Ship[] ship = new Ship[9];

    //    public List<int> EnemyShipSorting()
    //    {
    //        int count = -1;
    //        int max = 0;
    //        int[] index = new int[9];
    //        List<int> list = new List<int>();

    //        for (int i = 0; i < 4; i++)
    //        {
    //            if (ship[i].speed > max)
    //            {
    //                max = ship[i].speed;
    //                count = i;
    //            }
    //        }
    //        for (int i = 0; i < 4; i++)
    //        {
    //            if (i != count)
    //            {
    //                ship[i].InGame = false;
    //            }
    //        }
    //        for (int i = 0; i < 9; i++)
    //        {
    //            if (ship[i].InGame) { index[i] = ship[i].speed; }
    //            else { index[i] = 0; }
    //        }

    //        for (int i = 0; i < 9; i++)
    //        {
    //            max = 0;
    //            for (int j = 0; j < 9; j++)
    //            {
    //                if (index[j] > max)
    //                {
    //                    max = index[j];
    //                    count = j;
    //                }
    //            }
    //            if (max != 0) { index[count] = 0; list.Add(count); };
    //        }

    //        max = 0;
    //        for (int i = 0; i < 3; i++)
    //        {
    //            for (int j = 0; j < 4; j++)
    //            {
    //                if (ship[j].speed >= max && !ship[j].InGame)
    //                {
    //                    max = ship[j].speed;
    //                    count = j;
    //                }
    //            }
    //            ship[count].InGame = true;
    //            list.Add(count);
    //            max = 0;
    //        }
    //        for (int i = 0; i < 9; i++)
    //        {
    //            ship[i].InGame = true;
    //        }
    //        return list;
    //    }
    //    /*{
    //   public void AlexMovesShip(Position[] position)
    //   {
    //       int BotMove = AlexСhoosesShip();
    //       int index = BotMove / 100;
    //       if ((BotMove / 10) % 10 == 0)
    //       {
    //           position[ship[index].position].busy = false;
    //           ship[index].position = ship[index].position - ship[index].speed;
    //           if (ship[index].position < 0)
    //           {
    //               ship[index].InGame = false;
    //               EnemyShipsInCenter++;
    //           }
    //           else
    //           {
    //               if (position[ship[index].position].busy) { ship[index].position = position[ship[index].position].jump; }
    //               while (position[ship[index].position].busy && ship[index].InGame == true)
    //               {
    //                   if (position[ship[index].position].jump != -1)
    //                   {
    //                       ship[index].position = position[ship[index].position].jump;
    //                   }
    //                   else
    //                   {
    //                       ship[index].InGame = false;
    //                       EnemyShipsInCenter++;
    //                   }
    //               }
    //               position[ship[index].position].busy = true;
    //           }
    //           EnemyShipsCenterTextbox.Text = EnemyShipsInCenter.ToString();
    //       }
    //       else
    //       {
    //           if (BotMove % 10 == 0) { ship[index].speed--; }
    //           else { ship[index].speed++; }
    //       }
    //       Thread.Sleep(2000);
    //       //DrawEverything();
    //   }
    //   int HyperjumpToCenter()
    //   {
    //       //Может ли корабль попасть в центр через гипер прыжки
    //       int[] SpeedOfShip = new int[9];
    //       bool stop = false;
    //       int index = 0;
    //       int min = 126;
    //       int count = 0;
    //       SpeedOfShip = ArrZero(SpeedOfShip);
    //       for (int i = 0; i < 9; i++)
    //       {
    //           if (ship[i].InGame)
    //           {
    //               count = 0;
    //               index = ship[i].position - ship[i].speed;
    //               if (index > -1)
    //               {
    //                   while (!stop)
    //                   {
    //                       if (position[index].busy)
    //                       {
    //                           if (position[index].jump == -1)
    //                           {
    //                               SpeedOfShip[i]++;
    //                               stop = true;
    //                           }
    //                           else
    //                           {
    //                               index = position[index].jump;
    //                           }
    //                       }
    //                       else
    //                       {
    //                           stop = true;
    //                       }
    //                       count++;
    //                       if (count == 6) { stop = true; }
    //                   }
    //               }
    //           }
    //       }
    //       stop = false;
    //       for (int i = 0; i < 9; i++)
    //       {
    //           if (SpeedOfShip[i] == 1)
    //           {
    //               if (ship[i].position < min)
    //               {
    //                   index = i;
    //                   min = ship[i].position;
    //                   stop = true;
    //               }
    //           }
    //       }
    //       if (stop) { return index * 100; }
    //       else { return -1; }
    //   }
    //   int ToCenter()
    //   {
    //       int[] SpeedOfShip = new int[9];
    //       bool stop;
    //       int index = 0;
    //       int min = 126;
    //       SpeedOfShip = ArrZero(SpeedOfShip);
    //       for (int i = 0; i < 9; i++)
    //       {
    //           if (ship[i].InGame)
    //           {
    //               index = ship[i].position - ship[i].speed;
    //               if (index < 0) { SpeedOfShip[i]++; }
    //           }
    //       }
    //       stop = false;
    //       for (int i = 0; i < 9; i++)
    //       {
    //           if (SpeedOfShip[i] == 1)
    //           {
    //               if (ship[i].position < min)
    //               {
    //                   index = i;
    //                   min = ship[i].position;
    //                   stop = true;
    //               }
    //           }
    //       }
    //       if (stop) { return index * 100; }
    //       else { return -1; }
    //   }
    //   int Hyperjump()
    //   {
    //       int[] SpeedOfShip = new int[9];
    //       bool stop;
    //       int index = 0;
    //       int min;
    //       int max = -1;
    //       int count;
    //       SpeedOfShip = ArrZero(SpeedOfShip);
    //       for (int i = 0; i < 9; i++)
    //       {
    //           if (ship[i].InGame)
    //           {
    //               count = 0;
    //               index = ship[i].position - ship[i].speed;
    //               if (index > -1)
    //               {
    //                   stop = false;
    //                   while (!stop)
    //                   {
    //                       if (position[index].busy)
    //                       {
    //                           SpeedOfShip[i]++;
    //                           index = position[index].jump;
    //                       }
    //                       else
    //                       {
    //                           stop = true;
    //                       }
    //                       count++;
    //                       if (count == 6) { stop = true; }
    //                   }
    //               }
    //           }
    //       }
    //       min = 10;
    //       stop = false;
    //       for (int i = 0; i < 9; i++)
    //       {
    //           if (SpeedOfShip[i] > 0)
    //           {
    //               if (SpeedOfShip[i] > max)
    //               {
    //                   index = i;
    //                   max = SpeedOfShip[i];
    //               }
    //               else
    //               {
    //                   if (SpeedOfShip[i] == max)
    //                   {
    //                       if (ship[i].speed < min)
    //                       {
    //                           index = i;
    //                           min = ship[i].speed;
    //                       }
    //                   }
    //               }
    //               stop = true;
    //           }
    //       }
    //       if (stop) { return index * 100; }
    //       else { return -1; }
    //   }
    //   int HyperjumpInTheFuturePlus()
    //   {
    //       int[] SpeedOfShip = new int[9];
    //       bool stop = false;
    //       int index = 0;
    //       int min = 10;
    //       int count;
    //       SpeedOfShip = ArrZero(SpeedOfShip);
    //       for (int i = 0; i < 9; i++)
    //       {
    //           if (ship[i].InGame && ship[i].speed != 1)
    //           {
    //               count = 0;
    //               index = ship[i].position - ship[i].speed - 1;
    //               if (index > -1)
    //               {
    //                   while (!stop)
    //                   {
    //                       if (position[index].busy)
    //                       {
    //                           if (position[index].jump == -1)
    //                           {
    //                               SpeedOfShip[i]++;
    //                               stop = true;
    //                           }
    //                           else
    //                           {
    //                               index = position[index].jump;
    //                           }
    //                       }
    //                       else
    //                       {
    //                           stop = true;
    //                       }
    //                       count++;
    //                       if (count == 6) { stop = true; }
    //                   }
    //               }
    //           }
    //       }
    //       stop = false;
    //       for (int i = 0; i < 9; i++)
    //       {
    //           if (SpeedOfShip[i] == 1)
    //           {
    //               if (ship[i].speed < min)
    //               {
    //                   index = i;
    //                   min = ship[i].speed;
    //                   stop = true;
    //               }
    //           }
    //       }
    //       if (stop) { return index * 100 + 10 + 1; }
    //       else { return -1; }
    //   }
    //   int HyperjumpInTheFutureMinus()
    //   {
    //       int[] SpeedOfShip = new int[9];
    //       bool stop = false;
    //       int index = 0;
    //       int max = -1;
    //       int count = 0;
    //       SpeedOfShip = ArrZero(SpeedOfShip);
    //       stop = false;
    //       for (int i = 0; i < 9; i++)
    //       {
    //           if (ship[i].InGame && ((ship[i].type == 1 && ship[i].speed != 4) || (ship[i].type == 2 && ship[i].speed != 6) && (ship[i].type == 3 && ship[i].speed != 8)))
    //           {
    //               count = 0;
    //               index = ship[i].position - ship[i].speed + 1;
    //               if (index > -1)
    //               {
    //                   while (!stop)
    //                   {
    //                       if (position[index].busy)
    //                       {
    //                           if (position[index].jump == -1)
    //                           {
    //                               SpeedOfShip[i]++;
    //                               stop = true;
    //                           }
    //                           else
    //                           {
    //                               index = position[index].jump;
    //                           }
    //                       }
    //                       else
    //                       {

    //                           stop = true;
    //                       }
    //                       count++;
    //                       if (count == 6) { stop = true; }
    //                   }
    //               }
    //           }
    //       }
    //       stop = false;
    //       max = 0;
    //       for (int i = 0; i < 9; i++)
    //       {
    //           if (SpeedOfShip[i] == 1)
    //           {
    //               if (ship[i].speed > max)
    //               {
    //                   index = i;
    //                   max = ship[i].speed;
    //                   stop = true;
    //               }
    //           }
    //       }
    //       if (stop) { return index * 100 + 10 + 0; }
    //       else { return -1; }
    //   }
    //   int Jump()
    //   {
    //       int index = 0;
    //       int max = -1;
    //       for (int i = 0; i < 9; i++)
    //       {
    //           if (ship[i].InGame)
    //           {
    //               if (ship[i].speed > max)
    //               {
    //                   index = i;
    //                   max = ship[i].speed;
    //               }
    //           }
    //       }
    //       return index * 100;
    //   }
    //   int AlexСhoosesShip()
    //   {
    //       int index;
    //       index = HyperjumpToCenter();
    //       if (index != -1) { return index; }

    //       index = ToCenter();
    //       if (index != -1) { return index; }

    //       index = Hyperjump();
    //       if (index != -1) { return index; }

    //       index = HyperjumpInTheFuturePlus();
    //       if (index != -1) { return index; }

    //       index = HyperjumpInTheFutureMinus();
    //       if (index != -1) { return index; }

    //       if (rnd.Next() % 100 < 30)
    //       {
    //           bool flag = true;
    //           while (flag)
    //           {
    //               index = (rnd.Next() % 9) * 100;
    //               if (ship[index].InGame) { flag = false; }
    //           }
    //       }
    //       else { index = Jump(); }
    //       return index;
    //   }
    //   }
    //   */
    //}
    //struct Addres_Dash
    //{
    //    public int _external;
    //    public int _internal;
    //}

   
    internal static class Program
    {
       
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MenuForm());
        }

    }
}
