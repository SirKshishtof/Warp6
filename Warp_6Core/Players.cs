using System;
using System.Collections.Generic;
using System.Linq;


namespace Warp_6Core
{ 
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


