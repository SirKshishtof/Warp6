using Drawing;
using Ships;
using System;
using System.Windows.Forms;

namespace Game
{
    public delegate void Delegation (int index);

    public class Gameplay
    { 
        public short currentPoint = 125;

        public void MovingOfShip(TextBox ShipsCenterTextbox, ref Display display, ref Ship ship, string message, ref Delegation del)
        {
            display.position[ship.position].busy = false;
            if ((ship.position - ship.speed) < 0) ShipOutOfGame(ShipsCenterTextbox, ref ship, message, ref del);
            else
            {
                ship.position -= ship.speed;
                while (display.position[ship.position].busy && ship.InGame)
                {
                    if (display.position[ship.position].jump == -1) ShipOutOfGame(ShipsCenterTextbox, ref ship, message, ref del);
                    else ship.position = display.position[ship.position].jump;
                }
                display.position[ship.position].busy = true;
            }
        }

        void ShipOutOfGame(TextBox ShipsCenterTextbox, ref Ship ship, string message, ref Delegation del)
        {
            short shipInCenter = short.Parse(ShipsCenterTextbox.Text);
            shipInCenter++;
            ship.InGame = false;
            ShipsCenterTextbox.Text = shipInCenter.ToString();
            string winOrLoss;
            if (message.Contains("Вы победили!")){ del(ship.index); winOrLoss = "Победа!";}
            else { winOrLoss = "Проигрыш..."; }
            if (shipInCenter == 6)
            {
                DialogResult result = MessageBox.Show(message, winOrLoss, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) Application.Restart();
                else Application.Exit();
            }
        }

        public bool MaxSppeed(Ship ship)
        {
            if (ship.type == 1 && ship.speed == 4 ||
                ship.type == 2 && ship.speed == 6 ||
                ship.type == 3 && ship.speed == 8) return true;

            return false;
        }

        public void SetShipOnSpiral(Display display, ref Ship ship, bool isThatMyShip)
        {
            ship.position = currentPoint;
            display.position[currentPoint].busy = true;
            float x = display.X_GetCoord(ship);
            float y = display.Y_GetCoord(ship);
            switch (ship.type)
            {
                case 1: { display.DrawTriangle(isThatMyShip, x, y, ship.index + 1, ship.speed); } break;
                case 2: { display.DrawRectangle(isThatMyShip, x, y, ship.index + 1, ship.speed); } break;
                case 3: { display.DrawCircle(isThatMyShip, x, y, ship.index + 1, ship.speed); } break;
            }
            currentPoint--;
        }

        public void WhoGoesFirst(Display display, Enemy enemy)
        {
            Random rnd = new Random();
            string message;
            if (rnd.Next() % 2 != 0)
            {
                message = "О нет! Противник прибыл раньше вас! Вы ходите вторым.";
                short NumOfShip = enemy.list[0];
                SetShipOnSpiral(display, ref enemy.ships[NumOfShip], false);
                display.DrawWhiteRectangle(NumOfShip, true);
                enemy.list.RemoveAt(0);
            }
            else
            {
                message = "Вам повезло! Противник еще не прибыл! Вы ходите первым.";
            }
            display.PictureBoxRefresh();
            display.DrawImage();
            MessageBox.Show(message, "Кто начинает");
        }

        public void InitializationAllShips(Enemy enemy, Ship[] myShips)
        {
            Random rnd = new Random();

            for (short i = 0; i < 4; i++)
            {
                myShips[i].speed = (short)(rnd.Next() % 4 + 1);//Задание скорости корабля
                myShips[i].InGame = true;

                enemy.ships[i].speed = (short)(rnd.Next() % 4 + 1); ;//Задание скорости корабля
                enemy.ships[i].InGame = true;
            }

            for (short i = 4; i < 7; i++)
            {
                myShips[i].speed = (short)(rnd.Next() % 6 + 1);//Задание скорости корабля
                myShips[i].InGame = true;

                enemy.ships[i].speed = (short)(rnd.Next() % 6 + 1); ;//Задание скорости корабля
                enemy.ships[i].InGame = true;
            }

            for (short i = 7; i < 9; i++)
            {
                myShips[i].speed = (short)(rnd.Next() % 8 + 1);//Задание скорости корабля
                myShips[i].InGame = true;

                enemy.ships[i].speed = (short)(rnd.Next() % 8 + 1); ;//Задание скорости корабля
                enemy.ships[i].InGame = true;
            }
        }
    }
}
