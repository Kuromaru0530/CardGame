using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Red;

            //initialize player components
            if (Management.Turn == 0)
            {
                //set player's HP
                Util.SetHp1(15);
                Util.SetHp2(15);

                //prepare player1 deck and hands
                var deck1 = new int[10];

                Manipulate.Prep(deck1);
                Management.Deck1 = Manipulate.Init(deck1);
                Management.Hand1 = Manipulate.Draw(Management.Deck1);

                button2.Text = Management.Hand1[0].ToString();
                button3.Text = Management.Hand1[1].ToString();
                button4.Text = Management.Hand1[2].ToString();

                Management.Increment();
            }

            //check players HP
            if(Util.GetHp1() == 0)
            {
                
                Form f5 = new Form5
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                f5.ShowDialog();
            }
            else if(Util.GetHp2() == 0)
            {
                
                Form f5 = new Form5
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                f5.ShowDialog();
            }

            //display players HP
            label1.Text = Util.GetHp1().ToString();
            label2.Text = Util.GetHp2().ToString();

            //change texts depending on current turn
            if(Management.Turn % 2 == 0)
            {
                label5.Text = "You are Defender";
            }
            else
            {
                label5.Text = "You are Attacker";
            }

            //check how many cards you have now and which cards you have chosen in past turn
            var hands = 0;
            if(Management.btn11 == 1)
            {
                button2.Enabled = false;
                hands++;
            }
            if(Management.btn12 == 1)
            {
                button3.Enabled = false;
                hands++;
            }
            if(Management.btn13 == 1)
            {
                button4.Enabled = false;
                hands++;
            }

            //if you don't have any cards left, draw new cards from deck 
            if(hands == 3)
            {
                Management.Hand1 = Manipulate.Draw(Management.Deck1);
                Management.Hand2 = Manipulate.Draw(Management.Deck2);

                //if you can't draw cards enough, check winner
                if(Management.Hand1.Length == 1)
                {
                    Close();
                    Form f5 = new Form5
                    {
                        StartPosition = FormStartPosition.CenterParent
                    };
                    f5.ShowDialog();
                }
                Management.btn11 = 0;
                Management.btn12 = 0;
                Management.btn13 = 0;
                Management.btn21 = 0;
                Management.btn22 = 0;
                Management.btn23 = 0;

                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }

            if(Management.Hand1.Length == 3)
            {
                button2.Text = Management.Hand1[0].ToString();
                button3.Text = Management.Hand1[1].ToString();
                button4.Text = Management.Hand1[2].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Management.btn11++;
            if(Management.Turn % 2 == 0)
            {
                Management.Def = Management.Hand1[0];
            }
            else
            {
                Management.Atk = Management.Hand1[0];
            }
            
            Visible = false;
            Form3 f3 = new Form3();
            f3.StartPosition = FormStartPosition.CenterScreen;
            f3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Management.btn12++;
            if (Management.Turn % 2 == 0)
            {
                Management.Def = Management.Hand1[1];
            }
            else
            {
                Management.Atk = Management.Hand1[1];
            }
            Visible = false;
            Form3 f3 = new Form3();
            f3.StartPosition = FormStartPosition.CenterScreen;
            f3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Management.btn13++;
            if (Management.Turn % 2 == 0)
            {
                Management.Def = Management.Hand1[2];
            }
            else
            {
                Management.Atk = Management.Hand1[2];
            }
            Visible = false;
            Form3 f3 = new Form3();
            f3.StartPosition = FormStartPosition.CenterScreen;
            f3.Show();
        }
    }
}
