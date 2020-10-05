using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les2Exercise1
{
    class Program
    {
        //Ронжин Л.
        //1. Построить три класса (базовый и 2 потомка), описывающих работников с почасовой оплатой (один из потомков) и
        //фиксированной оплатой (второй потомок):
        //a. Описать в базовом классе абстрактный метод для расчета среднемесячной заработной платы.
        //Для «повременщиков» формула для расчета такова: «среднемесячная заработная плата = 20.8 * 8 * почасовая ставка»; 
        //для работников  с фиксированной  оплатой: «среднемесячная заработная плата = фиксированная месячная оплата»; - готово
        //b. Создать на базе абстрактного класса массив сотрудников и заполнить его; - готово
        //c. * Реализовать интерфейсы для возможности сортировки массива, используя Array.Sort(); - готово
        //d. * Создать класс, содержащий массив сотрудников, и реализовать возможность вывода данных с использованием foreach.

        static void Main(string[] args)
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            int countStaffFexedRate = 10; // Кол-во сотрудников на фиксированной ставке
            int countStaffHourlyRate = 10; // Кол-во сотрудников на почасовой ставке
            Worker[] staffs = new Worker[countStaffFexedRate + countStaffHourlyRate];
            // Заполнение массива    
            for (int i = 0; i < countStaffFexedRate; i++)
                staffs[i] = new WorkerHourlyRate("name" + i, "surname" + i, "patronymic" + i, r.Next(90, 150));

            for (int i = countStaffFexedRate; i < countStaffFexedRate + countStaffHourlyRate; i++)
                staffs[i] = new WorkerFixedRate("name" + i, "surname" + i, "patronymic" + i, r.Next(15000, 25000));

            int n = 0;
            //
            foreach (var item in staffs)
            {
                item.AverageMonthlyWage();
                Console.WriteLine($"{++n} - {item.Wage}");
            }
            Array.Sort(staffs);
            n = 0;
            Console.WriteLine();
            Console.WriteLine("Сортировка по среднемесячной заработной плате:");
            foreach (var item in staffs)
            {
                Console.WriteLine($"{++n} - {item.Wage}");
            }
            Console.ReadKey();
        }
    }
}
