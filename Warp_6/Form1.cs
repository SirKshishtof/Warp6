using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
//using System.Linq;
//using System.Security.Cryptography;
//using System.Text;
using System.Threading;
//using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;


namespace Warp_6
{
    public partial class Form1 : Form
    {
        class Position
        {
            public double pi;
            public double x;
            public double y;
            public int jump;
            public bool busy;
        }

        class Ship
        {
            public int position;
            public int type;
            public int speed;
            public bool InGame;
        }

        struct Addres_Dash
        {
            public int _external;
            public int _internal;
        }

        Graphics graphics;
        Graphics graph_bitmap;
        Bitmap bitmap;
        SolidBrush BrushBlack = new SolidBrush(Color.Black);
        SolidBrush BrushGold = new SolidBrush(Color.Gold);
        SolidBrush BrushLimeGreen = new SolidBrush(Color.LimeGreen);
        Pen BlackPen = new Pen(Color.Black, 3);

        Position[] position = new Position[126];
        Ship[] MyShip = new Ship[9];
        Ship[] EnemyShip = new Ship[9];
        Random rnd = new Random();
        List<int> list = new List<int>();

        Addres_Dash[] addres_dash = new Addres_Dash[30];

        short EnemyShipsInCenter = 0;
        double x;
        double y;

        void DrawDashLine(int a, int b)
        {
            graph_bitmap.DrawLine(BlackPen, (float)position[a].x, (float)position[a].y, (float)position[b].x, (float)position[b].y); 
        }

        void DrawCircle(double x, double y, float radius)
        {
            graph_bitmap.FillEllipse(BrushBlack, (float)(x - (radius / 2)), (float)(y - (radius / 2)), radius, radius);
        }

        void DrawTriangle(SolidBrush brush, int index, int NumShip, int PowerOfShip)
        {
            String TextNumShip = Convert.ToString(NumShip);
            String TextPowerOfShip = Convert.ToString(PowerOfShip);
            Font FontNumShip = new Font("Arial", 10);
            Font FontPowerOfShip = new Font("Arial", 25 );
            float radius = 30;
            float x = (float)position[index].x;
            float y = (float)position[index].y;
            float Shift = (float)Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(radius / 2, 2));
            PointF TopPoint = new PointF(x, y - radius);
            PointF BottomLeftPoint = new PointF(x - Shift, y + (radius / 2));
            PointF BottomRightPoint = new PointF(x + Shift, y + (radius / 2));
            PointF[] curvePoints = { TopPoint, BottomLeftPoint, BottomRightPoint };
            graph_bitmap.FillPolygon(brush, curvePoints);
            graph_bitmap.DrawString( TextPowerOfShip, FontPowerOfShip, BrushBlack, x - (radius / 3)-4, y - (radius / 2)-4);
            graph_bitmap.DrawString(TextNumShip, FontNumShip, BrushBlack, x - (radius / 3 - 10) - 20, y - (radius / 2) + 15);
            graphics.DrawImage(bitmap, 0, 0, pictureBox1.Size.Width, pictureBox1.Size.Height);
        }
        
        void DrawRectangle(SolidBrush brush, int index, int NumShip, int PowerOfShip)
        {
            String TextNumShip = Convert.ToString(NumShip);
            String TextPowerOfShip = Convert.ToString(PowerOfShip);
            Font FontNumShip = new Font("Arial", 10);
            Font FontPowerOfShip = new Font("Arial", 25);
            float radius = 40;
            float x = (float)position[index].x;
            float y = (float)position[index].y;
            graph_bitmap.FillRectangle(brush, x - (radius / 2), y - (radius / 2), radius, radius);
            graph_bitmap.DrawString(TextPowerOfShip, FontPowerOfShip, BrushBlack, x - (radius / 3) - 1, y - (radius / 2) + 2);
            graph_bitmap.DrawString(TextNumShip, FontNumShip, BrushBlack, x - (radius / 3) - 5, y - (radius / 2) + 14);
            graphics.DrawImage(bitmap, 0, 0, pictureBox1.Size.Width, pictureBox1.Size.Height);
        }
        
