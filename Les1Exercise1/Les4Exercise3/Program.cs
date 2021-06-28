using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les4Exercise3
{
    
    class Program
    {
        //Ронжин Л.
        //* Дан фрагмент программы:
        //а. Свернуть обращение к OrderBy с использованием лямбда-выражения =>.
        //b. * Развернуть обращение к OrderBy с использованием делегата.

        static int SortDictionary(KeyValuePair<string, int> pair)
        {
            return pair.Value;
        }

        static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
              {
                {"four",4 },
                {"two",2 },
                {"one",1 },
                {"three",3 },
              };
            Console.WriteLine("Исходный словарь");
            foreach (var pair in dict)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
            Console.WriteLine();
            Console.WriteLine("через delegate из методички");
            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            ConsoleWrite(d);
            Console.WriteLine();
            Console.WriteLine("u => u.Value");
            var c = dict.OrderBy(u => u.Value); 
            ConsoleWrite(c);

            Console.WriteLine();
            Console.WriteLine("from q in dict");
            var z = from q in dict
                    orderby q.Value
                    select q;
            ConsoleWrite(z);

            Console.WriteLine();
            Console.WriteLine("dict.OrderBy(SortDictionary)");
            var у = dict.OrderBy(SortDictionary);
            ConsoleWrite(у);
            Console.ReadKey();
        }

        private static void ConsoleWrite(IOrderedEnumerable<KeyValuePair<string, int>> у)
        {
            foreach (var pair in у)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
        }
    }
}
