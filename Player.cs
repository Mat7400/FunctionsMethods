using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp5
{
    class Player
    {
        public Player()
        {
            Random rondom = new Random();
            minDamage = rondom.Next(1,5);
            maxDamage = rondom.Next(8, 12);
            //constructor
            GenerateName();
            health();
            //
            dealedDamage.Clear();
        }
        public int Exp = 0;
        public int HealPoints = 15;
        public int Atack = 3;
        public int SuperAtack = 16;
        public string name = "knight";
        //
        // Этот делегат работает в сочетании с событиями Player.
        // EventArgs - специальный классс от микрософт для работы с событиями
        public delegate void PlayerHandler(string msg, EventArgs args);
        // Playerможет отправлять следующие события:
        public event PlayerHandler DamagedEvent;
        public override string ToString()
        {
            return "Name="+name+" Exp=" + Exp.ToString() + " Heal=" + HealPoints + " Atack=" + Atack + " Super Atack=" + SuperAtack;
        }
        public int maxDamage = 10;
        public int minDamage = 1;
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
        //dealed damage array (list)
        //DZ
        //03.01.2021 другие коллекции - очередь Queue, стек Stack и Словарь (dictonary)
        public List<int> dealedDamage = new List<int>();
        public void dealdamage(int damage)
        {
            HealPoints = HealPoints - damage;
            //store damage in array
            //fixed array
            //string[] lkka = new string[10];
            //dynamic array
            //List<int> lst = new List<int>();
            dealedDamage.Add(damage);
            //trigger event
            //проверка на нулл чтобы понять есть ли подписчики события
            if (DamagedEvent!=null)
                DamagedEvent("damaged =" + damage.ToString(), new EventArgs() );
            //2 способ - ?.
            //DamagedEvent?.Invoke("second way");
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
                //more than 55000-exception
                int numberCharacter = rnd.Next(1, 55000);
                //how to get character by number
                //exception catch
                try
                {
                    string c = Char.ConvertFromUtf32(numberCharacter);
                    name += c;
                }
                catch (Exception ex)
                {
                    //ex - data from exception
                    //MessageBox.Show(ex.Message+" source="+ ex.Source+" stack="+ex.StackTrace );
                    //log to file
                    //using - синтаксический сахар чтобы не писать много строк про открытие и закрытие файла
                    //по сути open close для файла вызываются неявно
                    using (StreamWriter sw = File.AppendText("log.txt"))
                    {
                        sw.WriteLine(ex.Message + " source=" + ex.Source + " stack=" + ex.StackTrace+
                            " numberCH="+ numberCharacter);
                    }
                }
            }
        }

        internal string dealedDamagePrint()
        {
            string result="";
            //for(int counter = 0;counter < dealedDamage.Count; counter++)
            //{

            //}
            //Foreach cycle
            foreach (int item in dealedDamage)
            {
                result += (item.ToString());
                result += " ";
            }

            return result;
        }
    }
}
