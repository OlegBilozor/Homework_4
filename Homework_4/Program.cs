using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace Homework_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Game myGame=new Game();
            Thread[] threads=new Thread[Game.Cars.Count];
            for (int i = 0; i < Game.Cars.Count;i++)
            {
                threads[i]=new Thread(Game.Cars[i].Step);
                threads[i].Start();
            }
            Console.ReadLine();
        }
    }
}
