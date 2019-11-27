using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace Homework_4
{
    public class CasualCar : Car
    {
        public override int Speed { get; protected set; } = 20;
        protected override int MaxSpeed { get; } = 250;
        public override int SpeedInc { get; } = 30;
        public override int SpeedDec { get; }= 30;
        

        public CasualCar(string name) : base(name)
        {
            Name = name;
            Drive += Step;
        }

        public override void Step()
        {
            while (Game.GameIsOn)
            {
                Way += Speed;
                Console.WriteLine($"CasualCar {Name} current way: {Way}");
                Random rnd = new Random(DateTime.Now.Millisecond);
                int chance = rnd.Next(3);
                switch (chance)
                {
                    case 0:
                        Acceleration();
                        Console.WriteLine($"CasualCar {Name} performs acceleration");
                        break;
                    case 1:
                        Deceleration();
                        Console.WriteLine($"CasualCar {Name} performs deceleration");
                        break;
                    default:
                        break;
                }

                if (Way >= Game.Finish)
                {
                    Game.CallEvent(this, new EndGameEventArgs(Name));
                }
                Thread.Sleep(300);
            }

        }
    }
}
