using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les3Exercise5
{
    class Program
    {
        //Ронжин Л.
        //5.* Добавить в пример Lesson3 обобщенный делегат.
        //Сергей, как то очень легко для задания со звездочкой, или я не совсем верно понял задание.
        static void Main(string[] args)
        {
                Source s = new Source();
                Observer1 o1 = new Observer1();
                Observer2 o2 = new Observer2();
                MyDelegate<object> d1 = new MyDelegate<object>(o1.Do);
                s.Run += d1;
                s.Run += o2.Do;
                s.Start();
                s.Run -= d1;
                s.Start();
            Console.ReadKey();
        }
    }
}
