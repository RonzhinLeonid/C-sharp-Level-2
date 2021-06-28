using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data;
using System.Data.SqlClient;

namespace Les8
{
    //Ронжин Л.
    //Изменить WPF-приложение для ведения списка сотрудников компании(из урока 5), используя связывание данных, DataGrid и ADO.NET.
    //Создать таблицы Employee и Department в БД MSSQL Server и заполнить списки сущностей начальными данными.
    //Для списка сотрудников и списка департаментов предусмотреть визуализацию(отображение). Это можно сделать, 
    //например, с использованием ComboBox или ListView.
    //Предусмотреть редактирование сотрудников и департаментов.Должна быть возможность изменить департамент у сотрудника.
    //Список департаментов для выбора можно выводить в ComboBox, и все это можно выводить на дополнительной форме.
    //Предусмотреть возможность создания новых сотрудников и департаментов.Реализовать данную возможность либо на форме редактирования,
    //либо сделать новую форму.


    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connDep;
        SqlConnection connEmpl;
        SqlDataAdapter adapterDep;
        SqlDataAdapter adapterEmpl;
        DataTable dtDep;
        DataTable dtEmpl;
        SqlParameter param;
        SqlCommand commandEmpl;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Отображение сотрудников департамента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvDepartmen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectDepartment();
        }

        private void SelectDepartment()
        {
            if (lvDepartmen.SelectedValue != null)
            {
                DataRowView selRow = (DataRowView)lvDepartmen.SelectedItem;
                string expression = "DepartmentID = " + (int)selRow.Row[0];
                DataRow[] temp = dtEmpl.Select(expression);
                if (temp.Length != 0)
                {
                    DataTable dt1 = temp.CopyToDataTable();
                    lvEmployees.ItemsSource = dt1.DefaultView;
                }
                else
                    lvEmployees.ItemsSource = "";
            }
        }

        /// <summary>
        /// Удаление департамента и перенос сотрудников в раздел без департамента
        /// "без департамента" удалить невозможно
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lvDepartmen.SelectedIndex != 0)
            {
                DataRowView delRow = (DataRowView)lvDepartmen.SelectedItem;
                string expression = "DepartmentID = " + (int)delRow.Row[0];
                var delEmpl = dtEmpl.Select(expression);
                foreach (var item in delEmpl)
                {
                    item.BeginEdit();
                    item["DepartmentID"] = 0;
                    item.EndEdit();
                }
                adapterEmpl.Update(dtEmpl);

                delRow.Row.Delete();
                adapterDep.Update(dtDep);

                lvDepartmen.SelectedIndex = 0;
                SelectDepartment();
            }

        }

        /// <summary>
        /// Открытие карты сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvEmployees_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView selRow = (DataRowView)lvEmployees.SelectedItem;
            string expression = "Id = " + (int)selRow["Id"];
            var selEmpl = dtEmpl.Select(expression);

            selEmpl[0].BeginEdit();

            CardEmployees editWindow = new CardEmployees(selEmpl[0], dtDep);
            editWindow.ShowDialog();


            if (editWindow.DialogResult.HasValue && editWindow.DialogResult.Value)
            {
                selEmpl[0].EndEdit();
                adapterEmpl.Update(dtEmpl);
                SelectDepartment();
            }
            else
            {
                selEmpl[0].CancelEdit();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Загрузка таблицы департаментов
            #region SQLDepartment
            connDep = DBUtils.GetDBConnection();
            adapterDep = new SqlDataAdapter();

            #region select
            SqlCommand commandDep =
               new SqlCommand("SELECT Id, Name FROM Department",
               connDep);
            adapterDep.SelectCommand = commandDep;
            #endregion

            #region insert
            commandDep = new SqlCommand(@"Insert into Department (Name, Description) 
                                            values (@name, @description); SET @Id = @@IDENTITY;",
                          connDep);
            commandDep.Parameters.Add("@name", SqlDbType.NVarChar, -1, "Name");
            commandDep.Parameters.Add("@description", SqlDbType.NVarChar, -1, "Description");

            param = commandDep.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");

            param.Direction = ParameterDirection.Output;
            adapterDep.InsertCommand = commandDep;
            #endregion

            #region update
            commandDep = new SqlCommand(@"UPDATE Department SET Name = @name,
                                                         Description = @description
                                        WHERE ID = @Id", connDep);
            commandDep.Parameters.Add("@description", SqlDbType.NVarChar, -1, "Description");
            param = commandDep.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            adapterDep.UpdateCommand = commandDep;
            #endregion

            #region delete
            commandDep = new SqlCommand("DELETE FROM Department WHERE Id = @Id", connDep);
            param = commandDep.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            adapterDep.DeleteCommand = commandDep;
            #endregion

            dtDep = new DataTable();
            adapterDep.Fill(dtDep);
            lvDepartmen.ItemsSource = dtDep.DefaultView;
            #endregion

            #region SQLEmployee
            connEmpl = DBUtils.GetDBConnection();
            adapterEmpl = new SqlDataAdapter();

            #region select
            commandEmpl =
                    new SqlCommand("SELECT Id, Name, Suname, Age, Salary, PhoneNumber, DepartmentID FROM Employee",
                    connEmpl);
            adapterEmpl.SelectCommand = commandEmpl;
            #endregion

            #region insert
            commandEmpl =
                      new SqlCommand(@"Insert into Employee (Name, Suname, Age, Salary, PhoneNumber, DepartmentID)
                                                     values (@name, @suname, @age, @salary, @phoneNumber, @departmentID);
                                                                                                        SET @Id = @@IDENTITY;",
                      connEmpl);
            commandEmpl.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "Name");
            commandEmpl.Parameters.Add("@Suname", SqlDbType.NVarChar, -1, "Suname");
            commandEmpl.Parameters.Add("@Age", SqlDbType.Int, 0, "Age");
            commandEmpl.Parameters.Add("@Salary", SqlDbType.Int, 0, "Salary");
            commandEmpl.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar, -1, "PhoneNumber");
            commandEmpl.Parameters.Add("@DepartmentID", SqlDbType.Int, 0, "DepartmentID");

            commandEmpl.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            adapterEmpl.UpdateCommand = commandEmpl;
            #endregion

            #region update
            commandEmpl =
                      new SqlCommand(@"UPDATE Employee SET Name = @Name, 
                                                        Suname  = @Suname,
                                                        Age = @Age,
                                                        Salary = @Salary,
                                                        PhoneNumber = @PhoneNumber,
                                                        DepartmentID = @DepartmentID
                                      WHERE Id = @Id",
                      connEmpl);
            commandEmpl.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "Name");
            commandEmpl.Parameters.Add("@Suname", SqlDbType.NVarChar, -1, "Suname");
            commandEmpl.Parameters.Add("@Age", SqlDbType.Int, 0, "Age");
            commandEmpl.Parameters.Add("@Salary", SqlDbType.Int, 0, "Salary");
            commandEmpl.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar, -1, "PhoneNumber");
            commandEmpl.Parameters.Add("@DepartmentID", SqlDbType.Int, 0, "DepartmentID");
            commandEmpl.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            adapterEmpl.UpdateCommand = commandEmpl;
            #endregion

            #region delete
            commandEmpl = new SqlCommand("DELETE FROM Employee WHERE ID = @Id", connEmpl);
            param = commandEmpl.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            adapterEmpl.DeleteCommand = commandEmpl;
            #endregion

            dtEmpl = new DataTable();
            adapterEmpl.Fill(dtEmpl);
            
            #endregion
        }
        
        /// <summary>
        /// Добавить сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            dtEmpl = new DataTable();

            DataRow newRow = dtEmpl.NewRow();
            CardEmployees editWindow = new CardEmployees(dtDep);
            editWindow.ShowDialog();

            if (editWindow.DialogResult.Value)
            {
                dtDep.Rows.Add(editWindow.resultRow);
                adapterEmpl.Update(dtEmpl);
            }
        }
    }
}
