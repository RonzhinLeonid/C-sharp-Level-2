using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Les5Exercise
{
    class Department
    {
        int id;
        string name;
        string description;
        public int ID { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Description { set { description = value; } }

        public ObservableCollection<Department> Departments { get; set; }
        public Department()
        {
            Departments = new ObservableCollection<Department>();
        }
        /// <summary>
        /// Добавление нового дупартамента.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="name">Наименование департамента</param>
        /// <param name="description">Описание департамента</param>
        public void AddDepartment(int id, string name, string description)
        {
            var temp = new Department()
            {
                ID = id,
                Name = name,
                Description = description
            };
            Departments.Add(temp);
        }
        

     

    }
}
