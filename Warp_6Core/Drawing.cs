using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing
{
    public class Display
    {
        public Display(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;

            bitmap = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            graph_bitmap = Graphics.FromImage(bitmap);
            graphics = pictureBox.CreateGraphics();
        }
        PictureBox pictureBox;
        public Graphics graphics;
        public Graphics graph_bitmap;
        public Bitmap bitmap;

        SolidBrush BrushGold = new SolidBrush(Color.Gold);
        SolidBrush BrushLimeGreen = new SolidBrush(Color.LimeGreen);
        SolidBrush BrushBlack = new SolidBrush(Color.Black);

        const short fontSmall = 12;//Шрифт меленькой цифры на фигуре
        const short fontBig = 25;//Шрифт большой цифры на фигуре
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
    }
}
