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
    public partial class Form1 : Form
    {      
        public Form1()
        {
            InitializeComponent();  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Management.Turn = 0;
            Management.btn11 = 0;
            Management.btn12 = 0;
            Management.btn13 = 0;
            Management.btn21 = 0;
            Management.btn22 = 0;
            Management.btn23 = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Visible = false;
            Form2 f2 = new Form2
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    public static class Util
    {
        private static int player1;
        private static int player2;
        public static void SetHp1(int a)
        {
            player1 = a;
            if (a < 0)
            {
                player1 = 0;
            }
        }
        public static int GetHp1()
        {
            return player1;
        }
        public static void SetHp2(int a)
        {
            player2 = a;
            if (a < 0)
            {
                player2 = 0;
            }
        }
        public static int GetHp2()
        {
            return player2;
        }
    }
    public static class Management
    {
        public static Stack<int> Deck1 { get; set; }
        public static Stack<int> Deck2 { get; set; }

        public static int[] Hand1 { get; set; }
        public static int[] Hand2 { get; set; }

        public static int Atk { get; set; }
        public static int Def { get; set; }

        public static int Turn;

        public static int btn11;
        public static int btn12;
        public static int btn13;

        public static int btn21;
        public static int btn22;
        public static int btn23;
        public static void Increment()
        {
            Turn++;
        }
    }

    public static class Manipulate
    {
        public static int[] Prep(int[] a)
        {
            for(int i = 0; i < a.Length; i++)
            {
                a[i] = i;
            }
            return a;
        }
        //Suffle player's deck
        public static int[] Suffle(int[] a)
        {
            Random rand = new Random();
            int choiceIdx = 0;
            var copy = new int[a.Length];
            var cnt = 0;

            while (a.Length > 0)
            {
                choiceIdx = rand.Next(0, a.Length);
                copy[cnt] = a[choiceIdx];

                a = a.Where(x => x != a[choiceIdx]).ToArray();
                cnt++;
            }
            return copy;
        }

        //Initialize player deck
        public static Stack<int> Init(int[] a)
        {
            var x = new Stack<int>();

            a = Suffle(a);

            for (int i = 0; i < a.Length; i++)
            {
                x.Push(a[i]);
            }
            return x;
        }

        //Draw from 3cards in deck
        public static int[] Draw(Stack<int> a)
        {
            if(a.Count == 1)
            {
                var last = new int[1];
                last[0] = a.Pop();
                return last;
            }
            var hand = new int[3];
            for (int i = 0; i < hand.Length; i++)
            {
                hand[i] = a.Pop();
            }
            return hand;
        }
    }
}
