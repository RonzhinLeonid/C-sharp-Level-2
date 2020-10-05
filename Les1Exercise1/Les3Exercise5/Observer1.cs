using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les3Exercise5
{
    class Observer1 // Наблюдатель 1
    {
        public void Do(object o)
        {
            Console.WriteLine("Первый. Принял, что объект {0} побежал", o);
        }
    }
}
