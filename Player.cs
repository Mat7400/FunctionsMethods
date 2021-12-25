using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5
{
    class Player
    {
        public Player()
        {
            //constructor
            GenerateName();
            health();
            //
        }
        public int Exp = 0;
        public int HealPoints = 15;
        public int Atack = 3;
        public int SuperAtack = 16;
        public string name = "knight";
        public override string ToString()
        {
            return "Name="+name+" Exp=" + Exp.ToString() + " Heal=" + HealPoints + " Atack=" + Atack + " Super Atack=" + SuperAtack;
        }
        public int maxDamage = 5;
        public int minDamage = 2;
        public int CountDamage()
        {
            Random rnd = new Random();
            return rnd.Next(minDamage, maxDamage);
        }
        public void health()
        {
            Random rndm = new Random();
            HealPoints = rndm.Next(15, 25);
        }
        public void dealdamage(int damage)
        {
            HealPoints = HealPoints - damage;
        }
        public bool isAlive()
        {
            //return true if alive
            return HealPoints > 0;
        }

        internal void GenerateName()
        {
            //utf-8 - 65536 любые языки
            //ascii - 128\256
            int length = 10;
            Random rnd = new Random();
            name = "";
            for (int i = 0; i < length; i++)
            {
                int numberCharacter = rnd.Next(1, 65536);
                //how to get character by number
                string c = Char.ConvertFromUtf32(numberCharacter);
                name += c;
            }
        }
    }
}
