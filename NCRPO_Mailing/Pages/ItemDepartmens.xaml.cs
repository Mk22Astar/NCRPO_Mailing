using Microsoft.EntityFrameworkCore;
using NCRPO_Mailing.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace NCRPO_Mailing.Pages
{
    /// <summary>
    /// Логика взаимодействия для ItemDepartmens.xaml
    /// </summary>
    public partial class ItemDepartmens : Page
    {
        private readonly Departments _departments;
        private ncrpoContext _context;
        public ItemDepartmens(Departments departments)
        {
            InitializeComponent();
            _departments = departments;
            _context = new ncrpoContext();
            LoadUserData();
        }
        
        private void LoadUserData()
        {
            
            tbDeport.Text = _departments.Name;
            var email = _context.Emails.Where(em => em.DepartmentId == _departments.DepartmentId).Select(em => em.Email).ToList();
            
            foreach (string em in email)
            {
                tbEmail.Text+= em +"\n";
            }
            var signatur = _context.Signatures.Where(s => s.DepartmentId == _departments.DepartmentId).Select(s => s.Name).ToList();
            foreach (string s in signatur)
            {
                tbSignatur.Text += s + "\n";
            }
            tbPassword.Text = _departments.Password;

            
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Удалить отдел из базы данных?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {

            }
        }
    }
}
