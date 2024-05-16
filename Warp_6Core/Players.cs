using Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Players
{
    public class Ship : IComparable<Ship>
    {
        public Ship(short type, short index)
        {
            this.type = type;
            this.index = index;
            position = -1;
        }
        public short index;
        public short position;
        public short type;
        public short speed;
        public bool inGame;
        //private void ShipOutOfGame(ref short shipInCenter, string message)
        //{
        //    shipInCenter++;
        //    inGame = false;
        //    string winOrLoss;
        //    if (message.Contains("Вы победили!")) winOrLoss = "Победа!";
        //    else winOrLoss = "Проигрыш...";
        //    if (shipInCenter == 6)
        //    {
        //        DialogResult result = MessageBox.Show(message, winOrLoss, MessageBoxButtons.YesNo);
        //        if (result == DialogResult.Yes) Application.Restart();
        //        else Application.Exit();
        //    }
        //}
        //private short SettingOfShipSpeed()
        //{
        //    Random rnd = new Random();
        //    short x = 0;

        //    switch (type)
        //    {
        //        case 1: x = 4; break;
        //        case 2: x = 6; break;
        //        case 3: x = 8; break;
        //    }

        //    return (short)(rnd.Next() % x + 1);
        //}
        //public static void SetShipOnSpiral(ref Ship ship, ref short currentPointOnMap, bool isThatHostsShip)
        //{
        //    ship.position = currentPointOnMap;
        //    Display.position[currentPointOnMap].busy = true;
        //    Display.DrawShip(ship, isThatHostsShip);
        //    currentPointOnMap--;
        //}
        //public static void MovingOfShip(ref Ship ship, ref short shipInCenter, string message)
        //{
        //    Display.position[ship.position].busy = false;
        //    if ((ship.position - ship.speed) < 0) ShipOutOfGame(ref ship, ref shipInCenter, message);
        //    else
        //    {
        //        ship.position -= ship.speed;
        //        while (Display.position[ship.position].busy && ship.inGame)
        //        {
        //            if (Display.position[ship.position].jump == -1) ShipOutOfGame(ref ship, ref shipInCenter, message);
        //            else ship.position = Display.position[ship.position].jump;
        //        }
        //        Display.position[ship.position].busy = true;
        //    }
        //}
        public int CompareTo(Ship? s)
        {
            if (s is null) throw new ArgumentException("Некорректное значение параметра");
            return speed.CompareTo(s.speed);
        }
    }
    class Player
    {
        public Player(bool brush)
        {
            this.brush = brush;
            shipInCerter = 0;
            for (short i = 0; i < 4; i++) ships[i] = new Ship(1, i);

            for (short i = 4; i < 7; i++) ships[i] = new Ship(2, i);

            for (short i = 7; i < 9; i++) ships[i] = new Ship(3, i);
        }
        public Ship[] ships = new Ship[9];
        public short shipInCerter;
        public bool brush;
    }
    class Enemy (bool brush) : Player (brush)
    {
        public List<short> list = new List<short>();
        
        public void EnemyShipSorting()
        {
            if (list.Count != 0) { list.Clear(); }
            short count = -1;
            int max = 0;
            int[] index = new int[9];

            for (short i = 0; i < 4; i++)
            {
                if (ships[i].speed > max)
                {
                    max = ships[i].speed;
                    count = i;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (i != count)
                {
                    ships[i].inGame = false;
                }
            }
            for (int i = 0; i < 9; i++)
            {
                if (ships[i].inGame) { index[i] = ships[i].speed; }
                else { index[i] = 0; }
            }

            for (int i = 0; i < 9; i++)
            {
                max = 0;
                for (short j = 0; j < 9; j++)
                {
                    if (index[j] > max)
                    {
                        max = index[j];
                        count = j;
                    }
                }
                if (max != 0) { index[count] = 0; list.Add(count); };
            }

            max = 0;
            for (int i = 0; i < 3; i++)
            {
                for (short j = 0; j < 4; j++)
                {
                    if (ships[j].speed >= max && !ships[j].inGame)
                    {
                        max = ships[j].speed;
                        count = j;
                    }
                }
                ships[count].inGame = true;
                list.Add(count);
                max = 0;
            }
            for (int i = 0; i < 9; i++)
            {
                ships[i].inGame = true;
            }
        }
        private int[] ArrZero(int[] Arr)
        {
            int size = Arr.Length;
            for (int i = 0; i < size; i++)
            {
                Arr[i] = 0;
            }
            return Arr;
        }

        bool MaxSppeed(short index)
        {
            if (ships[index].type == 1 && ships[index].speed == 4 ||
                ships[index].type == 2 && ships[index].speed == 6 ||
                ships[index].type == 3 && ships[index].speed == 8) return true;

            return false;
        }

        
        // 2 Вывод корабля в центр через 1 прыжок
        // 3 Вывод корабля в центр на прямую
        // 4 Ход с n прыжками
        // 5 Ход с 1 прыжком
        // 6 Увеличить скорость
        // 7 Уменьшить скорость
        // 8 Обычный ход
        // 9 Рандомный ход

        List<Ship> foo(Ship[] ships)
        {
            List<Ship> listBuf = new List<Ship>();
            List<Ship> list = new List<Ship>();
            listBuf.AddRange(ships);
            //list.Sort(list);//???????
            short count;
            short minSpeed = 10;
            short index=0;
            while (listBuf.Count > 0)
            {
                count = (short)(listBuf.Count);
                for (short i = 0; i < count; i++)
                {
                    if (listBuf[i].speed < minSpeed)
                    {
                        minSpeed = listBuf[i].speed;
                        index = i;
                    }
                }
                list.Add(listBuf[index]);
            }

            return list;
        }
        
        // 1 Вывод корабля в центр через n прыжков

        public short RandomStep()
        {
            Random rnd = new Random();
            List<short> shipsInGame = new List<short>();

            for (short i = 0; i < 9; i++) if (ships[i].inGame) shipsInGame.Add(i);

            short index = shipsInGame[rnd.Next() % shipsInGame.Count()];
            short action = (short)(rnd.Next() % 10);

            for (short j = 0; j < 20; j++)
            {
                if (action > 1) return (short)(index * 100);
                else
                {
                    short inc_dec = (short)(rnd.Next() % 2);

                    if (inc_dec == 0) if (ships[index].speed > 1) return (short)((index * 100) + (10));
                        else if (!MaxSppeed(index)) return (short)((index * 100) + (11));
                }
                index = shipsInGame[rnd.Next() % shipsInGame.Count()];
                action = (short)(rnd.Next() % 2);
            }
            return -1;
        }
    }
}


