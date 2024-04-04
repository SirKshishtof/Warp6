using Game;
using Players;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing
{ 
    struct Addres_Dash
    {
        public int _external;
        public int _internal;
    }
    struct Position
    {
        public Position()
        {
            jump = -1;
            busy = false;
        }

        public double x;
        public double y;
        public short jump;
        public bool busy;
    }
    static class Display
    {
        static Graphics graphics;
        static Graphics graph_bitmap;
        static Bitmap bitmap;
        static PictureBox pictureBox;
        static Pen BlackPen = new Pen(Color.Black, 3);
        static SolidBrush BrushBlack = new SolidBrush(Color.Black);
        static Addres_Dash[] addres_dash = new Addres_Dash[30];

        static public Position[] position = new Position[126];

        const double TURN = 3.11;//Коффициент задающий поворот спирали и точек
        const short VERTICALSHEAR = 20;//Сдвиг всей картинки относительно оси Y 
        const double KOF = 12;//Коффициент задающий ширину между витками спирали и точек
        const short FONTSMALL = 12;//Шрифт меленькой цифры на фигуре
        const short FONTBIG = 25;//Шрифт большой цифры на фигуре

        public static void InitializationMap(PictureBox picBox)
        {
            pictureBox = picBox;
            bitmap = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            graph_bitmap = Graphics.FromImage(bitmap);
            graphics = pictureBox.CreateGraphics();

            short[] index = new short[6] { 0, 1, 2, 3, 4, 5 };
            short count = 6;
            short dest = 6;
            float x;
            float y;
            float pi;
            float start_angle;
            float step;

            //Сохранение прыжков
            for (short i = 2; i <= 6; i++)
            {
                for (short j = 0; j < 6; j++)
                {
                    for (short k = 0; k < 2; k++)
                    {
                        position[count].jump = index[j];
                        count++;
                    }
                    index[j]++;
                    for (short k = 2; k < i; k++)
                    {
                        position[count].jump = index[j];
                        index[j]++;
                        count++;
                    }
                }
                index[0] = index[5];
                for (short j = 1; j < 6; j++)
                {
                    index[j] = (short)(index[j - 1] + i);
                }
            }

            //Сохранение координат точек
            pi = 3.7f;
            start_angle = 1.047f;
            count = 0;
            for (int i = 1; i <= 6; i++)
            {
                step = start_angle;
                step = step / i;
                for (int j = 0; j < 6 * i; j++)
                {
                    x = PolarToX(pi);
                    y = PolarToY(pi);
                    position[count].y = y + VERTICALSHEAR;
                    position[count].x = x;
                    position[count].busy = false;
                    count++;

                    pi += step;
                }
            }

            //Сохранение координат пунктирных линий
            addres_dash[0]._external = 95;
            addres_dash[0]._internal = 0;

            for (int i = 1; i < 5; i++)
            {
                addres_dash[i]._external = addres_dash[i - 1]._external - 1;
                addres_dash[i]._internal = addres_dash[i - 1]._internal + dest * i;
            }

            count = 5;

            for (short i = 0; i < 5; i++)
            {
                for (short j = 1; j < 6; j++)
                {
                    addres_dash[count]._external = addres_dash[count - 5]._external + dest;
                    addres_dash[count]._internal = addres_dash[count - 5]._internal + j;
                    count++;
                }
            }
        }
        static float PolarToX(float pi)//перевод полярной координаты в координату X
        {
            double p = pi * KOF;
            float x = (float)(p * Math.Cos(pi + TURN) + pictureBox.Size.Width / 2);
            return x;
        }
        static float PolarToY(float pi)//перевод полярной координаты в координату Y
        {
            double p = pi * KOF;
            float y = (float)(p * Math.Sin(pi + TURN) + pictureBox.Size.Height / 2 - 25);
            return y;
        }
        public static float X_GetCoord(Ship Ship)//получение координаты х корабля
        {
            return (float)position[Ship.position].x;
        }
        public static float Y_GetCoord(Ship Ship)//получение координаты у корабля
        {
            return (float)position[Ship.position].y;
        }

        static void DrawDashLine(int a, int b)
        {
            graph_bitmap.DrawLine(BlackPen, (float)position[a].x, (float)position[a].y, (float)position[b].x, (float)position[b].y);
        }
        static void DrawCircle(double x, double y, float radius)
        {
            graph_bitmap.FillEllipse(BrushBlack, (float)(x - (radius / 2)), (float)(y - (radius / 2)), radius, radius);
        }

        public static void DrawTriangle(bool isThatMyShip, float x, float y, int numShip, int speedOfShip)
        {
            SolidBrush brush;
            if (isThatMyShip) { brush = new SolidBrush(Color.LimeGreen); }
            else { brush = new SolidBrush(Color.Gold); }

            string TextNumShip = Convert.ToString(numShip);
            string TextPowerOfShip = Convert.ToString(speedOfShip);
            Font FontNumShip = new Font("Arial", FONTSMALL);
            Font FontPowerOfShip = new Font("Arial", FONTBIG);
            float radius = 40;
            float Shift = (float)Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(radius / 2, 2));
            PointF TopPoint = new PointF(x, y - radius);
            PointF BottomLeftPoint = new PointF(x - Shift, y + (radius / 2));
            PointF BottomRightPoint = new PointF(x + Shift, y + (radius / 2));
            PointF[] angelPoints = { TopPoint, BottomLeftPoint, BottomRightPoint };
            graph_bitmap.FillPolygon(brush, angelPoints);
            graph_bitmap.DrawString(TextPowerOfShip, FontPowerOfShip, BrushBlack, x - (radius / 3) - 4, y - (radius / 2) - 4);
            graph_bitmap.DrawString(TextNumShip, FontNumShip, BrushBlack, x - (radius / 3) - 13, y - (radius / 2) + 18);
        }
        public static void DrawRectangle(bool isThatMyShip, float x, float y, int numShip, int speedOfShip)
        {
            SolidBrush brush;
            if (isThatMyShip) { brush = new SolidBrush(Color.LimeGreen); }
            else { brush = new SolidBrush(Color.Gold); }

            string TextNumShip = Convert.ToString(numShip);
            string TextPowerOfShip = Convert.ToString(speedOfShip);
            Font FontNumShip = new Font("Arial", FONTSMALL);
            Font FontPowerOfShip = new Font("Arial", FONTBIG);
            float radius = 50;
            graph_bitmap.FillRectangle(brush, x - (radius / 2), y - (radius / 2), radius, radius);
            graph_bitmap.DrawString(TextPowerOfShip, FontPowerOfShip, BrushBlack, x - (radius / 3) + 3, y - (radius / 2) + 2);
            graph_bitmap.DrawString(TextNumShip, FontNumShip, BrushBlack, x - (radius / 3) - 8, y - (radius / 2) + 14);
        }
        public static void DrawCircle(bool isThatMyShip, float x, float y, int numShip, int speedOfShip)
        {
            SolidBrush brush;
            if (isThatMyShip) { brush = new SolidBrush(Color.LimeGreen); }
            else { brush = new SolidBrush(Color.Gold); }

            string TextNumShip = Convert.ToString(numShip);
            string TextPowerOfShip = Convert.ToString(speedOfShip);
            Font FontNumShip = new Font("Arial", FONTSMALL);
            Font FontPowerOfShip = new Font("Arial", FONTBIG);
            float radius = 55;
            graph_bitmap.FillEllipse(brush, x - (radius / 2), y - (radius / 2), radius, radius);
            graph_bitmap.DrawString(TextPowerOfShip, FontPowerOfShip, BrushBlack, x - (radius / 3) + 6, y - (radius / 2) + 5);
            graph_bitmap.DrawString(TextNumShip, FontNumShip, BrushBlack, x - (radius / 3) - 3, y - (radius / 2) + 17);
        }
        public static void DrawMap()
        {
            float x = 0;
            float y = 0;

            float pi = 0;
            float radius = 40;
            graph_bitmap.Clear(Color.White);

            BlackPen.DashStyle = DashStyle.Dash;

            DrawCircle(pictureBox.Size.Width / 2, pictureBox.Size.Height / 2 - 8, radius);

            radius = 4;
            //Отрисовывание сприрали 
            for (int i = 0; i < 41400; i++)
            {
                x = PolarToX(pi);
                y = PolarToY(pi);
                DrawCircle(x, y + VERTICALSHEAR, radius);
                pi += 0.001f;
            }
            //Отрисовывание точек
            radius = 30;

            for (int i = 0; i < 126; i++)
            {
                DrawCircle(position[i].x, position[i].y, radius);
            }

            DrawDashLine(90, 108);
            DrawDashLine(96, 114);
            DrawDashLine(102, 120);

            for (int i = 0; i < 30; i++)
            {
                DrawDashLine(addres_dash[i]._external, addres_dash[i]._internal);
            }

            PointF[] points = new PointF[3];

            float xOfPoint = (float)x;
            float yOfPoint = (float)y + 20;

            for (int i = 0; i < 3; i++)
            {
                //C
                points[0].X = (float)xOfPoint;
                points[0].Y = (float)yOfPoint;
                //A
                points[1].X = (float)(xOfPoint - 22f);
                points[1].Y = (float)(yOfPoint + 8f);
                //B
                points[2].X = (float)(xOfPoint - 3f);
                points[2].Y = (float)(yOfPoint + 22f);

                xOfPoint = (points[1].X + points[2].X) / 2;
                yOfPoint = (points[1].Y + points[2].Y) / 2;
                graph_bitmap.FillPolygon(BrushBlack, points);
            }
        }
        public static void DrawWhiteRectangle(int numOfShip, bool enemy)
        {
            float radius = 70;
            float x;
            float y = 155 + 80 * (numOfShip);

            if (enemy) { x = 1300; }
            else { x = 130; }

            graph_bitmap.FillRectangle(new SolidBrush(Color.White), x - (radius / 2), y - (radius / 2), radius, radius);
            graphics.DrawImage(bitmap, 0, 0, pictureBox.Size.Width, pictureBox.Size.Height);

        }
        public static void DrawingShipsOnSides(Ship[] myShips, Ship[] enemyShips)
        {
            float xLeft = 130;
            float xRight = 1300;
            float y = 160;
            float Shift = 80;

            for (int i = 0; i < 4; i++)
            {
                DrawTriangle(true, xLeft, y, i + 1, myShips[i].speed);
                DrawTriangle(false, xRight, y, i + 1, enemyShips[i].speed);
                y += Shift;
            }

            for (int i = 4; i < 7; i++)
            {
                DrawRectangle(true, xLeft, y, i + 1, myShips[i].speed);
                DrawRectangle(false, xRight, y, i + 1, enemyShips[i].speed);
                y += Shift;
            }

            for (int i = 7; i < 9; i++)
            {
                DrawCircle(true, xLeft, y, i + 1, myShips[i].speed);
                DrawCircle(false, xRight, y, i + 1, enemyShips[i].speed);
                y += Shift;
            }
        }
        public static void DrawMapAndShips(Ship[] playerOne, Ship[] PlayerTwo)
        {
            DrawMap();
            for (int i = 0; i < 4; i++)
            {
                if (playerOne[i].inGame) DrawTriangle(true, X_GetCoord(playerOne[i]), Y_GetCoord(playerOne[i]), i + 1, playerOne[i].speed);
                if (PlayerTwo[i].inGame) DrawTriangle(false, X_GetCoord(PlayerTwo[i]), Y_GetCoord(PlayerTwo[i]), i + 1, PlayerTwo[i].speed);
            }

            for (int i = 4; i < 7; i++)
            {
                if (playerOne[i].inGame) DrawRectangle(true, X_GetCoord(playerOne[i]), Y_GetCoord(playerOne[i]), i + 1, playerOne[i].speed);
                if (PlayerTwo[i].inGame) DrawRectangle(false, X_GetCoord(PlayerTwo[i]), Y_GetCoord(PlayerTwo[i]), i + 1, PlayerTwo[i].speed);
            }

            for (int i = 7; i < 9; i++)
            {
                if (playerOne[i].inGame) DrawCircle(true, X_GetCoord(playerOne[i]), Y_GetCoord(playerOne[i]), i + 1, playerOne[i].speed);
                if (PlayerTwo[i].inGame) DrawCircle(false, X_GetCoord(PlayerTwo[i]), Y_GetCoord(PlayerTwo[i]), i + 1, PlayerTwo[i].speed);
            }
            graphics.DrawImage(bitmap, 0, 0, pictureBox.Size.Width, pictureBox.Size.Height);
        }
        public static void DrawImage()
        {
            graphics.DrawImage(bitmap, 0, 0, pictureBox.Size.Width, pictureBox.Size.Height);
        }
        public static void PictureBoxRefresh()
        {
            pictureBox.Refresh();
        }
        public static void DrawShipAfterLoading(bool myShips, Ship ship, ref bool onPosition)
        {
            float x;
            float y;
            float yOnSide = 160;
            float shift = 80;
            if (ship.inGame)
            {
                if (ship.position == -1)
                {
                    if (myShips) x = 130;
                    else x = 1300;
                    y = yOnSide + shift * ship.index;
                    onPosition = true;
                }
                else
                {
                    x = X_GetCoord(ship);
                    y = Y_GetCoord(ship);
                }

                switch (ship.type)
                {
                    case 1: DrawTriangle(myShips, x, y, ship.index + 1, ship.speed); break;
                    case 2: DrawRectangle(myShips, x, y, ship.index + 1, ship.speed); break;
                    case 3: DrawCircle(myShips, x, y, ship.index + 1, ship.speed); break;
                }
            }
        }
    }
}
