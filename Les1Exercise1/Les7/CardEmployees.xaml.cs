using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Les7
{
    /// <summary>
    /// Логика взаимодействия для CardEmployees.xaml
    /// </summary>
    public partial class CardEmployees : Window
    {
        //public CardEmployees(int i, DataBase db)
        //{
        //    InitializeComponent();
        //    lblName.Content = db.EmployeesDB[i].Name;
        //    lblSuname.Content = db.EmployeesDB[i].Suname;
        //    lblAge.Content = db.EmployeesDB[i].Age;
        //    lblSalary.Content = db.EmployeesDB[i].Salary;
        //    lblPhoneNumber.Content = db.EmployeesDB[i].PhoneNumber;
        //    lblDepartmentID.Content = db.EmployeesDB[i].DepartmentID;
        //    foreach (var item in db.DepartmentDB)
        //    {
        //        cbDepartment.Items.Add(item);
        //    }
        //    cbDepartment.SelectedIndex = db.EmployeesDB[i].DepartmentID;

        //    this.btnSave.Click += delegate
        //    {
        //        db.EmployeesDB[i].Name = lblName.Content.ToString();
        //        db.EmployeesDB[i].Suname = lblSuname.Content.ToString();
        //        db.EmployeesDB[i].Age = Convert.ToInt32(lblAge.Content);
        //        db.EmployeesDB[i].Salary = Convert.ToInt32(lblSalary.Content);
        //        db.EmployeesDB[i].PhoneNumber = lblPhoneNumber.Content.ToString();
        //        db.EmployeesDB[i].DepartmentID = Convert.ToInt32(lblDepartmentID.Content);
        //        this.DialogResult = true;
        //        Close();
        //    };
        //}

        private void cbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // lblDepartmentID.Content = (cbDepartment.SelectedValue as Department).ID;
        }
        /// <summary>
        /// закрыть карту сотрудника.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
