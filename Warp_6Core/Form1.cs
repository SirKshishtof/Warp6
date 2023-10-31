using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
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
        short currentPoint = 126;
        short downwardShift = 20;
        bool flag = false;
        const double turn = 3.11;//Коффициент задающий поворот спирали и точек
        const double kof = 12;//Коффициент задающий ширину между витками спирали и точек
        const int fontSmall = 12;
        const int fontBig = 25;

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

        void WhiteRectangle(int NumOfShip, bool Enemy)
        {
            float radius = 70;
            float x = 50;
            float y = 155 + 80 * (NumOfShip);

            if (Enemy) { x = 1300; }

            SolidBrush brush = new SolidBrush(Color.White);

            graph_bitmap.FillRectangle(brush, x - (radius / 2), y - (radius / 2), radius, radius);
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
                DrawCircle(x, y + downwardShift, radius);
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



        void SetsShip(Ship Ship, int NumOfShip, SolidBrush Brush)
        {
            Ship.position = currentPoint;
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

            for (int i = 0; i < 4; i++)
            {
                myShip[i] = new Ship(1);
                myShip[i].speed = rnd.Next() % 4 + 1;

                enemy.ship[i] = new Ship(1);
                enemy.ship[i].speed = rnd.Next() % 4 + 1; ;
            }

            for (int i = 4; i < 7; i++)
            {
                myShip[i] = new Ship(2);
                myShip[i].speed = rnd.Next() % 6 + 1;

                enemy.ship[i] = new Ship(2);
                enemy.ship[i].speed = rnd.Next() % 6 + 1; ;
            }

            for (int i = 7; i < 9; i++)
            {
                myShip[i] = new Ship(3);
                myShip[i].speed = rnd.Next() % 8 + 1;

                enemy.ship[i] = new Ship(3);
                enemy.ship[i].speed = rnd.Next() % 8 + 1; ;
            }

            int[] index = new int[6] { 0, 1, 2, 3, 4, 5 };
            short count;
            short dest = 6;
            double x;
            double y;
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
                    x = PolarToX(pi);
                    y = PolarToY(pi);
                    position[count].pi = pi;
                    position[count].y = y + downwardShift;
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
                SetsShip(myShip[NumOfShip], NumOfShip, BrushLimeGreen);
                RadioButtonOff(NumOfShip);

                WhiteRectangle(NumOfShip, false);

                if (list.Count > 0)
                {
                    Thread.Sleep(1000);
                    NumOfShip = list[0];
                    SetsShip(enemy.ship[NumOfShip], NumOfShip, BrushGold);
                    WhiteRectangle(NumOfShip, true);
                    list.RemoveAt(0);
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
            ShowSpeed.ReadOnly = false;
        }

        private void Go_CheckedChanged(object sender, EventArgs e)
        {
            ShowSpeed.ReadOnly = true;
        }

        private void Rules_Click(object sender, EventArgs e)
        {

            String Mes = "Космические корабли воюющих миров получили срочное\r\nсообщение из другой части галактики. Началась решающая битва.\r\nРезервные корабли, в которых нуждалась флотилия, поспешили на\r\nпомощь.\r\nЕдинственный для всех флотилий способ добраться туда — это\r\nпопасть на место сражения через гиперпространственный тоннель,\r\nкоторый маходится в центре предательской чёрной дыры. Первая\r\nфлотилия, переправившая свои корабли в тоннель, выиграет битву.\r\n\r\nВы - командир межгалактической эскадрильи боевых космических\r\nкораблей, которые срочно нужно переправить через черную дыру,\r\nсоединяющую два конца нашей вселенной. Вначале от вас требуется\r\nраставить свои корабли(Ваши корабли показываются зеленым цветом,\r\nа малеленькой цифрой обозначается их номер) на позиции(у вас,\r\nпанели управления, они показываются как черные точки.\r\nНо противмик не дремлет, ему так же требуется переправить все\r\nсвои корабли через черную дыру из-за чего, в начале, ваши\r\nкорабли будут чередоваться: капитаны по очереди расставляют\r\nсвои корабли по внешней стороне спирали.\r\n\r\nУ вас в распоряжении есть три типа корабля. На приборной панели\r\nони отображаются как треугольник, квадрат и круг.\r\nУкаждого корабля есть скорость (большая цифра на фигуре),\r\nкоторая показывается на нем цифрой и может меняться.\r\nТреугольник: от 1 до 4\r\nКвадрат: от 1 до б\r\nКруг: от 1 до 8\r\nОт этой скорости зависит то, на сколько позиций может\r\nпродвимуться корабль.\r\nГлавное — умело пользоваться возможностью гиперперехода. Что\r\nэто такое? Количество ходов определяется скоростью корабля\r\nотображаемом ма нем, и когда корабль, сделав свой последний ход,\r\nпопадает на занятое другим кораблем место, то он перемещается\r\nпо пунктирной линии на следующий внутренний виток орбиты.\r\nЗа ход вы можете сделать одно из действий: передвимуть один\r\nкорабль или поменять у одного корабля скорость.\r\n\r\nКогда корабль окажется на последнем витке орбиты, можно не\r\nснижать скорость, чтобы попасть в самое пекло чёрной дыры. Будет\r\nстрашно — закройте глаза. Все пилоты истребителей так делают.\r\nПобеждает капитан, отправивший шесть своих кораблей на другой\r\nконец вселенной.\r\n\r\nMay the Force be with you";
            MessageBox.Show(Mes, "Правила");
            if (!groupShip.Visible)
            {
                groupShip.Visible = true;
                OnPosition.Visible = true;


                Map();
                currentPoint = 125;

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
                    Mes = "О нет! Противник прибыл раньше вас! Вы ходите вторым.";
                    int NumOfShip = list[0];
                    SetsShip(enemy.ship[NumOfShip], NumOfShip, BrushGold);
                    WhiteRectangle(NumOfShip, true);
                    list.RemoveAt(0);
                    flag = true;
                }
                else
                {
                    Mes = "Вам повезло! Противник еще не прибыл! Вы ходите первым.";
                }

                graphics.DrawImage(bitmap, 0, 0, pictureBox1.Size.Width, pictureBox1.Size.Height);
                MessageBox.Show(Mes, "Кто начинает");

            }
        }


        private void Start_Click(object sender, EventArgs e)
        {
            Start.Visible = false;
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

            if (flag)
            {
                textBox1.Text = "Ход противника";
                textBox1.BackColor = Color.Gold; flag = true;
            }


            //if (flag) { textBox1.Text = "Пык"; textBox1.BackColor = Color.LimeGreen; flag = false; }
            //else {  }

        }
    }
}
