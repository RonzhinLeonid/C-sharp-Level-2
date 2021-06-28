using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les5Exercise
{
    public class Employee: INotifyPropertyChanged
    {
        private string name;
        private string suname;
        private int age;
        private int salary;
        private string phoneNumber;
        private int departmentID;

        public event PropertyChangedEventHandler PropertyChanged;
        public int ID { get; set; }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.name)));
            }
        }
        public string Suname
        {
            get { return suname; }
            set
            {
                suname = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.suname)));
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.age)));
            }
        }
        public int Salary
        {
            get { return salary; }
            set
            {
                salary = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.salary)));
            }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.phoneNumber)));
            }
        }
        public int DepartmentID
        {
            get { return departmentID; }
            set
            {
                departmentID = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.departmentID)));
            }
        }
        public Employee(int id, 
                        string name, 
                        string suname, 
                        int age, 
                        int salary,
                        string phoneNumber,
                        int departmentID)
        {
            ID = id;
            Name = name;
            Suname = suname;
            Age = age;
            Salary = salary;
            PhoneNumber = phoneNumber;
            DepartmentID = departmentID;
        }
    }
}
