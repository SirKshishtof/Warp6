using Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players
{
    public struct Ship
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
        public bool InGame;
    }
    public struct Player
    {
        public Player(bool brush)
        {
            this.brash = brush;
            shipInCerter = 0;
            for (short i = 0; i < 4; i++) ships[i] = new Ship(1, i);

            for (short i = 4; i < 7; i++) ships[i] = new Ship(2, i);

            for (short i = 7; i < 9; i++) ships[i] = new Ship(3, i);
        }
        public Ship[] ships = new Ship[9];
        public short shipInCerter;
        public bool brash;
    }
    public class Enemy
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
                    player.ships[i].InGame = false;
                }
            }
            for (int i = 0; i < 9; i++)
            {
                if (player.ships[i].InGame) { index[i] = player.ships[i].speed; }
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
                    if (player.ships[j].speed >= max && !player.ships[j].InGame)
                    {
                        max = player.ships[j].speed;
                        count = j;
                    }
                }
                player.ships[count].InGame = true;
                list.Add(count);
                max = 0;
            }
            for (int i = 0; i < 9; i++)
            {
                player.ships[i].InGame = true;
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

        public int RandomStep()
        {
            Random rnd = new Random();
            return rnd.Next()%9;
        }
    }
}
