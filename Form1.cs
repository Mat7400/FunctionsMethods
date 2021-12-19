using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string Function(string a1, string b1)
        {
            //a1 b1 - внутри
            //переданная строка меняется!
            a1 = "changes";

            return a1 + b1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string a = "aaa";
         
            string b = "bbb";
            string c =Function(a, b);

            MessageBox.Show(c);

            
        }

        private int FunctionInt(int ai, int bi)
        {
            int ans = ai + bi;
            ai = 1000;
            return ans;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ai = 1;

            int bi = 2;
            int ci = FunctionInt(ai, bi);
            MessageBox.Show("a1=" + ai.ToString() + " answer=" + ci.ToString());
        }
        private void changePlayer(Player inPlayer)
        {
            inPlayer.name = "newname";
            inPlayer.Exp++;
            inPlayer.HealPoints--;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //changes for class
            Player p1 = new Player();
            changePlayer(p1);
            MessageBox.Show(p1.ToString());
        }
        Player mainHero;
        Player monsterl;
        private void button4_Click(object sender, EventArgs e)
        {
            int dmg1 = mainHero.DoAttack();
            int dmg2 = monsterl.DoAttack();
            //damage to textbox
            mainHero.HealPoints -= dmg2;
            monsterl.HealPoints -= dmg1;
             
            richTextBox1.Text += " hero attack monster " + dmg1.ToString();
            richTextBox1.Text += " monster attack hero " + dmg2.ToString();
            if (mainHero.isAlive() == false)
            {
                MessageBox.Show("player lose");
                init();
            }
            if (monsterl.isAlive() == false)
            {
                MessageBox.Show("WIN");
                init();
            }
        }
        void init()
        {
            mainHero = new Player();
            Random end = new Random();
            mainHero.HealPoints = end.Next(15, 20);

            monsterl = new Player();
            monsterl.HealPoints = end.Next(15, 20);
            //healpoint to textbox
            monsterl.name = "ыртышил";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            init();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

             
        }
    }
}
