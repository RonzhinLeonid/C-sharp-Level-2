using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les2Exercise1
{
    abstract class Worker: IComparable
    {
        protected string name;
        protected string surname;
        protected string patronymic;
        protected double rate;
        protected double wage;

        public double Wage { get { return wage; } }

        public Worker(string name, string surname, string patronymic, double rate)
        {
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
            this.rate = rate;
        }
        /// <summary>
        /// Переопределение метода сортировки для CompareTo для класса Worker
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public int CompareTo(object o)
        {
            Worker p = o as Worker;
            if (p != null)
                return this.wage.CompareTo(p.wage);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
        /// <summary>
        /// Абстрактный метод расчета среднемесячной заработной платы сотрудника
        /// </summary>
        public abstract void AverageMonthlyWage();
    }
}
