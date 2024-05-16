using Game;
using Players;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Drawing
{ 
    struct DashLine
    {
        public int externalDot;
        public int internalDot;
    }
    class Position
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
        private const double TURN = 3.11;//Коффициент задающий поворот спирали и точек по единичной окружности
        private const short VERTICALSHEAR = 20;//Сдвиг всей картинки относительно оси Y 
        private const double KOF = 12;//Коффициент задающий ширину между витками спирали и точек
        private const short FONTSMALL = 12;//Шрифт меленькой цифры на фигуре
        private const short FONTBIG = 25;//Шрифт большой цифры на фигуре

        private static Graphics graphics;
        private static Graphics graph_bitmap;
        private static Bitmap bitmap;
        private static PictureBox pictureBox;
        private static Pen BlackPen = new Pen(Color.Black, 3);
        private static SolidBrush BrushBlack = new SolidBrush(Color.Black);
        private static DashLine[] addres_dash = new DashLine[30];

        public static Position[] position = new Position[126];


        private static void CreatinJumpsAlongDottedLines()
        {
            short indexJumpTo = 0;//Показывает индексы точек, НА которые происходит прыжок
            short indexPos = 6; //Показывает индексы точек, С которых происходит прыжок

            //Сохранение прыжков по пунктирным линиям
            for (short i = 2; i < 7; i++)
            {
                for (short j = 0; j < 6; j++)
                {
                    for (short k = 0; k < 2; k++)
                    {
                        position[indexPos].jump = indexJumpTo;
                        indexPos++;
                    }
                    indexJumpTo++;
                    for (short k = 2; k < i; k++)
                    {
                        position[indexPos].jump = indexJumpTo;
                        indexJumpTo++;
                        indexPos++;
                    }
                }
            }
        }
        private static void SavingLargePointCoordinates()
        { 
            //Сохранение координат больших точек
            float pi = 3.7f;
            float start_angle = 1.047f;
            short indexPos = 0;
            float x;
            float y;
            float step;
            for (int i = 1; i <= 6; i++)
            {
                step = start_angle;
                step = step / i;
                for (int j = 0; j < 6 * i; j++)
                {
                    x = PolarToX(pi);
                    y = PolarToY(pi);
                    position[indexPos].y = y + VERTICALSHEAR;
                    position[indexPos].x = x;
                    position[indexPos].busy = false;
                    indexPos++;

                    pi += step;
                }
            }
        }
        private static void SavingEndsCoordinatesOfDottedLines()
        {
            short dest = 6;
            short indexPos = 5;

            addres_dash[0].externalDot = 95;
            addres_dash[0].internalDot = 0;

            for (int i = 1; i < 5; i++)
            {
                addres_dash[i].externalDot = addres_dash[i - 1].externalDot - 1;
                addres_dash[i].internalDot = addres_dash[i - 1].internalDot + dest * i;
            }

            indexPos = 5;

            for (short i = 0; i < 5; i++)
            {
                for (short j = 1; j < 6; j++)
                {
                    addres_dash[indexPos].externalDot = addres_dash[indexPos - 5].externalDot + dest;
                    addres_dash[indexPos].internalDot = addres_dash[indexPos - 5].internalDot + j;
                    indexPos++;
                }
            }
        }
        private static float PolarToX(float pi)//перевод полярной координаты в координату X
        {
            double p = pi * KOF;
            float x = (float)(p * Math.Cos(pi + TURN) + pictureBox.Size.Width / 2);
            return x;
        }
        private static float PolarToY(float pi)//перевод полярной координаты в координату Y
        {
            double p = pi * KOF;
            float y = (float)(p * Math.Sin(pi + TURN) + pictureBox.Size.Height / 2 - 25);
            return y;
        }
        private static float X_GetCoord(Ship Ship) => (float)position[Ship.position].x;//получение координаты х корабля
        private static float Y_GetCoord(Ship Ship) => (float)position[Ship.position].y;//получение координаты у корабля
        private static void DrawImage() => graphics.DrawImage(bitmap, 0, 0, pictureBox.Size.Width, pictureBox.Size.Height);
        private static void PictureBoxRefresh() => pictureBox.Refresh();
        private static void DrawDashLine(int a, int b)
        {
            graph_bitmap.DrawLine(BlackPen, (float)position[a].x, (float)position[a].y, (float)position[b].x, (float)position[b].y);
        }
        private static void DrawCircle(double x, double y, float radius)
        {
            graph_bitmap.FillEllipse(BrushBlack, (float)(x - (radius / 2)), (float)(y - (radius / 2)), radius, radius);
        }
        private static void GetCoord(Ship ship, out float x, out float y, bool isThatHostsShip)
        {
            x = 0;
            y = 0;
            float shift = 80;//Растояне между кораблями по бокам
            if (ship.inGame)
            {
                if (ship.position == -1)
                {
                    if (isThatHostsShip) x = 130;
                    else x = 1300;
                    y = 160 + shift * ship.index;
                }
                else
                {
                    x = X_GetCoord(ship);
                    y = Y_GetCoord(ship);
                }
            }
        }
        private static void DrawAllShips(Ship[] playerOneShips, Ship[] PlayerTwoShips)
        {
            for (int i = 0; i < 4; i++)
            {
                if (playerOneShips[i].inGame) DrawTriangleShip(playerOneShips[i], true);
                if (PlayerTwoShips[i].inGame) DrawTriangleShip(PlayerTwoShips[i], false);
            }

            for (int i = 4; i < 7; i++)
            {
                if (playerOneShips[i].inGame) DrawRectangleShip(playerOneShips[i], true);
                if (PlayerTwoShips[i].inGame) DrawRectangleShip(PlayerTwoShips[i], false);
            }

            for (int i = 7; i < 9; i++)
            {
                if (playerOneShips[i].inGame) DrawCircleShip(playerOneShips[i], true);
                if (PlayerTwoShips[i].inGame) DrawCircleShip(PlayerTwoShips[i], false);
            }
        }
        private static void DrawMap()
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
                DrawDashLine(addres_dash[i].externalDot, addres_dash[i].internalDot);
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
        private static void DrawTriangleShip(Ship ship, bool isThatHostsShip)
        {
            Font FontNumShip = new Font("Arial", FONTSMALL);
            Font FontPowerOfShip = new Font("Arial", FONTBIG);
            SolidBrush brush;
            string TextNumShip = Convert.ToString(ship.index + 1);
            string TextPowerOfShip = Convert.ToString(ship.speed);
            float radius = 40;
            float Shift = (float)Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(radius / 2, 2));
            float x;
            float y;
            GetCoord(ship, out x, out y, isThatHostsShip);
            PointF TopPoint = new PointF(x, y - radius);
            PointF BottomLeftPoint = new PointF(x - Shift, y + (radius / 2));
            PointF BottomRightPoint = new PointF(x + Shift, y + (radius / 2));
            PointF[] angelPoints = { TopPoint, BottomLeftPoint, BottomRightPoint };
            if (isThatHostsShip) { brush = new SolidBrush(Color.LimeGreen); }
            else { brush = new SolidBrush(Color.Gold); }
            graph_bitmap.FillPolygon(brush, angelPoints);
            graph_bitmap.DrawString(TextPowerOfShip, FontPowerOfShip, BrushBlack, x - (radius / 3) - 4, y - (radius / 2) - 4);
            graph_bitmap.DrawString(TextNumShip, FontNumShip, BrushBlack, x - (radius / 3) - 13, y - (radius / 2) + 18);
        }
        private static void DrawRectangleShip(Ship ship, bool isThatHostsShip)
        {
            Font FontNumShip = new Font("Arial", FONTSMALL);
            Font FontPowerOfShip = new Font("Arial", FONTBIG);
            SolidBrush brush;
            string TextNumShip = Convert.ToString(ship.index + 1);
            string TextPowerOfShip = Convert.ToString(ship.speed);
            float radius = 50;
            float x;
            float y;
            GetCoord(ship, out x, out y, isThatHostsShip);
            if (isThatHostsShip) { brush = new SolidBrush(Color.LimeGreen); }
            else { brush = new SolidBrush(Color.Gold); }
            graph_bitmap.FillRectangle(brush, x - (radius / 2), y - (radius / 2), radius, radius);
            graph_bitmap.DrawString(TextPowerOfShip, FontPowerOfShip, BrushBlack, x - (radius / 3) + 3, y - (radius / 2) + 2);
            graph_bitmap.DrawString(TextNumShip, FontNumShip, BrushBlack, x - (radius / 3) - 8, y - (radius / 2) + 14);
        }
        private static void DrawCircleShip(Ship ship, bool isThatHostsShip)
        {
            Font FontNumShip = new Font("Arial", FONTSMALL);
            Font FontPowerOfShip = new Font("Arial", FONTBIG);
            SolidBrush brush;
            string TextNumShip = Convert.ToString(ship.index + 1);
            string TextPowerOfShip = Convert.ToString(ship.speed);
            float radius = 55;
            float x;
            float y;
            GetCoord(ship, out x, out y, isThatHostsShip);
            if (isThatHostsShip) { brush = new SolidBrush(Color.LimeGreen); }
            else { brush = new SolidBrush(Color.Gold); }
            graph_bitmap.FillEllipse(brush, x - (radius / 2), y - (radius / 2), radius, radius);
            graph_bitmap.DrawString(TextPowerOfShip, FontPowerOfShip, BrushBlack, x - (radius / 3) + 6, y - (radius / 2) + 5);
            graph_bitmap.DrawString(TextNumShip, FontNumShip, BrushBlack, x - (radius / 3) - 3, y - (radius / 2) + 17);
        }

        public static void InitializationMap(PictureBox picBox)
        {
            pictureBox = picBox;
            bitmap = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            graph_bitmap = Graphics.FromImage(bitmap);
            graphics = pictureBox.CreateGraphics();

            for (int i = 0; i < position.Length; i++) position[i] = new Position();
            CreatinJumpsAlongDottedLines();
            SavingLargePointCoordinates();
            SavingEndsCoordinatesOfDottedLines();
        }
        public static void DrawShip(Ship ship, bool isThatHostsShip)
        {
            switch (ship.type)
            {
                case 1: { DrawTriangleShip(ship, isThatHostsShip); } break;
                case 2: { DrawRectangleShip(ship, isThatHostsShip); } break;
                case 3: { DrawCircleShip(ship, isThatHostsShip); } break;
            }
        }
        public static void DrawWhiteRectangle(int numOfShip, bool isThatHostsShip)
        {
            float radius = 70;
            float x;
            float y = 155 + 80 * (numOfShip);

            if (isThatHostsShip) { x = 1300; }
            else { x = 130; }

            graph_bitmap.FillRectangle(new SolidBrush(Color.White), x - (radius / 2), y - (radius / 2), radius, radius);
            graphics.DrawImage(bitmap, 0, 0, pictureBox.Size.Width, pictureBox.Size.Height);

        }
        public static void DrawMapAndShips(Ship[] playerOneShips, Ship[] PlayerTwoShips)
        {
            DrawMap();
            DrawAllShips(playerOneShips, PlayerTwoShips);
            DrawImage();
        }
        public static void ImageRefresh()
        {
            PictureBoxRefresh();
            DrawImage();
        }
    }
}
