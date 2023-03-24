using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;


namespace Warp_6
{
    struct Position
    {
        public double pi;
        public double x;
        public double y;
        public int jump;
        public bool busy;
    }

    struct Addres_Dash
    {
        public int _external;
        public int _internal;
    }

    struct Ship
    {
        int position;
        int type;
        int power;


    }

    public partial class Form1 : Form
    {
        Graphics graphics;
        Graphics graph_bitmap;
        Bitmap bitmap;
        Position[] position = new Position[126];
        Addres_Dash[] addres_dash = new Addres_Dash[30];
        short i = 126;


        SolidBrush BrushBlack = new SolidBrush(Color.Black);
        SolidBrush BrushGold = new SolidBrush(Color.Gold);
        SolidBrush BrushLimeGreen = new SolidBrush(Color.LimeGreen);
        Pen BlackPen = new Pen(Color.Black, 3);
        

        const int k = 10;
        const double turn = 3.11;

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
        void DrawTriangle(SolidBrush brush, int index)
        {
            String drawString = "3";
            Font drawFont = new Font("Arial", 25);
            float radius = 30;
            float x = (float)position[index].x;
            float y = (float)position[index].y;
            float Shift = (float)Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(radius / 2, 2));
            PointF TopPoint = new PointF(x, y - radius);
            PointF BottomLeftPoint = new PointF(x - Shift, y + (radius / 2));
            PointF BottomRightPoint = new PointF(x + Shift, y + (radius / 2));
            PointF[] curvePoints = { TopPoint, BottomLeftPoint, BottomRightPoint };
            graph_bitmap.FillPolygon(brush, curvePoints);
            graph_bitmap.DrawString(drawString, drawFont, BrushBlack, x - (radius / 3)-4, y - (radius / 2)-4);
            graphics.DrawImage(bitmap, 0, 0, pictureBox1.Size.Width, pictureBox1.Size.Height);
        }
        
        void DrawRectangle(SolidBrush brush, int index)
        {
            String drawString = "3";
            Font drawFont = new Font("Arial", 25);
            float radius = 40;
            float x = (float)position[index].x;
            float y = (float)position[index].y;
            graph_bitmap.FillRectangle(brush, x - (radius / 2), y - (radius / 2), radius, radius);
            graph_bitmap.DrawString(drawString, drawFont, BrushBlack, x - (radius / 3) - 1, y - (radius / 2) + 2);
            graphics.DrawImage(bitmap, 0, 0, pictureBox1.Size.Width, pictureBox1.Size.Height);
        }
        void DrawCircle(SolidBrush brush, int index)
        {
            String drawString = "3";
            Font drawFont = new Font("Arial", 25);
            float radius = 40;
            float x = (float)position[index].x;
            float y = (float)position[index].y;
            graph_bitmap.FillEllipse(brush, x - (radius / 2), y - (radius / 2), radius, radius);
            graph_bitmap.DrawString(drawString, drawFont, BrushBlack, x - (radius / 3)-1, y - (radius / 2)+2);
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
            double pi = 0;
            float radius;
            radius = 40;
            

            graph_bitmap.Clear(Color.White);
            
            BlackPen.DashStyle = DashStyle.Dash;

            DrawCircle(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2 - 25, radius);

            radius = 4;
            //Отрисовывание сприрали 
            for (int i = 0; i < 41400; i++)
            {
                x = PolarToX(pi, turn, k);
                y = PolarToY(pi, turn, k);
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


        public Form1()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            Map();
            if (i != 3) { i--; }
            else { i = 125; };
            DrawTriangle(BrushLimeGreen, i);
            DrawRectangle(BrushLimeGreen, i - 1);
            DrawCircle(BrushLimeGreen, i - 2);
            DrawCircle(BrushGold, i - 3);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            graph_bitmap = Graphics.FromImage(bitmap);
            graphics = pictureBox1.CreateGraphics();
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
                    x = PolarToX(pi, turn, k);
                    y = PolarToY(pi, turn, k);
                    position[count].pi = pi;
                    position[count].x = x;
                    position[count].y = y;
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

        private void Power_CheckedChanged(object sender, EventArgs e)
        {
            ShowPower.ReadOnly = false;
        }

        private void Go_CheckedChanged(object sender, EventArgs e)
        {
            ShowPower.ReadOnly = true;
        }
    }
}
