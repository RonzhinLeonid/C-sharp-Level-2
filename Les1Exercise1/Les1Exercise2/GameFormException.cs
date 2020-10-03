using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les1Exercise2
{
    class GameFormException: Exception
    {
        public GameFormException()
        {
            Console.WriteLine(base.Message);
        }
    }
}
