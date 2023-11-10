using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warp_6;
using static System.Windows.Forms.DataFormats;
using static Warp_6.MainForm;

namespace Warp_6Core
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        public void GameExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы точно хотите выйти?", "Выход ли это?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();

            mainForm.NewGameButtonMainForm_Click(null, null);
        }

        private void DownloadGameButtom_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            //open_dialog.Filter; ;
            open_dialog.ShowDialog();
        }
    }
}





//mainForm.NewGameToolStripMenuItem.Enabled = true;
//mainForm.SaveGameToolStripMenuItem.Enabled = true;
//mainForm.GroupShip.Visible = true;
//mainForm.OnPosition.Visible = true;


//mainForm.Map();

//float xLeft = 50;
//float xRight = 1300;
//float y = 160;
//float Shift = 80;

//for (int i = 0; i < 4; i++)
//{
//    mainForm.DrawTriangle(mainForm.BrushLimeGreen, xLeft, y, i + 1, mainForm.myShip[i].speed);
//    mainForm.DrawTriangle(mainForm.BrushGold, xRight, y, i + 1, mainForm.enemy.ship[i].speed);
//    y += Shift;
//}

//for (int i = 4; i < 7; i++)
//{
//    mainForm.DrawRectangle(mainForm.BrushLimeGreen, xLeft, y, i + 1, mainForm.myShip[i].speed);
//    mainForm.DrawRectangle(mainForm.BrushGold, xRight, y, i + 1, mainForm.enemy.ship[i].speed);
//    y += Shift;
//}

//for (int i = 7; i < 9; i++)
//{
//    mainForm.DrawCircle(mainForm.BrushLimeGreen, xLeft, y, i + 1, mainForm.myShip[i].speed);
//    mainForm.DrawCircle(mainForm.BrushGold, xRight, y, i + 1, mainForm.enemy.ship[i].speed);
//    y += Shift;
//}

//string mes;
//if (mainForm.rnd.Next() % 2 != 0)
//{
//    mes = "О нет! Противник прибыл раньше вас! Вы ходите вторым.";
//    int NumOfShip = mainForm.enemy.list[0];
//    mainForm.SetsShip(ref mainForm.enemy.ship[NumOfShip], NumOfShip, ref mainForm.currentPoint, mainForm.BrushGold);
//    mainForm.WhiteRectangle(NumOfShip, true);
//    mainForm.enemy.list.RemoveAt(0);
//}
//else
//{
//    mes = "Вам повезло! Противник еще не прибыл! Вы ходите первым.";
//}
//mainForm.graphics.DrawImage(mainForm.bitmap, 0, 0, mainForm.pictureBox1.Size.Width, mainForm.pictureBox1.Size.Height);
//MessageBox.Show(mes, "Кто начинает");
