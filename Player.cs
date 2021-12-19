using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5
{
    class Player
    {
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
        public int DoAttack()
        {
            Random rnd = new Random();
            return rnd.Next(minDamage, maxDamage);
        }
        public bool isAlive()
        {
            //return true if alive
            return HealPoints > 0;
        }
    }
}
