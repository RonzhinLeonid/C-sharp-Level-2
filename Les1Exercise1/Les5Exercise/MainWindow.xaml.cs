﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Les5Exercise
{
    //Ронжин Л.
    //Изменить WPF-приложение для ведения списка сотрудников компании(из урока 5), используя связывание данных, 
    //ListView, ObservableCollection и INotifyPropertyChanged.
    //Создать сущности Employee и Department и заполнить списки сущностей начальными данными.
    //Для списка сотрудников и списка департаментов предусмотреть визуализацию(отображение). Это можно сделать, например,
    //с использованием ComboBox или ListView.
    //Предусмотреть редактирование сотрудников и департаментов.Должна быть возможность изменить департамент у сотрудника.
    //Список департаментов для выбора можно выводить в ComboBox, и все это можно выводить на дополнительной форме.
    //Предусмотреть возможность создания новых сотрудников и департаментов.Реализовать данную возможность либо на форме 
    //редактирования, либо сделать новую форму.

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataBase data;
        public MainWindow()
        {

            InitializeComponent();
            data = new DataBase(1000, 100_000);
            this.DataContext = data;
            //Добавление нового сотрудника и заполнение данных через карту сотрудника
            AddEmployee.Click += delegate
            {
                data.EmployeesDB.Add(new Employee(data.EmployeesDB.Count + 1,
                                            "Имя",
                                            "Фамилия",
                                            0,
                                            0,
                                            "000-00-00",
                                            0));
                new CardEmployees(data.EmployeesDB.Count - 1, data).ShowDialog();
            };
            lvDepartmen.ItemsSource = data.DepartmentDB;
        }
        /// <summary>
        /// Отображение сотрудников департамента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvDepartmen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvDepartmen.SelectedValue != null)
              lvEmployees.ItemsSource = data.EmployeesDB.Where(x => x.DepartmentID == (lvDepartmen.SelectedValue as Department).ID);
        }
        /// <summary>
        /// Удаление департамента и перенос сотрудников в раздел без департамента
        /// "без департамента" elfkbnm ytdjpvj;yj
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lvDepartmen.SelectedIndex != 0)
            {
                data.DeleteDepartment((lvDepartmen.SelectedValue as Department).ID);
                lvDepartmen.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// Открытие карты сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvEmployees_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new CardEmployees(data.EmployeesDB.IndexOf(lvEmployees.SelectedItem as Employee), data).ShowDialog();
            
        }
    }
}
