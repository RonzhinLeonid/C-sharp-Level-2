using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Les4Exercise2
{
    class Program
    {
    //Ронжин Л.
    //2. Дана коллекция List<T>.Требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:
    //  a. для целых чисел;
    //  b. * для обобщенной коллекции;
    //  c. ** используя Linq.

        static void Main(string[] args)
        {

            List<int> listInt = new List<int> { 20, 1, 4, 8, 9, 4, 4 };
            PrintList(listInt);
            //простое решение для списка целых чисел.
            Dictionary<int, int> result = listInt.GroupBy(x => x)
                                       .ToDictionary(x => x.Key, x => x.Count());
            Console.WriteLine($"Простое решение для списка целых чисел.");
            PrintDictionary(result);
            var resultInt = NumberOfOccurrences(listInt);
            PrintDictionary(resultInt);

            List<String> listString = new List<string>() { "ToString", "Format", "ToString", "ToString", "Format", "Format" };
            PrintList(listString);
            var resulString = NumberOfOccurrences(listString);
            PrintDictionary(resulString);
            Console.ReadKey();
        }
        /// <summary>
        /// Вывод списка в консоль
        /// </summary>
        /// <param name="listInt">Список</param>
        private static void PrintList<T>(List<T> listInt)
        {
            foreach (var item in listInt)
            {
                Console.Write($"{item}  ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Метод для обобщенного списка List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        private static Dictionary<T, int> NumberOfOccurrences<T>(List<T> list)
        {
           return list.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        }
        /// <summary>
        /// Вывод коллекци в консоль
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        private static void PrintDictionary<T>(Dictionary<T, int> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
            Console.WriteLine($"--------------------------------------------");
        }
    }
}
