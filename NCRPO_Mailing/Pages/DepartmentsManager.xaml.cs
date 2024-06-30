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
