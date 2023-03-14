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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //initialize player2's component
            if(Management.Turn == 1)
            {
                var deck2 = new int[10];
                Manipulate.Prep(deck2);
                Management.Deck2 = Manipulate.Init(deck2);
                Management.Hand2 = Manipulate.Draw(Management.Deck2);
            }

            //display players status
            label1.Text = Util.GetHp1().ToString();
            label2.Text = Util.GetHp2().ToString();

            //change text depending on current turn
            if(Management.Turn % 2 == 0)
            {
                label5.Text = "You are Attacker";
            }
            else
            {
                label5.Text = "You are Defender";
            }

            //check player2's hands
            var hands = 0;
            if(Management.btn21 == 1)
            {
                button1.Enabled = false;
                hands++;
            }
            if(Management.btn22 == 1)
            {
                button2.Enabled = false;
                hands++;
            }
            if (Management.btn23 == 1)
            {
                button3.Enabled = false;
                hands++;
            }
            if(hands == 3)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }

            //display the cards player2 have
            button1.Text = Management.Hand2[0].ToString();
            button2.Text = Management.Hand2[1].ToString();
            button3.Text = Management.Hand2[2].ToString();

            label4.ForeColor = Color.Red;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Management.btn21++;
            if (Management.Turn % 2 == 0)
            {
                Management.Atk = Management.Hand2[0];
            }
            else
            {
                Management.Def = Management.Hand2[0];
            }
            Visible = false;
            Form f4 = new Form4
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            f4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Management.btn22++;
            if (Management.Turn % 2 == 0)
            {
                Management.Atk = Management.Hand2[1];
            }
            else
            {
                Management.Def = Management.Hand2[1];
            }
            Visible = false;
            Form f4 = new Form4
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            f4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Management.btn23++;
            if (Management.Turn % 2 == 0)
            {
                Management.Atk = Management.Hand2[2];
            }
            else
            {
                Management.Def = Management.Hand2[2];
            }
            Visible = false;
            Form f4 = new Form4
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            f4.Show();
        }
    }
}
