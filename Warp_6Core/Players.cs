using Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players
{
    struct Ship
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
    }

    //class ShipComparer : IComparer<Ship>
    //{
    //    public int Compare(Ship? s1, Ship? s2)
    //    {
    //        if (s1 is null || s2 is null)
    //            throw new ArgumentException("Некорректное значение параметра");
    //        return s1.speed - s2.Name.Length;
    //    }
    //}
    struct Player
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
    class Enemy
    {
        public Player player;
        public List<short> list = new List<short>();
        public void EnemyShipSorting()
        {
            if (list.Count != 0) { list.Clear(); }
            short count = -1;
            int max = 0;
            int[] index = new int[9];

            for (short i = 0; i < 4; i++)
            {
                if (player.ships[i].speed > max)
                {
                    max = player.ships[i].speed;
                    count = i;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (i != count)
                {
                    player.ships[i].inGame = false;
                }
            }
            for (int i = 0; i < 9; i++)
            {
                if (player.ships[i].inGame) { index[i] = player.ships[i].speed; }
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
                    if (player.ships[j].speed >= max && !player.ships[j].inGame)
                    {
                        max = player.ships[j].speed;
                        count = j;
                    }
                }
                player.ships[count].inGame = true;
                list.Add(count);
                max = 0;
            }
            for (int i = 0; i < 9; i++)
            {
                player.ships[i].inGame = true;
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
            if (player.ships[index].type == 1 && player.ships[index].speed == 4 ||
                player.ships[index].type == 2 && player.ships[index].speed == 6 ||
                player.ships[index].type == 3 && player.ships[index].speed == 8) return true;

            return false;
        }

        // 1 Вывод корабля в центр через n прыжков
        // 2 Вывод корабля в центр через 1 прыжок
        // 3 Вывод корабля в центр на прямую
        // 4 Ход с n прыжками
        // 5 Ход с 1 прыжком
        // 6 Увеличить скорость
        // 7 Уменьшить скорость
        // 8 Обычный ход

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
        short PuttingShipInCenterThroughSomeJumps()
        {
            return 0;
        }

        public short RandomStep()
        {
            Random rnd = new Random();
            List<short> shipsInGame = new List<short>();

            for (short i = 0; i < 9; i++) if (player.ships[i].inGame) shipsInGame.Add(i);

            short index = shipsInGame[rnd.Next() % shipsInGame.Count()];
            short action = (short)(rnd.Next() % 10);

            for (short j = 0; j < 20; j++)
            {
                if (action > 1) return (short)(index * 100);
                else
                {
                    short inc_dec = (short)(rnd.Next() % 2);

                    if (inc_dec == 0) if (player.ships[index].speed > 1) return (short)((index * 100) + (10));
                        else if (!MaxSppeed(index)) return (short)((index * 100) + (11));
                }
                index = shipsInGame[rnd.Next() % shipsInGame.Count()];
                action = (short)(rnd.Next() % 2);
            }
            return -1;
        }
    }
}


