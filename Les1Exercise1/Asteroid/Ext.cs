using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    static public class Ext
    {
        /// <summary>
        /// Проверка списка астероидов все ли астероиды уничтожены
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        static public bool Check<T>(this List<T> values)
        {
            return values.All(val => val == null);
        }
    }
}
