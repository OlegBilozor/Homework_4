using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace Homework_4
{
    public class Truck : Car
    {
        public override int Speed { get; protected set; } = 10;
        protected override int MaxSpeed { get; } = 250;
        public override int SpeedInc { get; } = 30;
        public override int SpeedDec { get; } = 35;
        public Truck(string name) : base(name)
        {
            Name = name;
            Drive += Step;

        }
        public override void Step()
        {
            while (Game.GameIsOn)
            {
                Way += Speed;
                Console.WriteLine($"Truck {Name} current way: {Way}");
                Random rnd = new Random(DateTime.Now.Millisecond);
                int chance = rnd.Next(4);
                switch (chance)
                {
                    case 0:
                        break;
                    case 1:
                        Acceleration();
                        Console.WriteLine($"Truck {Name} performs acceleration");
                        break;
                    default:
                        Deceleration();
                        Console.WriteLine($"Truck {Name} performs deceleration");
                        break;
                }
                if (Way >= Game.Finish)
                {
                    Game.CallEvent(this, new EndGameEventArgs(Name));
                }
                Thread.Sleep(400);
            }
        }

        
    }
}
