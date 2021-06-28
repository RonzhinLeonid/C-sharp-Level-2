using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les5Exercise
{
    //циклы фор идут с конца т.к. при удалении элемента коллекция смещается и можно пропустить элемент коллекции
    public class DataBase
    {
        public ObservableCollection<Employee> EmployeesDB { get; set; }
        public ObservableCollection<Department> DepartmentDB { get; set; }

        Random rnd = new Random();

        public DataBase(int CountDepartment, int CountEmployee)
        {
            EmployeesDB = new ObservableCollection<Employee>();
            DepartmentDB = new ObservableCollection<Department>();
            DepartmentDB.Add(new Department(0, "Без департамента", "Сотрудники не расределенные по департаментам."));
            for (int i = 1; i <= CountDepartment; i++)
            {
                DepartmentDB.Add(new Department(i, "Департамент-" + i, "Описание-" + i));
            }

            for (int i = 1; i <= CountEmployee; i++)
            {
                EmployeesDB.Add(new Employee(i,
                                            "Имя-" + i,
                                            "Фамилия-" + i,
                                            rnd.Next(18, 65),
                                            rnd.Next(50000, 150000),
                                            rnd.Next(1000000, 9999999).ToString("000-00-00"),
                                            rnd.Next(1, CountDepartment + 1)));
            }
        }
        /// <summary>
        /// Удаление департамента и перенос всех сотрудников из него в департамент с индексом 0
        /// </summary>
        /// <param name="index">Индекс департамнента</param>
        public void DeleteDepartment(int index)
        {
            for (int i = EmployeesDB.Count - 1; i >= 0; i--)
            {
                if (EmployeesDB[i].DepartmentID == index)
                {
                    EmployeesDB[i].DepartmentID = 0;
                }
            }
            for (int i = DepartmentDB.Count - 1; i >= 0; i--)
                if (DepartmentDB[i].ID == index)
                {
                    DepartmentDB.RemoveAt(i);
                    break; // выход из цикла когда департамент был удален, и дальнейший перебор коллекции не требуется
                }
        }
    }
}
