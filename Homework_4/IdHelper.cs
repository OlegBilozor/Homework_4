using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4
{
    public static class IdHelper
    {
        private static int _idCounter;
        public static int GetNextId()
        {
            return ++_idCounter;
        }
    }
}
