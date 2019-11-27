using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace Homework_4
{
    public class RacingCar : Car
    {
        public override int Speed { get; protected set; } = 30;
        protected override int MaxSpeed { get; } = 500;
        public override int SpeedInc { get; } = 80;
        public override int SpeedDec { get; } = 20;
        

        public RacingCar(string name) : base(name)
        {
            Name = name;
            Drive += Step;

        }

        public override void Step()
        {
            while (Game.GameIsOn)
            {
                Way += Speed;
                Console.WriteLine($"RacingCar {Name} current way: {Way}");
                Random rnd = new Random(DateTime.Now.Millisecond);
                int chance = rnd.Next(4);
                switch (chance)
                {
                    case 0:
                        break;
                    case 1:
                        Deceleration();
                        Console.WriteLine($"RacingCar {Name} performs deceleration");
                        break;
                    default:
                        Acceleration();
                        Console.WriteLine($"RacingCar {Name} performs acceleration");
                        break;
                }
                if (Way >= Game.Finish)
                {
                    Game.CallEvent(this, new EndGameEventArgs(Name));
                }
                Thread.Sleep(200);
            }
        }

        
    }
}
