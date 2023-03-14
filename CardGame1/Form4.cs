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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        //check both players have chosen same cards
        public static bool IsDraw { get; set; }

        private void Form4_Load(object sender, EventArgs e)
        {

            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            button2.Visible = false;

            //change text depending on current turn
            if(Management.Turn % 2 == 0)
            {
                label8.Text = "Player2";
                label9.Text = "Player1";
            }

            label3.Text = Management.Atk.ToString();
            label4.Text = Management.Def.ToString();

            //check which player is higher number
            if(Management.Atk > Management.Def)
            {
                label5.ForeColor = Color.Red;
                label5.Text = "Win";

                label6.ForeColor = Color.Blue;
                label6.Text = "Lose";
                IsDraw = false;
                var damage = Management.Atk - Management.Def;
                if (Management.Turn % 2 == 0)
                {
                    Util.SetHp1(Util.GetHp1() - damage);
                }
                else
                {
                    Util.SetHp2(Util.GetHp2() - damage);
                }
            }
            else if(Management.Atk == Management.Def)
            {
                IsDraw = true;
            }
            else
            {
                label5.ForeColor = Color.Blue;
                label5.Text = "Lose";

                label6.ForeColor = Color.Red;
                label6.Text = "Win";
                IsDraw = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(IsDraw == false)
            {
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
            }
            else
            {
                label3.Visible = true;
                label4.Visible = true;
                label7.Visible = true;
            }
            button1.Visible = false;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Management.Atk = 0;
            Management.Def = 0;
            Visible = false;

            Management.Increment();
            Form2 f2 = new Form2();
            f2.StartPosition = FormStartPosition.CenterScreen;
            f2.Show();
        }
    }
}