        void DrawCircle(SolidBrush brush, int index, int NumShip, int PowerOfShip)
        {
            String TextNumShip = Convert.ToString(NumShip);
            String TextPowerOfShip = Convert.ToString(PowerOfShip);
            Font FontNumShip = new Font("Arial", 10);
            Font FontPowerOfShip = new Font("Arial", 25);
            float radius = 40;
            float x = (float)position[index].x;
            float y = (float)position[index].y;
            graph_bitmap.FillEllipse(brush, x - (radius / 2), y - (radius / 2), radius, radius);
            graph_bitmap.DrawString(TextPowerOfShip, FontPowerOfShip, BrushBlack, x - (radius / 3) - 1, y - (radius / 2) + 2);
            graph_bitmap.DrawString(TextNumShip, FontNumShip, BrushBlack, x - (radius / 3) - 5, y - (radius / 2) + 14);
            graphics.DrawImage(bitmap, 0, 0, pictureBox1.Size.Width, pictureBox1.Size.Height);
        }

        double PolarToX(double pi, double turn, int k)
        {
            double p = pi * k;
            double x = p * Math.Cos(pi + turn) + pictureBox1.Size.Width / 2; ;
            return x;
        }

        double PolarToY(double pi, double turn, int k)
        {
            double p = pi * k;
            double y = p * Math.Sin(pi + turn) + pictureBox1.Size.Height / 2 - 25;
            return y;
        }

        void Map()
        {
            const int Kof = 10;
            const double turn = 3.11;
            double pi = 0;
            float radius = 40;
            

            graph_bitmap.Clear(Color.White);
            
            BlackPen.DashStyle = DashStyle.Dash;

            DrawCircle(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2 - 25, radius);

            radius = 4;
            //Отрисовывание сприрали 
            for (int i = 0; i < 41400; i++)
            {
                x = PolarToX(pi, turn, Kof);
                y = PolarToY(pi, turn, Kof);
                DrawCircle(x, y, radius);
                pi += 0.001;
            }

            //Отрисовывание точек
            radius = 25;

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

            graphics.DrawImage(bitmap, 0, 0, pictureBox1.Size.Width, pictureBox1.Size.Height);
        }

        int[] ArrZero(int[] Arr)
        {
            int size = Arr.Length;
            for (int i = 0; i<size; i++)
            {
                Arr[i] = 0;
            }
            return Arr;
        }

