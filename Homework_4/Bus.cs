using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Homework_4
{
    public class Bus : Car
    {
        public override int Speed { get; protected set; } = 20;
        protected override int MaxSpeed { get; } = 240;
        public override int SpeedInc { get; } = 20;
        public override int SpeedDec { get; } = 40;
        public Bus(string name) : base(name)
        {
            Name = name;
            Drive += Step;

        }
        public override void Step()
        {
            while (Game.GameIsOn)
            {
                Way += Speed;
                Console.WriteLine($"Bus {Name} current way: {Way}");
                Random rnd = new Random(DateTime.Now.Millisecond);
                int chance = rnd.Next(2);
                switch (chance)
                {
                    case 0:
                        Acceleration();
                        Console.WriteLine($"Bus {Name} performs acceleration");
                        break;
                    case 1:
                        Deceleration();
                        Console.WriteLine($"Bus {Name} performs deceleration");
                        break;
                    default:
                        break;
                }
                if (Way >= Game.Finish)
                {
                    Game.CallEvent(this, new EndGameEventArgs(Name));
                }
                Thread.Sleep(350);
            }
        }


       
    }
}
