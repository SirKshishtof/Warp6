using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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
            public short jump;
            public bool busy;
        }
        struct Ship
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
        class Enemy
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

        Graphics graphics;
        Graphics graph_bitmap;
        Bitmap bitmap;
        SolidBrush BrushBlack = new SolidBrush(Color.Black);
        SolidBrush BrushGold = new SolidBrush(Color.Gold);
        SolidBrush BrushLimeGreen = new SolidBrush(Color.LimeGreen);
        Pen BlackPen = new Pen(Color.Black, 3);
        Addres_Dash[] addres_dash = new Addres_Dash[30];
        Position[] position = new Position[126];
        Ship[] myShip = new Ship[9];
        Enemy enemy = new Enemy();
        Random rnd = new Random();
        System.Windows.Forms.RadioButton[] shipRadioButtons = new System.Windows.Forms.RadioButton[9];

        short enemyShipsInCenter = 0;
        short myShipsInCenter = 0;
        short currentPoint = 125;
        string savePath = Directory.GetCurrentDirectory() + "\\Save\\";
        string rulesPath = Directory.GetCurrentDirectory() + "\\Rules.txt";

        const double turn = 3.11;//Коффициент задающий поворот спирали и точек
        const short verticalShear = 20;//Сдвиг всей картинки относительно оси 
        const double kof = 12;//Коффициент задающий ширину между витками спирали и точек
        const short fontSmall = 12;//Шрифт меленькой цифры на фигуре
        const short fontBig = 25;//Шрифт большой цифры на фигуре
        const string messageYouWin= "Вы победили! Вам удалось опередить противника и выиграть эту битву! Империя гордиться вами! Начать заного?";
        const string messageBotWin = "Вы проиграли... Противник опередил вас и вы проиграли эту битву. Вы подвели империю. Начать заного?";
        //graph_bitmap.DrawRectangle(BlackPen, x - (radius / 2), y - (radius / 2), radius, radius);
        void DrawDashLine(int a, int b)
        {
            graph_bitmap.DrawLine(BlackPen, (float)position[a].x, (float)position[a].y, (float)position[b].x, (float)position[b].y);
        }
        void DrawCircle(double x, double y, float radius)
        {
            graph_bitmap.FillEllipse(BrushBlack, (float)(x - (radius / 2)), (float)(y - (radius / 2)), radius, radius);
        }
        void DrawTriangle(SolidBrush brush, float x, float y, int numShip, int speedOfShip)
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
        void DrawRectangle(SolidBrush brush, float x, float y, int numShip, int speedOfShip)
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
        void DrawCircle(SolidBrush brush, float x, float y, int numShip, int speedOfShip)
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
        void DrawShipFrame()
        {
            BlackPen.DashStyle = DashStyle.Solid;
            //graph_bitmap.DrawRectangle(BlackPen, x - (radius / 2), y - (radius / 2), radius, radius);
            short numOfShip = ShipSelection();
            //switch (myShip[numOfShip].type)
            //{
            //    case 1: { DrawTriangle(brush, ship, numOfShip + 1); } break;
            //    case 2: { DrawRectangle(brush, ship, numOfShip + 1); } break;
            //    case 3: { DrawCircle(brush, ship, numOfShip + 1); } break;
            //}
        }
        void DrawMap()
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
        void WhiteRectangle(int numOfShip, bool enemy)
        {
            float radius = 70;
            float x;
            float y = 155 + 80 * (numOfShip);

            if (enemy) { x = 1300; }
            else { x = 130; }

            graph_bitmap.FillRectangle(new SolidBrush(Color.White), x - (radius / 2), y - (radius / 2), radius, radius);
            graphics.DrawImage(bitmap, 0, 0, pictureBox.Size.Width, pictureBox.Size.Height);

        }
        void DrawingShipsOnSides()
        {
            float xLeft = 130;
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
        }
        void DrawEverything()
        {
            DrawMap();
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
            graphics.DrawImage(bitmap, 0, 0, pictureBox.Size.Width, pictureBox.Size.Height);
        }

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

        void WhoGoesFirst()
        {
            string message;
            if (rnd.Next() % 2 != 0)
            {
                message = "О нет! Противник прибыл раньше вас! Вы ходите вторым.";
                short NumOfShip = enemy.list[0];
                SetShipOnSpiral(ref enemy.ship[NumOfShip], NumOfShip, ref currentPoint, BrushGold);
                WhiteRectangle(NumOfShip, true);
                enemy.list.RemoveAt(0);
            }
            else
            {
                message = "Вам повезло! Противник еще не прибыл! Вы ходите первым.";
            }
            pictureBox.Refresh();
            graphics.DrawImage(bitmap, 0, 0, pictureBox.Size.Width, pictureBox.Size.Height);
            MessageBox.Show(message, "Кто начинает");
        }
        void InitializationAllShips()
        {
            for (short i = 0; i < 4; i++)
            {
                myShip[i].speed = (short)(rnd.Next() % 4 + 1);//Задание скорости корабля
                myShip[i].InGame = true;

                enemy.ship[i].speed = (short)(rnd.Next() % 4 + 1); ;//Задание скорости корабля
                enemy.ship[i].InGame = true;
            }

            for (short i = 4; i < 7; i++)
            {
                myShip[i].speed = (short)(rnd.Next() % 6 + 1);//Задание скорости корабля
                myShip[i].InGame = true;

                enemy.ship[i].speed = (short)(rnd.Next() % 6 + 1); ;//Задание скорости корабля
                enemy.ship[i].InGame = true;
            }

            for (short i = 7; i < 9; i++)
            {
                myShip[i].speed = (short)(rnd.Next() % 8 + 1);//Задание скорости корабля
                myShip[i].InGame = true;

                enemy.ship[i].speed = (short)(rnd.Next() % 8 + 1); ;//Задание скорости корабля
                enemy.ship[i].InGame = true;
            }
        }
        void SetShipOnSpiral(ref Ship ship, short numOfShip, ref short currentPoint, SolidBrush brush)
        {
            ship.position = currentPoint;
            position[currentPoint].busy = true;
            switch (ship.type)
            {
                case 1: { DrawTriangle(brush, X_(ship), Y_(ship), numOfShip + 1, ship.speed); } break;
                case 2: { DrawRectangle(brush, X_(ship), Y_(ship), numOfShip + 1, ship.speed); } break;
                case 3: { DrawCircle(brush, X_(ship), Y_(ship), numOfShip + 1, ship.speed); } break;
            }
            currentPoint--;
        }
        void ShipRadioButtonOff(int index)
        {
            shipRadioButtons[index].Checked = false;
            shipRadioButtons[index].Enabled = false;
            shipRadioButtons[index].BackColor = Color.WhiteSmoke;
        }
        short ShipSelection()
        {
            for (short i = 0; i < 9; i++)
            {
                if (shipRadioButtons[i].Checked) return i;
            }
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
            if (ChangeSpeed_RadioButton.Checked)
            {
                if (myShip[numOfShip].speed == 1)
                {
                    LessSpeed_Button.Enabled = false;
                    MoreSpeed_Button.Enabled = true;
                }
                else
                {
                    if (MaxSppeed(myShip[numOfShip]))
                    {
                        LessSpeed_Button.Enabled = true;
                        MoreSpeed_Button.Enabled = false;
                    }
                    else
                    {
                        LessSpeed_Button.Enabled = true;
                        MoreSpeed_Button.Enabled = true;
                    }
                }
            }
        }
        void AutoPos()
        {
            short NumOfShip;
            for (short i = 0; i < 10; i++)
            {
                NumOfShip = i;
                if (i != 9)
                {
                    SetShipOnSpiral(ref myShip[NumOfShip], NumOfShip, ref currentPoint, BrushLimeGreen);
                    ShipRadioButtonOff(NumOfShip);

                    WhiteRectangle(NumOfShip, false);
                }
                if (enemy.list.Count > 0)
                {
                    NumOfShip = enemy.list[0];
                    SetShipOnSpiral(ref enemy.ship[NumOfShip], NumOfShip, ref currentPoint, BrushGold);
                    WhiteRectangle(NumOfShip, true);
                    enemy.list.RemoveAt(0);

                    bool shipNotEnabled = true;
                    for (short j = 0; j < 9; j++)
                    {
                        if (shipRadioButtons[j].Enabled) { shipNotEnabled = false; break; }
                    }

                    if (enemy.list.Count == 0 && shipNotEnabled)
                    {
                        OnPosition_Button.Text = "Начать игру";
                        break;
                    }
                }
                else
                {
                    OnPosition_Button.Text = "Начать игру";
                }

            }
            AutoPosChB.Checked = false;
        }
        void ShipOutOfGame(TextBox ShipsCenterTextbox, ref Ship ship, ref short ShipsInCenter, short numOfShip, string message)
        {
            ShipsInCenter++;
            string winOrLoss = "Проигрыш...";
            if (message.Contains("Вы победили!")) { ShipRadioButtonOff(numOfShip); winOrLoss = "Победа!"; } 
            ShipsCenterTextbox.Text = ShipsInCenter.ToString();
            ship.InGame = false;
            if (myShipsInCenter == 6)
            {
                DialogResult result = MessageBox.Show(message, winOrLoss, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) Application.Restart();
                else Application.Exit();
            }
        }
        void MovingOfShip(TextBox ShipsCenterTextbox, ref Ship ship, ref short ShipsInCenter, short numOfShip, string message)
        {
            position[ship.position].busy = false;
            if ((ship.position - ship.speed) < 0) ShipOutOfGame(ShipsCenterTextbox, ref ship, ref ShipsInCenter, numOfShip, message);
            else
            {
                ship.position -= ship.speed;
                while (position[ship.position].busy && ship.InGame)
                {
                    if (position[ship.position].jump == -1) ShipOutOfGame(ShipsCenterTextbox, ref ship, ref ShipsInCenter, numOfShip, message);
                    else ship.position = position[ship.position].jump;
                }
                position[ship.position].busy = true;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            graph_bitmap = Graphics.FromImage(bitmap);
            graphics = pictureBox.CreateGraphics();
            short[] index = new short[6] { 0, 1, 2, 3, 4, 5 };
            short count;
            short dest = 6;
            double x;
            double y;
            double pi;
            double start_angle;
            double step;

            for (short i = 0; i < shipRadioButtons.Length; i++) shipRadioButtons[i] = new System.Windows.Forms.RadioButton();
            
            shipRadioButtons[0] = Ship_0;
            shipRadioButtons[1] = Ship_1;
            shipRadioButtons[2] = Ship_2;
            shipRadioButtons[3] = Ship_3;
            shipRadioButtons[4] = Ship_4;
            shipRadioButtons[5] = Ship_5;
            shipRadioButtons[6] = Ship_6;
            shipRadioButtons[7] = Ship_7;
            shipRadioButtons[8] = Ship_8;

            for (short i = 0; i < 126; i++) position[i] = new Position();

            for (short i = 0; i < 4; i++)
            {
                myShip[i] = new Ship(1);
                enemy.ship[i] = new Ship(1);
            }

            for (short i = 4; i < 7; i++)
            {
                myShip[i] = new Ship(2);
                enemy.ship[i] = new Ship(2);
            }

            for (short i = 7; i < 9; i++)
            {
                myShip[i] = new Ship(3);
                enemy.ship[i] = new Ship(3);
            }
            count = 6;
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
            enemy.EnemyShipSorting();
            Directory.CreateDirectory(savePath);
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
        private void Go_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            LessSpeed_Button.Enabled = false;
            MoreSpeed_Button.Enabled = false;
        }
        private void ChangeSpeed_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            int numOfShip = ShipSelection();
            if (numOfShip != -1)
            {
                if (myShip[numOfShip].speed == 1)
                {

                    LessSpeed_Button.Enabled = false;
                    MoreSpeed_Button.Enabled = true;
                }
                else
                {
                    if (MaxSppeed(myShip[numOfShip]))
                    {
                        LessSpeed_Button.Enabled = true;
                        MoreSpeed_Button.Enabled = false;
                    }
                    else
                    {
                        LessSpeed_Button.Enabled = true;
                        MoreSpeed_Button.Enabled = true;
                    }
                }
            }
        }
        
        private void OnPosition_Button_Click(object sender, EventArgs e)
        {
            OnPosition_Button.Enabled = false;
            short NumOfShip = ShipSelection();

            AutoPosChB.Visible = false;
            if (AutoPosChB.Checked) { AutoPos(); }
            else
            {
                if (OnPosition_Button.Text == "На позицию")
                {
                    if (NumOfShip != -1)
                    {
                        ShipRadioButtonOff(NumOfShip);
                        SetShipOnSpiral(ref myShip[NumOfShip], NumOfShip, ref currentPoint, BrushLimeGreen);
                        WhiteRectangle(NumOfShip, false);

                        if (enemy.list.Count > 0)
                        {
                            Thread.Sleep(1000);
                            NumOfShip = enemy.list[0];
                            SetShipOnSpiral(ref enemy.ship[NumOfShip], NumOfShip, ref currentPoint, BrushGold);
                            WhiteRectangle(NumOfShip, true);
                            enemy.list.RemoveAt(0);

                            bool shipNotEnabled = true;
                            for (short j = 0; j < 9; j++)
                            {
                                if (shipRadioButtons[j].Enabled) { shipNotEnabled = false; break; }
                            }

                            if (enemy.list.Count == 0 && shipNotEnabled)
                            {
                                OnPosition_Button.Text = "Начать игру";
                            }
                        }
                        else
                        {
                            OnPosition_Button.Text = "Начать игру";
                        }
                    }
                }
                else
                {
                    OnPosition_Button.Visible = false;
                    Go_RadioButton.Checked = true;
                    GroupAction.Visible = true;
                    ShowSpeed.Visible = true;
                    MoreSpeed_Button.Visible = true;
                    LessSpeed_Button.Visible = true;
                    ShipInCenterLabel.Visible = true;
                    MyShipsCenterLabel.Visible = true;
                    EnemyShipsCenterLebel.Visible = true;
                    MyShipsCenterTextbox.Visible = true;
                    EnemyShipsCenterTextbox.Visible = true;
                    Step_Button.Visible = true;
                    for (short i = 0; i < 9; i++)
                    {
                        shipRadioButtons[i].Enabled = true;
                        shipRadioButtons[i].BackColor = Color.Transparent;
                    }
                    SpeedLable.Visible = true;
                    ShowSpeed.Text = "";
                }
            }

            OnPosition_Button.Enabled = true;
        }
        private void LessSpeed_Button_Click(object sender, EventArgs e)
        {
            int numOfShip = ShipSelection();

            if (numOfShip != -1)
            {
                myShip[numOfShip].speed--;
                if (Go_RadioButton.Enabled)
                {
                    LessSpeed_Button.Enabled = false;
                    Go_RadioButton.Enabled = false;
                    GroupShip.Enabled = false;
                }
                else
                {
                    Go_RadioButton.Enabled = true;
                    GroupShip.Enabled = true;
                }
                MoreSpeed_Button.Enabled = true;
                ShowSpeed.Text = myShip[numOfShip].speed.ToString();
                if (myShip[numOfShip].speed == 1) LessSpeed_Button.Enabled = false;
            }
        }
        private void MoreSpeed_Button_Click(object sender, EventArgs e)
        {
            int numOfShip = ShipSelection();

            if (numOfShip != -1)
            {
                myShip[numOfShip].speed++;
                if (Go_RadioButton.Enabled)
                {
                    MoreSpeed_Button.Enabled = false;
                    Go_RadioButton.Enabled = false;
                    GroupShip.Enabled = false;
                }
                else
                {
                    Go_RadioButton.Enabled = true;
                    GroupShip.Enabled = true;
                }
                LessSpeed_Button.Enabled = true;
                ShowSpeed.Text = myShip[numOfShip].speed.ToString();
                if (MaxSppeed(myShip[numOfShip])) MoreSpeed_Button.Enabled = false;
            }
        }
        private void Step_Button_Click(object sender, EventArgs e)
        {
            Step_Button.Enabled = false;
            short numOfShip = ShipSelection();
            bool playerMadeStep = false;
            if (numOfShip != -1)
            {
                if (Go_RadioButton.Checked)
                {
                    MovingOfShip(MyShipsCenterTextbox, ref myShip[numOfShip], ref myShipsInCenter, numOfShip, messageYouWin);
                    playerMadeStep = true;
                }
                else
                {
                    if (!Go_RadioButton.Enabled)
                    {
                        Go_RadioButton.Checked = true;
                        Go_RadioButton.Enabled = true;
                        MoreSpeed_Button.Enabled = true;
                        LessSpeed_Button.Enabled = true;
                        GroupShip.Enabled = true;
                        LessSpeed_Button.Enabled = false;
                        MoreSpeed_Button.Enabled = false;
                        playerMadeStep = true;
                    }
                    else MessageBox.Show("Скорость не была изменена. Ход не закончен.", "Внимание!");
                }
            }
            else MessageBox.Show("Корабль не был выбран. Ход не закончен.", "Внимание!");
            

            if (playerMadeStep)
            {

                DrawEverything();
            }

            Step_Button.Enabled = true;
        }
        private void СreateSave_Button_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex("[\\\\/:*?\"<>|]");
            MatchCollection matches = reg.Matches(SaveName_Textbox.Text);
            if (matches.Count == 0)
            {
                StreamWriter SaveFile = new StreamWriter(savePath + SaveName_Textbox.Text + ".txt");

                for (int i = 0; i < 9; i++)
                {
                    SaveFile.WriteLine(myShip[i].speed);
                    SaveFile.WriteLine(myShip[i].position);
                    SaveFile.WriteLine(myShip[i].InGame);

                    SaveFile.WriteLine(enemy.ship[i].speed);
                    SaveFile.WriteLine(enemy.ship[i].position);
                    SaveFile.WriteLine(enemy.ship[i].InGame);
                }
                SaveFile.WriteLine(myShipsInCenter);
                SaveFile.WriteLine(enemyShipsInCenter);
                SaveFile.WriteLine(enemy.list.Count);
                for (short i = 0; i < enemy.list.Count; i++) SaveFile.WriteLine(enemy.list[i]);
                SaveFile.WriteLine(currentPoint);
                SaveFile.Close();

                InvalidСharacters_Label.Visible = false;
                СreateSave_Button.Visible = false;
                SaveName_Label.Visible = false;
                SaveName_Textbox.Visible = false;
                SaveGame_ToolStripMenuItem.Text = "Сохранить игру";
                Go_RadioButton.Enabled = true;
                Step_Button.Enabled = true;
                GroupShip.Enabled = true;
                OnPosition_Button.Enabled = true;
                GroupAction.Enabled = true;
                GroupAction.Enabled = true;
                DownloadGame_ToolStripMenuItem.Enabled = true;
                NewGame_ToolStripMenuItem.Enabled = true;
            }
            else InvalidСharacters_Label.Visible = true;
        }
        private void NewGame_Buttom_Click(object sender, EventArgs e)
        {
            NewGame_Buttom.Visible = false;
            OnPosition_Button.Visible = true;
            GroupShip.Visible = true;
            NewGame_Buttom.Visible = false;
            DownloadGame_Buttom.Visible = false;
            NewGame_ToolStripMenuItem.Visible = true;
            DownloadGame_ToolStripMenuItem.Visible = true;
            SaveGame_ToolStripMenuItem.Visible = true;
            GameExit_Buttom.Width = 177;
            GameExit_Buttom.Height = 33;
            GameExit_Buttom.Location = new Point(1713, 955);
            GameExit_Buttom.Font = new Font("Segoe UI", 12);
            myShipsInCenter = 0;
            enemyShipsInCenter = 0;

            InitializationAllShips();
            enemy.EnemyShipSorting();
            DrawMap();
            DrawingShipsOnSides();
            WhoGoesFirst();
        }
        private void DownloadGame_Buttom_Click(object sender, EventArgs e)
        {
            if (DownloadGame_Buttom.Text == "Загрузить игру")
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(savePath);
                FileInfo[] files = directoryInfo.GetFiles("*.txt");

                foreach (FileInfo fi in files)
                {
                    SaveList.Items.Add(fi.Name.ToString().Replace(".txt", ""));
                }

                SaveList.Visible = true;
                LoadingTheSelectedSave_Buttom.Visible = true;
                NewGame_Buttom.Enabled = false;
                GameExit_Buttom.Enabled = false;
                DownloadGame_Buttom.Text = "Назад";
            }
            else
            {
                SaveList.Visible = false;
                LoadingTheSelectedSave_Buttom.Visible = false;
                NewGame_Buttom.Enabled = true;
                GameExit_Buttom.Enabled = true;
                DownloadGame_Buttom.Text = "Загрузить игру";
            }
        }
        private void LoadingTheSelectedSave_Buttom_Click(object sender, EventArgs e)
        {
            bool wantToLoad = true;
            
            if (File.Exists(savePath + SaveList.SelectedItem + ".txt"))
            {
                if (!NewGame_Buttom.Visible)
                {   
                    DialogResult result = MessageBox.Show("Хотите загрузить игру?\n Весь не сохранённый прогресс будет потерян.", "Загрузка", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                    {
                        wantToLoad = false;
                    }
                    else
                    {
                        DownloadGame_ToolStripMenuItem.Text = "Загрузить игру";
                        GroupShip.Enabled = true;
                    }
                }
                else
                {
                    NewGame_Buttom.Visible = false;
                    DownloadGame_Buttom.Visible = false;
                    GameExit_Buttom.Enabled = true;
                    GameExit_Buttom.Width = 177;
                    GameExit_Buttom.Height = 33;
                    GameExit_Buttom.Location = new Point(1713, 955);
                    GameExit_Buttom.Font = new Font("Segoe UI", 12);
                    GroupShip.Visible = true;
                    NewGame_ToolStripMenuItem.Visible = true;
                    DownloadGame_ToolStripMenuItem.Visible = true;
                    SaveGame_ToolStripMenuItem.Visible = true;
                }

                if (wantToLoad)
                {                    
                    LoadingTheSelectedSave_Buttom.Visible = false;
                    SaveList.Visible = false;
                    GroupShip.Enabled = true;
                    Go_RadioButton.Enabled = true;
                    GroupAction.Enabled = true;
                    GroupAction.Enabled = true;
                    Step_Button.Enabled = true;
                    OnPosition_Button.Enabled = true;
                    DownloadGame_ToolStripMenuItem.Enabled = true;
                    SaveGame_ToolStripMenuItem.Enabled = true;
                    NewGame_ToolStripMenuItem.Enabled = true;

                    StreamReader SaveFile = new StreamReader(savePath + SaveList.SelectedItem + ".txt");
                    const float xLeft = 130;
                    const float xRight = 1300;
                    float yOnSide = 160;
                    float x = 0;
                    float y = 0;
                    float shift = 80;
                    bool onPosition = false;

                    for (short i = 0; i < 126; i++) position[i].busy = false;

                    for (short i = 0; i < 9; i++)
                    {
                        myShip[i].speed = short.Parse(SaveFile.ReadLine());
                        myShip[i].position = short.Parse(SaveFile.ReadLine());
                        myShip[i].InGame = bool.Parse(SaveFile.ReadLine());
                        if (myShip[i].position > -1) position[myShip[i].position].busy = true;

                        enemy.ship[i].speed = short.Parse(SaveFile.ReadLine());
                        enemy.ship[i].position = short.Parse(SaveFile.ReadLine());
                        enemy.ship[i].InGame = bool.Parse(SaveFile.ReadLine());
                        if (enemy.ship[i].position > -1) position[enemy.ship[i].position].busy = true;
                    }

                    myShipsInCenter = short.Parse(SaveFile.ReadLine());
                    enemyShipsInCenter = short.Parse(SaveFile.ReadLine());
                    MyShipsCenterTextbox.Text = myShipsInCenter.ToString();
                    EnemyShipsCenterTextbox.Text = enemyShipsInCenter.ToString();
                    short listCount = short.Parse(SaveFile.ReadLine());
                    enemy.list.Clear();
                    while (listCount > 0)
                    {
                        enemy.list.Add(short.Parse(SaveFile.ReadLine()));
                        listCount--;
                    }
                    currentPoint = short.Parse(SaveFile.ReadLine());
                    SaveFile.Close();
                    DrawMap();



                    for (short i = 0; i < 4; i++)
                    {
                        if (myShip[i].InGame) 
                        {
                            if (myShip[i].position == -1) { x = xLeft; y = yOnSide; onPosition = true; }
                            else { x = X_(myShip[i]); y = Y_(myShip[i]); }
                            DrawTriangle(BrushLimeGreen, x, y, i + 1, myShip[i].speed);
                        }

                        if (enemy.ship[i].InGame)
                        {
                            if (enemy.ship[i].position == -1) { x = xRight; y = yOnSide; }
                            else { x = X_(enemy.ship[i]); y = Y_(enemy.ship[i]); }
                            DrawTriangle(BrushGold, x, y, i + 1, enemy.ship[i].speed);
                        }

                        yOnSide += shift;
                    }

                    for (short i = 4; i < 7; i++)
                    {
                        if (myShip[i].InGame)
                        {
                            if (myShip[i].position == -1) { x = xLeft; y = yOnSide; onPosition = true; }
                            else { x = X_(myShip[i]); y = Y_(myShip[i]); }
                            DrawRectangle(BrushLimeGreen, x, y, i + 1, myShip[i].speed);
                        }

                        if (enemy.ship[i].InGame)
                        {
                            if (enemy.ship[i].position == -1) { x = xRight; y = yOnSide; }
                            else { x = X_(enemy.ship[i]); y = Y_(enemy.ship[i]); }
                            DrawRectangle(BrushGold, x, y, i + 1, enemy.ship[i].speed);
                        }

                        yOnSide += shift;
                    }

                    for (short i = 7; i < 9; i++)
                    {
                        if (myShip[i].InGame)
                        {
                            if (myShip[i].position == -1) { x = xLeft; y = yOnSide; onPosition = true; }
                            else { x = X_(myShip[i]); y = Y_(myShip[i]); }
                            DrawCircle(BrushLimeGreen, x, y, i + 1, myShip[i].speed);
                        }

                        if (enemy.ship[i].InGame)
                        {
                            if (enemy.ship[i].position == -1) { x = xRight; y = yOnSide; }
                            else { x = X_(enemy.ship[i]); y = Y_(enemy.ship[i]); }
                            DrawCircle(BrushGold, x, y, i + 1, enemy.ship[i].speed);
                        }
                       
                        yOnSide += shift;
                    }

                    if (onPosition)
                    {
                        OnPosition_Button.Visible = true;
                        OnPosition_Button.Enabled = true;
                        OnPosition_Button.Text = "На позицию";

                        for (short i = 0; i < 9; i++)
                        {
                            if (myShip[i].position == -1)
                            {
                                shipRadioButtons[i].Enabled = true;
                                shipRadioButtons[i].BackColor = Color.Transparent;
                            }
                            else
                            {
                                shipRadioButtons[i].Enabled = false;
                                shipRadioButtons[i].BackColor = Color.WhiteSmoke;
                            }
                        }
                    }
                    else
                    {
                        for (short i = 125; i < 107; i++) if (!position[i].busy) { onPosition = false; break; }

                        if (!onPosition)
                        {
                            OnPosition_Button.Visible = true;
                            OnPosition_Button.Enabled = true;
                            OnPosition_Button.Text = "Начать игру";
                        }
                        else
                        {   
                            OnPosition_Button.Visible = false;
                            Go_RadioButton.Checked = true;
                            GroupAction.Visible = true;
                            MoreSpeed_Button.Visible = true;
                            LessSpeed_Button.Visible = true;
                            Step_Button.Visible = true;
                            ShowSpeed.Visible = true;
                            ShipInCenterLabel.Visible = true;
                            MyShipsCenterLabel.Visible = true;
                            MyShipsCenterTextbox.Visible = true;
                            EnemyShipsCenterLebel.Visible = true;
                            EnemyShipsCenterTextbox.Visible = true;
                            LoadingTheSelectedSave_Buttom.Visible = false;
                            SaveList.Visible = false;

                            for (short i = 0; i < 9; i++)
                            {
                                if (myShip[i].InGame)
                                {
                                    shipRadioButtons[i].Enabled = true;
                                    shipRadioButtons[i].BackColor = Color.Transparent;
                                }
                                else
                                {
                                    shipRadioButtons[i].Enabled = false;
                                    shipRadioButtons[i].BackColor = Color.WhiteSmoke;
                                }
                            }

                            SpeedLable.Visible = true;
                            ShowSpeed.Text = "";
                        }
                    }
                    this.Refresh();
                    graphics.DrawImage(bitmap, 0, 0, pictureBox.Size.Width, pictureBox.Size.Height);
                }
            }
        }
        private void GameExit_Buttom_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Хотите выйти из игры?\n Весь не сохранённый прогресс будет потерян.", "Выход", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else Application.Restart();
        }

        private void Rules_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(rulesPath))
            {
                StreamReader rulesFile = new StreamReader(rulesPath);
                string mes = rulesFile.ReadToEnd();
                rulesFile.Close();
                MessageBox.Show(mes, "Правила");
            }
        }
        private void NewGame_ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Хотите начать новую игру?\n Весь не сохранённый прогресс будет потерян.", "Новая игра", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                NewGame_Buttom.Visible = false;
                OnPosition_Button.Visible = true;
                OnPosition_Button.Text = "На позицию";
                Go_RadioButton.Checked = false;
                GroupAction.Visible = false;
                ShowSpeed.Visible = false;
                MoreSpeed_Button.Visible = false;
                LessSpeed_Button.Visible = false;
                ShipInCenterLabel.Visible = false;
                MyShipsCenterLabel.Visible = false;
                EnemyShipsCenterLebel.Visible = false;
                MyShipsCenterTextbox.Visible = false;
                EnemyShipsCenterTextbox.Visible = false;
                Step_Button.Visible = false;
                AutoPosChB.Visible = true;
                AutoPosChB.Checked = false;
                SpeedLable.Visible = false;
                OnPosition_Button.Visible = true;
                myShipsInCenter = 0;
                enemyShipsInCenter = 0;
                enemyShipsInCenter = 0;
                myShipsInCenter = 0;
                currentPoint = 125;

                for (short i = 0; i < 9; i++)
                {
                    shipRadioButtons[i].Enabled = true;
                    shipRadioButtons[i].BackColor = Color.Transparent;
                }

                InitializationAllShips();
                enemy.EnemyShipSorting();
                DrawMap();
                DrawingShipsOnSides();
                WhoGoesFirst();
            }
        }
        private void SaveGame_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveGame_ToolStripMenuItem.Text == "Сохранить игру")
            {
                СreateSave_Button.Visible = true;
                SaveName_Label.Visible = true;
                SaveName_Textbox.Visible = true;
                SaveGame_ToolStripMenuItem.Text = "Отменить сохранение";
                string str = DateTime.Now.ToString().Replace(":", ".").Replace(" ", "  ");

                SaveName_Textbox.Text = str;

                GroupShip.Enabled = false;
                Go_RadioButton.Checked = true;
                Go_RadioButton.Enabled = false;
                GroupAction.Enabled = false;
                GroupAction.Enabled = false;
                Step_Button.Enabled = false;
                OnPosition_Button.Enabled = false;
                DownloadGame_ToolStripMenuItem.Enabled = false;
                NewGame_ToolStripMenuItem.Enabled = false;
            }
            else
            {
                СreateSave_Button.Visible = false;
                SaveName_Label.Visible = false;
                SaveName_Textbox.Visible = false;
                SaveGame_ToolStripMenuItem.Text = "Сохранить игру";

                GroupShip.Enabled = true;
                Go_RadioButton.Enabled = true;
                GroupAction.Enabled = true;
                GroupAction.Enabled = true;
                Step_Button.Enabled = true;
                OnPosition_Button.Enabled = true;
                DownloadGame_ToolStripMenuItem.Enabled = true;
                NewGame_ToolStripMenuItem.Enabled = true;
            }
        }
        private void DownloadGame_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DownloadGame_ToolStripMenuItem.Text == "Загрузить игру")
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(savePath);
                FileInfo[] files = directoryInfo.GetFiles("*.txt");
                SaveList.Items.Clear();
                foreach (FileInfo fi in files)
                {
                    SaveList.Items.Add(fi.Name.ToString().Replace(".txt", ""));
                }

                SaveList.Location = new Point(758, 289);
                LoadingTheSelectedSave_Buttom.Location = new Point(867, 695);
                SaveList.Visible = true;
                LoadingTheSelectedSave_Buttom.Visible = true;
                DownloadGame_ToolStripMenuItem.Text = "Отменить загрузку";
                GroupShip.Enabled = false;
                Go_RadioButton.Checked = true;
                Go_RadioButton.Enabled = false;
                GroupAction.Enabled = false;
                GroupAction.Enabled = false;
                Step_Button.Enabled = false;
                OnPosition_Button.Enabled = false;
                SaveGame_ToolStripMenuItem.Enabled = false;
                NewGame_ToolStripMenuItem.Enabled = false;
            }
            else
            {
                SaveList.Visible = false;
                LoadingTheSelectedSave_Buttom.Visible = false;
                DownloadGame_ToolStripMenuItem.Text = "Загрузить игру";

                GroupShip.Enabled = true;
                Go_RadioButton.Enabled = true;
                GroupAction.Enabled = true;
                GroupAction.Enabled = true;
                Step_Button.Enabled = true;
                OnPosition_Button.Enabled = true;
                SaveGame_ToolStripMenuItem.Enabled = true;
                NewGame_ToolStripMenuItem.Enabled = true;

                pictureBox.Refresh();
                graphics.DrawImage(bitmap, 0, 0, pictureBox.Size.Width, pictureBox.Size.Height);
            }
        }
    }
}