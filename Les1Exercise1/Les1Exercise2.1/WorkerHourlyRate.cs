using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les1Exercise2_1
{
    class WorkerHourlyRate: Worker
    {
        public WorkerHourlyRate(string name, string surname, string patronymic, double rate) : base(name, surname, patronymic, rate)
        {
        }
        /// <summary>
        /// Переопределение метода расчета заработной платы сотрудника
        /// </summary>
        public override void AverageMonthlyWage()
        {
            wage = 20.8 * 8 * rate;
        }
    }
}
