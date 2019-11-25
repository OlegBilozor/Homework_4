using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4
{
    public class EndGameEventArgs : EventArgs
    {
        public string Winner { get; }

        public EndGameEventArgs(string nameWinner)
        {
            Winner = nameWinner;
        }
    }
}
