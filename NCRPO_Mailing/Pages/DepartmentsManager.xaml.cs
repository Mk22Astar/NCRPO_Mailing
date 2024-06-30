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
    /// Логика взаимодействия для DepartmentsManager.xaml
    /// </summary>
    public partial class DepartmentsManager : Page
    {
        public DepartmentsManager()
        {
            InitializeComponent();
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ItemDepartmens());
        }

        private void lvDepartments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new ItemDepartmens());
        }
    }
}
