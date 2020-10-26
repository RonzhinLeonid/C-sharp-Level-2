﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data;
using System.Data.SqlClient;

namespace Les7
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
            if (lvDepartmen.SelectedValue != null)
            {
                //Загрузка таблицы сотрудников
                DataRowView newRow = (DataRowView)lvDepartmen.SelectedItem;
                commandEmpl =
                new SqlCommand("SELECT Id, Name, Suname, Age, Salary, PhoneNumber, DepartmentID FROM Employee Where DepartmentID = @IdDep",
                connEmpl);
                commandEmpl.Parameters.Add("@IdDep", SqlDbType.NVarChar, 0, newRow.Row[0].ToString());
                commandEmpl.Parameters["@IdDep"].Value = newRow.Row[0].ToString();
                adapterEmpl.SelectCommand = commandEmpl;
                
                dtEmpl = new DataTable();
                adapterEmpl.Fill(dtEmpl);
                lvEmployees.ItemsSource = dtEmpl.DefaultView;
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

                //commandEmpl =
                //   new SqlCommand("UPDATE Employee SET Employee.DepartmentID = @DepartmentID WHERE Employee.DepartmentID = @IdDep",
                //   connEmpl);//UPDATE Employee SET DepartmentID = 0 WHERE Employee.DepartmentID = 16
                //commandEmpl.Parameters.Add("@DepartmentID", SqlDbType.Int, -1, "0");
                //commandEmpl.Parameters["@DepartmentID"].Value = 0;
                //commandEmpl.Parameters.Add("@IdDep", SqlDbType.NVarChar, 0, "IdDep");
                //commandEmpl.Parameters["@IdDep"].Value = delRow.Row[0].ToString();

                //commandEmpl.ExecuteNonQuery();

                //adapterEmpl.UpdateCommand = commandEmpl;

                //commandEmpl.Parameters["@IdDep"].Value = delRow.Row[0].ToString();
                //adapterEmpl.UpdateCommand = commandEmpl;
                adapterEmpl.Update(dtEmpl);


                delRow.Row.Delete();
                adapterDep.Update(dtDep);

            }
            //надо добавить удаление сотрудников или перенос их в департамент с индексом 0
        }
        /// <summary>
        /// Открытие карты сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvEmployees_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            commandEmpl =
                  new SqlCommand(@"UPDATE Employee SET Name = @Name, 
                                                        Suneme  = @Suneme,
                                                        Age = @Age,
                                                        Salary = @Salary,
                                                        PhoneNumber = @PhoneNumber,
                                                        DepartmentID = @DepartmentID
                                      WHERE ID = @ID",
                  connEmpl);
            commandEmpl.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "Name");
            commandEmpl.Parameters.Add("@Suneme", SqlDbType.NVarChar, -1, "Suneme");
            commandEmpl.Parameters.Add("@Age", SqlDbType.Int, 0, "Age");
            commandEmpl.Parameters.Add("@Salary", SqlDbType.Int, 0, "Salary");
            commandEmpl.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar, -1, "PhoneNumber");
            commandEmpl.Parameters.Add("@DepartmentID", SqlDbType.Int, 0, "DepartmentID");
            commandEmpl.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
            adapterEmpl.UpdateCommand = commandEmpl;


            DataRowView newRow = (DataRowView)lvEmployees.SelectedItem;
            newRow.BeginEdit();

            CardEmployees editWindow = new CardEmployees(newRow.Row, dtDep);
            editWindow.ShowDialog();



            if (editWindow.DialogResult.HasValue && editWindow.DialogResult.Value)
            {
                newRow.EndEdit();
                adapterEmpl.Update(dtEmpl);
            }
            else
            {
                newRow.CancelEdit();
            }

            //не реализовано
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Загрузка таблицы департаментов
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
                                            values (@name, @description); SET @ID = @@IDENTITY;",
                          connDep);
            commandDep.Parameters.Add("@name", SqlDbType.NVarChar, -1, "Name");
            commandDep.Parameters.Add("@description", SqlDbType.NVarChar, -1, "Description");

            param = commandDep.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");

            param.Direction = ParameterDirection.Output;
            adapterDep.InsertCommand = commandDep;
            #endregion

            #region update
            commandDep = new SqlCommand(@"UPDATE Department SET Name = @name,
                                                         Description = @description
                                        WHERE ID = @ID", connDep);
           
            commandDep.Parameters.Add("@description", SqlDbType.NVarChar, -1, "Description");
            param = commandDep.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
            adapterDep.UpdateCommand = commandDep;
            #endregion

            #region delete
            commandDep = new SqlCommand("DELETE FROM Department WHERE ID = @ID", connDep);
            param = commandDep.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
            adapterDep.DeleteCommand = commandDep;
            #endregion

            dtDep = new DataTable();
            adapterDep.Fill(dtDep);
            lvDepartmen.ItemsSource = dtDep.DefaultView;

            #region заготовка для сотрудников


            connEmpl = DBUtils.GetDBConnection();
            adapterEmpl = new SqlDataAdapter();

            

            

            //commandEmpl = new SqlCommand("DELETE FROM Employee WHERE DepartmentID = @ID", connEmpl);
            #endregion
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}