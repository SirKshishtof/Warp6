using Ships;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing
{
    public class Addres_Dash
    {
        public int _external;
        public int _internal;
    }
    public class Position
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

    public class Map
    {
        public Map(/*int pictureBox_Size_Width, int pictureBox_Size_Height*/  PictureBox pictureBox)
        {
            //this.pictureBox_Size_Width = pictureBox_Size_Width;
            //this.pictureBox_Size_Height = pictureBox_Size_Height;

            this.pictureBox = pictureBox;
            bitmap = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            graph_bitmap = Graphics.FromImage(bitmap);
            graphics = pictureBox.CreateGraphics();

            short[] index = new short[6] { 0, 1, 2, 3, 4, 5 };
            short count = 6;
            short dest = 6;
            double x;
            double y;
            double pi;
            double start_angle;
            double step;

            for (short i = 0; i < 126; i++) position[i] = new Position();
            for (short i = 0; i < 30; i++) addres_dash[i] = new Addres_Dash();

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
            pi = 3.7;
            start_angle = 1.047;
            count = 0;
            for (int i = 1; i <= 6; i++)
            {
                step = start_angle;
                step = step / i;
                for (int j = 0; j < 6 * i; j++)
                {
                    x = PolarToX(pi);
                    y = PolarToY(pi);
                    position[count].y = y + verticalShear;
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
        Graphics graphics;
        Graphics graph_bitmap;
        Bitmap bitmap;
        int pictureBox_Size_Width;
        int pictureBox_Size_Height;
        PictureBox pictureBox;
        SolidBrush BrushBlack = new SolidBrush(Color.Black);
        SolidBrush BrushGold = new SolidBrush(Color.Gold);
        SolidBrush BrushLimeGreen = new SolidBrush(Color.LimeGreen);
        Pen BlackPen = new Pen(Color.Black, 3);
        Addres_Dash[] addres_dash = new Addres_Dash[30];
        public Position[] position = new Position[126];

        const double turn = 3.11;//Коффициент задающий поворот спирали и точек
        const short verticalShear = 20;//Сдвиг всей картинки относительно оси 
        const double kof = 12;//Коффициент задающий ширину между витками спирали и точек
        const short fontSmall = 12;//Шрифт меленькой цифры на фигуре
        const short fontBig = 25;//Шрифт большой цифры на фигуре

        double PolarToX(double pi)//перевод полярной координаты в координату X
        {
            double p = pi * kof;
            double x = p * Math.Cos(pi + turn) + pictureBox.Size.Width / 2; ;
            return x;
        }
        double PolarToY(double pi)//перевод полярной координаты в координату Y
        {
            double p = pi * kof;
            double y = p * Math.Sin(pi + turn) + pictureBox.Size.Height / 2 - 25;
            return y;
        }
        float X_(Ship Ship)//получение координаты х корабля
        {
            return (float)position[Ship.position].x;
        }
        float Y_(Ship Ship)//получение координаты у корабля
        {
            return (float)position[Ship.position].y;
        }
        public void DrawDashLine(int a, int b)
        {
            graph_bitmap.DrawLine(BlackPen, (float)position[a].x, (float)position[a].y, (float)position[b].x, (float)position[b].y);
        }
        public void DrawCircle(double x, double y, float radius)
        {
            graph_bitmap.FillEllipse(BrushBlack, (float)(x - (radius / 2)), (float)(y - (radius / 2)), radius, radius);
        }
        public void DrawTriangle(SolidBrush brush, float x, float y, int numShip, int speedOfShip)
        {
            string TextNumShip = Convert.ToString(numShip);
            string TextPowerOfShip = Convert.ToString(speedOfShip);
            Font FontNumShip = new Font("Arial", fontSmall);
            Font FontPowerOfShip = new Font("Arial", fontBig);
            float radius = 40;
            float Shift = (float)Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(radius / 2, 2));
            PointF TopPoint = new PointF(x, y - radius);
            PointF BottomLeftPoint = new PointF(x - Shift, y + (radius / 2));
            PointF BottomRightPoint = new PointF(x + Shift, y + (radius / 2));
            PointF[] angelPoints = { TopPoint, BottomLeftPoint, BottomRightPoint };
            graph_bitmap.FillPolygon(brush, angelPoints);
            graph_bitmap.DrawString(TextPowerOfShip, FontPowerOfShip, BrushBlack, x - (radius / 3) - 4, y - (radius / 2) - 4);
            graph_bitmap.DrawString(TextNumShip, FontNumShip, BrushBlack, x - (radius / 3) - 13, y - (radius / 2) + 18);
            //graphics.DrawImage(bitmap, 0, 0, pictureBox1.Size.Width, pictureBox1.Size.Height);
        }
        public void DrawRectangle(SolidBrush brush, float x, float y, int numShip, int speedOfShip)
        {
            string TextNumShip = Convert.ToString(numShip);
            string TextPowerOfShip = Convert.ToString(speedOfShip);
            Font FontNumShip = new Font("Arial", fontSmall);
            Font FontPowerOfShip = new Font("Arial", fontBig);
            float radius = 50;
            graph_bitmap.FillRectangle(brush, x - (radius / 2), y - (radius / 2), radius, radius);
            graph_bitmap.DrawString(TextPowerOfShip, FontPowerOfShip, BrushBlack, x - (radius / 3) + 3, y - (radius / 2) + 2);
            graph_bitmap.DrawString(TextNumShip, FontNumShip, BrushBlack, x - (radius / 3) - 8, y - (radius / 2) + 14);
            //graphics.DrawImage(bitmap, 0, 0, pictureBox1.Size.Width, pictureBox1.Size.Height);
        }
        public void DrawCircle(SolidBrush brush, float x, float y, int numShip, int speedOfShip)
        {
            string TextNumShip = Convert.ToString(numShip);
            string TextPowerOfShip = Convert.ToString(speedOfShip);
            Font FontNumShip = new Font("Arial", fontSmall);
            Font FontPowerOfShip = new Font("Arial", fontBig);
            float radius = 55;
            graph_bitmap.FillEllipse(brush, x - (radius / 2), y - (radius / 2), radius, radius);
            graph_bitmap.DrawString(TextPowerOfShip, FontPowerOfShip, BrushBlack, x - (radius / 3) + 6, y - (radius / 2) + 5);
            graph_bitmap.DrawString(TextNumShip, FontNumShip, BrushBlack, x - (radius / 3) - 3, y - (radius / 2) + 17);
        }
        public void DrawMap()
        {
            double x = 0;
            double y = 0;

            double pi = 0;
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
                DrawCircle(x, y + verticalShear, radius);
                pi += 0.001;
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

            float xOfPoint = 1123.4579f;
            float yOfPoint = 771.7283f;

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
        public void WhiteRectangle(int numOfShip, bool enemy)
        {
            float radius = 70;
            float x;
            float y = 155 + 80 * (numOfShip);

            if (enemy) { x = 1300; }
            else { x = 130; }

            graph_bitmap.FillRectangle(new SolidBrush(Color.White), x - (radius / 2), y - (radius / 2), radius, radius);
            graphics.DrawImage(bitmap, 0, 0, pictureBox.Size.Width, pictureBox.Size.Height);
        }
        public void DrawingShipsOnSides(Ship[] enemyShip, Ship[] myShip)
        {
            float xLeft = 130;
            float xRight = 1300;
            float y = 160;
            float Shift = 80;

            for (int i = 0; i < 4; i++)
            {
                DrawTriangle(BrushLimeGreen, xLeft, y, i + 1, myShip[i].speed);
                DrawTriangle(BrushGold, xRight, y, i + 1, enemyShip[i].speed);
                y += Shift;
            }

            for (int i = 4; i < 7; i++)
            {
                DrawRectangle(BrushLimeGreen, xLeft, y, i + 1, myShip[i].speed);
                DrawRectangle(BrushGold, xRight, y, i + 1, enemyShip[i].speed);
                y += Shift;
            }

            for (int i = 7; i < 9; i++)
            {
                DrawCircle(BrushLimeGreen, xLeft, y, i + 1, myShip[i].speed);
                DrawCircle(BrushGold, xRight, y, i + 1, enemyShip[i].speed);
                y += Shift;
            }
        }
        public void DrawEverything(Ship[] enemyShip, Ship[] myShip)
        {
            DrawMap();
            for (int i = 0; i < 4; i++)
            {
                if (myShip[i].InGame) DrawTriangle(BrushLimeGreen, X_(myShip[i]), Y_(myShip[i]), i + 1, myShip[i].speed);
                if (enemyShip[i].InGame) DrawTriangle(BrushGold, X_(enemyShip[i]), Y_(enemyShip[i]), i + 1, enemyShip[i].speed);
            }

            for (int i = 4; i < 7; i++)
            {
                if (myShip[i].InGame) DrawRectangle(BrushLimeGreen, X_(myShip[i]), Y_(myShip[i]), i + 1, myShip[i].speed);
                if (enemyShip[i].InGame) DrawRectangle(BrushGold, X_(enemyShip[i]), Y_(enemyShip[i]), i + 1, enemyShip[i].speed);
            }

            for (int i = 7; i < 9; i++)
            {
                if (myShip[i].InGame) DrawCircle(BrushLimeGreen, X_(myShip[i]), Y_(myShip[i]), i + 1, myShip[i].speed);
                if (enemyShip[i].InGame) DrawCircle(BrushGold, X_(enemyShip[i]), Y_(enemyShip[i]), i + 1, enemyShip[i].speed);
            }
            graphics.DrawImage(bitmap, 0, 0, pictureBox.Size.Width, pictureBox.Size.Height);
        }
        public void Refresh()
        {
            pictureBox.Refresh();
            graphics.DrawImage(bitmap, 0, 0, pictureBox.Size.Width, pictureBox.Size.Height);
        }
    }

}
