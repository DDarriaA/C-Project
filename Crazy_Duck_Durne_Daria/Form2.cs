using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crazy_Duck_Durne_Daria
{
    public partial class Form2 : Form
    {
        #region .. Double Buffered function ..
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }

        #endregion

        #region .. code for Flickering ..

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        #endregion

        public Form2()
        {
            InitializeComponent();
            SetDoubleBuffered(this);
        }
        bool st, dr, sus, jos;
        int viteza = 5;
        int vieti = 5;
        int time = 60;
        int vitezaa;
        int pozitie = 1;

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                time = time - 1;
                timp.Text = Convert.ToString(time);
            }
            else
            {
                timer2.Enabled = false;
                this.Hide();
                Game_over f = new Game_over();
                f.ShowDialog();
            }
        }

        private void player_Click(object sender, EventArgs e)
        {

        }

        private void door_Click(object sender, EventArgs e)
        {
           
        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                st = false;
            if (e.KeyCode == Keys.Right)
                dr = false;
            if (e.KeyCode == Keys.Up)
                sus = false;
            if (e.KeyCode == Keys.Down)
                jos = false;
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                st = true;
            if (e.KeyCode == Keys.Right)
                dr = true;
            if (e.KeyCode == Keys.Up)
                sus = true;
            if (e.KeyCode == Keys.Down)
                jos = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (player.Bounds.IntersectsWith(door.Bounds))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                this.Hide();
                Form3 f = new Form3();
                f.ShowDialog();
            }
            if (st == true)
            {
                if (pozitie == 1)
                {
                    player.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    pozitie = 0;
                }
                foreach (Control x in this.Controls)
                {
                    if ((string)x.Tag == "ziduri")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            vieti--;
                            st = false;
                            player.Left = player.Left + viteza + 6;
                        }
                    }
                }
                player.Left = player.Left - viteza;
            }
            if (dr == true)
            {
                if (pozitie == 0)
                {
                    player.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    pozitie = 1;
                }
                foreach (Control x in this.Controls)
                {
                    if ((string)x.Tag == "ziduri")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            vieti--;
                            dr = false;
                            player.Left = player.Left - viteza - 6;
                        }
                    }
                }
                player.Left = player.Left + viteza;
            }
            if (sus == true)
            {
                foreach (Control x in this.Controls)
                {
                    if ((string)x.Tag == "ziduri")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            vieti--;
                            sus = false;
                            player.Top = player.Top + viteza + 6;
                        }
                    }
                }
                player.Top = player.Top - viteza;
            }
            if (jos == true)
            {
                foreach (Control x in this.Controls)
                {
                    if ((string)x.Tag == "ziduri")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            vieti--;
                            jos = false;
                            player.Top = player.Top - viteza - 6;
                        }
                    }
                }
                player.Top = player.Top + viteza;
            }
            if (p1.Top <= this.Height)
            {
                Random va = new Random();
                vitezaa = va.Next(5, 10);
                p1.Top = p1.Top + vitezaa;
            }
            else
            {
                Random nr = new Random();
                int xa = nr.Next(1, 850);//coordonata pe orizontala a asteroidului
                int ya = nr.Next(10, 500);//coordonata pe verticala
                p1.Top = -ya;
                p1.Left = xa;
            }
            if (player.Bounds.IntersectsWith(p1.Bounds))
            {
                Random nr = new Random();
                int xa = nr.Next(1, 850);//coordonata pe orizontala a asteroidului
                int ya = nr.Next(10, 500);//coordonata pe verticala
                p1.Top = -ya;
                p1.Left = xa;

            }
            /**if (p2.Top <= this.Height)
            {
                Random va = new Random();
                vitezaa = va.Next(5, 10);
                p2.Top = p2.Top + vitezaa;
            }
            else
            {
                Random nr = new Random();
                int xa = nr.Next(1, 850);//coordonata pe orizontala a asteroidului
                int ya = nr.Next(10, 500);//coordonata pe verticala
                p2.Top = -ya;
                p2.Left = xa;
            }
            if (player.Bounds.IntersectsWith(p1.Bounds))
            {
                Random nr = new Random();
                int xa = nr.Next(1, 850);//coordonata pe orizontala a asteroidului
                int ya = nr.Next(10, 500);//coordonata pe verticala
                p2.Top = -ya;
                p2.Left = xa;

            }**/
            if (vieti == 4)
                i5.Visible = false;
            if (vieti == 3)
                i4.Visible = false;
            if (vieti == 2)
                i3.Visible = false;
            if (vieti == 1)
                i2.Visible = false;
            if (vieti == 0)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                this.Hide();
                Game_over f = new Game_over();
                f.ShowDialog();
            }
        }
    }
}
