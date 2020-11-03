using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

namespace WebAPIClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static HttpClient client = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();
            // client.BaseAddress = new Uri("http://localhost:6832/"); http://localhost:54435/ https://localhost:44376/
            client.BaseAddress = new Uri("https://localhost:44376/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        private async void alldepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Department> departments = await GetDepartmentsAsync(client.BaseAddress + "api/Departments");
            departmentDataGrid.ItemsSource = departments;
        }
        private async void iddepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            List<Department> departments = new List<Department>();
            if (iddepartmentTextBox.Text != String.Empty)
            {
                Department department = await GetDepartmentAsync(client.BaseAddress + "api/Departments/" + iddepartmentTextBox.Text);
                if (department != null)
                    departments.Add(department);
            }
            else
            {
                departments = (List<Department>)await GetDepartmentsAsync(client.BaseAddress + "api/Departments");
            }
            departmentDataGrid.ItemsSource = departments;
        }

        static async Task<IEnumerable<Department>> GetDepartmentsAsync(string path)
        {
            IEnumerable<Department> departments = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    departments = await response.Content.ReadAsAsync<IEnumerable<Department>>();
                }
            }
            catch (Exception)
            {
            }
            return departments;
        }

        static async Task<Department> GetDepartmentAsync(string path)
        {
            Department department = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    department = await response.Content.ReadAsAsync<Department>();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return department;
        }



    }
}
