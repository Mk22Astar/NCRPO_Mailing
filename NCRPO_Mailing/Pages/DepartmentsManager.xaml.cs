using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace NCRPO_Mailing.Pages
{
    /// <summary>
    /// Логика взаимодействия для DepartmentsManager.xaml
    /// </summary>
    public partial class DepartmentsManager : Page
    {
        private ncrpoContext _context;
        public DepartmentsManager()
        {
            InitializeComponent();
            _context= new ncrpoContext();
            LoadData();
        }
        private void LoadData()
        {
            var departments = _context.Departments.Include(d => d.Emails).Include(d => d.Signatures).ToList();
            lvDepartments.ItemsSource = departments;
            

        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {

            string filterText = tbFilter.Text.Trim().ToLower();

            if (!string.IsNullOrEmpty(filterText))
            {
                var filteredDepartments = _context.Departments
                    .Include(d => d.Emails)
                    .Include(d => d.Signatures)
                    .Where(d => d.Name.ToLower().Contains(filterText))
                    .ToList();

                lvDepartments.ItemsSource = filteredDepartments;

            }
            else
            {
                LoadData();
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            /*NavigationService.Navigate(new ItemDepartmens());*/
        }

        private void lvDepartments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (lvDepartments.SelectedItem != null)
            {
                var selectedDepartment = lvDepartments.SelectedItem as Departments;
                NavigationService.Navigate(new ItemDepartmens(selectedDepartment));
            }
        }
    }
}