        List<int> EnemyShipSorting()
        {
            int count = -1;
            int max = 0;
            int[] index = new int[9];
            List<int> list = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                if (EnemyShip[i].speed > max)
                {
                    max = EnemyShip[i].speed;
                    count = i;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (i != count)
                {
                    EnemyShip[i].InGame = false;
                }
            }
            for (int i = 0; i < 9; i++)
            {
                if (EnemyShip[i].InGame) { index[i] = EnemyShip[i].speed; }
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
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (EnemyShip[j].speed >= max && !EnemyShip[j].InGame)
                    {
                        max = EnemyShip[j].speed;
                        count = j;
                    }
                }
                EnemyShip[count].InGame = true;
                list.Add(count);
                max = 0;
            }
            for (int i = 0; i < 9; i++)
            {
                EnemyShip[i].InGame = true;
            }
            return list;
        }
        void AlexSetsShip()
        {
            int StartPoint = 0;
            int NumOfShip = list[0];
            list.RemoveAt(0);
            EnemyShip[NumOfShip].position = StartPoint - 1;
            switch (EnemyShip[NumOfShip].type)
            {
                case 1:
                    {
                        DrawTriangle(BrushGold, EnemyShip[NumOfShip].position, NumOfShip + 1, EnemyShip[NumOfShip].speed);
                    }
                    break;
                case 2:
                    {
                        DrawRectangle(BrushGold, EnemyShip[NumOfShip].position, NumOfShip + 1, EnemyShip[NumOfShip].speed);
                    }
                    break;
                case 3:
                    {
                        DrawCircle(BrushGold, EnemyShip[NumOfShip].position, NumOfShip + 1, EnemyShip[NumOfShip].speed);
                    }
                    break;
            }
        }
        void AlexMove()
        {
            int BotMove = AlexMoveShip();
            int index = BotMove / 100;
            if ((BotMove / 10) % 10 == 0)
            {
                position[EnemyShip[index].position].busy = false;
                EnemyShip[index].position = EnemyShip[index].position - EnemyShip[index].speed;
                if (EnemyShip[index].position < 0)
                {
                    EnemyShip[index].InGame = false;
                    EnemyShipsInCenter++;
                }
                else
                {
                    if (position[EnemyShip[index].position].busy) { EnemyShip[index].position = position[EnemyShip[index].position].jump; }
                    while (position[EnemyShip[index].position].busy && EnemyShip[index].InGame == true)
                    {
                        if (position[EnemyShip[index].position].jump != -1)
                        {
                            EnemyShip[index].position = position[EnemyShip[index].position].jump;
                        }
                        else
                        {
                            EnemyShip[index].InGame = false;
                            EnemyShipsInCenter++;
                        }
                    }
                    position[EnemyShip[index].position].busy = true;
                }
                EnemyShipsCenterTextbox.Text = EnemyShipsInCenter.ToString();
            }
            else
            {
                if (BotMove % 10 == 0) { EnemyShip[index].speed--; }
                else { EnemyShip[index].speed++; }
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
                if (EnemyShip[i].InGame)
                {
                    count = 0;
                    index = EnemyShip[i].position - EnemyShip[i].speed;
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
                    if (EnemyShip[i].position < min)
                    {
                        index = i;
                        min = EnemyShip[i].position;
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
                if (EnemyShip[i].InGame)
                {
                    index = EnemyShip[i].position - EnemyShip[i].speed;
                    if (index < 0) { SpeedOfShip[i]++; }
                }
            }
            stop = false;
            for (int i = 0; i < 9; i++)
            {
                if (SpeedOfShip[i] == 1)
                {
                    if (EnemyShip[i].position < min)
                    {
                        index = i;
                        min = EnemyShip[i].position;
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
                if (EnemyShip[i].InGame)
                {
                    count = 0;
                    index = EnemyShip[i].position - EnemyShip[i].speed;
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
                            if (EnemyShip[i].speed < min)
                            {
                                index = i;
                                min = EnemyShip[i].speed;
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
                if (EnemyShip[i].InGame && EnemyShip[i].speed != 1)
                {
                    count = 0;
                    index = EnemyShip[i].position - EnemyShip[i].speed - 1;
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
                    if (EnemyShip[i].speed < min)
                    {
                        index = i;
                        min = EnemyShip[i].speed;
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
                if (EnemyShip[i].InGame && ((EnemyShip[i].type == 1 && EnemyShip[i].speed != 4) || (EnemyShip[i].type == 2 && EnemyShip[i].speed != 6) && (EnemyShip[i].type == 3 && EnemyShip[i].speed != 8)))
                {
                    count = 0;
                    index = EnemyShip[i].position - EnemyShip[i].speed + 1;
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
                    if (EnemyShip[i].speed > max)
                    {
                        index = i;
                        max = EnemyShip[i].speed;
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
                if (EnemyShip[i].InGame)
                {
                    if (EnemyShip[i].speed > max)
                    {
                        index = i;
                        max = EnemyShip[i].speed;
                    }
                }
            }
            return index * 100;
        }
        int AlexMoveShip()
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
                    if (EnemyShip[index].InGame) { flag = false; }
                }
            }
            else { index = Jump(); }
            return index;
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
            for (int i = 0; i < 9; i++)
            {
                MyShip[i] = new Ship();
            }
            for (int i = 0; i < 9; i++)
            {
                EnemyShip [i] = new Ship();
            }

            int[] index = new int[6];
            short count;
            short dest = 6;
            double pi;
            double start_angle;
            double step;

            for (short i = 0; i < 6; i++)
            {
                position[i].jump = -1;
                index[i] = i;
            }

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

            const int Kof = 10;
            const double turn = 3.11;
            //Запоминание координат точек
            pi = 3.7;
            start_angle = 1.047;
            count = 0;
            for (int i = 1; i <= 6; i++)
            {
                step = start_angle;
                step = step / i;
                for (int j = 0; j < 6 * i; j++)
                {
                    x = PolarToX(pi, turn, Kof);
                    y = PolarToY(pi, turn, Kof);
                    position[count].pi = pi;
                    position[count].y = y;                    
                    position[count].x = x;
                    position[count].busy = false;
                    count++;

                    pi += step;
                }
            }

            //Запоминание координат пунктирных линий
            addres_dash[0]._external = 95;
            addres_dash[0]._internal = 0;

            for (int i = 1; i < 5; i++)
            {
                addres_dash[i]._external = addres_dash[i-1]._external - 1;
                addres_dash[i]._internal = addres_dash[i-1]._internal + dest * i;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void OnPosition_Click(object sender, EventArgs e)
        {
            Map();
        }

        private void Power_CheckedChanged(object sender, EventArgs e)
        {
            ShowSpeed.ReadOnly = false;
        }

        private void Go_CheckedChanged(object sender, EventArgs e)
        {
            ShowSpeed.ReadOnly = true;
        }

        private void Rules_Click(object sender, EventArgs e)
        {
            String Mes = "Космические корабли воюющих миров получили срочное\r\nсообщение из другой части галактики. Началась решающая битва.\r\n\r\nРезервные корабли, в которых нуждалась флотилия, поспешили на\r\nпомощь.\r\n\r\nЕдинственный для всех флотилий способ добраться туда — это\r\nпопасть на место сражения через гиперпространствемный тоннель,\r\nкоторый маходится в центре предательской чёрной дыры. Первая\r\nфлотилия, переправившая свои корабли в тоннель, выиграет битву.\r\n\r\nВы - командир межгалактической эскадрильи боевых космических\r\nкораблей, которые срочно нужно переправить через черную дыру,\r\nсоединяющую два конца нашей вселенной.\r\nВначале от вас требуется раставить свои корабли(Ваши корабли\r\nпоказываются зеленым цветом, а малеленькой цифрой\r\nобозмачается их номер) на позиции вас(у вас, памели упрьвления,\r\nони показываются как черные точки.\r\n\r\nНо противмик не дремлет, ему так же требуется переправить все\r\nсвои корабли через черную дыру из-за чего, в начале, ваши\r\nкорабли будут чередоваться: капитаны по очереди расставляют\r\n<вои корабли по внешней стороме спирали.\r\n\r\nУ вас в распоряжении есть три типа корабля. Нз приборной памели\r\nони отображаются как треугольник, квадрат и круг.\r\nУкаждого корабля есть скорость (большая цифра ма фигура),\r\nкоторая показывается на нем цифрой и может меняться.\r\nТреугольник: от 1 до 4\r\nКвадрат: от 1 до б\r\nКруг: от 1 до 8\r\nОт этой скорости зависит то, на сколько позиций может\r\nпродвимуться корабль.\r\n\r\nГлавное — умело пользоваться возможностью гиперперехода. Что\r\nэто такое? Количество ходов определяется скоростью корабля\r\nотображаемом ма нем, и когда корабль, сделав свой последний ход,\r\nпопадает ма занятое другим кораблем место, то он перемещается\r\nпо пунктирной линии на следующий внутренний виток орбиты.\r\n«Наступили» на корабль — ушли сразу ма круг ближе.\r\n\r\nЗа ход вы можете сделать одно из действий: передвимуть один\r\nкорабль или поменять у одного корабля скорость. Например, 3\r\nможно изменить нз 4 или наоборот: 4 на 3. Все зависит от вашей.\r\nцели и расположения кораблей соперника.\r\n\r\nКогда корабль окажется мз последнем витке орбиты, можно не\r\nснижать скорость, чтобы попасть в самое пекло чёрной дыры. Будет\r\nстрашно — закройте глаза. Все пилоты истребителей так делают.\r\nПобеждает капитан, отправивший шесть своих кораблей на другой\r\nконец вселенной.\r\n\r\nMay the Force be with you";
            DialogResult result = MessageBox.Show(Mes, "Правила", MessageBoxButtons.OK);

            groupShip.Visible = true;
            //groupAction.Visible = true;
            //ShowSpeed.Visible = true;
            //MoreSpeed.Visible = true;
            //LessSpeed.Visible = true;
            OnPosition.Visible = true;
            //ShipInCenterLabel.Visible = true;
            //YoursShipsCenterLabel.Visible = true;
            //EnemyShipsCenterLebel.Visible = true;
            //YoursShipsCenterTextbox.Visible = true;
            //EnemyShipsCenterTextbox.Visible = true;
            Map();
        }
    }
}
