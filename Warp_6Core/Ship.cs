using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warp_6Core
{
    public class Ship : IComparable<Ship>
    {
        public Ship(sbyte type, sbyte index)
        {
            this.type = type;
            this.index = index;
        }
        public sbyte index;
        public sbyte position;
        public sbyte type;
        public sbyte speed;
        public bool inGame;
        private void OutOfGame(ref sbyte shipInCenter, string message)
        {
            shipInCenter++;
            inGame = false;
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
        public void Move(ref sbyte shipInCenter, string message)
        {
            Display.position[position].busy = false;
            if ((position - speed) < 0) OutOfGame(ref shipInCenter, message);
            else
            {
                position -= speed;
                while (Display.position[position].busy && inGame)
                {
                    if (Display.position[position].jump == -1) OutOfGame(ref shipInCenter, message);
                    else position = Display.position[position].jump;
                }
                Display.position[position].busy = true;
            }
        }
        public void SetSpeed()
        {
            Random rnd = new Random();
            short x = 0;

            switch (type)
            {
                case 1: x = 4; break;
                case 2: x = 6; break;
                case 3: x = 8; break;
            }

            speed = (sbyte)(rnd.Next() % x + 1);
        }
        public void SetOnSpiral(ref sbyte currentPointOnMap, bool isThatHostsShip)
        {
            position = currentPointOnMap;
            Display.position[currentPointOnMap].busy = true;
            Display.DrawShip(this, isThatHostsShip);
            currentPointOnMap--;
        }

        public int CompareTo(Ship? s)
        {
            if (s is null) throw new ArgumentException("Некорректное значение параметра");
            return speed.CompareTo(s.speed);
        }
    }
}
