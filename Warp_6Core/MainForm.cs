using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Warp_6
{

    public partial class MainForm : Form
    {
        public Graphics graphics;
        public Graphics graph_bitmap;
        public Bitmap bitmap;
        public SolidBrush BrushBlack = new SolidBrush(Color.Black);
        public SolidBrush BrushGold = new SolidBrush(Color.Gold);
        public SolidBrush BrushLimeGreen = new SolidBrush(Color.LimeGreen);
        Pen BlackPen = new Pen(Color.Black, 3);
        Addres_Dash[] addres_dash = new Addres_Dash[30];

        Position[] position = new Position[126];
        public Ship[] myShip = new Ship[9];
        public Enemy enemy = new Enemy();
        public Random rnd = new Random();

        short enemyShipsInCenter = 0;
        short myShipsInCenter = 0;
        public short currentPoint = 125;
        const short verticalShear = 20;//Сдвиг всей картинки относительно оси Y
        const double turn = 3.11;//Коффициент задающий поворот спирали и точек
        const double kof = 12;//Коффициент задающий ширину между витками спирали и точек
        const int fontSmall = 12;//Шрифт меленькой цифры на фигуре
        const int fontBig = 25;//Шрифт большой цифры на фигуре

        public void DrawDashLine(int a, int b)
        {
            graph_bitmap.DrawLine(BlackPen, (float)position[a].x, (float)position[a].y, (float)position[b].x, (float)position[b].y);
        }
        public void DrawCircle(double x, double y, float radius)
        {
            graph_bitmap.FillEllipse(BrushBlack, (float)(x - (radius / 2)), (float)(y - (radius / 2)), radius, radius);
        }
        public void DrawTriangle(SolidBrush brush, float x, float y, int NumShip, int PowerOfShip)
        {
            string TextNumShip = Convert.ToString(NumShip);
            string TextPowerOfShip = Convert.ToString(PowerOfShip);
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
        public void DrawRectangle(SolidBrush brush, float x, float y, int NumShip, int PowerOfShip)
        {
            string TextNumShip = Convert.ToString(NumShip);
            string TextPowerOfShip = Convert.ToString(PowerOfShip);
            Font FontNumShip = new Font("Arial", fontSmall);
            Font FontPowerOfShip = new Font("Arial", fontBig);
            float radius = 50;
            graph_bitmap.FillRectangle(brush, x - (radius / 2), y - (radius / 2), radius, radius);
            graph_bitmap.DrawString(TextPowerOfShip, FontPowerOfShip, BrushBlack, x - (radius / 3) + 3, y - (radius / 2) + 2);
            graph_bitmap.DrawString(TextNumShip, FontNumShip, BrushBlack, x - (radius / 3) - 8, y - (radius / 2) + 14);
            //graphics.DrawImage(bitmap, 0, 0, pictureBox1.Size.Width, pictureBox1.Size.Height);
        }
        public void DrawCircle(SolidBrush brush, float x, float y, int NumShip, int PowerOfShip)
        {
            string TextNumShip = Convert.ToString(NumShip);
            string TextPowerOfShip = Convert.ToString(PowerOfShip);
            Font FontNumShip = new Font("Arial", fontSmall);
            Font FontPowerOfShip = new Font("Arial", fontBig);
            float radius = 55;
            graph_bitmap.FillEllipse(brush, x - (radius / 2), y - (radius / 2), radius, radius);
            graph_bitmap.DrawString(TextPowerOfShip, FontPowerOfShip, BrushBlack, x - (radius / 3) + 6, y - (radius / 2) + 5);
            graph_bitmap.DrawString(TextNumShip, FontNumShip, BrushBlack, x - (radius / 3) - 3, y - (radius / 2) + 17);
        }
        public void WhiteRectangle(int numOfShip, bool enemy)
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
        void DrawEverything()
        {
            Map();
            for (int i = 0; i < 4; i++)
            {
                if (myShip[i].InGame) DrawTriangle(BrushLimeGreen, X_(myShip[i]), Y_(myShip[i]), i + 1, myShip[i].speed);
                if (enemy.ship[i].InGame) DrawTriangle(BrushGold, X_(enemy.ship[i]), Y_(enemy.ship[i]), i + 1, enemy.ship[i].speed);
            }

            for (int i = 4; i < 7; i++)
            {
                if (myShip[i].InGame) DrawRectangle(BrushLimeGreen, X_(myShip[i]), Y_(myShip[i]), i + 1, myShip[i].speed);
                if (enemy.ship[i].InGame) DrawRectangle(BrushGold, X_(enemy.ship[i]), Y_(enemy.ship[i]), i + 1, enemy.ship[i].speed);
            }

            for (int i = 7; i < 9; i++)
            {
                if (myShip[i].InGame) DrawCircle(BrushLimeGreen, X_(myShip[i]), Y_(myShip[i]), i + 1, myShip[i].speed);
                if (enemy.ship[i].InGame) DrawCircle(BrushGold, X_(enemy.ship[i]), Y_(enemy.ship[i]), i + 1, enemy.ship[i].speed);
            }
            graphics.DrawImage(bitmap, 0, 0, pictureBox1.Size.Width, pictureBox1.Size.Height);
        }
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
        public void Map()
        {
            double x = 0;
            double y = 0;

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
        void Draw() => graphics.DrawImage(bitmap, 0, 0, pictureBox1.Size.Width, pictureBox1.Size.Height);

        public void SetsShip(ref Ship Ship, int NumOfShip, ref short currentPoint, SolidBrush Brush)
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
                case 0: { Ship_0.Checked = false; Ship_0.Enabled = false; } break;
                case 1: { Ship_1.Checked = false; Ship_1.Enabled = false; } break;
                case 2: { Ship_2.Checked = false; Ship_2.Enabled = false; } break;
                case 3: { Ship_3.Checked = false; Ship_3.Enabled = false; } break;
                case 4: { Ship_4.Checked = false; Ship_4.Enabled = false; } break;
                case 5: { Ship_5.Checked = false; Ship_5.Enabled = false; } break;
                case 6: { Ship_6.Checked = false; Ship_6.Enabled = false; } break;
                case 7: { Ship_7.Checked = false; Ship_7.Enabled = false; } break;
                case 8: { Ship_8.Checked = false; Ship_8.Enabled = false; } break;
            }
        }
        short ShipSelection()
        {
            if (Ship_0.Checked) { return 0; }
            if (Ship_1.Checked) { return 1; }
            if (Ship_2.Checked) { return 2; }
            if (Ship_3.Checked) { return 3; }
            if (Ship_4.Checked) { return 4; }
            if (Ship_5.Checked) { return 5; }
            if (Ship_6.Checked) { return 6; }
            if (Ship_7.Checked) { return 7; }
            if (Ship_8.Checked) { return 8; }
            return -1;
        }
        bool MaxSppeed(Ship ship)
        {
            if (ship.type == 1 && ship.speed == 4 ||
                ship.type == 2 && ship.speed == 6 ||
                ship.type == 3 && ship.speed == 8) return true;

            return false;
        }
        void PrintSpeed(short numOfShip)
        {
            ShowSpeed.Text = myShip[numOfShip].speed.ToString();
            if (ChangeSpeed.Checked)
            {
                if (myShip[numOfShip].speed == 1)
                {
                    LessSpeed.Enabled = false;
                    MoreSpeed.Enabled = true;
                }
                else
                {
                    if (MaxSppeed(myShip[numOfShip]))
                    {
                        LessSpeed.Enabled = true;
                        MoreSpeed.Enabled = false;
                    }
                    else
                    {
                        LessSpeed.Enabled = true;
                        MoreSpeed.Enabled = true;
                    }
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) 
        {
            bitmap = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            graph_bitmap = Graphics.FromImage(bitmap);
            graphics = pictureBox1.CreateGraphics();
            int[] index = new int[6] { 0, 1, 2, 3, 4, 5 };
            short count;
            short dest = 6;
            double x;
            double y;
            double pi;
            double start_angle;
            double step;

            for (int i = 0; i < 126; i++) position[i] = new Position();

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
            count = 6;
            //Сохранение прыжков
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

            enemy.EnemyShipSorting();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        void AutoPos()
        {
            int NumOfShip;
            NewGameButtonMainForm_Click(null, null);
            for (int i = 0; i < 10; i++)
            {
                NumOfShip = i;
                if (i != 9)
                {
                    SetsShip(ref myShip[NumOfShip], NumOfShip, ref currentPoint, BrushLimeGreen);
                    RadioButtonOff(NumOfShip);

                    WhiteRectangle(NumOfShip, false);
                }
                if (enemy.list.Count > 0)
                {
                    NumOfShip = enemy.list[0];
                    SetsShip(ref enemy.ship[NumOfShip], NumOfShip, ref currentPoint, BrushGold);
                    WhiteRectangle(NumOfShip, true);
                    enemy.list.RemoveAt(0);
                    if (enemy.list.Count == 0 &&
                        !Ship_0.Enabled &&
                        !Ship_1.Enabled &&
                        !Ship_2.Enabled &&
                        !Ship_3.Enabled &&
                        !Ship_4.Enabled &&
                        !Ship_5.Enabled &&
                        !Ship_6.Enabled &&
                        !Ship_7.Enabled &&
                        !Ship_8.Enabled)
                    {
                        OnPosition.Visible = false;
                        Start.Visible = true;
                        break;
                    }
                }
                else
                {
                    OnPosition.Visible = false;
                    Start.Visible = true;
                }

            }

        }
        private void OnPosition_Click(object sender, EventArgs e)
        {
            OnPosition.Enabled = false;
            int NumOfShip = ShipSelection();

            AutoPosChB.Visible = false;
            if (AutoPosChB.Checked) { AutoPos(); }
            else
            {
                if (NumOfShip != -1)
                {
                    SetsShip(ref myShip[NumOfShip], NumOfShip, ref currentPoint, BrushLimeGreen);
                    RadioButtonOff(NumOfShip);
                    WhiteRectangle(NumOfShip, false);

                    if (enemy.list.Count > 0)
                    {
                        Thread.Sleep(1000);
                        NumOfShip = enemy.list[0];
                        SetsShip(ref enemy.ship[NumOfShip], NumOfShip, ref currentPoint, BrushGold);
                        WhiteRectangle(NumOfShip, true);
                        enemy.list.RemoveAt(0);
                        if (enemy.list.Count == 0 &&
                            !Ship_0.Enabled &&
                            !Ship_1.Enabled &&
                            !Ship_2.Enabled &&
                            !Ship_3.Enabled &&
                            !Ship_4.Enabled &&
                            !Ship_5.Enabled &&
                            !Ship_6.Enabled &&
                            !Ship_7.Enabled &&
                            !Ship_8.Enabled)
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
            }
            OnPosition.Enabled = true;
        }
        private void ChangeSpeed_CheckedChanged(object sender, EventArgs e)
        {
            int numOfShip = ShipSelection();
            if (numOfShip != -1)
            {
                if (myShip[numOfShip].speed == 1)
                {

                    LessSpeed.Enabled = false;
                    MoreSpeed.Enabled = true;
                }
                else
                {
                    if (MaxSppeed(myShip[numOfShip]))
                    {
                        LessSpeed.Enabled = true;
                        MoreSpeed.Enabled = false;
                    }
                    else
                    {
                        LessSpeed.Enabled = true;
                        MoreSpeed.Enabled = true;
                    }
                }
            }
        }
        private void Go_CheckedChanged(object sender, EventArgs e)
        {
            LessSpeed.Enabled = false;
            MoreSpeed.Enabled = false;
        }
        public void NewGameButtonMainForm_Click(object sender, EventArgs e)
        {
            NewGameButtonMainForm.Visible = false;
            NewGameToolStripMenuItem.Enabled = true;
            SaveGameToolStripMenuItem.Enabled = true;
            GroupShip.Visible = true;
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

            string mes;
            if (rnd.Next() % 2 != 0)
            {
                mes = "О нет! Противник прибыл раньше вас! Вы ходите вторым.";
                int NumOfShip = enemy.list[0];
                SetsShip(ref enemy.ship[NumOfShip], NumOfShip, ref currentPoint, BrushGold);
                WhiteRectangle(NumOfShip, true);
                enemy.list.RemoveAt(0);
            }
            else
            {
                mes = "Вам повезло! Противник еще не прибыл! Вы ходите первым.";
            }

            graphics.DrawImage(bitmap, 0, 0, pictureBox1.Size.Width, pictureBox1.Size.Height);
            MessageBox.Show(mes, "Кто начинает");

        }
        private void Start_Click(object sender, EventArgs e)
        {
            Start.Visible = false;
            Go.Checked = true;
            GroupAction.Visible = true;
            ShowSpeed.Visible = true;
            MoreSpeed.Visible = true;
            LessSpeed.Visible = true;
            ShipInCenterLabel.Visible = true;
            MyShipsCenterLabel.Visible = true;
            EnemyShipsCenterLebel.Visible = true;
            MyShipsCenterTextbox.Visible = true;
            EnemyShipsCenterTextbox.Visible = true;
            Step.Visible = true;
            Ship_0.Enabled = true;
            Ship_1.Enabled = true;
            Ship_2.Enabled = true;
            Ship_3.Enabled = true;
            Ship_4.Enabled = true;
            Ship_5.Enabled = true;
            Ship_6.Enabled = true;
            Ship_7.Enabled = true;
            Ship_8.Enabled = true;
            SpeedLable.Visible = true;
            ShowSpeed.Text = "";
        }
        private void LessSpeed_Click(object sender, EventArgs e)
        {
            int numOfShip = ShipSelection();

            if (numOfShip != -1)
            {
                myShip[numOfShip].speed--;
                if (Go.Enabled)
                {
                    LessSpeed.Enabled = false;
                    Go.Enabled = false;
                    GroupShip.Enabled = false;
                }
                else
                {
                    Go.Enabled = true;
                    GroupShip.Enabled = true;
                }
                MoreSpeed.Enabled = true;
                ShowSpeed.Text = myShip[numOfShip].speed.ToString();
                if (myShip[numOfShip].speed == 1) LessSpeed.Enabled = false;
            }
        }
        private void MoreSpeed_Click(object sender, EventArgs e)
        {
            int numOfShip = ShipSelection();

            if (numOfShip != -1)
            {
                myShip[numOfShip].speed++;
                if (Go.Enabled)
                {
                    MoreSpeed.Enabled = false;
                    Go.Enabled = false;
                    GroupShip.Enabled = false;
                }
                else
                {
                    Go.Enabled = true;
                    GroupShip.Enabled = true;
                }
                LessSpeed.Enabled = true;
                ShowSpeed.Text = myShip[numOfShip].speed.ToString();
                if (MaxSppeed(myShip[numOfShip])) MoreSpeed.Enabled = false;
            }
        }
        private void Step_Click(object sender, EventArgs e)
        {
            Step.Enabled = false;
            int numOfShip = ShipSelection();
            bool playerMadeStep = false;
            if (numOfShip != -1)
            {
                if (Go.Checked)
                {
                    position[myShip[numOfShip].position].busy = false;
                    if ((myShip[numOfShip].position - myShip[numOfShip].speed) < 0)
                    {
                        myShipsInCenter++;
                        MyShipsCenterTextbox.Text = myShipsInCenter.ToString();
                        myShip[numOfShip].InGame = false;
                        if (myShipsInCenter == 6)
                        {
                            DialogResult result = MessageBox.Show("Вы победили! Вам удалось опередить противника и выиграть эту битву! Империя гордиться вами! Начать заного?", "Победа!", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes) Application.Restart();
                            else Application.Exit();
                        }
                        //MessageBox.Show("Скорость не была изменена. Ход не закончен.", "Внимание!");
                    }
                    else
                    {
                        myShip[numOfShip].position -= myShip[numOfShip].speed;
                        while (position[myShip[numOfShip].position].busy && myShip[numOfShip].InGame)
                        {
                            if (position[myShip[numOfShip].position].jump == -1)
                            {
                                myShipsInCenter++;
                                MyShipsCenterTextbox.Text = myShipsInCenter.ToString();
                                myShip[numOfShip].InGame = false;
                                if (myShipsInCenter == 6)
                                {
                                    DialogResult result = MessageBox.Show("Вы победили! Вам удалось опередить противника и выиграть эту битву! Империя гордиться вами! Начать заного?", "Победа!", MessageBoxButtons.YesNo);
                                    if (result == DialogResult.Yes) Application.Restart();
                                    else Application.Exit();
                                }
                                //MessageBox.Show("Скорость не была изменена. Ход не закончен.", "Внимание!");
                            }
                            else
                            {
                                myShip[numOfShip].position = position[myShip[numOfShip].position].jump;
                            }
                        }

                        position[myShip[numOfShip].position].busy = true;
                    }
                    playerMadeStep = true;
                }
                else
                {
                    if (!Go.Enabled)
                    {
                        Go.Checked = true;
                        Go.Enabled = true;
                        MoreSpeed.Enabled = true;
                        LessSpeed.Enabled = true;
                        GroupShip.Enabled = true;
                        LessSpeed.Enabled = false;
                        MoreSpeed.Enabled = false;
                        playerMadeStep = true;
                    }
                    else
                    {
                        MessageBox.Show("Скорость не была изменена. Ход не закончен.", "Внимание!");
                    }
                }

            }
            else
            {
                MessageBox.Show("Корабль не был выбран. Ход не закончен.", "Внимание!");
            }

            if (playerMadeStep)
            {
                DrawEverything();
            }

            Step.Enabled = true;
        }
        private void Ship_0_CheckedChanged(object sender, EventArgs e) => PrintSpeed(0);
        private void Ship_1_CheckedChanged(object sender, EventArgs e) => PrintSpeed(1);
        private void Ship_2_CheckedChanged(object sender, EventArgs e) => PrintSpeed(2);
        private void Ship_3_CheckedChanged(object sender, EventArgs e) => PrintSpeed(3);
        private void Ship_4_CheckedChanged(object sender, EventArgs e) => PrintSpeed(4);
        private void Ship_5_CheckedChanged(object sender, EventArgs e) => PrintSpeed(5);
        private void Ship_6_CheckedChanged(object sender, EventArgs e) => PrintSpeed(6);
        private void Ship_7_CheckedChanged(object sender, EventArgs e) => PrintSpeed(7);
        private void Ship_8_CheckedChanged(object sender, EventArgs e) => PrintSpeed(8);
        private void GameExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы точно хотите выйти из игры?", "Выход ли это?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //result = MessageBox.Show("Сохранить прогресс игры?", "Сохранить?", MessageBoxButtons.YesNo);
                //if (result == DialogResult.Yes)
                //{
                //    //StreamWriter rulesFile = new StreamWriter(@"D:\Zlowolf\Coursework\123.txt");

                //    //string str = DateTime.Now.ToString();
                //}
                //else
                Application.Exit();
            }
        }

        private void RulesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"D:\Zlowolf\Coursework\Rules.txt"))
            {
                StreamReader rulesFile = new StreamReader(@"D:\Zlowolf\Coursework\Rules.txt");
                string mes = rulesFile.ReadToEnd();
                rulesFile.Close();
                MessageBox.Show(mes, "Правила");
            }
        }

        public void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnPosition.Visible = true;
            Go.Checked = false;
            GroupAction.Visible = false;
            ShowSpeed.Visible = false;
            MoreSpeed.Visible = false;
            LessSpeed.Visible = false;
            ShipInCenterLabel.Visible = false;
            MyShipsCenterLabel.Visible = false;
            EnemyShipsCenterLebel.Visible = false;
            MyShipsCenterTextbox.Visible = false;
            EnemyShipsCenterTextbox.Visible = false;
            Step.Visible = false;
            Ship_0.Enabled = true;
            Ship_1.Enabled = true;
            Ship_2.Enabled = true;
            Ship_3.Enabled = true;
            Ship_4.Enabled = true;
            Ship_5.Enabled = true;
            Ship_6.Enabled = true;
            Ship_7.Enabled = true;
            Ship_8.Enabled = true;
            SpeedLable.Visible = false;

            for (int i = 0; i < 4; i++)
            {
                myShip[i].speed = rnd.Next() % 4 + 1;//Задание скорости корабля
                myShip[i].InGame = true;

                enemy.ship[i].speed = rnd.Next() % 4 + 1; ;//Задание скорости корабля
                enemy.ship[i].InGame = true;
            }

            for (int i = 4; i < 7; i++)
            {
                myShip[i].speed = rnd.Next() % 6 + 1;//Задание скорости корабля
                myShip[i].InGame = true;

                enemy.ship[i].speed = rnd.Next() % 6 + 1; ;//Задание скорости корабля
                enemy.ship[i].InGame = true;
            }

            for (int i = 7; i < 9; i++)
            {
                myShip[i].speed = rnd.Next() % 8 + 1;//Задание скорости корабля
                myShip[i].InGame = true;

                enemy.ship[i].speed = rnd.Next() % 8 + 1; ;//Задание скорости корабля
                enemy.ship[i].InGame = true;
            }

            AutoPosChB.Visible = true;
            AutoPosChB.Checked = false;
            enemy.EnemyShipSorting();

            enemyShipsInCenter = 0;
            myShipsInCenter = 0;
            currentPoint = 125;

            GroupShip.Visible = true;
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

            string mes;
            if (rnd.Next() % 2 != 0)
            {
                mes = "О нет! Противник прибыл раньше вас! Вы ходите вторым.";
                int NumOfShip = enemy.list[0];
                SetsShip(ref enemy.ship[NumOfShip], NumOfShip, ref currentPoint, BrushGold);
                WhiteRectangle(NumOfShip, true);
                enemy.list.RemoveAt(0);
            }
            else
            {
                mes = "Вам повезло! Противник еще не прибыл! Вы ходите первым.";
            }

            graphics.DrawImage(bitmap, 0, 0, pictureBox1.Size.Width, pictureBox1.Size.Height);
            MessageBox.Show(mes, "Кто начинает");
        }

        public void SaveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void DownloadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) => Draw();
    }
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
    public struct Ship
    {
        public Ship(short type)
        {
            InGame = true;
            this.type = type;
        }
        public int position;
        public short type;
        public int speed;
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