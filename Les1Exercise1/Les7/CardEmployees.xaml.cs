using System;
using System.Collections.Generic;
using System.Data;
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
        public DataRow resultRow { get; set; }
        public CardEmployees(DataRow dataRow, DataTable dtDep)
        {
            InitializeComponent();
            resultRow = dataRow;
            tbName.Text = resultRow["Name"].ToString();
            tbSuname.Text = resultRow["Suname"].ToString();
            tbAge.Text = resultRow["Age"].ToString();
            tbSalary.Text = resultRow["Salary"].ToString();
            tbPhoneNumber.Text = resultRow["PhoneNumber"].ToString();
            cbDepartment.ItemsSource = dtDep.DefaultView;
            
             var index = from row in dtDep.AsEnumerable()
                         let r = row.Field<int>("Id")
                         where r == Convert.ToInt32(resultRow["DepartmentID"])
                         select dtDep.Rows.IndexOf(row);

            cbDepartment.SelectedIndex = index.ToArray()[0];
        }

        private void cbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView vrow = (DataRowView)cbDepartment.SelectedItem;
            DataRow row = vrow.Row;
            lblDepartmentID.Content = row[0];
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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            resultRow["Name"] = lblName.Content;
            resultRow["Suname"] = lblSuname.Content;
            resultRow["Age"] = Convert.ToInt32(lblAge.Content);
            resultRow["Salary"] = Convert.ToInt32(lblSalary.Content);
            resultRow["PhoneNumber"] = lblPhoneNumber.Content;
            resultRow["DepartmentID"] = Convert.ToInt32(lblDepartmentID.Content);
            this.DialogResult = true;
        }
    }
}
