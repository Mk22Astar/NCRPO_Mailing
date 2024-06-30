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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            string departmentName = cbLogin.Text;
            string password = tbPassword.Text;
            if (Authenticate(departmentName, password))
            {
                using (var context = new ncrpoContext())
                {
                    var departmentId = context.Departments.Where(d => d.Name == departmentName).Select(d => d.DepartmentId).FirstOrDefault();
                    if (departmentId != 0)
                    {
                        NavigationService.Navigate(new SendingMessages(departmentId));
                    }
                    else
                    {
                        MessageBox.Show("ID отдела не найден. Пожалуйста, проверьте выбранное название отдела.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите название своего отдела из списка или введите вручную.\nПароль не сложный: passw0rd+цифра\n\nP.S. Если вашего отдела здесь нет, жалуйтесь руководителю, я бессилен.");
            }

            
        }
        public bool Authenticate(string departmentName, string password)
        {
            using (var context = new ncrpoContext())
            {
                var department = context.Departments.FirstOrDefault(d => d.Name == departmentName && d.Password == password);
                return department != null;
            }
        }

    }
}
