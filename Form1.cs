using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            int dmg1 = mainHero.CountDamage();
            Thread.Sleep(100);
            int dmg2 = monsterl.CountDamage();
            //damage to textbox
            mainHero.dealdamage(dmg2);
            monsterl.dealdamage(dmg1);
             
            richTextBox1.Text += "\n hero attack monster " + dmg1.ToString();
            richTextBox1.Text += "\n monster attack hero " + dmg2.ToString();
            if (mainHero.isAlive() == false && monsterl.isAlive() == false)
            {
                //listbox - массив dealedDamage вывести

                MessageBox.Show("TIE play");
                MessageBox.Show(mainHero.dealedDamagePrint() );
            }
            else
            {
                if (mainHero.isAlive() == false)
                {

                    MessageBox.Show("player lose");
                    MessageBox.Show(mainHero.dealedDamagePrint());

                }
                if (monsterl.isAlive() == false)
                {

                    MessageBox.Show("WIN");
                    MessageBox.Show(mainHero.dealedDamagePrint());

                }
            }
        }
        void init()
        {
            richTextBox1.Text = "";
            mainHero = new Player();
            //mainHero.GenerateName();
            //mainHero.health();
            //sleep 100ms to initiate new random
            Thread.Sleep(100);
            monsterl = new Player();
            //monsterl.GenerateName();
            //monsterl.health();
            //healpoint to textbox
            richTextBox1.Text += "\n hero name="+mainHero.name+" health " + mainHero.HealPoints.ToString();
            richTextBox1.Text += "\n monster =" + monsterl.name + "health " + monsterl.HealPoints.ToString();
            //subscribe to event
            mainHero.DamagedEvent += EventHandler;
            
        }
        //event handler (обработчик)
        public void EventHandler(string message, EventArgs e)
        {

            MessageBox.Show("event fired, message="+message+" args="+e.ToString());
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            init();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

             
        }

        private void button5_Click(object sender, EventArgs e)
        {
            init();
            
        }
    }
}
