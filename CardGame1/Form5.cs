using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            //judge player's HP
            if(Util.GetHp1() == 0)
            {
                label1.Text = "Player2 Win!";
                goto End;
            }
            else if(Util.GetHp2() == 0)
            {
                label1.Text = "Player1 Win!";
                goto End;
            }

            //judge including '0'cards in the player's deck
            if (Management.Hand1[0] == 0 && Management.Hand2[0] == 0)
            {
                if (Util.GetHp1() > Util.GetHp2())
                {
                    label1.Text = "Player1 Win!";
                    goto End;
                }
                else
                {
                    label1.Text = "P;ayer2 Win!";
                    goto End;
                }
            }
            //judge witch player is higher HP
            if (Management.Hand1[0] == 0)
            {
                label1.Text = "Player1 Win!";
            }
            else if(Management.Hand2[0] == 0)
            {
                label1.Text = "Player2 Win!";
            }
            else
            {
                if(Management.Hand1[0] > Management.Hand2[0])
                {
                    label1.Text = "Player1 Win!";
                }
                else
                {
                    label1.Text = "Player2 WIn!";
                }
            }
        End:;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Visible = false;
            Form f1 = new Form1
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            f1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
