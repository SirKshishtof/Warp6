using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Warp_6
{


    public partial class Form1 : Form
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
            public int jump;
            public bool busy;
        }
        struct Ship
        {
            public Ship(int type)
            {
                InGame = true;
                this.type = type;
            }
            public int position;
            public int type;
            public int speed;
            public bool InGame;
        }
        class Enemy
        {
            public Ship[] ship = new Ship[9];

            public List<int> EnemyShipSorting()
            {
                int count = -1;
                int max = 0;
                int[] index = new int[9];
                List<int> list = new List<int>();

                for (int i = 0; i < 4; i++)
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
                    for (int j = 0; j < 9; j++)
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
                    for (int j = 0; j < 4; j++)
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
                return list;
            }
            /*{
           public void AlexMovesShip(Position[] position)
           {
               int BotMove = AlexСhoosesShip();
               int index = BotMove / 100;
               if ((BotMove / 10) % 10 == 0)
               {
                   position[ship[index].position].busy = false;
                   ship[index].position = ship[index].position - ship[index].speed;
                   if (ship[index].position < 0)
                   {
                       ship[index].InGame = false;
                       EnemyShipsInCenter++;
                   }
                   else
                   {
                       if (position[ship[index].position].busy) { ship[index].position = position[ship[index].position].jump; }
                       while (position[ship[index].position].busy && ship[index].InGame == true)
                       {
                           if (position[ship[index].position].jump != -1)
                           {
                               ship[index].position = position[ship[index].position].jump;
                           }
                           else
                           {
                               ship[index].InGame = false;
                               EnemyShipsInCenter++;
                           }
                       }
                       position[ship[index].position].busy = true;
                   }
                   EnemyShipsCenterTextbox.Text = EnemyShipsInCenter.ToString();
               }
               else
               {
                   if (BotMove % 10 == 0) { ship[index].speed--; }
                   else { ship[index].speed++; }
               }
               Thread.Sleep(2000);
               //DrawEverything();
           }
           int HyperjumpToCenter()
           {
               //Может ли корабль попасть в центр через гипер прыжки
               int[] SpeedOfShip = new int[9];
               bool stop = false;
               int index = 0;
               int min = 126;
               int count = 0;
               SpeedOfShip = ArrZero(SpeedOfShip);
               for (int i = 0; i < 9; i++)
               {
                   if (ship[i].InGame)
                   {
                       count = 0;
                       index = ship[i].position - ship[i].speed;
                       if (index > -1)
                       {
                           while (!stop)
                           {
                               if (position[index].busy)
                               {
                                   if (position[index].jump == -1)
                                   {
                                       SpeedOfShip[i]++;
                                       stop = true;
                                   }
                                   else
                                   {
                                       index = position[index].jump;
                                   }
                               }
                               else
                               {
                                   stop = true;
                               }
                               count++;
                               if (count == 6) { stop = true; }
                           }
                       }
                   }
               }
               stop = false;
               for (int i = 0; i < 9; i++)
               {
                   if (SpeedOfShip[i] == 1)
                   {
                       if (ship[i].position < min)
                       {
                           index = i;
                           min = ship[i].position;
                           stop = true;
                       }
                   }
               }
               if (stop) { return index * 100; }
               else { return -1; }
           }
           int ToCenter()
           {
               int[] SpeedOfShip = new int[9];
               bool stop;
               int index = 0;
               int min = 126;
               SpeedOfShip = ArrZero(SpeedOfShip);
               for (int i = 0; i < 9; i++)
               {
                   if (ship[i].InGame)
                   {
                       index = ship[i].position - ship[i].speed;
                       if (index < 0) { SpeedOfShip[i]++; }
                   }
               }
               stop = false;
               for (int i = 0; i < 9; i++)
               {
                   if (SpeedOfShip[i] == 1)
                   {
                       if (ship[i].position < min)
                       {
                           index = i;
                           min = ship[i].position;
                           stop = true;
                       }
                   }
               }
               if (stop) { return index * 100; }
               else { return -1; }
           }
           int Hyperjump()
           {
               int[] SpeedOfShip = new int[9];
               bool stop;
               int index = 0;
               int min;
               int max = -1;
               int count;
               SpeedOfShip = ArrZero(SpeedOfShip);
               for (int i = 0; i < 9; i++)
               {
                   if (ship[i].InGame)
                   {
                       count = 0;
                       index = ship[i].position - ship[i].speed;
                       if (index > -1)
                       {
                           stop = false;
                           while (!stop)
                           {
                               if (position[index].busy)
                               {
                                   SpeedOfShip[i]++;
                                   index = position[index].jump;
                               }
                               else
                               {
                                   stop = true;
                               }
                               count++;
                               if (count == 6) { stop = true; }
                           }
                       }
                   }
               }
               min = 10;
               stop = false;
               for (int i = 0; i < 9; i++)
               {
                   if (SpeedOfShip[i] > 0)
                   {
                       if (SpeedOfShip[i] > max)
                       {
                           index = i;
                           max = SpeedOfShip[i];
                       }
                       else
                       {
                           if (SpeedOfShip[i] == max)
                           {
                               if (ship[i].speed < min)
                               {
                                   index = i;
                                   min = ship[i].speed;
                               }
                           }
                       }
                       stop = true;
                   }
               }
               if (stop) { return index * 100; }
               else { return -1; }
           }
           int HyperjumpInTheFuturePlus()
           {
               int[] SpeedOfShip = new int[9];
               bool stop = false;
               int index = 0;
               int min = 10;
               int count;
               SpeedOfShip = ArrZero(SpeedOfShip);
               for (int i = 0; i < 9; i++)
               {
                   if (ship[i].InGame && ship[i].speed != 1)
                   {
                       count = 0;
                       index = ship[i].position - ship[i].speed - 1;
                       if (index > -1)
                       {
                           while (!stop)
                           {
                               if (position[index].busy)
                               {
                                   if (position[index].jump == -1)
                                   {
                                       SpeedOfShip[i]++;
                                       stop = true;
                                   }
                                   else
                                   {
                                       index = position[index].jump;
                                   }
                               }
                               else
                               {
                                   stop = true;
                               }
                               count++;
                               if (count == 6) { stop = true; }
                           }
                       }
                   }
               }
               stop = false;
               for (int i = 0; i < 9; i++)
               {
                   if (SpeedOfShip[i] == 1)
                   {
                       if (ship[i].speed < min)
                       {
                           index = i;
                           min = ship[i].speed;
                           stop = true;
                       }
                   }
               }
               if (stop) { return index * 100 + 10 + 1; }
               else { return -1; }
           }
           int HyperjumpInTheFutureMinus()
           {
               int[] SpeedOfShip = new int[9];
               bool stop = false;
               int index = 0;
               int max = -1;
               int count = 0;
               SpeedOfShip = ArrZero(SpeedOfShip);
               stop = false;
               for (int i = 0; i < 9; i++)
               {
                   if (ship[i].InGame && ((ship[i].type == 1 && ship[i].speed != 4) || (ship[i].type == 2 && ship[i].speed != 6) && (ship[i].type == 3 && ship[i].speed != 8)))
                   {
                       count = 0;
                       index = ship[i].position - ship[i].speed + 1;
                       if (index > -1)
                       {
                           while (!stop)
                           {
                               if (position[index].busy)
                               {
                                   if (position[index].jump == -1)
                                   {
                                       SpeedOfShip[i]++;
                                       stop = true;
                                   }
                                   else
                                   {
                                       index = position[index].jump;
                                   }
                               }
                               else
                               {

                                   stop = true;
                               }
                               count++;
                               if (count == 6) { stop = true; }
                           }
                       }
                   }
               }
               stop = false;
               max = 0;
               for (int i = 0; i < 9; i++)
               {
                   if (SpeedOfShip[i] == 1)
                   {
                       if (ship[i].speed > max)
                       {
                           index = i;
                           max = ship[i].speed;
                           stop = true;
                       }
                   }
               }
               if (stop) { return index * 100 + 10 + 0; }
               else { return -1; }
           }
           int Jump()
           {
               int index = 0;
               int max = -1;
               for (int i = 0; i < 9; i++)
               {
                   if (ship[i].InGame)
                   {
                       if (ship[i].speed > max)
                       {
                           index = i;
                           max = ship[i].speed;
                       }
                   }
               }
               return index * 100;
           }
           int AlexСhoosesShip()
           {
               int index;
               index = HyperjumpToCenter();
               if (index != -1) { return index; }

               index = ToCenter();
               if (index != -1) { return index; }

               index = Hyperjump();
               if (index != -1) { return index; }

               index = HyperjumpInTheFuturePlus();
               if (index != -1) { return index; }

               index = HyperjumpInTheFutureMinus();
               if (index != -1) { return index; }

               if (rnd.Next() % 100 < 30)
               {
                   bool flag = true;
                   while (flag)
                   {
                       index = (rnd.Next() % 9) * 100;
                       if (ship[index].InGame) { flag = false; }
                   }
               }
               else { index = Jump(); }
               return index;
           }
           }
           */
        }

        Graphics graphics;
        Graphics graph_bitmap;
        Bitmap bitmap;
        SolidBrush BrushBlack = new SolidBrush(Color.Black);
        SolidBrush BrushGold = new SolidBrush(Color.Gold);
        SolidBrush BrushLimeGreen = new SolidBrush(Color.LimeGreen);
        Pen BlackPen = new Pen(Color.Black, 3);

        Position[] position = new Position[126];
        Ship[] myShip = new Ship[9];
        Enemy enemy = new Enemy();
        Random rnd = new Random();
        List<int> list = new List<int>();

        Addres_Dash[] addres_dash = new Addres_Dash[30];

        short enemyShipsInCenter = 0;
        short myShipsInCenter = 0;
        short currentPoint = 125;
        short verticalShear = 20;//Сдвиг всей картинки относительно оси Y
        //bool flag = false;
        bool didTheSpeedChange = false;
        const double turn = 3.11;//Коффициент задающий поворот спирали и точек
        const double kof = 12;//Коффициент задающий ширину между витками спирали и точек
        const int fontSmall = 12;//Шрифт меленькой цифры на фигуре
        const int fontBig = 25;//Шрифт большой цифры на фигуре

        void DrawDashLine(int a, int b)
        {
            graph_bitmap.DrawLine(BlackPen, (float)position[a].x, (float)position[a].y, (float)position[b].x, (float)position[b].y);
        }

        void DrawCircle(double x, double y, float radius)
        {
            graph_bitmap.FillEllipse(BrushBlack, (float)(x - (radius / 2)), (float)(y - (radius / 2)), radius, radius);
        }

        void DrawTriangle(SolidBrush brush, float x, float y, int NumShip, int PowerOfShip)
        {
            String TextNumShip = Convert.ToString(NumShip);
            String TextPowerOfShip = Convert.ToString(PowerOfShip);
            Font FontNumShip = new Font("Arial", fontSmall);
            Font FontPowerOfShip = new Font("Arial", fontBig);
            float radius = 40;
            float Shift = (float)Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(radius / 2, 2));
            PointF TopPoint = new PointF(x, y - radius);
            PointF BottomLeftPoint = new PointF(x - Shift, y + (radius / 2));
            PointF BottomRightPoint = new PointF(x + Shift, y + (radius / 2));
            PointF[] curvePoints = { TopPoint, BottomLeftPoint, BottomRightPoint };
            graph_bitmap.FillPolygon(brush, curvePoints);
            graph_bitmap.DrawString(TextPowerOfShip, FontPowerOfShip, BrushBlack, x - (radius / 3) - 4, y - (radius / 2) - 4);
            graph_bitmap.DrawString(TextNumShip, FontNumShip, BrushBlack, x - (radius / 3) - 13, y - (radius / 2) + 18);
            //graphics.DrawImage(bitmap, 0, 0, pictureBox1.Size.Width, pictureBox1.Size.Height);
        }

        void DrawRectangle(SolidBrush brush, float x, float y, int NumShip, int PowerOfShip)
        {
            String TextNumShip = Convert.ToString(NumShip);
            String TextPowerOfShip = Convert.ToString(PowerOfShip);
            Font FontNumShip = new Font("Arial", fontSmall);
            Font FontPowerOfShip = new Font("Arial", fontBig);
            float radius = 50;
            graph_bitmap.FillRectangle(brush, x - (radius / 2), y - (radius / 2), radius, radius);
            graph_bitmap.DrawString(TextPowerOfShip, FontPowerOfShip, BrushBlack, x - (radius / 3) + 3, y - (radius / 2) + 2);
            graph_bitmap.DrawString(TextNumShip, FontNumShip, BrushBlack, x - (radius / 3) - 8, y - (radius / 2) + 14);
            //graphics.DrawImage(bitmap, 0, 0, pictureBox1.Size.Width, pictureBox1.Size.Height);
        }

        void DrawCircle(SolidBrush brush, float x, float y, int NumShip, int PowerOfShip)
        {
            String TextNumShip = Convert.ToString(NumShip);
            String TextPowerOfShip = Convert.ToString(PowerOfShip);
            Font FontNumShip = new Font("Arial", fontSmall);
            Font FontPowerOfShip = new Font("Arial", fontBig);
            float radius = 55;
            graph_bitmap.FillEllipse(brush, x - (radius / 2), y - (radius / 2), radius, radius);
            graph_bitmap.DrawString(TextPowerOfShip, FontPowerOfShip, BrushBlack, x - (radius / 3) + 6, y - (radius / 2) + 5);
            graph_bitmap.DrawString(TextNumShip, FontNumShip, BrushBlack, x - (radius / 3) - 3, y - (radius / 2) + 17);
        }

        void WhiteRectangle(int numOfShip, bool enemy)
        {
            float radius = 70;
            float x;
            float y = 155 + 80 * (numOfShip);

            if (enemy) { x = 1300; }
            else { x = 50; }

            SolidBrush brush = new SolidBrush(Color.White);

            graph_bitmap.FillRectangle(brush, x - (radius / 2), y - (radius / 2), radius, radius);
            graphics.DrawImage(bitmap, 0, 0, pictureBox1.Size.Width, pictureBox1.Size.Height);

        }

        void DrawShip(SolidBrush brush, Ship ship, int numOfShip)
        {
            switch (ship.type)
            {
                case 1: { DrawTriangle(brush, X_(ship), Y_(ship), numOfShip + 1, ship.speed); } break;
                case 2: { DrawRectangle(brush, X_(ship), Y_(ship), numOfShip + 1, ship.speed); } break;
                case 3: { DrawCircle(brush, X_(ship), Y_(ship), numOfShip + 1, ship.speed); } break;
            }
            graphics.DrawImage(bitmap, 0, 0, pictureBox1.Size.Width, pictureBox1.Size.Height);
        }
        //void DrawEverything()
        //{
        //    Map();
        //    for (int i = 0; i < 4; i++)
        //    {
        //        DrawTriangle(BrushLimeGreen, X_(MyShip[i]), Y_(MyShip[i]), i + 1, MyShip[i].speed);
        //        DrawTriangle(BrushGold, X_(EnemyShip[i]), Y_(EnemyShip[i]), i + 1, EnemyShip[i].speed);
        //    }

        //    for (int i = 4; i < 7; i++)
        //    {
        //        DrawRectangle(BrushLimeGreen, X_(MyShip[i]), Y_(MyShip[i]), i + 1, MyShip[i].speed);
        //        DrawRectangle(BrushGold, X_(EnemyShip[i]), Y_(EnemyShip[i]), i + 1, EnemyShip[i].speed);
        //    }

        //    for (int i = 7; i < 9; i++)
        //    {
        //        DrawCircle(BrushLimeGreen, X_(MyShip[i]), Y_(MyShip[i]), i + 1, MyShip[i].speed);
        //        DrawCircle(BrushGold, X_(EnemyShip[i]), Y_(EnemyShip[i]), i + 1, EnemyShip[i].speed);
        //    }
        //    graphics.DrawImage(bitmap, 0, 0, pictureBox1.Size.Width, pictureBox1.Size.Height);
        //}

        double PolarToX(double pi)
        {
            double p = pi * kof;
            double x = p * Math.Cos(pi + turn) + pictureBox1.Size.Width / 2; ;
            return x;
        }

        double PolarToY(double pi)
        {
            double p = pi * kof;
            double y = p * Math.Sin(pi + turn) + pictureBox1.Size.Height / 2 - 25;
            return y;
        }

        float X_(Ship Ship)//получение координаты х
        {
            return (float)position[Ship.position].x; ;
        }

        float Y_(Ship Ship)//получение координаты у
        {
            return (float)position[Ship.position].y; ;
        }
        void Map()
        {
            double x;
            double y;

            double pi = 0;
            float radius = 40;

            graph_bitmap.Clear(Color.White);

            BlackPen.DashStyle = DashStyle.Dash;

            DrawCircle(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2 - 8, radius);

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

        }

        int[] ArrZero(int[] Arr)
        {
            int size = Arr.Length;
            for (int i = 0; i < size; i++)
            {
                Arr[i] = 0;
            }
            return Arr;
        }

        void SetsShip(ref Ship Ship, int NumOfShip, ref short currentPoint, SolidBrush Brush)
        {
            Ship.position = currentPoint;
            position[currentPoint].busy = true;
            float x = X_(Ship);
            float y = Y_(Ship);
            switch (Ship.type)
            {
                case 1: { DrawTriangle(Brush, x, y, NumOfShip + 1, Ship.speed); } break;
                case 2: { DrawRectangle(Brush, x, y, NumOfShip + 1, Ship.speed); } break;
                case 3: { DrawCircle(Brush, x, y, NumOfShip + 1, Ship.speed); } break;
            }
            currentPoint--;
        }

        void RadioButtonOff(int index)
        {
            switch (index)
            {
                case 0: { Ship1.Checked = false; Ship1.Enabled = false; } break;
                case 1: { Ship2.Checked = false; Ship2.Enabled = false; } break;
                case 2: { Ship3.Checked = false; Ship3.Enabled = false; } break;
                case 3: { Ship4.Checked = false; Ship4.Enabled = false; } break;
                case 4: { Ship5.Checked = false; Ship5.Enabled = false; } break;
                case 5: { Ship6.Checked = false; Ship6.Enabled = false; } break;
                case 6: { Ship7.Checked = false; Ship7.Enabled = false; } break;
                case 7: { Ship8.Checked = false; Ship8.Enabled = false; } break;
                case 8: { Ship9.Checked = false; Ship9.Enabled = false; } break;
            }
        }
        int ShipSelection()
        {
            if (Ship1.Checked) { return 0; }
            if (Ship2.Checked) { return 1; }
            if (Ship3.Checked) { return 2; }
            if (Ship4.Checked) { return 3; }
            if (Ship5.Checked) { return 4; }
            if (Ship6.Checked) { return 5; }
            if (Ship7.Checked) { return 6; }
            if (Ship8.Checked) { return 7; }
            if (Ship9.Checked) { return 8; }
            return -1;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            graph_bitmap = Graphics.FromImage(bitmap);
            graphics = pictureBox1.CreateGraphics();

            for (int i = 0; i < 126; i++)
            {
                position[i] = new Position();
            }

            //for (int i = 125; i <= 125; i++)
            //{
            //    position[i] = new Position();
            //}

            //for (int i = 0; i < 126; i++)
            //{
            //    position[i] = new Position();
            //}

            for (int i = 0; i < 4; i++)
            {
                myShip[i] = new Ship(1);
                myShip[i].speed = rnd.Next() % 4 + 1;//Задание скорости корабля

                enemy.ship[i] = new Ship(1);
                enemy.ship[i].speed = rnd.Next() % 4 + 1; ;//Задание скорости корабля
            }

            for (int i = 4; i < 7; i++)
            {
                myShip[i] = new Ship(2);
                myShip[i].speed = rnd.Next() % 6 + 1;//Задание скорости корабля

                enemy.ship[i] = new Ship(2);
                enemy.ship[i].speed = rnd.Next() % 6 + 1; ;//Задание скорости корабля
            }

            for (int i = 7; i < 9; i++)
            {
                myShip[i] = new Ship(3);
                myShip[i].speed = rnd.Next() % 8 + 1;//Задание скорости корабля

                enemy.ship[i] = new Ship(3);
                enemy.ship[i].speed = rnd.Next() % 8 + 1; ;//Задание скорости корабля
            }

            int[] index = new int[6] { 0, 1, 2, 3, 4, 5 };
            short count;
            short dest = 6;
            double x;
            double y;
            double pi;
            double start_angle;
            double step;

            count = 6;
            //Запоминатие прыжков
            for (int i = 2; i <= 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        position[count].jump = index[j];
                        count++;
                    }

                    index[j]++;
                    for (int k = 2; k < i; k++)
                    {
                        position[count].jump = index[j];
                        index[j]++;
                        count++;
                    }
                }
                index[0] = index[5];
                for (int j = 1; j < 6; j++)
                {
                    index[j] = index[j - 1] + i;
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

            list = enemy.EnemyShipSorting();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void OnPosition_Click(object sender, EventArgs e)

        {
            OnPosition.Enabled = false;
            int NumOfShip = ShipSelection();
            if (NumOfShip != -1)
            {
                SetsShip(ref myShip[NumOfShip], NumOfShip, ref currentPoint, BrushLimeGreen);
                RadioButtonOff(NumOfShip);

                WhiteRectangle(NumOfShip, false);

                if (list.Count > 0)
                {
                    Thread.Sleep(1000);
                    NumOfShip = list[0];
                    SetsShip(ref enemy.ship[NumOfShip], NumOfShip, ref currentPoint, BrushGold);
                    WhiteRectangle(NumOfShip, true);
                    list.RemoveAt(0);
                    if (list.Count == 0 &&
                        !Ship1.Enabled &&
                        !Ship2.Enabled &&
                        !Ship3.Enabled &&
                        !Ship4.Enabled &&
                        !Ship5.Enabled &&
                        !Ship6.Enabled &&
                        !Ship7.Enabled &&
                        !Ship8.Enabled &&
                        !Ship9.Enabled)
                    {
                        OnPosition.Visible = false;
                        Start.Visible = true;
                    }
                }
                else
                {
                    OnPosition.Visible = false;
                    Start.Visible = true;
                }

            }
            OnPosition.Enabled = true;
        }

        private void Power_CheckedChanged(object sender, EventArgs e)
        {
            LessSpeed.Enabled = true;
            MoreSpeed.Enabled = true;
        }

        private void Go_CheckedChanged(object sender, EventArgs e)
        {
            LessSpeed.Enabled = false;
            MoreSpeed.Enabled = false;
        }
        private void Rules_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"D:\Zlowolf\Coursework\Rules.txt"))
            {
                StreamReader rulesFile = new StreamReader(@"D:\Zlowolf\Coursework\Rules.txt");
                String mes = rulesFile.ReadToEnd();
                rulesFile.Close();
                MessageBox.Show(mes, "Правила");
                if (!groupShip.Visible)
                {
                    groupShip.Visible = true;
                    OnPosition.Visible = true;

                    Map();

                    float xLeft = 50;
                    float xRight = 1300;
                    float y = 160;
                    float Shift = 80;

                    for (int i = 0; i < 4; i++)
                    {
                        DrawTriangle(BrushLimeGreen, xLeft, y, i + 1, myShip[i].speed);
                        DrawTriangle(BrushGold, xRight, y, i + 1, enemy.ship[i].speed);
                        y += Shift;
                    }

                    for (int i = 4; i < 7; i++)
                    {
                        DrawRectangle(BrushLimeGreen, xLeft, y, i + 1, myShip[i].speed);
                        DrawRectangle(BrushGold, xRight, y, i + 1, enemy.ship[i].speed);
                        y += Shift;
                    }

                    for (int i = 7; i < 9; i++)
                    {
                        DrawCircle(BrushLimeGreen, xLeft, y, i + 1, myShip[i].speed);
                        DrawCircle(BrushGold, xRight, y, i + 1, enemy.ship[i].speed);
                        y += Shift;
                    }

                    if (rnd.Next() % 2 != 0)
                    {
                        mes = "О нет! Противник прибыл раньше вас! Вы ходите вторым.";
                        int NumOfShip = list[0];
                        SetsShip(ref enemy.ship[NumOfShip], NumOfShip, ref currentPoint, BrushGold);
                        WhiteRectangle(NumOfShip, true);
                        list.RemoveAt(0);
                    }
                    else
                    {
                        mes = "Вам повезло! Противник еще не прибыл! Вы ходите первым.";
                    }

                    graphics.DrawImage(bitmap, 0, 0, pictureBox1.Size.Width, pictureBox1.Size.Height);
                    MessageBox.Show(mes, "Кто начинает");

                }
            }
            else
            {
                MessageBox.Show("Правил нет, но мы работаем над этим", "Что-то пошло не по плану");
                Application.Exit();
            }
        }
        private void Start_Click(object sender, EventArgs e)
        {
            Start.Visible = false;
            WhoGoes.Visible = true;
            Go.Checked = true;
            groupAction.Visible = true;
            ShowSpeed.Visible = true;
            MoreSpeed.Visible = true;
            LessSpeed.Visible = true;
            ShipInCenterLabel.Visible = true;
            MyShipsCenterLabel.Visible = true;
            EnemyShipsCenterLebel.Visible = true;
            MyShipsCenterTextbox.Visible = true;
            EnemyShipsCenterTextbox.Visible = true;
            Step.Visible = true;
            Ship1.Enabled = true;
            Ship2.Enabled = true;
            Ship3.Enabled = true;
            Ship4.Enabled = true;
            Ship5.Enabled = true;
            Ship6.Enabled = true;
            Ship7.Enabled = true;
            Ship8.Enabled = true;
            Ship9.Enabled = true;
            SpeedLable.Visible = true;
            ShowSpeed.Text = "";

            //if (flag)
            //{
            //    textBox1.Text = "Ход противника";
            //    textBox1.BackColor = Color.Gold;
            //}
            //else
            //{
            //    textBox1.Text = "Ваш ход";
            //    textBox1.BackColor = Color.LimeGreen;
            //}
        }
        private void LessSpeed_Click(object sender, EventArgs e)
        {
            int NumOfShip = ShipSelection();

            if (NumOfShip != -1)
            {
                if (myShip[NumOfShip].speed > 1)
                {
                    myShip[NumOfShip].speed--;
                    if (!Go.Enabled)
                    {
                        Go.Enabled = true;
                        MoreSpeed.Enabled = true;
                    }
                    else
                    {
                        LessSpeed.Enabled = false;
                        Go.Enabled = false;
                    }
                    ShowSpeed.Text = myShip[NumOfShip].speed.ToString();
                }
            }
        }
        private void MoreSpeed_Click(object sender, EventArgs e)
        {
            int NumOfShip = ShipSelection();

            if (NumOfShip != -1)
            {
                if (myShip[NumOfShip].type == 1 && myShip[NumOfShip].speed < 4 ||
                    myShip[NumOfShip].type == 2 && myShip[NumOfShip].speed < 6 ||
                    myShip[NumOfShip].type == 3 && myShip[NumOfShip].speed < 8)
                {
                    myShip[NumOfShip].speed++;
                    if (!Go.Enabled)
                    {
                        Go.Enabled = true;
                        LessSpeed.Enabled = true;
                    }
                    else
                    {
                        MoreSpeed.Enabled = false;
                        Go.Enabled = false;
                    }
                    ShowSpeed.Text = myShip[NumOfShip].speed.ToString();
                }
            }
        }
        private void Ship1_CheckedChanged(object sender, EventArgs e) => ShowSpeed.Text = myShip[0].speed.ToString();
        private void Ship2_CheckedChanged(object sender, EventArgs e) => ShowSpeed.Text = myShip[1].speed.ToString();
        private void Ship3_CheckedChanged(object sender, EventArgs e) => ShowSpeed.Text = myShip[2].speed.ToString();
        private void Ship4_CheckedChanged(object sender, EventArgs e) => ShowSpeed.Text = myShip[3].speed.ToString();
        private void Ship5_CheckedChanged(object sender, EventArgs e) => ShowSpeed.Text = myShip[4].speed.ToString();
        private void Ship6_CheckedChanged(object sender, EventArgs e) => ShowSpeed.Text = myShip[5].speed.ToString();
        private void Ship7_CheckedChanged(object sender, EventArgs e) => ShowSpeed.Text = myShip[6].speed.ToString();
        private void Ship8_CheckedChanged(object sender, EventArgs e) => ShowSpeed.Text = myShip[7].speed.ToString();
        private void Ship9_CheckedChanged(object sender, EventArgs e) => ShowSpeed.Text = myShip[8].speed.ToString();

        private void Step_Click(object sender, EventArgs e)
        {
            Step.Enabled = false;
            int NumOfShip = ShipSelection();
            if (NumOfShip != -1)
            {
                myShip[NumOfShip].position -= myShip[NumOfShip].speed;
                if (position[myShip[NumOfShip].position].busy) 
                {
                    myShip[NumOfShip].position = position[myShip[NumOfShip].position].jump; 
                }
                DrawShip(BrushLimeGreen, myShip[NumOfShip], NumOfShip);
            }
            Step.Enabled = true;
        }
    }
}
