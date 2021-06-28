using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Les5Exercise
{
    public class Department : INotifyPropertyChanged
    {
        int id;
        string name;
        string description;

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
        public string Description 
        {
            get { return description; }
            set
            { 
                description = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.description)));
            } 
        }
        public Department(int id, string name, string description)
        {
            ID = id;
            Name = name;
            Description = description;
        }
    }
}
