﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les2Exercise1
{
    class WorkerFixedRate : Worker
    {
        public WorkerFixedRate(string name, string surname, string patronymic, double rate) : base(name, surname, patronymic, rate)
        {
        }
        /// <summary>
        /// Переопределение метода расчета заработной платы сотрудника
        /// </summary>
        public override void AverageMonthlyWage()
        {
            wage = rate;
        }
    }
}
