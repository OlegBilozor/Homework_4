using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace Homework_4
{
    public abstract class Car
    {
        public string Name { get; set; }
        public abstract int Speed { get; protected set; }
        protected abstract int MaxSpeed { get;  }
        public virtual int SpeedInc { get; }
        public virtual int SpeedDec { get; }
        public int Way { get; protected set; }
        public event Action Drive;
        public abstract void Step();

        protected Car(string name)
        {
            
        }

        public void Acceleration()
        {
            Random rnd= new Random(DateTime.Now.Millisecond);
            int chance = rnd.Next(3);
            if (chance == 2 && Speed < MaxSpeed)
            {
                if (Speed + SpeedInc < MaxSpeed)
                    Speed += SpeedInc;
                else
                    Speed = MaxSpeed;
            }
        }

        public void Deceleration()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            int chance = rnd.Next(3);
            if (chance == 2 && Speed > 0)
            {
                if (Speed - SpeedDec >= 0)
                    Speed -= SpeedDec;
                else
                    Speed = 0;
            }
        }
    }
}
