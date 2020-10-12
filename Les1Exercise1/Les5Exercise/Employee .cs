using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les5Exercise
{
    class Employee
    {
        //private string name;
        //private string suname;
        //private string department;

        public int ID { get; set; }
        public string Name { get; set; }
        public string Suname { get; set; }
        public string Age { get; set; }
        public string Salary { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int DepartmentID { get; set; }

        public ObservableCollection<Employee> Staff { get; set; }

        public Employee()
        {
            Staff = new ObservableCollection<Employee>();
        }

        /// <summary>
        /// Добавление нового сотрудника.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="name">имя</param>
        /// <param name="suname">фамилия</param>
        /// <param name="departmentID">id департамента</param>
        public void AddEmployee(int id , string name, string suname, int departmentID)
        {
            var temp = new Employee()
            {
                ID = id,
                Name = name,
                Suname = suname,
                DepartmentID = departmentID
            };
            Staff.Add(temp);
        }

        /// <summary>
        /// Замена департамент у сотрудника 
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="suname">Фамилия</param>
        /// <param name="newDepartment">Новый департамент</param>
        public void ChangeDepartment(string name, string suname, int newDepartment)
        {
            Staff.Single(x => x.Name == name && x.Suname == suname).DepartmentID = newDepartment;
        }
    }
}
