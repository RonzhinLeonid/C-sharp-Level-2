using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les1Exercise2
{
    class GameObjectException: Exception
    {
        public GameObjectException(string message) : base(message)
        {
        }
    }
}
