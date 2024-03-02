using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ships
{
    public struct Ship
    {
        public Ship(short type)
        {
            InGame = true;
            this.type = type;
            position = -1;
        }
        public short position;
        public short type;
        public short speed;
        public bool InGame;
    }

    public class Enemy
    {
        public Ship[] ship = new Ship[9];
        public List<short> list = new List<short>();
        public void EnemyShipSorting()
        {
            if (list.Count != 0) { list.Clear(); }
            short count = -1;
            int max = 0;
            int[] index = new int[9];

            for (short i = 0; i < 4; i++)
            {
                if (ship[i].speed > max)
                {
                    max = ship[i].speed;
                    count = i;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (i != count)
                {
                    ship[i].InGame = false;
                }
            }
            for (int i = 0; i < 9; i++)
            {
                if (ship[i].InGame) { index[i] = ship[i].speed; }
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
                    if (ship[j].speed >= max && !ship[j].InGame)
                    {
                        max = ship[j].speed;
                        count = j;
                    }
                }
                ship[count].InGame = true;
                list.Add(count);
                max = 0;
            }
            for (int i = 0; i < 9; i++)
            {
                ship[i].InGame = true;
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
    }
}
