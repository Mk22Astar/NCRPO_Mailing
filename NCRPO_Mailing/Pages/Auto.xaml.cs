using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace NCRPO_Mailing.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auto.xaml
    /// </summary>
    public partial class Auto : Page
    {
        public Auto()
        {
            InitializeComponent();
            using (var context = new ncrpoContext())
            {
                var departments = context.Departments.ToList();
                cbLogin.ItemsSource = departments;
            }

        }

        private void btnAuthorization_Click(object sender, RoutedEventArgs e)
        {
            var departmentName = cbLogin.Text;
            var password = tbPassword.Text;
            var departmentId = GetDepartment(departmentName, password);
            if (departmentId is null)
            {
                MessageBox.Show("ID отдела не найден. Пожалуйста, проверьте выбранное название отдела.");
            }
            else
            {
                NavigationService.Navigate(new SendingMessages((int)departmentId));
            }            
        }

        public int? GetDepartment(string departmentName, string password)
        {
            using (var context = new ncrpoContext())
            {
                return  context.Departments.FirstOrDefault(d => d.Name == departmentName && d.Password == password)?.DepartmentId;
            }
        }

    }
}
